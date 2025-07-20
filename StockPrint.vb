Imports System.Data.SqlClient
Public Class StockPrint

    Private Sub StockPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsStockDatewisePrint.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsStockDatewisePrint.FromToDateTable)
        'TODO: This line of code loads data into the 'dsStockDatewisePrint.StockPrint' table. You can move, or remove it, as needed.
        Me.StockPrintTableAdapter.Fill(Me.dsStockDatewisePrint.StockPrint)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class