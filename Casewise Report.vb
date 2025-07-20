Imports System.Data.SqlClient
Public Class Casewise_Report

    Private Sub Casewise_Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim arr As New ArrayList
        arr.Add("All")
        dt = SelectQuery("SELECT CaseName FROM CaseTypeMaster")
        For i As Integer = 0 To dt.Rows.Count - 1
            arr.Add(dt.Rows(i).Item("CaseName"))
        Next
        drpCase.DataSource = arr
        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        arr1.Add("All")
        dt1 = SelectQuery("Select DoctorName from DoctorNameMaster")
        For i As Integer = 0 To dt1.Rows.Count - 1
            arr1.Add(dt1.Rows(i).Item("DoctorName"))
        Next
        drpDoctorName.DataSource = arr1
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        'TODO: This line of code loads data into the 'dsTypewiseReport.DrugSlipDetails' table. You can move, or remove it, as needed.
        If drpCase.Text <> "All" And drpDoctorName.Text = "All" Then
            Me.DrugSlipDetailsTableAdapter.Fill(Me.dsTypewiseReport.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text, drpCase.Text)
        ElseIf drpCase.Text = "All" And drpDoctorName.Text <> "All" Then
            Me.DrugSlipDetailsTableAdapter.FillBy2(Me.dsTypewiseReport.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text, drpDoctorName.Text)
        ElseIf drpCase.Text <> "All" And drpDoctorName.Text <> "All" Then
            Me.DrugSlipDetailsTableAdapter.FillBy1(Me.dsTypewiseReport.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text, drpCase.Text, drpDoctorName.Text)
        Else
            Me.DrugSlipDetailsTableAdapter.FillBy(Me.dsTypewiseReport.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text)
        End If
        'TODO: This line of code loads data into the 'dsTypewiseReport.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsTypewiseReport.FromToDateTable)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub drpCase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCase.SelectedIndexChanged

    End Sub
End Class