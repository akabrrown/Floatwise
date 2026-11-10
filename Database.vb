Imports System.Collections.Generic
Imports System.Data.SQLite
Imports System.Globalization
Imports System.IO

' =====================================================================
'  Database.vb - SQLite local embedded database engine for FloatWise.
'  Persists users, wallet balances, transactions, audit logs, and till state
'  in %AppData%\FloatWise\floatwise.db with full ACID transaction safety.
' =====================================================================

Public Module Database

    Private ReadOnly Property DbFolder As String
        Get
            Dim p As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FloatWise")
            If Not Directory.Exists(p) Then Directory.CreateDirectory(p)
            Return p
        End Get
    End Property

    Public ReadOnly Property DbPath As String
        Get
            Return Path.Combine(DbFolder, "floatwise.db")
        End Get
    End Property

    Private Function GetConnectionString() As String
        Return "Data Source=" & DbPath & ";Version=3;Pooling=True;Journal Mode=WAL;"
    End Function

    Public Function GetConnection() As SQLiteConnection
        Dim conn As New SQLiteConnection(GetConnectionString())
        conn.Open()
        Return conn
    End Function

    ''' <summary>Initializes tables and default data on application startup.</summary>
    Public Sub InitDatabase()
        Dim existsBefore As Boolean = File.Exists(DbPath)
        If Not existsBefore Then
            SQLiteConnection.CreateFile(DbPath)
        End If

        Using conn As SQLiteConnection = GetConnection()
            Using cmd As SQLiteCommand = conn.CreateCommand()
                cmd.CommandText = "
                    CREATE TABLE IF NOT EXISTS users (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        username TEXT UNIQUE NOT NULL COLLATE NOCASE,
                        full_name TEXT NOT NULL,
                        role TEXT NOT NULL,
                        salt TEXT NOT NULL,
                        hash TEXT NOT NULL,
                        active INTEGER NOT NULL DEFAULT 1,
                        created TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS wallet_floats (
                        network TEXT PRIMARY KEY,
                        balance REAL NOT NULL DEFAULT 0.0,
                        low_limit REAL NOT NULL DEFAULT 0.0
                    );

                    CREATE TABLE IF NOT EXISTS till_state (
                        key TEXT PRIMARY KEY,
                        value TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS transactions (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        time_text TEXT NOT NULL,
                        network TEXT NOT NULL,
                        txn_type TEXT NOT NULL,
                        phone TEXT,
                        amount REAL NOT NULL,
                        commission REAL NOT NULL,
                        recorded_by TEXT NOT NULL,
                        role TEXT NOT NULL,
                        is_voided INTEGER NOT NULL DEFAULT 0,
                        void_reason TEXT
                    );

                    CREATE TABLE IF NOT EXISTS audit_logs (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        time_text TEXT NOT NULL,
                        username TEXT NOT NULL,
                        role TEXT,
                        activity TEXT NOT NULL,
                        details TEXT
                    );

                    CREATE TABLE IF NOT EXISTS cash_counts (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        time_text TEXT NOT NULL,
                        counted_total REAL NOT NULL,
                        system_till REAL NOT NULL,
                        difference REAL NOT NULL,
                        status TEXT NOT NULL,
                        recorded_by TEXT NOT NULL
                    );
                "
                cmd.ExecuteNonQuery()

                ' Ensure default networks exist in wallet_floats
                Dim defaultNetworks() As String = {"MTN MoMo", "Telecel Cash", "AirtelTigo Money"}
                For Each net As String In defaultNetworks
                    cmd.CommandText = "INSERT OR IGNORE INTO wallet_floats (network, balance, low_limit) VALUES (@net, 0.0, 0.0);"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@net", net)
                    cmd.ExecuteNonQuery()
                Next

                ' Ensure cash_in_till exists in till_state
                cmd.CommandText = "INSERT OR IGNORE INTO till_state (key, value) VALUES ('cash_in_till', '0.00');"
                cmd.Parameters.Clear()
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT OR IGNORE INTO till_state (key, value) VALUES ('counted_cash', '-1.00');"
                cmd.Parameters.Clear()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Automatic migration from legacy users.txt if users table is empty
        MigrateLegacyUsers()
    End Sub

    Private Sub MigrateLegacyUsers()
        Dim txtFile As String = Path.Combine(DbFolder, "users.txt")
        If Not File.Exists(txtFile) Then Return

        Using conn As SQLiteConnection = GetConnection()
            Using checkCmd As New SQLiteCommand("SELECT COUNT(*) FROM users;", conn)
                Dim count As Long = Convert.ToInt64(checkCmd.ExecuteScalar())
                If count > 0 Then Return ' Already has users in SQLite
            End Using

            ' Read lines from legacy users.txt
            Try
                Dim lines() As String = File.ReadAllLines(txtFile)
                Using tx As SQLiteTransaction = conn.BeginTransaction()
                    For Each line As String In lines
                        Dim p() As String = line.Split("|"c)
                        If p.Length >= 7 Then
                            Using insCmd As New SQLiteCommand("
                                INSERT OR IGNORE INTO users (username, role, full_name, salt, hash, active, created)
                                VALUES (@user, @role, @name, @salt, @hash, @active, @created);", conn, tx)
                                insCmd.Parameters.AddWithValue("@user", p(0))
                                insCmd.Parameters.AddWithValue("@role", p(1))
                                insCmd.Parameters.AddWithValue("@name", p(2))
                                insCmd.Parameters.AddWithValue("@salt", p(3))
                                insCmd.Parameters.AddWithValue("@hash", p(4))
                                insCmd.Parameters.AddWithValue("@active", If(p(5) = "1", 1, 0))
                                insCmd.Parameters.AddWithValue("@created", p(6))
                                insCmd.ExecuteNonQuery()
                            End Using
                        End If
                    Next
                    tx.Commit()
                End Using
            Catch
                ' Non-critical migration fallback
            End Try
        End Using
    End Sub

    ' =================================================================
    '  USERS
    ' =================================================================

    Public Function DbLoadUsers() As List(Of UserAccount)
        Dim list As New List(Of UserAccount)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("SELECT username, role, full_name, salt, hash, active, created FROM users ORDER BY id ASC;", conn)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(New UserAccount With {
                            .Username = reader.GetString(0),
                            .Role = reader.GetString(1),
                            .FullName = reader.GetString(2),
                            .Salt = reader.GetString(3),
                            .Hash = reader.GetString(4),
                            .Active = (reader.GetInt32(5) = 1),
                            .Created = reader.GetString(6)
                        })
                    End While
                End Using
            End Using
        End Using
        Return list
    End Function

    Public Sub DbSaveUser(u As UserAccount)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("
                INSERT INTO users (username, role, full_name, salt, hash, active, created)
                VALUES (@user, @role, @name, @salt, @hash, @active, @created)
                ON CONFLICT(username) DO UPDATE SET
                    role = excluded.role,
                    full_name = excluded.full_name,
                    salt = excluded.salt,
                    hash = excluded.hash,
                    active = excluded.active;", conn)
                cmd.Parameters.AddWithValue("@user", u.Username)
                cmd.Parameters.AddWithValue("@role", u.Role)
                cmd.Parameters.AddWithValue("@name", u.FullName)
                cmd.Parameters.AddWithValue("@salt", u.Salt)
                cmd.Parameters.AddWithValue("@hash", u.Hash)
                cmd.Parameters.AddWithValue("@active", If(u.Active, 1, 0))
                cmd.Parameters.AddWithValue("@created", u.Created)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DbUpdateUserActive(username As String, active As Boolean)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("UPDATE users SET active = @active WHERE username = @user;", conn)
                cmd.Parameters.AddWithValue("@active", If(active, 1, 0))
                cmd.Parameters.AddWithValue("@user", username)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' =================================================================
    '  WALLET BALANCES & LIMITS
    ' =================================================================

    Public Sub DbLoadBalances(floats As Dictionary(Of String, Decimal), limits As Dictionary(Of String, Decimal), ByRef cashInTill As Decimal, ByRef countedCash As Decimal)
        Using conn As SQLiteConnection = GetConnection()
            ' Wallet floats
            Using cmd As New SQLiteCommand("SELECT network, balance, low_limit FROM wallet_floats;", conn)
                Using r As SQLiteDataReader = cmd.ExecuteReader()
                    While r.Read()
                        Dim net As String = r.GetString(0)
                        floats(net) = Convert.ToDecimal(r.GetDouble(1))
                        limits(net) = Convert.ToDecimal(r.GetDouble(2))
                    End While
                End Using
            End Using

            ' Till state
            Using cmd As New SQLiteCommand("SELECT key, value FROM till_state;", conn)
                Using r As SQLiteDataReader = cmd.ExecuteReader()
                    While r.Read()
                        Dim k As String = r.GetString(0)
                        Dim v As String = r.GetString(1)
                        Dim decVal As Decimal
                        If Decimal.TryParse(v, NumberStyles.Any, CultureInfo.InvariantCulture, decVal) Then
                            If k = "cash_in_till" Then cashInTill = decVal
                            If k = "counted_cash" Then countedCash = decVal
                        End If
                    End While
                End Using
            End Using
        End Using
    End Sub

    Public Sub DbSaveBalances(cashInTill As Decimal, floats As Dictionary(Of String, Decimal))
        Using conn As SQLiteConnection = GetConnection()
            Using tx As SQLiteTransaction = conn.BeginTransaction()
                Using cmdTill As New SQLiteCommand("INSERT OR REPLACE INTO till_state (key, value) VALUES ('cash_in_till', @val);", conn, tx)
                    cmdTill.Parameters.AddWithValue("@val", cashInTill.ToString("F2", CultureInfo.InvariantCulture))
                    cmdTill.ExecuteNonQuery()
                End Using

                For Each kvp In floats
                    Using cmdFloat As New SQLiteCommand("
                        INSERT INTO wallet_floats (network, balance, low_limit)
                        VALUES (@net, @bal, 0.0)
                        ON CONFLICT(network) DO UPDATE SET balance = excluded.balance;", conn, tx)
                        cmdFloat.Parameters.AddWithValue("@net", kvp.Key)
                        cmdFloat.Parameters.AddWithValue("@bal", Convert.ToDouble(kvp.Value))
                        cmdFloat.ExecuteNonQuery()
                    End Using
                Next
                tx.Commit()
            End Using
        End Using
    End Sub

    Public Sub DbSaveLimit(network As String, limit As Decimal)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("
                INSERT INTO wallet_floats (network, balance, low_limit)
                VALUES (@net, 0.0, @limit)
                ON CONFLICT(network) DO UPDATE SET low_limit = excluded.low_limit;", conn)
                cmd.Parameters.AddWithValue("@net", network)
                cmd.Parameters.AddWithValue("@limit", Convert.ToDouble(limit))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DbSaveTillState(key As String, value As String)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("INSERT OR REPLACE INTO till_state (key, value) VALUES (@key, @val);", conn)
                cmd.Parameters.AddWithValue("@key", key)
                cmd.Parameters.AddWithValue("@val", value)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' =================================================================
    '  TRANSACTIONS (ACID Atomic Execution)
    ' =================================================================

    Public Function DbLoadTransactions() As List(Of Txn)
        Dim list As New List(Of Txn)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("
                SELECT id, time_text, network, txn_type, phone, amount, commission, recorded_by, role
                FROM transactions
                WHERE is_voided = 0
                ORDER BY id DESC;", conn)
                Using r As SQLiteDataReader = cmd.ExecuteReader()
                    While r.Read()
                        list.Add(New Txn With {
                            .Id = r.GetInt32(0),
                            .TimeText = r.GetString(1),
                            .Network = r.GetString(2),
                            .TxnType = r.GetString(3),
                            .Phone = If(r.IsDBNull(4), "", r.GetString(4)),
                            .Amount = Convert.ToDecimal(r.GetDouble(5)),
                            .Commission = Convert.ToDecimal(r.GetDouble(6)),
                            .RecordedBy = r.GetString(7),
                            .Role = If(r.IsDBNull(8), "", r.GetString(8))
                        })
                    End While
                End Using
            End Using
        End Using
        Return list
    End Function

    ''' <summary>
    ''' Atomically inserts transaction, adjusts float balance, adjusts cash in till,
    ''' and records audit log within a single SQLite transaction.
    ''' </summary>
    Public Function DbExecuteTransaction(t As Txn, newTill As Decimal, newFloat As Decimal, logMsg As String) As Integer
        Using conn As SQLiteConnection = GetConnection()
            Using tx As SQLiteTransaction = conn.BeginTransaction()
                Dim insertedId As Integer = 0
                ' 1. Insert transaction
                Using cmdTxn As New SQLiteCommand("
                    INSERT INTO transactions (time_text, network, txn_type, phone, amount, commission, recorded_by, role, is_voided)
                    VALUES (@time, @net, @type, @phone, @amt, @comm, @user, @role, 0);
                    SELECT last_insert_rowid();", conn, tx)
                    cmdTxn.Parameters.AddWithValue("@time", t.TimeText)
                    cmdTxn.Parameters.AddWithValue("@net", t.Network)
                    cmdTxn.Parameters.AddWithValue("@type", t.TxnType)
                    cmdTxn.Parameters.AddWithValue("@phone", If(String.IsNullOrEmpty(t.Phone), DBNull.Value, CObj(t.Phone)))
                    cmdTxn.Parameters.AddWithValue("@amt", Convert.ToDouble(t.Amount))
                    cmdTxn.Parameters.AddWithValue("@comm", Convert.ToDouble(t.Commission))
                    cmdTxn.Parameters.AddWithValue("@user", t.RecordedBy)
                    cmdTxn.Parameters.AddWithValue("@role", t.Role)
                    insertedId = Convert.ToInt32(cmdTxn.ExecuteScalar())
                End Using

                ' 2. Update float balance
                Using cmdFloat As New SQLiteCommand("UPDATE wallet_floats SET balance = @bal WHERE network = @net;", conn, tx)
                    cmdFloat.Parameters.AddWithValue("@bal", Convert.ToDouble(newFloat))
                    cmdFloat.Parameters.AddWithValue("@net", t.Network)
                    cmdFloat.ExecuteNonQuery()
                End Using

                ' 3. Update till cash
                Using cmdTill As New SQLiteCommand("INSERT OR REPLACE INTO till_state (key, value) VALUES ('cash_in_till', @val);", conn, tx)
                    cmdTill.Parameters.AddWithValue("@val", newTill.ToString("F2", CultureInfo.InvariantCulture))
                    cmdTill.ExecuteNonQuery()
                End Using

                ' 4. Add audit log
                Using cmdLog As New SQLiteCommand("
                    INSERT INTO audit_logs (time_text, username, role, activity, details)
                    VALUES (@time, @user, @role, @act, @details);", conn, tx)
                    cmdLog.Parameters.AddWithValue("@time", Date.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmdLog.Parameters.AddWithValue("@user", t.RecordedBy)
                    cmdLog.Parameters.AddWithValue("@role", t.Role)
                    cmdLog.Parameters.AddWithValue("@act", t.TxnType)
                    cmdLog.Parameters.AddWithValue("@details", logMsg)
                    cmdLog.ExecuteNonQuery()
                End Using

                tx.Commit()
                Return insertedId
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Atomically marks transaction voided, reverses till and float, and writes audit record.
    ''' </summary>
    Public Sub DbVoidTransaction(txnId As Integer, net As String, newTill As Decimal, newFloat As Decimal, reason As String, adminUser As String, adminRole As String, auditDetails As String)
        Using conn As SQLiteConnection = GetConnection()
            Using tx As SQLiteTransaction = conn.BeginTransaction()
                ' 1. Mark transaction voided
                Using cmdTxn As New SQLiteCommand("UPDATE transactions SET is_voided = 1, void_reason = @reason WHERE id = @id;", conn, tx)
                    cmdTxn.Parameters.AddWithValue("@reason", reason)
                    cmdTxn.Parameters.AddWithValue("@id", txnId)
                    cmdTxn.ExecuteNonQuery()
                End Using

                ' 2. Reverse float
                Using cmdFloat As New SQLiteCommand("UPDATE wallet_floats SET balance = @bal WHERE network = @net;", conn, tx)
                    cmdFloat.Parameters.AddWithValue("@bal", Convert.ToDouble(newFloat))
                    cmdFloat.Parameters.AddWithValue("@net", net)
                    cmdFloat.ExecuteNonQuery()
                End Using

                ' 3. Reverse till cash
                Using cmdTill As New SQLiteCommand("INSERT OR REPLACE INTO till_state (key, value) VALUES ('cash_in_till', @val);", conn, tx)
                    cmdTill.Parameters.AddWithValue("@val", newTill.ToString("F2", CultureInfo.InvariantCulture))
                    cmdTill.ExecuteNonQuery()
                End Using

                ' 4. Add audit log
                Using cmdLog As New SQLiteCommand("
                    INSERT INTO audit_logs (time_text, username, role, activity, details)
                    VALUES (@time, @user, @role, 'Void', @details);", conn, tx)
                    cmdLog.Parameters.AddWithValue("@time", Date.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmdLog.Parameters.AddWithValue("@user", adminUser)
                    cmdLog.Parameters.AddWithValue("@role", adminRole)
                    cmdLog.Parameters.AddWithValue("@details", auditDetails)
                    cmdLog.ExecuteNonQuery()
                End Using

                tx.Commit()
            End Using
        End Using
    End Sub

    ' =================================================================
    '  AUDIT LOGS
    ' =================================================================

    Public Function DbLoadLogs(Optional limit As Integer = 500) As List(Of LogEntry)
        Dim list As New List(Of LogEntry)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("
                SELECT time_text, username, role, activity, details
                FROM audit_logs
                ORDER BY id DESC
                LIMIT @lim;", conn)
                cmd.Parameters.AddWithValue("@lim", limit)
                Using r As SQLiteDataReader = cmd.ExecuteReader()
                    While r.Read()
                        list.Add(New LogEntry With {
                            .TimeText = r.GetString(0),
                            .UserName = r.GetString(1),
                            .Role = If(r.IsDBNull(2), "", r.GetString(2)),
                            .Activity = r.GetString(3),
                            .Details = If(r.IsDBNull(4), "", r.GetString(4))
                        })
                    End While
                End Using
            End Using
        End Using
        Return list
    End Function

    Public Sub DbInsertLog(l As LogEntry)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("
                INSERT INTO audit_logs (time_text, username, role, activity, details)
                VALUES (@time, @user, @role, @act, @details);", conn)
                cmd.Parameters.AddWithValue("@time", l.TimeText)
                cmd.Parameters.AddWithValue("@user", l.UserName)
                cmd.Parameters.AddWithValue("@role", l.Role)
                cmd.Parameters.AddWithValue("@act", l.Activity)
                cmd.Parameters.AddWithValue("@details", l.Details)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DbClearLogs()
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("DELETE FROM audit_logs;", conn)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DbDeleteLog(timeText As String, user As String, activity As String)
        Using conn As SQLiteConnection = GetConnection()
            Using cmd As New SQLiteCommand("
                DELETE FROM audit_logs
                WHERE id IN (
                    SELECT id FROM audit_logs
                    WHERE time_text = @time AND username = @user AND activity = @act
                    LIMIT 1
                );", conn)
                cmd.Parameters.AddWithValue("@time", timeText)
                cmd.Parameters.AddWithValue("@user", user)
                cmd.Parameters.AddWithValue("@act", activity)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' =================================================================
    '  CASH COUNTS
    ' =================================================================

    Public Sub DbRecordCashCount(timeText As String, countedTotal As Decimal, systemTill As Decimal, diff As Decimal, status As String, recordedBy As String)
        Using conn As SQLiteConnection = GetConnection()
            Using tx As SQLiteTransaction = conn.BeginTransaction()
                Using cmd As New SQLiteCommand("
                    INSERT INTO cash_counts (time_text, counted_total, system_till, difference, status, recorded_by)
                    VALUES (@time, @counted, @sys, @diff, @stat, @user);", conn, tx)
                    cmd.Parameters.AddWithValue("@time", timeText)
                    cmd.Parameters.AddWithValue("@counted", Convert.ToDouble(countedTotal))
                    cmd.Parameters.AddWithValue("@sys", Convert.ToDouble(systemTill))
                    cmd.Parameters.AddWithValue("@diff", Convert.ToDouble(diff))
                    cmd.Parameters.AddWithValue("@stat", status)
                    cmd.Parameters.AddWithValue("@user", recordedBy)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmdState As New SQLiteCommand("INSERT OR REPLACE INTO till_state (key, value) VALUES ('counted_cash', @val);", conn, tx)
                    cmdState.Parameters.AddWithValue("@val", countedTotal.ToString("F2", CultureInfo.InvariantCulture))
                    cmdState.ExecuteNonQuery()
                End Using

                tx.Commit()
            End Using
        End Using
    End Sub

End Module

