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
    Public Property Password As String

    ' Method to parse DataGridViewRow into Staff_class object
    Shared Sub Swap(Of T)(ByRef a As T, ByRef b As T)
        Dim temp As T = a
        a = b
        b = temp
    End Sub

End Class