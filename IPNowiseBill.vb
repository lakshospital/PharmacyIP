Public Class IPNowiseBill

    Private Sub IPNowiseBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails1' table. You can move, or remove it, as needed.
        Me.DrugSlipDetails1TableAdapter.FillBy3(Me.dsDrugSlipBetweenDate.DrugSlipDetails1, txtPatientID.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class