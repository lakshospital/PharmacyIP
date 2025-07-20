<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CancelBillsBetweenDatewiseConsolidate
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
        Me.DrugSlipDetails1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDrugSlipBetweenDate = New Pharmacy.dsDrugSlipBetweenDate
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdShow = New Glass.GlassButton
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DrugSlipDetails1TableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails1TableAdapter
        Me.FromToDateTableTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.FromToDateTableTableAdapter
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DrugSlipDetails1BindingSource
        '
        Me.DrugSlipDetails1BindingSource.DataMember = "DrugSlipDetails1"
        Me.DrugSlipDetails1BindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'dsDrugSlipBetweenDate
        '
        Me.dsDrugSlipBetweenDate.DataSetName = "dsDrugSlipBetweenDate"
        Me.dsDrugSlipBetweenDate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(576, 3)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 30
        Me.cmdShow.Text = "&Show"
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(455, 12)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 29
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(281, 12)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpfromDate.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(396, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(210, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "From Date"
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsDrugSlipBetweenDate_DrugSlipDetails1"
        ReportDataSource1.Value = Me.DrugSlipDetails1BindingSource
        ReportDataSource2.Name = "dsDrugSlipBetweenDate_FromToDateTable"
        ReportDataSource2.Value = Me.FromToDateTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptCancelBillsBetweenDatewiseConsolidate.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 47)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(847, 604)
        Me.ReportViewer1.TabIndex = 31
        '
        'DrugSlipDetails1TableAdapter
        '
        Me.DrugSlipDetails1TableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'CancelBillsBetweenDatewiseConsolidate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 663)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "CancelBillsBetweenDatewiseConsolidate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancel Bills Between Datewise Consolidate"
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DrugSlipDetails1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsDrugSlipBetweenDate As Pharmacy.dsDrugSlipBetweenDate
    Friend WithEvents DrugSlipDetails1TableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails1TableAdapter
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.FromToDateTableTableAdapter
End Class
