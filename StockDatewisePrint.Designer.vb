<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockDatewisePrint
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
        Me.StockPrintBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsStockDatewisePrint = New Pharmacy.dsStockDatewisePrint
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.StockPrintTableAdapter = New Pharmacy.dsStockDatewisePrintTableAdapters.StockPrintTableAdapter
        Me.FromToDateTableTableAdapter = New Pharmacy.dsStockDatewisePrintTableAdapters.FromToDateTableTableAdapter
        CType(Me.StockPrintBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsStockDatewisePrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StockPrintBindingSource
        '
        Me.StockPrintBindingSource.DataMember = "StockPrint"
        Me.StockPrintBindingSource.DataSource = Me.dsStockDatewisePrint
        '
        'dsStockDatewisePrint
        '
        Me.dsStockDatewisePrint.DataSetName = "dsStockDatewisePrint"
        Me.dsStockDatewisePrint.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.dsStockDatewisePrint
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsStockDatewisePrint_StockPrint"
        ReportDataSource1.Value = Me.StockPrintBindingSource
        ReportDataSource2.Name = "dsStockDatewisePrint_FromToDateTable"
        ReportDataSource2.Value = Me.FromToDateTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptStockPrint.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(893, 576)
        Me.ReportViewer1.TabIndex = 0
        '
        'StockPrintTableAdapter
        '
        Me.StockPrintTableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'StockDatewisePrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 600)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "StockDatewisePrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Datewise Print"
        CType(Me.StockPrintBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsStockDatewisePrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents StockPrintBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsStockDatewisePrint As Pharmacy.dsStockDatewisePrint
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StockPrintTableAdapter As Pharmacy.dsStockDatewisePrintTableAdapters.StockPrintTableAdapter
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.dsStockDatewisePrintTableAdapters.FromToDateTableTableAdapter
End Class
