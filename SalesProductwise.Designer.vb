<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesProductwise
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
        Me.DrugSlipDetails3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDrugSlipBetweenDate = New Pharmacy.dsDrugSlipBetweenDate
        Me.drpProductName = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.drpProductGroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdShow = New Glass.GlassButton
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DrugSlipDetails3TableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails3TableAdapter
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FromToDateTableTableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.FromToDateTableTableAdapter
        CType(Me.DrugSlipDetails3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DrugSlipDetails3BindingSource
        '
        Me.DrugSlipDetails3BindingSource.DataMember = "DrugSlipDetails3"
        Me.DrugSlipDetails3BindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'dsDrugSlipBetweenDate
        '
        Me.dsDrugSlipBetweenDate.DataSetName = "dsDrugSlipBetweenDate"
        Me.dsDrugSlipBetweenDate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'drpProductName
        '
        Me.drpProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductName.FormattingEnabled = True
        Me.drpProductName.Location = New System.Drawing.Point(507, 47)
        Me.drpProductName.Name = "drpProductName"
        Me.drpProductName.Size = New System.Drawing.Size(244, 21)
        Me.drpProductName.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(412, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "ProductName"
        '
        'drpProductGroup
        '
        Me.drpProductGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpProductGroup.FormattingEnabled = True
        Me.drpProductGroup.Location = New System.Drawing.Point(180, 47)
        Me.drpProductGroup.Name = "drpProductGroup"
        Me.drpProductGroup.Size = New System.Drawing.Size(215, 21)
        Me.drpProductGroup.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(85, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Product Group"
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(770, 18)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(112, 45)
        Me.cmdShow.TabIndex = 56
        Me.cmdShow.Text = "&Show"
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(489, 12)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 60
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(315, 12)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpfromDate.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(430, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(244, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "From Date"
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsDrugSlipBetweenDate_DrugSlipDetails3"
        ReportDataSource1.Value = Me.DrugSlipDetails3BindingSource
        ReportDataSource2.Name = "dsDrugSlipBetweenDate_FromToDateTable"
        ReportDataSource2.Value = Me.FromToDateTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptSalesProductwise.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 74)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(938, 516)
        Me.ReportViewer1.TabIndex = 61
        '
        'DrugSlipDetails3TableAdapter
        '
        Me.DrugSlipDetails3TableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'SalesProductwise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(962, 602)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.drpProductName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.drpProductGroup)
        Me.Controls.Add(Me.Label3)
        Me.MaximizeBox = False
        Me.Name = "SalesProductwise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Drug Slip Product wise"
        CType(Me.DrugSlipDetails3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents drpProductName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents drpProductGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DrugSlipDetails3BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsDrugSlipBetweenDate As Pharmacy.dsDrugSlipBetweenDate
    Friend WithEvents DrugSlipDetails3TableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails3TableAdapter
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.FromToDateTableTableAdapter
End Class
