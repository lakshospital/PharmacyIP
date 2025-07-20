<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductNearExpDate
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
        Me.StockDetails1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsLowStock = New Pharmacy.dsLowStock
        Me.StockDetails1TableAdapter = New Pharmacy.dsLowStockTableAdapters.StockDetails1TableAdapter
        CType(Me.StockDetails1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsLowStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsLowStock_StockDetails1"
        ReportDataSource1.Value = Me.StockDetails1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptProductNearExpDate.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(851, 572)
        Me.ReportViewer1.TabIndex = 0
        '
        'StockDetails1BindingSource
        '
        Me.StockDetails1BindingSource.DataMember = "StockDetails1"
        Me.StockDetails1BindingSource.DataSource = Me.dsLowStock
        '
        'dsLowStock
        '
        Me.dsLowStock.DataSetName = "dsLowStock"
        Me.dsLowStock.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StockDetails1TableAdapter
        '
        Me.StockDetails1TableAdapter.ClearBeforeFill = True
        '
        'ProductNearExpDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(875, 596)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.Name = "ProductNearExpDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Near ExpDate"
        CType(Me.StockDetails1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsLowStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents StockDetails1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsLowStock As Pharmacy.dsLowStock
    Friend WithEvents StockDetails1TableAdapter As Pharmacy.dsLowStockTableAdapters.StockDetails1TableAdapter
End Class
