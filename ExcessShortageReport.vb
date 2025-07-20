Public Class ExcessShortageReport
    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        'TODO: This line of code loads data into the 'dsExcessShortage.ESTable' table. You can move, or remove it, as needed.
        Me.ESTableTableAdapter.Fill(Me.dsExcessShortage.ESTable, CDate(dtpfromDate.Text), CDate(dtpToDate.Text))
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class