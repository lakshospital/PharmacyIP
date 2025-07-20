Public Class frmStockDoctorwisePrint

    Private Sub frmStockDoctorwisePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsStockDatewisePrint.StockPrint1' table. You can move, or remove it, as needed.
        Me.StockPrint1TableAdapter.Fill(Me.dsStockDatewisePrint.StockPrint1)
        'TODO: This line of code loads data into the 'dsStockDatewisePrint.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsStockDatewisePrint.FromToDateTable)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class