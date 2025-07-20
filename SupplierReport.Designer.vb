<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierReport
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dsSuppliers = New Pharmacy.dsSuppliers
        Me.SupplierMasterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SupplierMasterTableAdapter = New Pharmacy.dsSuppliersTableAdapters.SupplierMasterTableAdapter
        CType(Me.dsSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SupplierMasterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsSuppliers_SupplierMaster"
        ReportDataSource1.Value = Me.SupplierMasterBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptSuppliers.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(772, 569)
        Me.ReportViewer1.TabIndex = 0
        '
        'dsSuppliers
        '
        Me.dsSuppliers.DataSetName = "dsSuppliers"
        Me.dsSuppliers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SupplierMasterBindingSource
        '
        Me.SupplierMasterBindingSource.DataMember = "SupplierMaster"
        Me.SupplierMasterBindingSource.DataSource = Me.dsSuppliers
        '
        'SupplierMasterTableAdapter
        '
        Me.SupplierMasterTableAdapter.ClearBeforeFill = True
        '
        'SupplierReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 593)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "SupplierReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier Report"
        CType(Me.dsSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SupplierMasterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents SupplierMasterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsSuppliers As Pharmacy.dsSuppliers
    Friend WithEvents SupplierMasterTableAdapter As Pharmacy.dsSuppliersTableAdapters.SupplierMasterTableAdapter
End Class
