Public Class ChangePasswordForm



    ' Subroutine: Reset_Click
    ' Inputs: VB Button
    ' Returns: None
    '
    ' Environmental Effect:
    ' Replaces users password field with password from dialog
    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click

        'MessageBox.Show("Hello")

        ' Validate password fields
        If txt_PSW1.Text = "" Or txt_PSW2.Text = "" Then
            MessageBox.Show("Password fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Check if passwords match
        If txt_PSW1.Text <> txt_PSW2.Text Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Store the new password (you should hash it before saving)
        Form1.staff_list(Form1.drp_staff.SelectedIndex).Password = txt_PSW1.Text

        ' Confirm password change
        MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Close the form
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class