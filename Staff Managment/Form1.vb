Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Public staff_list As New List(Of Staff_class)
    Dim mod_mode As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadFile(Application.StartupPath + "data.txt")
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
        saveFileDialog.Filter = "Text Files (*.txt)|*.txt|XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
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
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
        openFileDialog.FilterIndex = 1
        openFileDialog.Title = "Select Files"
        openFileDialog.Multiselect = False ' Allow multiple files selection

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Iterate through each selected file
            ReadFile(openFileDialog.FileName)
        End If


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
                        If result.Length = 13 Then
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
                                .Pay = result(12)
                            }

                            staff_list.Add(newline)
                            'UpdateStaffList()
                        Else
                            ' Handle the case where the line doesn't have enough fields
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
                    MessageBox.Show(xdoc.ToString())
                Catch ex As Exception
                    MessageBox.Show("Error reading XML file: " & ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub ReadFile(path As String)
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
                If result.Length = 13 Then
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
                        .Pay = result(12)
                    }

                    staff_list.Add(newline)
                    'UpdateStaffList()
                Else
                    ' Handle the case where the line doesn't have enough fields
                    Console.WriteLine("Invalid line format: " & String.Join("|", result))
                End If
            End While

            UpdateStaffList()
        End Using

    End Sub

    Private Sub btn_removestaff_Click(sender As Object, e As EventArgs) Handles btn_removestaff.Click
        removestaff.Show()
        removestaff.Activate()
    End Sub

    Private Sub btn_addstaff_Click(sender As Object, e As EventArgs) Handles btn_addstaff.Click
        AddStaff.Show()
        AddStaff.Activate()
    End Sub



    Private Sub UpdateStaffList()
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

    Private Sub UpdateStaffPI()

        txt_staffidbox.Clear()
        txt_firstnamebox.Clear()
        txt_surnamebox.Clear()
        txt_modgenderbox.Clear()
        txt_paybox.Clear()
        txt_skillsbox.Clear()

        'MessageBox.Show(staff_list.Count)
        Dim curid = drp_staff.SelectedIndex

        If staff_list.Count = 0 Then
            txt_staffidbox.ReadOnly = False
            txt_firstnamebox.ReadOnly = False
            txt_surnamebox.ReadOnly = False
            txt_modgenderbox.ReadOnly = False
            txt_paybox.ReadOnly = False
            dtp_dob.Enabled = True
            txt_skillsbox.ReadOnly = False
            Return
        End If


        txt_staffidbox.Text = staff_list(curid).Staff_ID
        txt_firstnamebox.Text = staff_list(curid).FirstName
        txt_surnamebox.Text = staff_list(curid).Surname
        txt_modgenderbox.Text = staff_list(curid).Gender
        txt_paybox.Text = staff_list(curid).Pay
        dtp_dob.Text = staff_list(curid).DOB
        chk_makeadmin.Checked = staff_list(curid).Admin

        ' Combine skills into a single string separated by commas

        txt_skillsbox.AppendText(staff_list(curid).Skill1 & Environment.NewLine)
        txt_skillsbox.AppendText(staff_list(curid).Skill2 & Environment.NewLine)
        txt_skillsbox.AppendText(staff_list(curid).Skill3 & Environment.NewLine)
        txt_skillsbox.AppendText(staff_list(curid).Skill4 & Environment.NewLine)
        txt_skillsbox.AppendText(staff_list(curid).Skill5 & Environment.NewLine)
        txt_skillsbox.AppendText(staff_list(curid).Skill6 & Environment.NewLine)


        txt_staffidbox.ReadOnly = False
        txt_firstnamebox.ReadOnly = False
        txt_surnamebox.ReadOnly = False
        txt_modgenderbox.ReadOnly = False
        txt_paybox.ReadOnly = False
        dtp_dob.Enabled = True
        txt_skillsbox.ReadOnly = False

        mod_mode = True
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

    Private Sub btn_modstaff_Click(sender As Object, e As EventArgs) Handles btn_modstaff.Click
        If mod_mode Then
            mod_mode = False

            txt_staffidbox.ReadOnly = False
            txt_firstnamebox.ReadOnly = False
            txt_surnamebox.ReadOnly = False
            txt_modgenderbox.ReadOnly = False
            txt_paybox.ReadOnly = False
            dtp_dob.Enabled = True
            txt_skillsbox.ReadOnly = False

        Else
            mod_mode = True

            txt_staffidbox.ReadOnly = True
            txt_firstnamebox.ReadOnly = True
            txt_surnamebox.ReadOnly = True
            txt_modgenderbox.ReadOnly = True
            txt_paybox.ReadOnly = True
            dtp_dob.Enabled = False
            txt_skillsbox.ReadOnly = True
        End If
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

        End If

    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        SaveAll()
        Login_Screen.Show()
        Me.Hide()
    End Sub

    Private Sub WriteToFile(filePath As String)
        If filePath.EndsWith(".txt") Then
            ' Write to a text file
            Using sw As New IO.StreamWriter(filePath, False) ' False = overwrite file
                For Each staff As Staff_class In staff_list
                    Dim line As String = $"{staff.Staff_ID}|{staff.FirstName}|{staff.Surname}|{staff.Gender}|{staff.DOB}|" &
                                     $"{If(staff.Admin, "Yes", "No")}|{staff.Skill1}|{staff.Skill2}|{staff.Skill3}|{staff.Skill4}|" &
                                     $"{staff.Skill5}|{staff.Skill6}|{staff.Pay}"
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
        Else
            MessageBox.Show("Invalid file format. Please use .txt or .xml")
        End If
    End Sub


    Private Sub SaveAll()



        WriteToFile(Application.StartupPath + "data.txt")
    End Sub

    Private Sub btn_saveall_Click(sender As Object, e As EventArgs) Handles btn_saveall.Click
        SaveAll()
    End Sub

    ' Ensure a valid staff member is selected before making changes
    Private Function GetSelectedStaff() As Staff_class
        If drp_staff.SelectedIndex >= 0 AndAlso drp_staff.SelectedIndex < staff_list.Count Then
            Return staff_list(drp_staff.SelectedIndex)
        End If
        Return Nothing
    End Function

    ' Staff ID - Ensure it is a number before assigning
    Private Sub txt_staffidbox_TextChanged(sender As Object, e As EventArgs) Handles txt_staffidbox.TextChanged
        If mod_mode Then Return

        Dim selectedStaff As Staff_class = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            Dim staffID As Integer
            If Integer.TryParse(txt_staffidbox.Text, staffID) Then
                selectedStaff.Staff_ID = staffID.ToString() ' Ensure it's stored as string if needed
            Else
                MessageBox.Show("Error: Invalid Staff ID (Numbers only).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_staffidbox.Clear()
            End If
        End If
    End Sub

    ' Gender
    Private Sub txt_modgenderbox_TextChanged(sender As Object, e As EventArgs) Handles txt_modgenderbox.TextChanged
        Dim selectedStaff As Staff_class = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            selectedStaff.Gender = txt_modgenderbox.Text
        End If
    End Sub

    ' First Name
    Private Sub txt_firstnamebox_TextChanged(sender As Object, e As EventArgs) Handles txt_firstnamebox.TextChanged
        Dim selectedStaff As Staff_class = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            selectedStaff.FirstName = txt_firstnamebox.Text
        End If
    End Sub

    ' Surname
    Private Sub txt_surnamebox_TextChanged(sender As Object, e As EventArgs) Handles txt_surnamebox.TextChanged
        Dim selectedStaff As Staff_class = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            selectedStaff.Surname = txt_surnamebox.Text
        End If
    End Sub

    ' Pay - Ensure it is a number before assigning
    Private Sub txt_paybox_TextChanged(sender As Object, e As EventArgs) Handles txt_paybox.TextChanged
        Dim selectedStaff As Staff_class = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            Dim payAmount As Integer
            If Integer.TryParse(txt_paybox.Text, payAmount) Then
                selectedStaff.Pay = payAmount.ToString() ' Convert to string if needed
            Else
                MessageBox.Show("Error: Invalid Pay (Numbers only).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_paybox.Clear()
            End If
        End If
    End Sub

    ' Date of Birth - Ensure it's properly formatted
    Private Sub dtp_dob_ValueChanged(sender As Object, e As EventArgs) Handles dtp_dob.ValueChanged
        Dim selectedStaff As Staff_class = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            selectedStaff.DOB = dtp_dob.Value.ToString("yyyy-MM-dd") ' Standardized format
        End If
    End Sub

    ' Admin Checkbox
    Private Sub chk_makeadmin_CheckedChanged(sender As Object, e As EventArgs) Handles chk_makeadmin.CheckedChanged
        Dim selectedStaff As Staff_class = GetSelectedStaff()
        If selectedStaff IsNot Nothing Then
            selectedStaff.Admin = chk_makeadmin.Checked
        End If
    End Sub

    ' Skills - Assign each line to Skill1 - Skill6
    Private Sub txt_skillsbox_TextChanged(sender As Object, e As EventArgs) Handles txt_skillsbox.TextChanged
        Dim selectedStaff As Staff_class = GetSelectedStaff()
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


End Class



