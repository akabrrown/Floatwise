Imports System.Collections.Generic
Imports System.Globalization

' =====================================================================
'  Models.vb - the data shapes and the in-memory "ledger".
'  (Frontend only: everything lives in memory while the app is open.)
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

    ' ---- data kept in memory ----
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

    ''' <summary>Opening balances initialized to zero (use "Set Balances" to enter actual balances).</summary>
    Public Sub InitDemoOnce()
        If started Then Return
        started = True
        CashInTill = 0D
        Floats(Networks(0)) = 0D
        Floats(Networks(1)) = 0D
        Floats(Networks(2)) = 0D
        For Each n As String In Networks
            Limits(n) = 0D
        Next
    End Sub

    Public Sub AddLog(user As String, activity As String, details As String, Optional role As String = "")
        Logs.Insert(0, New LogEntry With {
            .TimeText = Date.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            .UserName = user,
            .Role = role,
            .Activity = activity,
            .Details = details})
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
