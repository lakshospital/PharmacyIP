<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrugSlip
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label9 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblGrandTotal = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExpDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MRP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblDt = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.dtpIncidentDate = New System.Windows.Forms.DateTimePicker
        Me.txtPatientName = New System.Windows.Forms.TextBox
        Me.drpCase = New System.Windows.Forms.ComboBox
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.UserControl11 = New Pharmacy.UserControl1
        Me.drpDrName = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtPatientID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmdCombination = New System.Windows.Forms.Button
        Me.txtBatch = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtExpDate = New System.Windows.Forms.DateTimePicker
        Me.txtRackNo = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDoctorWhoPurchased = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.drpInvoiceNo = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtVat = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtMRP = New System.Windows.Forms.TextBox
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.drpProductName = New System.Windows.Forms.ComboBox
        Me.txtCurrentStockQty = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdCancellBill = New Glass.GlassButton
        Me.cmdPrint = New Glass.GlassButton
        Me.cmdNew = New Glass.GlassButton
        Me.cmdExit = New Glass.GlassButton
        Me.cmdShow = New Glass.GlassButton
        Me.cmdEdit = New Glass.GlassButton
        Me.cmdNext = New Glass.GlassButton
        Me.chkCashlessBill = New System.Windows.Forms.CheckBox
        Me.lblLastBillNo = New System.Windows.Forms.Label
        Me.cmdPaymentDue = New Glass.GlassButton
        Me.lblTotalStock = New System.Windows.Forms.Label
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(427, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 31)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Drug Slip"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.Red
        Me.lblGrandTotal.Location = New System.Drawing.Point(789, 498)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(0, 24)
        Me.lblGrandTotal.TabIndex = 88
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(679, 501)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 20)
        Me.Label16.TabIndex = 87
        Me.Label16.Text = "Grand Total"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNo, Me.ProductName, Me.Qty, Me.BatchNo, Me.ExpDate, Me.VAT, Me.MRP, Me.InvoiceNo, Me.Total})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Location = New System.Drawing.Point(12, 227)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(939, 262)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 9
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
        Me.ProductName.Width = 240
        '
        'Qty
        '
        Me.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 70
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
        Me.VAT.Width = 65
        '
        'MRP
        '
        Me.MRP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.MRP.HeaderText = "MRP"
        Me.MRP.Name = "MRP"
        Me.MRP.ReadOnly = True
        Me.MRP.Width = 90
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
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SandyBrown
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(-263, -194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 18)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Exp.Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblDt)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.dtpIncidentDate)
        Me.Panel1.Controls.Add(Me.txtPatientName)
        Me.Panel1.Controls.Add(Me.drpCase)
        Me.Panel1.Controls.Add(Me.txtBillNo)
        Me.Panel1.Controls.Add(Me.UserControl11)
        Me.Panel1.Controls.Add(Me.drpDrName)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txtPatientID)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(13, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(938, 65)
        Me.Panel1.TabIndex = 89
        '
        'lblDt
        '
        Me.lblDt.Location = New System.Drawing.Point(394, 7)
        Me.lblDt.Name = "lblDt"
        Me.lblDt.Size = New System.Drawing.Size(159, 21)
        Me.lblDt.TabIndex = 111
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(827, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 13)
        Me.Label20.TabIndex = 104
        Me.Label20.Text = "Date of Incident"
        '
        'dtpIncidentDate
        '
        Me.dtpIncidentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIncidentDate.Location = New System.Drawing.Point(825, 34)
        Me.dtpIncidentDate.Name = "dtpIncidentDate"
        Me.dtpIncidentDate.Size = New System.Drawing.Size(108, 20)
        Me.dtpIncidentDate.TabIndex = 7
        '
        'txtPatientName
        '
        Me.txtPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientName.Location = New System.Drawing.Point(413, 35)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.ReadOnly = True
        Me.txtPatientName.Size = New System.Drawing.Size(144, 20)
        Me.txtPatientName.TabIndex = 5
        Me.txtPatientName.TabStop = False
        '
        'drpCase
        '
        Me.drpCase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.drpCase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpCase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpCase.FormattingEnabled = True
        Me.drpCase.Location = New System.Drawing.Point(624, 35)
        Me.drpCase.Name = "drpCase"
        Me.drpCase.Size = New System.Drawing.Size(195, 21)
        Me.drpCase.TabIndex = 6
        '
        'txtBillNo
        '
        Me.txtBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNo.Location = New System.Drawing.Point(91, 8)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(223, 20)
        Me.txtBillNo.TabIndex = 1
        Me.txtBillNo.TabStop = False
        '
        'UserControl11
        '
        Me.UserControl11.Location = New System.Drawing.Point(389, 8)
        Me.UserControl11.Name = "UserControl11"
        Me.UserControl11.Size = New System.Drawing.Size(150, 26)
        Me.UserControl11.TabIndex = 14
        Me.UserControl11.TabStop = False
        '
        'drpDrName
        '
        Me.drpDrName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.drpDrName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpDrName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpDrName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpDrName.FormattingEnabled = True
        Me.drpDrName.Location = New System.Drawing.Point(624, 5)
        Me.drpDrName.Name = "drpDrName"
        Me.drpDrName.Size = New System.Drawing.Size(195, 21)
        Me.drpDrName.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(240, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPatientID
        '
        Me.txtPatientID.BackColor = System.Drawing.Color.GreenYellow
        Me.txtPatientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientID.Location = New System.Drawing.Point(90, 36)
        Me.txtPatientID.Name = "txtPatientID"
        Me.txtPatientID.ReadOnly = True
        Me.txtPatientID.Size = New System.Drawing.Size(142, 20)
        Me.txtPatientID.TabIndex = 3
        Me.txtPatientID.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(328, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Patient Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(563, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Case"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(558, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Dr. Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Patient ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(328, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Bill Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Bill No"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmdCombination)
        Me.Panel2.Controls.Add(Me.txtBatch)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtExpDate)
        Me.Panel2.Controls.Add(Me.txtRackNo)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txtDoctorWhoPurchased)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.drpInvoiceNo)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtVat)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtMRP)
        Me.Panel2.Controls.Add(Me.txtQty)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.drpProductName)
        Me.Panel2.Location = New System.Drawing.Point(13, 113)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(810, 108)
        Me.Panel2.TabIndex = 90
        '
        'cmdCombination
        '
        Me.cmdCombination.Location = New System.Drawing.Point(299, 6)
        Me.cmdCombination.Name = "cmdCombination"
        Me.cmdCombination.Size = New System.Drawing.Size(24, 41)
        Me.cmdCombination.TabIndex = 107
        Me.cmdCombination.TabStop = False
        Me.cmdCombination.Text = "&C"
        Me.cmdCombination.UseVisualStyleBackColor = True
        '
        'txtBatch
        '
        Me.txtBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBatch.FormattingEnabled = True
        Me.txtBatch.Location = New System.Drawing.Point(489, 27)
        Me.txtBatch.Name = "txtBatch"
        Me.txtBatch.Size = New System.Drawing.Size(139, 21)
        Me.txtBatch.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SandyBrown
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(489, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 18)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "Batch No"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtExpDate
        '
        Me.txtExpDate.Enabled = False
        Me.txtExpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtExpDate.Location = New System.Drawing.Point(109, 75)
        Me.txtExpDate.Name = "txtExpDate"
        Me.txtExpDate.Size = New System.Drawing.Size(106, 20)
        Me.txtExpDate.TabIndex = 104
        '
        'txtRackNo
        '
        Me.txtRackNo.BackColor = System.Drawing.Color.GreenYellow
        Me.txtRackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRackNo.Location = New System.Drawing.Point(3, 75)
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
        Me.Label19.Location = New System.Drawing.Point(3, 55)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 18)
        Me.Label19.TabIndex = 103
        Me.Label19.Text = "RackNo"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDoctorWhoPurchased
        '
        Me.txtDoctorWhoPurchased.BackColor = System.Drawing.Color.LightPink
        Me.txtDoctorWhoPurchased.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDoctorWhoPurchased.Location = New System.Drawing.Point(312, 75)
        Me.txtDoctorWhoPurchased.Name = "txtDoctorWhoPurchased"
        Me.txtDoctorWhoPurchased.ReadOnly = True
        Me.txtDoctorWhoPurchased.Size = New System.Drawing.Size(336, 20)
        Me.txtDoctorWhoPurchased.TabIndex = 101
        Me.txtDoctorWhoPurchased.TabStop = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SandyBrown
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(312, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(336, 18)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "Doctor Name Who Purchased"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'drpInvoiceNo
        '
        Me.drpInvoiceNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpInvoiceNo.FormattingEnabled = True
        Me.drpInvoiceNo.Location = New System.Drawing.Point(325, 26)
        Me.drpInvoiceNo.Name = "drpInvoiceNo"
        Me.drpInvoiceNo.Size = New System.Drawing.Size(158, 21)
        Me.drpInvoiceNo.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SandyBrown
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(325, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(158, 18)
        Me.Label17.TabIndex = 98
        Me.Label17.Text = "InvoiceNo"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVat
        '
        Me.txtVat.BackColor = System.Drawing.Color.LightPink
        Me.txtVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVat.Location = New System.Drawing.Point(220, 76)
        Me.txtVat.Name = "txtVat"
        Me.txtVat.ReadOnly = True
        Me.txtVat.Size = New System.Drawing.Size(87, 20)
        Me.txtVat.TabIndex = 88
        Me.txtVat.TabStop = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SandyBrown
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(221, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 18)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "VAT(%)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SandyBrown
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(654, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 18)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "MRP"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMRP
        '
        Me.txtMRP.BackColor = System.Drawing.Color.LightPink
        Me.txtMRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMRP.Location = New System.Drawing.Point(654, 75)
        Me.txtMRP.Name = "txtMRP"
        Me.txtMRP.ReadOnly = True
        Me.txtMRP.Size = New System.Drawing.Size(125, 20)
        Me.txtMRP.TabIndex = 89
        Me.txtMRP.TabStop = False
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(632, 27)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(68, 20)
        Me.txtQty.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SandyBrown
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(108, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 18)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "Exp.Date"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SandyBrown
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(632, 6)
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
        Me.Label7.Size = New System.Drawing.Size(295, 18)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Product Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'drpProductName
        '
        Me.drpProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.drpProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductName.FormattingEnabled = True
        Me.drpProductName.Location = New System.Drawing.Point(1, 26)
        Me.drpProductName.Name = "drpProductName"
        Me.drpProductName.Size = New System.Drawing.Size(296, 21)
        Me.drpProductName.TabIndex = 8
        '
        'txtCurrentStockQty
        '
        Me.txtCurrentStockQty.BackColor = System.Drawing.Color.GreenYellow
        Me.txtCurrentStockQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentStockQty.Location = New System.Drawing.Point(720, 140)
        Me.txtCurrentStockQty.Name = "txtCurrentStockQty"
        Me.txtCurrentStockQty.ReadOnly = True
        Me.txtCurrentStockQty.Size = New System.Drawing.Size(99, 20)
        Me.txtCurrentStockQty.TabIndex = 90
        Me.txtCurrentStockQty.TabStop = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SandyBrown
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(720, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 18)
        Me.Label15.TabIndex = 97
        Me.Label15.Text = "Current Stock (Qty)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancellBill
        '
        Me.cmdCancellBill.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdCancellBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancellBill.ForeColor = System.Drawing.Color.Black
        Me.cmdCancellBill.GlowColor = System.Drawing.Color.Yellow
        Me.cmdCancellBill.Image = Global.Pharmacy.My.Resources.Resource1.Delete
        Me.cmdCancellBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancellBill.Location = New System.Drawing.Point(568, 524)
        Me.cmdCancellBill.Name = "cmdCancellBill"
        Me.cmdCancellBill.Size = New System.Drawing.Size(172, 66)
        Me.cmdCancellBill.TabIndex = 17
        Me.cmdCancellBill.Text = "Can&cel Bill"
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.GlowColor = System.Drawing.Color.Yellow
        Me.cmdPrint.Image = Global.Pharmacy.My.Resources.Resource1.Printer
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(746, 524)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(172, 66)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "&Print"
        '
        'cmdNew
        '
        Me.cmdNew.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNew.ForeColor = System.Drawing.Color.Black
        Me.cmdNew.GlowColor = System.Drawing.Color.Yellow
        Me.cmdNew.Image = Global.Pharmacy.My.Resources.Resource1._New
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.Location = New System.Drawing.Point(34, 524)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(172, 66)
        Me.cmdNew.TabIndex = 14
        Me.cmdNew.Text = "&New"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.GlowColor = System.Drawing.Color.Yellow
        Me.cmdExit.Image = Global.Pharmacy.My.Resources.Resource1._Exit
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.Location = New System.Drawing.Point(390, 603)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(172, 66)
        Me.cmdExit.TabIndex = 19
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
        Me.cmdShow.Location = New System.Drawing.Point(390, 524)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(172, 66)
        Me.cmdShow.TabIndex = 16
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
        Me.cmdEdit.Location = New System.Drawing.Point(212, 524)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(172, 66)
        Me.cmdEdit.TabIndex = 15
        Me.cmdEdit.Text = "&Edit"
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.Color.Black
        Me.cmdNext.GlowColor = System.Drawing.Color.Yellow
        Me.cmdNext.Image = Global.Pharmacy.My.Resources.Resource1._New
        Me.cmdNext.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdNext.Location = New System.Drawing.Point(829, 113)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(61, 70)
        Me.cmdNext.TabIndex = 12
        Me.cmdNext.Text = "&Add"
        Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'chkCashlessBill
        '
        Me.chkCashlessBill.AutoSize = True
        Me.chkCashlessBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCashlessBill.Location = New System.Drawing.Point(575, 501)
        Me.chkCashlessBill.Name = "chkCashlessBill"
        Me.chkCashlessBill.Size = New System.Drawing.Size(97, 17)
        Me.chkCashlessBill.TabIndex = 13
        Me.chkCashlessBill.Text = "Cashless Bill"
        Me.chkCashlessBill.UseVisualStyleBackColor = True
        '
        'lblLastBillNo
        '
        Me.lblLastBillNo.AutoSize = True
        Me.lblLastBillNo.ForeColor = System.Drawing.Color.Red
        Me.lblLastBillNo.Location = New System.Drawing.Point(14, 18)
        Me.lblLastBillNo.Name = "lblLastBillNo"
        Me.lblLastBillNo.Size = New System.Drawing.Size(0, 13)
        Me.lblLastBillNo.TabIndex = 98
        '
        'cmdPaymentDue
        '
        Me.cmdPaymentDue.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdPaymentDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPaymentDue.ForeColor = System.Drawing.Color.Black
        Me.cmdPaymentDue.GlowColor = System.Drawing.Color.Yellow
        Me.cmdPaymentDue.Image = Global.Pharmacy.My.Resources.Resource1.lists
        Me.cmdPaymentDue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPaymentDue.Location = New System.Drawing.Point(221, 603)
        Me.cmdPaymentDue.Name = "cmdPaymentDue"
        Me.cmdPaymentDue.Size = New System.Drawing.Size(143, 66)
        Me.cmdPaymentDue.TabIndex = 99
        Me.cmdPaymentDue.Text = "Payment &Due"
        Me.cmdPaymentDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPaymentDue.Visible = False
        '
        'lblTotalStock
        '
        Me.lblTotalStock.AutoSize = True
        Me.lblTotalStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalStock.ForeColor = System.Drawing.Color.Red
        Me.lblTotalStock.Location = New System.Drawing.Point(873, 197)
        Me.lblTotalStock.Name = "lblTotalStock"
        Me.lblTotalStock.Size = New System.Drawing.Size(24, 25)
        Me.lblTotalStock.TabIndex = 100
        Me.lblTotalStock.Text = "0"
        '
        'DrugSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(962, 674)
        Me.Controls.Add(Me.lblTotalStock)
        Me.Controls.Add(Me.cmdPaymentDue)
        Me.Controls.Add(Me.lblLastBillNo)
        Me.Controls.Add(Me.chkCashlessBill)
        Me.Controls.Add(Me.txtCurrentStockQty)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmdCancellBill)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblGrandTotal)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.MaximizeBox = False
        Me.Name = "DrugSlip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Drug Slip"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblGrandTotal As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdNew As Glass.GlassButton
    Friend WithEvents cmdExit As Glass.GlassButton
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents cmdEdit As Glass.GlassButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdNext As Glass.GlassButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents drpCase As System.Windows.Forms.ComboBox
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents UserControl11 As Pharmacy.UserControl1
    Friend WithEvents drpDrName As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtPatientID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtCurrentStockQty As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtVat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMRP As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents drpProductName As System.Windows.Forms.ComboBox
    Friend WithEvents txtPatientName As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents drpInvoiceNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDoctorWhoPurchased As System.Windows.Forms.TextBox
    Friend WithEvents SNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MRP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRackNo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtExpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdPrint As Glass.GlassButton
    Friend WithEvents cmdCancellBill As Glass.GlassButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBatch As System.Windows.Forms.ComboBox
    Friend WithEvents chkCashlessBill As System.Windows.Forms.CheckBox
    Friend WithEvents lblLastBillNo As System.Windows.Forms.Label
    Friend WithEvents cmdPaymentDue As Glass.GlassButton
    Friend WithEvents dtpIncidentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmdCombination As System.Windows.Forms.Button
    Friend WithEvents lblDt As System.Windows.Forms.Label
    Friend WithEvents lblTotalStock As System.Windows.Forms.Label
End Class
