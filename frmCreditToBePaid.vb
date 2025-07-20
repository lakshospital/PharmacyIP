Imports Microsoft.Reporting.WinForms

Public Class frmCreditToBePaid

    Private Sub frmCreditToBePaid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.PaymentDueTableAdapter.Fill(Me.DataSet1.PaymentDue, CDate(System.DateTime.Now.Date).ToString("MMM/dd/yyyy"))

        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub ReportViewer1_Drillthrough(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.DrillthroughEventArgs) Handles ReportViewer1.Drillthrough
        Dim lc As LocalReport = DirectCast(e.Report, LocalReport)
        Dim i As Integer
        Dim arr As New ArrayList
        i = 0
        Dim DrillThroughValues As ReportParameterInfoCollection
        DrillThroughValues = e.Report.GetParameters()

        For Each d As ReportParameterInfo In DrillThroughValues
            arr.Add(d.Values(0).ToString.Trim)
            i = i + 1
        Next

        Me.DrugSlipDetailsTableAdapter.Fill(Me.DataSet1.DrugSlipDetails, arr(0).ToString, CDate(arr(1)).ToShortDateString)

        Me.PaymentHistoryTableAdapter.Fill(Me.DataSet1.PaymentHistory, arr(0).ToString, arr(1).ToString)

        Dim drugDataSource = New ReportDataSource("DataSet1_DrugSlipDetails", DataSet1.DrugSlipDetails.DefaultView)
        Me.ReportViewer1.LocalReport.DataSources.Add(drugDataSource)
        lc.DataSources.Add(New ReportDataSource("DataSet1_DrugSlipDetails", DataSet1.DrugSlipDetails))
        lc.DataSources.Add(New ReportDataSource("DataSet1_PaymentHistory", DataSet1.PaymentHistory))



        lc.DataSources.Add(New ReportDataSource("DataSet1_PaymentHistory", DataSet1.PaymentHistory))
        Dim paymentHistory = New ReportDataSource("DataSet1_PaymentHistory", DataSet1.PaymentHistory.DefaultView)
        Me.ReportViewer1.LocalReport.DataSources.Add(paymentHistory)


        lc.Refresh()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Me.PaymentDueTableAdapter.Fill(Me.DataSet1.PaymentDue, CDate(System.DateTime.Now.Date).ToString("MMM/dd/yyyy"))

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class