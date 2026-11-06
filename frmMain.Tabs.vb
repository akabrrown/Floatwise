Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

' =====================================================================
'  frmMain.Tabs.vb - the other tabs (same class as frmMain.vb):
'  Physical Cash, E-Cash, Activity Log, Users (admin) and the
'  Daily Report tab (opens when you click "Daily Report") with Print.
' =====================================================================
Partial Public Class frmMain

    ' =====================================================================
    '  PHYSICAL CASH TAB  (count the drawer and compare with the app)
    ' =====================================================================
    Private ReadOnly Denoms() As Integer = {200, 100, 50, 20, 10, 5, 2, 1}
    Private _numCount() As NumericUpDown
    Private _lblSub() As Label
    Private ReadOnly Property numCount(index As Integer) As NumericUpDown
        Get
            If _numCount Is Nothing Then
                _numCount = New NumericUpDown() {numCount0, numCount1, numCount2, numCount3, numCount4, numCount5, numCount6, numCount7}
            End If
            Return _numCount(index)
        End Get
    End Property
    Private ReadOnly Property lblSub(index As Integer) As Label
        Get
            If _lblSub Is Nothing Then
                _lblSub = New Label() {lblSub0, lblSub1, lblSub2, lblSub3, lblSub4, lblSub5, lblSub6, lblSub7}
            End If
            Return _lblSub(index)
        End Get
    End Property

    Private Sub InitCashEvents()
        For i As Integer = 0 To 7
            AddHandler numCount(i).ValueChanged, AddressOf CountChanged
        Next
        AddHandler numCoins.ValueChanged, AddressOf CountChanged
        AddHandler btnCountRecord.Click, AddressOf btnCountRecord_Click
        AddHandler btnCountReset.Click, AddressOf btnCountReset_Click
        AddHandler btnMatchTill.Click, AddressOf btnMatchTill_Click
    End Sub

    Private Function CurrentCountTotal() As Decimal
        Dim total As Decimal = numCoins.Value
        For i As Integer = 0 To 7
            total += numCount(i).Value * Denoms(i)
        Next
        Return total
    End Function

    Private Sub CountChanged(sender As Object, e As EventArgs)
        RefreshCashTab()
    End Sub

    Private Sub RefreshCashTab()
        If numCoins Is Nothing OrElse lblMoveTop Is Nothing Then Return
        For i As Integer = 0 To 7
            lblSub(i).Text = Money(numCount(i).Value * Denoms(i))
        Next
        Dim counted As Decimal = CurrentCountTotal()
        lblCountedTotal.Text = Money(counted)
        lblTillSystem.Text = Money(CashInTill)
        lblTillCounted.Text = Money(counted)

        Dim diff As Decimal = counted - CashInTill
        If counted = 0D Then
            lblDiff.Text = "-"
            lblDiff.ForeColor = Muted
            lblDiffNote.Text = "Enter the notes and coins on the left."
        ElseIf diff = 0D Then
            lblDiff.Text = Money(0D)
            lblDiff.ForeColor = SaveGreen
            lblDiffNote.Text = "Perfect match. The drawer agrees with the app."
        ElseIf diff > 0D Then
            lblDiff.Text = "+" & Money(diff)
            lblDiff.ForeColor = CashAmber
            lblDiffNote.Text = "OVER: there is more cash than the app expects. Look for a missing entry."
        Else
            lblDiff.Text = "-" & Money(-diff)
            lblDiff.ForeColor = AlertOrange
            lblDiffNote.Text = "SHORT: there is less cash than the app expects. Check recent transactions."
        End If

        Dim scoped As List(Of Txn) = GetScopedTxns()
        lblMoveIn.Text = Money(scoped.Where(Function(x) x.TxnType = TypeCashIn).Sum(Function(x) x.Amount))
        lblMoveOut.Text = Money(scoped.Where(Function(x) x.TxnType = TypeCashOut).Sum(Function(x) x.Amount))
        lblMoveTop.Text = Money(scoped.Where(Function(x) x.TxnType = TypeTopUp).Sum(Function(x) x.Amount))
    End Sub

    Private Sub btnCountRecord_Click(sender As Object, e As EventArgs)
        Dim counted As Decimal = CurrentCountTotal()
        If counted = 0D Then
            MessageBox.Show("Enter the notes and coins first.", "Cash count", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        CountedCash = counted
        Audit("Cash count", "Counted " & Money(counted) & " vs app " & Money(CashInTill) & " (difference " & Money(counted - CashInTill) & ")")
        tslStatus.Text = "Cash count recorded: " & Money(counted) & "."
        RefreshReportIfOpen()
    End Sub

    Private Sub btnCountReset_Click(sender As Object, e As EventArgs)
        For i As Integer = 0 To 7
            numCount(i).Value = 0D
        Next
        numCoins.Value = 0D
        RefreshCashTab()
    End Sub

    Private Sub btnMatchTill_Click(sender As Object, e As EventArgs)
        If Not currentUser.IsAdmin Then Return
        Dim counted As Decimal = CurrentCountTotal()
        If counted = 0D Then
            MessageBox.Show("Count the cash first.", "Match till", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Change the till balance from " & Money(CashInTill) & " to " & Money(counted) & "?",
                           "Match till", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Audit("Till adjusted", "Till changed from " & Money(CashInTill) & " to " & Money(counted) & " to match the count")
        CashInTill = counted
        NotBackedUp = True
        RefreshAll()
    End Sub

    ' =====================================================================
    '  E-CASH TAB  (float per network + check against the phone)
    ' =====================================================================
    Private Const BarWidth As Integer = 640
    Private _lblEFloat() As Label
    Private _lblELimit() As Label
    Private _lblEStatus() As Label
    Private _pnlEFill() As Panel
    Private _txtActual() As TextBox
    Private _lblVar() As Label
    Private ReadOnly Property lblEFloat(i As Integer) As Label
        Get
            If _lblEFloat Is Nothing Then _lblEFloat = New Label() {lblEFloat0, lblEFloat1, lblEFloat2}
            Return _lblEFloat(i)
        End Get
    End Property
    Private ReadOnly Property lblELimit(i As Integer) As Label
        Get
            If _lblELimit Is Nothing Then _lblELimit = New Label() {lblELimit0, lblELimit1, lblELimit2}
            Return _lblELimit(i)
        End Get
    End Property
    Private ReadOnly Property lblEStatus(i As Integer) As Label
        Get
            If _lblEStatus Is Nothing Then _lblEStatus = New Label() {lblEStatus0, lblEStatus1, lblEStatus2}
            Return _lblEStatus(i)
        End Get
    End Property
    Private ReadOnly Property pnlEFill(i As Integer) As Panel
        Get
            If _pnlEFill Is Nothing Then _pnlEFill = New Panel() {pnlEFill0, pnlEFill1, pnlEFill2}
            Return _pnlEFill(i)
        End Get
    End Property
    Private ReadOnly Property txtActual(i As Integer) As TextBox
        Get
            If _txtActual Is Nothing Then _txtActual = New TextBox() {txtActual0, txtActual1, txtActual2}
            Return _txtActual(i)
        End Get
    End Property
    Private ReadOnly Property lblVar(i As Integer) As Label
        Get
            If _lblVar Is Nothing Then _lblVar = New Label() {lblVar0, lblVar1, lblVar2}
            Return _lblVar(i)
        End Get
    End Property

    Private Sub InitECashEvents()
        AddHandler txtActual0.KeyPress, AddressOf MoneyKeyPress
        AddHandler txtActual1.KeyPress, AddressOf MoneyKeyPress
        AddHandler txtActual2.KeyPress, AddressOf MoneyKeyPress

        AddHandler btnCheck0.Click, Sub(s As Object, e As EventArgs) CheckWallet(0)
        AddHandler btnCheck1.Click, Sub(s As Object, e As EventArgs) CheckWallet(1)
        AddHandler btnCheck2.Click, Sub(s As Object, e As EventArgs) CheckWallet(2)

        AddHandler btnTop0.Click, Sub(s As Object, e As EventArgs) GoTopUp(0)
        AddHandler btnTop1.Click, Sub(s As Object, e As EventArgs) GoTopUp(1)
        AddHandler btnTop2.Click, Sub(s As Object, e As EventArgs) GoTopUp(2)
    End Sub

    Private Sub MoneyKeyPress(sender As Object, e As KeyPressEventArgs)
        Dim box As TextBox = DirectCast(sender, TextBox)
        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then Return
        If e.KeyChar = "."c AndAlso Not box.Text.Contains(".") Then Return
        e.Handled = True
    End Sub

    Private Sub CheckWallet(i As Integer)
        Dim net As String = Networks(i)
        Dim actual As Decimal
        If Not TryParseMoney(txtActual(i).Text, actual) Then
            lblVar(i).ForeColor = AlertOrange
            lblVar(i).Text = "Enter the balance shown on the phone, for example 1250.50"
            txtActual(i).Focus()
            Return
        End If
        Dim diff As Decimal = actual - Floats(net)
        WalletActual(net) = actual
        If diff = 0D Then
            lblVar(i).ForeColor = SaveGreen
            lblVar(i).Text = "Matches the app. No difference."
        ElseIf diff > 0D Then
            lblVar(i).ForeColor = CashAmber
            lblVar(i).Text = "The phone shows MORE than the app by " & Money(diff) & ". Look for a missing entry."
        Else
            lblVar(i).ForeColor = AlertOrange
            lblVar(i).Text = "The phone shows LESS than the app by " & Money(-diff) & ". Check recent transactions."
        End If
        Audit("E-cash check", net & ": phone " & Money(actual) & " vs app " & Money(Floats(net)) & " (difference " & Money(diff) & ")")
        RefreshReportIfOpen()
    End Sub

    Private Sub GoTopUp(i As Integer)
        tabMain.SelectedTab = tpDash
        SelectNetwork(i)
        SelectedType = TypeTopUp
        txtAmount.Focus()
    End Sub

    Private Sub RefreshECashTab()
        If lblTotalMoney Is Nothing Then Return
        Dim totalFloat As Decimal = 0D
        For i As Integer = 0 To 2
            Dim n As String = Networks(i)
            lblEFloat(i).Text = Money(Floats(n))
            lblELimit(i).Text = Money(Limits(n))
            totalFloat += Floats(n)
            Dim isLow As Boolean = Floats(n) < Limits(n)
            lblEStatus(i).Text = If(isLow, "LOW FLOAT", "HEALTHY")
            lblEStatus(i).BackColor = If(isLow, AlertOrange, SaveGreen)
            lblEFloat(i).ForeColor = If(isLow, AlertOrange, Ink)
            Dim ratio As Double = 1.0
            If Limits(n) > 0D Then ratio = Math.Min(1.0, CDbl(Floats(n) / (Limits(n) * 3D)))
            If ratio < 0.0 Then ratio = 0.0
            pnlEFill(i).Width = Math.Max(4, CInt(BarWidth * ratio))
        Next
        lblTotalEFloat.Text = Money(totalFloat)
        lblTotalCashE.Text = Money(CashInTill)
        lblTotalMoney.Text = Money(totalFloat + CashInTill)
    End Sub

    ' =====================================================================
    '  ACTIVITY LOG TAB  (everyone can read, only the ADMIN can delete)
    ' =====================================================================
    Private Sub InitLogEvents()
        AddHandler txtLogSearch.TextChanged, Sub(s As Object, e As EventArgs) RefreshLogGrid()
        AddHandler btnExportLog.Click, AddressOf btnExportLog_Click
        AddHandler btnLogDelete.Click, AddressOf btnLogDelete_Click
        AddHandler btnLogClear.Click, AddressOf btnLogClear_Click
    End Sub

    Private Sub RefreshLogGrid()
        If dgvLog Is Nothing Then Return
        Dim q As String = txtLogSearch.Text.Trim().ToLowerInvariant()
        Dim scoped As List(Of LogEntry) = GetScopedLogs()
        Dim rows As List(Of LogEntry) = scoped.Where(Function(l) q = "" OrElse
            (l.UserName & " " & l.Activity & " " & l.Details & " " & l.TimeText).ToLowerInvariant().Contains(q)).ToList()
        dgvLog.DataSource = rows
    End Sub

    Private Sub btnLogDelete_Click(sender As Object, e As EventArgs)
        If Not currentUser.IsAdmin Then Return
        If dgvLog.SelectedRows.Count = 0 Then
            MessageBox.Show("Click a log entry first.", "Delete log entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim entry As LogEntry = DirectCast(dgvLog.SelectedRows(0).DataBoundItem, LogEntry)
        If MessageBox.Show("Delete this log entry?" & vbCrLf & entry.TimeText & "  " & entry.Activity,
                           "Delete log entry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Logs.Remove(entry)
        Audit("Log entry deleted", entry.TimeText & " - " & entry.Activity)
    End Sub

    Private Sub btnLogClear_Click(sender As Object, e As EventArgs)
        If Not currentUser.IsAdmin Then Return
        If Logs.Count = 0 Then Return
        If MessageBox.Show("Delete ALL " & Logs.Count & " log entries? This cannot be undone.",
                           "Clear log", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Dim removed As Integer = Logs.Count
        Logs.Clear()
        Audit("Log cleared", removed & " entries removed")
    End Sub

    Private Sub btnExportLog_Click(sender As Object, e As EventArgs)
        Dim scoped As List(Of LogEntry) = GetScopedLogs()
        If scoped.Count = 0 Then
            MessageBox.Show("The log is empty.", "Export log", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using dlg As New SaveFileDialog()
            dlg.Title = "Export activity log"
            dlg.Filter = "CSV file (*.csv)|*.csv"
            dlg.FileName = "FloatWise_Log_" & Date.Now.ToString("yyyy-MM-dd") & ".csv"
            If dlg.ShowDialog() <> DialogResult.OK Then Return
            Try
                Using sw As New StreamWriter(dlg.FileName, False, New UTF8Encoding(True))
                    sw.WriteLine("Time,User,Role,Activity,Details")
                    For Each l As LogEntry In scoped.AsEnumerable().Reverse()
                        sw.WriteLine(CsvField(l.TimeText) & "," & CsvField(l.UserName) & "," & CsvField(l.Role) & "," & CsvField(l.Activity) & "," & CsvField(l.Details))
                    Next
                End Using
                tslStatus.Text = "Log exported: " & Path.GetFileName(dlg.FileName)
            Catch ex As Exception
                MessageBox.Show("The log could not be saved." & vbCrLf & ex.Message, "Export log", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' =====================================================================
    '  USERS TAB  (ADMIN ONLY - the admin creates the workers)
    ' =====================================================================
    Private Sub InitUsersEvents()
        AddHandler btnCreateUser.Click, AddressOf btnCreateUser_Click
        AddHandler btnToggleUser.Click, AddressOf btnToggleUser_Click
    End Sub

    Public Sub InitTabsEvents()
        InitCashEvents()
        InitECashEvents()
        InitLogEvents()
        InitUsersEvents()
    End Sub

    Private Sub RefreshUsersGrid()
        If dgvUsers Is Nothing Then Return
        dgvUsers.DataSource = AuthStore.Users.ToList()
    End Sub

    Private Sub btnCreateUser_Click(sender As Object, e As EventArgs)
        If Not currentUser.IsAdmin Then Return
        lblUserMsg.Text = ""
        Dim role As String = If(cboURole.SelectedIndex = 1, "Admin", "Worker")
        Dim problem As String = CreateUser(txtUName.Text, txtUUser.Text, txtUPass.Text, txtUConfirm.Text, role)
        If problem <> "" Then
            lblUserMsg.ForeColor = AlertOrange
            lblUserMsg.Text = problem
            Return
        End If
        Audit("User created", role & " account '" & txtUUser.Text.Trim() & "' created")
        lblUserMsg.ForeColor = SaveGreen
        lblUserMsg.Text = "Account created for " & txtUName.Text.Trim() & ". Give them their username and password."
        txtUName.Clear()
        txtUUser.Clear()
        txtUPass.Clear()
        txtUConfirm.Clear()
        cboURole.SelectedIndex = 0
        RefreshUsersGrid()
    End Sub

    Private Sub btnToggleUser_Click(sender As Object, e As EventArgs)
        If Not currentUser.IsAdmin Then Return
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Click an account first.", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim u As UserAccount = DirectCast(dgvUsers.SelectedRows(0).DataBoundItem, UserAccount)
        If String.Equals(u.Username, currentUser.Username, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("You cannot disable your own account.", "Users", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim activeAdmins As Integer = AuthStore.Users.Where(Function(x) x.Role = "Admin" AndAlso x.Active).Count()
        If u.Role = "Admin" AndAlso u.Active AndAlso activeAdmins <= 1 Then
            MessageBox.Show("You cannot disable the last active admin.", "Users", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        u.Active = Not u.Active
        If Not SaveUsers() Then
            u.Active = Not u.Active
            MessageBox.Show("The change could not be saved.", "Users", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Audit(If(u.Active, "User enabled", "User disabled"), u.Role & " account '" & u.Username & "'")
        RefreshUsersGrid()
    End Sub

    ' =====================================================================
    '  DAILY REPORT TAB  (opens in a NEW TAB, with Print)
    ' =====================================================================
    Private rtbReport As RichTextBox
    Private WithEvents printDoc As New PrintDocument()
    Private printLines As New List(Of String)
    Private printIndex As Integer = 0

    Private Sub OpenReportTab()
        If tpReport Is Nothing OrElse Not tabMain.TabPages.Contains(tpReport) Then
            tpReport = NewPage("Daily Report", ReportTeal)
            BuildReportTab()
            tabMain.TabPages.Add(tpReport)
        End If
        ShowReport()
        tabMain.SelectedTab = tpReport
        Audit("Daily report", "Daily report opened")
    End Sub

    Private Sub BuildReportTab()
        Dim btnPrint As Button = MakeButton("Print", PrintOrange, 12, 12, 140, 38)
        Dim btnPreview As Button = MakeButton("Print preview", PreviewSky, 162, 12, 170, 38)
        Dim btnRefreshReport As Button = MakeButton("Refresh", RefreshLime, 342, 12, 130, 38)
        Dim btnCloseReport As Button = MakeButton("Close tab", LogoutSlate, 1054, 12, 140, 38)
        tpReport.Controls.Add(btnPrint)
        tpReport.Controls.Add(btnPreview)
        tpReport.Controls.Add(btnRefreshReport)
        tpReport.Controls.Add(btnCloseReport)

        rtbReport = New RichTextBox()
        rtbReport.Location = New Point(12, 62)
        rtbReport.Size = New Size(1182, 590)
        rtbReport.ReadOnly = True
        rtbReport.BackColor = Color.White
        rtbReport.BorderStyle = BorderStyle.None
        rtbReport.Font = New Font("Consolas", 11.0F)
        tpReport.Controls.Add(rtbReport)

        AddHandler btnPrint.Click, Sub(s As Object, e As EventArgs) PrintReport()
        AddHandler btnPreview.Click, Sub(s As Object, e As EventArgs) PreviewReport()
        AddHandler btnRefreshReport.Click, Sub(s As Object, e As EventArgs) ShowReport()
        AddHandler btnCloseReport.Click, Sub(s As Object, e As EventArgs)
                                             tabMain.TabPages.Remove(tpReport)
                                             tpReport = Nothing
                                             tabMain.SelectedTab = tpDash
                                         End Sub
    End Sub

    Private Sub RefreshReportIfOpen()
        If tpReport IsNot Nothing AndAlso tabMain.TabPages.Contains(tpReport) Then ShowReport()
    End Sub

    Private Function PadR(s As String, n As Integer) As String
        If s.Length >= n Then Return s.Substring(0, n)
        Return s.PadRight(n)
    End Function

    Private Function PadL(s As String, n As Integer) As String
        If s.Length >= n Then Return s
        Return s.PadLeft(n)
    End Function

    Private Function RepMoney(value As Decimal) As String
        Return "GHS " & value.ToString("N2", CultureInfo.InvariantCulture)
    End Function

    Private Function BuildReportLines() As List(Of String)
        Dim lines As New List(Of String)
        Dim rule As String = New String("="c, 76)
        Dim thin As String = New String("-"c, 76)
        Dim scoped As List(Of Txn) = GetScopedTxns()
        Dim volume As Decimal = scoped.Sum(Function(x) x.Amount)
        Dim comm As Decimal = scoped.Sum(Function(x) x.Commission)

        lines.Add("##FLOATWISE - DAILY REPORT")
        lines.Add("Date: " & Date.Now.ToString("dddd, dd MMMM yyyy") & "     Time: " & Date.Now.ToString("HH:mm"))
        lines.Add("Prepared by: " & currentUser.FullName & " (" & currentUser.Role & ")")
        lines.Add(rule)

        lines.Add("##SUMMARY")
        lines.Add(PadR("Transactions recorded", 30) & scoped.Count)
        lines.Add(PadR("Total volume", 30) & RepMoney(volume))
        lines.Add(PadR("Commission earned", 30) & RepMoney(comm))
        lines.Add("")

        lines.Add("##BY NETWORK")
        lines.Add(PadR("Network", 22) & PadL("Txns", 6) & PadL("Volume", 18) & PadL("Commission", 18))
        lines.Add(thin)
        For Each net As String In Networks
            Dim n As String = net
            Dim rows As List(Of Txn) = scoped.Where(Function(x) x.Network = n).ToList()
            lines.Add(PadR(n, 22) & PadL(rows.Count.ToString(), 6) & PadL(RepMoney(rows.Sum(Function(x) x.Amount)), 18) & PadL(RepMoney(rows.Sum(Function(x) x.Commission)), 18))
        Next
        lines.Add("")

        lines.Add("##BY TRANSACTION TYPE")
        lines.Add(PadR("Type", 22) & PadL("Txns", 6) & PadL("Volume", 18) & PadL("Commission", 18))
        lines.Add(thin)
        For Each ty As String In New String() {TypeCashIn, TypeCashOut, TypeTopUp}
            Dim tyName As String = ty
            Dim rows As List(Of Txn) = scoped.Where(Function(x) x.TxnType = tyName).ToList()
            lines.Add(PadR(tyName, 22) & PadL(rows.Count.ToString(), 6) & PadL(RepMoney(rows.Sum(Function(x) x.Amount)), 18) & PadL(RepMoney(rows.Sum(Function(x) x.Commission)), 18))
        Next
        lines.Add("")

        lines.Add("##CLOSING BALANCES")
        lines.Add(PadR("Cash in till (app)", 30) & RepMoney(CashInTill))
        If CountedCash >= 0D Then
            lines.Add(PadR("Last cash count recorded", 30) & RepMoney(CountedCash))
            lines.Add(PadR("Difference (count - till now)", 30) & RepMoney(CountedCash - CashInTill))
        Else
            lines.Add(PadR("Last cash count recorded", 30) & "not counted yet")
        End If
        Dim totalFloat As Decimal = 0D
        For Each net As String In Networks
            Dim isLow As Boolean = Floats(net) < Limits(net)
            totalFloat += Floats(net)
            lines.Add(PadR(net & " float", 30) & RepMoney(Floats(net)) & If(isLow, "   << LOW (limit " & RepMoney(Limits(net)) & ")", ""))
            If WalletActual.ContainsKey(net) Then
                lines.Add(PadR("   phone balance checked", 30) & RepMoney(WalletActual(net)))
            End If
        Next
        lines.Add(PadR("Total money (cash + e-float)", 30) & RepMoney(CashInTill + totalFloat))
        lines.Add("")

        lines.Add("##TRANSACTIONS (oldest first)")
        If scoped.Count = 0 Then
            lines.Add("(no transactions recorded yet)")
        Else
            lines.Add(PadR("Time", 6) & PadR("Network", 14) & PadR("Type", 10) & PadR("Phone", 12) & PadL("Amount", 11) & PadL("Comm.", 9) & "  By")
            lines.Add(thin)
            For Each tx As Txn In scoped.OrderBy(Function(x) x.Id)
                lines.Add(PadR(tx.TimeText, 6) & PadR(tx.Network, 14) & PadR(tx.TxnType, 10) &
                          PadR(If(tx.Phone <> "", tx.Phone, "-"), 12) &
                          PadL(tx.Amount.ToString("N2", CultureInfo.InvariantCulture), 11) &
                          PadL(tx.Commission.ToString("N2", CultureInfo.InvariantCulture), 9) & "  " & tx.RecordedBy)
            Next
        End If
        lines.Add("")
        lines.Add(rule)
        lines.Add("Prepared by: ____________________     Checked by: ____________________")
        Return lines
    End Function

    Private Sub ShowReport()
        If rtbReport Is Nothing Then Return
        printLines = BuildReportLines()
        rtbReport.Clear()
        For Each ln As String In printLines
            Dim isHead As Boolean = ln.StartsWith("##")
            Dim textLine As String = If(isHead, ln.Substring(2), ln)
            rtbReport.SelectionStart = rtbReport.TextLength
            rtbReport.SelectionLength = 0
            If isHead Then
                rtbReport.SelectionFont = New Font("Consolas", 11.5F, FontStyle.Bold)
                rtbReport.SelectionColor = ReportTeal
            Else
                rtbReport.SelectionFont = New Font("Consolas", 11.0F, FontStyle.Regular)
                rtbReport.SelectionColor = Ink
            End If
            rtbReport.AppendText(textLine & vbLf)
        Next
        rtbReport.SelectionStart = 0
        rtbReport.ScrollToCaret()
    End Sub

    ' ---------- printing ----------
    Private Sub PrintReport()
        ShowReport()
        printDoc.DocumentName = "FloatWise Daily Report"
        Try
            Using dlg As New PrintDialog()
                dlg.Document = printDoc
                If dlg.ShowDialog() = DialogResult.OK Then
                    printDoc.Print()
                    Audit("Print", "Daily report sent to the printer")
                    tslStatus.Text = "Report sent to the printer."
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Printing failed." & vbCrLf & ex.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PreviewReport()
        ShowReport()
        printDoc.DocumentName = "FloatWise Daily Report"
        Try
            Using pv As New PrintPreviewDialog()
                pv.Document = printDoc
                pv.Width = 1000
                pv.Height = 800
                pv.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show("Print preview failed." & vbCrLf & ex.Message, "Print preview", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub printDoc_BeginPrint(sender As Object, e As PrintEventArgs) Handles printDoc.BeginPrint
        printIndex = 0
    End Sub

    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        Using fBody As New Font("Consolas", 9.5F, FontStyle.Regular),
              fBold As New Font("Consolas", 9.5F, FontStyle.Bold),
              fTitle As New Font("Consolas", 15.0F, FontStyle.Bold)
            Dim y As Single = e.MarginBounds.Top
            Dim lineH As Single = fBody.GetHeight(e.Graphics) + 2.0F
            e.HasMorePages = False

            While printIndex < printLines.Count
                Dim ln As String = printLines(printIndex)
                Dim f As Font = fBody
                Dim h As Single = lineH
                If printIndex = 0 Then
                    f = fTitle
                    h = fTitle.GetHeight(e.Graphics) + 6.0F
                End If
                If ln.StartsWith("##") Then
                    ln = ln.Substring(2)
                    If printIndex > 0 Then f = fBold
                End If
                If y + h > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    Exit While
                End If
                e.Graphics.DrawString(ln, f, Brushes.Black, e.MarginBounds.Left, y)
                y += h
                printIndex += 1
            End While
        End Using
    End Sub

End Class
