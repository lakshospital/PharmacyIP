<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrugSlipBetweenBillNoFull
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
        Me.DrugSlipDetails1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDrugSlipBetweenDate = New Pharmacy.dsDrugSlipBetweenDate
        Me.txtStartBillNo = New System.Windows.Forms.TextBox
        Me.txtStartYear = New System.Windows.Forms.TextBox
        Me.txtEndBillNo = New System.Windows.Forms.TextBox
        Me.txtEndYear = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdShow = New Glass.GlassButton
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DrugSlipDetails1TableAdapter = New Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails1TableAdapter
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtStartBillNo
        '
        Me.txtStartBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartBillNo.Location = New System.Drawing.Point(198, 10)
        Me.txtStartBillNo.Name = "txtStartBillNo"
        Me.txtStartBillNo.Size = New System.Drawing.Size(147, 20)
        Me.txtStartBillNo.TabIndex = 0
        '
        'txtStartYear
        '
        Me.txtStartYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartYear.Location = New System.Drawing.Point(198, 34)
        Me.txtStartYear.Name = "txtStartYear"
        Me.txtStartYear.Size = New System.Drawing.Size(147, 20)
        Me.txtStartYear.TabIndex = 1
        '
        'txtEndBillNo
        '
        Me.txtEndBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndBillNo.Location = New System.Drawing.Point(452, 10)
        Me.txtEndBillNo.Name = "txtEndBillNo"
        Me.txtEndBillNo.Size = New System.Drawing.Size(143, 20)
        Me.txtEndBillNo.TabIndex = 2
        '
        'txtEndYear
        '
        Me.txtEndYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndYear.Location = New System.Drawing.Point(452, 34)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(143, 20)
        Me.txtEndYear.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(107, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Start Bill No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(107, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Start Bill Year"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(366, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "End Bill No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(366, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "End Bill Year"
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.Color.Black
        Me.cmdShow.GlowColor = System.Drawing.Color.Yellow
        Me.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShow.Location = New System.Drawing.Point(604, 12)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(104, 38)
        Me.cmdShow.TabIndex = 31
        Me.cmdShow.Text = "&Show"
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsDrugSlipBetweenDate_DrugSlipDetails1"
        ReportDataSource1.Value = Me.DrugSlipDetails1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pharmacy.rptDrugSlipDetailsBetweenBillNo.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 60)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(902, 527)
        Me.ReportViewer1.TabIndex = 32
        '
        'DrugSlipDetails1TableAdapter
        '
        Me.DrugSlipDetails1TableAdapter.ClearBeforeFill = True
        '
        'DrugSlipBetweenBillNoFull
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 599)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEndYear)
        Me.Controls.Add(Me.txtEndBillNo)
        Me.Controls.Add(Me.txtStartYear)
        Me.Controls.Add(Me.txtStartBillNo)
        Me.MaximizeBox = False
        Me.Name = "DrugSlipBetweenBillNoFull"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Drug Slip Between BillNo (Full)"
        CType(Me.DrugSlipDetails1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDrugSlipBetweenDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStartBillNo As System.Windows.Forms.TextBox
    Friend WithEvents txtStartYear As System.Windows.Forms.TextBox
    Friend WithEvents txtEndBillNo As System.Windows.Forms.TextBox
    Friend WithEvents txtEndYear As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As Glass.GlassButton
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DrugSlipDetails1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsDrugSlipBetweenDate As Pharmacy.dsDrugSlipBetweenDate
    Friend WithEvents DrugSlipDetails1TableAdapter As Pharmacy.dsDrugSlipBetweenDateTableAdapters.DrugSlipDetails1TableAdapter
End Class
