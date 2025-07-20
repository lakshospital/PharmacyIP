<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesReturn
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesReturn))
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtVat = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtExpDate = New System.Windows.Forms.DateTimePicker
        Me.txtRackNo = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.txtReturnQty = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtMRP = New System.Windows.Forms.TextBox
        Me.txtBatch = New System.Windows.Forms.TextBox
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.drpProductName = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtBillDate = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtSalesBillNo = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCase = New System.Windows.Forms.TextBox
        Me.txtDrName = New System.Windows.Forms.TextBox
        Me.txtPatientName = New System.Windows.Forms.TextBox
        Me.txtReturnBillNo = New System.Windows.Forms.TextBox
        Me.UserControl11 = New Pharmacy.UserControl1
        Me.txtPatientID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblGrandTotal = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExpDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MRP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalReturn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdExit = New Glass.GlassButton
        Me.cmdShow = New Glass.GlassButton
        Me.cmdReturn = New Glass.GlassButton
        Me.cmdNext = New Glass.GlassButton
        Me.lblReturnGrandTotal = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SandyBrown
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(312, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(171, 18)
        Me.Label17.TabIndex = 98
        Me.Label17.Text = "InvoiceNo"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVat
        '
        Me.txtVat.BackColor = System.Drawing.Color.LightPink
        Me.txtVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVat.Location = New System.Drawing.Point(253, 76)
        Me.txtVat.Name = "txtVat"
        Me.txtVat.ReadOnly = True
        Me.txtVat.Size = New System.Drawing.Size(84, 20)
        Me.txtVat.TabIndex = 88
        Me.txtVat.TabStop = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SandyBrown
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(254, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 18)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "VAT(%)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SandyBrown
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(343, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 18)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "MRP"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtExpDate
        '
        Me.txtExpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtExpDate.Location = New System.Drawing.Point(141, 75)
        Me.txtExpDate.Name = "txtExpDate"
        Me.txtExpDate.Size = New System.Drawing.Size(106, 20)
        Me.txtExpDate.TabIndex = 104
        '
        'txtRackNo
        '
        Me.txtRackNo.BackColor = System.Drawing.Color.GreenYellow
        Me.txtRackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRackNo.Location = New System.Drawing.Point(656, 26)
        Me.txtRackNo.Name = "txtRackNo"
        Me.txtRackNo.ReadOnly = True
        Me.txtRackNo.Size = New System.Drawing.Size(99, 20)
        Me.txtRackNo.TabIndex = 102
        Me.txtRackNo.TabStop = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SandyBrown
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(656, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 18)
        Me.Label19.TabIndex = 103
        Me.Label19.Text = "RackNo"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtInvoiceNo)
        Me.Panel2.Controls.Add(Me.txtReturnQty)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtExpDate)
        Me.Panel2.Controls.Add(Me.txtRackNo)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtVat)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtMRP)
        Me.Panel2.Controls.Add(Me.txtBatch)
        Me.Panel2.Controls.Add(Me.txtQty)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.drpProductName)
        Me.Panel2.Location = New System.Drawing.Point(46, 151)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(810, 108)
        Me.Panel2.TabIndex = 104
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.Location = New System.Drawing.Point(312, 26)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.ReadOnly = True
        Me.txtInvoiceNo.Size = New System.Drawing.Size(172, 20)
        Me.txtInvoiceNo.TabIndex = 107
        '
        'txtReturnQty
        '
        Me.txtReturnQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnQty.Location = New System.Drawing.Point(561, 27)
        Me.txtReturnQty.Name = "txtReturnQty"
        Me.txtReturnQty.Size = New System.Drawing.Size(89, 20)
        Me.txtReturnQty.TabIndex = 105
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SandyBrown
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(561, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 18)
        Me.Label18.TabIndex = 106
        Me.Label18.Text = "Return Qty"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMRP
        '
        Me.txtMRP.BackColor = System.Drawing.Color.LightPink
        Me.txtMRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMRP.Location = New System.Drawing.Point(343, 75)
        Me.txtMRP.Name = "txtMRP"
        Me.txtMRP.ReadOnly = True
        Me.txtMRP.Size = New System.Drawing.Size(140, 20)
        Me.txtMRP.TabIndex = 89
        Me.txtMRP.TabStop = False
        '
        'txtBatch
        '
        Me.txtBatch.BackColor = System.Drawing.Color.LightPink
        Me.txtBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBatch.Location = New System.Drawing.Point(1, 75)
        Me.txtBatch.Name = "txtBatch"
        Me.txtBatch.ReadOnly = True
        Me.txtBatch.Size = New System.Drawing.Size(133, 20)
        Me.txtBatch.TabIndex = 86
        Me.txtBatch.TabStop = False
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(489, 27)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(68, 20)
        Me.txtQty.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SandyBrown
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(140, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 18)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "Exp.Date"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SandyBrown
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 18)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "Batch No"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SandyBrown
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(489, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 18)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Qty"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SandyBrown
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(305, 18)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Product Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'drpProductName
        '
        Me.drpProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.drpProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductName.FormattingEnabled = True
        Me.drpProductName.Location = New System.Drawing.Point(1, 26)
        Me.drpProductName.Name = "drpProductName"
        Me.drpProductName.Size = New System.Drawing.Size(306, 21)
        Me.drpProductName.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtBillDate)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txtSalesBillNo)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtCase)
        Me.Panel1.Controls.Add(Me.txtDrName)
        Me.Panel1.Controls.Add(Me.txtPatientName)
        Me.Panel1.Controls.Add(Me.txtReturnBillNo)
        Me.Panel1.Controls.Add(Me.UserControl11)
        Me.Panel1.Controls.Add(Me.txtPatientID)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(46, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(877, 102)
        Me.Panel1.TabIndex = 103
        '
        'txtBillDate
        '
        Me.txtBillDate.BackColor = System.Drawing.Color.GreenYellow
        Me.txtBillDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillDate.Location = New System.Drawing.Point(426, 12)
        Me.txtBillDate.Name = "txtBillDate"
        Me.txtBillDate.ReadOnly = True
        Me.txtBillDate.Size = New System.Drawing.Size(189, 20)
        Me.txtBillDate.TabIndex = 118
        Me.txtBillDate.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(325, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 13)
        Me.Label20.TabIndex = 117
        Me.Label20.Text = "Sales Bill Date"
        '
        'txtSalesBillNo
        '
        Me.txtSalesBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesBillNo.Location = New System.Drawing.Point(88, 12)
        Me.txtSalesBillNo.Name = "txtSalesBillNo"
        Me.txtSalesBillNo.Size = New System.Drawing.Size(223, 20)
        Me.txtSalesBillNo.TabIndex = 116
        Me.txtSalesBillNo.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 115
        Me.Label15.Text = "Sales Bill No"
        '
        'txtCase
        '
        Me.txtCase.Location = New System.Drawing.Point(619, 69)
        Me.txtCase.Name = "txtCase"
        Me.txtCase.ReadOnly = True
        Me.txtCase.Size = New System.Drawing.Size(247, 20)
        Me.txtCase.TabIndex = 114
        '
        'txtDrName
        '
        Me.txtDrName.Location = New System.Drawing.Point(619, 39)
        Me.txtDrName.Name = "txtDrName"
        Me.txtDrName.ReadOnly = True
        Me.txtDrName.Size = New System.Drawing.Size(247, 20)
        Me.txtDrName.TabIndex = 113
        '
        'txtPatientName
        '
        Me.txtPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientName.Location = New System.Drawing.Point(410, 69)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.ReadOnly = True
        Me.txtPatientName.Size = New System.Drawing.Size(144, 20)
        Me.txtPatientName.TabIndex = 3
        Me.txtPatientName.TabStop = False
        '
        'txtReturnBillNo
        '
        Me.txtReturnBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnBillNo.Location = New System.Drawing.Point(88, 42)
        Me.txtReturnBillNo.Name = "txtReturnBillNo"
        Me.txtReturnBillNo.Size = New System.Drawing.Size(223, 20)
        Me.txtReturnBillNo.TabIndex = 0
        Me.txtReturnBillNo.TabStop = False
        '
        'UserControl11
        '
        Me.UserControl11.Location = New System.Drawing.Point(386, 42)
        Me.UserControl11.Name = "UserControl11"
        Me.UserControl11.Size = New System.Drawing.Size(150, 26)
        Me.UserControl11.TabIndex = 14
        Me.UserControl11.TabStop = False
        '
        'txtPatientID
        '
        Me.txtPatientID.BackColor = System.Drawing.Color.GreenYellow
        Me.txtPatientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientID.Location = New System.Drawing.Point(87, 70)
        Me.txtPatientID.Name = "txtPatientID"
        Me.txtPatientID.ReadOnly = True
        Me.txtPatientID.Size = New System.Drawing.Size(224, 20)
        Me.txtPatientID.TabIndex = 112
        Me.txtPatientID.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(325, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Patient Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(560, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Case"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(555, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Dr. Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Patient ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(325, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Bill Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Return Bill No"
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.Red
        Me.lblGrandTotal.Location = New System.Drawing.Point(881, 514)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(0, 24)
        Me.lblGrandTotal.TabIndex = 102
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(699, 522)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(166, 20)
        Me.Label16.TabIndex = 101
        Me.Label16.Text = "Grand Total (Sales)"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNo, Me.ProductName, Me.Qty, Me.ReturnQty, Me.BatchNo, Me.ExpDate, Me.VAT, Me.MRP, Me.InvoiceNo, Me.Total, Me.TotalReturn})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(8, 264)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(967, 233)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 94
        Me.DataGridView1.TabStop = False
        '
        'SNo
        '
        Me.SNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SNo.HeaderText = "SNo"
        Me.SNo.Name = "SNo"
        Me.SNo.ReadOnly = True
        Me.SNo.Width = 30
        '
        'ProductName
        '
        Me.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ProductName.HeaderText = "ProductName"
        Me.ProductName.Name = "ProductName"
        Me.ProductName.ReadOnly = True
        Me.ProductName.Width = 215
        '
        'Qty
        '
        Me.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 70
        '
        'ReturnQty
        '
        Me.ReturnQty.HeaderText = "ReturnQty"
        Me.ReturnQty.Name = "ReturnQty"
        Me.ReturnQty.ReadOnly = True
        Me.ReturnQty.Width = 65
        '
        'BatchNo
        '
        Me.BatchNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BatchNo.HeaderText = "BatchNo"
        Me.BatchNo.Name = "BatchNo"
        Me.BatchNo.ReadOnly = True
        Me.BatchNo.Width = 110
        '
        'ExpDate
        '
        Me.ExpDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ExpDate.HeaderText = "ExpDate"
        Me.ExpDate.Name = "ExpDate"
        Me.ExpDate.ReadOnly = True
        Me.ExpDate.Width = 75
        '
        'VAT
        '
        Me.VAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.VAT.HeaderText = "VAT"
        Me.VAT.Name = "VAT"
        Me.VAT.ReadOnly = True
        Me.VAT.Width = 45
        '
        'MRP
        '
        Me.MRP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.MRP.HeaderText = "MRP"
        Me.MRP.Name = "MRP"
        Me.MRP.ReadOnly = True
        Me.MRP.Width = 70
        '
        'InvoiceNo
        '
        Me.InvoiceNo.HeaderText = "InvoiceNo"
        Me.InvoiceNo.Name = "InvoiceNo"
        Me.InvoiceNo.ReadOnly = True
        '
        'Total
        '
        Me.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'TotalReturn
        '
        Me.TotalReturn.HeaderText = "Total(Return)"
        Me.TotalReturn.Name = "TotalReturn"
        Me.TotalReturn.ReadOnly = True
        Me.TotalReturn.Width = 75
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(460, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(165, 31)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "Sales Return"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SandyBrown
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(-268, -191)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 18)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Exp.Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.GlowColor = System.Drawing.Color.Yellow
        Me.cmdExit.Image = Global.Pharmacy.My.Resources.Resource1._Exit
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.Location = New System.Drawing.Point(409, 611)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(172, 66)
        Me.cmdExit.TabIndex = 98
        Me.cmdExit.Text = "E&xit"
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.Image = Global.Pharmacy.My.Resources.Resource1.Search
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(325, 539)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(172, 66)
        Me.cmdShow.TabIndex = 97
        Me.cmdShow.Text = "&Show"
        '
        'cmdReturn
        '
        Me.cmdReturn.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReturn.ForeColor = System.Drawing.Color.Black
        Me.cmdReturn.GlowColor = System.Drawing.Color.Yellow
        Me.cmdReturn.Image = CType(resources.GetObject("cmdReturn.Image"), System.Drawing.Image)
        Me.cmdReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReturn.Location = New System.Drawing.Point(504, 539)
        Me.cmdReturn.Name = "cmdReturn"
        Me.cmdReturn.Size = New System.Drawing.Size(172, 66)
        Me.cmdReturn.TabIndex = 96
        Me.cmdReturn.Text = "&Return"
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.Color.Black
        Me.cmdNext.GlowColor = System.Drawing.Color.Yellow
        Me.cmdNext.Image = Global.Pharmacy.My.Resources.Resource1._New
        Me.cmdNext.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdNext.Location = New System.Drawing.Point(862, 151)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(61, 70)
        Me.cmdNext.TabIndex = 93
        Me.cmdNext.Text = "&Add"
        Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblReturnGrandTotal
        '
        Me.lblReturnGrandTotal.AutoSize = True
        Me.lblReturnGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReturnGrandTotal.ForeColor = System.Drawing.Color.Red
        Me.lblReturnGrandTotal.Location = New System.Drawing.Point(881, 539)
        Me.lblReturnGrandTotal.Name = "lblReturnGrandTotal"
        Me.lblReturnGrandTotal.Size = New System.Drawing.Size(0, 24)
        Me.lblReturnGrandTotal.TabIndex = 106
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Navy
        Me.Label22.Location = New System.Drawing.Point(699, 542)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(176, 20)
        Me.Label22.TabIndex = 105
        Me.Label22.Text = "Grand Total (Return)"
        '
        'SalesReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(987, 680)
        Me.Controls.Add(Me.lblReturnGrandTotal)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblGrandTotal)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.cmdReturn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label12)
        Me.Name = "SalesReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Return"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtVat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtExpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRackNo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtMRP As System.Windows.Forms.TextBox
    Friend WithEvents txtBatch As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents drpProductName As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPatientName As System.Windows.Forms.TextBox
    Friend WithEvents txtReturnBillNo As System.Windows.Forms.TextBox
    Friend WithEvents UserControl11 As Pharmacy.UserControl1
    Friend WithEvents txtPatientID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblGrandTotal As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As Glass.GlassButton
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents cmdReturn As Glass.GlassButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdNext As Glass.GlassButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtReturnQty As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents txtDrName As System.Windows.Forms.TextBox
    Friend WithEvents txtCase As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtBillDate As System.Windows.Forms.TextBox
    Friend WithEvents lblReturnGrandTotal As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents SNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MRP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalReturn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
