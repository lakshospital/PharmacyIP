<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockDetailsDatewise
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
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Date1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpeningStock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Purchase = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesReturn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Excess = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Shortage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ClosingStock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdShow = New Glass.GlassButton
        Me.drpProductName = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.drpProductGroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdPrint = New Glass.GlassButton
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(126, 38)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(199, 20)
        Me.dtpToDate.TabIndex = 71
        '
        'dtpfromDate
        '
        Me.dtpfromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfromDate.Location = New System.Drawing.Point(126, 9)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(199, 20)
        Me.dtpfromDate.TabIndex = 70
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "From Date"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Date1, Me.ProductName, Me.OpeningStock, Me.Purchase, Me.Sales, Me.SalesReturn, Me.Excess, Me.Shortage, Me.ClosingStock, Me.StockValue})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 114)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(946, 442)
        Me.DataGridView1.TabIndex = 67
        '
        'Date1
        '
        Me.Date1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Date1.FillWeight = 319.797!
        Me.Date1.HeaderText = "Date"
        Me.Date1.Name = "Date1"
        Me.Date1.ReadOnly = True
        Me.Date1.Width = 70
        '
        'ProductName
        '
        Me.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ProductName.FillWeight = 72.52538!
        Me.ProductName.HeaderText = "ProductName"
        Me.ProductName.Name = "ProductName"
        Me.ProductName.ReadOnly = True
        Me.ProductName.Width = 170
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
        Me.StockValue.Width = 130
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(710, 6)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(129, 34)
        Me.cmdShow.TabIndex = 66
        Me.cmdShow.Text = "&Show"
        '
        'drpProductName
        '
        Me.drpProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductName.FormattingEnabled = True
        Me.drpProductName.Location = New System.Drawing.Point(444, 66)
        Me.drpProductName.Name = "drpProductName"
        Me.drpProductName.Size = New System.Drawing.Size(244, 21)
        Me.drpProductName.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(349, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "ProductName"
        '
        'drpProductGroup
        '
        Me.drpProductGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductGroup.FormattingEnabled = True
        Me.drpProductGroup.Location = New System.Drawing.Point(126, 66)
        Me.drpProductGroup.Name = "drpProductGroup"
        Me.drpProductGroup.Size = New System.Drawing.Size(215, 21)
        Me.drpProductGroup.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Product Group"
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.GlowColor = System.Drawing.Color.Yellow
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(710, 46)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(129, 34)
        Me.cmdPrint.TabIndex = 72
        Me.cmdPrint.Text = "&Print"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(352, 11)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(295, 17)
        Me.CheckBox1.TabIndex = 73
        Me.CheckBox1.Text = "Show Products Only on Sales and Sales Return"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(352, 43)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(131, 17)
        Me.CheckBox2.TabIndex = 74
        Me.CheckBox2.Text = "Un-Sales Products"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'StockDetailsDatewise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(970, 571)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.drpProductName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.drpProductGroup)
        Me.Controls.Add(Me.Label3)
        Me.Name = "StockDetailsDatewise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Details Between Date"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents drpProductName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents drpProductGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As Glass.GlassButton
    Friend WithEvents Date1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpeningStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Purchase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesReturn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Excess As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Shortage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClosingStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
End Class
