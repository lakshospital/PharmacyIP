Imports System.Data.SqlClient
Public Class CashLessBillBetweenDateFull

    Private Sub CashLessBillBetweenDateFull_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As New DataTable
        Dim arr As New ArrayList
        arr.Add("All")
        dt = SelectQuery("SELECT CaseName FROM CaseTypeMaster")
        For i As Integer = 0 To dt.Rows.Count - 1
            arr.Add(dt.Rows(i).Item("CaseName"))
        Next
        drpCase.DataSource = arr
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from ReportTitles"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into ReportTitles(CaseType) Values('" & drpCase.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails5' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsDrugSlipBetweenDate.FromToDateTable)
        If drpCase.Text = "All" Then
            Me.DrugSlipDetails5TableAdapter.Fill(Me.dsDrugSlipBetweenDate.DrugSlipDetails5, dtpfromDate.Text & " 12:00:00 AM", dtpToDate.Text & " 11:59:59 PM")
        Else
            Me.DrugSlipDetails5TableAdapter.FillBy(Me.dsDrugSlipBetweenDate.DrugSlipDetails5, dtpfromDate.Text & " 12:00:00 AM", dtpToDate.Text & " 11:59:59 PM", drpCase.Text)
        End If
        Me.ReportTitlesTableAdapter.Fill(Me.dsDrugSlipBetweenDate.ReportTitles)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class