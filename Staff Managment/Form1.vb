Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Public staff_list As New List(Of Staff_class)
    Dim mod_mode As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login_Screen.Show()
        Login_Screen.Activate()
        Me.Hide()
        'Login_Screen.WindowState = WindowState.
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'SaveAll()
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

    End Sub

    Private Sub btn_import_Click(sender As Object, e As EventArgs) Handles btn_import.Click

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
        openFileDialog.FilterIndex = 3
        openFileDialog.Title = "Select Files"
        openFileDialog.Multiselect = False ' Allow multiple files selection

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Iterate through each selected file
            ReadFile(openFileDialog)
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


    Private Sub chk_makeadmin_CheckedChanged(sender As Object, e As EventArgs) Handles chk_makeadmin.Click
        If mod_mode = True Then
            chk_makeadmin.Checked = staff_list(drp_staff.SelectedIndex).Admin
            'MessageBox.Show("sss")
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

    End Sub

    Private Sub SaveAll()
        WriteToFile(Application.StartupPath + "data.txt")
    End Sub

    Private Sub btn_saveall_Click(sender As Object, e As EventArgs) Handles btn_saveall.Click
        SaveAll()
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