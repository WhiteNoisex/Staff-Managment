Public Class Sort



    Dim mode As String


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sorted.CellContentClick

    End Sub

    Private Sub btn_sort_Click(sender As Object, e As EventArgs) Handles btn_sort.Click
        'dgv_sorted.Rows.Add(1)
        'dgv_sorted.Rows.Insert(dgv_sorted.Rows.GetRowCount() + 1,)
        dgv_sorted.Rows.Clear()
        For index = 0 To Form1.staff_list.Count - 1
            dgv_sorted.Rows.Add(Form1.staff_list(index).Staff_ID, Form1.staff_list(index).FirstName, Form1.staff_list(index).Surname, Form1.staff_list(index).Gender,
                                Form1.staff_list(index).DOB, Form1.staff_list(index).Pay, Form1.staff_list(index).Admin, Form1.staff_list(index).Skill1, Form1.staff_list(index).Skill2, Form1.staff_list(index).Skill3, Form1.staff_list(index).Skill4,
                                Form1.staff_list(index).Skill5, Form1.staff_list(index).Skill6)
            'MessageBox.Show(staff_list(index).FirstName & " " & staff_list(index).Surname)
        Next

        If dgv_sorted.Rows.Count > 0 Then
            dgv_sorted.Text = dgv_sorted.Rows(0).ToString() ' Sets the text to the first item
        End If

        If mode = "Lin" Then
            'sort_bubble(1)
            sort_selection(combo_sortby.SelectedIndex)
            Return
        ElseIf mode = "Bub" Then


            sort_bubble(combo_sortby.SelectedIndex)
            'MessageBox.Show("Error reading XML file: ")
            Return
        Else
            Return
        End If

    End Sub

    Private Sub sort_bubble(columnIndex As Integer)
        Dim rows As Integer = dgv_sorted.Rows.Count - 1

        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To rows - i - 1
                Dim value1 As Object = dgv_sorted.Rows(j).Cells(columnIndex).Value
                Dim value2 As Object = dgv_sorted.Rows(j + 1).Cells(columnIndex).Value

                ' Convert to strings for proper comparison
                Dim strValue1 As String = If(value1 IsNot Nothing, value1.ToString(), "")
                Dim strValue2 As String = If(value2 IsNot Nothing, value2.ToString(), "")

                ' Sorting in ascending order
                If String.Compare(strValue1, strValue2) > 0 Then
                    ' Swap entire rows
                    For col As Integer = 0 To dgv_sorted.Columns.Count - 1
                        Dim temp As Object = dgv_sorted.Rows(j).Cells(col).Value
                        dgv_sorted.Rows(j).Cells(col).Value = dgv_sorted.Rows(j + 1).Cells(col).Value
                        dgv_sorted.Rows(j + 1).Cells(col).Value = temp
                    Next
                End If
            Next
        Next
    End Sub

    ' Selection Sort: Finds the smallest element and swaps it to the front
    Private Sub sort_selection(columnIndex As Integer)
        Dim rows As Integer = dgv_sorted.Rows.Count - 1

        For i As Integer = 0 To rows - 1
            Dim minIndex As Integer = i
            For j As Integer = i + 1 To rows
                Dim value1 As Object = dgv_sorted.Rows(j).Cells(columnIndex).Value
                Dim value2 As Object = dgv_sorted.Rows(minIndex).Cells(columnIndex).Value

                ' Convert to strings for comparison
                Dim strValue1 As String = If(value1 IsNot Nothing, value1.ToString(), "")
                Dim strValue2 As String = If(value2 IsNot Nothing, value2.ToString(), "")

                If String.Compare(strValue1, strValue2) < 0 Then
                    minIndex = j
                End If
            Next

            ' Swap rows
            If minIndex <> i Then
                For col As Integer = 0 To dgv_sorted.Columns.Count - 1
                    Dim temp As Object = dgv_sorted.Rows(i).Cells(col).Value
                    dgv_sorted.Rows(i).Cells(col).Value = dgv_sorted.Rows(minIndex).Cells(col).Value
                    dgv_sorted.Rows(minIndex).Cells(col).Value = temp
                Next
            End If
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

    Private Sub Sort_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo_sortby.DropDownStyle = ComboBoxStyle.DropDownList

        dgv_sorted.Rows.Clear()
        For index = 0 To Form1.staff_list.Count - 1
            dgv_sorted.Rows.Add(Form1.staff_list(index).Staff_ID, Form1.staff_list(index).FirstName, Form1.staff_list(index).Surname, Form1.staff_list(index).Gender,
                                Form1.staff_list(index).DOB, Form1.staff_list(index).Pay, Form1.staff_list(index).Admin, Form1.staff_list(index).Skill1, Form1.staff_list(index).Skill2, Form1.staff_list(index).Skill3, Form1.staff_list(index).Skill4,
                                Form1.staff_list(index).Skill5, Form1.staff_list(index).Skill6)
            'MessageBox.Show(staff_list(index).FirstName & " " & staff_list(index).Surname)
        Next

        combo_sortby.SelectedIndex = 0
        sort_mode.SetItemChecked(0, True)
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        dgv_sorted.Rows.Clear()
        For index = 0 To Form1.staff_list.Count - 1
            dgv_sorted.Rows.Add(Form1.staff_list(index).Staff_ID, Form1.staff_list(index).FirstName, Form1.staff_list(index).Surname, Form1.staff_list(index).Gender,
                                Form1.staff_list(index).DOB, Form1.staff_list(index).Pay, Form1.staff_list(index).Admin, Form1.staff_list(index).Skill1, Form1.staff_list(index).Skill2, Form1.staff_list(index).Skill3, Form1.staff_list(index).Skill4,
                                Form1.staff_list(index).Skill5, Form1.staff_list(index).Skill6)
            'MessageBox.Show(staff_list(index).FirstName & " " & staff_list(index).Surname)
        Next
    End Sub

    Private Sub RemoveEmptyRows()
        ' Ensure all edits are committed before deleting
        If dgv_sorted.IsCurrentCellInEditMode Then
            dgv_sorted.EndEdit()
        End If
        dgv_sorted.CommitEdit(DataGridViewDataErrorContexts.Commit)

        ' Disable adding new rows temporarily to avoid conflicts
        Dim addNewRowEnabled As Boolean = dgv_sorted.AllowUserToAddRows
        dgv_sorted.AllowUserToAddRows = False

        ' Loop through the DataGridView from bottom to top
        For i As Integer = dgv_sorted.Rows.Count - 1 To 0 Step -1
            ' Skip the "new row" (if AllowUserToAddRows is enabled)
            If dgv_sorted.Rows(i).IsNewRow Then Continue For

            Dim isEmpty As Boolean = True

            ' Check if all cells in the row are empty
            For Each cell As DataGridViewCell In dgv_sorted.Rows(i).Cells
                If cell.Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cell.Value.ToString()) Then
                    isEmpty = False
                    Exit For ' Stop checking if any cell contains data
                End If
            Next

            ' Remove the row if it's empty
            If isEmpty Then
                dgv_sorted.Rows.RemoveAt(i)
            End If
        Next

        ' Restore the Add New Row functionality if it was enabled
        dgv_sorted.AllowUserToAddRows = addNewRowEnabled
    End Sub



    Private Sub btn_ReverseSearch_CheckedChanged(sender As Object, e As EventArgs) Handles btn_ReverseSearch.CheckedChanged
        ' Check if there are rows to reverse
        If dgv_sorted.Rows.Count = 0 Then Exit Sub

        ' Create a temporary list to store reversed rows
        Dim reversedRows As New List(Of DataGridViewRow)

        ' Loop through DataGridView rows in reverse order
        For index As Integer = dgv_sorted.Rows.Count - 1 To 0 Step -1
            ' Clone the row structure
            Dim newRow As DataGridViewRow = DirectCast(dgv_sorted.Rows(index).Clone(), DataGridViewRow)

            ' Copy cell values
            For col As Integer = 0 To dgv_sorted.Columns.Count - 1
                newRow.Cells(col).Value = dgv_sorted.Rows(index).Cells(col).Value
            Next

            reversedRows.Add(newRow)
        Next

        ' Clear the DataGridView before repopulating
        dgv_sorted.Rows.Clear()

        ' Add the reversed rows back
        For Each row As DataGridViewRow In reversedRows
            dgv_sorted.Rows.Add(row)
        Next

        RemoveEmptyRows()
    End Sub

End Class