<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeliveryReport
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
        Me.DrugSlipDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsTypewiseReport = New Pharmacy.dsTypewiseReport
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SingleTitleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdShow = New Glass.GlassButton
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.Label4 = New System.Windows.Forms.Label
        Me.drpDoctorName = New System.Windows.Forms.ComboBox
        Me.rdoBillDate = New System.Windows.Forms.RadioButton
        Me.rdoIncidentDate = New System.Windows.Forms.RadioButton
        Me.DrugSlipDetailsTableAdapter = New Pharmacy.dsTypewiseReportTableAdapters.DrugSlipDetailsTableAdapter
        Me.FromToDateTableTableAdapter = New Pharmacy.dsTypewiseReportTableAdapters.FromToDateTableTableAdapter
        Me.SingleTitleTableAdapter = New Pharmacy.dsTypewiseReportTableAdapters.SingleTitleTableAdapter
        Me.dsTemplate = New Pharmacy.dsTemplate
        Me.OTTemplateTableAdapter = New Pharmacy.dsTemplateTableAdapters.OTTemplateTableAdapter
        Me.DrugSlipDetailsBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.OTTemplateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DrugSlipDetails1TableAdapter = New Pharmacy.dsTemplateTableAdapters.DrugSlipDetails1TableAdapter
        Me.DrugSlipDetails1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DrugSlipDetailsTableAdapter2 = New Pharmacy.dsTemplateTableAdapters.DrugSlipDetailsTableAdapter
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsTypewiseReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SingleTitleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetailsBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OTTemplateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DrugSlipDetailsBindingSource
        '
        Me.DrugSlipDetailsBindingSource.DataMember = "DrugSlipDetails"
        Me.DrugSlipDetailsBindingSource.DataSource = Me.dsTypewiseReport
        '
        'dsTypewiseReport
        '
        Me.dsTypewiseReport.DataSetName = "dsTypewiseReport"
        Me.dsTypewiseReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.dsTypewiseReport
        '
        'SingleTitleBindingSource
        '
        Me.SingleTitleBindingSource.DataMember = "SingleTitle"
        Me.SingleTitleBindingSource.DataSource = Me.dsTypewiseReport
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(785, 20)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 40
        Me.cmdShow.Text = "&Show"
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(182, 43)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 39
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(182, 15)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpfromDate.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(111, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(111, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "From Date"
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsTypewiseReport_DrugSlipDetails"
        ReportDataSource1.Value = Me.DrugSlipDetailsBindingSource
        ReportDataSource2.Name = "dsTypewiseReport_FromToDateTable"
        ReportDataSource2.Value = Me.FromToDateTableBindingSource
        ReportDataSource3.Name = "dsTypewiseReport_SingleTitle"
        ReportDataSource3.Value = Me.SingleTitleBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptDeliveryReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 78)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1005, 581)
        Me.ReportViewer1.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(480, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Dr Name"
        '
        'drpDoctorName
        '
        Me.drpDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpDoctorName.FormattingEnabled = True
        Me.drpDoctorName.Location = New System.Drawing.Point(551, 30)
        Me.drpDoctorName.Name = "drpDoctorName"
        Me.drpDoctorName.Size = New System.Drawing.Size(215, 21)
        Me.drpDoctorName.TabIndex = 42
        '
        'rdoBillDate
        '
        Me.rdoBillDate.AutoSize = True
        Me.rdoBillDate.Checked = True
        Me.rdoBillDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBillDate.Location = New System.Drawing.Point(292, 19)
        Me.rdoBillDate.Name = "rdoBillDate"
        Me.rdoBillDate.Size = New System.Drawing.Size(125, 17)
        Me.rdoBillDate.TabIndex = 49
        Me.rdoBillDate.TabStop = True
        Me.rdoBillDate.Text = "Show by Bill Date"
        Me.rdoBillDate.UseVisualStyleBackColor = True
        '
        'rdoIncidentDate
        '
        Me.rdoIncidentDate.AutoSize = True
        Me.rdoIncidentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoIncidentDate.Location = New System.Drawing.Point(292, 44)
        Me.rdoIncidentDate.Name = "rdoIncidentDate"
        Me.rdoIncidentDate.Size = New System.Drawing.Size(170, 17)
        Me.rdoIncidentDate.TabIndex = 48
        Me.rdoIncidentDate.Text = "Show By Date of Incident"
        Me.rdoIncidentDate.UseVisualStyleBackColor = True
        '
        'DrugSlipDetailsTableAdapter
        '
        Me.DrugSlipDetailsTableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'SingleTitleTableAdapter
        '
        Me.SingleTitleTableAdapter.ClearBeforeFill = True
        '
        'dsTemplate
        '
        Me.dsTemplate.DataSetName = "dsTemplate"
        Me.dsTemplate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OTTemplateTableAdapter
        '
        Me.OTTemplateTableAdapter.ClearBeforeFill = True
        '
        'DrugSlipDetailsBindingSource2
        '
        Me.DrugSlipDetailsBindingSource2.DataMember = "DrugSlipDetails"
        Me.DrugSlipDetailsBindingSource2.DataSource = Me.dsTemplate
        '
        'OTTemplateBindingSource
        '
        Me.OTTemplateBindingSource.DataMember = "OTTemplate"
        Me.OTTemplateBindingSource.DataSource = Me.dsTemplate
        '
        'DrugSlipDetails1TableAdapter
        '
        Me.DrugSlipDetails1TableAdapter.ClearBeforeFill = True
        '
        'DrugSlipDetails1BindingSource
        '
        Me.DrugSlipDetails1BindingSource.DataMember = "DrugSlipDetails1"
        Me.DrugSlipDetails1BindingSource.DataSource = Me.dsTemplate
        '
        'DrugSlipDetailsTableAdapter2
        '
        Me.DrugSlipDetailsTableAdapter2.ClearBeforeFill = True
        '
        'DeliveryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 671)
        Me.Controls.Add(Me.rdoBillDate)
        Me.Controls.Add(Me.rdoIncidentDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.drpDoctorName)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "DeliveryReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Report"
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsTypewiseReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SingleTitleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetailsBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OTTemplateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents drpDoctorName As System.Windows.Forms.ComboBox
    Friend WithEvents DrugSlipDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsTypewiseReport As Pharmacy.dsTypewiseReport
    Friend WithEvents DrugSlipDetailsTableAdapter As Pharmacy.dsTypewiseReportTableAdapters.DrugSlipDetailsTableAdapter
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.dsTypewiseReportTableAdapters.FromToDateTableTableAdapter
    Friend WithEvents rdoBillDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoIncidentDate As System.Windows.Forms.RadioButton
    Friend WithEvents SingleTitleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SingleTitleTableAdapter As Pharmacy.dsTypewiseReportTableAdapters.SingleTitleTableAdapter
    Friend WithEvents dsTemplate As Pharmacy.dsTemplate
    Friend WithEvents OTTemplateTableAdapter As Pharmacy.dsTemplateTableAdapters.OTTemplateTableAdapter
    Friend WithEvents DrugSlipDetailsBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents OTTemplateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetails1TableAdapter As Pharmacy.dsTemplateTableAdapters.DrugSlipDetails1TableAdapter
    Friend WithEvents DrugSlipDetails1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetailsTableAdapter2 As Pharmacy.dsTemplateTableAdapters.DrugSlipDetailsTableAdapter
End Class
