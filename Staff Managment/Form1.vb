Imports System.IO
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Security.Cryptography
Imports System.Net.NetworkInformation

Imports System

Public Class Form1
    Public staff_list As New List(Of Staff_class)
    Dim mod_mode As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show(Login_Screen.masterKey)
        ReadFile(Application.StartupPath + "data_encr.txt", Login_Screen.masterKey)
        Login_Screen.Show()
        Login_Screen.Activate()
        Me.Hide()
        'Login_Screen.WindowState = WindowState.
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveAll()
        Application.Exit() ' Closes the entire application
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search.Show()
        Search.Activate()
    End Sub

    Private Sub btn_sort_Click(sender As Object, e As EventArgs) Handles btn_sort.Click
        Sort.Show()
        Sort.Activate()
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Text Files (*.txt)|*.txt|XML Files (*.xml)|*.xml|All Files (*.*)|*.*|Encrypted (*.encr)|*.encr"
        saveFileDialog.FilterIndex = 1
        saveFileDialog.Title = "Save File"
        saveFileDialog.OverwritePrompt = True ' Ask before overwriting
        saveFileDialog.DefaultExt = "txt" ' Default file extension

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Write data to the selected file
            WriteToFile(saveFileDialog.FileName)
            MessageBox.Show("Data successfully exported!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub btn_import_Click(sender As Object, e As EventArgs) Handles btn_import.Click

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|XML Files (*.xml)|*.xml|All Files (*.*)|*.*|Encrypted (*.encr)|*.encr"
        openFileDialog.FilterIndex = 1
        openFileDialog.Title = "Select Files"
        openFileDialog.Multiselect = False ' Allow multiple files selection

        staff_list.Clear()

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Iterate through each selected file
            ReadFile(openFileDialog)
        End If


    End Sub



    Private Sub btn_removestaff_Click(sender As Object, e As EventArgs) Handles btn_removestaff.Click
        removestaff.Show()
        removestaff.Activate()
    End Sub

    Private Sub btn_addstaff_Click(sender As Object, e As EventArgs) Handles btn_addstaff.Click
        AddStaff.Show()
        AddStaff.Activate()
    End Sub



    Public Sub UpdateStaffList()
        drp_staff.Items.Clear()



        'MessageBox.Show(staff_list.Count)

        For index = 0 To staff_list.Count - 1
            drp_staff.Items.Add(staff_list(index).FirstName & " " & staff_list(index).Surname)
            'MessageBox.Show(staff_list(index).FirstName & " " & staff_list(index).Surname)
        Next

        If drp_staff.Items.Count > 0 Then
            drp_staff.Text = drp_staff.Items(0).ToString() ' Sets the text to the first item
        End If

        UpdateStaffPI()
    End Sub



    Private Sub btn_selright_Click(sender As Object, e As EventArgs) Handles btn_selright.Click
        ' Ensure an item is selected and that we're not at the last item
        If drp_staff.Items.Count > 0 AndAlso drp_staff.SelectedIndex < drp_staff.Items.Count - 1 Then
            drp_staff.SelectedIndex += 1 ' Move to the next item
        End If
        UpdateStaffPI()

    End Sub

    Private Sub btn_selleft_Click(sender As Object, e As EventArgs) Handles btn_selleft.Click
        ' Ensure an item is selected and that we're not at the first item
        If drp_staff.Items.Count > 0 AndAlso drp_staff.SelectedIndex > 0 Then
            drp_staff.SelectedIndex -= 1 ' Move to the previous item
        End If
        UpdateStaffPI()

    End Sub


    Private Sub dtp_date_Enter(sender As Object, e As EventArgs) Handles dtp_dob.Enter
        If mod_mode = True Then
            dtp_dob.Enabled = False ' Disable to lose focus
            Me.Focus() ' Set focus to the form
            Application.DoEvents() ' Process UI update
            dtp_dob.Enabled = True ' Re-enable it
        End If

    End Sub




    Private Sub btn_modpsw_Click(sender As Object, e As EventArgs) Handles btn_modpsw.Click
        If mod_mode = True Then
            ChangePasswordForm.Show()
        End If

    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        SaveAll()
        Application.Restart()
        'Login_Screen.Show()
        'Me.Hide()
    End Sub





    Private Sub SaveAll()
        WriteToFile(Application.StartupPath + "data_encr.txt", Login_Screen.masterKey)
    End Sub

    Private Sub btn_saveall_Click(sender As Object, e As EventArgs) Handles btn_saveall.Click
        SaveAll()
    End Sub

    ' Ensure a valid staff member is selected before making changes
    ' Ensure a valid staff member is selected before making changes
    Private Function GetSelectedStaff() As Staff_class
        If drp_staff.SelectedIndex >= 0 AndAlso drp_staff.SelectedIndex < staff_list.Count Then
            Return staff_list(drp_staff.SelectedIndex)
        End If
        Return Nothing
    End Function

    ' Updates the form fields with the selected staff's information
    Private Sub UpdateStaffPI()
        If drp_staff.SelectedIndex < 0 OrElse drp_staff.SelectedIndex >= staff_list.Count Then Return

        Dim curid = drp_staff.SelectedIndex
        Dim selectedStaff = staff_list(curid)

        ' Ensure fields are cleared before updating
        txt_staffidbox.Clear()
        txt_firstnamebox.Clear()
        txt_surnamebox.Clear()
        txt_modgenderbox.Clear()
        txt_paybox.Clear()
        txt_skillsbox.Clear()

        ' Populate the fields with selected staff details
        txt_staffidbox.Text = selectedStaff.Staff_ID.ToString()
        txt_firstnamebox.Text = selectedStaff.FirstName
        txt_surnamebox.Text = selectedStaff.Surname
        txt_modgenderbox.Text = selectedStaff.Gender
        txt_paybox.Text = selectedStaff.Pay.ToString()
        dtp_dob.Value = selectedStaff.DOB
        chk_makeadmin.Checked = selectedStaff.Admin

        ' Set skills correctly
        txt_skillsbox.AppendText(selectedStaff.Skill1 & Environment.NewLine)
        txt_skillsbox.AppendText(selectedStaff.Skill2 & Environment.NewLine)
        txt_skillsbox.AppendText(selectedStaff.Skill3 & Environment.NewLine)
        txt_skillsbox.AppendText(selectedStaff.Skill4 & Environment.NewLine)
        txt_skillsbox.AppendText(selectedStaff.Skill5 & Environment.NewLine)
        txt_skillsbox.AppendText(selectedStaff.Skill6 & Environment.NewLine)

        ' Make fields editable based on `mod_mode`
        SetEditingMode(mod_mode)
    End Sub

    ' Toggles modification mode and enables/disables input fields
    Private Sub btn_modstaff_Click(sender As Object, e As EventArgs) Handles btn_modstaff.Click
        mod_mode = Not mod_mode
        SetEditingMode(mod_mode)
    End Sub

    ' Function to enable or disable editing
    Private Sub SetEditingMode(enabled As Boolean)
        ' Set ReadOnly properties
        txt_staffidbox.ReadOnly = Not enabled
        txt_firstnamebox.ReadOnly = Not enabled
        txt_surnamebox.ReadOnly = Not enabled
        txt_modgenderbox.ReadOnly = Not enabled
        txt_paybox.ReadOnly = Not enabled
        txt_skillsbox.ReadOnly = Not enabled

        ' Disable Date Picker and Checkbox
        dtp_dob.Enabled = enabled
        chk_makeadmin.Enabled = enabled

        ' Change background color based on editability
        Dim readonlyColor As Color = Color.LightGray
        Dim editableColor As Color = Color.White

        txt_staffidbox.BackColor = If(enabled, editableColor, readonlyColor)
        txt_firstnamebox.BackColor = If(enabled, editableColor, readonlyColor)
        txt_surnamebox.BackColor = If(enabled, editableColor, readonlyColor)
        txt_modgenderbox.BackColor = If(enabled, editableColor, readonlyColor)
        txt_paybox.BackColor = If(enabled, editableColor, readonlyColor)
        txt_skillsbox.BackColor = If(enabled, editableColor, readonlyColor)

        ' Disable Tab Stop when fields are not editable (optional)
        txt_staffidbox.TabStop = enabled
        txt_firstnamebox.TabStop = enabled
        txt_surnamebox.TabStop = enabled
        txt_modgenderbox.TabStop = enabled
        txt_paybox.TabStop = enabled
        txt_skillsbox.TabStop = enabled
    End Sub


    ' Only saves changes if mod_mode is enabled
    Private Sub txt_staffidbox_TextChanged(sender As Object, e As EventArgs) Handles txt_staffidbox.TextChanged
        If Not mod_mode Then Return

        Dim selectedStaff = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            Dim staffID As Integer
            If Integer.TryParse(txt_staffidbox.Text, staffID) Then
                selectedStaff.Staff_ID = staffID
            ElseIf txt_staffidbox.Text = "" Then
                selectedStaff.Staff_ID = 0 ' Default to 0 if empty
            Else
                MessageBox.Show("Error: Invalid Staff ID. Only numbers allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_staffidbox.Clear()
            End If
        End If
    End Sub

    ' Only saves changes if mod_mode is enabled
    Private Sub txt_paybox_TextChanged(sender As Object, e As EventArgs) Handles txt_paybox.TextChanged
        If Not mod_mode Then Return

        Dim selectedStaff = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            Dim payAmount As Integer
            If Integer.TryParse(txt_paybox.Text, payAmount) Then
                selectedStaff.Pay = payAmount
            ElseIf txt_paybox.Text = "" Then
                selectedStaff.Pay = 0 ' Default to 0 if empty
            Else
                MessageBox.Show("Error: Invalid Pay. Only numbers allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_paybox.Clear()
            End If
        End If
    End Sub

    ' Only saves changes if mod_mode is enabled
    Private Sub txt_firstnamebox_TextChanged(sender As Object, e As EventArgs) Handles txt_firstnamebox.TextChanged
        If Not mod_mode Then Return
        Dim selectedStaff = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then selectedStaff.FirstName = txt_firstnamebox.Text
    End Sub

    ' Only saves changes if mod_mode is enabled
    Private Sub txt_surnamebox_TextChanged(sender As Object, e As EventArgs) Handles txt_surnamebox.TextChanged
        If Not mod_mode Then Return
        Dim selectedStaff = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then selectedStaff.Surname = txt_surnamebox.Text
    End Sub

    ' Only saves changes if mod_mode is enabled
    Private Sub txt_modgenderbox_TextChanged(sender As Object, e As EventArgs) Handles txt_modgenderbox.TextChanged
        If Not mod_mode Then Return
        Dim selectedStaff = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then selectedStaff.Gender = txt_modgenderbox.Text
    End Sub

    ' Only saves changes if mod_mode is enabled
    Private Sub dtp_dob_ValueChanged(sender As Object, e As EventArgs) Handles dtp_dob.ValueChanged
        If Not mod_mode Then Return
        Dim selectedStaff = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then selectedStaff.DOB = dtp_dob.Value
    End Sub

    ' Only saves changes if mod_mode is enabled
    Private Sub chk_makeadmin_CheckedChanged(sender As Object, e As EventArgs) Handles chk_makeadmin.CheckedChanged
        If Not mod_mode Then Return
        Dim selectedStaff = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then selectedStaff.Admin = chk_makeadmin.Checked
    End Sub

    ' Only saves changes if mod_mode is enabled
    Private Sub txt_skillsbox_TextChanged(sender As Object, e As EventArgs) Handles txt_skillsbox.TextChanged
        If Not mod_mode Then Return

        Dim selectedStaff = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            Dim skills As String() = txt_skillsbox.Lines
            selectedStaff.Skill1 = If(skills.Length > 0, skills(0), "")
            selectedStaff.Skill2 = If(skills.Length > 1, skills(1), "")
            selectedStaff.Skill3 = If(skills.Length > 2, skills(2), "")
            selectedStaff.Skill4 = If(skills.Length > 3, skills(3), "")
            selectedStaff.Skill5 = If(skills.Length > 4, skills(4), "")
            selectedStaff.Skill6 = If(skills.Length > 5, skills(5), "")
        End If
    End Sub

    Private Sub drp_staff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drp_staff.SelectedIndexChanged
        UpdateStaffPI()
    End Sub






    Private Sub ReadFile(path As OpenFileDialog)
        For Each filePath As String In path.FileNames
            ' Check the file extension to determine how to process it
            If filePath.EndsWith(".txt") Then
                ' Process the text file
                Using sr As New IO.StreamReader(filePath)
                    ' Assume txtContent is a TextBox to display the content
                    'txtContent.AppendText(sr.ReadToEnd() & Environment.NewLine) ' Display content
                    'MessageBox.Show(sr.ReadToEnd())
                    While Not sr.EndOfStream
                        Dim result As String() = sr.ReadLine().Split("|")
                        'MessageBox.Show(result.Length)
                        ' Ensure result has enough elements to avoid index errors
                        If result.Length = 14 Then
                            Dim newline As New Staff_class With {
                                .Staff_ID = result(0),
                                .FirstName = result(1),
                                .Surname = result(2),
                                .Gender = result(3),
                                .DOB = result(4),
                                .Admin = (result(5).Trim().ToLower() = "yes"), ' Convert "Yes"/"No" to Boolean
                                .Skill1 = result(6),
                                .Skill2 = result(7),
                                .Skill3 = result(8),
                                .Skill4 = result(9),
                                .Skill5 = result(10),
                                .Skill6 = result(11),
                                .Pay = result(12),
                                .Password = result(13)
                            }

                            staff_list.Add(newline)
                            'UpdateStaffList()
                        Else
                            ' Handle the case where the line doesn't have enough fields
                            MessageBox.Show("W3: Error Invalid File Format")
                            Console.WriteLine("Invalid line format: " & String.Join("|", result))
                        End If
                    End While

                    UpdateStaffList()

                End Using
            ElseIf filePath.EndsWith(".xml") Then
                ' Process the XML file
                Try
                    Dim xdoc As XDocument = XDocument.Load(filePath)
                    'txtContent.AppendText(xdoc.ToString() & Environment.NewLine) ' Display content
                Catch ex As Exception
                    MessageBox.Show("Error reading XML file: " & ex.Message)
                End Try
            ElseIf filePath.EndsWith(".encr") Then
                ' Process the XML file
                Try
                    'WriteToFile(Application.StartupPath + "data_encr.txt", Login_Screen.masterKey)
                    ReadFile(filePath, Login_Screen.masterKey)


                    'txtContent.AppendText(xdoc.ToString() & Environment.NewLine) ' Display content
                Catch ex As Exception
                    MessageBox.Show("Error reading XML file: " & ex.Message)
                End Try
            End If


            '
        Next
    End Sub

    Public Sub ReadFile(path As String)
        ' Check the file extension to determine how to process it

        ' Process the text file
        Using sr As New IO.StreamReader(path)
            ' Assume txtContent is a TextBox to display the content
            'txtContent.AppendText(sr.ReadToEnd() & Environment.NewLine) ' Display content
            'MessageBox.Show(sr.ReadToEnd())
            While Not sr.EndOfStream


                Dim result As String() = sr.ReadLine().Split("|")
                'MessageBox.Show(result.Length)
                ' Ensure result has enough elements to avoid index errors
                If result.Length = 14 Then
                    Dim newline As New Staff_class With {
                        .Staff_ID = result(0),
                        .FirstName = result(1),
                        .Surname = result(2),
                        .Gender = result(3),
                        .DOB = result(4),
                        .Admin = (result(5).Trim().ToLower() = "yes"), ' Convert "Yes"/"No" to Boolean
                        .Skill1 = result(6),
                        .Skill2 = result(7),
                        .Skill3 = result(8),
                        .Skill4 = result(9),
                        .Skill5 = result(10),
                        .Skill6 = result(11),
                        .Pay = result(12),
                        .Password = result(13)
                    }

                    staff_list.Add(newline)
                    'UpdateStaffList()
                Else
                    ' Handle the case where the line doesn't have enough fields
                    MessageBox.Show("W4: Error Invalid File Format")
                    'Console.WriteLine("Invalid line format: " & String.Join("|", result))
                End If
            End While

            UpdateStaffList()
        End Using

    End Sub

    Private Sub ReadFile(path As String, encr_key As String)
        Try
            ' If the file does not exist, create an empty one
            If Not IO.File.Exists(path) Then
                IO.File.WriteAllText(path, "")
                Return
            End If

            ' Read all encrypted lines at once
            Dim encryptedLines As String() = IO.File.ReadAllLines(path)

            ' Clear existing staff list to avoid duplicates
            staff_list.Clear()

            ' Process all lines
            For Each encryptedLine As String In encryptedLines
                Dim decryptedText As String = PasswordSecurity.DecryptBase64ToString(encryptedLine, encr_key)

                ' Validate decrypted format
                Dim result As String() = decryptedText.Split("|")
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
                    staff_list.Add(newline)
                Else
                    ' Log the issue without crashing
                    Console.WriteLine("Invalid line format: " & decryptedText)
                End If
            Next

            ' Update the staff list in the UI
            UpdateStaffList()

        Catch ex As Exception
            MessageBox.Show("Error reading file: " & ex.Message)
        End Try
    End Sub


    Private Sub WriteToFile(filePath As String)
        If filePath.EndsWith(".txt") Then
            ' Write to a text file
            Using sw As New IO.StreamWriter(filePath, False) ' False = overwrite file
                For Each staff As Staff_class In staff_list
                    Dim line As String = $"{staff.Staff_ID}|{staff.FirstName}|{staff.Surname}|{staff.Gender}|{staff.DOB}|" &
                                     $"{If(staff.Admin, "Yes", "No")}|{staff.Skill1}|{staff.Skill2}|{staff.Skill3}|{staff.Skill4}|" &
                                     $"{staff.Skill5}|{staff.Skill6}|{staff.Pay}|{staff.Password}"
                    sw.WriteLine(line)
                Next
            End Using
            'MessageBox.Show("Data successfully written to text file.")

        ElseIf filePath.EndsWith(".xml") Then
            ' Write to an XML file
            Try
                Dim xdoc As New XDocument(
                New XElement("StaffList",
                    From staff In staff_list
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
                        New XElement("Pay", staff.Pay)
                    )
                )
            )
                xdoc.Save(filePath)
                'MessageBox.Show("Data successfully written to XML file.")
            Catch ex As Exception
                MessageBox.Show("Error writing XML file: " & ex.Message)
            End Try

        ElseIf filePath.EndsWith(".encr") Then
            ' Process the XML file
            Try
                WriteToFile(filePath, Login_Screen.masterKey)
                'ReadFile(filePath, Login_Screen.masterKey)


                'txtContent.AppendText(xdoc.ToString() & Environment.NewLine) ' Display content
            Catch ex As Exception
                MessageBox.Show("Error reading XML file: " & ex.Message)
            End Try
        Else
            Dim fileExtension As String = System.IO.Path.GetExtension(filePath)
            MessageBox.Show("W1) Invalid file format. Please use .txt or .xml not: " & fileExtension)

        End If
    End Sub

    Private Sub WriteToFile(filePath As String, password_key As String)
        If filePath.EndsWith(".txt") Then
            Try
                ' Convert all staff records to encrypted lines at once
                Dim encryptedLines As New List(Of String)
                For Each staff As Staff_class In staff_list
                    Dim line As String = $"{staff.Staff_ID}|{staff.FirstName}|{staff.Surname}|{staff.Gender}|{staff.DOB}|" &
                                         $"{If(staff.Admin, "Yes", "No")}|{staff.Skill1}|{staff.Skill2}|{staff.Skill3}|{staff.Skill4}|" &
                                         $"{staff.Skill5}|{staff.Skill6}|{staff.Pay}|{staff.Password}"

                    If Not staff.Password = "" And staff.Admin Then
                        UserManager.ManageEncryptionKey(staff.FirstName, PasswordSecurity.EncryptMasterKey(password_key, staff.Password))
                    End If

                    encryptedLines.Add(PasswordSecurity.EncryptStringToBase64(line, password_key))
                Next

                ' Write all encrypted lines at once
                IO.File.WriteAllLines(filePath, encryptedLines)

            Catch ex As Exception
                MessageBox.Show("Error writing to text file: " & ex.Message)
            End Try

        ElseIf filePath.EndsWith(".xml") Then
            ' Bulk write to XML
            Try
                Dim xdoc As New XDocument(
                    New XElement("StaffList",
                        From staff In staff_list
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
        ElseIf filePath.EndsWith(".encr") Then
            ' Process the XML file
            Try
                ' Convert all staff records to encrypted lines at once
                Dim encryptedLines As New List(Of String)
                For Each staff As Staff_class In staff_list
                    Dim line As String = $"{staff.Staff_ID}|{staff.FirstName}|{staff.Surname}|{staff.Gender}|{staff.DOB}|" &
                                         $"{If(staff.Admin, "Yes", "No")}|{staff.Skill1}|{staff.Skill2}|{staff.Skill3}|{staff.Skill4}|" &
                                         $"{staff.Skill5}|{staff.Skill6}|{staff.Pay}|{staff.Password}"

                    If Not staff.Password = "" And staff.Admin Then
                        UserManager.ManageEncryptionKey(staff.FirstName, PasswordSecurity.EncryptMasterKey(password_key, staff.Password))
                    End If

                    encryptedLines.Add(PasswordSecurity.EncryptStringToBase64(line, password_key))
                Next

                ' Write all encrypted lines at once
                IO.File.WriteAllLines(filePath, encryptedLines)

            Catch ex As Exception
                MessageBox.Show("Error writing to encripted file: " & ex.Message)
            End Try
        Else
            Dim fileExtension As String = System.IO.Path.GetExtension(filePath)
            MessageBox.Show("W2) Invalid file format. Please use .txt or .xml not: " & fileExtension)
        End If
    End Sub

End Class


Public Class Staff_class
    Public Property Staff_ID As Integer
    Public Property FirstName As String
    Public Property Surname As String
    Public Property Gender As String
    Public Property DOB As Date
    Public Property Pay As Integer
    Public Property Admin As Boolean
    Public Property Skill1 As String
    Public Property Skill2 As String
    Public Property Skill3 As String
    Public Property Skill4 As String
    Public Property Skill5 As String
    Public Property Skill6 As String
    Public Property Password As String

    ' Method to parse DataGridViewRow into Staff_class object
    Shared Sub Swap(Of T)(ByRef a As T, ByRef b As T)
        Dim temp As T = a
        a = b
        b = temp
    End Sub

End Class




Public Class PasswordSecurity

    ' 🟢 Function to Derive an AES Key from the Master Key
    Public Shared Function GetAESKeyFromMasterKey(masterKey As String) As Byte()
        Return Convert.FromBase64String(masterKey)
    End Function

    ' 🟢 Function to Encrypt a String and Return a Base64 Encoded String
    Public Shared Function EncryptStringToBase64(inputString As String, masterKey As String) As String
        Dim key As Byte() = GetAESKeyFromMasterKey(masterKey)

        ' Generate IV
        Dim iv As Byte() = New Byte(15) {} ' AES block size is 16 bytes
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(iv)
        End Using

        ' Convert input string to bytes
        Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(inputString)

        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Using encryptor As ICryptoTransform = aes.CreateEncryptor()
                Dim encryptedBytes As Byte() = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)

                ' Store IV + Encrypted Data, return as Base64 string
                Dim finalData As Byte() = iv.Concat(encryptedBytes).ToArray()
                Return Convert.ToBase64String(finalData)
            End Using
        End Using
    End Function

    ' 🟢 Function to Decrypt a Base64 Encoded String
    Public Shared Function DecryptBase64ToString(encryptedBase64 As String, masterKey As String) As String
        Dim key As Byte() = GetAESKeyFromMasterKey(masterKey)

        ' Convert Base64 string to byte array
        Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedBase64)

        ' Extract IV (first 16 bytes)
        Dim iv As Byte() = encryptedBytes.Take(16).ToArray()

        ' Extract actual encrypted data (remaining bytes)
        Dim cipherBytes As Byte() = encryptedBytes.Skip(16).ToArray()

        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Using decryptor As ICryptoTransform = aes.CreateDecryptor()
                Dim decryptedBytes As Byte() = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length)

                ' Convert decrypted bytes to string and return
                Return Encoding.UTF8.GetString(decryptedBytes)
            End Using
        End Using
    End Function


    ' 🟢 Function to Derive an AES Encryption Key from the Password
    Public Shared Function DeriveEncryptionKey(password As String) As Byte()
        Using sha256 As SHA256 = SHA256.Create()
            Dim salt As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password & "secure_salt"))
            Using pbkdf2 As New Rfc2898DeriveBytes("shared_secret", salt, 100000, HashAlgorithmName.SHA256)
                Return pbkdf2.GetBytes(32) ' 256-bit key for AES
            End Using
        End Using
    End Function

    ' 🟢 Function to Encrypt the Master Key Using AES-256
    Public Shared Function EncryptMasterKey(masterKey As String, password As String) As String
        Dim key As Byte() = DeriveEncryptionKey(password)

        ' Generate IV
        Dim iv As Byte() = New Byte(15) {}
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(iv)
        End Using

        ' Encrypt
        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(masterKey)
            Using encryptor As ICryptoTransform = aes.CreateEncryptor()
                Dim encryptedBytes As Byte() = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)

                ' Store IV + Encrypted Master Key
                Dim finalData As Byte() = iv.Concat(encryptedBytes).ToArray()
                Return Convert.ToBase64String(finalData)
            End Using
        End Using
    End Function

    ' 🟢 Function to Decrypt the Master Key Using AES-256
    Public Shared Function DecryptMasterKey(encryptedMasterKey As String, password As String) As String
        Dim key As Byte() = DeriveEncryptionKey(password)

        ' Decode Base64
        Dim fullCipher As Byte() = Convert.FromBase64String(encryptedMasterKey)

        ' Extract IV and encrypted data
        Dim iv As Byte() = fullCipher.Take(16).ToArray()
        Dim encryptedData As Byte() = fullCipher.Skip(16).ToArray()

        ' Decrypt
        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Using decryptor As ICryptoTransform = aes.CreateDecryptor()
                Dim decryptedBytes As Byte() = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length)
                Return Encoding.UTF8.GetString(decryptedBytes)
            End Using
        End Using
    End Function
