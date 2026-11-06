Imports System.Drawing
Imports System.Windows.Forms

' =====================================================================
'  frmLogin - separate sign-in for ADMIN and WORKER.
'  * First time the app runs there is no admin, so the admin
'    creates the first admin account (sign-up).
'  * After that, only an admin can create workers (Users tab).
'  * 5 wrong passwords = locked for 30 seconds.
' =====================================================================
Partial Public Class frmLogin
    Inherits System.Windows.Forms.Form

    Public Property Result As UserSession

    Private Function IsDesignMode() As Boolean
        Return Me.DesignMode OrElse
               System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime OrElse
               System.Diagnostics.Process.GetCurrentProcess().ProcessName.IndexOf("devenv", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Public Sub New()
        InitializeComponent()

        If IsDesignMode() Then
            pnlAdmin.Visible = True
            pnlWorker.Visible = False
            pnlSignup.Visible = False
            Return
        End If

        lnkFirstTime.Visible = Not AuthStore.AdminExists()

        AddHandler chkAdminPass.CheckedChanged, Sub(s, e) txtAdminPass.UseSystemPasswordChar = Not chkAdminPass.Checked
        AddHandler chkWorkerPass.CheckedChanged, Sub(s, e) txtWorkerPass.UseSystemPasswordChar = Not chkWorkerPass.Checked
        AddHandler lnkFirstTime.LinkClicked, Sub(s, e) ShowPanel("signup")

        AddHandler btnTabAdmin.Click, Sub(s As Object, e As EventArgs) ShowPanel(If(AuthStore.AdminExists(), "admin", "signup"))
        AddHandler btnTabWorker.Click, Sub(s As Object, e As EventArgs) ShowPanel("worker")
        AddHandler btnAdminLogin.Click, Sub(s As Object, e As EventArgs) DoLogin(txtAdminUser, txtAdminPass, "Admin", lblAdminMsg)
        AddHandler btnWorkerLogin.Click, Sub(s As Object, e As EventArgs) DoLogin(txtWorkerUser, txtWorkerPass, "Worker", lblWorkerMsg)
        AddHandler btnSignup.Click, AddressOf btnSignup_Click

        ShowPanel(If(AuthStore.AdminExists(), "admin", "signup"))
    End Sub

    Private Sub ShowPanel(which As String)
        pnlAdmin.Visible = (which = "admin")
        pnlWorker.Visible = (which = "worker")
        pnlSignup.Visible = (which = "signup")

        ' highlight the active switch, fade the other one
        btnTabAdmin.BackColor = If(which = "worker", ControlPaint.Light(AdminPurple, 0.55F), AdminPurple)
        btnTabWorker.BackColor = If(which = "worker", WorkerTeal, ControlPaint.Light(WorkerTeal, 0.55F))

        Select Case which
            Case "admin"
                Me.AcceptButton = btnAdminLogin
                txtAdminUser.Focus()
            Case "worker"
                Me.AcceptButton = btnWorkerLogin
                txtWorkerUser.Focus()
            Case Else
                Me.AcceptButton = btnSignup
                txtSuName.Focus()
        End Select
    End Sub

    ' ---------- sign in ----------
    Private Sub DoLogin(userBox As TextBox, passBox As TextBox, role As String, msg As Label)
        msg.Text = ""
        If Date.Now < LockedUntil Then
            Dim s As Integer = Math.Max(1, CInt((LockedUntil - Date.Now).TotalSeconds))
            msg.Text = "Too many wrong passwords. Wait " & s & " seconds."
            Return
        End If

        Dim u As UserAccount = Authenticate(userBox.Text.Trim(), passBox.Text, role)
        If u Is Nothing Then
            FailedAttempts += 1
            If FailedAttempts >= 5 Then
                LockedUntil = Date.Now.AddSeconds(30)
                msg.Text = "Wrong password. Locked for 30 seconds."
            Else
                Dim left As Integer = 5 - FailedAttempts
                msg.Text = "Wrong username or password (" & left & " attempts left)."
            End If
            passBox.Clear()
            passBox.Focus()
            Return
        End If

        FailedAttempts = 0
        Result = New UserSession With {.Username = u.Username, .FullName = u.FullName, .Role = u.Role}
        Me.DialogResult = DialogResult.OK
    End Sub

    ' ---------- first-time admin sign-up ----------
    Private Sub btnSignup_Click(sender As Object, e As EventArgs)
        lblSuMsg.Text = ""
        If AuthStore.AdminExists() Then
            lblSuMsg.Text = "An admin already exists. Ask the admin to create your account."
            Return
        End If
        Dim problem As String = CreateUser(txtSuName.Text, txtSuUser.Text, txtSuPass.Text, txtSuConfirm.Text, "Admin")
        If problem <> "" Then
            lblSuMsg.Text = problem
            Return
        End If
        MessageBox.Show("Admin account created. Please sign in.", "FloatWise", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtAdminUser.Text = txtSuUser.Text.Trim()
        txtSuPass.Clear()
        txtSuConfirm.Clear()
        ShowPanel("admin")
        txtAdminPass.Focus()
    End Sub

End Class
