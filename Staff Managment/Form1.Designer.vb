<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_logout = New System.Windows.Forms.Button()
        Me.btn_saveall = New System.Windows.Forms.Button()
        Me.btn_sort = New System.Windows.Forms.Button()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.btn_import = New System.Windows.Forms.Button()
        Me.btn_removestaff = New System.Windows.Forms.Button()
        Me.btn_addstaff = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_skillsbox = New System.Windows.Forms.TextBox()
        Me.btn_modpsw = New System.Windows.Forms.Button()
        Me.dtp_dob = New System.Windows.Forms.DateTimePicker()
        Me.btn_selleft = New System.Windows.Forms.Button()
        Me.btn_selright = New System.Windows.Forms.Button()
        Me.drp_staff = New System.Windows.Forms.ComboBox()
        Me.btn_modstaff = New System.Windows.Forms.Button()
        Me.chk_makeadmin = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_surnamebox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_modgenderbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_paybox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_firstnamebox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_staffidbox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.btn_logout)
        Me.Panel1.Controls.Add(Me.btn_saveall)
        Me.Panel1.Controls.Add(Me.btn_sort)
        Me.Panel1.Controls.Add(Me.btn_search)
        Me.Panel1.Controls.Add(Me.btn_export)
        Me.Panel1.Controls.Add(Me.btn_import)
        Me.Panel1.Controls.Add(Me.btn_removestaff)
        Me.Panel1.Controls.Add(Me.btn_addstaff)
        Me.Panel1.Location = New System.Drawing.Point(12, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(128, 259)
        Me.Panel1.TabIndex = 1
        '
        'btn_logout
        '
        Me.btn_logout.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.btn_logout.FlatAppearance.BorderSize = 0
        Me.btn_logout.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_logout.Location = New System.Drawing.Point(11, 231)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(111, 22)
        Me.btn_logout.TabIndex = 7
        Me.btn_logout.Text = "Logout"
        Me.btn_logout.UseVisualStyleBackColor = False
        '
        'btn_saveall
        '
        Me.btn_saveall.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.btn_saveall.FlatAppearance.BorderSize = 0
        Me.btn_saveall.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_saveall.Location = New System.Drawing.Point(11, 185)
        Me.btn_saveall.Name = "btn_saveall"
        Me.btn_saveall.Size = New System.Drawing.Size(111, 22)
        Me.btn_saveall.TabIndex = 6
        Me.btn_saveall.Text = "Save All"
        Me.btn_saveall.UseVisualStyleBackColor = False
        '
        'btn_sort
        '
        Me.btn_sort.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.btn_sort.FlatAppearance.BorderSize = 0
        Me.btn_sort.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_sort.Location = New System.Drawing.Point(11, 157)
        Me.btn_sort.Name = "btn_sort"
        Me.btn_sort.Size = New System.Drawing.Size(111, 22)
        Me.btn_sort.TabIndex = 5
        Me.btn_sort.Text = "Sort"
        Me.btn_sort.UseVisualStyleBackColor = False
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.btn_search.FlatAppearance.BorderSize = 0
        Me.btn_search.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_search.Location = New System.Drawing.Point(11, 129)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(111, 22)
        Me.btn_search.TabIndex = 4
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.btn_export.FlatAppearance.BorderSize = 0
        Me.btn_export.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_export.Location = New System.Drawing.Point(11, 101)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(111, 22)
        Me.btn_export.TabIndex = 3
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'btn_import
        '
        Me.btn_import.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.btn_import.FlatAppearance.BorderSize = 0
        Me.btn_import.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_import.Location = New System.Drawing.Point(11, 73)
        Me.btn_import.Name = "btn_import"
        Me.btn_import.Size = New System.Drawing.Size(111, 22)
        Me.btn_import.TabIndex = 2
        Me.btn_import.Text = "Import"
        Me.btn_import.UseVisualStyleBackColor = False
        '
        'btn_removestaff
        '
        Me.btn_removestaff.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.btn_removestaff.FlatAppearance.BorderSize = 0
        Me.btn_removestaff.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_removestaff.Location = New System.Drawing.Point(11, 45)
        Me.btn_removestaff.Name = "btn_removestaff"
        Me.btn_removestaff.Size = New System.Drawing.Size(111, 22)
        Me.btn_removestaff.TabIndex = 1
        Me.btn_removestaff.Text = "Remove Staff"
        Me.btn_removestaff.UseVisualStyleBackColor = False
        '
        'btn_addstaff
        '
        Me.btn_addstaff.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.btn_addstaff.FlatAppearance.BorderSize = 0
        Me.btn_addstaff.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_addstaff.Location = New System.Drawing.Point(11, 17)
        Me.btn_addstaff.Name = "btn_addstaff"
        Me.btn_addstaff.Size = New System.Drawing.Size(111, 22)
        Me.btn_addstaff.TabIndex = 0
        Me.btn_addstaff.Text = "Add Staff"
        Me.btn_addstaff.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.Controls.Add(Me.txt_skillsbox)
        Me.Panel2.Controls.Add(Me.btn_modpsw)
        Me.Panel2.Controls.Add(Me.dtp_dob)
        Me.Panel2.Controls.Add(Me.btn_selleft)
        Me.Panel2.Controls.Add(Me.btn_selright)
        Me.Panel2.Controls.Add(Me.drp_staff)
        Me.Panel2.Controls.Add(Me.btn_modstaff)
        Me.Panel2.Controls.Add(Me.chk_makeadmin)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_surnamebox)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txt_modgenderbox)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txt_paybox)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txt_firstnamebox)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txt_staffidbox)
        Me.Panel2.Location = New System.Drawing.Point(146, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(468, 259)
        Me.Panel2.TabIndex = 2
        '
        'txt_skillsbox
        '
        Me.txt_skillsbox.Location = New System.Drawing.Point(268, 90)
        Me.txt_skillsbox.Multiline = True
        Me.txt_skillsbox.Name = "txt_skillsbox"
        Me.txt_skillsbox.Size = New System.Drawing.Size(165, 131)
        Me.txt_skillsbox.TabIndex = 21
        '
        'btn_modpsw
        '
        Me.btn_modpsw.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_modpsw.Location = New System.Drawing.Point(95, 231)
        Me.btn_modpsw.Name = "btn_modpsw"
        Me.btn_modpsw.Size = New System.Drawing.Size(129, 23)
        Me.btn_modpsw.TabIndex = 20
        Me.btn_modpsw.Text = "Change Password"
        Me.btn_modpsw.UseVisualStyleBackColor = True
        '
        'dtp_dob
        '
        Me.dtp_dob.CustomFormat = "DD/MM/YYYY"
        Me.dtp_dob.Enabled = False
        Me.dtp_dob.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dob.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtp_dob.Location = New System.Drawing.Point(149, 204)
        Me.dtp_dob.Name = "dtp_dob"
        Me.dtp_dob.Size = New System.Drawing.Size(100, 23)
        Me.dtp_dob.TabIndex = 4
        '
        'btn_selleft
        '
        Me.btn_selleft.FlatAppearance.BorderSize = 0
        Me.btn_selleft.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btn_selleft.Location = New System.Drawing.Point(13, 31)
        Me.btn_selleft.Name = "btn_selleft"
        Me.btn_selleft.Size = New System.Drawing.Size(36, 24)
        Me.btn_selleft.TabIndex = 19
        Me.btn_selleft.Text = "<"
        Me.btn_selleft.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_selleft.UseVisualStyleBackColor = True
        '
        'btn_selright
        '
        Me.btn_selright.FlatAppearance.BorderSize = 0
        Me.btn_selright.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btn_selright.Location = New System.Drawing.Point(268, 31)
        Me.btn_selright.Name = "btn_selright"
        Me.btn_selright.Size = New System.Drawing.Size(36, 24)
        Me.btn_selright.TabIndex = 18
        Me.btn_selright.Text = ">"
        Me.btn_selright.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_selright.UseVisualStyleBackColor = True
        '
        'drp_staff
        '
        Me.drp_staff.FormattingEnabled = True
        Me.drp_staff.Location = New System.Drawing.Point(55, 32)
        Me.drp_staff.Name = "drp_staff"
        Me.drp_staff.Size = New System.Drawing.Size(207, 23)
        Me.drp_staff.TabIndex = 17
        '
        'btn_modstaff
        '
        Me.btn_modstaff.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.btn_modstaff.Location = New System.Drawing.Point(333, 233)
        Me.btn_modstaff.Name = "btn_modstaff"
        Me.btn_modstaff.Size = New System.Drawing.Size(100, 23)
        Me.btn_modstaff.TabIndex = 15
        Me.btn_modstaff.Text = "Modify Staff"
        Me.btn_modstaff.UseVisualStyleBackColor = True
        '
        'chk_makeadmin
        '
        Me.chk_makeadmin.AutoSize = True
        Me.chk_makeadmin.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.chk_makeadmin.Location = New System.Drawing.Point(15, 234)
        Me.chk_makeadmin.Name = "chk_makeadmin"
        Me.chk_makeadmin.Size = New System.Drawing.Size(62, 19)
        Me.chk_makeadmin.TabIndex = 14
        Me.chk_makeadmin.Text = "Admin"
        Me.chk_makeadmin.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Yu Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label7.Location = New System.Drawing.Point(268, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Skills"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(149, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Date Of Birth"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(149, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Surname"
        '
        'txt_surnamebox
        '
        Me.txt_surnamebox.Location = New System.Drawing.Point(149, 149)
        Me.txt_surnamebox.Name = "txt_surnamebox"
        Me.txt_surnamebox.ReadOnly = True
        Me.txt_surnamebox.Size = New System.Drawing.Size(100, 23)
        Me.txt_surnamebox.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Yu Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(149, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Gender"
        '
        'txt_modgenderbox
        '
        Me.txt_modgenderbox.Location = New System.Drawing.Point(149, 90)
        Me.txt_modgenderbox.Name = "txt_modgenderbox"
        Me.txt_modgenderbox.ReadOnly = True
        Me.txt_modgenderbox.Size = New System.Drawing.Size(100, 23)
        Me.txt_modgenderbox.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(10, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Pay"
        '
        'txt_paybox
        '
        Me.txt_paybox.Location = New System.Drawing.Point(10, 204)
        Me.txt_paybox.Name = "txt_paybox"
        Me.txt_paybox.ReadOnly = True
        Me.txt_paybox.Size = New System.Drawing.Size(100, 23)
        Me.txt_paybox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(10, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "First Name"
        '
        'txt_firstnamebox
        '
        Me.txt_firstnamebox.Location = New System.Drawing.Point(10, 149)
        Me.txt_firstnamebox.Name = "txt_firstnamebox"
        Me.txt_firstnamebox.ReadOnly = True
        Me.txt_firstnamebox.Size = New System.Drawing.Size(100, 23)
        Me.txt_firstnamebox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(10, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Staff ID"
        '
        'txt_staffidbox
        '
        Me.txt_staffidbox.Location = New System.Drawing.Point(10, 90)
        Me.txt_staffidbox.Name = "txt_staffidbox"
        Me.txt_staffidbox.ReadOnly = True
        Me.txt_staffidbox.Size = New System.Drawing.Size(100, 23)
        Me.txt_staffidbox.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label8.Font = New System.Drawing.Font("Snap ITC", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(99, -8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(454, 35)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Jbrezzy Mangment Console"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 31)
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(586, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 286)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(803, 316)
        Me.Panel3.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(800, 310)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_addstaff As Button
    Friend WithEvents btn_saveall As Button
    Friend WithEvents btn_sort As Button
    Friend WithEvents btn_search As Button
    Friend WithEvents btn_export As Button
    Friend WithEvents btn_import As Button
    Friend WithEvents btn_removestaff As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_surnamebox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_modgenderbox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_paybox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_firstnamebox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_staffidbox As TextBox
    Friend WithEvents drp_staff As ComboBox
    Friend WithEvents btn_modstaff As Button
    Friend WithEvents chk_makeadmin As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents btn_selleft As Button
    Friend WithEvents btn_selright As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_logout As Button
    Friend WithEvents btn_modpsw As Button
    Friend WithEvents dtp_dob As DateTimePicker
    Friend WithEvents txt_skillsbox As TextBox
    Friend WithEvents Panel3 As Panel
End Class
