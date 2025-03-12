Public Class FileIO_APP

    ' Shared function to read a file (supports plain text, XML, and encrypted files)

    ' Subroutine: ReadFile
    ' Inputs: filePath As String     Optional encryptionKey As String
    ' Returns: None
    '
    ' Environmental Effect:
    ' Calls Seprate functions based on file extension to handle seprate file types
    Public Shared Sub ReadFile(filePath As String, Optional encryptionKey As String = Nothing)
        Try
            If Not IO.File.Exists(filePath) Then
                MessageBox.Show("File not found: " & filePath)
                Return
            End If

            Dim fileExtension As String = IO.Path.GetExtension(filePath).ToLower()

            Select Case fileExtension
                Case ".txt"
                    ReadTextFile(filePath)
                Case ".xml"
                    ReadXmlFile(filePath)
                Case ".encr"
                    If encryptionKey IsNot Nothing Then
                        ReadEncryptedFile(filePath, encryptionKey)
                    Else
                        MessageBox.Show("Encryption key required to read this file.")
                    End If
                Case Else
                    MessageBox.Show("Invalid file format. Please use .txt, .xml, or .encr not: " & fileExtension)
            End Select

        Catch ex As Exception
            MessageBox.Show("Error reading file: " & ex.Message)
        End Try
    End Sub

    ' Subroutine: WriteFile
    ' Inputs: filePath As String     Optional encryptionKey As String
    ' Returns: None
    '
    ' Environmental Effect:
    ' Creates tempory file a lagging backup of the database
    ' Calls seprate functions based on file extension
    ' Validate Temp file beofre replacing original
    Public Shared Sub WriteFile(filePath As String, Optional encryptionKey As String = Nothing)
        Try
            Dim fileExtension As String = IO.Path.GetExtension(filePath).ToLower()
            Dim tempFilePath As String = filePath & ".tmp"
            Dim backupFilePath As String = filePath & ".bak"

            ' Backup old file before writing (lagging backup)
            If IO.File.Exists(filePath) Then
                IO.File.Copy(filePath, backupFilePath, True)
            End If

            ' Write to a temporary file first
            Select Case fileExtension
                Case ".txt"
                    WriteTextFile(tempFilePath)
                Case ".xml"
                    WriteXmlFile(tempFilePath)
                Case ".encr"
                    If encryptionKey IsNot Nothing Then
                        WriteEncryptedFile(tempFilePath, encryptionKey)
                    Else
                        MessageBox.Show("Encryption key required to write this file.")
                        Return
                    End If
                Case Else
                    MessageBox.Show("Invalid file format. Please use .txt, .xml, or .encr not: " & fileExtension)
                    Return
            End Select

            ' Validate non-empty temp file before replacing original
            If IO.File.Exists(tempFilePath) AndAlso New IO.FileInfo(tempFilePath).Length > 0 Then
                IO.File.Copy(tempFilePath, filePath, True)
                IO.File.Delete(tempFilePath) ' Clean up temporary file
            Else
                MessageBox.Show("Write operation aborted: Temporary file is empty.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error writing to file: " & ex.Message)
        End Try
    End Sub

    ' Subroutine: ReadTextFile
    ' Inputs: filePath As String
    ' Returns: None
    '
    ' Environmental Effect:
    ' Reads File from path and calls function to proccess data to fill the master list
    ' then calls function to refresh menus.
    Private Shared Sub ReadTextFile(filePath As String)
        Using sr As New IO.StreamReader(filePath)
            While Not sr.EndOfStream
                ProcessStaffData(sr.ReadLine())
            End While
        End Using
        Form1.UpdateStaffList()
    End Sub

    ' Subroutine: ReadEncryptedFile
    ' Inputs: filePath As String     Optional encryptionKey As String
    ' Returns: None
    '
    ' Environmental Effect:
    ' Reads File from path and calls function to proccess data to fill the master list
    ' then calls function to refresh menus.ff
    Private Shared Sub ReadEncryptedFile(filePath As String, encryptionKey As String)
        Dim encryptedLines As String() = IO.File.ReadAllLines(filePath)
        Form1.staff_list.Clear()

        For Each line In encryptedLines
            Dim decryptedText As String = PasswordSecurity.DecryptBase64ToString(line, encryptionKey)
            ProcessStaffData(decryptedText)
        Next

        Form1.UpdateStaffList()
    End Sub

    ' Reads an XML file (not processed, just displays for now)
    Private Shared Sub ReadXmlFile(filePath As String)
        Try
            Dim xdoc As XDocument = XDocument.Load(filePath)
            ' You may need to process this XML to populate staff_list if required
        Catch ex As Exception
            MessageBox.Show("Error reading XML file: " & ex.Message)
        End Try
    End Sub

    ' Writes a plain text file with staff data
    Private Shared Sub WriteTextFile(filePath As String)
        Using sw As New IO.StreamWriter(filePath, False)
            For Each staff In Form1.staff_list
                sw.WriteLine(FormatStaffData(staff))
            Next
        End Using
    End Sub

    ' Writes an encrypted file with staff data
    Private Shared Sub WriteEncryptedFile(filePath As String, encryptionKey As String)
        Dim encryptedLines As New List(Of String)

        For Each staff In Form1.staff_list
            Dim encryptedData As String = PasswordSecurity.EncryptStringToBase64(FormatStaffData(staff), encryptionKey)
            encryptedLines.Add(encryptedData)
        Next

        IO.File.WriteAllLines(filePath, encryptedLines)
    End Sub

    ' Writes an XML file with staff data
    Private Shared Sub WriteXmlFile(filePath As String)
        Try
            Dim xdoc As New XDocument(
                New XElement("StaffList",
                    From staff In Form1.staff_list
                    Select New XElement("Staff",
                        New XElement("Staff_ID", staff.Staff_ID),
                        New XElement("FirstName", staff.FirstName),
                        New XElement("Surname", staff.Surname),
                        New XElement("Gender", staff.Gender),
                        New XElement("DOB", staff.DOB),
                        New XElement("Admin", If(staff.Admin, "Yes", "No")),
                        New XElement("Skill1", staff.Skill1),
                        New XElement("Skill2", staff.Skill2),
                        New XElement("Skill3", staff.Skill3),
                        New XElement("Skill4", staff.Skill4),
                        New XElement("Skill5", staff.Skill5),
                        New XElement("Skill6", staff.Skill6),
                        New XElement("Pay", staff.Pay),
                        New XElement("Password", staff.Password)
                    )
                )
            )
            xdoc.Save(filePath)
        Catch ex As Exception
            MessageBox.Show("Error writing XML file: " & ex.Message)
        End Try
    End Sub

    ' Helper function to process a single line of staff data
    Private Shared Sub ProcessStaffData(data As String)
        Dim result As String() = data.Split("|")
        If result.Length = 14 Then
            Dim newline As New Staff_class With {
                .Staff_ID = result(0),
                .FirstName = result(1),
                .Surname = result(2),
                .Gender = result(3),
                .DOB = result(4),
                .Admin = (result(5).Trim().ToLower() = "yes"),
                .Skill1 = result(6),
                .Skill2 = result(7),
                .Skill3 = result(8),
                .Skill4 = result(9),
                .Skill5 = result(10),
                .Skill6 = result(11),
                .Pay = result(12),
                .Password = result(13)
            }
            Form1.staff_list.Add(newline)
        Else
            Console.WriteLine("Invalid line format: " & data)
        End If
    End Sub

    ' Helper function to format a staff object as a string for saving
    Private Shared Function FormatStaffData(staff As Staff_class) As String
        Return $"{staff.Staff_ID}|{staff.FirstName}|{staff.Surname}|{staff.Gender}|{staff.DOB}|" &
               $"{If(staff.Admin, "Yes", "No")}|{staff.Skill1}|{staff.Skill2}|{staff.Skill3}|{staff.Skill4}|" &
               $"{staff.Skill5}|{staff.Skill6}|{staff.Pay}|{staff.Password}"
    End Function






    Shared Function ReadFileStartUp(path As String, masterKey As String) As String
        Try
            ' If file does not exist, create it with default encrypted data
            If Not IO.File.Exists(path) Then
                Dim defaultData As String = "-1|Admin|Admin|None|22/03/1985 12:00:00 AM|Yes||||||||"
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
    Shared Sub EnsureUserDatabaseExists()
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
