Public Class DrugPrint

    Private Sub DrugPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DrugSlipDetails1TableAdapter.FillBy2(Me.dsDrugSlipBetweenDate.DrugSlipDetails1, crysBillNo, crysBillYear)
        ''crystalReport11.PrintToPrinter(1, False, 1, 1)
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
   
   
    Private Sub ReportViewer1_Print(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ReportViewer1.Print
        Dim cmd As New SqlClient.SqlCommand("Update drugSlipDetails set LastPrint='" & System.DateTime.Now & "' where BillNo=" & crysBillNo & " and Year(BillDate)='" & crysBillYear & "'", con)
        CheckConnection()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        'ReportViewer1.PrintDialog()
    End Sub
End Class