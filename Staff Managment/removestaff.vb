Public Class removestaff

    Private Sub removestaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_sorted.Rows.Clear()
        For index = 0 To Form1.staff_list.Count - 1
            dgv_sorted.Rows.Add(False, Form1.staff_list(index).Staff_ID, Form1.staff_list(index).FirstName, Form1.staff_list(index).Surname, Form1.staff_list(index).Gender,
                                Form1.staff_list(index).DOB, Form1.staff_list(index).Pay, Form1.staff_list(index).Admin)
            'MessageBox.Show(staff_list(index).FirstName & " " & staff_list(index).Surname)
        Next
    End Sub


    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Try


            Dim result As DialogResult
            result = MessageBox.Show("Are you sure you want to continue?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Store the indices to remove in a separate list
                Dim indicesToRemove As New List(Of Integer)

                ' Iterate over the DataGridView in reverse order to avoid index shifting
                For i As Integer = dgv_sorted.Rows.Count - 1 To 0 Step -1
                    Dim row As DataGridViewRow = dgv_sorted.Rows(i)

                    If row.Cells("btn_removestaff").Value IsNot Nothing AndAlso row.Cells("btn_removestaff").Value = True Then
                        ' Remove user from UserManager only if Admin is enabled
                        If Convert.ToBoolean(row.Cells("tbi_admin").Value) Then
                            UserManager.RemoveUser(row.Cells("FIrst_Name").Value.ToString()) ' Fixed column name
                        End If

                        ' Store the index to remove from staff_list
                        indicesToRemove.Add(i)
                    End If
                Next

                ' Remove users from the staff list in reverse order
                For i As Integer = indicesToRemove.Count - 1 To 0 Step -1
                    Form1.staff_list.RemoveAt(indicesToRemove(i))
                Next

                ' Refresh the DataGridView
                Form1.UpdateStaffList()
                dgv_sorted.Rows.Clear()
                For index = 0 To Form1.staff_list.Count - 1
                    dgv_sorted.Rows.Add(False, Form1.staff_list(index).Staff_ID, Form1.staff_list(index).FirstName, Form1.staff_list(index).Surname, Form1.staff_list(index).Gender,
                                    Form1.staff_list(index).DOB, Form1.staff_list(index).Pay, Form1.staff_list(index).Admin)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("The Application Has Failed To Run Function 'btn_confirm_Click' please Contect Admins: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Me.Hide()
        Form1.Show()

    End Sub
End Class