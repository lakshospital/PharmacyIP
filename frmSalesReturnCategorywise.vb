Public Class frmSalesReturnCategorywise

    Private Sub frmSalesReturnCategorywise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        'TODO: This line of code loads data into the 'dsSalesReturnBetweenDate.DataTable1' table. You can move, or remove it, as needed.
        Me.DataTable1TableAdapter.Fill(Me.dsSalesReturnBetweenDate.DataTable1, dtpfromDate.Text, dtpToDate.Text)
        'TODO: This line of code loads data into the 'dsSalesReturnBetweenDate.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsSalesReturnBetweenDate.FromToDateTable)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class