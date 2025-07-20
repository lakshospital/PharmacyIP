Public Class ProductNearExpDate

    Private Sub ProductNearExpDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsLowStock.StockDetails1' table. You can move, or remove it, as needed.
        Me.StockDetails1TableAdapter.Fill(Me.dsLowStock.StockDetails1, System.DateTime.Now.Date.AddMonths(1))
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class