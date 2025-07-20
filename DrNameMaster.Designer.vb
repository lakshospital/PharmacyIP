<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrNameMaster
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
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.txtDoctorName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New Glass.GlassButton
        Me.cmdSave = New Glass.GlassButton
        Me.cmdRemove = New Glass.GlassButton
        Me.cmdAdd = New Glass.GlassButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(13, 125)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(357, 355)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 10
        '
        'txtDoctorName
        '
        Me.txtDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDoctorName.Location = New System.Drawing.Point(97, 88)
        Me.txtDoctorName.Name = "txtDoctorName"
        Me.txtDoctorName.Size = New System.Drawing.Size(273, 20)
        Me.txtDoctorName.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Doctor Name"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.GlowColor = System.Drawing.Color.Yellow
        Me.cmdExit.Image = Global.Pharmacy.My.Resources.Resource1._Exit
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.Location = New System.Drawing.Point(396, 290)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(161, 62)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "E&xit"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdSave.ForeColor = System.Drawing.Color.Black
        Me.cmdSave.GlowColor = System.Drawing.Color.Yellow
        Me.cmdSave.Image = Global.Pharmacy.My.Resources.Resource1.Save
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(396, 222)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(161, 62)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Text = "&Save"
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRemove.ForeColor = System.Drawing.Color.Black
        Me.cmdRemove.GlowColor = System.Drawing.Color.Yellow
        Me.cmdRemove.Image = Global.Pharmacy.My.Resources.Resource1.Delete
        Me.cmdRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRemove.Location = New System.Drawing.Point(396, 154)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(161, 62)
        Me.cmdRemove.TabIndex = 11
        Me.cmdRemove.Text = "&Remove"
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdd.ForeColor = System.Drawing.Color.Black
        Me.cmdAdd.GlowColor = System.Drawing.Color.Yellow
        Me.cmdAdd.Image = Global.Pharmacy.My.Resources.Resource1._New
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(396, 84)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(161, 62)
        Me.cmdAdd.TabIndex = 9
        Me.cmdAdd.Text = "&Add"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(161, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(254, 31)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Doctor Name Master"
        '
        'DrNameMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(566, 525)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtDoctorName)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DrNameMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Doctor Name Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents cmdExit As Glass.GlassButton
    Friend WithEvents cmdSave As Glass.GlassButton
    Friend WithEvents cmdRemove As Glass.GlassButton
    Friend WithEvents cmdAdd As Glass.GlassButton
    Friend WithEvents txtDoctorName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
