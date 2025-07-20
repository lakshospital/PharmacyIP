<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseEntry
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblSupplierName = New System.Windows.Forms.Label
        Me.txtCompanyInvoice = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtSupplierID = New System.Windows.Forms.TextBox
        Me.drpDrName = New System.Windows.Forms.ComboBox
        Me.drpProductName = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.txtBatch = New System.Windows.Forms.TextBox
        Me.txtMRP = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtVat = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExpDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MRP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HSR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtHSR = New System.Windows.Forms.TextBox
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblGrandTotal = New System.Windows.Forms.Label
        Me.GlassButton1 = New Glass.GlassButton
        Me.cmdShow = New Glass.GlassButton
        Me.cmdEdit = New Glass.GlassButton
        Me.cmdNew = New Glass.GlassButton
        Me.cmdNext = New Glass.GlassButton
        Me.cmdChange = New Glass.GlassButton
        Me.txtExpDate = New System.Windows.Forms.DateTimePicker
        Me.cmdCancellBill = New Glass.GlassButton
        Me.dtpCompanyDate = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.UserControl11 = New Pharmacy.UserControl1
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invoice No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(340, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Invoice Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(340, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Supplier ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Dr. Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(575, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Company Invoice No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(331, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "SupplierName"
        '
        'lblSupplierName
        '
        Me.lblSupplierName.AutoSize = True
        Me.lblSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplierName.ForeColor = System.Drawing.Color.Red
        Me.lblSupplierName.Location = New System.Drawing.Point(422, 117)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(98, 13)
        Me.lblSupplierName.TabIndex = 8
        Me.lblSupplierName.Text = "lblSupplierName"
        '
        'txtCompanyInvoice
        '
        Me.txtCompanyInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyInvoice.Location = New System.Drawing.Point(705, 61)
        Me.txtCompanyInvoice.Name = "txtCompanyInvoice"
        Me.txtCompanyInvoice.Size = New System.Drawing.Size(194, 20)
        Me.txtCompanyInvoice.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(575, 87)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "&Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtSupplierID
        '
        Me.txtSupplierID.BackColor = System.Drawing.Color.GreenYellow
        Me.txtSupplierID.Location = New System.Drawing.Point(425, 89)
        Me.txtSupplierID.Name = "txtSupplierID"
        Me.txtSupplierID.ReadOnly = True
        Me.txtSupplierID.Size = New System.Drawing.Size(142, 20)
        Me.txtSupplierID.TabIndex = 4
        Me.txtSupplierID.TabStop = False
        '
        'drpDrName
        '
        Me.drpDrName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.drpDrName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpDrName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpDrName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpDrName.FormattingEnabled = True
        Me.drpDrName.Location = New System.Drawing.Point(103, 89)
        Me.drpDrName.Name = "drpDrName"
        Me.drpDrName.Size = New System.Drawing.Size(223, 21)
        Me.drpDrName.TabIndex = 4
        '
        'drpProductName
        '
        Me.drpProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.drpProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductName.FormattingEnabled = True
        Me.drpProductName.Location = New System.Drawing.Point(21, 157)
        Me.drpProductName.Name = "drpProductName"
        Me.drpProductName.Size = New System.Drawing.Size(289, 21)
        Me.drpProductName.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SandyBrown
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(288, 18)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Product Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(406, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(190, 31)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Purchase Entry"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SandyBrown
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(315, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 18)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Qty"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SandyBrown
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(389, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 18)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Batch No"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SandyBrown
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(499, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 18)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Exp.Date"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(315, 158)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(68, 20)
        Me.txtQty.TabIndex = 7
        '
        'txtBatch
        '
        Me.txtBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBatch.Location = New System.Drawing.Point(389, 157)
        Me.txtBatch.Name = "txtBatch"
        Me.txtBatch.Size = New System.Drawing.Size(105, 20)
        Me.txtBatch.TabIndex = 8
        '
        'txtMRP
        '
        Me.txtMRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMRP.Location = New System.Drawing.Point(656, 157)
        Me.txtMRP.Name = "txtMRP"
        Me.txtMRP.Size = New System.Drawing.Size(85, 20)
        Me.txtMRP.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SandyBrown
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(-254, -199)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 18)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Exp.Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SandyBrown
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(656, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 18)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "MRP"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SandyBrown
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(603, 136)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 18)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "VAT(%)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVat
        '
        Me.txtVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVat.Location = New System.Drawing.Point(602, 157)
        Me.txtVat.Name = "txtVat"
        Me.txtVat.Size = New System.Drawing.Size(48, 20)
        Me.txtVat.TabIndex = 10
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNo, Me.ProductName, Me.Qty, Me.BatchNo, Me.ExpDate, Me.VAT, Me.MRP, Me.HSR, Me.Total})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(21, 184)
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
        Me.DataGridView1.Size = New System.Drawing.Size(939, 230)
        Me.DataGridView1.TabIndex = 44
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
        'HSR
        '
        Me.HSR.HeaderText = "HSR"
        Me.HSR.Name = "HSR"
        Me.HSR.ReadOnly = True
        '
        'Total
        '
        Me.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(164, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(163, 22)
        Me.ToolStripMenuItem1.Text = "Old Price History"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SandyBrown
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(747, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 18)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "HSR"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtHSR
        '
        Me.txtHSR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHSR.Location = New System.Drawing.Point(747, 157)
        Me.txtHSR.Name = "txtHSR"
        Me.txtHSR.Size = New System.Drawing.Size(85, 20)
        Me.txtHSR.TabIndex = 12
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.Location = New System.Drawing.Point(103, 61)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(223, 20)
        Me.txtInvoiceNo.TabIndex = 1
        Me.txtInvoiceNo.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(688, 434)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 20)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "Grand Total"
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.Red
        Me.lblGrandTotal.Location = New System.Drawing.Point(798, 431)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(0, 24)
        Me.lblGrandTotal.TabIndex = 52
        '
        'GlassButton1
        '
        Me.GlassButton1.BackColor = System.Drawing.Color.SteelBlue
        Me.GlassButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GlassButton1.ForeColor = System.Drawing.Color.Black
        Me.GlassButton1.GlowColor = System.Drawing.Color.Yellow
        Me.GlassButton1.Image = Global.Pharmacy.My.Resources.Resource1._Exit
        Me.GlassButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GlassButton1.Location = New System.Drawing.Point(389, 547)
        Me.GlassButton1.Name = "GlassButton1"
        Me.GlassButton1.Size = New System.Drawing.Size(172, 66)
        Me.GlassButton1.TabIndex = 18
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
        Me.cmdShow.Location = New System.Drawing.Point(656, 474)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(172, 66)
        Me.cmdShow.TabIndex = 17
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
        Me.cmdEdit.Location = New System.Drawing.Point(300, 474)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(172, 66)
        Me.cmdEdit.TabIndex = 16
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
        Me.cmdNew.Location = New System.Drawing.Point(122, 474)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(172, 66)
        Me.cmdNew.TabIndex = 15
        Me.cmdNew.Text = "&New"
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.Color.Black
        Me.cmdNext.GlowColor = System.Drawing.Color.Yellow
        Me.cmdNext.Image = Global.Pharmacy.My.Resources.Resource1.List_manager
        Me.cmdNext.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdNext.Location = New System.Drawing.Point(838, 108)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(61, 70)
        Me.cmdNext.TabIndex = 13
        Me.cmdNext.Text = "&Add"
        Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdChange
        '
        Me.cmdChange.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChange.ForeColor = System.Drawing.Color.Black
        Me.cmdChange.GlowColor = System.Drawing.Color.Yellow
        Me.cmdChange.Image = Global.Pharmacy.My.Resources.Resource1.lists
        Me.cmdChange.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdChange.Location = New System.Drawing.Point(900, 107)
        Me.cmdChange.Name = "cmdChange"
        Me.cmdChange.Size = New System.Drawing.Size(61, 70)
        Me.cmdChange.TabIndex = 14
        Me.cmdChange.Text = "C&hange"
        Me.cmdChange.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtExpDate
        '
        Me.txtExpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtExpDate.Location = New System.Drawing.Point(501, 158)
        Me.txtExpDate.Name = "txtExpDate"
        Me.txtExpDate.Size = New System.Drawing.Size(95, 20)
        Me.txtExpDate.TabIndex = 9
        '
        'cmdCancellBill
        '
        Me.cmdCancellBill.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdCancellBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancellBill.ForeColor = System.Drawing.Color.Black
        Me.cmdCancellBill.GlowColor = System.Drawing.Color.Yellow
        Me.cmdCancellBill.Image = Global.Pharmacy.My.Resources.Resource1.Delete
        Me.cmdCancellBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancellBill.Location = New System.Drawing.Point(478, 474)
        Me.cmdCancellBill.Name = "cmdCancellBill"
        Me.cmdCancellBill.Size = New System.Drawing.Size(172, 66)
        Me.cmdCancellBill.TabIndex = 53
        Me.cmdCancellBill.Text = "C&ancel Bill"
        '
        'dtpCompanyDate
        '
        Me.dtpCompanyDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompanyDate.Location = New System.Drawing.Point(805, 85)
        Me.dtpCompanyDate.Name = "dtpCompanyDate"
        Me.dtpCompanyDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpCompanyDate.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(668, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 13)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Company Invoice No"
        '
        'UserControl11
        '
        Me.UserControl11.Location = New System.Drawing.Point(419, 60)
        Me.UserControl11.Name = "UserControl11"
        Me.UserControl11.Size = New System.Drawing.Size(150, 26)
        Me.UserControl11.TabIndex = 45
        '
        'PurchaseEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(972, 625)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.dtpCompanyDate)
        Me.Controls.Add(Me.cmdCancellBill)
        Me.Controls.Add(Me.txtExpDate)
        Me.Controls.Add(Me.cmdChange)
        Me.Controls.Add(Me.lblGrandTotal)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GlassButton1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.txtInvoiceNo)
        Me.Controls.Add(Me.UserControl11)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.txtHSR)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtVat)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtMRP)
        Me.Controls.Add(Me.txtBatch)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.drpProductName)
        Me.Controls.Add(Me.drpDrName)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtSupplierID)
        Me.Controls.Add(Me.txtCompanyInvoice)
        Me.Controls.Add(Me.lblSupplierName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PurchaseEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Entry"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents txtCompanyInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtSupplierID As System.Windows.Forms.TextBox
    Friend WithEvents drpDrName As System.Windows.Forms.ComboBox
    Friend WithEvents drpProductName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtBatch As System.Windows.Forms.TextBox
    Friend WithEvents txtMRP As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtVat As System.Windows.Forms.TextBox
    Friend WithEvents cmdNext As Glass.GlassButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents UserControl11 As Pharmacy.UserControl1
    Friend WithEvents SNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MRP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HSR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtHSR As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents GlassButton1 As Glass.GlassButton
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents cmdEdit As Glass.GlassButton
    Friend WithEvents cmdNew As Glass.GlassButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblGrandTotal As System.Windows.Forms.Label
    Friend WithEvents cmdChange As Glass.GlassButton
    Friend WithEvents txtExpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdCancellBill As Glass.GlassButton
    Friend WithEvents dtpCompanyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
