<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    ' ---- Form Header ----
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents chip As System.Windows.Forms.Label
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button

    ' ---- Tab Control & Pages ----
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpDash As System.Windows.Forms.TabPage
    Friend WithEvents tpCash As System.Windows.Forms.TabPage
    Friend WithEvents tpECash As System.Windows.Forms.TabPage
    Friend WithEvents tpLog As System.Windows.Forms.TabPage
    Friend WithEvents tpUsers As System.Windows.Forms.TabPage

    ' ---- Status Strip ----
    Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents epMain As System.Windows.Forms.ErrorProvider
    Friend WithEvents tip As System.Windows.Forms.ToolTip

    ' ---- Dashboard Controls ----
    Friend WithEvents pnlCashCard As System.Windows.Forms.Panel
    Friend WithEvents pnlCashBar As System.Windows.Forms.Panel
    Friend WithEvents lblCashTitle As System.Windows.Forms.Label
    Friend WithEvents lblCashValue As System.Windows.Forms.Label

    Friend WithEvents pnlMtnCard As System.Windows.Forms.Panel
    Friend WithEvents pnlMtnBar As System.Windows.Forms.Panel
    Friend WithEvents lblMtnTitle As System.Windows.Forms.Label
    Friend WithEvents lblMtnValue As System.Windows.Forms.Label

    Friend WithEvents pnlTelecelCard As System.Windows.Forms.Panel
    Friend WithEvents pnlTelecelBar As System.Windows.Forms.Panel
    Friend WithEvents lblTelecelTitle As System.Windows.Forms.Label
    Friend WithEvents lblTelecelValue As System.Windows.Forms.Label

    Friend WithEvents pnlAirtelCard As System.Windows.Forms.Panel
    Friend WithEvents pnlAirtelBar As System.Windows.Forms.Panel
    Friend WithEvents lblAirtelTitle As System.Windows.Forms.Label
    Friend WithEvents lblAirtelValue As System.Windows.Forms.Label

    Friend WithEvents pnlAlert As System.Windows.Forms.Panel
    Friend WithEvents lblAlert As System.Windows.Forms.Label

    Friend WithEvents grpEntry As System.Windows.Forms.GroupBox
    Friend WithEvents lblNetwork As System.Windows.Forms.Label
    Friend WithEvents pnlNetwork As System.Windows.Forms.Panel
    Friend WithEvents radNet0 As System.Windows.Forms.RadioButton
    Friend WithEvents radNet1 As System.Windows.Forms.RadioButton
    Friend WithEvents radNet2 As System.Windows.Forms.RadioButton
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents pnlType As System.Windows.Forms.Panel
    Friend WithEvents radTypeCashIn As System.Windows.Forms.RadioButton
    Friend WithEvents radTypeCashOut As System.Windows.Forms.RadioButton
    Friend WithEvents radTypeTopUp As System.Windows.Forms.RadioButton
    Friend WithEvents btnToggleTopUpType As System.Windows.Forms.Button
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblCommission As System.Windows.Forms.Label
    Friend WithEvents txtCommission As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button

    Friend WithEvents grpToday As System.Windows.Forms.GroupBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblShowing As System.Windows.Forms.Label
    Friend WithEvents dgvTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTileCount As System.Windows.Forms.Panel
    Friend WithEvents lblCountTitle As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents pnlTileVolume As System.Windows.Forms.Panel
    Friend WithEvents lblVolumeTitle As System.Windows.Forms.Label
    Friend WithEvents lblVolume As System.Windows.Forms.Label
    Friend WithEvents pnlTileCommission As System.Windows.Forms.Panel
    Friend WithEvents lblCommissionTotalTitle As System.Windows.Forms.Label
    Friend WithEvents lblCommissionTotal As System.Windows.Forms.Label

    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnBackup As System.Windows.Forms.Button
    Friend WithEvents btnToggleLimitMode As System.Windows.Forms.Button
    Friend WithEvents btnSetLimit As System.Windows.Forms.Button
    Friend WithEvents btnBalances As System.Windows.Forms.Button
    Friend WithEvents btnVoid As System.Windows.Forms.Button

    ' ---- Physical Cash Tab Controls ----
    Friend WithEvents grpCashCount As System.Windows.Forms.GroupBox
    Friend WithEvents numCount0 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCount1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCount2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCount3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCount4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCount5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCount6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCount7 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSub0 As System.Windows.Forms.Label
    Friend WithEvents lblSub1 As System.Windows.Forms.Label
    Friend WithEvents lblSub2 As System.Windows.Forms.Label
    Friend WithEvents lblSub3 As System.Windows.Forms.Label
    Friend WithEvents lblSub4 As System.Windows.Forms.Label
    Friend WithEvents lblSub5 As System.Windows.Forms.Label
    Friend WithEvents lblSub6 As System.Windows.Forms.Label
    Friend WithEvents lblSub7 As System.Windows.Forms.Label
    Friend WithEvents numCoins As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCountedTotal As System.Windows.Forms.Label
    Friend WithEvents btnCountRecord As System.Windows.Forms.Button
    Friend WithEvents btnCountReset As System.Windows.Forms.Button
    Friend WithEvents btnMatchTill As System.Windows.Forms.Button

    Friend WithEvents pnlTillSystem As System.Windows.Forms.Panel
    Friend WithEvents lblTillSystem As System.Windows.Forms.Label
    Friend WithEvents pnlTillCounted As System.Windows.Forms.Panel
    Friend WithEvents lblTillCounted As System.Windows.Forms.Label
    Friend WithEvents pnlDiff As System.Windows.Forms.Panel
    Friend WithEvents lblDiff As System.Windows.Forms.Label
    Friend WithEvents lblDiffNote As System.Windows.Forms.Label
    Friend WithEvents pnlMoveIn As System.Windows.Forms.Panel
    Friend WithEvents lblMoveIn As System.Windows.Forms.Label
    Friend WithEvents pnlMoveOut As System.Windows.Forms.Panel
    Friend WithEvents lblMoveOut As System.Windows.Forms.Label
    Friend WithEvents pnlMoveTop As System.Windows.Forms.Panel
    Friend WithEvents lblMoveTop As System.Windows.Forms.Label
    Friend WithEvents tipPanel As System.Windows.Forms.Panel
    Friend WithEvents tipText As System.Windows.Forms.Label

    ' ---- E-Cash Tab Controls ----
    Friend WithEvents pnlNetRow0 As System.Windows.Forms.Panel
    Friend WithEvents lblEStatus0 As System.Windows.Forms.Label
    Friend WithEvents lblEFloat0 As System.Windows.Forms.Label
    Friend WithEvents lblELimit0 As System.Windows.Forms.Label
    Friend WithEvents pnlEFill0 As System.Windows.Forms.Panel
    Friend WithEvents txtActual0 As System.Windows.Forms.TextBox
    Friend WithEvents btnCheck0 As System.Windows.Forms.Button
    Friend WithEvents btnTop0 As System.Windows.Forms.Button
    Friend WithEvents lblVar0 As System.Windows.Forms.Label

    Friend WithEvents pnlNetRow1 As System.Windows.Forms.Panel
    Friend WithEvents lblEStatus1 As System.Windows.Forms.Label
    Friend WithEvents lblEFloat1 As System.Windows.Forms.Label
    Friend WithEvents lblELimit1 As System.Windows.Forms.Label
    Friend WithEvents pnlEFill1 As System.Windows.Forms.Panel
    Friend WithEvents txtActual1 As System.Windows.Forms.TextBox
    Friend WithEvents btnCheck1 As System.Windows.Forms.Button
    Friend WithEvents btnTop1 As System.Windows.Forms.Button
    Friend WithEvents lblVar1 As System.Windows.Forms.Label

    Friend WithEvents pnlNetRow2 As System.Windows.Forms.Panel
    Friend WithEvents lblEStatus2 As System.Windows.Forms.Label
    Friend WithEvents lblEFloat2 As System.Windows.Forms.Label
    Friend WithEvents lblELimit2 As System.Windows.Forms.Label
    Friend WithEvents pnlEFill2 As System.Windows.Forms.Panel
    Friend WithEvents txtActual2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCheck2 As System.Windows.Forms.Button
    Friend WithEvents btnTop2 As System.Windows.Forms.Button
    Friend WithEvents lblVar2 As System.Windows.Forms.Label

    Friend WithEvents pnlTotalEFloat As System.Windows.Forms.Panel
    Friend WithEvents lblTotalEFloat As System.Windows.Forms.Label
    Friend WithEvents pnlTotalCashE As System.Windows.Forms.Panel
    Friend WithEvents lblTotalCashE As System.Windows.Forms.Label
    Friend WithEvents pnlTotalMoney As System.Windows.Forms.Panel
    Friend WithEvents lblTotalMoney As System.Windows.Forms.Label

    ' ---- Activity Log Tab Controls ----
    Friend WithEvents txtLogSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnExportLog As System.Windows.Forms.Button
    Friend WithEvents btnLogDelete As System.Windows.Forms.Button
    Friend WithEvents btnLogClear As System.Windows.Forms.Button
    Friend WithEvents dgvLog As System.Windows.Forms.DataGridView
    Friend WithEvents lblLogNote As System.Windows.Forms.Label

    ' ---- Users Tab Controls ----
    Friend WithEvents grpAddUser As System.Windows.Forms.GroupBox
    Friend WithEvents txtUName As System.Windows.Forms.TextBox
    Friend WithEvents txtUUser As System.Windows.Forms.TextBox
    Friend WithEvents txtUPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUConfirm As System.Windows.Forms.TextBox
    Friend WithEvents cboURole As System.Windows.Forms.ComboBox
    Friend WithEvents btnCreateUser As System.Windows.Forms.Button
    Friend WithEvents lblUserMsg As System.Windows.Forms.Label
    Friend WithEvents dgvUsers As System.Windows.Forms.DataGridView
    Friend WithEvents btnToggleUser As System.Windows.Forms.Button
    Friend WithEvents btnResetUserPass As System.Windows.Forms.Button
    Friend WithEvents lblUsersNote As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.chip = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpDash = New System.Windows.Forms.TabPage()
        Me.pnlCashCard = New System.Windows.Forms.Panel()
        Me.pnlCashBar = New System.Windows.Forms.Panel()
        Me.lblCashTitle = New System.Windows.Forms.Label()
        Me.lblCashValue = New System.Windows.Forms.Label()
        Me.pnlMtnCard = New System.Windows.Forms.Panel()
        Me.pnlMtnBar = New System.Windows.Forms.Panel()
        Me.lblMtnTitle = New System.Windows.Forms.Label()
        Me.lblMtnValue = New System.Windows.Forms.Label()
        Me.pnlTelecelCard = New System.Windows.Forms.Panel()
        Me.pnlTelecelBar = New System.Windows.Forms.Panel()
        Me.lblTelecelTitle = New System.Windows.Forms.Label()
        Me.lblTelecelValue = New System.Windows.Forms.Label()
        Me.pnlAirtelCard = New System.Windows.Forms.Panel()
        Me.pnlAirtelBar = New System.Windows.Forms.Panel()
        Me.lblAirtelTitle = New System.Windows.Forms.Label()
        Me.lblAirtelValue = New System.Windows.Forms.Label()
        Me.pnlAlert = New System.Windows.Forms.Panel()
        Me.lblAlert = New System.Windows.Forms.Label()
        Me.grpEntry = New System.Windows.Forms.GroupBox()
        Me.lblNetwork = New System.Windows.Forms.Label()
        Me.pnlNetwork = New System.Windows.Forms.Panel()
        Me.radNet0 = New System.Windows.Forms.RadioButton()
        Me.radNet1 = New System.Windows.Forms.RadioButton()
        Me.radNet2 = New System.Windows.Forms.RadioButton()
        Me.lblType = New System.Windows.Forms.Label()
        Me.pnlType = New System.Windows.Forms.Panel()
        Me.radTypeCashIn = New System.Windows.Forms.RadioButton()
        Me.radTypeCashOut = New System.Windows.Forms.RadioButton()
        Me.radTypeTopUp = New System.Windows.Forms.RadioButton()
        Me.btnToggleTopUpType = New System.Windows.Forms.Button()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lblCommission = New System.Windows.Forms.Label()
        Me.txtCommission = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.grpToday = New System.Windows.Forms.GroupBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblShowing = New System.Windows.Forms.Label()
        Me.dgvTransactions = New System.Windows.Forms.DataGridView()
        Me.pnlTileCount = New System.Windows.Forms.Panel()
        Me.lblCountTitle = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.pnlTileVolume = New System.Windows.Forms.Panel()
        Me.lblVolumeTitle = New System.Windows.Forms.Label()
        Me.lblVolume = New System.Windows.Forms.Label()
        Me.pnlTileCommission = New System.Windows.Forms.Panel()
        Me.lblCommissionTotalTitle = New System.Windows.Forms.Label()
        Me.lblCommissionTotal = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.btnToggleLimitMode = New System.Windows.Forms.Button()
        Me.btnSetLimit = New System.Windows.Forms.Button()
        Me.btnBalances = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.tpCash = New System.Windows.Forms.TabPage()
        Me.grpCashCount = New System.Windows.Forms.GroupBox()
        Me.numCount0 = New System.Windows.Forms.NumericUpDown()
        Me.lblSub0 = New System.Windows.Forms.Label()
        Me.numCount1 = New System.Windows.Forms.NumericUpDown()
        Me.lblSub1 = New System.Windows.Forms.Label()
        Me.numCount2 = New System.Windows.Forms.NumericUpDown()
        Me.lblSub2 = New System.Windows.Forms.Label()
        Me.numCount3 = New System.Windows.Forms.NumericUpDown()
        Me.lblSub3 = New System.Windows.Forms.Label()
        Me.numCount4 = New System.Windows.Forms.NumericUpDown()
        Me.lblSub4 = New System.Windows.Forms.Label()
        Me.numCount5 = New System.Windows.Forms.NumericUpDown()
        Me.lblSub5 = New System.Windows.Forms.Label()
        Me.numCount6 = New System.Windows.Forms.NumericUpDown()
        Me.lblSub6 = New System.Windows.Forms.Label()
        Me.numCount7 = New System.Windows.Forms.NumericUpDown()
        Me.lblSub7 = New System.Windows.Forms.Label()
        Me.numCoins = New System.Windows.Forms.NumericUpDown()
        Me.lblCountedTotal = New System.Windows.Forms.Label()
        Me.btnCountRecord = New System.Windows.Forms.Button()
        Me.btnCountReset = New System.Windows.Forms.Button()
        Me.btnMatchTill = New System.Windows.Forms.Button()
        Me.pnlTillSystem = New System.Windows.Forms.Panel()
        Me.lblTillSystem = New System.Windows.Forms.Label()
        Me.pnlTillCounted = New System.Windows.Forms.Panel()
        Me.lblTillCounted = New System.Windows.Forms.Label()
        Me.pnlDiff = New System.Windows.Forms.Panel()
        Me.lblDiff = New System.Windows.Forms.Label()
        Me.lblDiffNote = New System.Windows.Forms.Label()
        Me.pnlMoveIn = New System.Windows.Forms.Panel()
        Me.lblMoveIn = New System.Windows.Forms.Label()
        Me.pnlMoveOut = New System.Windows.Forms.Panel()
        Me.lblMoveOut = New System.Windows.Forms.Label()
        Me.pnlMoveTop = New System.Windows.Forms.Panel()
        Me.lblMoveTop = New System.Windows.Forms.Label()
        Me.tipPanel = New System.Windows.Forms.Panel()
        Me.tipText = New System.Windows.Forms.Label()
        Me.tpECash = New System.Windows.Forms.TabPage()
        Me.pnlNetRow0 = New System.Windows.Forms.Panel()
        Me.lblEStatus0 = New System.Windows.Forms.Label()
        Me.lblEFloat0 = New System.Windows.Forms.Label()
        Me.lblELimit0 = New System.Windows.Forms.Label()
        Me.pnlEFill0 = New System.Windows.Forms.Panel()
        Me.txtActual0 = New System.Windows.Forms.TextBox()
        Me.btnCheck0 = New System.Windows.Forms.Button()
        Me.btnTop0 = New System.Windows.Forms.Button()
        Me.lblVar0 = New System.Windows.Forms.Label()
        Me.pnlNetRow1 = New System.Windows.Forms.Panel()
        Me.lblEStatus1 = New System.Windows.Forms.Label()
        Me.lblEFloat1 = New System.Windows.Forms.Label()
        Me.lblELimit1 = New System.Windows.Forms.Label()
        Me.pnlEFill1 = New System.Windows.Forms.Panel()
        Me.txtActual1 = New System.Windows.Forms.TextBox()
        Me.btnCheck1 = New System.Windows.Forms.Button()
        Me.btnTop1 = New System.Windows.Forms.Button()
        Me.lblVar1 = New System.Windows.Forms.Label()
        Me.pnlNetRow2 = New System.Windows.Forms.Panel()
        Me.lblEStatus2 = New System.Windows.Forms.Label()
        Me.lblEFloat2 = New System.Windows.Forms.Label()
        Me.lblELimit2 = New System.Windows.Forms.Label()
        Me.pnlEFill2 = New System.Windows.Forms.Panel()
        Me.txtActual2 = New System.Windows.Forms.TextBox()
        Me.btnCheck2 = New System.Windows.Forms.Button()
        Me.btnTop2 = New System.Windows.Forms.Button()
        Me.lblVar2 = New System.Windows.Forms.Label()
        Me.pnlTotalEFloat = New System.Windows.Forms.Panel()
        Me.lblTotalEFloat = New System.Windows.Forms.Label()
        Me.pnlTotalCashE = New System.Windows.Forms.Panel()
        Me.lblTotalCashE = New System.Windows.Forms.Label()
        Me.pnlTotalMoney = New System.Windows.Forms.Panel()
        Me.lblTotalMoney = New System.Windows.Forms.Label()
        Me.tpLog = New System.Windows.Forms.TabPage()
        Me.txtLogSearch = New System.Windows.Forms.TextBox()
        Me.btnExportLog = New System.Windows.Forms.Button()
        Me.btnLogDelete = New System.Windows.Forms.Button()
        Me.btnLogClear = New System.Windows.Forms.Button()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.lblLogNote = New System.Windows.Forms.Label()
        Me.tpUsers = New System.Windows.Forms.TabPage()
        Me.grpAddUser = New System.Windows.Forms.GroupBox()
        Me.txtUName = New System.Windows.Forms.TextBox()
        Me.txtUUser = New System.Windows.Forms.TextBox()
        Me.txtUPass = New System.Windows.Forms.TextBox()
        Me.txtUConfirm = New System.Windows.Forms.TextBox()
        Me.cboURole = New System.Windows.Forms.ComboBox()
        Me.btnCreateUser = New System.Windows.Forms.Button()
        Me.lblUserMsg = New System.Windows.Forms.Label()
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.btnToggleUser = New System.Windows.Forms.Button()
        Me.btnResetUserPass = New System.Windows.Forms.Button()
        Me.lblUsersNote = New System.Windows.Forms.Label()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.epMain = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlHeader.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tpDash.SuspendLayout()
        Me.pnlCashCard.SuspendLayout()
        Me.pnlMtnCard.SuspendLayout()
        Me.pnlTelecelCard.SuspendLayout()
        Me.pnlAirtelCard.SuspendLayout()
        Me.pnlAlert.SuspendLayout()
        Me.grpEntry.SuspendLayout()
        Me.pnlNetwork.SuspendLayout()
        Me.pnlType.SuspendLayout()
        Me.grpToday.SuspendLayout()
        CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTileCount.SuspendLayout()
        Me.pnlTileVolume.SuspendLayout()
        Me.pnlTileCommission.SuspendLayout()
        Me.tpCash.SuspendLayout()
        Me.grpCashCount.SuspendLayout()
        CType(Me.numCount0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCount1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCount2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCount3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCount4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCount5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCount6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCount7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCoins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTillSystem.SuspendLayout()
        Me.pnlTillCounted.SuspendLayout()
        Me.pnlDiff.SuspendLayout()
        Me.pnlMoveIn.SuspendLayout()
        Me.pnlMoveOut.SuspendLayout()
        Me.pnlMoveTop.SuspendLayout()
        Me.tipPanel.SuspendLayout()
        Me.tpECash.SuspendLayout()
        Me.pnlNetRow0.SuspendLayout()
        Me.pnlNetRow1.SuspendLayout()
        Me.pnlNetRow2.SuspendLayout()
        Me.pnlTotalEFloat.SuspendLayout()
        Me.pnlTotalCashE.SuspendLayout()
        Me.pnlTotalMoney.SuspendLayout()
        Me.tpLog.SuspendLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpUsers.SuspendLayout()
        Me.grpAddUser.SuspendLayout()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssMain.SuspendLayout()
        CType(Me.epMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlHeader.Controls.Add(Me.lblHeaderSub)
        Me.pnlHeader.Controls.Add(Me.lblUser)
        Me.pnlHeader.Controls.Add(Me.chip)
        Me.pnlHeader.Controls.Add(Me.btnLogout)
        Me.pnlHeader.Controls.Add(Me.btnExit)
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1240, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 19.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(16, 6)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(167, 45)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "FloatWise"
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblHeaderSub.Location = New System.Drawing.Point(18, 36)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(167, 21)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "MoMo Agent Manager"
        '
        'lblUser
        '
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(610, 8)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(380, 24)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Administrator"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chip
        '
        Me.chip.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.chip.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.chip.ForeColor = System.Drawing.Color.White
        Me.chip.Location = New System.Drawing.Point(900, 34)
        Me.chip.Name = "chip"
        Me.chip.Size = New System.Drawing.Size(90, 20)
        Me.chip.TabIndex = 3
        Me.chip.Text = "ADMIN"
        Me.chip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(1004, 13)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(100, 34)
        Me.btnLogout.TabIndex = 4
        Me.btnLogout.Text = "Log out"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(1114, 13)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(100, 34)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tpDash)
        Me.tabMain.Controls.Add(Me.tpCash)
        Me.tabMain.Controls.Add(Me.tpECash)
        Me.tabMain.Controls.Add(Me.tpLog)
        Me.tabMain.Controls.Add(Me.tpUsers)
        Me.tabMain.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.tabMain.ItemSize = New System.Drawing.Size(170, 36)
        Me.tabMain.Location = New System.Drawing.Point(0, 60)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1240, 712)
        Me.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabMain.TabIndex = 1
        '
        'tpDash
        '
        Me.tpDash.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tpDash.Controls.Add(Me.pnlCashCard)
        Me.tpDash.Controls.Add(Me.pnlMtnCard)
        Me.tpDash.Controls.Add(Me.pnlTelecelCard)
        Me.tpDash.Controls.Add(Me.pnlAirtelCard)
        Me.tpDash.Controls.Add(Me.pnlAlert)
        Me.tpDash.Controls.Add(Me.grpEntry)
        Me.tpDash.Controls.Add(Me.grpToday)
        Me.tpDash.Controls.Add(Me.btnReport)
        Me.tpDash.Controls.Add(Me.btnBackup)
        Me.tpDash.Controls.Add(Me.btnToggleLimitMode)
        Me.tpDash.Controls.Add(Me.btnSetLimit)
        Me.tpDash.Controls.Add(Me.btnBalances)
        Me.tpDash.Controls.Add(Me.btnVoid)
        Me.tpDash.Location = New System.Drawing.Point(4, 40)
        Me.tpDash.Name = "tpDash"
        Me.tpDash.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDash.Size = New System.Drawing.Size(1232, 668)
        Me.tpDash.TabIndex = 0
        Me.tpDash.Text = "Dashboard"
        '
        'pnlCashCard
        '
        Me.pnlCashCard.BackColor = System.Drawing.Color.White
        Me.pnlCashCard.Controls.Add(Me.pnlCashBar)
        Me.pnlCashCard.Controls.Add(Me.lblCashTitle)
        Me.pnlCashCard.Controls.Add(Me.lblCashValue)
        Me.pnlCashCard.Location = New System.Drawing.Point(12, 12)
        Me.pnlCashCard.Name = "pnlCashCard"
        Me.pnlCashCard.Size = New System.Drawing.Size(282, 84)
        Me.pnlCashCard.TabIndex = 0
        '
        'pnlCashBar
        '
        Me.pnlCashBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.pnlCashBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlCashBar.Name = "pnlCashBar"
        Me.pnlCashBar.Size = New System.Drawing.Size(8, 84)
        Me.pnlCashBar.TabIndex = 0
        '
        'lblCashTitle
        '
        Me.lblCashTitle.AutoSize = True
        Me.lblCashTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCashTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCashTitle.Location = New System.Drawing.Point(20, 10)
        Me.lblCashTitle.Name = "lblCashTitle"
        Me.lblCashTitle.Size = New System.Drawing.Size(94, 23)
        Me.lblCashTitle.TabIndex = 1
        Me.lblCashTitle.Text = "Cash in till"
        '
        'lblCashValue
        '
        Me.lblCashValue.AutoSize = True
        Me.lblCashValue.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCashValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblCashValue.Location = New System.Drawing.Point(18, 38)
        Me.lblCashValue.Name = "lblCashValue"
        Me.lblCashValue.Size = New System.Drawing.Size(168, 46)
        Me.lblCashValue.TabIndex = 2
        Me.lblCashValue.Text = "GH₵ 0.00"
        '
        'pnlMtnCard
        '
        Me.pnlMtnCard.BackColor = System.Drawing.Color.White
        Me.pnlMtnCard.Controls.Add(Me.pnlMtnBar)
        Me.pnlMtnCard.Controls.Add(Me.lblMtnTitle)
        Me.pnlMtnCard.Controls.Add(Me.lblMtnValue)
        Me.pnlMtnCard.Location = New System.Drawing.Point(312, 12)
        Me.pnlMtnCard.Name = "pnlMtnCard"
        Me.pnlMtnCard.Size = New System.Drawing.Size(282, 84)
        Me.pnlMtnCard.TabIndex = 1
        '
        'pnlMtnBar
        '
        Me.pnlMtnBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.pnlMtnBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlMtnBar.Name = "pnlMtnBar"
        Me.pnlMtnBar.Size = New System.Drawing.Size(8, 84)
        Me.pnlMtnBar.TabIndex = 0
        '
        'lblMtnTitle
        '
        Me.lblMtnTitle.AutoSize = True
        Me.lblMtnTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMtnTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblMtnTitle.Location = New System.Drawing.Point(20, 10)
        Me.lblMtnTitle.Name = "lblMtnTitle"
        Me.lblMtnTitle.Size = New System.Drawing.Size(149, 23)
        Me.lblMtnTitle.TabIndex = 1
        Me.lblMtnTitle.Text = "MTN MoMo float"
        '
        'lblMtnValue
        '
        Me.lblMtnValue.AutoSize = True
        Me.lblMtnValue.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblMtnValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblMtnValue.Location = New System.Drawing.Point(18, 38)
        Me.lblMtnValue.Name = "lblMtnValue"
        Me.lblMtnValue.Size = New System.Drawing.Size(168, 46)
        Me.lblMtnValue.TabIndex = 2
        Me.lblMtnValue.Text = "GH₵ 0.00"
        '
        'pnlTelecelCard
        '
        Me.pnlTelecelCard.BackColor = System.Drawing.Color.White
        Me.pnlTelecelCard.Controls.Add(Me.pnlTelecelBar)
        Me.pnlTelecelCard.Controls.Add(Me.lblTelecelTitle)
        Me.pnlTelecelCard.Controls.Add(Me.lblTelecelValue)
        Me.pnlTelecelCard.Location = New System.Drawing.Point(612, 12)
        Me.pnlTelecelCard.Name = "pnlTelecelCard"
        Me.pnlTelecelCard.Size = New System.Drawing.Size(282, 84)
        Me.pnlTelecelCard.TabIndex = 2
        '
        'pnlTelecelBar
        '
        Me.pnlTelecelBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.pnlTelecelBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTelecelBar.Name = "pnlTelecelBar"
        Me.pnlTelecelBar.Size = New System.Drawing.Size(8, 84)
        Me.pnlTelecelBar.TabIndex = 0
        '
        'lblTelecelTitle
        '
        Me.lblTelecelTitle.AutoSize = True
        Me.lblTelecelTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTelecelTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTelecelTitle.Location = New System.Drawing.Point(20, 10)
        Me.lblTelecelTitle.Name = "lblTelecelTitle"
        Me.lblTelecelTitle.Size = New System.Drawing.Size(148, 23)
        Me.lblTelecelTitle.TabIndex = 1
        Me.lblTelecelTitle.Text = "Telecel Cash float"
        '
        'lblTelecelValue
        '
        Me.lblTelecelValue.AutoSize = True
        Me.lblTelecelValue.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTelecelValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblTelecelValue.Location = New System.Drawing.Point(18, 38)
        Me.lblTelecelValue.Name = "lblTelecelValue"
        Me.lblTelecelValue.Size = New System.Drawing.Size(168, 46)
        Me.lblTelecelValue.TabIndex = 2
        Me.lblTelecelValue.Text = "GH₵ 0.00"
        '
        'pnlAirtelCard
        '
        Me.pnlAirtelCard.BackColor = System.Drawing.Color.White
        Me.pnlAirtelCard.Controls.Add(Me.pnlAirtelBar)
        Me.pnlAirtelCard.Controls.Add(Me.lblAirtelTitle)
        Me.pnlAirtelCard.Controls.Add(Me.lblAirtelValue)
        Me.pnlAirtelCard.Location = New System.Drawing.Point(912, 12)
        Me.pnlAirtelCard.Name = "pnlAirtelCard"
        Me.pnlAirtelCard.Size = New System.Drawing.Size(282, 84)
        Me.pnlAirtelCard.TabIndex = 3
        '
        'pnlAirtelBar
        '
        Me.pnlAirtelBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.pnlAirtelBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlAirtelBar.Name = "pnlAirtelBar"
        Me.pnlAirtelBar.Size = New System.Drawing.Size(8, 84)
        Me.pnlAirtelBar.TabIndex = 0
        '
        'lblAirtelTitle
        '
        Me.lblAirtelTitle.AutoSize = True
        Me.lblAirtelTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblAirtelTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblAirtelTitle.Location = New System.Drawing.Point(20, 10)
        Me.lblAirtelTitle.Name = "lblAirtelTitle"
        Me.lblAirtelTitle.Size = New System.Drawing.Size(134, 23)
        Me.lblAirtelTitle.TabIndex = 1
        Me.lblAirtelTitle.Text = "AirtelTigo float"
        '
        'lblAirtelValue
        '
        Me.lblAirtelValue.AutoSize = True
        Me.lblAirtelValue.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblAirtelValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblAirtelValue.Location = New System.Drawing.Point(18, 38)
        Me.lblAirtelValue.Name = "lblAirtelValue"
        Me.lblAirtelValue.Size = New System.Drawing.Size(168, 46)
        Me.lblAirtelValue.TabIndex = 2
        Me.lblAirtelValue.Text = "GH₵ 0.00"
        '
        'pnlAlert
        '
        Me.pnlAlert.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.pnlAlert.Controls.Add(Me.lblAlert)
        Me.pnlAlert.Location = New System.Drawing.Point(12, 104)
        Me.pnlAlert.Name = "pnlAlert"
        Me.pnlAlert.Size = New System.Drawing.Size(1182, 34)
        Me.pnlAlert.TabIndex = 4
        '
        'lblAlert
        '
        Me.lblAlert.AutoSize = True
        Me.lblAlert.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlert.ForeColor = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.lblAlert.Location = New System.Drawing.Point(16, 7)
        Me.lblAlert.Name = "lblAlert"
        Me.lblAlert.Size = New System.Drawing.Size(192, 23)
        Me.lblAlert.TabIndex = 0
        Me.lblAlert.Text = "All float levels healthy."
        '
        'grpEntry
        '
        Me.grpEntry.BackColor = System.Drawing.Color.White
        Me.grpEntry.Controls.Add(Me.lblNetwork)
        Me.grpEntry.Controls.Add(Me.pnlNetwork)
        Me.grpEntry.Controls.Add(Me.lblType)
        Me.grpEntry.Controls.Add(Me.pnlType)
        Me.grpEntry.Controls.Add(Me.lblPhone)
        Me.grpEntry.Controls.Add(Me.txtPhone)
        Me.grpEntry.Controls.Add(Me.lblAmount)
        Me.grpEntry.Controls.Add(Me.txtAmount)
        Me.grpEntry.Controls.Add(Me.lblCommission)
        Me.grpEntry.Controls.Add(Me.txtCommission)
        Me.grpEntry.Controls.Add(Me.btnSave)
        Me.grpEntry.Controls.Add(Me.btnClear)
        Me.grpEntry.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpEntry.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.grpEntry.Location = New System.Drawing.Point(12, 146)
        Me.grpEntry.Name = "grpEntry"
        Me.grpEntry.Size = New System.Drawing.Size(380, 466)
        Me.grpEntry.TabIndex = 5
        Me.grpEntry.TabStop = False
        Me.grpEntry.Text = "Record a transaction"
        '
        'lblNetwork
        '
        Me.lblNetwork.AutoSize = True
        Me.lblNetwork.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNetwork.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblNetwork.Location = New System.Drawing.Point(16, 26)
        Me.lblNetwork.Name = "lblNetwork"
        Me.lblNetwork.Size = New System.Drawing.Size(80, 23)
        Me.lblNetwork.TabIndex = 0
        Me.lblNetwork.Text = "Network"
        '
        'pnlNetwork
        '
        Me.pnlNetwork.Controls.Add(Me.radNet0)
        Me.pnlNetwork.Controls.Add(Me.radNet1)
        Me.pnlNetwork.Controls.Add(Me.radNet2)
        Me.pnlNetwork.Location = New System.Drawing.Point(16, 48)
        Me.pnlNetwork.Name = "pnlNetwork"
        Me.pnlNetwork.Size = New System.Drawing.Size(346, 28)
        Me.pnlNetwork.TabIndex = 1
        '
        'radNet0
        '
        Me.radNet0.AutoSize = True
        Me.radNet0.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.radNet0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.radNet0.Location = New System.Drawing.Point(0, 3)
        Me.radNet0.Name = "radNet0"
        Me.radNet0.Size = New System.Drawing.Size(122, 25)
        Me.radNet0.TabIndex = 0
        Me.radNet0.TabStop = True
        Me.radNet0.Text = "MTN MoMo"
        Me.radNet0.UseVisualStyleBackColor = True
        '
        'radNet1
        '
        Me.radNet1.AutoSize = True
        Me.radNet1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.radNet1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.radNet1.Location = New System.Drawing.Point(114, 3)
        Me.radNet1.Name = "radNet1"
        Me.radNet1.Size = New System.Drawing.Size(124, 25)
        Me.radNet1.TabIndex = 1
        Me.radNet1.TabStop = True
        Me.radNet1.Text = "Telecel Cash"
        Me.radNet1.UseVisualStyleBackColor = True
        '
        'radNet2
        '
        Me.radNet2.AutoSize = True
        Me.radNet2.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.radNet2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.radNet2.Location = New System.Drawing.Point(232, 3)
        Me.radNet2.Name = "radNet2"
        Me.radNet2.Size = New System.Drawing.Size(107, 25)
        Me.radNet2.TabIndex = 2
        Me.radNet2.TabStop = True
        Me.radNet2.Text = "AT Money"
        Me.radNet2.UseVisualStyleBackColor = True
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblType.Location = New System.Drawing.Point(16, 84)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(142, 23)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "Transaction type"
        '
        'pnlType
        '
        Me.pnlType.Controls.Add(Me.radTypeCashIn)
        Me.pnlType.Controls.Add(Me.radTypeCashOut)
        Me.pnlType.Controls.Add(Me.radTypeTopUp)
        Me.pnlType.Controls.Add(Me.btnToggleTopUpType)
        Me.pnlType.Location = New System.Drawing.Point(16, 106)
        Me.pnlType.Name = "pnlType"
        Me.pnlType.Size = New System.Drawing.Size(360, 28)
        Me.pnlType.TabIndex = 3
        '
        'radTypeCashIn
        '
        Me.radTypeCashIn.AutoSize = True
        Me.radTypeCashIn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.radTypeCashIn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.radTypeCashIn.Location = New System.Drawing.Point(0, 3)
        Me.radTypeCashIn.Name = "radTypeCashIn"
        Me.radTypeCashIn.Size = New System.Drawing.Size(81, 24)
        Me.radTypeCashIn.TabIndex = 0
        Me.radTypeCashIn.TabStop = True
        Me.radTypeCashIn.Text = "Cash-In"
        Me.radTypeCashIn.UseVisualStyleBackColor = True
        '
        'radTypeCashOut
        '
        Me.radTypeCashOut.AutoSize = True
        Me.radTypeCashOut.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.radTypeCashOut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.radTypeCashOut.Location = New System.Drawing.Point(78, 3)
        Me.radTypeCashOut.Name = "radTypeCashOut"
        Me.radTypeCashOut.Size = New System.Drawing.Size(93, 24)
        Me.radTypeCashOut.TabIndex = 1
        Me.radTypeCashOut.TabStop = True
        Me.radTypeCashOut.Text = "Cash-Out"
        Me.radTypeCashOut.UseVisualStyleBackColor = True
        '
        'radTypeTopUp
        '
        Me.radTypeTopUp.AutoSize = True
        Me.radTypeTopUp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.radTypeTopUp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.radTypeTopUp.Location = New System.Drawing.Point(164, 3)
        Me.radTypeTopUp.Name = "radTypeTopUp"
        Me.radTypeTopUp.Size = New System.Drawing.Size(118, 24)
        Me.radTypeTopUp.TabIndex = 2
        Me.radTypeTopUp.TabStop = True
        Me.radTypeTopUp.Text = "Float Top-up"
        Me.radTypeTopUp.UseVisualStyleBackColor = True
        '
        'btnToggleTopUpType
        '
        Me.btnToggleTopUpType.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnToggleTopUpType.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnToggleTopUpType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToggleTopUpType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnToggleTopUpType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.btnToggleTopUpType.Location = New System.Drawing.Point(286, 2)
        Me.btnToggleTopUpType.Name = "btnToggleTopUpType"
        Me.btnToggleTopUpType.Size = New System.Drawing.Size(24, 22)
        Me.btnToggleTopUpType.TabIndex = 3
        Me.btnToggleTopUpType.Text = "⇄"
        Me.btnToggleTopUpType.UseVisualStyleBackColor = False
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPhone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblPhone.Location = New System.Drawing.Point(16, 142)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(298, 23)
        Me.lblPhone.TabIndex = 4
        Me.lblPhone.Text = "Customer phone number (10 digits)"
        '
        'txtPhone
        '
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtPhone.Location = New System.Drawing.Point(16, 164)
        Me.txtPhone.MaxLength = 10
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(346, 31)
        Me.txtPhone.TabIndex = 5
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblAmount.Location = New System.Drawing.Point(16, 200)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(152, 23)
        Me.lblAmount.TabIndex = 6
        Me.lblAmount.Text = "Amount (in cedis)"
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtAmount.Location = New System.Drawing.Point(16, 222)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(346, 31)
        Me.txtAmount.TabIndex = 7
        '
        'lblCommission
        '
        Me.lblCommission.AutoSize = True
        Me.lblCommission.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCommission.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblCommission.Location = New System.Drawing.Point(16, 258)
        Me.lblCommission.Name = "lblCommission"
        Me.lblCommission.Size = New System.Drawing.Size(167, 23)
        Me.lblCommission.TabIndex = 8
        Me.lblCommission.Text = "Commission earned"
        '
        'txtCommission
        '
        Me.txtCommission.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtCommission.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCommission.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtCommission.Location = New System.Drawing.Point(16, 280)
        Me.txtCommission.Name = "txtCommission"
        Me.txtCommission.ReadOnly = True
        Me.txtCommission.Size = New System.Drawing.Size(346, 31)
        Me.txtCommission.TabIndex = 9
        Me.txtCommission.Text = "0.00"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(16, 324)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(346, 46)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save Transaction"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(16, 380)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(346, 40)
        Me.btnClear.TabIndex = 11
        Me.btnClear.Text = "Clear form"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'grpToday
        '
        Me.grpToday.BackColor = System.Drawing.Color.White
        Me.grpToday.Controls.Add(Me.lblSearch)
        Me.grpToday.Controls.Add(Me.txtSearch)
        Me.grpToday.Controls.Add(Me.lblShowing)
        Me.grpToday.Controls.Add(Me.dgvTransactions)
        Me.grpToday.Controls.Add(Me.pnlTileCount)
        Me.grpToday.Controls.Add(Me.pnlTileVolume)
        Me.grpToday.Controls.Add(Me.pnlTileCommission)
        Me.grpToday.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpToday.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.grpToday.Location = New System.Drawing.Point(406, 146)
        Me.grpToday.Name = "grpToday"
        Me.grpToday.Size = New System.Drawing.Size(788, 466)
        Me.grpToday.TabIndex = 6
        Me.grpToday.TabStop = False
        Me.grpToday.Text = "Today's transactions"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(18, 28)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(63, 23)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtSearch.Location = New System.Drawing.Point(76, 24)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(260, 31)
        Me.txtSearch.TabIndex = 1
        '
        'lblShowing
        '
        Me.lblShowing.AutoSize = True
        Me.lblShowing.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblShowing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblShowing.Location = New System.Drawing.Point(350, 28)
        Me.lblShowing.Name = "lblShowing"
        Me.lblShowing.Size = New System.Drawing.Size(115, 21)
        Me.lblShowing.TabIndex = 2
        Me.lblShowing.Text = "Showing 0 of 0"
        '
        'dgvTransactions
        '
        Me.dgvTransactions.AllowUserToAddRows = False
        Me.dgvTransactions.AllowUserToDeleteRows = False
        Me.dgvTransactions.BackgroundColor = System.Drawing.Color.White
        Me.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransactions.Location = New System.Drawing.Point(18, 58)
        Me.dgvTransactions.MultiSelect = False
        Me.dgvTransactions.Name = "dgvTransactions"
        Me.dgvTransactions.ReadOnly = True
        Me.dgvTransactions.RowHeadersVisible = False
        Me.dgvTransactions.RowHeadersWidth = 51
        Me.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransactions.Size = New System.Drawing.Size(752, 252)
        Me.dgvTransactions.TabIndex = 3
        '
        'pnlTileCount
        '
        Me.pnlTileCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.pnlTileCount.Controls.Add(Me.lblCountTitle)
        Me.pnlTileCount.Controls.Add(Me.lblCount)
        Me.pnlTileCount.Location = New System.Drawing.Point(18, 320)
        Me.pnlTileCount.Name = "pnlTileCount"
        Me.pnlTileCount.Size = New System.Drawing.Size(236, 80)
        Me.pnlTileCount.TabIndex = 4
        '
        'lblCountTitle
        '
        Me.lblCountTitle.AutoSize = True
        Me.lblCountTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblCountTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCountTitle.Location = New System.Drawing.Point(12, 10)
        Me.lblCountTitle.Name = "lblCountTitle"
        Me.lblCountTitle.Size = New System.Drawing.Size(105, 21)
        Me.lblCountTitle.TabIndex = 0
        Me.lblCountTitle.Text = "Transactions"
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblCount.Location = New System.Drawing.Point(10, 34)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(35, 41)
        Me.lblCount.TabIndex = 1
        Me.lblCount.Text = "0"
        '
        'pnlTileVolume
        '
        Me.pnlTileVolume.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.pnlTileVolume.Controls.Add(Me.lblVolumeTitle)
        Me.pnlTileVolume.Controls.Add(Me.lblVolume)
        Me.pnlTileVolume.Location = New System.Drawing.Point(266, 320)
        Me.pnlTileVolume.Name = "pnlTileVolume"
        Me.pnlTileVolume.Size = New System.Drawing.Size(236, 80)
        Me.pnlTileVolume.TabIndex = 5
        '
        'lblVolumeTitle
        '
        Me.lblVolumeTitle.AutoSize = True
        Me.lblVolumeTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblVolumeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblVolumeTitle.Location = New System.Drawing.Point(12, 10)
        Me.lblVolumeTitle.Name = "lblVolumeTitle"
        Me.lblVolumeTitle.Size = New System.Drawing.Size(110, 21)
        Me.lblVolumeTitle.TabIndex = 0
        Me.lblVolumeTitle.Text = "Total volume"
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblVolume.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblVolume.Location = New System.Drawing.Point(10, 36)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(135, 37)
        Me.lblVolume.TabIndex = 1
        Me.lblVolume.Text = "GH₵ 0.00"
        '
        'pnlTileCommission
        '
        Me.pnlTileCommission.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.pnlTileCommission.Controls.Add(Me.lblCommissionTotalTitle)
        Me.pnlTileCommission.Controls.Add(Me.lblCommissionTotal)
        Me.pnlTileCommission.Location = New System.Drawing.Point(514, 320)
        Me.pnlTileCommission.Name = "pnlTileCommission"
        Me.pnlTileCommission.Size = New System.Drawing.Size(236, 80)
        Me.pnlTileCommission.TabIndex = 6
        '
        'lblCommissionTotalTitle
        '
        Me.lblCommissionTotalTitle.AutoSize = True
        Me.lblCommissionTotalTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblCommissionTotalTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCommissionTotalTitle.Location = New System.Drawing.Point(12, 10)
        Me.lblCommissionTotalTitle.Name = "lblCommissionTotalTitle"
        Me.lblCommissionTotalTitle.Size = New System.Drawing.Size(209, 21)
        Me.lblCommissionTotalTitle.TabIndex = 0
        Me.lblCommissionTotalTitle.Text = "Commission earned today"
        '
        'lblCommissionTotal
        '
        Me.lblCommissionTotal.AutoSize = True
        Me.lblCommissionTotal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblCommissionTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblCommissionTotal.Location = New System.Drawing.Point(10, 36)
        Me.lblCommissionTotal.Name = "lblCommissionTotal"
        Me.lblCommissionTotal.Size = New System.Drawing.Size(135, 37)
        Me.lblCommissionTotal.TabIndex = 1
        Me.lblCommissionTotal.Text = "GH₵ 0.00"
        '
        'btnReport
        '
        Me.btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnReport.ForeColor = System.Drawing.Color.White
        Me.btnReport.Location = New System.Drawing.Point(12, 622)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(185, 42)
        Me.btnReport.TabIndex = 7
        Me.btnReport.Text = "Daily Report"
        Me.btnReport.UseVisualStyleBackColor = False
        '
        'btnBackup
        '
        Me.btnBackup.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackup.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnBackup.ForeColor = System.Drawing.Color.White
        Me.btnBackup.Location = New System.Drawing.Point(206, 622)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(185, 42)
        Me.btnBackup.TabIndex = 8
        Me.btnBackup.Text = "Save Backup"
        Me.btnBackup.UseVisualStyleBackColor = False
        '
        'btnToggleLimitMode
        '
        Me.btnToggleLimitMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnToggleLimitMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToggleLimitMode.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnToggleLimitMode.ForeColor = System.Drawing.Color.White
        Me.btnToggleLimitMode.Location = New System.Drawing.Point(398, 622)
        Me.btnToggleLimitMode.Name = "btnToggleLimitMode"
        Me.btnToggleLimitMode.Size = New System.Drawing.Size(38, 42)
        Me.btnToggleLimitMode.TabIndex = 8
        Me.btnToggleLimitMode.Text = "⇄"
        Me.btnToggleLimitMode.UseVisualStyleBackColor = False
        '
        'btnSetLimit
        '
        Me.btnSetLimit.BackColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.btnSetLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetLimit.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnSetLimit.ForeColor = System.Drawing.Color.White
        Me.btnSetLimit.Location = New System.Drawing.Point(440, 622)
        Me.btnSetLimit.Name = "btnSetLimit"
        Me.btnSetLimit.Size = New System.Drawing.Size(185, 42)
        Me.btnSetLimit.TabIndex = 9
        Me.btnSetLimit.Text = "Set Float Limit"
        Me.btnSetLimit.UseVisualStyleBackColor = False
        '
        'btnBalances
        '
        Me.btnBalances.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnBalances.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBalances.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnBalances.ForeColor = System.Drawing.Color.White
        Me.btnBalances.Location = New System.Drawing.Point(634, 622)
        Me.btnBalances.Name = "btnBalances"
        Me.btnBalances.Size = New System.Drawing.Size(185, 42)
        Me.btnBalances.TabIndex = 10
        Me.btnBalances.Text = "Set Balances"
        Me.btnBalances.UseVisualStyleBackColor = False
        '
        'btnVoid
        '
        Me.btnVoid.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoid.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnVoid.ForeColor = System.Drawing.Color.White
        Me.btnVoid.Location = New System.Drawing.Point(828, 622)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(185, 42)
        Me.btnVoid.TabIndex = 11
        Me.btnVoid.Text = "Void Selected"
        Me.btnVoid.UseVisualStyleBackColor = False
        '
        'tpCash
        '
        Me.tpCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tpCash.Controls.Add(Me.grpCashCount)
        Me.tpCash.Controls.Add(Me.pnlTillSystem)
        Me.tpCash.Controls.Add(Me.pnlTillCounted)
        Me.tpCash.Controls.Add(Me.pnlDiff)
        Me.tpCash.Controls.Add(Me.pnlMoveIn)
        Me.tpCash.Controls.Add(Me.pnlMoveOut)
        Me.tpCash.Controls.Add(Me.pnlMoveTop)
        Me.tpCash.Controls.Add(Me.tipPanel)
        Me.tpCash.Location = New System.Drawing.Point(4, 40)
        Me.tpCash.Name = "tpCash"
        Me.tpCash.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCash.Size = New System.Drawing.Size(1232, 668)
        Me.tpCash.TabIndex = 1
        Me.tpCash.Text = "Physical Cash"
        '
        'grpCashCount
        '
        Me.grpCashCount.BackColor = System.Drawing.Color.White
        Me.grpCashCount.Controls.Add(Me.numCount0)
        Me.grpCashCount.Controls.Add(Me.lblSub0)
        Me.grpCashCount.Controls.Add(Me.numCount1)
        Me.grpCashCount.Controls.Add(Me.lblSub1)
        Me.grpCashCount.Controls.Add(Me.numCount2)
        Me.grpCashCount.Controls.Add(Me.lblSub2)
        Me.grpCashCount.Controls.Add(Me.numCount3)
        Me.grpCashCount.Controls.Add(Me.lblSub3)
        Me.grpCashCount.Controls.Add(Me.numCount4)
        Me.grpCashCount.Controls.Add(Me.lblSub4)
        Me.grpCashCount.Controls.Add(Me.numCount5)
        Me.grpCashCount.Controls.Add(Me.lblSub5)
        Me.grpCashCount.Controls.Add(Me.numCount6)
        Me.grpCashCount.Controls.Add(Me.lblSub6)
        Me.grpCashCount.Controls.Add(Me.numCount7)
        Me.grpCashCount.Controls.Add(Me.lblSub7)
        Me.grpCashCount.Controls.Add(Me.numCoins)
        Me.grpCashCount.Controls.Add(Me.lblCountedTotal)
        Me.grpCashCount.Controls.Add(Me.btnCountRecord)
        Me.grpCashCount.Controls.Add(Me.btnCountReset)
        Me.grpCashCount.Controls.Add(Me.btnMatchTill)
        Me.grpCashCount.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpCashCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.grpCashCount.Location = New System.Drawing.Point(12, 12)
        Me.grpCashCount.Name = "grpCashCount"
        Me.grpCashCount.Size = New System.Drawing.Size(560, 640)
        Me.grpCashCount.TabIndex = 0
        Me.grpCashCount.TabStop = False
        Me.grpCashCount.Text = "Count the cash drawer"
        '
        'numCount0
        '
        Me.numCount0.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCount0.Location = New System.Drawing.Point(190, 42)
        Me.numCount0.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCount0.Name = "numCount0"
        Me.numCount0.Size = New System.Drawing.Size(120, 32)
        Me.numCount0.TabIndex = 0
        '
        'lblSub0
        '
        Me.lblSub0.AutoSize = True
        Me.lblSub0.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.lblSub0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSub0.Location = New System.Drawing.Point(340, 45)
        Me.lblSub0.Name = "lblSub0"
        Me.lblSub0.Size = New System.Drawing.Size(93, 28)
        Me.lblSub0.TabIndex = 1
        Me.lblSub0.Text = "GH₵ 0.00"
        '
        'numCount1
        '
        Me.numCount1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCount1.Location = New System.Drawing.Point(190, 88)
        Me.numCount1.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCount1.Name = "numCount1"
        Me.numCount1.Size = New System.Drawing.Size(120, 32)
        Me.numCount1.TabIndex = 2
        '
        'lblSub1
        '
        Me.lblSub1.AutoSize = True
        Me.lblSub1.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.lblSub1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSub1.Location = New System.Drawing.Point(340, 91)
        Me.lblSub1.Name = "lblSub1"
        Me.lblSub1.Size = New System.Drawing.Size(93, 28)
        Me.lblSub1.TabIndex = 3
        Me.lblSub1.Text = "GH₵ 0.00"
        '
        'numCount2
        '
        Me.numCount2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCount2.Location = New System.Drawing.Point(190, 134)
        Me.numCount2.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCount2.Name = "numCount2"
        Me.numCount2.Size = New System.Drawing.Size(120, 32)
        Me.numCount2.TabIndex = 4
        '
        'lblSub2
        '
        Me.lblSub2.AutoSize = True
        Me.lblSub2.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.lblSub2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSub2.Location = New System.Drawing.Point(340, 137)
        Me.lblSub2.Name = "lblSub2"
        Me.lblSub2.Size = New System.Drawing.Size(93, 28)
        Me.lblSub2.TabIndex = 5
        Me.lblSub2.Text = "GH₵ 0.00"
        '
        'numCount3
        '
        Me.numCount3.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCount3.Location = New System.Drawing.Point(190, 180)
        Me.numCount3.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCount3.Name = "numCount3"
        Me.numCount3.Size = New System.Drawing.Size(120, 32)
        Me.numCount3.TabIndex = 6
        '
        'lblSub3
        '
        Me.lblSub3.AutoSize = True
        Me.lblSub3.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.lblSub3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSub3.Location = New System.Drawing.Point(340, 183)
        Me.lblSub3.Name = "lblSub3"
        Me.lblSub3.Size = New System.Drawing.Size(93, 28)
        Me.lblSub3.TabIndex = 7
        Me.lblSub3.Text = "GH₵ 0.00"
        '
        'numCount4
        '
        Me.numCount4.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCount4.Location = New System.Drawing.Point(190, 226)
        Me.numCount4.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCount4.Name = "numCount4"
        Me.numCount4.Size = New System.Drawing.Size(120, 32)
        Me.numCount4.TabIndex = 8
        '
        'lblSub4
        '
        Me.lblSub4.AutoSize = True
        Me.lblSub4.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.lblSub4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSub4.Location = New System.Drawing.Point(340, 229)
        Me.lblSub4.Name = "lblSub4"
        Me.lblSub4.Size = New System.Drawing.Size(93, 28)
        Me.lblSub4.TabIndex = 9
        Me.lblSub4.Text = "GH₵ 0.00"
        '
        'numCount5
        '
        Me.numCount5.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCount5.Location = New System.Drawing.Point(190, 272)
        Me.numCount5.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCount5.Name = "numCount5"
        Me.numCount5.Size = New System.Drawing.Size(120, 32)
        Me.numCount5.TabIndex = 10
        '
        'lblSub5
        '
        Me.lblSub5.AutoSize = True
        Me.lblSub5.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.lblSub5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSub5.Location = New System.Drawing.Point(340, 275)
        Me.lblSub5.Name = "lblSub5"
        Me.lblSub5.Size = New System.Drawing.Size(93, 28)
        Me.lblSub5.TabIndex = 11
        Me.lblSub5.Text = "GH₵ 0.00"
        '
        'numCount6
        '
        Me.numCount6.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCount6.Location = New System.Drawing.Point(190, 318)
        Me.numCount6.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCount6.Name = "numCount6"
        Me.numCount6.Size = New System.Drawing.Size(120, 32)
        Me.numCount6.TabIndex = 12
        '
        'lblSub6
        '
        Me.lblSub6.AutoSize = True
        Me.lblSub6.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.lblSub6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSub6.Location = New System.Drawing.Point(340, 321)
        Me.lblSub6.Name = "lblSub6"
        Me.lblSub6.Size = New System.Drawing.Size(93, 28)
        Me.lblSub6.TabIndex = 13
        Me.lblSub6.Text = "GH₵ 0.00"
        '
        'numCount7
        '
        Me.numCount7.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCount7.Location = New System.Drawing.Point(190, 364)
        Me.numCount7.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCount7.Name = "numCount7"
        Me.numCount7.Size = New System.Drawing.Size(120, 32)
        Me.numCount7.TabIndex = 14
        '
        'lblSub7
        '
        Me.lblSub7.AutoSize = True
        Me.lblSub7.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.lblSub7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSub7.Location = New System.Drawing.Point(340, 367)
        Me.lblSub7.Name = "lblSub7"
        Me.lblSub7.Size = New System.Drawing.Size(93, 28)
        Me.lblSub7.TabIndex = 15
        Me.lblSub7.Text = "GH₵ 0.00"
        '
        'numCoins
        '
        Me.numCoins.DecimalPlaces = 2
        Me.numCoins.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numCoins.Location = New System.Drawing.Point(190, 410)
        Me.numCoins.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCoins.Name = "numCoins"
        Me.numCoins.Size = New System.Drawing.Size(120, 32)
        Me.numCoins.TabIndex = 16
        '
        'lblCountedTotal
        '
        Me.lblCountedTotal.AutoSize = True
        Me.lblCountedTotal.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCountedTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.lblCountedTotal.Location = New System.Drawing.Point(190, 464)
        Me.lblCountedTotal.Name = "lblCountedTotal"
        Me.lblCountedTotal.Size = New System.Drawing.Size(168, 46)
        Me.lblCountedTotal.TabIndex = 17
        Me.lblCountedTotal.Text = "GH₵ 0.00"
        '
        'btnCountRecord
        '
        Me.btnCountRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.btnCountRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCountRecord.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCountRecord.ForeColor = System.Drawing.Color.White
        Me.btnCountRecord.Location = New System.Drawing.Point(20, 524)
        Me.btnCountRecord.Name = "btnCountRecord"
        Me.btnCountRecord.Size = New System.Drawing.Size(260, 44)
        Me.btnCountRecord.TabIndex = 18
        Me.btnCountRecord.Text = "Record this count"
        Me.btnCountRecord.UseVisualStyleBackColor = False
        '
        'btnCountReset
        '
        Me.btnCountReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnCountReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCountReset.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCountReset.ForeColor = System.Drawing.Color.White
        Me.btnCountReset.Location = New System.Drawing.Point(292, 524)
        Me.btnCountReset.Name = "btnCountReset"
        Me.btnCountReset.Size = New System.Drawing.Size(130, 44)
        Me.btnCountReset.TabIndex = 19
        Me.btnCountReset.Text = "Reset"
        Me.btnCountReset.UseVisualStyleBackColor = False
        '
        'btnMatchTill
        '
        Me.btnMatchTill.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnMatchTill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMatchTill.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnMatchTill.ForeColor = System.Drawing.Color.White
        Me.btnMatchTill.Location = New System.Drawing.Point(20, 580)
        Me.btnMatchTill.Name = "btnMatchTill"
        Me.btnMatchTill.Size = New System.Drawing.Size(402, 40)
        Me.btnMatchTill.TabIndex = 20
        Me.btnMatchTill.Text = "Match till to counted cash"
        Me.btnMatchTill.UseVisualStyleBackColor = False
        '
        'pnlTillSystem
        '
        Me.pnlTillSystem.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.pnlTillSystem.Controls.Add(Me.lblTillSystem)
        Me.pnlTillSystem.Location = New System.Drawing.Point(590, 12)
        Me.pnlTillSystem.Name = "pnlTillSystem"
        Me.pnlTillSystem.Size = New System.Drawing.Size(292, 90)
        Me.pnlTillSystem.TabIndex = 1
        '
        'lblTillSystem
        '
        Me.lblTillSystem.AutoSize = True
        Me.lblTillSystem.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTillSystem.ForeColor = System.Drawing.Color.White
        Me.lblTillSystem.Location = New System.Drawing.Point(16, 40)
        Me.lblTillSystem.Name = "lblTillSystem"
        Me.lblTillSystem.Size = New System.Drawing.Size(135, 37)
        Me.lblTillSystem.TabIndex = 0
        Me.lblTillSystem.Text = "GH₵ 0.00"
        '
        'pnlTillCounted
        '
        Me.pnlTillCounted.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.pnlTillCounted.Controls.Add(Me.lblTillCounted)
        Me.pnlTillCounted.Location = New System.Drawing.Point(902, 12)
        Me.pnlTillCounted.Name = "pnlTillCounted"
        Me.pnlTillCounted.Size = New System.Drawing.Size(292, 90)
        Me.pnlTillCounted.TabIndex = 2
        '
        'lblTillCounted
        '
        Me.lblTillCounted.AutoSize = True
        Me.lblTillCounted.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTillCounted.ForeColor = System.Drawing.Color.White
        Me.lblTillCounted.Location = New System.Drawing.Point(16, 40)
        Me.lblTillCounted.Name = "lblTillCounted"
        Me.lblTillCounted.Size = New System.Drawing.Size(135, 37)
        Me.lblTillCounted.TabIndex = 0
        Me.lblTillCounted.Text = "GH₵ 0.00"
        '
        'pnlDiff
        '
        Me.pnlDiff.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.pnlDiff.Controls.Add(Me.lblDiff)
        Me.pnlDiff.Controls.Add(Me.lblDiffNote)
        Me.pnlDiff.Location = New System.Drawing.Point(590, 118)
        Me.pnlDiff.Name = "pnlDiff"
        Me.pnlDiff.Size = New System.Drawing.Size(604, 112)
        Me.pnlDiff.TabIndex = 3
        '
        'lblDiff
        '
        Me.lblDiff.AutoSize = True
        Me.lblDiff.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiff.ForeColor = System.Drawing.Color.White
        Me.lblDiff.Location = New System.Drawing.Point(16, 30)
        Me.lblDiff.Name = "lblDiff"
        Me.lblDiff.Size = New System.Drawing.Size(34, 46)
        Me.lblDiff.TabIndex = 0
        Me.lblDiff.Text = "-"
        '
        'lblDiffNote
        '
        Me.lblDiffNote.AutoSize = True
        Me.lblDiffNote.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.lblDiffNote.ForeColor = System.Drawing.Color.White
        Me.lblDiffNote.Location = New System.Drawing.Point(16, 76)
        Me.lblDiffNote.Name = "lblDiffNote"
        Me.lblDiffNote.Size = New System.Drawing.Size(302, 25)
        Me.lblDiffNote.TabIndex = 1
        Me.lblDiffNote.Text = "Enter the notes and coins on the left."
        '
        'pnlMoveIn
        '
        Me.pnlMoveIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.pnlMoveIn.Controls.Add(Me.lblMoveIn)
        Me.pnlMoveIn.Location = New System.Drawing.Point(590, 246)
        Me.pnlMoveIn.Name = "pnlMoveIn"
        Me.pnlMoveIn.Size = New System.Drawing.Size(190, 92)
        Me.pnlMoveIn.TabIndex = 4
        '
        'lblMoveIn
        '
        Me.lblMoveIn.AutoSize = True
        Me.lblMoveIn.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblMoveIn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblMoveIn.Location = New System.Drawing.Point(14, 40)
        Me.lblMoveIn.Name = "lblMoveIn"
        Me.lblMoveIn.Size = New System.Drawing.Size(119, 32)
        Me.lblMoveIn.TabIndex = 0
        Me.lblMoveIn.Text = "GH₵ 0.00"
        '
        'pnlMoveOut
        '
        Me.pnlMoveOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.pnlMoveOut.Controls.Add(Me.lblMoveOut)
        Me.pnlMoveOut.Location = New System.Drawing.Point(797, 246)
        Me.pnlMoveOut.Name = "pnlMoveOut"
        Me.pnlMoveOut.Size = New System.Drawing.Size(190, 92)
        Me.pnlMoveOut.TabIndex = 5
        '
        'lblMoveOut
        '
        Me.lblMoveOut.AutoSize = True
        Me.lblMoveOut.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblMoveOut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblMoveOut.Location = New System.Drawing.Point(14, 40)
        Me.lblMoveOut.Name = "lblMoveOut"
        Me.lblMoveOut.Size = New System.Drawing.Size(119, 32)
        Me.lblMoveOut.TabIndex = 0
        Me.lblMoveOut.Text = "GH₵ 0.00"
        '
        'pnlMoveTop
        '
        Me.pnlMoveTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.pnlMoveTop.Controls.Add(Me.lblMoveTop)
        Me.pnlMoveTop.Location = New System.Drawing.Point(1004, 246)
        Me.pnlMoveTop.Name = "pnlMoveTop"
        Me.pnlMoveTop.Size = New System.Drawing.Size(190, 92)
        Me.pnlMoveTop.TabIndex = 6
        '
        'lblMoveTop
        '
        Me.lblMoveTop.AutoSize = True
        Me.lblMoveTop.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblMoveTop.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblMoveTop.Location = New System.Drawing.Point(14, 40)
        Me.lblMoveTop.Name = "lblMoveTop"
        Me.lblMoveTop.Size = New System.Drawing.Size(119, 32)
        Me.lblMoveTop.TabIndex = 0
        Me.lblMoveTop.Text = "GH₵ 0.00"
        '
        'tipPanel
        '
        Me.tipPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.tipPanel.Controls.Add(Me.tipText)
        Me.tipPanel.Location = New System.Drawing.Point(590, 354)
        Me.tipPanel.Name = "tipPanel"
        Me.tipPanel.Size = New System.Drawing.Size(604, 104)
        Me.tipPanel.TabIndex = 7
        '
        'tipText
        '
        Me.tipText.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.tipText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.tipText.Location = New System.Drawing.Point(16, 18)
        Me.tipText.Name = "tipText"
        Me.tipText.Size = New System.Drawing.Size(570, 70)
        Me.tipText.TabIndex = 0
        Me.tipText.Text = "Tip: count the drawer at the start and end of every shift. A small difference today is easier to trace than a big one next week."
        '
        'tpECash
        '
        Me.tpECash.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tpECash.Controls.Add(Me.pnlNetRow0)
        Me.tpECash.Controls.Add(Me.pnlNetRow1)
        Me.tpECash.Controls.Add(Me.pnlNetRow2)
        Me.tpECash.Controls.Add(Me.pnlTotalEFloat)
        Me.tpECash.Controls.Add(Me.pnlTotalCashE)
        Me.tpECash.Controls.Add(Me.pnlTotalMoney)
        Me.tpECash.Location = New System.Drawing.Point(4, 40)
        Me.tpECash.Name = "tpECash"
        Me.tpECash.Padding = New System.Windows.Forms.Padding(3)
        Me.tpECash.Size = New System.Drawing.Size(1232, 668)
        Me.tpECash.TabIndex = 2
        Me.tpECash.Text = "E-Cash"
        '
        'pnlNetRow0
        '
        Me.pnlNetRow0.BackColor = System.Drawing.Color.White
        Me.pnlNetRow0.Controls.Add(Me.lblEStatus0)
        Me.pnlNetRow0.Controls.Add(Me.lblEFloat0)
        Me.pnlNetRow0.Controls.Add(Me.lblELimit0)
        Me.pnlNetRow0.Controls.Add(Me.pnlEFill0)
        Me.pnlNetRow0.Controls.Add(Me.txtActual0)
        Me.pnlNetRow0.Controls.Add(Me.btnCheck0)
        Me.pnlNetRow0.Controls.Add(Me.btnTop0)
        Me.pnlNetRow0.Controls.Add(Me.lblVar0)
        Me.pnlNetRow0.Location = New System.Drawing.Point(12, 12)
        Me.pnlNetRow0.Name = "pnlNetRow0"
        Me.pnlNetRow0.Size = New System.Drawing.Size(1182, 155)
        Me.pnlNetRow0.TabIndex = 0
        '
        'lblEStatus0
        '
        Me.lblEStatus0.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblEStatus0.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblEStatus0.ForeColor = System.Drawing.Color.White
        Me.lblEStatus0.Location = New System.Drawing.Point(28, 50)
        Me.lblEStatus0.Name = "lblEStatus0"
        Me.lblEStatus0.Size = New System.Drawing.Size(120, 24)
        Me.lblEStatus0.TabIndex = 0
        Me.lblEStatus0.Text = "HEALTHY"
        Me.lblEStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEFloat0
        '
        Me.lblEFloat0.AutoSize = True
        Me.lblEFloat0.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblEFloat0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblEFloat0.Location = New System.Drawing.Point(188, 36)
        Me.lblEFloat0.Name = "lblEFloat0"
        Me.lblEFloat0.Size = New System.Drawing.Size(168, 46)
        Me.lblEFloat0.TabIndex = 1
        Me.lblEFloat0.Text = "GH₵ 0.00"
        '
        'lblELimit0
        '
        Me.lblELimit0.AutoSize = True
        Me.lblELimit0.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblELimit0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.lblELimit0.Location = New System.Drawing.Point(438, 42)
        Me.lblELimit0.Name = "lblELimit0"
        Me.lblELimit0.Size = New System.Drawing.Size(122, 35)
        Me.lblELimit0.TabIndex = 2
        Me.lblELimit0.Text = "GH₵ 0.00"
        '
        'pnlEFill0
        '
        Me.pnlEFill0.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.pnlEFill0.Location = New System.Drawing.Point(28, 112)
        Me.pnlEFill0.Name = "pnlEFill0"
        Me.pnlEFill0.Size = New System.Drawing.Size(640, 18)
        Me.pnlEFill0.TabIndex = 3
        '
        'txtActual0
        '
        Me.txtActual0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActual0.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtActual0.Location = New System.Drawing.Point(720, 40)
        Me.txtActual0.MaxLength = 10
        Me.txtActual0.Name = "txtActual0"
        Me.txtActual0.Size = New System.Drawing.Size(200, 32)
        Me.txtActual0.TabIndex = 4
        '
        'btnCheck0
        '
        Me.btnCheck0.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnCheck0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheck0.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheck0.ForeColor = System.Drawing.Color.White
        Me.btnCheck0.Location = New System.Drawing.Point(930, 38)
        Me.btnCheck0.Name = "btnCheck0"
        Me.btnCheck0.Size = New System.Drawing.Size(90, 33)
        Me.btnCheck0.TabIndex = 5
        Me.btnCheck0.Text = "Check"
        Me.btnCheck0.UseVisualStyleBackColor = False
        '
        'btnTop0
        '
        Me.btnTop0.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.btnTop0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTop0.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTop0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btnTop0.Location = New System.Drawing.Point(1030, 38)
        Me.btnTop0.Name = "btnTop0"
        Me.btnTop0.Size = New System.Drawing.Size(140, 33)
        Me.btnTop0.TabIndex = 6
        Me.btnTop0.Text = "Top up float"
        Me.btnTop0.UseVisualStyleBackColor = False
        '
        'lblVar0
        '
        Me.lblVar0.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblVar0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblVar0.Location = New System.Drawing.Point(720, 84)
        Me.lblVar0.Name = "lblVar0"
        Me.lblVar0.Size = New System.Drawing.Size(450, 56)
        Me.lblVar0.TabIndex = 7
        '
        'pnlNetRow1
        '
        Me.pnlNetRow1.BackColor = System.Drawing.Color.White
        Me.pnlNetRow1.Controls.Add(Me.lblEStatus1)
        Me.pnlNetRow1.Controls.Add(Me.lblEFloat1)
        Me.pnlNetRow1.Controls.Add(Me.lblELimit1)
        Me.pnlNetRow1.Controls.Add(Me.pnlEFill1)
        Me.pnlNetRow1.Controls.Add(Me.txtActual1)
        Me.pnlNetRow1.Controls.Add(Me.btnCheck1)
        Me.pnlNetRow1.Controls.Add(Me.btnTop1)
        Me.pnlNetRow1.Controls.Add(Me.lblVar1)
        Me.pnlNetRow1.Location = New System.Drawing.Point(12, 177)
        Me.pnlNetRow1.Name = "pnlNetRow1"
        Me.pnlNetRow1.Size = New System.Drawing.Size(1182, 155)
        Me.pnlNetRow1.TabIndex = 1
        '
        'lblEStatus1
        '
        Me.lblEStatus1.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblEStatus1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblEStatus1.ForeColor = System.Drawing.Color.White
        Me.lblEStatus1.Location = New System.Drawing.Point(28, 50)
        Me.lblEStatus1.Name = "lblEStatus1"
        Me.lblEStatus1.Size = New System.Drawing.Size(120, 24)
        Me.lblEStatus1.TabIndex = 0
        Me.lblEStatus1.Text = "HEALTHY"
        Me.lblEStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEFloat1
        '
        Me.lblEFloat1.AutoSize = True
        Me.lblEFloat1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblEFloat1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblEFloat1.Location = New System.Drawing.Point(188, 36)
        Me.lblEFloat1.Name = "lblEFloat1"
        Me.lblEFloat1.Size = New System.Drawing.Size(168, 46)
        Me.lblEFloat1.TabIndex = 1
        Me.lblEFloat1.Text = "GH₵ 0.00"
        '
        'lblELimit1
        '
        Me.lblELimit1.AutoSize = True
        Me.lblELimit1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblELimit1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.lblELimit1.Location = New System.Drawing.Point(438, 42)
        Me.lblELimit1.Name = "lblELimit1"
        Me.lblELimit1.Size = New System.Drawing.Size(122, 35)
        Me.lblELimit1.TabIndex = 2
        Me.lblELimit1.Text = "GH₵ 0.00"
        '
        'pnlEFill1
        '
        Me.pnlEFill1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.pnlEFill1.Location = New System.Drawing.Point(28, 112)
        Me.pnlEFill1.Name = "pnlEFill1"
        Me.pnlEFill1.Size = New System.Drawing.Size(640, 18)
        Me.pnlEFill1.TabIndex = 3
        '
        'txtActual1
        '
        Me.txtActual1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActual1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtActual1.Location = New System.Drawing.Point(720, 40)
        Me.txtActual1.MaxLength = 10
        Me.txtActual1.Name = "txtActual1"
        Me.txtActual1.Size = New System.Drawing.Size(200, 32)
        Me.txtActual1.TabIndex = 4
        '
        'btnCheck1
        '
        Me.btnCheck1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnCheck1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheck1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheck1.ForeColor = System.Drawing.Color.White
        Me.btnCheck1.Location = New System.Drawing.Point(930, 38)
        Me.btnCheck1.Name = "btnCheck1"
        Me.btnCheck1.Size = New System.Drawing.Size(90, 33)
        Me.btnCheck1.TabIndex = 5
        Me.btnCheck1.Text = "Check"
        Me.btnCheck1.UseVisualStyleBackColor = False
        '
        'btnTop1
        '
        Me.btnTop1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.btnTop1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTop1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTop1.ForeColor = System.Drawing.Color.White
        Me.btnTop1.Location = New System.Drawing.Point(1030, 38)
        Me.btnTop1.Name = "btnTop1"
        Me.btnTop1.Size = New System.Drawing.Size(140, 33)
        Me.btnTop1.TabIndex = 6
        Me.btnTop1.Text = "Top up float"
        Me.btnTop1.UseVisualStyleBackColor = False
        '
        'lblVar1
        '
        Me.lblVar1.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblVar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblVar1.Location = New System.Drawing.Point(720, 84)
        Me.lblVar1.Name = "lblVar1"
        Me.lblVar1.Size = New System.Drawing.Size(450, 56)
        Me.lblVar1.TabIndex = 7
        '
        'pnlNetRow2
        '
        Me.pnlNetRow2.BackColor = System.Drawing.Color.White
        Me.pnlNetRow2.Controls.Add(Me.lblEStatus2)
        Me.pnlNetRow2.Controls.Add(Me.lblEFloat2)
        Me.pnlNetRow2.Controls.Add(Me.lblELimit2)
        Me.pnlNetRow2.Controls.Add(Me.pnlEFill2)
        Me.pnlNetRow2.Controls.Add(Me.txtActual2)
        Me.pnlNetRow2.Controls.Add(Me.btnCheck2)
        Me.pnlNetRow2.Controls.Add(Me.btnTop2)
        Me.pnlNetRow2.Controls.Add(Me.lblVar2)
        Me.pnlNetRow2.Location = New System.Drawing.Point(12, 342)
        Me.pnlNetRow2.Name = "pnlNetRow2"
        Me.pnlNetRow2.Size = New System.Drawing.Size(1182, 155)
        Me.pnlNetRow2.TabIndex = 2
        '
        'lblEStatus2
        '
        Me.lblEStatus2.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblEStatus2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblEStatus2.ForeColor = System.Drawing.Color.White
        Me.lblEStatus2.Location = New System.Drawing.Point(28, 50)
        Me.lblEStatus2.Name = "lblEStatus2"
        Me.lblEStatus2.Size = New System.Drawing.Size(120, 24)
        Me.lblEStatus2.TabIndex = 0
        Me.lblEStatus2.Text = "HEALTHY"
        Me.lblEStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEFloat2
        '
        Me.lblEFloat2.AutoSize = True
        Me.lblEFloat2.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblEFloat2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.lblEFloat2.Location = New System.Drawing.Point(188, 36)
        Me.lblEFloat2.Name = "lblEFloat2"
        Me.lblEFloat2.Size = New System.Drawing.Size(168, 46)
        Me.lblEFloat2.TabIndex = 1
        Me.lblEFloat2.Text = "GH₵ 0.00"
        '
        'lblELimit2
        '
        Me.lblELimit2.AutoSize = True
        Me.lblELimit2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblELimit2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.lblELimit2.Location = New System.Drawing.Point(438, 42)
        Me.lblELimit2.Name = "lblELimit2"
        Me.lblELimit2.Size = New System.Drawing.Size(122, 35)
        Me.lblELimit2.TabIndex = 2
        Me.lblELimit2.Text = "GH₵ 0.00"
        '
        'pnlEFill2
        '
        Me.pnlEFill2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.pnlEFill2.Location = New System.Drawing.Point(28, 112)
        Me.pnlEFill2.Name = "pnlEFill2"
        Me.pnlEFill2.Size = New System.Drawing.Size(640, 18)
        Me.pnlEFill2.TabIndex = 3
        '
        'txtActual2
        '
        Me.txtActual2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActual2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtActual2.Location = New System.Drawing.Point(720, 40)
        Me.txtActual2.MaxLength = 10
        Me.txtActual2.Name = "txtActual2"
        Me.txtActual2.Size = New System.Drawing.Size(200, 32)
        Me.txtActual2.TabIndex = 4
        '
        'btnCheck2
        '
        Me.btnCheck2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnCheck2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheck2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheck2.ForeColor = System.Drawing.Color.White
        Me.btnCheck2.Location = New System.Drawing.Point(930, 38)
        Me.btnCheck2.Name = "btnCheck2"
        Me.btnCheck2.Size = New System.Drawing.Size(90, 33)
        Me.btnCheck2.TabIndex = 5
        Me.btnCheck2.Text = "Check"
        Me.btnCheck2.UseVisualStyleBackColor = False
        '
        'btnTop2
        '
        Me.btnTop2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnTop2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTop2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTop2.ForeColor = System.Drawing.Color.White
        Me.btnTop2.Location = New System.Drawing.Point(1030, 38)
        Me.btnTop2.Name = "btnTop2"
        Me.btnTop2.Size = New System.Drawing.Size(140, 33)
        Me.btnTop2.TabIndex = 6
        Me.btnTop2.Text = "Top up float"
        Me.btnTop2.UseVisualStyleBackColor = False
        '
        'lblVar2
        '
        Me.lblVar2.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblVar2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblVar2.Location = New System.Drawing.Point(720, 84)
        Me.lblVar2.Name = "lblVar2"
        Me.lblVar2.Size = New System.Drawing.Size(450, 56)
        Me.lblVar2.TabIndex = 7
        '
        'pnlTotalEFloat
        '
        Me.pnlTotalEFloat.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlTotalEFloat.Controls.Add(Me.lblTotalEFloat)
        Me.pnlTotalEFloat.Location = New System.Drawing.Point(12, 510)
        Me.pnlTotalEFloat.Name = "pnlTotalEFloat"
        Me.pnlTotalEFloat.Size = New System.Drawing.Size(380, 84)
        Me.pnlTotalEFloat.TabIndex = 3
        '
        'lblTotalEFloat
        '
        Me.lblTotalEFloat.AutoSize = True
        Me.lblTotalEFloat.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalEFloat.ForeColor = System.Drawing.Color.White
        Me.lblTotalEFloat.Location = New System.Drawing.Point(16, 32)
        Me.lblTotalEFloat.Name = "lblTotalEFloat"
        Me.lblTotalEFloat.Size = New System.Drawing.Size(146, 41)
        Me.lblTotalEFloat.TabIndex = 0
        Me.lblTotalEFloat.Text = "GH₵ 0.00"
        '
        'pnlTotalCashE
        '
        Me.pnlTotalCashE.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.pnlTotalCashE.Controls.Add(Me.lblTotalCashE)
        Me.pnlTotalCashE.Location = New System.Drawing.Point(412, 510)
        Me.pnlTotalCashE.Name = "pnlTotalCashE"
        Me.pnlTotalCashE.Size = New System.Drawing.Size(380, 84)
        Me.pnlTotalCashE.TabIndex = 4
        '
        'lblTotalCashE
        '
        Me.lblTotalCashE.AutoSize = True
        Me.lblTotalCashE.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCashE.ForeColor = System.Drawing.Color.White
        Me.lblTotalCashE.Location = New System.Drawing.Point(16, 32)
        Me.lblTotalCashE.Name = "lblTotalCashE"
        Me.lblTotalCashE.Size = New System.Drawing.Size(146, 41)
        Me.lblTotalCashE.TabIndex = 0
        Me.lblTotalCashE.Text = "GH₵ 0.00"
        '
        'pnlTotalMoney
        '
        Me.pnlTotalMoney.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.pnlTotalMoney.Controls.Add(Me.lblTotalMoney)
        Me.pnlTotalMoney.Location = New System.Drawing.Point(812, 510)
        Me.pnlTotalMoney.Name = "pnlTotalMoney"
        Me.pnlTotalMoney.Size = New System.Drawing.Size(382, 84)
        Me.pnlTotalMoney.TabIndex = 5
        '
        'lblTotalMoney
        '
        Me.lblTotalMoney.AutoSize = True
        Me.lblTotalMoney.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalMoney.ForeColor = System.Drawing.Color.White
        Me.lblTotalMoney.Location = New System.Drawing.Point(16, 32)
        Me.lblTotalMoney.Name = "lblTotalMoney"
        Me.lblTotalMoney.Size = New System.Drawing.Size(146, 41)
        Me.lblTotalMoney.TabIndex = 0
        Me.lblTotalMoney.Text = "GH₵ 0.00"
        '
        'tpLog
        '
        Me.tpLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tpLog.Controls.Add(Me.txtLogSearch)
        Me.tpLog.Controls.Add(Me.btnExportLog)
        Me.tpLog.Controls.Add(Me.btnLogDelete)
        Me.tpLog.Controls.Add(Me.btnLogClear)
        Me.tpLog.Controls.Add(Me.dgvLog)
        Me.tpLog.Controls.Add(Me.lblLogNote)
        Me.tpLog.Location = New System.Drawing.Point(4, 40)
        Me.tpLog.Name = "tpLog"
        Me.tpLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLog.Size = New System.Drawing.Size(1232, 668)
        Me.tpLog.TabIndex = 3
        Me.tpLog.Text = "Activity Log"
        '
        'txtLogSearch
        '
        Me.txtLogSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogSearch.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtLogSearch.Location = New System.Drawing.Point(80, 16)
        Me.txtLogSearch.Name = "txtLogSearch"
        Me.txtLogSearch.Size = New System.Drawing.Size(340, 31)
        Me.txtLogSearch.TabIndex = 0
        '
        'btnExportLog
        '
        Me.btnExportLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.btnExportLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportLog.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportLog.ForeColor = System.Drawing.Color.White
        Me.btnExportLog.Location = New System.Drawing.Point(440, 12)
        Me.btnExportLog.Name = "btnExportLog"
        Me.btnExportLog.Size = New System.Drawing.Size(150, 36)
        Me.btnExportLog.TabIndex = 1
        Me.btnExportLog.Text = "Export log"
        Me.btnExportLog.UseVisualStyleBackColor = False
        '
        'btnLogDelete
        '
        Me.btnLogDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnLogDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogDelete.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogDelete.ForeColor = System.Drawing.Color.White
        Me.btnLogDelete.Location = New System.Drawing.Point(600, 12)
        Me.btnLogDelete.Name = "btnLogDelete"
        Me.btnLogDelete.Size = New System.Drawing.Size(170, 36)
        Me.btnLogDelete.TabIndex = 2
        Me.btnLogDelete.Text = "Delete selected"
        Me.btnLogDelete.UseVisualStyleBackColor = False
        '
        'btnLogClear
        '
        Me.btnLogClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnLogClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogClear.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogClear.ForeColor = System.Drawing.Color.White
        Me.btnLogClear.Location = New System.Drawing.Point(780, 12)
        Me.btnLogClear.Name = "btnLogClear"
        Me.btnLogClear.Size = New System.Drawing.Size(130, 36)
        Me.btnLogClear.TabIndex = 3
        Me.btnLogClear.Text = "Clear all"
        Me.btnLogClear.UseVisualStyleBackColor = False
        '
        'dgvLog
        '
        Me.dgvLog.AllowUserToAddRows = False
        Me.dgvLog.AllowUserToDeleteRows = False
        Me.dgvLog.BackgroundColor = System.Drawing.Color.White
        Me.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLog.Location = New System.Drawing.Point(12, 60)
        Me.dgvLog.MultiSelect = False
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.ReadOnly = True
        Me.dgvLog.RowHeadersVisible = False
        Me.dgvLog.RowHeadersWidth = 51
        Me.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLog.Size = New System.Drawing.Size(1182, 560)
        Me.dgvLog.TabIndex = 4
        '
        'lblLogNote
        '
        Me.lblLogNote.AutoSize = True
        Me.lblLogNote.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblLogNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblLogNote.Location = New System.Drawing.Point(12, 630)
        Me.lblLogNote.Name = "lblLogNote"
        Me.lblLogNote.Size = New System.Drawing.Size(530, 23)
        Me.lblLogNote.TabIndex = 5
        Me.lblLogNote.Text = "Every action is recorded here. Only the admin can delete log entries."
        '
        'tpUsers
        '
        Me.tpUsers.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tpUsers.Controls.Add(Me.grpAddUser)
        Me.tpUsers.Controls.Add(Me.dgvUsers)
        Me.tpUsers.Controls.Add(Me.btnToggleUser)
        Me.tpUsers.Controls.Add(Me.btnResetUserPass)
        Me.tpUsers.Controls.Add(Me.lblUsersNote)
        Me.tpUsers.Location = New System.Drawing.Point(4, 40)
        Me.tpUsers.Name = "tpUsers"
        Me.tpUsers.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUsers.Size = New System.Drawing.Size(1232, 668)
        Me.tpUsers.TabIndex = 4
        Me.tpUsers.Text = "Users"
        '
        'grpAddUser
        '
        Me.grpAddUser.BackColor = System.Drawing.Color.White
        Me.grpAddUser.Controls.Add(Me.txtUName)
        Me.grpAddUser.Controls.Add(Me.txtUUser)
        Me.grpAddUser.Controls.Add(Me.txtUPass)
        Me.grpAddUser.Controls.Add(Me.txtUConfirm)
        Me.grpAddUser.Controls.Add(Me.cboURole)
        Me.grpAddUser.Controls.Add(Me.btnCreateUser)
        Me.grpAddUser.Controls.Add(Me.lblUserMsg)
        Me.grpAddUser.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpAddUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.grpAddUser.Location = New System.Drawing.Point(12, 12)
        Me.grpAddUser.Name = "grpAddUser"
        Me.grpAddUser.Size = New System.Drawing.Size(440, 480)
        Me.grpAddUser.TabIndex = 0
        Me.grpAddUser.TabStop = False
        Me.grpAddUser.Text = "Create an account"
        '
        'txtUName
        '
        Me.txtUName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUName.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtUName.Location = New System.Drawing.Point(20, 56)
        Me.txtUName.Name = "txtUName"
        Me.txtUName.Size = New System.Drawing.Size(400, 31)
        Me.txtUName.TabIndex = 0
        '
        'txtUUser
        '
        Me.txtUUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUUser.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtUUser.Location = New System.Drawing.Point(20, 116)
        Me.txtUUser.Name = "txtUUser"
        Me.txtUUser.Size = New System.Drawing.Size(400, 31)
        Me.txtUUser.TabIndex = 1
        '
        'txtUPass
        '
        Me.txtUPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUPass.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtUPass.Location = New System.Drawing.Point(20, 176)
        Me.txtUPass.Name = "txtUPass"
        Me.txtUPass.Size = New System.Drawing.Size(400, 31)
        Me.txtUPass.TabIndex = 2
        Me.txtUPass.UseSystemPasswordChar = True
        '
        'txtUConfirm
        '
        Me.txtUConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUConfirm.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtUConfirm.Location = New System.Drawing.Point(20, 236)
        Me.txtUConfirm.Name = "txtUConfirm"
        Me.txtUConfirm.Size = New System.Drawing.Size(400, 31)
        Me.txtUConfirm.TabIndex = 3
        Me.txtUConfirm.UseSystemPasswordChar = True
        '
        'cboURole
        '
        Me.cboURole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboURole.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.cboURole.FormattingEnabled = True
        Me.cboURole.Items.AddRange(New Object() {"Worker (record txns, count cash, reports)", "Admin (full control)"})
        Me.cboURole.Location = New System.Drawing.Point(20, 296)
        Me.cboURole.Name = "cboURole"
        Me.cboURole.Size = New System.Drawing.Size(400, 31)
        Me.cboURole.TabIndex = 4
        '
        'btnCreateUser
        '
        Me.btnCreateUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateUser.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateUser.ForeColor = System.Drawing.Color.White
        Me.btnCreateUser.Location = New System.Drawing.Point(20, 346)
        Me.btnCreateUser.Name = "btnCreateUser"
        Me.btnCreateUser.Size = New System.Drawing.Size(400, 46)
        Me.btnCreateUser.TabIndex = 5
        Me.btnCreateUser.Text = "Create account"
        Me.btnCreateUser.UseVisualStyleBackColor = False
        '
        'lblUserMsg
        '
        Me.lblUserMsg.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUserMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.lblUserMsg.Location = New System.Drawing.Point(20, 402)
        Me.lblUserMsg.Name = "lblUserMsg"
        Me.lblUserMsg.Size = New System.Drawing.Size(400, 60)
        Me.lblUserMsg.TabIndex = 6
        '
        'dgvUsers
        '
        Me.dgvUsers.AllowUserToAddRows = False
        Me.dgvUsers.AllowUserToDeleteRows = False
        Me.dgvUsers.BackgroundColor = System.Drawing.Color.White
        Me.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Location = New System.Drawing.Point(470, 12)
        Me.dgvUsers.MultiSelect = False
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.ReadOnly = True
        Me.dgvUsers.RowHeadersVisible = False
        Me.dgvUsers.RowHeadersWidth = 51
        Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsers.Size = New System.Drawing.Size(724, 480)
        Me.dgvUsers.TabIndex = 1
        '
        'btnToggleUser
        '
        Me.btnToggleUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnToggleUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToggleUser.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnToggleUser.ForeColor = System.Drawing.Color.White
        Me.btnToggleUser.Location = New System.Drawing.Point(470, 504)
        Me.btnToggleUser.Name = "btnToggleUser"
        Me.btnToggleUser.Size = New System.Drawing.Size(240, 42)
        Me.btnToggleUser.TabIndex = 2
        Me.btnToggleUser.Text = "Enable / Disable selected"
        Me.btnToggleUser.UseVisualStyleBackColor = False
        '
        'btnResetUserPass
        '
        Me.btnResetUserPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnResetUserPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetUserPass.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnResetUserPass.ForeColor = System.Drawing.Color.White
        Me.btnResetUserPass.Location = New System.Drawing.Point(725, 504)
        Me.btnResetUserPass.Name = "btnResetUserPass"
        Me.btnResetUserPass.Size = New System.Drawing.Size(200, 42)
        Me.btnResetUserPass.TabIndex = 3
        Me.btnResetUserPass.Text = "Reset password"
        Me.btnResetUserPass.UseVisualStyleBackColor = False
        '
        'lblUsersNote
        '
        Me.lblUsersNote.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblUsersNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblUsersNote.Location = New System.Drawing.Point(470, 554)
        Me.lblUsersNote.Name = "lblUsersNote"
        Me.lblUsersNote.Size = New System.Drawing.Size(724, 45)
        Me.lblUsersNote.TabIndex = 3
        Me.lblUsersNote.Text = "Disabled users cannot sign in. Existing transactions they recorded are kept in th" &
    "e ledger."
        '
        'ssMain
        '
        Me.ssMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.ssMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus})
        Me.ssMain.Location = New System.Drawing.Point(0, 771)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Size = New System.Drawing.Size(1240, 29)
        Me.ssMain.TabIndex = 2
        '
        'tslStatus
        '
        Me.tslStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tslStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(56, 23)
        Me.tslStatus.Text = "Ready"
        '
        'epMain
        '
        Me.epMain.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epMain.ContainerControl = Me
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1240, 800)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.ssMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FloatWise - MoMo Agent Manager"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tpDash.ResumeLayout(False)
        Me.pnlCashCard.ResumeLayout(False)
        Me.pnlCashCard.PerformLayout()
        Me.pnlMtnCard.ResumeLayout(False)
        Me.pnlMtnCard.PerformLayout()
        Me.pnlTelecelCard.ResumeLayout(False)
        Me.pnlTelecelCard.PerformLayout()
        Me.pnlAirtelCard.ResumeLayout(False)
        Me.pnlAirtelCard.PerformLayout()
        Me.pnlAlert.ResumeLayout(False)
        Me.pnlAlert.PerformLayout()
        Me.grpEntry.ResumeLayout(False)
        Me.grpEntry.PerformLayout()
        Me.pnlNetwork.ResumeLayout(False)
        Me.pnlNetwork.PerformLayout()
        Me.pnlType.ResumeLayout(False)
        Me.pnlType.PerformLayout()
        Me.grpToday.ResumeLayout(False)
        Me.grpToday.PerformLayout()
        CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTileCount.ResumeLayout(False)
        Me.pnlTileCount.PerformLayout()
        Me.pnlTileVolume.ResumeLayout(False)
        Me.pnlTileVolume.PerformLayout()
        Me.pnlTileCommission.ResumeLayout(False)
        Me.pnlTileCommission.PerformLayout()
        Me.tpCash.ResumeLayout(False)
        Me.grpCashCount.ResumeLayout(False)
        Me.grpCashCount.PerformLayout()
        CType(Me.numCount0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCount1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCount2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCount3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCount4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCount5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCount6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCount7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCoins, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTillSystem.ResumeLayout(False)
        Me.pnlTillSystem.PerformLayout()
        Me.pnlTillCounted.ResumeLayout(False)
        Me.pnlTillCounted.PerformLayout()
        Me.pnlDiff.ResumeLayout(False)
        Me.pnlDiff.PerformLayout()
        Me.pnlMoveIn.ResumeLayout(False)
        Me.pnlMoveIn.PerformLayout()
        Me.pnlMoveOut.ResumeLayout(False)
        Me.pnlMoveOut.PerformLayout()
        Me.pnlMoveTop.ResumeLayout(False)
        Me.pnlMoveTop.PerformLayout()
        Me.tipPanel.ResumeLayout(False)
        Me.tpECash.ResumeLayout(False)
        Me.pnlNetRow0.ResumeLayout(False)
        Me.pnlNetRow0.PerformLayout()
        Me.pnlNetRow1.ResumeLayout(False)
        Me.pnlNetRow1.PerformLayout()
        Me.pnlNetRow2.ResumeLayout(False)
        Me.pnlNetRow2.PerformLayout()
        Me.pnlTotalEFloat.ResumeLayout(False)
        Me.pnlTotalEFloat.PerformLayout()
        Me.pnlTotalCashE.ResumeLayout(False)
        Me.pnlTotalCashE.PerformLayout()
        Me.pnlTotalMoney.ResumeLayout(False)
        Me.pnlTotalMoney.PerformLayout()
        Me.tpLog.ResumeLayout(False)
        Me.tpLog.PerformLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpUsers.ResumeLayout(False)
        Me.grpAddUser.ResumeLayout(False)
        Me.grpAddUser.PerformLayout()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        CType(Me.epMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
