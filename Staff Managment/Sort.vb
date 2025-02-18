Public Class Sort
    Dim mode As String = "Lin" ' Default mode

    Private Sub btn_sort_Click(sender As Object, e As EventArgs) Handles btn_sort.Click
        ' Clear and reload DataGridView
        dgv_sorted.Rows.Clear()
        For Each staff In Form1.staff_list
            dgv_sorted.Rows.Add(staff.Staff_ID, staff.FirstName, staff.Surname, staff.Gender,
                                staff.DOB, staff.Pay, staff.Admin, staff.Skill1, staff.Skill2,
                                staff.Skill3, staff.Skill4, staff.Skill5, staff.Skill6)
        Next

        ' Ensure a valid sorting column is selected
        If combo_sortby.SelectedIndex < 0 Then
            MessageBox.Show("Please select a column to sort by.", "Sort Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform sorting based on selected mode
        If mode = "Lin" Then
            sort_selection(combo_sortby.SelectedIndex)
        ElseIf mode = "Bub" Then
            sort_bubble(combo_sortby.SelectedIndex)
        End If
    End Sub

    ' 🟢 Improved Bubble Sort (Handles Numeric and Null Values)
    Private Sub sort_bubble(columnIndex As Integer)
        Dim rows As Integer = dgv_sorted.Rows.Count - 1

        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To rows - i - 1
                Dim value1 As Object = dgv_sorted.Rows(j).Cells(columnIndex).Value
                Dim value2 As Object = dgv_sorted.Rows(j + 1).Cells(columnIndex).Value

                ' Convert to proper types for comparison
                Dim strValue1 As String = If(value1 IsNot Nothing, value1.ToString(), "")
                Dim strValue2 As String = If(value2 IsNot Nothing, value2.ToString(), "")

                ' Handle numeric sorting
                Dim num1, num2 As Double
                Dim isNumeric1 As Boolean = Double.TryParse(strValue1, num1)
                Dim isNumeric2 As Boolean = Double.TryParse(strValue2, num2)

                ' Determine the sorting logic
                Dim shouldSwap As Boolean
                If isNumeric1 AndAlso isNumeric2 Then
                    shouldSwap = num1 > num2 ' Compare as numbers
                Else
                    shouldSwap = String.Compare(strValue1, strValue2, StringComparison.OrdinalIgnoreCase) > 0
                End If

                ' Swap rows if needed
                If shouldSwap Then
                    SwapRows(j, j + 1)
                End If
            Next
        Next
    End Sub

    ' 🟢 Improved Selection Sort (Handles Numeric and Null Values)
    Private Sub sort_selection(columnIndex As Integer)
        Dim rows As Integer = dgv_sorted.Rows.Count - 1

        For i As Integer = 0 To rows - 1
            Dim minIndex As Integer = i
            For j As Integer = i + 1 To rows
                Dim value1 As Object = dgv_sorted.Rows(j).Cells(columnIndex).Value
                Dim value2 As Object = dgv_sorted.Rows(minIndex).Cells(columnIndex).Value

                ' Convert to proper types for comparison
                Dim strValue1 As String = If(value1 IsNot Nothing, value1.ToString(), "")
                Dim strValue2 As String = If(value2 IsNot Nothing, value2.ToString(), "")

                ' Handle numeric sorting
                Dim num1, num2 As Double
                Dim isNumeric1 As Boolean = Double.TryParse(strValue1, num1)
                Dim isNumeric2 As Boolean = Double.TryParse(strValue2, num2)

                ' Determine the sorting logic
                Dim shouldSwap As Boolean
                If isNumeric1 AndAlso isNumeric2 Then
                    shouldSwap = num1 < num2 ' Compare as numbers
                Else
                    shouldSwap = String.Compare(strValue1, strValue2, StringComparison.OrdinalIgnoreCase) < 0
                End If

                If shouldSwap Then
                    minIndex = j
                End If
            Next

            ' Swap rows if needed
            If minIndex <> i Then
                SwapRows(i, minIndex)
            End If
        Next
    End Sub

    ' 🔄 Helper Function: Swap Two Rows in DataGridView
    Private Sub SwapRows(row1 As Integer, row2 As Integer)
        For col As Integer = 0 To dgv_sorted.Columns.Count - 1
            Dim temp As Object = dgv_sorted.Rows(row1).Cells(col).Value
            dgv_sorted.Rows(row1).Cells(col).Value = dgv_sorted.Rows(row2).Cells(col).Value
            dgv_sorted.Rows(row2).Cells(col).Value = temp
        Next
    End Sub

    ' Ensures only one sort mode is selected at a time
    Private Sub sort_mode_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles sort_mode.ItemCheck
        If e.NewValue = CheckState.Checked Then
            For i As Integer = 0 To sort_mode.Items.Count - 1
                If i <> e.Index Then
                    sort_mode.SetItemChecked(i, False)
                End If
            Next
        End If

        If e.NewValue = CheckState.Checked Then
            mode = If(e.Index = 0, "Lin", "Bub")
        End If
    End Sub

    ' On Form Load, populate the DataGridView
    Private Sub Sort_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo_sortby.DropDownStyle = ComboBoxStyle.DropDownList
        ReloadDataGridView()
        combo_sortby.SelectedIndex = 0
        sort_mode.SetItemChecked(0, True)
    End Sub

    ' Function to reload DataGridView
    Private Sub ReloadDataGridView()
        dgv_sorted.Rows.Clear()
        For Each staff In Form1.staff_list
            dgv_sorted.Rows.Add(staff.Staff_ID, staff.FirstName, staff.Surname, staff.Gender,
                                staff.DOB, staff.Pay, staff.Admin, staff.Skill1, staff.Skill2,
                                staff.Skill3, staff.Skill4, staff.Skill5, staff.Skill6)
        Next
    End Sub

    ' Reverse the sorted results
    Private Sub btn_ReverseSearch_CheckedChanged(sender As Object, e As EventArgs) Handles btn_ReverseSearch.CheckedChanged
        If dgv_sorted.Rows.Count = 0 Then Exit Sub

        ' Temporarily disable AllowUserToAddRows to prevent empty row issues
        Dim addNewRowEnabled As Boolean = dgv_sorted.AllowUserToAddRows
        dgv_sorted.AllowUserToAddRows = False

        ' Reverse the rows without creating empty rows
        Dim reversedRows = dgv_sorted.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).Reverse().ToList()

        ' Clear the DataGridView before repopulating
        dgv_sorted.Rows.Clear()

        ' Add the reversed rows back
        For Each row In reversedRows
            Dim newRow As DataGridViewRow = dgv_sorted.Rows(dgv_sorted.Rows.Add())
            For col As Integer = 0 To dgv_sorted.Columns.Count - 1
                newRow.Cells(col).Value = row.Cells(col).Value
            Next
        Next

        ' Restore the Add New Row functionality if it was enabled
        dgv_sorted.AllowUserToAddRows = addNewRowEnabled
    End Sub

End Class
