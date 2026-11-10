Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms


'  frmMain - the main screen (header + coloured tabs).
'  This file: start-up, header, Dashboard tab, validation and saving.
'  The other tabs are in frmMain.Tabs.vb (same class, second file).

Partial Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' ---- who is signed in ----
    Private ReadOnly currentUser As UserSession
    Public LoggedOut As Boolean = False
    ' ---- shared state ----
    Private tpReport As TabPage
    Private firstBad As Control = Nothing
    Private ReadOnly NetColors() As Color = {MtnYellow, TelecelRed, AirtelBlue}

    Private Function IsDesignMode() As Boolean
        Return Me.DesignMode OrElse
               System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime OrElse
               System.Diagnostics.Process.GetCurrentProcess().ProcessName.IndexOf("devenv", StringComparison.OrdinalIgnoreCase) >= 0
    End Function


    '  START-UP

    Public Sub New()
        Me.New(New UserSession() With {.Username = "admin", .FullName = "Administrator", .Role = "Admin"})
    End Sub

    Public Sub New(user As UserSession)
        InitializeComponent()

        currentUser = If(user, New UserSession() With {.Username = "admin", .FullName = "Administrator", .Role = "Admin"})

        ' Ensure demo ledger data exists so dictionaries are always populated
        Ledger.InitDemoOnce()

        ' Setup tab accent colors for owner draw
        If tpDash IsNot Nothing Then tpDash.Tag = BrandGreen
        If tpCash IsNot Nothing Then tpCash.Tag = CashAmber
        If tpECash IsNot Nothing Then tpECash.Tag = ECashNavy
        If tpLog IsNot Nothing Then tpLog.Tag = LogBrown
        If tpUsers IsNot Nothing Then tpUsers.Tag = UserPink

        ' User header setup
        If lblUser IsNot Nothing Then lblUser.Text = currentUser.FullName
        If chip IsNot Nothing Then
            chip.Text = currentUser.Role.ToUpperInvariant()
            chip.BackColor = If(currentUser.IsAdmin, AdminPurple, WorkerTeal)
        End If

        If cboURole IsNot Nothing Then
            cboURole.Items.Clear()
            cboURole.Items.AddRange(New Object() {"Worker", "Admin"})
            cboURole.SelectedIndex = 0
        End If

        ' In Visual Studio Designer, stop here so all tabs & controls are fully editable in the canvas
        If IsDesignMode() Then Return

        ' Grids setup
        InitGrids()

        ' Wire all events
        InitEvents()

        ' Quick amount buttons
        InitQuickAmounts()

        ' Apply permissions based on role
        ApplyRolePermissions()

        Audit("Sign in", currentUser.FullName & " signed in as " & currentUser.Role)
        RefreshAll()
        If tslStatus IsNot Nothing Then
            tslStatus.Text = "Welcome, " & currentUser.FullName & ". Today is " & Date.Now.ToString("dddd, dd MMM yyyy") & "."
        End If
    End Sub

    Private Sub Audit(activity As String, details As String)
        Ledger.AddLog(currentUser.Username, activity, details, currentUser.Role)
        RefreshLogGrid()
    End Sub

    Public Function GetScopedTxns() As List(Of Txn)
        If currentUser Is Nothing OrElse currentUser.IsAdmin Then
            Return Txns.ToList()
        End If
        ' Worker scope: strictly exclude Admin transactions to ensure zero interference
        Return Txns.Where(Function(t) (t.Role <> "Admin") AndAlso
            (t.Role = "Worker" OrElse t.RecordedBy = currentUser.Username OrElse String.IsNullOrEmpty(t.Role))).ToList()
    End Function

    Public Function GetScopedLogs() As List(Of LogEntry)
        If currentUser Is Nothing OrElse currentUser.IsAdmin Then
            Return Logs.ToList()
        End If
        ' Worker scope: strictly exclude Admin actions & sensitive administrative activities
        Dim adminActivities() As String = {"User created", "User enabled", "User disabled", "Float limit", "Balances set", "Till adjusted", "Void", "Log cleared", "Log entry deleted"}
        Return Logs.Where(Function(l) (l.Role <> "Admin") AndAlso
            Not adminActivities.Contains(l.Activity) AndAlso
            (l.UserName = currentUser.Username OrElse String.IsNullOrEmpty(l.Role) OrElse l.Role = "Worker")).ToList()
    End Function

    Private Function NewPage(title As String, accent As Color) As TabPage
        Dim p As New TabPage(title)
        p.BackColor = PageBg
        p.Tag = accent
        Return p
    End Function

    Private Sub InitGrids()
        StyleGrid(dgvTransactions, ReportTeal)
        dgvTransactions.Columns.Clear()
        AddGridColumn(dgvTransactions, "TimeText", "Time", False, 60)
        AddGridColumn(dgvTransactions, "Network", "Network", False, 100)
        AddGridColumn(dgvTransactions, "TxnType", "Type", False, 85)
        AddGridColumn(dgvTransactions, "Phone", "Phone Number", False, 110)
        AddGridColumn(dgvTransactions, "Amount", "Amount", True, 90)
        AddGridColumn(dgvTransactions, "Commission", "Commission", True, 80)
        AddGridColumn(dgvTransactions, "RecordedBy", "By", False, 80)

        StyleGrid(dgvLog, LogBrown)
        dgvLog.Columns.Clear()
        AddGridColumn(dgvLog, "TimeText", "Time", False, 18)
        AddGridColumn(dgvLog, "UserName", "User", False, 12)
        AddGridColumn(dgvLog, "Activity", "Activity", False, 16)
        AddGridColumn(dgvLog, "Details", "Details", False, 54)

        StyleGrid(dgvUsers, UserPink)
        dgvUsers.Columns.Clear()
        AddGridColumn(dgvUsers, "Username", "Username", False, 22)
        AddGridColumn(dgvUsers, "FullName", "Full name", False, 34)
        AddGridColumn(dgvUsers, "Role", "Role", False, 14)
        AddGridColumn(dgvUsers, "Status", "Status", False, 14)
        AddGridColumn(dgvUsers, "Created", "Created", False, 18)
    End Sub

    Private Sub InitEvents()
        AddHandler tabMain.DrawItem, AddressOf tabMain_DrawItem
        AddHandler tabMain.SelectedIndexChanged, AddressOf tabMain_SelectedIndexChanged

        AddHandler btnLogout.Click, Sub(s As Object, e As EventArgs)
                                        LoggedOut = True
                                        Me.Close()
                                    End Sub
        AddHandler btnExit.Click, Sub(s As Object, e As EventArgs) Me.Close()

        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler btnClear.Click, AddressOf btnClear_Click
        AddHandler txtSearch.TextChanged, Sub(s As Object, e As EventArgs) RefreshGrid()
        AddHandler txtAmount.KeyPress, AddressOf txtAmount_KeyPress
        AddHandler txtPhone.KeyPress, AddressOf txtPhone_KeyPress
        AddHandler txtAmount.TextChanged, AddressOf txtAmount_TextChanged
        AddHandler radNet0.CheckedChanged, AddressOf Network_CheckedChanged
        AddHandler radNet1.CheckedChanged, AddressOf Network_CheckedChanged
        AddHandler radNet2.CheckedChanged, AddressOf Network_CheckedChanged
        AddHandler radTypeCashIn.CheckedChanged, AddressOf Type_CheckedChanged
        AddHandler radTypeCashOut.CheckedChanged, AddressOf Type_CheckedChanged
        AddHandler radTypeTopUp.CheckedChanged, AddressOf Type_CheckedChanged

        AddHandler btnReport.Click, Sub(s As Object, e As EventArgs) OpenReportTab()
        AddHandler btnSetLimit.Click, AddressOf btnSetLimit_Click
        AddHandler btnBalances.Click, AddressOf btnBalances_Click
        AddHandler btnVoid.Click, AddressOf btnVoid_Click

        AddHandler Me.FormClosing, AddressOf frmMain_FormClosing

        InitTabsEvents()
    End Sub

    Private Sub InitQuickAmounts()
        Dim amounts() As Integer = {10, 20, 50, 100, 200, 500}
        Dim tints() As String = {"#DCFCE7", "#FEF9C3", "#FFE4E6", "#E0E7FF", "#FFEDD5", "#CFFAFE"}
        For i As Integer = 0 To amounts.Length - 1
            Dim amt As Integer = amounts(i)
            Dim chipBtn As Button = MakeButton(amt.ToString(), Col(tints(i)), 16 + i * 58, 420, 52, 30, Ink)
            AddHandler chipBtn.Click, Sub(s As Object, e As EventArgs)
                                          txtAmount.Text = amt.ToString()
                                          txtAmount.Focus()
                                      End Sub
            grpEntry.Controls.Add(chipBtn)
        Next
    End Sub

    Private Sub ApplyRolePermissions()
        If currentUser.IsAdmin Then
            btnReport.Visible = True
            btnBackup.Visible = True
            btnSetLimit.Visible = True
            btnBalances.Visible = True
            btnVoid.Visible = True
            btnMatchTill.Visible = True
            btnLogDelete.Visible = True
            btnLogClear.Visible = True
            If Not tabMain.TabPages.Contains(tpUsers) Then
                tabMain.TabPages.Add(tpUsers)
            End If
        Else
            ' Worker gets strictly separated non-admin access
            btnSetLimit.Visible = False
            btnBalances.Visible = False
            btnVoid.Visible = False
            btnMatchTill.Visible = False
            btnLogDelete.Visible = False
            btnLogClear.Visible = False
            If tabMain.TabPages.Contains(tpUsers) Then
                tabMain.TabPages.Remove(tpUsers)
            End If

            ' Adjust worker button layout
            btnReport.Visible = True
            btnReport.Size = New Size(220, 42)
            btnReport.Location = New Point(12, 624)
            btnBackup.Visible = True
            btnBackup.Size = New Size(220, 42)
            btnBackup.Location = New Point(244, 624)

            btnCountRecord.Size = New Size(265, 48)
            btnCountRecord.Location = New Point(20, 536)
            btnCountReset.Size = New Size(125, 48)
            btnCountReset.Location = New Point(297, 536)
        End If
    End Sub

    Private Sub tabMain_DrawItem(sender As Object, e As DrawItemEventArgs)
        Dim page As TabPage = tabMain.TabPages(e.Index)
        Dim accent As Color = Ink
        If TypeOf page.Tag Is Color Then accent = CType(page.Tag, Color)
        Dim selected As Boolean = (e.Index = tabMain.SelectedIndex)
        Using b As New SolidBrush(If(selected, accent, ControlPaint.Light(accent, 0.7F)))
            e.Graphics.FillRectangle(b, e.Bounds)
        End Using
        Dim textColor As Color = If(selected, Color.White, Ink)
        TextRenderer.DrawText(e.Graphics, page.Text, New Font("Segoe UI", 10.5F, FontStyle.Bold), e.Bounds, textColor,
                              TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs)
        UpdateEnterEscKeys()
    End Sub

    ''' <summary>Enter = Save and Esc = Clear, but only on the Dashboard.</summary>
    Private Sub UpdateEnterEscKeys()
        If tabMain.SelectedTab Is tpDash Then
            Me.AcceptButton = btnSave
            Me.CancelButton = btnClear
        ElseIf tpUsers IsNot Nothing AndAlso tabMain.SelectedTab Is tpUsers Then
            Me.AcceptButton = btnCreateUser
            Me.CancelButton = Nothing
        Else
            Me.AcceptButton = Nothing
            Me.CancelButton = Nothing
        End If
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs)
        If Ledger.NotBackedUp AndAlso Ledger.Txns.Count > 0 Then
            Dim msg As String = If(LoggedOut, "Log out now?", "Exit FloatWise?") & vbCrLf & "Today's transactions have not been backed up yet."
            If MessageBox.Show(msg, "FloatWise", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                e.Cancel = True
                LoggedOut = False
                Return
            End If
        End If
        If LoggedOut Then Ledger.AddLog(currentUser.Username, "Sign out", currentUser.FullName & " signed out")
    End Sub


    '  LIVE INPUT CONTROL (stops bad characters being typed)

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then Return
        If e.KeyChar = "."c AndAlso Not txtAmount.Text.Contains(".") Then Return
        e.Handled = True
    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then Return
        If e.KeyChar = " "c OrElse e.KeyChar = "+"c OrElse e.KeyChar = "-"c Then Return
        e.Handled = True
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs)
        epMain.SetError(txtAmount, "")
        UpdateCommissionPreview()
    End Sub

    Private Sub txtPhone_TextChanged(sender As Object, e As EventArgs)
        epMain.SetError(txtPhone, "")
    End Sub

    Public Property SelectedNetwork As String
        Get
            If radNet0 IsNot Nothing AndAlso radNet0.Checked Then Return Networks(0)
            If radNet1 IsNot Nothing AndAlso radNet1.Checked Then Return Networks(1)
            If radNet2 IsNot Nothing AndAlso radNet2.Checked Then Return Networks(2)
            Return ""
        End Get
        Set(value As String)
            If radNet0 Is Nothing Then Return
            radNet0.Checked = (value = Networks(0))
            radNet1.Checked = (value = Networks(1))
            radNet2.Checked = (value = Networks(2))
        End Set
    End Property

    Public Property SelectedType As String
        Get
            If radTypeCashIn IsNot Nothing AndAlso radTypeCashIn.Checked Then Return TypeCashIn
            If radTypeCashOut IsNot Nothing AndAlso radTypeCashOut.Checked Then Return TypeCashOut
            If radTypeTopUp IsNot Nothing AndAlso radTypeTopUp.Checked Then Return TypeTopUp
            Return ""
        End Get
        Set(value As String)
            If radTypeCashIn Is Nothing Then Return
            radTypeCashIn.Checked = (value = TypeCashIn)
            radTypeCashOut.Checked = (value = TypeCashOut)
            radTypeTopUp.Checked = (value = TypeTopUp)
        End Set
    End Property

    Public Sub SelectNetwork(index As Integer)
        If index = 0 AndAlso radNet0 IsNot Nothing Then radNet0.Checked = True
        If index = 1 AndAlso radNet1 IsNot Nothing Then radNet1.Checked = True
        If index = 2 AndAlso radNet2 IsNot Nothing Then radNet2.Checked = True
    End Sub

    Public Sub ClearNetworkSelection()
        If radNet0 IsNot Nothing Then radNet0.Checked = False
        If radNet1 IsNot Nothing Then radNet1.Checked = False
        If radNet2 IsNot Nothing Then radNet2.Checked = False
    End Sub

    Public Sub ClearTypeSelection()
        If radTypeCashIn IsNot Nothing Then radTypeCashIn.Checked = False
        If radTypeCashOut IsNot Nothing Then radTypeCashOut.Checked = False
        If radTypeTopUp IsNot Nothing Then radTypeTopUp.Checked = False
    End Sub

    Private Sub Network_CheckedChanged(sender As Object, e As EventArgs)
        Dim rb As RadioButton = TryCast(sender, RadioButton)
        If rb IsNot Nothing AndAlso rb.Checked Then
            epMain.SetError(pnlNetwork, "")
        End If
    End Sub

    Private Sub Type_CheckedChanged(sender As Object, e As EventArgs)
        Dim rb As RadioButton = TryCast(sender, RadioButton)
        If rb IsNot Nothing AndAlso rb.Checked Then
            epMain.SetError(pnlType, "")
            Dim isTopUp As Boolean = (SelectedType = TypeTopUp)
            txtPhone.Enabled = Not isTopUp
            If isTopUp Then
                txtPhone.Clear()
                epMain.SetError(txtPhone, "")
            End If
            UpdateCommissionPreview()
        End If
    End Sub

    Private Sub UpdateCommissionPreview()
        Dim amt As Decimal
        Dim t As String = SelectedType
        If t <> "" AndAlso TryParseMoney(txtAmount.Text, amt) Then
            txtCommission.Text = CalcCommission(t, amt).ToString("N2", CultureInfo.InvariantCulture)
        Else
            txtCommission.Text = "0.00"
        End If
    End Sub


    '  PHONE HELPERS
    ''' <summary>Ghana mobile numbers: 0XXXXXXXXX, +233XXXXXXXXX or 233XXXXXXXXX.</summary>
    Private Function TryNormalizePhone(raw As String, ByRef phone As String) As Boolean
        Dim s As String = Regex.Replace(raw, "[\s\-]", "")
        If s.StartsWith("+233") Then
            s = "0" & s.Substring(4)
        ElseIf s.StartsWith("233") AndAlso s.Length = 12 Then
            s = "0" & s.Substring(3)
        End If
        If Not Regex.IsMatch(s, "^0\d{9}$") Then Return False
        Dim valid() As String = {"020", "024", "025", "026", "027", "050", "053", "054", "055", "056", "057", "059"}
        If Not valid.Contains(s.Substring(0, 3)) Then Return False
        phone = s
        Return True
    End Function

    Private Function GuessNetwork(phone As String) As String
        Select Case phone.Substring(0, 3)
            Case "024", "025", "053", "054", "055", "059"
                Return Networks(0)
            Case "020", "050"
                Return Networks(1)
            Case "026", "027", "056", "057"
                Return Networks(2)
            Case Else
                Return ""
        End Select
    End Function

    Private Function MaskPhone(phone As String) As String
        Return phone
    End Function

    Private Sub Flag(ctrl As Control, message As String)
        epMain.SetError(ctrl, message)
        If firstBad Is Nothing Then firstBad = ctrl
    End Sub


    '  VALIDATION

    Private Function ValidateEntry(ByRef amount As Decimal, ByRef phone As String) As Boolean
        epMain.Clear()
        firstBad = Nothing
        phone = ""
        amount = 0D

        If SelectedNetwork = "" Then Flag(pnlNetwork, "Choose a network.")
        If SelectedType = "" Then Flag(pnlType, "Choose the transaction type.")

        Dim t As String = SelectedType
        If t = TypeCashIn OrElse t = TypeCashOut Then
            If txtPhone.Text.Trim().Length = 0 Then
                Flag(txtPhone, "Enter the customer's phone number.")
            ElseIf Not TryNormalizePhone(txtPhone.Text, phone) Then
                Flag(txtPhone, "Enter a valid Ghana mobile number, e.g. 024 123 4567.")
            End If
        End If

        Dim amountOk As Boolean = False
        If txtAmount.Text.Trim().Length = 0 Then
            Flag(txtAmount, "Enter the amount.")
        ElseIf Not TryParseMoney(txtAmount.Text, amount) Then
            Flag(txtAmount, "Enter a valid amount (numbers only, max 2 decimal places).")
        ElseIf amount <= 0D Then
            Flag(txtAmount, "Amount must be greater than 0.")
        ElseIf amount > MaxAmount Then
            Flag(txtAmount, "Maximum per transaction is " & Money(MaxAmount) & ".")
        Else
            amountOk = True
        End If

        If amountOk AndAlso SelectedNetwork <> "" Then
            Dim net As String = SelectedNetwork
            Select Case t
                Case TypeCashIn
                    If Floats(net) < amount Then
                        Flag(txtAmount, "Not enough " & net & " float. Available: " & Money(Floats(net)) & ".")
                    End If
                Case TypeCashOut, TypeTopUp
                    If CashInTill < amount Then
                        Flag(txtAmount, "Not enough cash in till. Available: " & Money(CashInTill) & ".")
                    End If
            End Select
        End If

        If firstBad IsNot Nothing Then
            firstBad.Focus()
            tslStatus.Text = "Please fix the highlighted fields."
            Return False
        End If
        Return True
    End Function


    '  SAVE A TRANSACTION

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim amount As Decimal
        Dim phone As String = ""
        If Not ValidateEntry(amount, phone) Then Return

        Dim net As String = SelectedNetwork
        Dim t As String = SelectedType

        If phone <> "" Then
            Dim guess As String = GuessNetwork(phone)
            If guess <> "" AndAlso guess <> net Then
                Dim answer As DialogResult = MessageBox.Show(
                    "This number looks like a " & guess & " number, but you selected " & net & "." & vbCrLf &
                    "Numbers can be ported between networks. Continue?",
                    "Network check", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If answer = DialogResult.No Then
                    txtPhone.Focus()
                    Return
                End If
            End If
        End If

        Dim commission As Decimal = CalcCommission(t, amount)
        Dim summary As String = "Please confirm this transaction:" & vbCrLf & vbCrLf &
            "Network:  " & net & vbCrLf &
            "Type:  " & t & vbCrLf &
            If(phone <> "", "Customer:  " & phone & vbCrLf, "") &
            "Amount:  " & Money(amount) & vbCrLf &
            "Commission:  " & Money(commission)
        If MessageBox.Show(summary, "Confirm transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim newTxn As New Txn With {
            .TimeText = Date.Now.ToString("HH:mm"),
            .Network = net,
            .TxnType = t,
            .Phone = phone,
            .Amount = amount,
            .Commission = commission,
            .RecordedBy = currentUser.Username,
            .Role = currentUser.Role}

        Dim logMsg As String = t & " " & Money(amount) & " on " & net & If(phone <> "", " (" & phone & ")", "")
        Try
            ExecuteTransaction(newTxn, logMsg)
        Catch ex As Exception
            MessageBox.Show("Database error while saving transaction: " & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        RefreshAll()
        ClearForm(True)
        tslStatus.Text = "Saved " & t & " of " & Money(amount) & " on " & net & " at " & Date.Now.ToString("HH:mm") & "."
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        ClearForm(False)
        tslStatus.Text = "Form cleared."
    End Sub

    Private Sub ClearForm(keepNetwork As Boolean)
        epMain.Clear()
        If Not keepNetwork Then ClearNetworkSelection()
        ClearTypeSelection()
        txtPhone.Clear()
        txtAmount.Clear()
        txtCommission.Text = "0.00"
        If keepNetwork Then
            radTypeCashIn.Focus()
        Else
            radNet0.Focus()
        End If
    End Sub


    '  VOID (ADMIN ONLY)

    Private Sub btnVoid_Click(sender As Object, e As EventArgs)
        If Not currentUser.IsAdmin Then Return
        If dgvTransactions.SelectedRows.Count = 0 Then
            MessageBox.Show("Click a transaction in the list first.", "Void", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim t As Txn = DirectCast(dgvTransactions.SelectedRows(0).DataBoundItem, Txn)

        If t.TxnType = TypeCashIn AndAlso CashInTill < t.Amount Then
            MessageBox.Show("Cannot void: not enough cash in till to reverse this Cash-In.", "Void", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If (t.TxnType = TypeCashOut OrElse t.TxnType = TypeTopUp) AndAlso Floats(t.Network) < t.Amount Then
            MessageBox.Show("Cannot void: not enough " & t.Network & " float to reverse this transaction.", "Void", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim reason As String = InputBox("Why are you voiding this " & t.TxnType & " of " & Money(t.Amount) & "?", "Void transaction", "").Trim()
        If reason = "" Then
            MessageBox.Show("A reason is required to void a transaction.", "Void", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim auditDetails As String = t.TxnType & " " & Money(t.Amount) & " on " & t.Network & " by " & t.RecordedBy & ". Reason: " & reason
        Try
            VoidTransaction(t, reason, currentUser.Username, currentUser.Role, auditDetails)
        Catch ex As Exception
            MessageBox.Show("Database error while voiding transaction: " & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        RefreshAll()
        tslStatus.Text = "Transaction voided."
    End Sub


    '  SCREEN REFRESH

    Private Sub RefreshAll()
        RefreshDisplay()
        RefreshGrid()
        RefreshCashTab()
        RefreshECashTab()
        RefreshLogGrid()
        RefreshUsersGrid()
        RefreshReportIfOpen()
    End Sub

    Private Sub RefreshDisplay()
        lblCashValue.Text = Money(CashInTill)
        lblMtnValue.Text = Money(Floats(Networks(0)))
        lblTelecelValue.Text = Money(Floats(Networks(1)))
        lblAirtelValue.Text = Money(Floats(Networks(2)))

        Dim low As New List(Of String)
        StyleCard(pnlMtnCard, lblMtnValue, Networks(0), low)
        StyleCard(pnlTelecelCard, lblTelecelValue, Networks(1), low)
        StyleCard(pnlAirtelCard, lblAirtelValue, Networks(2), low)

        If low.Count > 0 Then
            pnlAlert.BackColor = AlertTint
            lblAlert.ForeColor = AlertOrange
            lblAlert.Text = "LOW FLOAT ALERT:  " & String.Join(",  ", low) & ".  Please top up soon."
        Else
            pnlAlert.BackColor = OkTint
            lblAlert.ForeColor = BrandGreen
            lblAlert.Text = "All floats are above their limits."
        End If

        Dim scoped As List(Of Txn) = GetScopedTxns()
        lblCount.Text = scoped.Count.ToString()
        lblVolume.Text = Money(scoped.Sum(Function(x) x.Amount))
        lblCommissionTotal.Text = Money(scoped.Sum(Function(x) x.Commission))
    End Sub

    Private Sub StyleCard(card As Panel, valueLabel As Label, network As String, low As List(Of String))
        If Floats(network) < Limits(network) Then
            card.BackColor = AlertTint
            valueLabel.ForeColor = AlertOrange
            low.Add(network & " (" & Money(Floats(network)) & ", limit " & Money(Limits(network)) & ")")
        Else
            card.BackColor = Color.White
            valueLabel.ForeColor = Ink
        End If
    End Sub

    Private Sub RefreshGrid()
        If dgvTransactions Is Nothing Then Return
        Dim q As String = txtSearch.Text.Trim().ToLowerInvariant()
        Dim scoped As List(Of Txn) = GetScopedTxns()
        Dim rows As List(Of Txn) = scoped.Where(Function(t) q = "" OrElse
            (t.Network & " " & t.TxnType & " " & t.Phone & " " & t.RecordedBy & " " & t.TimeText).ToLowerInvariant().Contains(q)).ToList()
        dgvTransactions.DataSource = rows
        lblShowing.Text = "Showing " & rows.Count & " of " & scoped.Count
    End Sub


    '  SET FLOAT LIMIT / SET BALANCES (ADMIN ONLY)

    Private Sub btnSetLimit_Click(sender As Object, e As EventArgs)
        If Not currentUser.IsAdmin Then Return
        If SelectedNetwork = "" Then
            MessageBox.Show("First choose a network using the Network buttons, then click Set Float Limit.",
                            "Set Float Limit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            radNet0.Focus()
            Return
        End If
        Dim net As String = SelectedNetwork
        Dim input As String = InputBox("Enter the low-float limit for " & net & " (in cedis):",
                                       "Set Float Limit", Limits(net).ToString("0.00", CultureInfo.InvariantCulture))
        If input.Trim() = "" Then Return
        Dim v As Decimal
        If Not TryParseMoney(input, v) Then
            MessageBox.Show("Please enter a valid amount, for example 1500 or 1500.50.",
                            "Set Float Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        SaveLimit(net, v)
        Audit("Float limit", net & " limit set to " & Money(v))
        RefreshAll()
        tslStatus.Text = "Float limit for " & net & " set to " & Money(v) & "."
    End Sub

    Private Sub btnBalances_Click(sender As Object, e As EventArgs)
        If Not currentUser.IsAdmin Then Return
        If Txns.Count > 0 Then
            If MessageBox.Show("Transactions have already been recorded today. Overwrite the current balances?",
                               "Set Balances", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        End If

        Dim names() As String = {"Cash in till", Networks(0) & " float", Networks(1) & " float", Networks(2) & " float"}
        Dim current() As Decimal = {CashInTill, Floats(Networks(0)), Floats(Networks(1)), Floats(Networks(2))}
        Dim values(3) As Decimal

        For i As Integer = 0 To 3
            Dim s As String = InputBox("Enter " & names(i) & " (in cedis):", "Set Balances",
                                       current(i).ToString("0.00", CultureInfo.InvariantCulture))
            If s.Trim() = "" OrElse Not TryParseMoney(s, values(i)) Then
                MessageBox.Show("Invalid or cancelled entry. No balances were changed.",
                                "Set Balances", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        Dim newFloats As New Dictionary(Of String, Decimal) From {
            {Networks(0), values(1)},
            {Networks(1), values(2)},
            {Networks(2), values(3)}
        }
        SaveBalances(values(0), newFloats)
        Audit("Balances set", "Till " & Money(values(0)) & ", MTN " & Money(values(1)) & ", Telecel " & Money(values(2)) & ", AirtelTigo " & Money(values(3)))
        RefreshAll()
        tslStatus.Text = "Balances updated."
    End Sub


    '  SAVE BACKUP (CSV)

    Private Function CsvField(value As String) As String
        Return """" & value.Replace("""", """""") & """"
    End Function

    Private Sub btnBackup_Click(sender As Object, e As EventArgs)
        Dim scoped As List(Of Txn) = GetScopedTxns()
        If scoped.Count = 0 Then
            MessageBox.Show("There are no transactions to back up yet.", "Save Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dlg As New SaveFileDialog()
            dlg.Title = "Save backup"
            dlg.Filter = "CSV file (*.csv)|*.csv"
            dlg.FileName = "FloatWise_" & Date.Now.ToString("yyyy-MM-dd") & ".csv"
            If dlg.ShowDialog() <> DialogResult.OK Then Return

            Try
                Using sw As New StreamWriter(dlg.FileName, False, New UTF8Encoding(True))
                    sw.WriteLine("No,Time,Network,Type,Phone,Amount,Commission,RecordedBy,Role")
                    For Each t As Txn In scoped.OrderBy(Function(x) x.Id)
                        Dim phoneCell As String = ""
                        If t.Phone <> "" Then phoneCell = CsvField("=""" & t.Phone & """")
                        sw.WriteLine(t.Id & "," & t.TimeText & "," & CsvField(t.Network) & "," & CsvField(t.TxnType) & "," &
                                     phoneCell & "," & t.Amount.ToString("0.00", CultureInfo.InvariantCulture) & "," &
                                     t.Commission.ToString("0.00", CultureInfo.InvariantCulture) & "," & CsvField(t.RecordedBy) & "," & CsvField(t.Role))
                    Next
                End Using
                NotBackedUp = False
                Audit("Backup", "Saved " & Path.GetFileName(dlg.FileName))
                tslStatus.Text = "Backup saved: " & Path.GetFileName(dlg.FileName)
            Catch ex As Exception
                MessageBox.Show("The backup could not be saved." & vbCrLf & ex.Message,
                                "Save Backup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

End Class
