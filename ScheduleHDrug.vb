Imports System.Data.SqlClient
Public Class ScheduleHDrug

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
       

        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        'Dim fromDate, toDate As String

        'fromDate = CDate(dtpfromDate.Text).ToString("MM/dd/yyyy")
        'toDate = CDate(dtpToDate.Text).ToString("MM/dd/yyyy")

        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from SingleTitle"
        cmd.ExecuteNonQuery()

        'TODO: This line of code loads data into the 'SheduleHDrug.DrugSlipDetails' table. You can move, or remove it, as needed.
        Me.DrugSlipDetailsTableAdapter.Fill(Me.SheduleHDrug.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text)
        'TODO: This line of code loads data into the 'SheduleHDrug.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.SheduleHDrug.FromToDateTable)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ScheduleHDrug_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class