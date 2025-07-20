<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseReportSalesTax
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.cmdShow = New Glass.GlassButton
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dsAccounts = New Pharmacy.dsAccounts
        Me.PurchaseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseTableAdapter = New Pharmacy.dsAccountsTableAdapters.PurchaseTableAdapter
        CType(Me.dsAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource2.Name = "dsAccounts_Purchase"
        ReportDataSource2.Value = Me.PurchaseBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptPurchaseReportSalesTax.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 42)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(984, 538)
        Me.ReportViewer1.TabIndex = 0
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(584, 10)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 24)
        Me.cmdShow.TabIndex = 49
        Me.cmdShow.Text = "&Show"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MMM,yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(492, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(86, 20)
        Me.DateTimePicker1.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(404, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Select Month"
        '
        'dsAccounts
        '
        Me.dsAccounts.DataSetName = "dsAccounts"
        Me.dsAccounts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PurchaseBindingSource
        '
        Me.PurchaseBindingSource.DataMember = "Purchase"
        Me.PurchaseBindingSource.DataSource = Me.dsAccounts
        '
        'PurchaseTableAdapter
        '
        Me.PurchaseTableAdapter.ClearBeforeFill = True
        '
        'frmPurchaseReportSalesTax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1008, 592)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.Name = "frmPurchaseReportSalesTax"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Report (Sales Tax)"
        CType(Me.dsAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PurchaseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsAccounts As Pharmacy.dsAccounts
    Friend WithEvents PurchaseTableAdapter As Pharmacy.dsAccountsTableAdapters.PurchaseTableAdapter
End Class
