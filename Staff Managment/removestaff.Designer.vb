<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class removestaff
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
        Me.dgv_sorted = New System.Windows.Forms.DataGridView()
        Me.btn_removestaff = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIrst_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_surname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_Age = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_pay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbi_admin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_confirm = New System.Windows.Forms.Button()
        CType(Me.dgv_sorted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_sorted
        '
        Me.dgv_sorted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sorted.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btn_removestaff, Me.ID, Me.FIrst_Name, Me.tbl_surname, Me.tbl_Gender, Me.tbl_Age, Me.col_pay, Me.tbi_admin})
        Me.dgv_sorted.Location = New System.Drawing.Point(12, 12)
        Me.dgv_sorted.Name = "dgv_sorted"
        Me.dgv_sorted.RowTemplate.Height = 25
        Me.dgv_sorted.Size = New System.Drawing.Size(526, 278)
        Me.dgv_sorted.TabIndex = 12
        '
        'btn_removestaff
        '
        Me.btn_removestaff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.btn_removestaff.HeaderText = "Fire"
        Me.btn_removestaff.Name = "btn_removestaff"
        Me.btn_removestaff.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_removestaff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_removestaff.Width = 51
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
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(12, 296)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(107, 40)
        Me.btn_Cancel.TabIndex = 13
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_confirm
        '
        Me.btn_confirm.BackColor = System.Drawing.Color.IndianRed
        Me.btn_confirm.Location = New System.Drawing.Point(430, 296)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(107, 40)
        Me.btn_confirm.TabIndex = 14
        Me.btn_confirm.Text = "Confirm"
        Me.btn_confirm.UseVisualStyleBackColor = False
        '
        'removestaff
        '
        Me.AcceptButton = Me.btn_confirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Cancel
        Me.ClientSize = New System.Drawing.Size(549, 342)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_confirm)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.dgv_sorted)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "removestaff"
        Me.Text = "removestaff"
        CType(Me.dgv_sorted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_sorted As DataGridView
    Friend WithEvents btn_removestaff As DataGridViewCheckBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents FIrst_Name As DataGridViewTextBoxColumn
    Friend WithEvents tbl_surname As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Gender As DataGridViewTextBoxColumn
    Friend WithEvents tbl_Age As DataGridViewTextBoxColumn
    Friend WithEvents col_pay As DataGridViewTextBoxColumn
    Friend WithEvents tbi_admin As DataGridViewCheckBoxColumn
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_confirm As Button
End Class
