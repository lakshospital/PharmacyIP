Imports System.Data.SqlClient
Imports System.Data
Public Class frmOldPriceHistory
    Function OldPriceHistory(ByVal ProdName As String) As DataTable
        Try
            Dim da As New SqlDataAdapter("SELECT TOP 10 i.InvoiceNo,i.InvoiceDateTime,s.SupplierName, i.ProductName, i.HSR, i.MRP,(((i.MRP-i.HSR)/i.MRP)*100) as 'Profit%' FROM InvoiceDetails i INNER JOIN  SupplierMaster s ON i.SupplierID = s.SupplierID where i.productname='" & ProdName & "' order by i.InvoiceDateTime desc", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub frmOldPriceHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt = OldPriceHistory(txtProductName.Text)
        DataGridView1.DataSource = dt.DefaultView
        DataGridView1.Columns(4).DefaultCellStyle.Format = "##,##0.00"
        DataGridView1.Columns(5).DefaultCellStyle.Format = "##,##0.00"
        DataGridView1.Columns(6).DefaultCellStyle.Format = "##,##0.00"
        DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
End Class