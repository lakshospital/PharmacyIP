<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrugSlipBetweenDateConsolidate
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource8 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource9 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource10 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource11 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource12 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource13 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.DrugSlipDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDrugSlipBetweenDate = New Pharmacy.dsDrugSlipBetweenDate
        Me.DrugSlipDetails1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DrugSlipDetails4BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AmountReturnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesReturnTotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CashlessBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AmountToReturnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Credit1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Credit2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExcessAmountBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CancelBillsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesReturnTotCashLessBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.cmdShow = New Glass.GlassButton
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DrugSlipDetailsTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetailsTableAdapter
        Me.DrugSlipDetails1TableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails1TableAdapter
        Me.FromToDateTableTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.FromToDateTableTableAdapter
        Me.DrugSlipDetails4TableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails4TableAdapter
        Me.AmountReturnTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.AmountReturnTableAdapter
        Me.SalesReturnTotTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.SalesReturnTotTableAdapter
        Me.CashlessTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.CashlessTableAdapter
        Me.AmountToReturnTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.AmountToReturnTableAdapter
        Me.Credit1TableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.Credit1TableAdapter
        Me.Credit2TableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.Credit2TableAdapter
        Me.ExcessAmountTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.ExcessAmountTableAdapter
        Me.CancelBillsTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.CancelBillsTableAdapter
        Me.dtpFromTime = New System.Windows.Forms.DateTimePicker
        Me.dtpToTime = New System.Windows.Forms.DateTimePicker
        Me.chkIncludeTime = New System.Windows.Forms.CheckBox
        Me.SalesReturnTotCashLessTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.SalesReturnTotCashLessTableAdapter
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DrugSlipDetails4BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountReturnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesReturnTotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CashlessBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountToReturnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Credit1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Credit2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExcessAmountBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelBillsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesReturnTotCashLessBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DrugSlipDetailsBindingSource
        '
        Me.DrugSlipDetailsBindingSource.DataMember = "DrugSlipDetails"
        Me.DrugSlipDetailsBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'dsDrugSlipBetweenDate
        '
        Me.dsDrugSlipBetweenDate.DataSetName = "dsDrugSlipBetweenDate"
        Me.dsDrugSlipBetweenDate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DrugSlipDetails1BindingSource
        '
        Me.DrugSlipDetails1BindingSource.DataMember = "DrugSlipDetails1"
        Me.DrugSlipDetails1BindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'DrugSlipDetails4BindingSource
        '
        Me.DrugSlipDetails4BindingSource.DataMember = "DrugSlipDetails4"
        Me.DrugSlipDetails4BindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'AmountReturnBindingSource
        '
        Me.AmountReturnBindingSource.DataMember = "AmountReturn"
        Me.AmountReturnBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'SalesReturnTotBindingSource
        '
        Me.SalesReturnTotBindingSource.DataMember = "SalesReturnTot"
        Me.SalesReturnTotBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'CashlessBindingSource
        '
        Me.CashlessBindingSource.DataMember = "Cashless"
        Me.CashlessBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'AmountToReturnBindingSource
        '
        Me.AmountToReturnBindingSource.DataMember = "AmountToReturn"
        Me.AmountToReturnBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'Credit1BindingSource
        '
        Me.Credit1BindingSource.DataMember = "Credit1"
        Me.Credit1BindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'Credit2BindingSource
        '
        Me.Credit2BindingSource.DataMember = "Credit2"
        Me.Credit2BindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'ExcessAmountBindingSource
        '
        Me.ExcessAmountBindingSource.DataMember = "ExcessAmount"
        Me.ExcessAmountBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'CancelBillsBindingSource
        '
        Me.CancelBillsBindingSource.DataMember = "CancelBills"
        Me.CancelBillsBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'SalesReturnTotCashLessBindingSource
        '
        Me.SalesReturnTotCashLessBindingSource.DataMember = "SalesReturnTotCashLess"
        Me.SalesReturnTotCashLessBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsDrugSlipBetweenDate_DrugSlipDetails"
        ReportDataSource1.Value = Me.DrugSlipDetailsBindingSource
        ReportDataSource2.Name = "dsDrugSlipBetweenDate_DrugSlipDetails1"
        ReportDataSource2.Value = Me.DrugSlipDetails1BindingSource
        ReportDataSource3.Name = "dsDrugSlipBetweenDate_FromToDateTable"
        ReportDataSource3.Value = Me.FromToDateTableBindingSource
        ReportDataSource4.Name = "dsDrugSlipBetweenDate_DrugSlipDetails4"
        ReportDataSource4.Value = Me.DrugSlipDetails4BindingSource
        ReportDataSource5.Name = "dsDrugSlipBetweenDate_AmountReturn"
        ReportDataSource5.Value = Me.AmountReturnBindingSource
        ReportDataSource6.Name = "dsDrugSlipBetweenDate_SalesReturnTot"
        ReportDataSource6.Value = Me.SalesReturnTotBindingSource
        ReportDataSource7.Name = "dsDrugSlipBetweenDate_Cashless"
        ReportDataSource7.Value = Me.CashlessBindingSource
        ReportDataSource8.Name = "dsDrugSlipBetweenDate_AmountToReturn"
        ReportDataSource8.Value = Me.AmountToReturnBindingSource
        ReportDataSource9.Name = "dsDrugSlipBetweenDate_Credit1"
        ReportDataSource9.Value = Me.Credit1BindingSource
        ReportDataSource10.Name = "dsDrugSlipBetweenDate_Credit2"
        ReportDataSource10.Value = Me.Credit2BindingSource
        ReportDataSource11.Name = "dsDrugSlipBetweenDate_ExcessAmount"
        ReportDataSource11.Value = Me.ExcessAmountBindingSource
        ReportDataSource12.Name = "dsDrugSlipBetweenDate_CancelBills"
        ReportDataSource12.Value = Me.CancelBillsBindingSource
        ReportDataSource13.Name = "dsDrugSlipBetweenDate_SalesReturnTotCashLess"
        ReportDataSource13.Value = Me.SalesReturnTotCashLessBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource6)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource7)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource8)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource9)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource10)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource11)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource12)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource13)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptDrugSlipBetweenDateConsolidate.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 60)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(911, 602)
        Me.ReportViewer1.TabIndex = 0
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(670, 12)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 40
        Me.cmdShow.Text = "&Show"
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(368, 21)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 39
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(96, 21)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpfromDate.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(309, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "From Date"
        '
        'DrugSlipDetailsTableAdapter
        '
        Me.DrugSlipDetailsTableAdapter.ClearBeforeFill = True
        '
        'DrugSlipDetails1TableAdapter
        '
        Me.DrugSlipDetails1TableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'DrugSlipDetails4TableAdapter
        '
        Me.DrugSlipDetails4TableAdapter.ClearBeforeFill = True
        '
        'AmountReturnTableAdapter
        '
        Me.AmountReturnTableAdapter.ClearBeforeFill = True
        '
        'SalesReturnTotTableAdapter
        '
        Me.SalesReturnTotTableAdapter.ClearBeforeFill = True
        '
        'CashlessTableAdapter
        '
        Me.CashlessTableAdapter.ClearBeforeFill = True
        '
        'AmountToReturnTableAdapter
        '
        Me.AmountToReturnTableAdapter.ClearBeforeFill = True
        '
        'Credit1TableAdapter
        '
        Me.Credit1TableAdapter.ClearBeforeFill = True
        '
        'Credit2TableAdapter
        '
        Me.Credit2TableAdapter.ClearBeforeFill = True
        '
        'ExcessAmountTableAdapter
        '
        Me.ExcessAmountTableAdapter.ClearBeforeFill = True
        '
        'CancelBillsTableAdapter
        '
        Me.CancelBillsTableAdapter.ClearBeforeFill = True
        '
        'dtpFromTime
        '
        Me.dtpFromTime.CustomFormat = "hh:mm tt"
        Me.dtpFromTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromTime.Location = New System.Drawing.Point(196, 21)
        Me.dtpFromTime.Name = "dtpFromTime"
        Me.dtpFromTime.ShowUpDown = True
        Me.dtpFromTime.Size = New System.Drawing.Size(83, 20)
        Me.dtpFromTime.TabIndex = 41
        '
        'dtpToTime
        '
        Me.dtpToTime.CustomFormat = "hh:mm tt"
        Me.dtpToTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToTime.Location = New System.Drawing.Point(468, 21)
        Me.dtpToTime.Name = "dtpToTime"
        Me.dtpToTime.ShowUpDown = True
        Me.dtpToTime.Size = New System.Drawing.Size(94, 20)
        Me.dtpToTime.TabIndex = 42
        '
        'chkIncludeTime
        '
        Me.chkIncludeTime.AutoSize = True
        Me.chkIncludeTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncludeTime.Location = New System.Drawing.Point(568, 24)
        Me.chkIncludeTime.Name = "chkIncludeTime"
        Me.chkIncludeTime.Size = New System.Drawing.Size(99, 17)
        Me.chkIncludeTime.TabIndex = 43
        Me.chkIncludeTime.Text = "Include Time"
        Me.chkIncludeTime.UseVisualStyleBackColor = True
        '
        'SalesReturnTotCashLessTableAdapter
        '
        Me.SalesReturnTotCashLessTableAdapter.ClearBeforeFill = True
        '
        'DrugSlipBetweenDateConsolidate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 674)
        Me.Controls.Add(Me.chkIncludeTime)
        Me.Controls.Add(Me.dtpToTime)
        Me.Controls.Add(Me.dtpFromTime)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.Name = "DrugSlipBetweenDateConsolidate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DrugSlip Between Date Consolidate"
        CType(Me.DrugSlipDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DrugSlipDetails4BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountReturnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesReturnTotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CashlessBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountToReturnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Credit1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Credit2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExcessAmountBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelBillsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesReturnTotCashLessBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DrugSlipDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsDrugSlipBetweenDate As Pharmacy.dsDrugSlipBetweenDate
    Friend WithEvents DrugSlipDetails1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DrugSlipDetails4BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AmountReturnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesReturnTotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CashlessBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AmountToReturnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Credit1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Credit2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DrugSlipDetailsTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetailsTableAdapter
    Friend WithEvents DrugSlipDetails1TableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails1TableAdapter
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.FromToDateTableTableAdapter
    Friend WithEvents DrugSlipDetails4TableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails4TableAdapter
    Friend WithEvents AmountReturnTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.AmountReturnTableAdapter
    Friend WithEvents SalesReturnTotTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.SalesReturnTotTableAdapter
    Friend WithEvents CashlessTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.CashlessTableAdapter
    Friend WithEvents AmountToReturnTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.AmountToReturnTableAdapter
    Friend WithEvents Credit1TableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.Credit1TableAdapter
    Friend WithEvents Credit2TableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.Credit2TableAdapter
    Friend WithEvents ExcessAmountBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ExcessAmountTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.ExcessAmountTableAdapter
    Friend WithEvents CancelBillsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CancelBillsTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.CancelBillsTableAdapter
    Friend WithEvents dtpFromTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkIncludeTime As System.Windows.Forms.CheckBox
    Friend WithEvents SalesReturnTotCashLessBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesReturnTotCashLessTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.SalesReturnTotCashLessTableAdapter
End Class
