<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Admin = New System.Windows.Forms.RadioButton()
        Me.User = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdCancel = New Glass.GlassButton()
        Me.cmdLogin = New Glass.GlassButton()
        Me.Pharmacy = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(140, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(140, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Login as"
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.Location = New System.Drawing.Point(143, 42)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(183, 20)
        Me.UsernameTextBox.TabIndex = 1
        Me.UsernameTextBox.Text = "user"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.Location = New System.Drawing.Point(143, 92)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(36)
        Me.PasswordTextBox.ShortcutsEnabled = False
        Me.PasswordTextBox.Size = New System.Drawing.Size(183, 20)
        Me.PasswordTextBox.TabIndex = 2
        Me.PasswordTextBox.Text = "user"
        '
        'Admin
        '
        Me.Admin.AutoSize = True
        Me.Admin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Admin.Location = New System.Drawing.Point(311, 151)
        Me.Admin.Name = "Admin"
        Me.Admin.Size = New System.Drawing.Size(59, 17)
        Me.Admin.TabIndex = 4
        Me.Admin.Text = "Admin"
        Me.Admin.UseVisualStyleBackColor = True
        '
        'User
        '
        Me.User.AutoSize = True
        Me.User.Checked = True
        Me.User.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.User.Location = New System.Drawing.Point(146, 151)
        Me.User.Name = "User"
        Me.User.Size = New System.Drawing.Size(51, 17)
        Me.User.TabIndex = 3
        Me.User.TabStop = True
        Me.User.Text = "User"
        Me.User.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Pharmacy.My.Resources.Resource1.UserIco
        Me.PictureBox1.Location = New System.Drawing.Point(2, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(132, 131)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.GlowColor = System.Drawing.Color.Yellow
        Me.cmdCancel.Image = Global.Pharmacy.My.Resources.Resource1._Exit
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(517, 21)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(168, 60)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "E&xit"
        '
        'cmdLogin
        '
        Me.cmdLogin.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLogin.ForeColor = System.Drawing.Color.Black
        Me.cmdLogin.GlowColor = System.Drawing.Color.Yellow
        Me.cmdLogin.Image = Global.Pharmacy.My.Resources.Resource1.Ok
        Me.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogin.Location = New System.Drawing.Point(343, 21)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(168, 60)
        Me.cmdLogin.TabIndex = 5
        Me.cmdLogin.Text = "&Login"
        '
        'Pharmacy
        '
        Me.Pharmacy.AutoSize = True
        Me.Pharmacy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pharmacy.Location = New System.Drawing.Point(213, 151)
        Me.Pharmacy.Name = "Pharmacy"
        Me.Pharmacy.Size = New System.Drawing.Size(80, 17)
        Me.Pharmacy.TabIndex = 8
        Me.Pharmacy.Text = "Pharmacy"
        Me.Pharmacy.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(402, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 26)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "V: 11/DEC/2024"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(696, 262)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Pharmacy)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.User)
        Me.Controls.Add(Me.Admin)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Admin As System.Windows.Forms.RadioButton
    Friend WithEvents User As System.Windows.Forms.RadioButton
    Friend WithEvents cmdLogin As Glass.GlassButton
    Friend WithEvents cmdCancel As Glass.GlassButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Pharmacy As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
