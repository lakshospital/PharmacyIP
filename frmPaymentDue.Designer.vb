<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentDue
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
        Me.txtPatientName = New System.Windows.Forms.TextBox
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.txtPatientID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.lblReceiveReturn = New System.Windows.Forms.Label
        Me.txtAmountReceived = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblBillAmount = New System.Windows.Forms.Label
        Me.cmdExit = New Glass.GlassButton
        Me.lblBillDate = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPatientName
        '
        Me.txtPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientName.Location = New System.Drawing.Point(483, 55)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.ReadOnly = True
        Me.txtPatientName.Size = New System.Drawing.Size(144, 20)
        Me.txtPatientName.TabIndex = 114
        Me.txtPatientName.TabStop = False
        '
        'txtBillNo
        '
        Me.txtBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNo.Location = New System.Drawing.Point(251, 25)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.ReadOnly = True
        Me.txtBillNo.Size = New System.Drawing.Size(141, 20)
        Me.txtBillNo.TabIndex = 111
        Me.txtBillNo.TabStop = False
        '
        'txtPatientID
        '
        Me.txtPatientID.BackColor = System.Drawing.Color.GreenYellow
        Me.txtPatientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientID.Location = New System.Drawing.Point(250, 53)
        Me.txtPatientID.Name = "txtPatientID"
        Me.txtPatientID.ReadOnly = True
        Me.txtPatientID.Size = New System.Drawing.Size(142, 20)
        Me.txtPatientID.TabIndex = 112
        Me.txtPatientID.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(398, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "Patient Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(165, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Patient ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(398, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Bill Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(166, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Bill No"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(80, 88)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(698, 166)
        Me.DataGridView1.TabIndex = 122
        '
        'lblReceiveReturn
        '
        Me.lblReceiveReturn.AutoSize = True
        Me.lblReceiveReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiveReturn.Location = New System.Drawing.Point(525, 263)
        Me.lblReceiveReturn.Name = "lblReceiveReturn"
        Me.lblReceiveReturn.Size = New System.Drawing.Size(107, 13)
        Me.lblReceiveReturn.TabIndex = 123
        Me.lblReceiveReturn.Text = "Amount Received"
        '
        'txtAmountReceived
        '
        Me.txtAmountReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountReceived.Location = New System.Drawing.Point(638, 260)
        Me.txtAmountReceived.Name = "txtAmountReceived"
        Me.txtAmountReceived.Size = New System.Drawing.Size(141, 20)
        Me.txtAmountReceived.TabIndex = 1
        Me.txtAmountReceived.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(633, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Bill Amount"
        '
        'lblBillAmount
        '
        Me.lblBillAmount.AutoSize = True
        Me.lblBillAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillAmount.ForeColor = System.Drawing.Color.Red
        Me.lblBillAmount.Location = New System.Drawing.Point(709, 41)
        Me.lblBillAmount.Name = "lblBillAmount"
        Me.lblBillAmount.Size = New System.Drawing.Size(0, 20)
        Me.lblBillAmount.TabIndex = 126
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.GlowColor = System.Drawing.Color.Yellow
        Me.cmdExit.Image = Global.Pharmacy.My.Resources.Resource1.Ok
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.Location = New System.Drawing.Point(651, 286)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(117, 66)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "&Save"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBillDate
        '
        Me.lblBillDate.AutoSize = True
        Me.lblBillDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillDate.ForeColor = System.Drawing.Color.Red
        Me.lblBillDate.Location = New System.Drawing.Point(480, 28)
        Me.lblBillDate.Name = "lblBillDate"
        Me.lblBillDate.Size = New System.Drawing.Size(0, 13)
        Me.lblBillDate.TabIndex = 128
        '
        'frmPaymentDue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(878, 367)
        Me.Controls.Add(Me.lblBillDate)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lblBillAmount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAmountReceived)
        Me.Controls.Add(Me.lblReceiveReturn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtPatientName)
        Me.Controls.Add(Me.txtBillNo)
        Me.Controls.Add(Me.txtPatientID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaymentDue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payment Due"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPatientName As System.Windows.Forms.TextBox
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPatientID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblReceiveReturn As System.Windows.Forms.Label
    Friend WithEvents txtAmountReceived As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblBillAmount As System.Windows.Forms.Label
    Friend WithEvents cmdExit As Glass.GlassButton
    Friend WithEvents lblBillDate As System.Windows.Forms.Label
End Class
