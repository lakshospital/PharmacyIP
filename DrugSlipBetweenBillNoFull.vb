Public Class DrugSlipBetweenBillNoFull

    Private Sub DrugSlipBetweenBillNoFull_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails1' table. You can move, or remove it, as needed.
        Me.DrugSlipDetails1TableAdapter.FillBy1(Me.dsDrugSlipBetweenDate.DrugSlipDetails1, txtStartBillNo.Text, txtStartYear.Text, txtEndBillNo.Text, txtEndYear.Text)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class