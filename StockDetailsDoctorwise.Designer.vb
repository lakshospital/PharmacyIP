<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockDetailsDoctorwise
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.drpProductName = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.drpProductGroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdPrint = New Glass.GlassButton
        Me.cmdShow = New Glass.GlassButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpeningStock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Purchase = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesFromOwnPurchse = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesFromPurchase = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesReturn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Excess = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Shortage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ClosingStock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.drpDrName = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPurchase = New System.Windows.Forms.Label
        Me.lblSalesFromOwnPurchase = New System.Windows.Forms.Label
        Me.lblSalesFromPurchase = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(380, 14)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 75
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(206, 14)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpfromDate.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(321, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(135, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "From Date"
        '
        'drpProductName
        '
        Me.drpProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductName.FormattingEnabled = True
        Me.drpProductName.Location = New System.Drawing.Point(565, 52)
        Me.drpProductName.Name = "drpProductName"
        Me.drpProductName.Size = New System.Drawing.Size(244, 21)
        Me.drpProductName.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(470, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "ProductName"
        '
        'drpProductGroup
        '
        Me.drpProductGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductGroup.FormattingEnabled = True
        Me.drpProductGroup.Location = New System.Drawing.Point(230, 52)
        Me.drpProductGroup.Name = "drpProductGroup"
        Me.drpProductGroup.Size = New System.Drawing.Size(215, 21)
        Me.drpProductGroup.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(135, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Product Group"
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.GlowColor = System.Drawing.Color.Yellow
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(872, 47)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(129, 34)
        Me.cmdPrint.TabIndex = 81
        Me.cmdPrint.Text = "&Print"
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(872, 7)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(129, 34)
        Me.cmdShow.TabIndex = 80
        Me.cmdShow.Text = "&Show"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductName, Me.OpeningStock, Me.Purchase, Me.Sales, Me.SalesFromOwnPurchse, Me.SalesFromPurchase, Me.SalesReturn, Me.Excess, Me.Shortage, Me.ClosingStock, Me.StockValue})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 161)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1011, 407)
        Me.DataGridView1.TabIndex = 82
        '
        'ProductName
        '
        Me.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ProductName.FillWeight = 72.52538!
        Me.ProductName.HeaderText = "ProductName"
        Me.ProductName.Name = "ProductName"
        Me.ProductName.ReadOnly = True
        Me.ProductName.Width = 120
        '
        'OpeningStock
        '
        Me.OpeningStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.OpeningStock.FillWeight = 72.52538!
        Me.OpeningStock.HeaderText = "OpeningStock"
        Me.OpeningStock.Name = "OpeningStock"
        Me.OpeningStock.ReadOnly = True
        '
        'Purchase
        '
        Me.Purchase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Purchase.FillWeight = 72.52538!
        Me.Purchase.HeaderText = "Purchase"
        Me.Purchase.Name = "Purchase"
        Me.Purchase.ReadOnly = True
        '
        'Sales
        '
        Me.Sales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Sales.FillWeight = 72.52538!
        Me.Sales.HeaderText = "Sales"
        Me.Sales.Name = "Sales"
        Me.Sales.ReadOnly = True
        '
        'SalesFromOwnPurchse
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SalesFromOwnPurchse.DefaultCellStyle = DataGridViewCellStyle1
        Me.SalesFromOwnPurchse.HeaderText = "SalesFromOwnPurchse"
        Me.SalesFromOwnPurchse.Name = "SalesFromOwnPurchse"
        Me.SalesFromOwnPurchse.ReadOnly = True
        '
        'SalesFromPurchase
        '
        Me.SalesFromPurchase.HeaderText = "SalesFromPurchase"
        Me.SalesFromPurchase.Name = "SalesFromPurchase"
        Me.SalesFromPurchase.ReadOnly = True
        '
        'SalesReturn
        '
        Me.SalesReturn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SalesReturn.FillWeight = 72.52538!
        Me.SalesReturn.HeaderText = "SalesReturn"
        Me.SalesReturn.Name = "SalesReturn"
        Me.SalesReturn.ReadOnly = True
        '
        'Excess
        '
        Me.Excess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Excess.FillWeight = 72.52538!
        Me.Excess.HeaderText = "Excess"
        Me.Excess.Name = "Excess"
        Me.Excess.ReadOnly = True
        '
        'Shortage
        '
        Me.Shortage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Shortage.FillWeight = 72.52538!
        Me.Shortage.HeaderText = "Shortage"
        Me.Shortage.Name = "Shortage"
        Me.Shortage.ReadOnly = True
        '
        'ClosingStock
        '
        Me.ClosingStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ClosingStock.FillWeight = 72.52538!
        Me.ClosingStock.HeaderText = "ClosingStock"
        Me.ClosingStock.Name = "ClosingStock"
        Me.ClosingStock.ReadOnly = True
        '
        'StockValue
        '
        Me.StockValue.HeaderText = "StockValue (Rs)"
        Me.StockValue.Name = "StockValue"
        Me.StockValue.ReadOnly = True
        Me.StockValue.Width = 90
        '
        'drpDrName
        '
        Me.drpDrName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.drpDrName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.drpDrName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpDrName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpDrName.FormattingEnabled = True
        Me.drpDrName.Location = New System.Drawing.Point(565, 15)
        Me.drpDrName.Name = "drpDrName"
        Me.drpDrName.Size = New System.Drawing.Size(244, 21)
        Me.drpDrName.TabIndex = 84
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(480, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Dr. Name"
        '
        'lblPurchase
        '
        Me.lblPurchase.AutoSize = True
        Me.lblPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurchase.Location = New System.Drawing.Point(12, 81)
        Me.lblPurchase.Name = "lblPurchase"
        Me.lblPurchase.Size = New System.Drawing.Size(202, 13)
        Me.lblPurchase.TabIndex = 85
        Me.lblPurchase.Text = "Purchase - Product Purchased By "
        '
        'lblSalesFromOwnPurchase
        '
        Me.lblSalesFromOwnPurchase.AutoSize = True
        Me.lblSalesFromOwnPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalesFromOwnPurchase.Location = New System.Drawing.Point(12, 109)
        Me.lblSalesFromOwnPurchase.Name = "lblSalesFromOwnPurchase"
        Me.lblSalesFromOwnPurchase.Size = New System.Drawing.Size(155, 13)
        Me.lblSalesFromOwnPurchase.TabIndex = 86
        Me.lblSalesFromOwnPurchase.Text = "Sales From Own Purchase"
        '
        'lblSalesFromPurchase
        '
        Me.lblSalesFromPurchase.AutoSize = True
        Me.lblSalesFromPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalesFromPurchase.Location = New System.Drawing.Point(12, 133)
        Me.lblSalesFromPurchase.Name = "lblSalesFromPurchase"
        Me.lblSalesFromPurchase.Size = New System.Drawing.Size(119, 13)
        Me.lblSalesFromPurchase.TabIndex = 87
        Me.lblSalesFromPurchase.Text = "Sales From Purchas"
        '
        'StockDetailsDoctorwise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1028, 580)
        Me.Controls.Add(Me.lblSalesFromPurchase)
        Me.Controls.Add(Me.lblSalesFromOwnPurchase)
        Me.Controls.Add(Me.lblPurchase)
        Me.Controls.Add(Me.drpDrName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.drpProductName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.drpProductGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "StockDetailsDoctorwise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Details Doctorwise"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents drpProductName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents drpProductGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As Glass.GlassButton
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents drpDrName As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPurchase As System.Windows.Forms.Label
    Friend WithEvents lblSalesFromOwnPurchase As System.Windows.Forms.Label
    Friend WithEvents lblSalesFromPurchase As System.Windows.Forms.Label
    Friend WithEvents ProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpeningStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Purchase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesFromOwnPurchse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesFromPurchase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesReturn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Excess As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Shortage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClosingStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
