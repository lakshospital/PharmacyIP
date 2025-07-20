Imports System.Data.SqlClient
Public Class PurchaseReportDatewise

    Private Sub rptPurchaseReportDatewise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        arr1.Add("All")
        dt1 = SelectQuery("Select DoctorName from DoctorNameMaster")
        For i As Integer = 0 To dt1.Rows.Count - 1
            arr1.Add(dt1.Rows(i).Item("DoctorName"))
        Next
        drpDoctorName.DataSource = arr1

        Dim dt2 As New DataTable
        Dim arr2 As New ArrayList
        arr2.Add("All")
        dt2 = SelectQuery("Select SupplierName from SupplierMaster")
        For i As Integer = 0 To dt2.Rows.Count - 1
            arr2.Add(dt2.Rows(i).Item("SupplierName"))
        Next
        drpSupplierName.DataSource = arr2
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
        Dim SupplierID As Integer
        Dim dt As New DataTable
        dt = SelectQuery("Select SupplierID from SupplierMaster where SupplierName='" & drpSupplierName.Text & "'")
        If dt.Rows.Count > 0 Then
            SupplierID = dt.Rows(0).Item("SupplierID")
        End If
        If drpDoctorName.Text = "All" And drpSupplierName.Text = "All" Then
            'TODO: This line of code loads data into the 'dsPurchaseReportDatewise.InvoiceDetails' table. You can move, or remove it, as needed.
            Me.InvoiceDetailsTableAdapter.Fill(Me.dsPurchaseReportDatewise.InvoiceDetails, dtpfromDate.Text, dtpToDate.Text)
        ElseIf drpDoctorName.Text <> "All" And drpSupplierName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy(Me.dsPurchaseReportDatewise.InvoiceDetails, dtpfromDate.Text, dtpToDate.Text, drpDoctorName.Text)
        ElseIf drpDoctorName.Text <> "All" And drpSupplierName.Text <> "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy1(Me.dsPurchaseReportDatewise.InvoiceDetails, dtpfromDate.Text, dtpToDate.Text, drpDoctorName.Text, SupplierID)
        Else
            Me.InvoiceDetailsTableAdapter.FillBy2(Me.dsPurchaseReportDatewise.InvoiceDetails, dtpfromDate.Text, dtpToDate.Text, SupplierID)
        End If
        'TODO: This line of code loads data into the 'dsPurchaseReportDatewise.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsPurchaseReportDatewise.FromToDateTable)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class