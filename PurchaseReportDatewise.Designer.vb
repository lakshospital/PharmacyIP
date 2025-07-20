<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseReportDatewise
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
        Me.cmdShow = New Glass.GlassButton
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.Label4 = New System.Windows.Forms.Label
        Me.drpDoctorName = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.drpSupplierName = New System.Windows.Forms.ComboBox
        Me.InvoiceDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsPurchaseReportDatewise = New Pharmacy.dsPurchaseReportDatewise
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceDetailsTableAdapter = New Pharmacy.dsPurchaseReportDatewiseTableAdapters.InvoiceDetailsTableAdapter
        Me.FromToDateTableTableAdapter = New Pharmacy.dsPurchaseReportDatewiseTableAdapters.FromToDateTableTableAdapter
        CType(Me.InvoiceDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPurchaseReportDatewise, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(718, 24)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 35
        Me.cmdShow.Text = "&Show"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(429, 20)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpToDate.TabIndex = 34
        '
        'dtpfromDate
        '
        Me.dtpfromDate.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfromDate.Location = New System.Drawing.Point(177, 20)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpfromDate.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(370, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(106, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "From Date"
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsPurchaseReportDatewise_InvoiceDetails"
        ReportDataSource1.Value = Me.InvoiceDetailsBindingSource
        ReportDataSource2.Name = "dsPurchaseReportDatewise_FromToDateTable"
        ReportDataSource2.Value = Me.FromToDateTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptPurchaseReportDatewise.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(3, 87)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(985, 590)
        Me.ReportViewer1.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(411, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Dr Name"
        '
        'drpDoctorName
        '
        Me.drpDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpDoctorName.FormattingEnabled = True
        Me.drpDoctorName.Location = New System.Drawing.Point(473, 55)
        Me.drpDoctorName.Name = "drpDoctorName"
        Me.drpDoctorName.Size = New System.Drawing.Size(180, 21)
        Me.drpDoctorName.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(106, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Supplier Name"
        '
        'drpSupplierName
        '
        Me.drpSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpSupplierName.FormattingEnabled = True
        Me.drpSupplierName.Location = New System.Drawing.Point(201, 55)
        Me.drpSupplierName.Name = "drpSupplierName"
        Me.drpSupplierName.Size = New System.Drawing.Size(189, 21)
        Me.drpSupplierName.TabIndex = 43
        '
        'InvoiceDetailsBindingSource
        '
        Me.InvoiceDetailsBindingSource.DataMember = "InvoiceDetails"
        Me.InvoiceDetailsBindingSource.DataSource = Me.dsPurchaseReportDatewise
        '
        'dsPurchaseReportDatewise
        '
        Me.dsPurchaseReportDatewise.DataSetName = "dsPurchaseReportDatewise"
        Me.dsPurchaseReportDatewise.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.dsPurchaseReportDatewise
        '
        'InvoiceDetailsTableAdapter
        '
        Me.InvoiceDetailsTableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'PurchaseReportDatewise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 689)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.drpSupplierName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.drpDoctorName)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PurchaseReportDatewise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Report Datewise"
        CType(Me.InvoiceDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPurchaseReportDatewise, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents InvoiceDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsPurchaseReportDatewise As Pharmacy.dsPurchaseReportDatewise
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceDetailsTableAdapter As Pharmacy.dsPurchaseReportDatewiseTableAdapters.InvoiceDetailsTableAdapter
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.dsPurchaseReportDatewiseTableAdapters.FromToDateTableTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents drpDoctorName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents drpSupplierName As System.Windows.Forms.ComboBox
End Class
