<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sort
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_sort = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.sort_mode = New System.Windows.Forms.CheckedListBox()
        Me.combo_sortby = New System.Windows.Forms.ComboBox()
        Me.dgv_sorted = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIrst_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_surname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Age = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbi_admin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tbl_Skill1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_skill2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Skill3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Skill4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Skill5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Skill6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_ReverseSearch = New System.Windows.Forms.CheckBox()
        CType(Me.dgv_sorted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_sort
        '
        Me.btn_sort.Location = New System.Drawing.Point(12, 210)
        Me.btn_sort.Name = "btn_sort"
        Me.btn_sort.Size = New System.Drawing.Size(75, 23)
        Me.btn_sort.TabIndex = 0
        Me.btn_sort.Text = "Sort"
        Me.btn_sort.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(12, 239)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 1
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'sort_mode
        '
        Me.sort_mode.CheckOnClick = True
        Me.sort_mode.FormattingEnabled = True
        Me.sort_mode.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.sort_mode.Items.AddRange(New Object() {"Linier", "Binary"})
        Me.sort_mode.Location = New System.Drawing.Point(12, 152)
        Me.sort_mode.Name = "sort_mode"
        Me.sort_mode.Size = New System.Drawing.Size(120, 40)
        Me.sort_mode.TabIndex = 2
        '
        'combo_sortby
        '
        Me.combo_sortby.FormattingEnabled = True
        Me.combo_sortby.Items.AddRange(New Object() {"ID", "First Name", "Surname", "Gender", "Age", "Pay", "Admin", "Skills"})
        Me.combo_sortby.Location = New System.Drawing.Point(11, 98)
        Me.combo_sortby.Name = "combo_sortby"
        Me.combo_sortby.Size = New System.Drawing.Size(121, 23)
        Me.combo_sortby.TabIndex = 3
        '
        'dgv_sorted
        '
        Me.dgv_sorted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sorted.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.FIrst_Name, Me.tbl_surname, Me.tbl_Gender, Me.tbl_Age, Me.tbi_admin, Me.tbl_Skill1, Me.tbl_skill2, Me.tbl_Skill3, Me.tbl_Skill4, Me.tbl_Skill5, Me.tbl_Skill6})
        Me.dgv_sorted.Location = New System.Drawing.Point(138, 12)
        Me.dgv_sorted.Name = "dgv_sorted"
        Me.dgv_sorted.RowTemplate.Height = 25
        Me.dgv_sorted.Size = New System.Drawing.Size(546, 278)
        Me.dgv_sorted.TabIndex = 4
        '
        'ID
        '
        Me.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Width = 43
        '
        'FIrst_Name
        '
        Me.FIrst_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.FIrst_Name.HeaderText = "First Name"
        Me.FIrst_Name.Name = "FIrst_Name"
        Me.FIrst_Name.Width = 89
        '
        'tbl_surname
        '
        Me.tbl_surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_surname.HeaderText = "Surname"
        Me.tbl_surname.Name = "tbl_surname"
        Me.tbl_surname.Width = 79
        '
        'tbl_Gender
        '
        Me.tbl_Gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Gender.HeaderText = "Gender"
        Me.tbl_Gender.Name = "tbl_Gender"
        Me.tbl_Gender.Width = 70
        '
        'tbl_Age
        '
        Me.tbl_Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Age.HeaderText = "Age"
        Me.tbl_Age.Name = "tbl_Age"
        Me.tbl_Age.Width = 53
        '
        'tbi_admin
        '
        Me.tbi_admin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbi_admin.HeaderText = "Admin"
        Me.tbi_admin.Name = "tbi_admin"
        Me.tbi_admin.Width = 49
        '
        'tbl_Skill1
        '
        Me.tbl_Skill1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill1.HeaderText = "Skill 1"
        Me.tbl_Skill1.Name = "tbl_Skill1"
        Me.tbl_Skill1.Width = 62
        '
        'tbl_skill2
        '
        Me.tbl_skill2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_skill2.HeaderText = "Skill 2"
        Me.tbl_skill2.Name = "tbl_skill2"
        Me.tbl_skill2.Width = 62
        '
        'tbl_Skill3
        '
        Me.tbl_Skill3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill3.HeaderText = "Skill 3"
        Me.tbl_Skill3.Name = "tbl_Skill3"
        Me.tbl_Skill3.Width = 62
        '
        'tbl_Skill4
        '
        Me.tbl_Skill4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill4.HeaderText = "Skill 4"
        Me.tbl_Skill4.Name = "tbl_Skill4"
        Me.tbl_Skill4.Width = 62
        '
        'tbl_Skill5
        '
        Me.tbl_Skill5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill5.HeaderText = "Skill 5"
        Me.tbl_Skill5.Name = "tbl_Skill5"
        Me.tbl_Skill5.Width = 62
        '
        'tbl_Skill6
        '
        Me.tbl_Skill6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill6.HeaderText = "Skill 6"
        Me.tbl_Skill6.Name = "tbl_Skill6"
        Me.tbl_Skill6.Width = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 40.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 72)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Sort"
        '
        'btn_ReverseSearch
        '
        Me.btn_ReverseSearch.AutoSize = True
        Me.btn_ReverseSearch.Location = New System.Drawing.Point(15, 193)
        Me.btn_ReverseSearch.Name = "btn_ReverseSearch"
        Me.btn_ReverseSearch.Size = New System.Drawing.Size(104, 19)
        Me.btn_ReverseSearch.TabIndex = 6
        Me.btn_ReverseSearch.Text = "Reverse Search"
        Me.btn_ReverseSearch.UseVisualStyleBackColor = True
        '
        'Sort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 302)
        Me.Controls.Add(Me.btn_ReverseSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_sorted)
        Me.Controls.Add(Me.combo_sortby)
        Me.Controls.Add(Me.sort_mode)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_sort)
        Me.Name = "Sort"
        Me.Text = "Sort"
        CType(Me.dgv_sorted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_sort As Button
    Friend WithEvents btn_cancel As Button
    Friend WithEvents sort_mode As CheckedListBox
    Friend WithEvents combo_sortby As ComboBox
    Friend WithEvents dgv_sorted As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents FIrst_Name As DataGridViewTextBoxColumn
    Friend WithEvents tbl_surname As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Gender As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Age As DataGridViewTextBoxColumn
    Friend WithEvents tbi_admin As DataGridViewCheckBoxColumn
    Friend WithEvents tbl_Skill1 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_skill2 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Skill3 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Skill4 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Skill5 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Skill6 As DataGridViewTextBoxColumn
    Friend WithEvents btn_ReverseSearch As CheckBox
End Class
