Public Class StockDatewisePrint

    Private Sub StockDatewisePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsStockDatewisePrint.StockPrint' table. You can move, or remove it, as needed.
        Me.dsStockDatewisePrint.EnforceConstraints = False
        Me.dsStockDatewisePrint.StockPrint.Constraints.Clear()
        Me.StockPrintTableAdapter.Fill(Me.dsStockDatewisePrint.StockPrint)
        'TODO: This line of code loads data into the 'dsStockDatewisePrint.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsStockDatewisePrint.FromToDateTable)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class