﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_sorted = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIrst_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_surname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Age = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_pay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbi_admin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tbl_Skill1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_skill2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Skill3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Skill4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Skill5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Skill6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.combo_sortby = New System.Windows.Forms.ComboBox()
        Me.sort_mode = New System.Windows.Forms.CheckedListBox()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_sort = New System.Windows.Forms.Button()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_searchtime = New System.Windows.Forms.Label()
        CType(Me.dgv_sorted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 46)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Search"
        '
        'dgv_sorted
        '
        Me.dgv_sorted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sorted.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.FIrst_Name, Me.tbl_surname, Me.tbl_Gender, Me.tbl_Age, Me.col_pay, Me.tbi_admin, Me.tbl_Skill1, Me.tbl_skill2, Me.tbl_Skill3, Me.tbl_Skill4, Me.tbl_Skill5, Me.tbl_Skill6})
        Me.dgv_sorted.Location = New System.Drawing.Point(142, 12)
        Me.dgv_sorted.Name = "dgv_sorted"
        Me.dgv_sorted.RowTemplate.Height = 25
        Me.dgv_sorted.Size = New System.Drawing.Size(547, 278)
        Me.dgv_sorted.TabIndex = 11
        '
        'ID
        '
        Me.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 43
        '
        'FIrst_Name
        '
        Me.FIrst_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.FIrst_Name.HeaderText = "First Name"
        Me.FIrst_Name.Name = "FIrst_Name"
        Me.FIrst_Name.ReadOnly = True
        Me.FIrst_Name.Width = 89
        '
        'tbl_surname
        '
        Me.tbl_surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_surname.HeaderText = "Surname"
        Me.tbl_surname.Name = "tbl_surname"
        Me.tbl_surname.ReadOnly = True
        Me.tbl_surname.Width = 79
        '
        'tbl_Gender
        '
        Me.tbl_Gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Gender.HeaderText = "Gender"
        Me.tbl_Gender.Name = "tbl_Gender"
        Me.tbl_Gender.ReadOnly = True
        Me.tbl_Gender.Width = 70
        '
        'tbl_Age
        '
        Me.tbl_Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Age.HeaderText = "Age"
        Me.tbl_Age.Name = "tbl_Age"
        Me.tbl_Age.ReadOnly = True
        Me.tbl_Age.Width = 53
        '
        'col_pay
        '
        Me.col_pay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col_pay.HeaderText = "Pay"
        Me.col_pay.Name = "col_pay"
        Me.col_pay.ReadOnly = True
        Me.col_pay.Width = 51
        '
        'tbi_admin
        '
        Me.tbi_admin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbi_admin.HeaderText = "Admin"
        Me.tbi_admin.Name = "tbi_admin"
        Me.tbi_admin.ReadOnly = True
        Me.tbi_admin.Width = 49
        '
        'tbl_Skill1
        '
        Me.tbl_Skill1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill1.HeaderText = "Skill 1"
        Me.tbl_Skill1.Name = "tbl_Skill1"
        Me.tbl_Skill1.ReadOnly = True
        Me.tbl_Skill1.Width = 62
        '
        'tbl_skill2
        '
        Me.tbl_skill2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_skill2.HeaderText = "Skill 2"
        Me.tbl_skill2.Name = "tbl_skill2"
        Me.tbl_skill2.ReadOnly = True
        Me.tbl_skill2.Width = 62
        '
        'tbl_Skill3
        '
        Me.tbl_Skill3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill3.HeaderText = "Skill 3"
        Me.tbl_Skill3.Name = "tbl_Skill3"
        Me.tbl_Skill3.ReadOnly = True
        Me.tbl_Skill3.Width = 62
        '
        'tbl_Skill4
        '
        Me.tbl_Skill4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill4.HeaderText = "Skill 4"
        Me.tbl_Skill4.Name = "tbl_Skill4"
        Me.tbl_Skill4.ReadOnly = True
        Me.tbl_Skill4.Width = 62
        '
        'tbl_Skill5
        '
        Me.tbl_Skill5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill5.HeaderText = "Skill 5"
        Me.tbl_Skill5.Name = "tbl_Skill5"
        Me.tbl_Skill5.ReadOnly = True
        Me.tbl_Skill5.Width = 62
        '
        'tbl_Skill6
        '
        Me.tbl_Skill6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tbl_Skill6.HeaderText = "Skill 6"
        Me.tbl_Skill6.Name = "tbl_Skill6"
        Me.tbl_Skill6.ReadOnly = True
        Me.tbl_Skill6.Width = 62
        '
        'combo_sortby
        '
        Me.combo_sortby.FormattingEnabled = True
        Me.combo_sortby.Items.AddRange(New Object() {"ID", "First Name", "Surname", "Gender", "Age", "Pay", "Admin", "Skills"})
        Me.combo_sortby.Location = New System.Drawing.Point(15, 98)
        Me.combo_sortby.Name = "combo_sortby"
        Me.combo_sortby.Size = New System.Drawing.Size(121, 23)
        Me.combo_sortby.TabIndex = 10
        '
        'sort_mode
        '
        Me.sort_mode.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.sort_mode.CheckOnClick = True
        Me.sort_mode.FormattingEnabled = True
        Me.sort_mode.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.sort_mode.Items.AddRange(New Object() {"Linier", "Binary"})
        Me.sort_mode.Location = New System.Drawing.Point(16, 164)
        Me.sort_mode.Name = "sort_mode"
        Me.sort_mode.Size = New System.Drawing.Size(120, 40)
        Me.sort_mode.TabIndex = 9
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(16, 239)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 8
        Me.btn_cancel.Text = "Reset"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_sort
        '
        Me.btn_sort.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btn_sort.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btn_sort.FlatAppearance.BorderSize = 2
        Me.btn_sort.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_sort.Location = New System.Drawing.Point(16, 210)
        Me.btn_sort.Name = "btn_sort"
        Me.btn_sort.Size = New System.Drawing.Size(75, 23)
        Me.btn_sort.TabIndex = 7
        Me.btn_sort.Text = "Sort"
        Me.btn_sort.UseVisualStyleBackColor = False
        '
        'txt_search
        '
        Me.txt_search.Location = New System.Drawing.Point(15, 127)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(121, 23)
        Me.txt_search.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Search Duration:"
        '
        'txt_searchtime
        '
        Me.txt_searchtime.AutoSize = True
        Me.txt_searchtime.Location = New System.Drawing.Point(15, 70)
        Me.txt_searchtime.Name = "txt_searchtime"
        Me.txt_searchtime.Size = New System.Drawing.Size(49, 15)
        Me.txt_searchtime.TabIndex = 15
        Me.txt_searchtime.Text = "00:00:00"
        '
        'Search
        '
        Me.AcceptButton = Me.btn_sort
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CancelButton = Me.btn_cancel
        Me.ClientSize = New System.Drawing.Size(701, 301)
        Me.Controls.Add(Me.txt_searchtime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_sorted)
        Me.Controls.Add(Me.combo_sortby)
        Me.Controls.Add(Me.sort_mode)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_sort)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "Search"
        Me.ShowIcon = False
        Me.Text = "Search"
        CType(Me.dgv_sorted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgv_sorted As DataGridView
    Friend WithEvents combo_sortby As ComboBox
    Friend WithEvents sort_mode As CheckedListBox
    Friend WithEvents btn_cancel As Button
    Friend WithEvents btn_sort As Button
    Friend WithEvents txt_search As TextBox
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents FIrst_Name As DataGridViewTextBoxColumn
    Friend WithEvents tbl_surname As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Gender As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Age As DataGridViewTextBoxColumn
    Friend WithEvents col_pay As DataGridViewTextBoxColumn
    Friend WithEvents tbi_admin As DataGridViewCheckBoxColumn
    Friend WithEvents tbl_Skill1 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_skill2 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Skill3 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Skill4 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Skill5 As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Skill6 As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_searchtime As Label
End Class
