Imports Microsoft.Reporting.WinForms
Public Class frmAmountToReturn

    Private Sub frmAmountToReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        'TODO: This line of code loads data into the 'DataSet2.PaymentDue' table. You can move, or remove it, as needed.
        Me.PaymentDueTableAdapter.Fill(Me.DataSet2.PaymentDue)

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


        'TODO: This line of code loads data into the 'DataSet2.DrugSlipDetails' table. You can move, or remove it, as needed.
        Me.DrugSlipDetailsTableAdapter.Fill(Me.DataSet2.DrugSlipDetails, arr(0).ToString, CDate(arr(1)).ToShortDateString)
        'TODO: This line of code loads data into the 'DataSet2.PaymentHistory' table. You can move, or remove it, as needed.
        Me.PaymentHistoryTableAdapter.Fill(Me.DataSet2.PaymentHistory, arr(0).ToString, CDate(arr(1)).ToString)

        lc.DataSources.Add(New ReportDataSource("DataSet2_DrugSlipDetails", DataSet2.DrugSlipDetails))
        lc.DataSources.Add(New ReportDataSource("DataSet2_PaymentHistory", DataSet2.PaymentHistory))

        lc.Refresh()

    End Sub
End Class