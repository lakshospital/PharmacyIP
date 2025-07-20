<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditToBePaidBetweenDate
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.cmdShow = New Glass.GlassButton
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DataSet3 = New Pharmacy.DataSet3
        Me.CreditToBePaidBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CreditToBePaidTableAdapter = New Pharmacy.DataSet3TableAdapters.CreditToBePaidTableAdapter
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FromToDateTableTableAdapter = New Pharmacy.DataSet3TableAdapters.FromToDateTableTableAdapter
        Me.DataSet1 = New Pharmacy.DataSet1
        Me.DrugSlipDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DrugSlipDetailsTableAdapter = New Pharmacy.DataSet1TableAdapters.DrugSlipDetailsTableAdapter
        Me.PaymentHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PaymentHistoryTableAdapter = New Pharmacy.DataSet1TableAdapters.PaymentHistoryTableAdapter
        CType(Me.DataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditToBePaidBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(563, 7)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 50
        Me.cmdShow.Text = "&Show"
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(442, 16)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 49
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(268, 16)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpfromDate.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(383, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(197, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "From Date"
        '
        'ReportViewer1
        '
        ReportDataSource3.Name = "DataSet3_CreditToBePaid"
        ReportDataSource3.Value = Me.CreditToBePaidBindingSource
        ReportDataSource4.Name = "DataSet3_FromToDateTable"
        ReportDataSource4.Value = Me.FromToDateTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptCreditToBePaidBetweenDate.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 64)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(840, 551)
        Me.ReportViewer1.TabIndex = 51
        '
        'DataSet3
        '
        Me.DataSet3.DataSetName = "DataSet3"
        Me.DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CreditToBePaidBindingSource
        '
        Me.CreditToBePaidBindingSource.DataMember = "CreditToBePaid"
        Me.CreditToBePaidBindingSource.DataSource = Me.DataSet3
        '
        'CreditToBePaidTableAdapter
        '
        Me.CreditToBePaidTableAdapter.ClearBeforeFill = True
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
        'frmCreditToBePaidBetweenDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 627)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmCreditToBePaidBetweenDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Credit To Be PaidBetween Date"
        CType(Me.DataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditToBePaidBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CreditToBePaidBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet3 As Pharmacy.DataSet3
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CreditToBePaidTableAdapter As Pharmacy.DataSet3TableAdapters.CreditToBePaidTableAdapter
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.DataSet3TableAdapters.FromToDateTableTableAdapter
    Friend WithEvents DrugSlipDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet1 As Pharmacy.DataSet1
    Friend WithEvents PaymentHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetailsTableAdapter As Pharmacy.DataSet1TableAdapters.DrugSlipDetailsTableAdapter
    Friend WithEvents PaymentHistoryTableAdapter As Pharmacy.DataSet1TableAdapters.PaymentHistoryTableAdapter
End Class
