Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmAmoutToBeReturnBetweenDate

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()

        Me.AmountToBeReturnedTableAdapter.Fill(Me.DataSet3.AmountToBeReturned, dtpToDate.Text & " 11:59:59 PM", dtpfromDate.Text & " 12:00:00 AM", dtpToDate.Text & " 11:59:59 PM", dtpfromDate.Text & " 12:00:00 AM")
        'TODO: This line of code loads data into the 'DataSet3.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.DataSet3.FromToDateTable)
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

        Me.DrugSlipDetailsTableAdapter.Fill(Me.DataSet2.DrugSlipDetails, arr(0).ToString, CDate(arr(1)).ToShortDateString)
        'TODO: This line of code loads data into the 'DataSet2.PaymentHistory' table. You can move, or remove it, as needed.
        Me.PaymentHistoryTableAdapter.Fill(Me.DataSet2.PaymentHistory, arr(0).ToString, CDate(arr(1)).ToShortDateString)

        lc.DataSources.Add(New ReportDataSource("DataSet2_DrugSlipDetails", DataSet2.DrugSlipDetails))
        lc.DataSources.Add(New ReportDataSource("DataSet2_PaymentHistory", DataSet2.PaymentHistory))

        lc.Refresh()
    End Sub
End Class