<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductMaster
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
        Me.components = New System.ComponentModel.Container
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtProductName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMinimumStockToMaintain = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GlassButton1 = New Glass.GlassButton
        Me.cmdShow = New Glass.GlassButton
        Me.cmdEdit = New Glass.GlassButton
        Me.cmdNew = New Glass.GlassButton
        Me.drpProductGroup = New System.Windows.Forms.ComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtRackNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.drpDoctorName = New System.Windows.Forms.ComboBox
        Me.drpCombination = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtManufacturer = New System.Windows.Forms.TextBox
        Me.lblScheduleH = New System.Windows.Forms.Label
        Me.drpScheduleH = New System.Windows.Forms.ComboBox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(470, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.TabStop = False
        Me.Button1.Text = "&Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.SystemColors.Window
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(219, 94)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(233, 20)
        Me.txtProductName.TabIndex = 0
        Me.txtProductName.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(261, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(191, 31)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Product Master"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(121, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Product Name"
        '
        'txtMinimumStockToMaintain
        '
        Me.txtMinimumStockToMaintain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinimumStockToMaintain.Location = New System.Drawing.Point(219, 188)
        Me.txtMinimumStockToMaintain.Name = "txtMinimumStockToMaintain"
        Me.txtMinimumStockToMaintain.Size = New System.Drawing.Size(116, 20)
        Me.txtMinimumStockToMaintain.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(121, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 30)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Minimum Stock to Maintain"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(121, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "ProductGroup"
        '
        'GlassButton1
        '
        Me.GlassButton1.BackColor = System.Drawing.Color.SteelBlue
        Me.GlassButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GlassButton1.ForeColor = System.Drawing.Color.Black
        Me.GlassButton1.GlowColor = System.Drawing.Color.Yellow
        Me.GlassButton1.Image = Global.Pharmacy.My.Resources.Resource1._Exit
        Me.GlassButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GlassButton1.Location = New System.Drawing.Point(241, 462)
        Me.GlassButton1.Name = "GlassButton1"
        Me.GlassButton1.Size = New System.Drawing.Size(172, 66)
        Me.GlassButton1.TabIndex = 10
        Me.GlassButton1.Text = "E&xit"
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.Image = Global.Pharmacy.My.Resources.Resource1.Search
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(419, 390)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(172, 66)
        Me.cmdShow.TabIndex = 9
        Me.cmdShow.Text = "&Show"
        '
        'cmdEdit
        '
        Me.cmdEdit.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.ForeColor = System.Drawing.Color.Black
        Me.cmdEdit.GlowColor = System.Drawing.Color.Yellow
        Me.cmdEdit.Image = Global.Pharmacy.My.Resources.Resource1.Edit
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(241, 390)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(172, 66)
        Me.cmdEdit.TabIndex = 8
        Me.cmdEdit.Text = "&Edit"
        '
        'cmdNew
        '
        Me.cmdNew.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNew.ForeColor = System.Drawing.Color.Black
        Me.cmdNew.GlowColor = System.Drawing.Color.Yellow
        Me.cmdNew.Image = Global.Pharmacy.My.Resources.Resource1._New
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.Location = New System.Drawing.Point(63, 390)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(172, 66)
        Me.cmdNew.TabIndex = 7
        Me.cmdNew.Text = "&New"
        '
        'drpProductGroup
        '
        Me.drpProductGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.drpProductGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpProductGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpProductGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductGroup.FormattingEnabled = True
        Me.drpProductGroup.Location = New System.Drawing.Point(219, 124)
        Me.drpProductGroup.Name = "drpProductGroup"
        Me.drpProductGroup.Size = New System.Drawing.Size(231, 21)
        Me.drpProductGroup.TabIndex = 2
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtRackNo
        '
        Me.txtRackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRackNo.Location = New System.Drawing.Point(219, 156)
        Me.txtRackNo.Name = "txtRackNo"
        Me.txtRackNo.Size = New System.Drawing.Size(116, 20)
        Me.txtRackNo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(121, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Rack No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Doctor Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(121, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Combination"
        '
        'drpDoctorName
        '
        Me.drpDoctorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.drpDoctorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpDoctorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpDoctorName.FormattingEnabled = True
        Me.drpDoctorName.Location = New System.Drawing.Point(219, 221)
        Me.drpDoctorName.Name = "drpDoctorName"
        Me.drpDoctorName.Size = New System.Drawing.Size(231, 21)
        Me.drpDoctorName.TabIndex = 5
        '
        'drpCombination
        '
        Me.drpCombination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.drpCombination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpCombination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpCombination.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpCombination.FormattingEnabled = True
        Me.drpCombination.Location = New System.Drawing.Point(219, 253)
        Me.drpCombination.Name = "drpCombination"
        Me.drpCombination.Size = New System.Drawing.Size(231, 21)
        Me.drpCombination.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(121, 292)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Manufacturer"
        '
        'txtManufacturer
        '
        Me.txtManufacturer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManufacturer.Location = New System.Drawing.Point(219, 289)
        Me.txtManufacturer.Name = "txtManufacturer"
        Me.txtManufacturer.Size = New System.Drawing.Size(231, 20)
        Me.txtManufacturer.TabIndex = 52
        '
        'lblScheduleH
        '
        Me.lblScheduleH.AutoSize = True
        Me.lblScheduleH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScheduleH.Location = New System.Drawing.Point(121, 323)
        Me.lblScheduleH.Name = "lblScheduleH"
        Me.lblScheduleH.Size = New System.Drawing.Size(69, 13)
        Me.lblScheduleH.TabIndex = 53
        Me.lblScheduleH.Text = "ScheduleH"
        '
        'drpScheduleH
        '
        Me.drpScheduleH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpScheduleH.FormattingEnabled = True
        Me.drpScheduleH.Items.AddRange(New Object() {"YES", "NO"})
        Me.drpScheduleH.Location = New System.Drawing.Point(219, 323)
        Me.drpScheduleH.Name = "drpScheduleH"
        Me.drpScheduleH.Size = New System.Drawing.Size(121, 21)
        Me.drpScheduleH.TabIndex = 54
        '
        'ProductMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(866, 622)
        Me.Controls.Add(Me.drpScheduleH)
        Me.Controls.Add(Me.lblScheduleH)
        Me.Controls.Add(Me.txtManufacturer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.drpCombination)
        Me.Controls.Add(Me.drpDoctorName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRackNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.drpProductGroup)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GlassButton1)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.txtMinimumStockToMaintain)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProductMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProductMaster"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GlassButton1 As Glass.GlassButton
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents cmdEdit As Glass.GlassButton
    Friend WithEvents cmdNew As Glass.GlassButton
    Friend WithEvents txtMinimumStockToMaintain As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents drpProductGroup As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtRackNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents drpCombination As System.Windows.Forms.ComboBox
    Friend WithEvents drpDoctorName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtManufacturer As System.Windows.Forms.TextBox
    Friend WithEvents lblScheduleH As System.Windows.Forms.Label
    Friend WithEvents drpScheduleH As System.Windows.Forms.ComboBox
End Class
