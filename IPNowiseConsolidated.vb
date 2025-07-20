Public Class IPNowiseConsolidated

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails2' table. You can move, or remove it, as needed.
        Me.DrugSlipDetails2TableAdapter.Fill(Me.dsDrugSlipBetweenDate.DrugSlipDetails2, txtPatientID.Text)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub
End Class