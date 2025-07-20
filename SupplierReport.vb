Public Class SupplierReport

    Private Sub SupplierReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsSuppliers.SupplierMaster' table. You can move, or remove it, as needed.
        Me.SupplierMasterTableAdapter.Fill(Me.dsSuppliers.SupplierMaster)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class