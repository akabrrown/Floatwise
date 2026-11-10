Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq

' =====================================================================
'  Models.vb - Data shapes and Ledger service layer backed by SQLite.
'  Combines high-speed in-memory cached state with immediate SQLite persistence.
' =====================================================================

Public Class Txn
    Public Property Id As Integer
    Public Property TimeText As String
    Public Property Network As String
    Public Property TxnType As String
    Public Property Phone As String
    Public Property Amount As Decimal
    Public Property Commission As Decimal
    Public Property RecordedBy As String
    Public Property Role As String
End Class

Public Class LogEntry
    Public Property TimeText As String
    Public Property UserName As String
    Public Property Role As String
    Public Property Activity As String
    Public Property Details As String
End Class

Public Module Ledger

    ' ---- settings you can change ----
    Public Const MaxAmount As Decimal = 10000D        ' biggest single transaction
    Public Const CashInRate As Decimal = 0.005D       ' 0.5 % commission on Cash-In
    Public Const CashOutRate As Decimal = 0.008D      ' 0.8 % commission on Cash-Out
    Public Const TypeCashIn As String = "Cash-In"
    Public Const TypeCashOut As String = "Cash-Out"
    Public Const TypeTopUp As String = "Float Top-up"

    Public ReadOnly Networks() As String = {"MTN MoMo", "Telecel Cash", "AirtelTigo Money"}

    ' ---- data kept in memory and synchronized with SQLite ----
    Public ReadOnly Floats As New Dictionary(Of String, Decimal)
    Public ReadOnly Limits As New Dictionary(Of String, Decimal)
    Public ReadOnly Txns As New List(Of Txn)
    Public ReadOnly Logs As New List(Of LogEntry)
    Public ReadOnly WalletActual As New Dictionary(Of String, Decimal)
    Public CashInTill As Decimal = 0D
    Public NextId As Integer = 1
    Public NotBackedUp As Boolean = False
    Public CountedCash As Decimal = -1D               ' -1 = no cash count yet

    Private started As Boolean = False

    ''' <summary>Initializes and loads persistent state from SQLite database.</summary>
    Public Sub LoadFromDb()
        started = True
        For Each n As String In Networks
            Floats(n) = 0D
            Limits(n) = 0D
        Next

        Try
            Database.DbLoadBalances(Floats, Limits, CashInTill, CountedCash)
        Catch ex As Exception
            ' Fallback if table not ready
        End Try

        Txns.Clear()
        Try
            Dim loadedTxns As List(Of Txn) = Database.DbLoadTransactions()
            Txns.AddRange(loadedTxns)
            If Txns.Count > 0 Then
                NextId = Txns.Max(Function(x) x.Id) + 1
            Else
                NextId = 1
            End If
        Catch ex As Exception
        End Try

        Logs.Clear()
        Try
            Dim loadedLogs As List(Of LogEntry) = Database.DbLoadLogs()
            Logs.AddRange(loadedLogs)
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>Backward-compatible startup call that delegates to SQLite LoadFromDb.</summary>
    Public Sub InitDemoOnce()
        If started Then Return
        LoadFromDb()
    End Sub

    Public Sub AddLog(user As String, activity As String, details As String, Optional role As String = "")
        Dim entry As New LogEntry With {
            .TimeText = Date.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            .UserName = user,
            .Role = role,
            .Activity = activity,
            .Details = details}
        Logs.Insert(0, entry)
        Try
            Database.DbInsertLog(entry)
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Atomically executes a transaction, updating in-memory balances and persisting
    ''' transaction, balance adjustments, and audit log to SQLite.
    ''' </summary>
    Public Function ExecuteTransaction(t As Txn, logMsg As String) As Boolean
        Select Case t.TxnType
            Case TypeCashIn
                CashInTill += t.Amount
                Floats(t.Network) -= t.Amount
            Case TypeCashOut, TypeTopUp
                CashInTill -= t.Amount
                Floats(t.Network) += t.Amount
        End Select

        Try
            Dim newId As Integer = Database.DbExecuteTransaction(t, CashInTill, Floats(t.Network), logMsg)
            If newId > 0 Then t.Id = newId
            Txns.Insert(0, t)
            If t.Id >= NextId Then NextId = t.Id + 1

            Logs.Insert(0, New LogEntry With {
                .TimeText = Date.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                .UserName = t.RecordedBy,
                .Role = t.Role,
                .Activity = t.TxnType,
                .Details = logMsg})
            NotBackedUp = True
            Return True
        Catch ex As Exception
            ' Revert in-memory changes if DB failed
            Select Case t.TxnType
                Case TypeCashIn
                    CashInTill -= t.Amount
                    Floats(t.Network) += t.Amount
                Case TypeCashOut, TypeTopUp
                    CashInTill += t.Amount
                    Floats(t.Network) -= t.Amount
            End Select
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Atomically voids a transaction, reversing cash/float movements in memory and in SQLite.
    ''' </summary>
    Public Function VoidTransaction(t As Txn, reason As String, adminUser As String, adminRole As String, auditDetails As String) As Boolean
        Select Case t.TxnType
            Case TypeCashIn
                CashInTill -= t.Amount
                Floats(t.Network) += t.Amount
            Case TypeCashOut, TypeTopUp
                CashInTill += t.Amount
                Floats(t.Network) -= t.Amount
        End Select

        Try
            Database.DbVoidTransaction(t.Id, t.Network, CashInTill, Floats(t.Network), reason, adminUser, adminRole, auditDetails)
            Txns.Remove(t)
            Logs.Insert(0, New LogEntry With {
                .TimeText = Date.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                .UserName = adminUser,
                .Role = adminRole,
                .Activity = "Void",
                .Details = auditDetails})
            NotBackedUp = True
            Return True
        Catch ex As Exception
            ' Revert in-memory reversal if DB failed
            Select Case t.TxnType
                Case TypeCashIn
                    CashInTill += t.Amount
                    Floats(t.Network) -= t.Amount
                Case TypeCashOut, TypeTopUp
                    CashInTill -= t.Amount
                    Floats(t.Network) += t.Amount
            End Select
            Throw
        End Try
    End Function

    Public Sub SaveBalances(cash As Decimal, newFloats As Dictionary(Of String, Decimal))
        CashInTill = cash
        For Each kvp In newFloats
            Floats(kvp.Key) = kvp.Value
        Next
        Database.DbSaveBalances(CashInTill, Floats)
        NotBackedUp = True
    End Sub

    Public Sub SaveLimit(network As String, limit As Decimal)
        Limits(network) = limit
        Database.DbSaveLimit(network, limit)
    End Sub

    Public Sub SaveTillState(key As String, value As String)
        Database.DbSaveTillState(key, value)
    End Sub

    Public Sub RecordCashCount(counted As Decimal, user As String)
        CountedCash = counted
        Dim diff As Decimal = counted - CashInTill
        Dim stat As String = If(counted = 0D, "-", If(diff = 0D, "MATCH", If(diff > 0D, "OVER", "SHORT")))
        Database.DbRecordCashCount(Date.Now.ToString("yyyy-MM-dd HH:mm:ss"), counted, CashInTill, diff, stat, user)
    End Sub

    Public Sub ClearLogs()
        Logs.Clear()
        Database.DbClearLogs()
    End Sub

    Public Sub DeleteLog(entry As LogEntry)
        Logs.Remove(entry)
        Database.DbDeleteLog(entry.TimeText, entry.UserName, entry.Activity)
    End Sub

    ''' <summary>Accepts digits with at most 2 decimals. No negatives, no letters.</summary>
    Public Function TryParseMoney(text As String, ByRef value As Decimal) As Boolean
        Dim s As String = text.Trim().Replace(",", "")
        If s.Length = 0 Then Return False
        If Not Decimal.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, value) Then Return False
        Return Math.Round(value, 2) = value
    End Function

    Public Function CalcCommission(txnType As String, amount As Decimal) As Decimal
        Select Case txnType
            Case TypeCashIn
                Return Math.Round(amount * CashInRate, 2, MidpointRounding.AwayFromZero)
            Case TypeCashOut
                Return Math.Round(amount * CashOutRate, 2, MidpointRounding.AwayFromZero)
            Case Else
                Return 0D
        End Select
    End Function

End Module
