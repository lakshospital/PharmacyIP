<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAmountToReturn
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
        Me.DrugSlipDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet2 = New Pharmacy.DataSet2
        Me.PaymentHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.PaymentDueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PaymentDueTableAdapter = New Pharmacy.DataSet2TableAdapters.PaymentDueTableAdapter
        Me.DrugSlipDetailsTableAdapter = New Pharmacy.DataSet2TableAdapters.DrugSlipDetailsTableAdapter
        Me.PaymentHistoryTableAdapter = New Pharmacy.DataSet2TableAdapters.PaymentHistoryTableAdapter
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentDueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DrugSlipDetailsBindingSource
        '
        Me.DrugSlipDetailsBindingSource.DataMember = "DrugSlipDetails"
        Me.DrugSlipDetailsBindingSource.DataSource = Me.DataSet2
        '
        'DataSet2
        '
        Me.DataSet2.DataSetName = "DataSet2"
        Me.DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PaymentHistoryBindingSource
        '
        Me.PaymentHistoryBindingSource.DataMember = "PaymentHistory"
        Me.PaymentHistoryBindingSource.DataSource = Me.DataSet2
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet2_PaymentDue"
        ReportDataSource1.Value = Me.PaymentDueBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptAmountReturn.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(949, 620)
        Me.ReportViewer1.TabIndex = 0
        '
        'PaymentDueBindingSource
        '
        Me.PaymentDueBindingSource.DataMember = "PaymentDue"
        Me.PaymentDueBindingSource.DataSource = Me.DataSet2
        '
        'PaymentDueTableAdapter
        '
        Me.PaymentDueTableAdapter.ClearBeforeFill = True
        '
        'DrugSlipDetailsTableAdapter
        '
        Me.DrugSlipDetailsTableAdapter.ClearBeforeFill = True
        '
        'PaymentHistoryTableAdapter
        '
        Me.PaymentHistoryTableAdapter.ClearBeforeFill = True
        '
        'frmAmountToReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 644)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.Name = "frmAmountToReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amount To Return"
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentDueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PaymentDueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet2 As Pharmacy.DataSet2
    Friend WithEvents PaymentDueTableAdapter As Pharmacy.DataSet2TableAdapters.PaymentDueTableAdapter
    Friend WithEvents DrugSlipDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetailsTableAdapter As Pharmacy.DataSet2TableAdapters.DrugSlipDetailsTableAdapter
    Friend WithEvents PaymentHistoryTableAdapter As Pharmacy.DataSet2TableAdapters.PaymentHistoryTableAdapter
End Class
