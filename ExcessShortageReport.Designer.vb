<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExcessShortageReport
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpfromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdShow = New Glass.GlassButton
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dsExcessShortage = New Pharmacy.dsExcessShortage
        Me.ESTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ESTableTableAdapter = New Pharmacy.dsExcessShortageTableAdapters.ESTableTableAdapter
        CType(Me.dsExcessShortage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ESTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpToDate
        '
        Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(572, 13)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 38
        '
        'dtpfromDate
        '
        Me.dtpfromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromDate.Location = New System.Drawing.Point(398, 13)
        Me.dtpfromDate.Name = "dtpfromDate"
        Me.dtpfromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpfromDate.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(513, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(327, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "From Date"
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(672, 4)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 39
        Me.cmdShow.Text = "&Show"
        '
        'ReportViewer1
        '
        ReportDataSource2.Name = "dsExcessShortage_ESTable"
        ReportDataSource2.Value = Me.ESTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptESReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 52)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1036, 600)
        Me.ReportViewer1.TabIndex = 40
        '
        'dsExcessShortage
        '
        Me.dsExcessShortage.DataSetName = "dsExcessShortage"
        Me.dsExcessShortage.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ESTableBindingSource
        '
        Me.ESTableBindingSource.DataMember = "ESTable"
        Me.ESTableBindingSource.DataSource = Me.dsExcessShortage
        '
        'ESTableTableAdapter
        '
        Me.ESTableTableAdapter.ClearBeforeFill = True
        '
        'ExcessShortageReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1060, 664)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpfromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "ExcessShortageReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excess Shortage Report"
        CType(Me.dsExcessShortage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ESTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ESTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsExcessShortage As Pharmacy.dsExcessShortage
    Friend WithEvents ESTableTableAdapter As Pharmacy.dsExcessShortageTableAdapters.ESTableTableAdapter
End Class
