Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ts As TimeSpan
        ts = System.DateTime.Now.Date.Subtract(DateTimePicker1.Text)
        MsgBox(ts.TotalDays)
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''TODO: This line of code loads data into the 'dsTemplate.OTTemplate' table. You can move, or remove it, as needed.
        'Me.OTTemplateTableAdapter.Fill(Me.dsTemplate.OTTemplate)
        ''TODO: This line of code loads data into the 'dsTemplate.DrugSlipDetails' table. You can move, or remove it, as needed.
        'Me.DrugSlipDetailsTableAdapter.Fill(Me.dsTemplate.DrugSlipDetails)
        ''TODO: This line of code loads data into the 'dsTemplate.DrugSlipDetails1' table. You can move, or remove it, as needed.
        'Me.DrugSlipDetails1TableAdapter.Fill(Me.dsTemplate.DrugSlipDetails1)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class