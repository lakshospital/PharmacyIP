Public Class ProductReport

    Private Sub ProductReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsProducts.ProductMaster' table. You can move, or remove it, as needed.
        Me.ProductMasterTableAdapter.Fill(Me.dsProducts.ProductMaster)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class