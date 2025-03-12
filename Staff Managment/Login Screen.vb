Imports Staff_Managment.FileIO_APP

Public Class Login_Screen
    Public masterKey As String

    Private Sub Login_Screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Form1.Hide()
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Ensure user database exists on first startup
        EnsureUserDatabaseExists()
    End Sub

    Private Sub but_login_Click(sender As Object, e As EventArgs) Handles but_login.Click
        If txt_username.Text.Trim() = "" Or txt_password.Text.Trim() = "" Then
            MessageBox.Show("Missing Fields.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim username As String = txt_username.Text.Trim()
        Dim password As String = txt_password.Text.Trim()

        ' Retrieve encrypted master key for the username
        Dim encryptedMasterKey As String = UserManager.GetEncryptedMasterKey(username)

        If encryptedMasterKey Is Nothing Then
            MessageBox.Show("User not found!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Attempt to decrypt the master key with the provided password
            masterKey = PasswordSecurity.DecryptMasterKey(encryptedMasterKey, password)
            'MessageBox.Show("Master Key: " + masterKey)

            ' If decryption fails (wrong password or corruption), return an error
            If String.IsNullOrEmpty(masterKey) Then
                MessageBox.Show("Incorrect password or corrupted data!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Use masterKey to unlock the database (in this example, decrypting a file)
            Dim decryptedData As String = ReadFileStartUp(Application.StartupPath + "data_encr.txt", masterKey)
            'MessageBox.Show("Decripted Data: " + decryptedData)
            If decryptedData = "CORRUPT" Then
                MessageBox.Show("Database file is corrupted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'MessageBox.Show("Decrypted: " & decryptedData, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Open the main application window
            Form1.Show()
            Me.Hide()
            Form1.Activate()

        Catch ex As Exception
            MessageBox.Show("Decryption failed: Incorrect username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 🟢 Function to Read & Decrypt a File Using the Master Key

End Class
