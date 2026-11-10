Imports System.Windows.Forms

' =====================================================================
'  FloatWise - start-up code.
'  Shows the login screen, then the main screen. When a user clicks
'  "Log out" the login screen comes back (data stays in memory).
' =====================================================================
Module Program

    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Database.InitDatabase()
        AuthStore.LoadUsers()
        Ledger.LoadFromDb()

        Do
            Dim user As UserSession = Nothing
            Using login As New frmLogin()
                If login.ShowDialog() <> DialogResult.OK Then Exit Do
                user = login.Result
            End Using

            Dim again As Boolean = False
            Using mainForm As New frmMain(user)
                Application.Run(mainForm)
                again = mainForm.LoggedOut
            End Using
            If Not again Then Exit Do
        Loop
    End Sub

End Module