End Class

Public Class UserManager
    Private Shared userFilePath As String = Application.StartupPath + "users.dat"

    Public Shared Sub ManageEncryptionKey(username As String, encryptionKey As String)
        Dim updated As Boolean = False

        ' Ensure file exists
        If Not File.Exists(userFilePath) Then
            File.Create(userFilePath).Dispose()
        End If

        ' Read all lines and check if key exists
        Dim lines As List(Of String) = File.ReadAllLines(userFilePath).ToList()

        For i As Integer = 0 To lines.Count - 1
            If lines(i).StartsWith(username & ":") Then
                ' Update existing key
                lines(i) = username & ":" & encryptionKey
                updated = True
                Exit For
            End If
        Next

        ' If no existing key, create new entry
        If Not updated Then
            lines.Add(username & ":" & encryptionKey)
        End If

        ' Write back to file
        File.WriteAllLines(userFilePath, lines)
    End Sub


    ' 🟢 Function to Add a New User with a Password
    Public Shared Sub AddUser(username As String, password As String)
        Dim masterKey As String = GenerateMasterKey() ' Generate a master key for database encryption
        Dim encryptedMasterKey As String = PasswordSecurity.EncryptMasterKey(masterKey, password)

        ' Save to file
        Dim newUser As String = $"{username}:{encryptedMasterKey}"
        File.AppendAllText(userFilePath, newUser & Environment.NewLine)
    End Sub

    Public Shared Sub RemoveUser(username As String)
        ' Check if the file exists
        If Not File.Exists(userFilePath) Then
            MessageBox.Show("User file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Read all lines and filter out the user
        Dim lines As List(Of String) = File.ReadAllLines(userFilePath).ToList()
        Dim updatedLines = lines.Where(Function(line) Not line.StartsWith(username & ":")).ToList()

        ' Check if the user was found and removed
        If lines.Count = updatedLines.Count Then
            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Overwrite the file with updated user list
        File.WriteAllLines(userFilePath, updatedLines)

        ' Confirmation message
        MessageBox.Show($"User '{username}' has been removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' 🟢 Function to Retrieve the Encrypted Master Key for a Username
    Public Shared Function GetEncryptedMasterKey(username As String) As String
        If File.Exists(userFilePath) Then
            For Each line As String In File.ReadAllLines(userFilePath)
                Dim parts As String() = line.Split(":"c)
                If parts(0).ToLower() = username.ToLower() Then
                    Return parts(1) ' Return encrypted master key
                End If
            Next
        End If
        Return Nothing ' User not found
    End Function

    ' 🟢 Function to Generate a Random 256-bit Master Key
    Private Shared Function GenerateMasterKey() As String
        Dim key As Byte() = New Byte(31) {} ' 32 bytes for AES-256
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(key)
        End Using
        Return Convert.ToBase64String(key)
    End Function
End Class


