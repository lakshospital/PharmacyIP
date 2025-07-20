<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OTTemplateReport
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
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource8 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource9 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.txtBillYear = New System.Windows.Forms.TextBox
        Me.cmdShow = New Glass.GlassButton
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.OTTemplateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsTemplate = New Pharmacy.dsTemplate
        Me.DrugSlipDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DrugSlipDetails1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OTTemplateTableAdapter = New Pharmacy.dsTemplateTableAdapters.OTTemplateTableAdapter
        Me.DrugSlipDetailsTableAdapter = New Pharmacy.dsTemplateTableAdapters.DrugSlipDetailsTableAdapter
        Me.DrugSlipDetails1TableAdapter = New Pharmacy.dsTemplateTableAdapters.DrugSlipDetails1TableAdapter
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.OTTemplateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(294, 17)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(100, 20)
        Me.txtBillNo.TabIndex = 0
        '
        'txtBillYear
        '
        Me.txtBillYear.Location = New System.Drawing.Point(473, 16)
        Me.txtBillYear.Name = "txtBillYear"
        Me.txtBillYear.Size = New System.Drawing.Size(100, 20)
        Me.txtBillYear.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(579, 10)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 31
        Me.cmdShow.Text = "&Show"
        '
        'ReportViewer1
        '
        ReportDataSource7.Name = "dsTemplate_OTTemplate"
        ReportDataSource7.Value = Me.OTTemplateBindingSource
        ReportDataSource8.Name = "dsTemplate_DrugSlipDetails"
        ReportDataSource8.Value = Me.DrugSlipDetailsBindingSource
        ReportDataSource9.Name = "dsTemplate_DrugSlipDetails1"
        ReportDataSource9.Value = Me.DrugSlipDetails1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource7)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource8)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource9)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptOTTemplate.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 60)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(805, 501)
        Me.ReportViewer1.TabIndex = 32
        '
        'OTTemplateBindingSource
        '
        Me.OTTemplateBindingSource.DataMember = "OTTemplate"
        Me.OTTemplateBindingSource.DataSource = Me.dsTemplate
        '
        'dsTemplate
        '
        Me.dsTemplate.DataSetName = "dsTemplate"
        Me.dsTemplate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DrugSlipDetailsBindingSource
        '
        Me.DrugSlipDetailsBindingSource.DataMember = "DrugSlipDetails"
        Me.DrugSlipDetailsBindingSource.DataSource = Me.dsTemplate
        '
        'DrugSlipDetails1BindingSource
        '
        Me.DrugSlipDetails1BindingSource.DataMember = "DrugSlipDetails1"
        Me.DrugSlipDetails1BindingSource.DataSource = Me.dsTemplate
        '
        'OTTemplateTableAdapter
        '
        Me.OTTemplateTableAdapter.ClearBeforeFill = True
        '
        'DrugSlipDetailsTableAdapter
        '
        Me.DrugSlipDetailsTableAdapter.ClearBeforeFill = True
        '
        'DrugSlipDetails1TableAdapter
        '
        Me.DrugSlipDetails1TableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(244, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Bill No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(413, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Bill Year"
        '
        'OTTemplateReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 573)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtBillYear)
        Me.Controls.Add(Me.txtBillNo)
        Me.MaximizeBox = False
        Me.Name = "OTTemplateReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OT Template Report"
        CType(Me.OTTemplateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents txtBillYear As System.Windows.Forms.TextBox
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents OTTemplateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsTemplate As Pharmacy.dsTemplate
    Friend WithEvents OTTemplateTableAdapter As Pharmacy.dsTemplateTableAdapters.OTTemplateTableAdapter
    Friend WithEvents DrugSlipDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetailsTableAdapter As Pharmacy.dsTemplateTableAdapters.DrugSlipDetailsTableAdapter
    Friend WithEvents DrugSlipDetails1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetails1TableAdapter As Pharmacy.dsTemplateTableAdapters.DrugSlipDetails1TableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
