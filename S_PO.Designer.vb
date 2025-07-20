<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S_PO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(S_PO))
        Me.lblReport = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblToDate = New System.Windows.Forms.Label
        Me.lblFromDate = New System.Windows.Forms.Label
        Me.btnPurchased = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnNonMoving = New System.Windows.Forms.Button
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.btnZeroOrder = New System.Windows.Forms.Button
        Me.btnToOrder = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnPercentageCalculate = New System.Windows.Forms.Button
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.txtPercentage = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnToOrderNew = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblReport
        '
        Me.lblReport.AutoSize = True
        Me.lblReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReport.ForeColor = System.Drawing.Color.IndianRed
        Me.lblReport.Location = New System.Drawing.Point(317, 27)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(71, 16)
        Me.lblReport.TabIndex = 42
        Me.lblReport.Text = "REPORT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Tomato
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(149, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "TO"
        '
        'lblToDate
        '
        Me.lblToDate.AutoSize = True
        Me.lblToDate.BackColor = System.Drawing.Color.Tomato
        Me.lblToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToDate.Location = New System.Drawing.Point(197, 25)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(74, 16)
        Me.lblToDate.TabIndex = 40
        Me.lblToDate.Text = "TO DATE"
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.BackColor = System.Drawing.Color.Tomato
        Me.lblFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromDate.Location = New System.Drawing.Point(47, 24)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(96, 16)
        Me.lblFromDate.TabIndex = 39
        Me.lblFromDate.Text = "FROM DATE"
        '
        'btnPurchased
        '
        Me.btnPurchased.Location = New System.Drawing.Point(889, 455)
        Me.btnPurchased.Name = "btnPurchased"
        Me.btnPurchased.Size = New System.Drawing.Size(101, 23)
        Me.btnPurchased.TabIndex = 38
        Me.btnPurchased.Text = "PURCHASED"
        Me.btnPurchased.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(871, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 23)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "REPORT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnNonMoving
        '
        Me.btnNonMoving.Location = New System.Drawing.Point(889, 426)
        Me.btnNonMoving.Name = "btnNonMoving"
        Me.btnNonMoving.Size = New System.Drawing.Size(101, 23)
        Me.btnNonMoving.TabIndex = 36
        Me.btnNonMoving.Text = "NON-MOVING"
        Me.btnNonMoving.UseVisualStyleBackColor = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'btnZeroOrder
        '
        Me.btnZeroOrder.Location = New System.Drawing.Point(871, 229)
        Me.btnZeroOrder.Name = "btnZeroOrder"
        Me.btnZeroOrder.Size = New System.Drawing.Size(119, 23)
        Me.btnZeroOrder.TabIndex = 35
        Me.btnZeroOrder.Text = "ZERO ORDER"
        Me.btnZeroOrder.UseVisualStyleBackColor = True
        '
        'btnToOrder
        '
        Me.btnToOrder.Location = New System.Drawing.Point(871, 171)
        Me.btnToOrder.Name = "btnToOrder"
        Me.btnToOrder.Size = New System.Drawing.Size(119, 23)
        Me.btnToOrder.TabIndex = 34
        Me.btnToOrder.Text = "TO ORDER-OLD"
        Me.btnToOrder.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(871, 51)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(115, 21)
        Me.ComboBox1.TabIndex = 33
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(889, 504)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(101, 23)
        Me.btnPrint.TabIndex = 32
        Me.btnPrint.Text = "PRINT"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPercentageCalculate
        '
        Me.btnPercentageCalculate.Location = New System.Drawing.Point(871, 142)
        Me.btnPercentageCalculate.Name = "btnPercentageCalculate"
        Me.btnPercentageCalculate.Size = New System.Drawing.Size(119, 23)
        Me.btnPercentageCalculate.TabIndex = 31
        Me.btnPercentageCalculate.Text = "FULL VIEW"
        Me.btnPercentageCalculate.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'txtPercentage
        '
        Me.txtPercentage.Location = New System.Drawing.Point(871, 116)
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(119, 20)
        Me.txtPercentage.TabIndex = 30
        Me.txtPercentage.Text = "150"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(886, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "ENTER PERCENTAGE"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(42, 69)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(802, 553)
        Me.DataGridView1.TabIndex = 28
        '
        'btnToOrderNew
        '
        Me.btnToOrderNew.Location = New System.Drawing.Point(871, 200)
        Me.btnToOrderNew.Name = "btnToOrderNew"
        Me.btnToOrderNew.Size = New System.Drawing.Size(119, 23)
        Me.btnToOrderNew.TabIndex = 43
        Me.btnToOrderNew.Text = "TO ORDER - NEW"
        Me.btnToOrderNew.UseVisualStyleBackColor = True
        '
        'S_PO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 603)
        Me.Controls.Add(Me.btnToOrderNew)
        Me.Controls.Add(Me.lblReport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblToDate)
        Me.Controls.Add(Me.lblFromDate)
        Me.Controls.Add(Me.btnPurchased)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnNonMoving)
        Me.Controls.Add(Me.btnZeroOrder)
        Me.Controls.Add(Me.btnToOrder)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnPercentageCalculate)
        Me.Controls.Add(Me.txtPercentage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "S_PO"
        Me.Text = "S_PO"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents btnPurchased As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnNonMoving As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btnZeroOrder As System.Windows.Forms.Button
    Friend WithEvents btnToOrder As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPercentageCalculate As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnToOrderNew As System.Windows.Forms.Button
End Class
