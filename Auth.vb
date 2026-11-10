Imports System.IO
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions

' =====================================================================
'  Auth.vb - accounts, roles and password safety.
'  Accounts are persisted in SQLite database (%AppData%\FloatWise\floatwise.db).
'  Passwords are NEVER stored - only a salted PBKDF2 hash.
'  Roles:  Admin  = everything (void, delete logs, create workers...)
'          Worker = record transactions, view/print reports, count cash
' =====================================================================

Public Class UserAccount
    Public Property Username As String
    Public Property FullName As String
    Public Property Role As String
    Public Property Salt As String
    Public Property Hash As String
    Public Property Active As Boolean
    Public Property Created As String

    Public ReadOnly Property Status As String
        Get
            Return If(Active, "Active", "Disabled")
        End Get
    End Property
End Class

Public Class UserSession
    Public Property Username As String
    Public Property FullName As String
    Public Property Role As String

    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return Role = "Admin"
        End Get
    End Property
End Class

Public Module AuthStore

    Public ReadOnly Users As New List(Of UserAccount)
    Public FailedAttempts As Integer = 0
    Public LockedUntil As Date = Date.MinValue

    Public Sub LoadUsers()
        Users.Clear()
        Try
            Dim loaded As List(Of UserAccount) = Database.DbLoadUsers()
            Users.AddRange(loaded)
        Catch ex As Exception
            ' If database cannot be read, starts empty
        End Try
    End Sub

    Public Function SaveUsers() As Boolean
        Try
            For Each u As UserAccount In Users
                Database.DbSaveUser(u)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AdminExists() As Boolean
        Return Users.Any(Function(u) u.Role = "Admin" AndAlso u.Active)
    End Function

    Public Function FindUser(username As String) As UserAccount
        Return Users.FirstOrDefault(Function(u) String.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase))
    End Function

    Public Function GetUserRole(username As String) As String
        Dim u As UserAccount = FindUser(username)
        If u IsNot Nothing Then Return u.Role
        Return ""
    End Function

    Private Function NewSalt() As String
        Dim b(15) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(b)
        End Using
        Return Convert.ToBase64String(b)
    End Function

    Private Function HashPassword(password As String, salt As String) As String
        Using kdf As New Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000)
            Return Convert.ToBase64String(kdf.GetBytes(32))
        End Using
    End Function

    ''' <summary>Returns the account if the username, password and role all match.</summary>
    Public Function Authenticate(username As String, password As String, role As String) As UserAccount
        Dim u As UserAccount = FindUser(username)
        If u Is Nothing Then Return Nothing
        If Not u.Active OrElse u.Role <> role Then Return Nothing
        If HashPassword(password, u.Salt) <> u.Hash Then Return Nothing
        Return u
    End Function

    ''' <summary>Creates an account. Returns "" when it worked, otherwise the error message.</summary>
    Public Function CreateUser(fullName As String, username As String, password As String, confirm As String, role As String) As String
        fullName = fullName.Replace("|", " ").Trim()
        username = username.Trim()
        If fullName.Length < 2 Then Return "Enter the person's full name."
        If Not Regex.IsMatch(username, "^[A-Za-z0-9_]{3,20}$") Then Return "Username must be 3-20 letters, numbers or underscores."
        If FindUser(username) IsNot Nothing Then Return "That username is already taken."
        If password.Length < 6 OrElse Not password.Any(Function(c) Char.IsLetter(c)) OrElse Not password.Any(Function(c) Char.IsDigit(c)) Then
            Return "Password needs at least 6 characters, with a letter and a number."
        End If
        If password <> confirm Then Return "The two passwords do not match."

        Dim salt As String = NewSalt()
        Dim newAcc As New UserAccount With {
            .Username = username, .FullName = fullName, .Role = role,
            .Salt = salt, .Hash = HashPassword(password, salt),
            .Active = True, .Created = Date.Now.ToString("yyyy-MM-dd")}

        Try
            Database.DbSaveUser(newAcc)
            Users.Add(newAcc)
            Return ""
        Catch ex As Exception
            Return "Failed to save account to database: " & ex.Message
        End Try
    End Function

    ''' <summary>Resets password for an account verifying username and registered full name.</summary>
    Public Function ResetPassword(username As String, fullName As String, newPassword As String, confirmPassword As String, Optional targetRole As String = "") As String
        username = username.Trim()
        fullName = fullName.Trim()
        If username.Length = 0 Then Return "Enter your username."
        If fullName.Length = 0 Then Return "Enter your registered full name."

        Dim u As UserAccount = FindUser(username)
        If u Is Nothing Then Return "Account not found with that username."
        If Not String.IsNullOrEmpty(targetRole) AndAlso Not String.Equals(u.Role, targetRole, StringComparison.OrdinalIgnoreCase) Then
            Return "This account is not a " & targetRole & " account."
        End If
        If Not String.Equals(u.FullName.Trim(), fullName, StringComparison.OrdinalIgnoreCase) Then
            Return "Full name does not match the account records."
        End If
        If Not u.Active Then Return "This account is disabled. Contact your system administrator."

        If newPassword.Length < 6 OrElse Not newPassword.Any(Function(c) Char.IsLetter(c)) OrElse Not newPassword.Any(Function(c) Char.IsDigit(c)) Then
            Return "New password needs at least 6 characters, with a letter and a number."
        End If
        If newPassword <> confirmPassword Then Return "The passwords do not match."

        Dim salt As String = NewSalt()
        u.Salt = salt
        u.Hash = HashPassword(newPassword, salt)

        Try
            Database.DbSaveUser(u)
            Database.DbInsertLog(New LogEntry With {
                .TimeText = Date.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                .UserName = u.Username,
                .Role = u.Role,
                .Activity = "Password reset",
                .Details = "Password successfully reset via identity verification."})
            Return ""
        Catch ex As Exception
            Return "Failed to update password in database: " & ex.Message
        End Try
    End Function

    ''' <summary>Admin overrides password for a managed user account.</summary>
    Public Function AdminResetWorkerPassword(adminUsername As String, targetUsername As String, newPassword As String) As String
        Dim u As UserAccount = FindUser(targetUsername)
        If u Is Nothing Then Return "User not found."
        If newPassword.Length < 6 OrElse Not newPassword.Any(Function(c) Char.IsLetter(c)) OrElse Not newPassword.Any(Function(c) Char.IsDigit(c)) Then
            Return "Password needs at least 6 characters, with a letter and a number."
        End If

        Dim salt As String = NewSalt()
        u.Salt = salt
        u.Hash = HashPassword(newPassword, salt)

        Try
            Database.DbSaveUser(u)
            Return ""
        Catch ex As Exception
            Return "Database update error: " & ex.Message
        End Try
    End Function

End Module
