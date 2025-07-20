<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dsTemplate = New Pharmacy.dsTemplate
        Me.OTTemplateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OTTemplateTableAdapter = New Pharmacy.dsTemplateTableAdapters.OTTemplateTableAdapter
        Me.DrugSlipDetailsBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DrugSlipDetailsTableAdapter2 = New Pharmacy.dsTemplateTableAdapters.DrugSlipDetailsTableAdapter
        Me.DrugSlipDetails1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DrugSlipDetails1TableAdapter = New Pharmacy.dsTemplateTableAdapters.DrugSlipDetails1TableAdapter
        CType(Me.dsTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OTTemplateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetailsBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(53, 66)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(53, 30)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(114, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsTemplate_OTTemplate"
        ReportDataSource1.Value = Me.OTTemplateBindingSource
        ReportDataSource2.Name = "dsTemplate_DrugSlipDetails"
        ReportDataSource2.Value = Me.DrugSlipDetailsBindingSource2
        ReportDataSource3.Name = "dsTemplate_DrugSlipDetails1"
        ReportDataSource3.Value = Me.DrugSlipDetails1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptOTTemplate.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(53, 166)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(400, 250)
        Me.ReportViewer1.TabIndex = 2
        '
        'dsTemplate
        '
        Me.dsTemplate.DataSetName = "dsTemplate"
        Me.dsTemplate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OTTemplateBindingSource
        '
        Me.OTTemplateBindingSource.DataMember = "OTTemplate"
        Me.OTTemplateBindingSource.DataSource = Me.dsTemplate
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
        'DrugSlipDetailsTableAdapter2
        '
        Me.DrugSlipDetailsTableAdapter2.ClearBeforeFill = True
        '
        'DrugSlipDetails1BindingSource
        '
        Me.DrugSlipDetails1BindingSource.DataMember = "DrugSlipDetails1"
        Me.DrugSlipDetails1BindingSource.DataSource = Me.dsTemplate
        '
        'DrugSlipDetails1TableAdapter
        '
        Me.DrugSlipDetails1TableAdapter.ClearBeforeFill = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 537)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.dsTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OTTemplateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetailsBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents OTTemplateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsTemplate As Pharmacy.dsTemplate
    Friend WithEvents DrugSlipDetailsBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetails1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OTTemplateTableAdapter As Pharmacy.dsTemplateTableAdapters.OTTemplateTableAdapter
    Friend WithEvents DrugSlipDetailsTableAdapter2 As Pharmacy.dsTemplateTableAdapters.DrugSlipDetailsTableAdapter
    Friend WithEvents DrugSlipDetails1TableAdapter As Pharmacy.dsTemplateTableAdapters.DrugSlipDetails1TableAdapter
End Class
