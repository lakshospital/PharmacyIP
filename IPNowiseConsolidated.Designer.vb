<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPNowiseConsolidated
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
        Me.DrugSlipDetails2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDrugSlipBetweenDate = New Pharmacy.dsDrugSlipBetweenDate
        Me.cmdAdd = New Glass.GlassButton
        Me.txtPatientID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DrugSlipDetails2TableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails2TableAdapter
        CType(Me.DrugSlipDetails2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DrugSlipDetails2BindingSource
        '
        Me.DrugSlipDetails2BindingSource.DataMember = "DrugSlipDetails2"
        Me.DrugSlipDetails2BindingSource.DataSource = Me.dsDrugSlipBetweenDate
        '
        'dsDrugSlipBetweenDate
        '
        Me.dsDrugSlipBetweenDate.DataSetName = "dsDrugSlipBetweenDate"
        Me.dsDrugSlipBetweenDate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.Color.Black
        Me.cmdAdd.GlowColor = System.Drawing.Color.Yellow
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(477, 5)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(97, 33)
        Me.cmdAdd.TabIndex = 28
        Me.cmdAdd.Text = "&Show"
        '
        'txtPatientID
        '
        Me.txtPatientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientID.Location = New System.Drawing.Point(284, 12)
        Me.txtPatientID.Name = "txtPatientID"
        Me.txtPatientID.Size = New System.Drawing.Size(178, 20)
        Me.txtPatientID.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(209, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Enter IPNo"
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsDrugSlipBetweenDate_DrugSlipDetails2"
        ReportDataSource1.Value = Me.DrugSlipDetails2BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptIPNowiseConsolidated.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 44)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(793, 545)
        Me.ReportViewer1.TabIndex = 29
        '
        'DrugSlipDetails2TableAdapter
        '
        Me.DrugSlipDetails2TableAdapter.ClearBeforeFill = True
        '
        'IPNowiseConsolidated
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(817, 601)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtPatientID)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "IPNowiseConsolidated"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IP No wise Consolidated"
        CType(Me.DrugSlipDetails2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAdd As Glass.GlassButton
    Friend WithEvents txtPatientID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DrugSlipDetails2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsDrugSlipBetweenDate As Pharmacy.dsDrugSlipBetweenDate
    Friend WithEvents DrugSlipDetails2TableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails2TableAdapter
End Class
