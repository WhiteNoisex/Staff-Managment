Public Class Login_Screen

    Private Sub Login_Screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Form1.Hide()
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub but_login_Click(sender As Object, e As EventArgs) Handles but_login.Click

        Form1.Show()
        Me.Hide()
        'Form1.Activate()
    End Sub
End Class