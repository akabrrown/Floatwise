<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSub As System.Windows.Forms.Label
    Friend WithEvents btnTabAdmin As System.Windows.Forms.Button
    Friend WithEvents btnTabWorker As System.Windows.Forms.Button
    Friend WithEvents pnlAdmin As System.Windows.Forms.Panel
    Friend WithEvents lblAdminUser As System.Windows.Forms.Label
    Friend WithEvents txtAdminUser As System.Windows.Forms.TextBox
    Friend WithEvents lblAdminPass As System.Windows.Forms.Label
    Friend WithEvents txtAdminPass As System.Windows.Forms.TextBox
    Friend WithEvents chkAdminPass As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdminLogin As System.Windows.Forms.Button
    Friend WithEvents lblAdminMsg As System.Windows.Forms.Label
    Friend WithEvents lnkFirstTime As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlWorker As System.Windows.Forms.Panel
    Friend WithEvents lblWorkerUser As System.Windows.Forms.Label
    Friend WithEvents txtWorkerUser As System.Windows.Forms.TextBox
    Friend WithEvents lblWorkerPass As System.Windows.Forms.Label
    Friend WithEvents txtWorkerPass As System.Windows.Forms.TextBox
    Friend WithEvents chkWorkerPass As System.Windows.Forms.CheckBox
    Friend WithEvents btnWorkerLogin As System.Windows.Forms.Button
    Friend WithEvents lblWorkerMsg As System.Windows.Forms.Label
    Friend WithEvents lblWorkerNote As System.Windows.Forms.Label
    Friend WithEvents pnlSignup As System.Windows.Forms.Panel
    Friend WithEvents lblSignupTitle As System.Windows.Forms.Label
    Friend WithEvents lblSuName As System.Windows.Forms.Label
    Friend WithEvents txtSuName As System.Windows.Forms.TextBox
    Friend WithEvents lblSuUser As System.Windows.Forms.Label
    Friend WithEvents txtSuUser As System.Windows.Forms.TextBox
    Friend WithEvents lblSuPass As System.Windows.Forms.Label
    Friend WithEvents txtSuPass As System.Windows.Forms.TextBox
    Friend WithEvents lblSuConfirm As System.Windows.Forms.Label
    Friend WithEvents txtSuConfirm As System.Windows.Forms.TextBox
    Friend WithEvents btnSignup As System.Windows.Forms.Button
    Friend WithEvents lblSuMsg As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSub = New System.Windows.Forms.Label()
        Me.btnTabAdmin = New System.Windows.Forms.Button()
        Me.btnTabWorker = New System.Windows.Forms.Button()
        Me.pnlAdmin = New System.Windows.Forms.Panel()
        Me.lblAdminUser = New System.Windows.Forms.Label()
        Me.txtAdminUser = New System.Windows.Forms.TextBox()
        Me.lblAdminPass = New System.Windows.Forms.Label()
        Me.txtAdminPass = New System.Windows.Forms.TextBox()
        Me.chkAdminPass = New System.Windows.Forms.CheckBox()
        Me.btnAdminLogin = New System.Windows.Forms.Button()
        Me.lblAdminMsg = New System.Windows.Forms.Label()
        Me.lnkFirstTime = New System.Windows.Forms.LinkLabel()
        Me.pnlWorker = New System.Windows.Forms.Panel()
        Me.lblWorkerUser = New System.Windows.Forms.Label()
        Me.txtWorkerUser = New System.Windows.Forms.TextBox()
        Me.lblWorkerPass = New System.Windows.Forms.Label()
        Me.txtWorkerPass = New System.Windows.Forms.TextBox()
        Me.chkWorkerPass = New System.Windows.Forms.CheckBox()
        Me.btnWorkerLogin = New System.Windows.Forms.Button()
        Me.lblWorkerMsg = New System.Windows.Forms.Label()
        Me.lblWorkerNote = New System.Windows.Forms.Label()
        Me.pnlSignup = New System.Windows.Forms.Panel()
        Me.lblSignupTitle = New System.Windows.Forms.Label()
        Me.lblSuName = New System.Windows.Forms.Label()
        Me.txtSuName = New System.Windows.Forms.TextBox()
        Me.lblSuUser = New System.Windows.Forms.Label()
        Me.txtSuUser = New System.Windows.Forms.TextBox()
        Me.lblSuPass = New System.Windows.Forms.Label()
        Me.txtSuPass = New System.Windows.Forms.TextBox()
        Me.lblSuConfirm = New System.Windows.Forms.Label()
        Me.txtSuConfirm = New System.Windows.Forms.TextBox()
        Me.btnSignup = New System.Windows.Forms.Button()
        Me.lblSuMsg = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAdmin.SuspendLayout()
        Me.pnlWorker.SuspendLayout()
        Me.pnlSignup.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 101, 52)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.lblSub)
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(480, 100)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(24, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(182, 47)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "FloatWise"
        '
        'lblSub
        '
        Me.lblSub.AutoSize = True
        Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(205, 232, 216)
        Me.lblSub.Location = New System.Drawing.Point(27, 62)
        Me.lblSub.Name = "lblSub"
        Me.lblSub.Size = New System.Drawing.Size(161, 20)
        Me.lblSub.TabIndex = 1
        Me.lblSub.Text = "MoMo Agent Manager"
        '
        'btnTabAdmin
        '
        Me.btnTabAdmin.BackColor = System.Drawing.Color.FromArgb(109, 40, 217)
        Me.btnTabAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTabAdmin.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnTabAdmin.ForeColor = System.Drawing.Color.White
        Me.btnTabAdmin.Location = New System.Drawing.Point(20, 114)
        Me.btnTabAdmin.Name = "btnTabAdmin"
        Me.btnTabAdmin.Size = New System.Drawing.Size(215, 42)
        Me.btnTabAdmin.TabIndex = 1
        Me.btnTabAdmin.Text = "Admin"
        Me.btnTabAdmin.UseVisualStyleBackColor = False
        '
        'btnTabWorker
        '
        Me.btnTabWorker.BackColor = System.Drawing.Color.FromArgb(15, 118, 110)
        Me.btnTabWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTabWorker.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnTabWorker.ForeColor = System.Drawing.Color.White
        Me.btnTabWorker.Location = New System.Drawing.Point(245, 114)
        Me.btnTabWorker.Name = "btnTabWorker"
        Me.btnTabWorker.Size = New System.Drawing.Size(215, 42)
        Me.btnTabWorker.TabIndex = 2
        Me.btnTabWorker.Text = "Worker"
        Me.btnTabWorker.UseVisualStyleBackColor = False
        '
        'pnlAdmin
        '
        Me.pnlAdmin.BackColor = System.Drawing.Color.White
        Me.pnlAdmin.Controls.Add(Me.lblAdminUser)
        Me.pnlAdmin.Controls.Add(Me.txtAdminUser)
        Me.pnlAdmin.Controls.Add(Me.lblAdminPass)
        Me.pnlAdmin.Controls.Add(Me.txtAdminPass)
        Me.pnlAdmin.Controls.Add(Me.chkAdminPass)
        Me.pnlAdmin.Controls.Add(Me.btnAdminLogin)
        Me.pnlAdmin.Controls.Add(Me.lblAdminMsg)
        Me.pnlAdmin.Controls.Add(Me.lnkFirstTime)
        Me.pnlAdmin.Location = New System.Drawing.Point(20, 168)
        Me.pnlAdmin.Name = "pnlAdmin"
        Me.pnlAdmin.Size = New System.Drawing.Size(440, 420)
        Me.pnlAdmin.TabIndex = 3
        '
        'lblAdminUser
        '
        Me.lblAdminUser.AutoSize = True
        Me.lblAdminUser.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblAdminUser.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.lblAdminUser.Location = New System.Drawing.Point(20, 20)
        Me.lblAdminUser.Name = "lblAdminUser"
        Me.lblAdminUser.Size = New System.Drawing.Size(121, 19)
        Me.lblAdminUser.TabIndex = 0
        Me.lblAdminUser.Text = "Admin username"
        '
        'txtAdminUser
        '
        Me.txtAdminUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdminUser.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtAdminUser.Location = New System.Drawing.Point(20, 46)
        Me.txtAdminUser.Name = "txtAdminUser"
        Me.txtAdminUser.Size = New System.Drawing.Size(400, 27)
        Me.txtAdminUser.TabIndex = 1
        '
        'lblAdminPass
        '
        Me.lblAdminPass.AutoSize = True
        Me.lblAdminPass.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblAdminPass.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.lblAdminPass.Location = New System.Drawing.Point(20, 92)
        Me.lblAdminPass.Name = "lblAdminPass"
        Me.lblAdminPass.Size = New System.Drawing.Size(73, 19)
        Me.lblAdminPass.TabIndex = 2
        Me.lblAdminPass.Text = "Password"
        '
        'txtAdminPass
        '
        Me.txtAdminPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdminPass.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtAdminPass.Location = New System.Drawing.Point(20, 118)
        Me.txtAdminPass.Name = "txtAdminPass"
        Me.txtAdminPass.Size = New System.Drawing.Size(400, 27)
        Me.txtAdminPass.TabIndex = 3
        Me.txtAdminPass.UseSystemPasswordChar = True
        '
        'chkAdminPass
        '
        Me.chkAdminPass.AutoSize = True
        Me.chkAdminPass.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.chkAdminPass.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.chkAdminPass.Location = New System.Drawing.Point(20, 156)
        Me.chkAdminPass.Name = "chkAdminPass"
        Me.chkAdminPass.Size = New System.Drawing.Size(118, 21)
        Me.chkAdminPass.TabIndex = 4
        Me.chkAdminPass.Text = "Show password"
        Me.chkAdminPass.UseVisualStyleBackColor = True
        '
        'btnAdminLogin
        '
        Me.btnAdminLogin.BackColor = System.Drawing.Color.FromArgb(109, 40, 217)
        Me.btnAdminLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdminLogin.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdminLogin.ForeColor = System.Drawing.Color.White
        Me.btnAdminLogin.Location = New System.Drawing.Point(20, 196)
        Me.btnAdminLogin.Name = "btnAdminLogin"
        Me.btnAdminLogin.Size = New System.Drawing.Size(400, 46)
        Me.btnAdminLogin.TabIndex = 5
        Me.btnAdminLogin.Text = "Sign in as Admin"
        Me.btnAdminLogin.UseVisualStyleBackColor = False
        '
        'lblAdminMsg
        '
        Me.lblAdminMsg.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblAdminMsg.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12)
        Me.lblAdminMsg.Location = New System.Drawing.Point(20, 252)
        Me.lblAdminMsg.Name = "lblAdminMsg"
        Me.lblAdminMsg.Size = New System.Drawing.Size(400, 40)
        Me.lblAdminMsg.TabIndex = 6
        '
        'lnkFirstTime
        '
        Me.lnkFirstTime.AutoSize = True
        Me.lnkFirstTime.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lnkFirstTime.LinkColor = System.Drawing.Color.FromArgb(109, 40, 217)
        Me.lnkFirstTime.Location = New System.Drawing.Point(20, 300)
        Me.lnkFirstTime.Name = "lnkFirstTime"
        Me.lnkFirstTime.Size = New System.Drawing.Size(227, 19)
        Me.lnkFirstTime.TabIndex = 7
        Me.lnkFirstTime.TabStop = True
        Me.lnkFirstTime.Text = "First time? Create the admin account"
        '
        'pnlWorker
        '
        Me.pnlWorker.BackColor = System.Drawing.Color.White
        Me.pnlWorker.Controls.Add(Me.lblWorkerUser)
        Me.pnlWorker.Controls.Add(Me.txtWorkerUser)
        Me.pnlWorker.Controls.Add(Me.lblWorkerPass)
        Me.pnlWorker.Controls.Add(Me.txtWorkerPass)
        Me.pnlWorker.Controls.Add(Me.chkWorkerPass)
        Me.pnlWorker.Controls.Add(Me.btnWorkerLogin)
        Me.pnlWorker.Controls.Add(Me.lblWorkerMsg)
        Me.pnlWorker.Controls.Add(Me.lblWorkerNote)
        Me.pnlWorker.Location = New System.Drawing.Point(20, 168)
        Me.pnlWorker.Name = "pnlWorker"
        Me.pnlWorker.Size = New System.Drawing.Size(440, 420)
        Me.pnlWorker.TabIndex = 4
        Me.pnlWorker.Visible = False
        '
        'lblWorkerUser
        '
        Me.lblWorkerUser.AutoSize = True
        Me.lblWorkerUser.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblWorkerUser.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.lblWorkerUser.Location = New System.Drawing.Point(20, 20)
        Me.lblWorkerUser.Name = "lblWorkerUser"
        Me.lblWorkerUser.Size = New System.Drawing.Size(126, 19)
        Me.lblWorkerUser.TabIndex = 0
        Me.lblWorkerUser.Text = "Worker username"
        '
        'txtWorkerUser
        '
        Me.txtWorkerUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkerUser.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtWorkerUser.Location = New System.Drawing.Point(20, 46)
        Me.txtWorkerUser.Name = "txtWorkerUser"
        Me.txtWorkerUser.Size = New System.Drawing.Size(400, 27)
        Me.txtWorkerUser.TabIndex = 1
        '
        'lblWorkerPass
        '
        Me.lblWorkerPass.AutoSize = True
        Me.lblWorkerPass.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblWorkerPass.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.lblWorkerPass.Location = New System.Drawing.Point(20, 92)
        Me.lblWorkerPass.Name = "lblWorkerPass"
        Me.lblWorkerPass.Size = New System.Drawing.Size(73, 19)
        Me.lblWorkerPass.TabIndex = 2
        Me.lblWorkerPass.Text = "Password"
        '
        'txtWorkerPass
        '
        Me.txtWorkerPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkerPass.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtWorkerPass.Location = New System.Drawing.Point(20, 118)
        Me.txtWorkerPass.Name = "txtWorkerPass"
        Me.txtWorkerPass.Size = New System.Drawing.Size(400, 27)
        Me.txtWorkerPass.TabIndex = 3
        Me.txtWorkerPass.UseSystemPasswordChar = True
        '
        'chkWorkerPass
        '
        Me.chkWorkerPass.AutoSize = True
        Me.chkWorkerPass.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.chkWorkerPass.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.chkWorkerPass.Location = New System.Drawing.Point(20, 156)
        Me.chkWorkerPass.Name = "chkWorkerPass"
        Me.chkWorkerPass.Size = New System.Drawing.Size(118, 21)
        Me.chkWorkerPass.TabIndex = 4
        Me.chkWorkerPass.Text = "Show password"
        Me.chkWorkerPass.UseVisualStyleBackColor = True
        '
        'btnWorkerLogin
        '
        Me.btnWorkerLogin.BackColor = System.Drawing.Color.FromArgb(15, 118, 110)
        Me.btnWorkerLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkerLogin.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnWorkerLogin.ForeColor = System.Drawing.Color.White
        Me.btnWorkerLogin.Location = New System.Drawing.Point(20, 196)
        Me.btnWorkerLogin.Name = "btnWorkerLogin"
        Me.btnWorkerLogin.Size = New System.Drawing.Size(400, 46)
        Me.btnWorkerLogin.TabIndex = 5
        Me.btnWorkerLogin.Text = "Sign in as Worker"
        Me.btnWorkerLogin.UseVisualStyleBackColor = False
        '
        'lblWorkerMsg
        '
        Me.lblWorkerMsg.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblWorkerMsg.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12)
        Me.lblWorkerMsg.Location = New System.Drawing.Point(20, 252)
        Me.lblWorkerMsg.Name = "lblWorkerMsg"
        Me.lblWorkerMsg.Size = New System.Drawing.Size(400, 40)
        Me.lblWorkerMsg.TabIndex = 6
        '
        'lblWorkerNote
        '
        Me.lblWorkerNote.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblWorkerNote.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblWorkerNote.Location = New System.Drawing.Point(20, 300)
        Me.lblWorkerNote.Name = "lblWorkerNote"
        Me.lblWorkerNote.Size = New System.Drawing.Size(400, 45)
        Me.lblWorkerNote.TabIndex = 7
        Me.lblWorkerNote.Text = "Workers cannot register themselves. Ask your admin to create your account."
        '
        'pnlSignup
        '
        Me.pnlSignup.BackColor = System.Drawing.Color.White
        Me.pnlSignup.Controls.Add(Me.lblSignupTitle)
        Me.pnlSignup.Controls.Add(Me.lblSuName)
        Me.pnlSignup.Controls.Add(Me.txtSuName)
        Me.pnlSignup.Controls.Add(Me.lblSuUser)
        Me.pnlSignup.Controls.Add(Me.txtSuUser)
        Me.pnlSignup.Controls.Add(Me.lblSuPass)
        Me.pnlSignup.Controls.Add(Me.txtSuPass)
        Me.pnlSignup.Controls.Add(Me.lblSuConfirm)
        Me.pnlSignup.Controls.Add(Me.txtSuConfirm)
        Me.pnlSignup.Controls.Add(Me.btnSignup)
        Me.pnlSignup.Controls.Add(Me.lblSuMsg)
        Me.pnlSignup.Location = New System.Drawing.Point(20, 168)
        Me.pnlSignup.Name = "pnlSignup"
        Me.pnlSignup.Size = New System.Drawing.Size(440, 420)
        Me.pnlSignup.TabIndex = 5
        Me.pnlSignup.Visible = False
        '
        'lblSignupTitle
        '
        Me.lblSignupTitle.AutoSize = True
        Me.lblSignupTitle.Font = New System.Drawing.Font("Segoe UI", 12.5!, System.Drawing.FontStyle.Bold)
        Me.lblSignupTitle.ForeColor = System.Drawing.Color.FromArgb(109, 40, 217)
        Me.lblSignupTitle.Location = New System.Drawing.Point(20, 8)
        Me.lblSignupTitle.Name = "lblSignupTitle"
        Me.lblSignupTitle.Size = New System.Drawing.Size(222, 23)
        Me.lblSignupTitle.TabIndex = 0
        Me.lblSignupTitle.Text = "Create the admin account"
        '
        'lblSuName
        '
        Me.lblSuName.AutoSize = True
        Me.lblSuName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSuName.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.lblSuName.Location = New System.Drawing.Point(20, 42)
        Me.lblSuName.Name = "lblSuName"
        Me.lblSuName.Size = New System.Drawing.Size(73, 19)
        Me.lblSuName.TabIndex = 1
        Me.lblSuName.Text = "Full name"
        '
        'txtSuName
        '
        Me.txtSuName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtSuName.Location = New System.Drawing.Point(20, 64)
        Me.txtSuName.Name = "txtSuName"
        Me.txtSuName.Size = New System.Drawing.Size(400, 27)
        Me.txtSuName.TabIndex = 2
        '
        'lblSuUser
        '
        Me.lblSuUser.AutoSize = True
        Me.lblSuUser.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSuUser.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.lblSuUser.Location = New System.Drawing.Point(20, 102)
        Me.lblSuUser.Name = "lblSuUser"
        Me.lblSuUser.Size = New System.Drawing.Size(209, 19)
        Me.lblSuUser.TabIndex = 3
        Me.lblSuUser.Text = "Username (letters, numbers, _)"
        '
        'txtSuUser
        '
        Me.txtSuUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuUser.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtSuUser.Location = New System.Drawing.Point(20, 124)
        Me.txtSuUser.Name = "txtSuUser"
        Me.txtSuUser.Size = New System.Drawing.Size(400, 27)
        Me.txtSuUser.TabIndex = 4
        '
        'lblSuPass
        '
        Me.lblSuPass.AutoSize = True
        Me.lblSuPass.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSuPass.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.lblSuPass.Location = New System.Drawing.Point(20, 162)
        Me.lblSuPass.Name = "lblSuPass"
        Me.lblSuPass.Size = New System.Drawing.Size(326, 19)
        Me.lblSuPass.TabIndex = 5
        Me.lblSuPass.Text = "Password (6+ characters, a letter and a number)"
        '
        'txtSuPass
        '
        Me.txtSuPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuPass.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtSuPass.Location = New System.Drawing.Point(20, 184)
        Me.txtSuPass.Name = "txtSuPass"
        Me.txtSuPass.Size = New System.Drawing.Size(400, 27)
        Me.txtSuPass.TabIndex = 6
        Me.txtSuPass.UseSystemPasswordChar = True
        '
        'lblSuConfirm
        '
        Me.lblSuConfirm.AutoSize = True
        Me.lblSuConfirm.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSuConfirm.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.lblSuConfirm.Location = New System.Drawing.Point(20, 222)
        Me.lblSuConfirm.Name = "lblSuConfirm"
        Me.lblSuConfirm.Size = New System.Drawing.Size(129, 19)
        Me.lblSuConfirm.TabIndex = 7
        Me.lblSuConfirm.Text = "Confirm password"
        '
        'txtSuConfirm
        '
        Me.txtSuConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuConfirm.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtSuConfirm.Location = New System.Drawing.Point(20, 244)
        Me.txtSuConfirm.Name = "txtSuConfirm"
        Me.txtSuConfirm.Size = New System.Drawing.Size(400, 27)
        Me.txtSuConfirm.TabIndex = 8
        Me.txtSuConfirm.UseSystemPasswordChar = True
        '
        'btnSignup
        '
        Me.btnSignup.BackColor = System.Drawing.Color.FromArgb(109, 40, 217)
        Me.btnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSignup.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSignup.ForeColor = System.Drawing.Color.White
        Me.btnSignup.Location = New System.Drawing.Point(20, 292)
        Me.btnSignup.Name = "btnSignup"
        Me.btnSignup.Size = New System.Drawing.Size(400, 46)
        Me.btnSignup.TabIndex = 9
        Me.btnSignup.Text = "Create admin account"
        Me.btnSignup.UseVisualStyleBackColor = False
        '
        'lblSuMsg
        '
        Me.lblSuMsg.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSuMsg.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12)
        Me.lblSuMsg.Location = New System.Drawing.Point(20, 348)
        Me.lblSuMsg.Name = "lblSuMsg"
        Me.lblSuMsg.Size = New System.Drawing.Size(400, 50)
        Me.lblSuMsg.TabIndex = 10
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(243, 244, 246)
        Me.ClientSize = New System.Drawing.Size(480, 610)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.btnTabAdmin)
        Me.Controls.Add(Me.btnTabWorker)
        Me.Controls.Add(Me.pnlAdmin)
        Me.Controls.Add(Me.pnlWorker)
        Me.Controls.Add(Me.pnlSignup)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FloatWise - Sign in"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlAdmin.ResumeLayout(False)
        Me.pnlAdmin.PerformLayout()
        Me.pnlWorker.ResumeLayout(False)
        Me.pnlWorker.PerformLayout()
        Me.pnlSignup.ResumeLayout(False)
        Me.pnlSignup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
