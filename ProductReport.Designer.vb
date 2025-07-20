<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductReport
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
        Me.ProductMasterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsProducts = New Pharmacy.dsProducts
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ProductMasterTableAdapter = New Pharmacy.dsProductsTableAdapters.ProductMasterTableAdapter
        CType(Me.ProductMasterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProductMasterBindingSource
        '
        Me.ProductMasterBindingSource.DataMember = "ProductMaster"
        Me.ProductMasterBindingSource.DataSource = Me.dsProducts
        '
        'dsProducts
        '
        Me.dsProducts.DataSetName = "dsProducts"
        Me.dsProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsProducts_ProductMaster"
        ReportDataSource1.Value = Me.ProductMasterBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptProducts.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(773, 579)
        Me.ReportViewer1.TabIndex = 0
        '
        'ProductMasterTableAdapter
        '
        Me.ProductMasterTableAdapter.ClearBeforeFill = True
        '
        'ProductReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(797, 603)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ProductReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Report"
        CType(Me.ProductMasterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ProductMasterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsProducts As Pharmacy.dsProducts
    Friend WithEvents ProductMasterTableAdapter As Pharmacy.dsProductsTableAdapters.ProductMasterTableAdapter
End Class
