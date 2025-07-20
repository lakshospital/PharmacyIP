<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LowStock
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
        Me.DrugSlipDetails1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsLowStock = New Pharmacy.dsLowStock
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.drpProductGroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DrugSlipDetails1TableAdapter = New Pharmacy.dsLowStockTableAdapters.DrugSlipDetails1TableAdapter
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsLowStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DrugSlipDetails1BindingSource
        '
        Me.DrugSlipDetails1BindingSource.DataMember = "DrugSlipDetails1"
        Me.DrugSlipDetails1BindingSource.DataSource = Me.dsLowStock
        '
        'dsLowStock
        '
        Me.dsLowStock.DataSetName = "dsLowStock"
        Me.dsLowStock.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsLowStock_DrugSlipDetails1"
        ReportDataSource1.Value = Me.DrugSlipDetails1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptProudctsInLowStock.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 48)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(765, 499)
        Me.ReportViewer1.TabIndex = 0
        '
        'drpProductGroup
        '
        Me.drpProductGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductGroup.FormattingEnabled = True
        Me.drpProductGroup.Location = New System.Drawing.Point(341, 12)
        Me.drpProductGroup.Name = "drpProductGroup"
        Me.drpProductGroup.Size = New System.Drawing.Size(215, 21)
        Me.drpProductGroup.TabIndex = 79
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(246, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Product Group"
        '
        'DrugSlipDetails1TableAdapter
        '
        Me.DrugSlipDetails1TableAdapter.ClearBeforeFill = True
        '
        'LowStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(789, 556)
        Me.Controls.Add(Me.drpProductGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.Name = "LowStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Low Stock"
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsLowStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DrugSlipDetails1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsLowStock As Pharmacy.dsLowStock
    Friend WithEvents DrugSlipDetails1TableAdapter As Pharmacy.dsLowStockTableAdapters.DrugSlipDetails1TableAdapter
    Friend WithEvents drpProductGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
