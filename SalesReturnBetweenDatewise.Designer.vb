<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesReturnBetweenDatewise
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.SalesReturnDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsSalesReturnBetweenDate = New Pharmacy.dsSalesReturnBetweenDate
        Me.FromToDateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SingleTitleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdShow = New Glass.GlassButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.SalesReturnDetailsTableAdapter = New Pharmacy.dsSalesReturnBetweenDateTableAdapters.SalesReturnDetailsTableAdapter
        Me.FromToDateTableTableAdapter = New Pharmacy.dsSalesReturnBetweenDateTableAdapters.FromToDateTableTableAdapter
        Me.SingleTitleTableAdapter = New Pharmacy.dsSalesReturnBetweenDateTableAdapters.SingleTitleTableAdapter
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        CType(Me.SalesReturnDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsSalesReturnBetweenDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SingleTitleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SalesReturnDetailsBindingSource
        '
        Me.SalesReturnDetailsBindingSource.DataMember = "SalesReturnDetails"
        Me.SalesReturnDetailsBindingSource.DataSource = Me.dsSalesReturnBetweenDate
        '
        'dsSalesReturnBetweenDate
        '
        Me.dsSalesReturnBetweenDate.DataSetName = "dsSalesReturnBetweenDate"
        Me.dsSalesReturnBetweenDate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FromToDateTableBindingSource
        '
        Me.FromToDateTableBindingSource.DataMember = "FromToDateTable"
        Me.FromToDateTableBindingSource.DataSource = Me.dsSalesReturnBetweenDate
        '
        'SingleTitleBindingSource
        '
        Me.SingleTitleBindingSource.DataMember = "SingleTitle"
        Me.SingleTitleBindingSource.DataSource = Me.dsSalesReturnBetweenDate
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(811, 3)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 30
        Me.cmdShow.Text = "&Show"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(287, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "From Date"
        '
        'ReportViewer1
        '
        ReportDataSource4.Name = "dsSalesReturnBetweenDate_SalesReturnDetails"
        ReportDataSource4.Value = Me.SalesReturnDetailsBindingSource
        ReportDataSource5.Name = "dsSalesReturnBetweenDate_FromToDateTable"
        ReportDataSource5.Value = Me.FromToDateTableBindingSource
        ReportDataSource6.Name = "dsSalesReturnBetweenDate_SingleTitle"
        ReportDataSource6.Value = Me.SingleTitleBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource6)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptSalesReturnBetweenDatewise.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 47)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(903, 647)
        Me.ReportViewer1.TabIndex = 31
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(547, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(137, 17)
        Me.RadioButton1.TabIndex = 32
        Me.RadioButton1.Text = "Show Cashless Bills"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(690, 14)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(115, 17)
        Me.RadioButton2.TabIndex = 33
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Show Cash Bills"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'SalesReturnDetailsTableAdapter
        '
        Me.SalesReturnDetailsTableAdapter.ClearBeforeFill = True
        '
        'FromToDateTableTableAdapter
        '
        Me.FromToDateTableTableAdapter.ClearBeforeFill = True
        '
        'SingleTitleTableAdapter
        '
        Me.SingleTitleTableAdapter.ClearBeforeFill = True
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(123, 16)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(122, 20)
        Me.dtpfromDate.TabIndex = 40
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(369, 14)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(138, 20)
        Me.dtpToDate.TabIndex = 41
        '
        'SalesReturnBetweenDatewise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(927, 706)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SalesReturnBetweenDatewise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Return Between Datewise"
        CType(Me.SalesReturnDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsSalesReturnBetweenDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromToDateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SingleTitleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents SalesReturnDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsSalesReturnBetweenDate As Pharmacy.dsSalesReturnBetweenDate
    Friend WithEvents SalesReturnDetailsTableAdapter As Pharmacy.dsSalesReturnBetweenDateTableAdapters.SalesReturnDetailsTableAdapter
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents FromToDateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SingleTitleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FromToDateTableTableAdapter As Pharmacy.dsSalesReturnBetweenDateTableAdapters.FromToDateTableTableAdapter
    Friend WithEvents SingleTitleTableAdapter As Pharmacy.dsSalesReturnBetweenDateTableAdapters.SingleTitleTableAdapter
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
End Class
