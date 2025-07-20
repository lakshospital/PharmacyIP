Public Class frmPurchaseReportSalesTax

    Private Sub frmPurchaseReportSalesTax_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim EndDate As System.DateTime
        Dim i As Integer
        i = Date.DaysInMonth(CDate(DateTimePicker1.Text).Year, CDate(DateTimePicker1.Text).Month)
        EndDate = i & "-" & DateTimePicker1.Text
        'TODO: This line of code loads data into the 'dsAccounts.Purchase' table. You can move, or remove it, as needed.
        Me.PurchaseTableAdapter.Fill(Me.dsAccounts.Purchase, DateTimePicker1.Text, EndDate)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class