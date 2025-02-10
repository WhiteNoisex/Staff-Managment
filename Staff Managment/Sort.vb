Public Class Sort



    Dim mode As String


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sorted.CellContentClick

    End Sub

    Private Sub btn_sort_Click(sender As Object, e As EventArgs) Handles btn_sort.Click
        'dgv_sorted.Rows.Add(1)
        'dgv_sorted.Rows.Insert(dgv_sorted.Rows.GetRowCount() + 1,)
        For index = 0 To Form1.staff_list.Count - 1
            dgv_sorted.Rows.Add(Form1.staff_list(index).FirstName & " " & Form1.staff_list(index).Surname)
            'MessageBox.Show(staff_list(index).FirstName & " " & staff_list(index).Surname)
        Next

        If dgv_sorted.Rows.Count > 0 Then
            dgv_sorted.Text = dgv_sorted.Rows(0).ToString() ' Sets the text to the first item
        End If



        If mode = "Lin" Then

        ElseIf mode = "Bub" Then
            sort_bubble(0)
            'MessageBox.Show("Error reading XML file: ")
        Else
            Return
        End If

    End Sub

    Private Sub sort_bubble(columnIndex As Integer)
        Dim rows As Integer = dgv_sorted.Rows.Count - 1
        Dim tempStaffID As String
        Dim tempFirstName As String
        Dim tempSurname As String
        Dim tempGender As String
        Dim tempDOB As String
        Dim tempPay As String
        Dim tempAdmin As Boolean

        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To rows - i - 1
                If dgv_sorted.Rows(j).Cells(columnIndex).Value.ToString() > dgv_sorted.Rows(j + 1).Cells(columnIndex).Value.ToString() Then
                    ' Swap rows
                    tempStaffID = dgv_sorted.Rows(j).Cells(0).Value.ToString()
                    tempFirstName = dgv_sorted.Rows(j).Cells(1).Value.ToString()
                    tempSurname = dgv_sorted.Rows(j).Cells(2).Value.ToString()
                    tempGender = dgv_sorted.Rows(j).Cells(3).Value.ToString()
                    tempDOB = dgv_sorted.Rows(j).Cells(4).Value.ToString()
                    tempPay = dgv_sorted.Rows(j).Cells(5).Value.ToString()
                    tempAdmin = dgv_sorted.Rows(j).Cells(6).Value

                    dgv_sorted.Rows(j).Cells(0).Value = dgv_sorted.Rows(j + 1).Cells(0).Value.ToString()
                    dgv_sorted.Rows(j).Cells(1).Value = dgv_sorted.Rows(j + 1).Cells(1).Value.ToString()
                    dgv_sorted.Rows(j).Cells(2).Value = dgv_sorted.Rows(j + 1).Cells(2).Value.ToString()
                    dgv_sorted.Rows(j).Cells(3).Value = dgv_sorted.Rows(j + 1).Cells(3).Value.ToString()
                    dgv_sorted.Rows(j).Cells(4).Value = dgv_sorted.Rows(j + 1).Cells(4).Value.ToString()
                    dgv_sorted.Rows(j).Cells(5).Value = dgv_sorted.Rows(j + 1).Cells(5).Value.ToString()
                    dgv_sorted.Rows(j).Cells(6).Value = dgv_sorted.Rows(j + 1).Cells(6).Value

                    dgv_sorted.Rows(j + 1).Cells(0).Value = tempStaffID
                    dgv_sorted.Rows(j + 1).Cells(1).Value = tempFirstName
                    dgv_sorted.Rows(j + 1).Cells(2).Value = tempSurname
                    dgv_sorted.Rows(j + 1).Cells(3).Value = tempGender
                    dgv_sorted.Rows(j + 1).Cells(4).Value = tempDOB
                    dgv_sorted.Rows(j + 1).Cells(5).Value = tempPay
                    dgv_sorted.Rows(j + 1).Cells(6).Value = tempAdmin
                End If
            Next
        Next
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles sort_mode.ItemCheck
        If e.NewValue = CheckState.Checked Then
            For i As Integer = 0 To sort_mode.Items.Count - 1
                If i <> e.Index Then
                    sort_mode.SetItemChecked(i, False)
                End If
            Next
        End If


        If e.NewValue = CheckState.Checked Then
            If (e.Index = 0) Then
                mode = "Lin"
            Else
                mode = "Bub"
            End If
        Else
            'MessageBox.Show("Item " & e.Index & " is unchecked")
        End If
    End Sub
End Class