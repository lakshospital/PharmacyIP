Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class DeliveryReport

    Private Sub DeliveryReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        cmd.CommandText = "Delete from SingleTitle"
        cmd.ExecuteNonQuery()
        If rdoBillDate.Checked = True Then
            cmd.CommandText = "insert into SingleTitle values('Bill Datewise')"
            cmd.ExecuteNonQuery()
        Else
            cmd.CommandText = "insert into SingleTitle values('Incident Datewise')"
            cmd.ExecuteNonQuery()
        End If
        con.Close()
        If drpDoctorName.Text = "All" And rdoBillDate.Checked = True Then
            'TODO: This line of code loads data into the 'dsTypewiseReport.DrugSlipDetails' table. You can move, or remove it, as needed.
            Me.DrugSlipDetailsTableAdapter.FillBy4(Me.dsTypewiseReport.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text)
        ElseIf drpDoctorName.Text <> "All" And rdoBillDate.Checked = True Then
            Me.DrugSlipDetailsTableAdapter.FillBy5(Me.dsTypewiseReport.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text, drpDoctorName.Text)
        ElseIf drpDoctorName.Text = "All" And rdoIncidentDate.Checked = True Then
            Me.DrugSlipDetailsTableAdapter.FillBy9(Me.dsTypewiseReport.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text)
        ElseIf drpDoctorName.Text <> "All" And rdoIncidentDate.Checked = True Then
            Me.DrugSlipDetailsTableAdapter.FillBy10(Me.dsTypewiseReport.DrugSlipDetails, dtpfromDate.Text, dtpToDate.Text, drpDoctorName.Text)
        End If

        'TODO: This line of code loads data into the 'dsTypewiseReport.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsTypewiseReport.FromToDateTable)
        Me.SingleTitleTableAdapter.Fill(Me.dsTypewiseReport.SingleTitle)
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

        Dim da As New SqlClient.SqlDataAdapter("Select DrName,CaseType from DrugSlipDetails where BillNo=" & arr(0) & " AND YEAR(BillDate)='" & CDate(arr(1)).Year & "'", con)
        Dim ds As New DataSet
        da.Fill(ds)



        'TODO: This line of code loads data into the 'dsTemplate.OTTemplate' table. You can move, or remove it, as needed.
        Me.OTTemplateTableAdapter.Fill(Me.dsTemplate.OTTemplate, arr(0).ToString(), CDate(arr(1)).Year.ToString(), ds.Tables(0).Rows(0).Item("DrName").ToString(), ds.Tables(0).Rows(0).Item("CaseType").ToString())
        'TODO: This line of code loads data into the 'dsTemplate.DrugSlipDetails' table. You can move, or remove it, as needed.
        Me.DrugSlipDetailsTableAdapter2.Fill(Me.dsTemplate.DrugSlipDetails, arr(0).ToString(), CDate(arr(1).ToString()).Year)
        'TODO: This line of code loads data into the 'dsTemplate.DrugSlipDetails1' table. You can move, or remove it, as needed.
        Me.DrugSlipDetails1TableAdapter.Fill(Me.dsTemplate.DrugSlipDetails1, arr(0).ToString(), CDate(arr(1).ToString()).Year)


        lc.DataSources.Add(New ReportDataSource("dsTemplate_OTTemplate", dsTemplate.OTTemplate))
        lc.DataSources.Add(New ReportDataSource("dsTemplate_DrugSlipDetails", dsTemplate.DrugSlipDetails))
        lc.DataSources.Add(New ReportDataSource("dsTemplate_DrugSlipDetails1", dsTemplate.DrugSlipDetails1))


        lc.Refresh()
    End Sub
End Class