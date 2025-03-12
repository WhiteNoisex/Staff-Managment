Imports System.IO
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Security.Cryptography
Imports System.Net.NetworkInformation
Imports Staff_Managment.FileIO_APP

Imports System

Public Class Form1
    Public staff_list As New List(Of Staff_class)
    Dim mod_mode As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show(Login_Screen.masterKey)
        ReadFile(Application.StartupPath + "data_encr.encr", Login_Screen.masterKey)
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
            WriteFile(saveFileDialog.FileName)
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
            ReadFile(openFileDialog.FileName)
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
        WriteFile(Application.StartupPath + "data_encr.encr", Login_Screen.masterKey)
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








End Class