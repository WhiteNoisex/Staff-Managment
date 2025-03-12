Imports Staff_Managment.TimerHelper
Public Class Search
    Dim mode As String
    Dim myStopwatch As New TimerHelper()

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sorted.CellContentClick

    End Sub

    Private Sub btn_sort_Click(sender As Object, e As EventArgs) Handles btn_sort.Click


        ' Start timer
        myStopwatch.StartTimer()

        ' Simulate some process
        'Threading.Thread.Sleep(2000) ' Simulate a 2-second delay

        ' Stop timer
        'myStopwatch.StopTimer()

        ' Display elapsed time
        'MessageBox.Show("Elapsed Time: " & myStopwatch.GetFormattedTime())




        'dgv_sorted.Rows.Add(1)
        'dgv_sorted.Rows.Insert(dgv_sorted.Rows.GetRowCount() + 1,)
        dgv_sorted.Rows.Clear()
        For index = 0 To Form1.staff_list.Count - 1
            dgv_sorted.Rows.Add(Form1.staff_list(index).Staff_ID, Form1.staff_list(index).FirstName, Form1.staff_list(index).Surname, Form1.staff_list(index).Gender,
                                DateDiff(DateInterval.Year, Form1.staff_list(index).DOB, Date.Today), Form1.staff_list(index).Pay, Form1.staff_list(index).Admin, Form1.staff_list(index).Skill1, Form1.staff_list(index).Skill2, Form1.staff_list(index).Skill3, Form1.staff_list(index).Skill4,
                                Form1.staff_list(index).Skill5, Form1.staff_list(index).Skill6)
            'MessageBox.Show(staff_list(index).FirstName & " " & staff_list(index).Surname)
        Next

        If dgv_sorted.Rows.Count > 0 Then
            dgv_sorted.Text = dgv_sorted.Rows(0).ToString() ' Sets the text to the first item
        End If

        If mode = "Lin" Then
            'sort_bubble(1)
            search_linear(combo_sortby.SelectedIndex, txt_search.Text, False, -1, "")
            Return
        ElseIf mode = "Bub" Then


            search_binary(combo_sortby.SelectedIndex, txt_search.Text, False, -1, "")
            'MessageBox.Show("Error reading XML file: ")
            Return
        Else
            Return
        End If

    End Sub
    ' Binary Search: Finds all matching records in a sorted dataset
    ' Binary Search: Finds all matching records in a sorted dataset
    ' Optimized Binary Search using UserClass.Swap
    Private Sub search_binary(columnIndex As Integer, searchValue As String, useNarrowingCriteria As Boolean, narrowingCriteriaColumn As Integer, narrowingCriteriaValue As String)
        Dim left As Integer = 0
        Dim right As Integer = dgv_sorted.Rows.Count - 1
        Dim results As New List(Of DataGridViewRow)

        ' Perform binary search to find a match
        While left <= right
            Dim mid As Integer = (left + right) \ 2
            Dim midValue As Object = dgv_sorted.Rows(mid).Cells(columnIndex).Value
            Dim midStr As String = If(midValue IsNot Nothing, midValue.ToString(), "")

            Dim comparison As Integer = String.Compare(midStr, searchValue)

            If comparison = 0 Then
                ' Add all matching results
                AddMatchingResults(columnIndex, searchValue, useNarrowingCriteria, narrowingCriteriaColumn, narrowingCriteriaValue, results)
                Exit While ' Stop searching
            ElseIf comparison < 0 Then
                Staff_class.Swap(left, mid) ' Swap for optimization (if needed)
                left += 1 ' Search right half
            Else
                Staff_class.Swap(right, mid) ' Swap for optimization (if needed)
                right -= 1 ' Search left half
            End If
        End While

        ' Fill results table
        FillResultsTable(results)
    End Sub

    ' Optimized Linear Search using UserClass.Swap
    Private Sub search_linear(columnIndex As Integer, searchValue As String, useNarrowingCriteria As Boolean, narrowingCriteriaColumn As Integer, narrowingCriteriaValue As String)

        Dim results As New List(Of DataGridViewRow)

        ' Scan each row for a match
        For i As Integer = 0 To dgv_sorted.Rows.Count - 1
            Dim cellValue As Object = dgv_sorted.Rows(i).Cells(columnIndex).Value
            Dim strValue As String = If(cellValue IsNot Nothing, cellValue.ToString(), "")

            If strValue = searchValue Then
                ' Add matching row to results if criteria matches or is ignored
                Dim row As DataGridViewRow = dgv_sorted.Rows(i)
                If Not useNarrowingCriteria OrElse MatchesCriteria(row, narrowingCriteriaColumn, narrowingCriteriaValue) Then
                    results.Add(row)
                End If
            End If
        Next

        ' Fill results table
        FillResultsTable(results)
    End Sub

    ' Finds all matching results (used in binary search)
    Private Sub AddMatchingResults(columnIndex As Integer, searchValue As String, useNarrowingCriteria As Boolean, narrowingCriteriaColumn As Integer, narrowingCriteriaValue As String, results As List(Of DataGridViewRow))
        ' Search through all rows for matching values
        For i As Integer = 0 To dgv_sorted.Rows.Count - 1
            Dim cellValue As Object = dgv_sorted.Rows(i).Cells(columnIndex).Value
            Dim strValue As String = If(cellValue IsNot Nothing, cellValue.ToString(), "")

            If strValue = searchValue Then
                Dim row As DataGridViewRow = dgv_sorted.Rows(i)
                If Not useNarrowingCriteria OrElse MatchesCriteria(row, narrowingCriteriaColumn, narrowingCriteriaValue) Then
                    results.Add(row)
                End If
            End If
        Next
    End Sub

    ' Checks if a row matches the narrowing criteria
    Private Function MatchesCriteria(row As DataGridViewRow, narrowingCriteriaColumn As Integer, narrowingCriteriaValue As String) As Boolean
        Dim criteriaValue As String = If(row.Cells(narrowingCriteriaColumn).Value IsNot Nothing, row.Cells(narrowingCriteriaColumn).Value.ToString(), "")
        Return criteriaValue = narrowingCriteriaValue
    End Function

    ' Fills the results DataGridView with the found matches
    Private Sub FillResultsTable(results As List(Of DataGridViewRow))
        myStopwatch.StopTimer()
        txt_searchtime.Text = myStopwatch.GetFormattedTime
        myStopwatch.ResetTimer()

        dgv_sorted.Rows.Clear()

        For Each row As DataGridViewRow In results
            Dim newRow As DataGridViewRow = dgv_sorted.Rows(dgv_sorted.Rows.Add())

            ' Copy each cell from the original row to the results table
            For col As Integer = 0 To dgv_sorted.Columns.Count - 1
                newRow.Cells(col).Value = row.Cells(col).Value
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

    Private Sub Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo_sortby.DropDownStyle = ComboBoxStyle.DropDownList

        dgv_sorted.Rows.Clear()
        For index = 0 To Form1.staff_list.Count - 1
            dgv_sorted.Rows.Add(Form1.staff_list(index).Staff_ID, Form1.staff_list(index).FirstName, Form1.staff_list(index).Surname, Form1.staff_list(index).Gender,
                                DateDiff(DateInterval.Year, Form1.staff_list(index).DOB, Date.Today), Form1.staff_list(index).Pay, Form1.staff_list(index).Admin, Form1.staff_list(index).Skill1, Form1.staff_list(index).Skill2, Form1.staff_list(index).Skill3, Form1.staff_list(index).Skill4,
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
                                DateDiff(DateInterval.Year, Form1.staff_list(index).DOB, Date.Today), Form1.staff_list(index).Pay, Form1.staff_list(index).Admin, Form1.staff_list(index).Skill1, Form1.staff_list(index).Skill2, Form1.staff_list(index).Skill3, Form1.staff_list(index).Skill4,
                                Form1.staff_list(index).Skill5, Form1.staff_list(index).Skill6)
            'MessageBox.Show(staff_list(index).FirstName & " " & staff_list(index).Surname)
        Next
    End Sub
End Class