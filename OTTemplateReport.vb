
Public Class OTTemplateReport

    Private Sub OTTemplateReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        'Me.ReportViewer1.ServerReport.SetParameters()
        'TODO: This line of code loads data into the 'dsTemplate.OTTemplate' table. You can move, or remove it, as needed.
        Dim da As New SqlClient.SqlDataAdapter("Select DrName,CaseType from DrugSlipDetails where BillNo=" & txtBillNo.Text & " AND YEAR(BillDate)='" & txtBillYear.Text & "'", con)
        Dim ds As New DataSet
        da.Fill(ds)
        Me.OTTemplateTableAdapter.Fill(Me.dsTemplate.OTTemplate, txtBillNo.Text, txtBillYear.Text, ds.Tables(0).Rows(0).Item("DrName").ToString(), ds.Tables(0).Rows(0).Item("CaseType").ToString())
        Me.DrugSlipDetailsTableAdapter.Fill(Me.dsTemplate.DrugSlipDetails, txtBillNo.Text, txtBillYear.Text)
        Me.DrugSlipDetails1TableAdapter.Fill(Me.dsTemplate.DrugSlipDetails1, txtBillNo.Text, txtBillYear.Text)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class