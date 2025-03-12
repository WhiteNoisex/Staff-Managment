Imports System.Security.Cryptography
Imports System.Text

Public Class AddStaff
    ' Event: Form Load


    ' Subroutine: AddStaff_Load
    ' Inputs: VB Button
    ' Returns: None
    '
    ' Envriomental Effect:
    ' Updates "dtp_dob" value to today
    Private Sub AddStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize default values if needed
        dtp_dob.Value = DateTime.Today
    End Sub


    ' Subroutine: Button1_Click
    ' Inputs: VB Button
    ' Returns: None
    '
    ' Envriomental Effect:
    ' Creates new member of "Staff_class" with collected values, then adds them to the "Form1.staff_list" and calling "Form1.UpdateStaffList()" and closing the current form "AddStaff"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate required fields
        If txt_staffidbox.Text.Trim() = "" OrElse txt_firstnamebox.Text.Trim() = "" OrElse txt_surnamebox.Text.Trim() = "" Then
            MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Ensure Staff ID and Pay are numeric
        Dim staffID As Integer
        Dim payAmount As Integer

        If Not Integer.TryParse(txt_staffidbox.Text, staffID) Then
            MessageBox.Show("Invalid Staff ID. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Integer.TryParse(txt_paybox.Text, payAmount) Then
            MessageBox.Show("Invalid Pay Amount. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Determine if user is an Admin
        Dim isAdmin As Boolean = chk_makeadmin.Checked
        Dim userPassword As String = ""

        ' Only set password if Admin is checked
        If isAdmin Then
            If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                MessageBox.Show("Admin accounts require a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            userPassword = (TextBox1.Text) ' Hash password before saving
        End If

        ' Create new staff member
        Dim newStaff As New Staff_class With {
            .Staff_ID = staffID.ToString(),
            .FirstName = txt_firstnamebox.Text.Trim(),
            .Surname = txt_surnamebox.Text.Trim(),
            .Gender = txt_modgenderbox.Text.Trim(),
            .DOB = dtp_dob.Value.ToString("yyyy-MM-dd"),
            .Admin = isAdmin,
            .Skill1 = GetSkill(0),
            .Skill2 = GetSkill(1),
            .Skill3 = GetSkill(2),
            .Skill4 = GetSkill(3),
            .Skill5 = GetSkill(4),
            .Skill6 = GetSkill(5),
            .Pay = payAmount.ToString(),
            .Password = userPassword ' Only set if Admin
        }

        ' Add staff to the list (assuming staff_list exists in Form1)
        Form1.staff_list.Add(newStaff)

        ' Notify user
        MessageBox.Show("New staff member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Form1.UpdateStaffList()
        ' Close form after successful submission
        Me.Close()
    End Sub


    ' Function: GetSkill
    ' Inputs: an index as Integer
    ' Returns: A string representing the skill at the specified index
    '
    ' Environmental Effect:
    ' Retrieves a skill from TextBox2 based on the given index. If the index is invalid, it returns an empty string.
    Private Function GetSkill(index As Integer) As String
        Dim skills As String() = TextBox2.Lines ' Get all lines (skills) from TextBox2

        ' Check if the index is within range and if the skill at that index is not empty
        If skills.Length > index AndAlso Not String.IsNullOrWhiteSpace(skills(index)) Then
            Return skills(index).Trim()
        End If

        ' Return an empty string if the index is out of bounds or the skill is empty
        Return ""
    End Function


    ' Subroutine: Button2_Click
    ' Inputs: VB Button
    ' Returns: None
    '
    ' Environmental Effect:
    ' Closes This Form
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class
