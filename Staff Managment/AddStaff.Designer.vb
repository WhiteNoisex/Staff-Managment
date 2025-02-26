<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddStaff
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
        Me.dtp_dob = New System.Windows.Forms.DateTimePicker()
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'dtp_dob
        '
        Me.dtp_dob.CustomFormat = "DD/MM/YYYY"
        Me.dtp_dob.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dob.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtp_dob.Location = New System.Drawing.Point(163, 191)
        Me.dtp_dob.Name = "dtp_dob"
        Me.dtp_dob.Size = New System.Drawing.Size(100, 23)
        Me.dtp_dob.TabIndex = 6
        '
        'chk_makeadmin
        '
        Me.chk_makeadmin.AutoSize = True
        Me.chk_makeadmin.Location = New System.Drawing.Point(141, 236)
        Me.chk_makeadmin.Name = "chk_makeadmin"
        Me.chk_makeadmin.Size = New System.Drawing.Size(62, 19)
        Me.chk_makeadmin.TabIndex = 8
        Me.chk_makeadmin.Text = "Admin"
        Me.chk_makeadmin.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(282, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 15)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Skills"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(163, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Date Of Birth"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(163, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Surname"
        '
        'txt_surnamebox
        '
        Me.txt_surnamebox.Location = New System.Drawing.Point(163, 136)
        Me.txt_surnamebox.MaxLength = 10
        Me.txt_surnamebox.Name = "txt_surnamebox"
        Me.txt_surnamebox.PlaceholderText = "Doe"
        Me.txt_surnamebox.Size = New System.Drawing.Size(100, 23)
        Me.txt_surnamebox.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(163, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Gender"
        '
        'txt_modgenderbox
        '
        Me.txt_modgenderbox.Location = New System.Drawing.Point(163, 77)
        Me.txt_modgenderbox.MaxLength = 100
        Me.txt_modgenderbox.Name = "txt_modgenderbox"
        Me.txt_modgenderbox.PlaceholderText = "Male"
        Me.txt_modgenderbox.Size = New System.Drawing.Size(100, 23)
        Me.txt_modgenderbox.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Pay"
        '
        'txt_paybox
        '
        Me.txt_paybox.Location = New System.Drawing.Point(24, 191)
        Me.txt_paybox.MaxLength = 10
        Me.txt_paybox.Name = "txt_paybox"
        Me.txt_paybox.PlaceholderText = "$$$"
        Me.txt_paybox.Size = New System.Drawing.Size(100, 23)
        Me.txt_paybox.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "First Name"
        '
        'txt_firstnamebox
        '
        Me.txt_firstnamebox.Location = New System.Drawing.Point(24, 136)
        Me.txt_firstnamebox.MaxLength = 10
        Me.txt_firstnamebox.Name = "txt_firstnamebox"
        Me.txt_firstnamebox.PlaceholderText = "John"
        Me.txt_firstnamebox.Size = New System.Drawing.Size(100, 23)
        Me.txt_firstnamebox.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Staff ID"
        '
        'txt_staffidbox
        '
        Me.txt_staffidbox.Location = New System.Drawing.Point(24, 77)
        Me.txt_staffidbox.MaxLength = 100
        Me.txt_staffidbox.Name = "txt_staffidbox"
        Me.txt_staffidbox.PlaceholderText = "000001"
        Me.txt_staffidbox.Size = New System.Drawing.Size(100, 23)
        Me.txt_staffidbox.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("SimSun-ExtG", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(24, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(376, 35)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Create Staff Member"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Button1.Location = New System.Drawing.Point(331, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 43)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Create"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Button2.Location = New System.Drawing.Point(209, 221)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 43)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 218)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 15)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Password"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(26, 236)
        Me.TextBox1.MaxLength = 10
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 23)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.UseSystemPasswordChar = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(282, 77)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(165, 131)
        Me.TextBox2.TabIndex = 7
        '
        'AddStaff
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(461, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtp_dob)
        Me.Controls.Add(Me.chk_makeadmin)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_surnamebox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_modgenderbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_paybox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_firstnamebox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_staffidbox)
        Me.MaximizeBox = False
        Me.Name = "AddStaff"
        Me.Text = "AddStaff"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtp_dob As DateTimePicker
    Friend WithEvents chk_makeadmin As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
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
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
End Class
