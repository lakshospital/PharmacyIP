<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseProfitPercentage
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.InvoiceDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsPurchaseProfitPercentage = New Pharmacy.dsPurchaseProfitPercentage
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceTitleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.drpSupplierName = New System.Windows.Forms.ComboBox
        Me.drpProductGroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdShow = New Glass.GlassButton
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.drpProductName = New System.Windows.Forms.ComboBox
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.drpDrName = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.drpOrder = New System.Windows.Forms.ComboBox
        Me.InvoiceDetailsTableAdapter = New Pharmacy.dsPurchaseProfitPercentageTableAdapters.InvoiceDetailsTableAdapter
        Me.FromToDateTableTableAdapter = New Pharmacy.dsPurchaseProfitPercentageTableAdapters.FromToDateTableTableAdapter
        Me.InvoiceTitleTableAdapter = New Pharmacy.dsPurchaseProfitPercentageTableAdapters.InvoiceTitleTableAdapter
        Me.DataSet4 = New Pharmacy.DataSet4
        Me.InvoiceDetails_HistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceDetails_HistoryTableAdapter = New Pharmacy.DataSet4TableAdapters.InvoiceDetails_HistoryTableAdapter
        CType(Me.InvoiceDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPurchaseProfitPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceTitleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceDetails_HistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InvoiceDetailsBindingSource
        '
        Me.InvoiceDetailsBindingSource.DataMember = "InvoiceDetails"
        Me.InvoiceDetailsBindingSource.DataSource = Me.dsPurchaseProfitPercentage
        '
        'dsPurchaseProfitPercentage
        '
        Me.dsPurchaseProfitPercentage.DataSetName = "dsPurchaseProfitPercentage"
        Me.dsPurchaseProfitPercentage.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.dsPurchaseProfitPercentage
        '
        'InvoiceTitleBindingSource
        '
        Me.InvoiceTitleBindingSource.DataMember = "InvoiceTitle"
        Me.InvoiceTitleBindingSource.DataSource = Me.dsPurchaseProfitPercentage
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(606, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Supplier Name"
        '
        'drpSupplierName
        '
        Me.drpSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpSupplierName.FormattingEnabled = True
        Me.drpSupplierName.Location = New System.Drawing.Point(710, 16)
        Me.drpSupplierName.Name = "drpSupplierName"
        Me.drpSupplierName.Size = New System.Drawing.Size(215, 21)
        Me.drpSupplierName.TabIndex = 48
        '
        'drpProductGroup
        '
        Me.drpProductGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductGroup.FormattingEnabled = True
        Me.drpProductGroup.Location = New System.Drawing.Point(518, 44)
        Me.drpProductGroup.Name = "drpProductGroup"
        Me.drpProductGroup.Size = New System.Drawing.Size(215, 21)
        Me.drpProductGroup.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(423, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Product Group"
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(749, 44)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(139, 57)
        Me.cmdShow.TabIndex = 45
        Me.cmdShow.Text = "&Show"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd-MMM-yyyy hh:mm:ss tt"
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(408, 15)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(192, 20)
        Me.dtpToDate.TabIndex = 44
        '
        'dtpfromDate
        '
        Me.dtpfromDate.CustomFormat = "dd-MMM-yyyy hh:mm:ss tt"
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfromDate.Location = New System.Drawing.Point(149, 15)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(194, 20)
        Me.dtpfromDate.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(349, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(78, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "From Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(78, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "ProductName"
        '
        'drpProductName
        '
        Me.drpProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductName.FormattingEnabled = True
        Me.drpProductName.Location = New System.Drawing.Point(173, 72)
        Me.drpProductName.Name = "drpProductName"
        Me.drpProductName.Size = New System.Drawing.Size(244, 21)
        Me.drpProductName.TabIndex = 51
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsPurchaseProfitPercentage_InvoiceDetails"
        ReportDataSource1.Value = Me.InvoiceDetailsBindingSource
        ReportDataSource2.Name = "dsPurchaseProfitPercentage_FromToDateTable"
        ReportDataSource2.Value = Me.FromToDateTableBindingSource
        ReportDataSource3.Name = "dsPurchaseProfitPercentage_InvoiceTitle"
        ReportDataSource3.Value = Me.InvoiceTitleBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptPurchaseProfitReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 91)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(937, 566)
        Me.ReportViewer1.TabIndex = 52
        '
        'drpDrName
        '
        Me.drpDrName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpDrName.FormattingEnabled = True
        Me.drpDrName.Location = New System.Drawing.Point(173, 44)
        Me.drpDrName.Name = "drpDrName"
        Me.drpDrName.Size = New System.Drawing.Size(244, 21)
        Me.drpDrName.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(78, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Doctor Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(423, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Order By"
        '
        'drpOrder
        '
        Me.drpOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpOrder.FormattingEnabled = True
        Me.drpOrder.Location = New System.Drawing.Point(518, 72)
        Me.drpOrder.Name = "drpOrder"
        Me.drpOrder.Size = New System.Drawing.Size(215, 21)
        Me.drpOrder.TabIndex = 56
        '
        'InvoiceDetailsTableAdapter
        '
        Me.InvoiceDetailsTableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceTitleTableAdapter
        '
        Me.InvoiceTitleTableAdapter.ClearBeforeFill = True
        '
        'DataSet4
        '
        Me.DataSet4.DataSetName = "DataSet4"
        Me.DataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InvoiceDetails_HistoryBindingSource
        '
        Me.InvoiceDetails_HistoryBindingSource.DataMember = "InvoiceDetails_History"
        Me.InvoiceDetails_HistoryBindingSource.DataSource = Me.DataSet4
        '
        'InvoiceDetails_HistoryTableAdapter
        '
        Me.InvoiceDetails_HistoryTableAdapter.ClearBeforeFill = True
        '
        'PurchaseProfitPercentage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(949, 657)
        Me.Controls.Add(Me.drpOrder)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.drpDrName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.drpProductName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.drpSupplierName)
        Me.Controls.Add(Me.drpProductGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PurchaseProfitPercentage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Profit Percentage"
        CType(Me.InvoiceDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPurchaseProfitPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceTitleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceDetails_HistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents drpSupplierName As System.Windows.Forms.ComboBox
    Friend WithEvents drpProductGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents drpProductName As System.Windows.Forms.ComboBox
    Friend WithEvents InvoiceDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsPurchaseProfitPercentage As Pharmacy.dsPurchaseProfitPercentage
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceDetailsTableAdapter As Pharmacy.dsPurchaseProfitPercentageTableAdapters.InvoiceDetailsTableAdapter
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.dsPurchaseProfitPercentageTableAdapters.FromToDateTableTableAdapter
    Friend WithEvents drpDrName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents InvoiceTitleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceTitleTableAdapter As Pharmacy.dsPurchaseProfitPercentageTableAdapters.InvoiceTitleTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents drpOrder As System.Windows.Forms.ComboBox
    Friend WithEvents InvoiceDetails_HistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet4 As Pharmacy.DataSet4
    Friend WithEvents InvoiceDetails_HistoryTableAdapter As Pharmacy.DataSet4TableAdapters.InvoiceDetails_HistoryTableAdapter
    Public WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
