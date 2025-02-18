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
            Dim decryptedData As String = ReadFile(Application.StartupPath + "data_encr.txt", masterKey)
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
    Public Function ReadFile(path As String, masterKey As String) As String
        Try
            ' If file does not exist, create it with default encrypted data
            If Not IO.File.Exists(path) Then
                Dim defaultData As String = "2001|Liam|Peterson|Male|22/03/1985 12:00:00 AM|Yes|Software Engineering|Java|Python|C++|Algorithms|Databases|120000|"
                Dim encryptedData As String = PasswordSecurity.EncryptStringToBase64(defaultData, masterKey)
                IO.File.WriteAllText(path, encryptedData) ' Write single encrypted record
                Return defaultData
            End If

            ' Read all encrypted lines at once
            Dim encryptedLines As String() = IO.File.ReadAllLines(path)

            ' Validate file is not empty
            If encryptedLines.Length = 0 Then
                Return "CORRUPT"
            End If

            ' Initialize a list to store decrypted records
            Dim decryptedRecords As New List(Of String)

            ' Process each line separately
            For Each encryptedLine As String In encryptedLines
                ' Ignore empty lines
                If String.IsNullOrWhiteSpace(encryptedLine) Then Continue For

                ' Validate that the line is Base64-encoded before decryption
                Try
                    Dim testDecode As Byte() = Convert.FromBase64String(encryptedLine)
                Catch ex As FormatException
                    MessageBox.Show("Invalid Base64 format detected. Skipping corrupted line.")
                    Continue For ' Skip this line
                End Try

                ' Decrypt the line
                Dim decryptedText As String = PasswordSecurity.DecryptBase64ToString(encryptedLine, masterKey)

                ' Ensure decryption was successful
                If String.IsNullOrEmpty(decryptedText) OrElse decryptedText = "CORRUPT" Then
                    MessageBox.Show("Decryption failed for one line. Skipping.")
                    Continue For ' Skip invalid records
                End If

                ' Store valid decrypted data
                decryptedRecords.Add(decryptedText)
            Next

            ' If no valid records were found, return "CORRUPT"
            If decryptedRecords.Count = 0 Then
                Return "CORRUPT"
            End If

            ' Return all decrypted data as a single string (or modify this to return a structured format)
            Return String.Join(Environment.NewLine, decryptedRecords)

        Catch ex As Exception
            MessageBox.Show("Error in ReadFile: " & ex.Message)
            Return "CORRUPT"
        End Try
    End Function


    ' 🟢 Ensures that a default user exists when first starting the program
    Private Sub EnsureUserDatabaseExists()
        Dim userFilePath As String = Application.StartupPath + "\users.dat"

        If Not IO.File.Exists(userFilePath) Then
            ' Create a default admin user
            Dim defaultUsername As String = "Admin"
            Dim defaultPassword As String = "Admin123"

            ' Generate and store encrypted master key for the default user
            UserManager.AddUser(defaultUsername, defaultPassword)

            MessageBox.Show("First-time setup complete! Default user: Admin / Admin123", "Setup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
