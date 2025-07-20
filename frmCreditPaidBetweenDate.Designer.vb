<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditPaidBetweenDate
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.cmdShow = New Glass.GlassButton
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataSet3 = New Pharmacy.DataSet3
        Me.CreditPaidBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CreditPaidTableAdapter = New Pharmacy.DataSet3TableAdapters.CreditPaidTableAdapter
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FromToDateTableTableAdapter = New Pharmacy.DataSet3TableAdapters.FromToDateTableTableAdapter
        Me.DataSet1 = New Pharmacy.DataSet1
        Me.DrugSlipDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DrugSlipDetailsTableAdapter = New Pharmacy.DataSet1TableAdapters.DrugSlipDetailsTableAdapter
        Me.PaymentHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PaymentHistoryTableAdapter = New Pharmacy.DataSet1TableAdapters.PaymentHistoryTableAdapter
        CType(Me.DataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditPaidBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet3_CreditPaid"
        ReportDataSource1.Value = Me.CreditPaidBindingSource
        ReportDataSource2.Name = "DataSet3_FromToDateTable"
        ReportDataSource2.Value = Me.FromToDateTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptCreditPaid.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 56)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(846, 558)
        Me.ReportViewer1.TabIndex = 0
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(584, 9)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 45
        Me.cmdShow.Text = "&Show"
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(463, 18)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 44
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(289, 18)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpfromDate.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(404, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(218, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "From Date"
        '
        'DataSet3
        '
        Me.DataSet3.DataSetName = "DataSet3"
        Me.DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CreditPaidBindingSource
        '
        Me.CreditPaidBindingSource.DataMember = "CreditPaid"
        Me.CreditPaidBindingSource.DataSource = Me.DataSet3
        '
        'CreditPaidTableAdapter
        '
        Me.CreditPaidTableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.DataSet3
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DrugSlipDetailsBindingSource
        '
        Me.DrugSlipDetailsBindingSource.DataMember = "DrugSlipDetails"
        Me.DrugSlipDetailsBindingSource.DataSource = Me.DataSet1
        '
        'DrugSlipDetailsTableAdapter
        '
        Me.DrugSlipDetailsTableAdapter.ClearBeforeFill = True
        '
        'PaymentHistoryBindingSource
        '
        Me.PaymentHistoryBindingSource.DataMember = "PaymentHistory"
        Me.PaymentHistoryBindingSource.DataSource = Me.DataSet1
        '
        'PaymentHistoryTableAdapter
        '
        Me.PaymentHistoryTableAdapter.ClearBeforeFill = True
        '
        'frmCreditPaidBetweenDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 626)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.Name = "frmCreditPaidBetweenDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Credit Paid Between Date"
        CType(Me.DataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditPaidBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CreditPaidBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet3 As Pharmacy.DataSet3
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CreditPaidTableAdapter As Pharmacy.DataSet3TableAdapters.CreditPaidTableAdapter
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.DataSet3TableAdapters.FromToDateTableTableAdapter
    Friend WithEvents DrugSlipDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet1 As Pharmacy.DataSet1
    Friend WithEvents PaymentHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetailsTableAdapter As Pharmacy.DataSet1TableAdapters.DrugSlipDetailsTableAdapter
    Friend WithEvents PaymentHistoryTableAdapter As Pharmacy.DataSet1TableAdapters.PaymentHistoryTableAdapter
End Class
