Imports System.Data.SqlClient
Public Class frmSupplierwiseSales

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim SupplierID As Integer
        Dim dt As New DataTable
        dt = SelectQuery("Select SupplierID from SupplierMaster where SupplierName='" & drpSupplierName.Text & "'")
        If dt.Rows.Count > 0 Then
            SupplierID = dt.Rows(0).Item("SupplierID")
        End If
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from ReportTitles"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into ReportTitles(ProductGroup,ProductName) Values('" & drpProductGroup.Text & "','" & drpProductName.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        'TODO: This line of code loads data into the 'dsSupplierSales.DataTable1' table. You can move, or remove it, as needed.
        If drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.Fill(Me.dsSupplierSales.DataTable1, SupplierID, dtpfromDate.Text, dtpToDate.Text)
        ElseIf drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy(Me.dsSupplierSales.DataTable1, SupplierID, dtpfromDate.Text, dtpToDate.Text, drpProductGroup.Text)
        ElseIf (drpProductGroup.Text = "All" And drpProductName.Text <> "All") Or (drpProductGroup.Text <> "All" And drpProductName.Text <> "All") Then
            Me.DataTable1TableAdapter.FillBy1(Me.dsSupplierSales.DataTable1, SupplierID, dtpfromDate.Text, dtpToDate.Text, drpProductName.Text)
        End If

        'TODO: This line of code loads data into the 'dsSupplierSales.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsSupplierSales.FromToDateTable)
        Me.ReportTitlesTableAdapter.Fill(Me.dsSupplierSales.ReportTitles)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub frmSupplierwiseSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        dt1 = SelectQuery("Select SupplierName from SupplierMaster")
        drpSupplierName.DataSource = dt1
        drpSupplierName.ValueMember = "SupplierName"
        drpSupplierName.DisplayMember = "SupplierName"


        Dim dt As New DataTable
        Dim arr As New ArrayList
        arr.Add("All")
        dt = SelectQuery("SELECT GroupName FROM ProductGroupMaster")
        For i As Integer = 0 To dt.Rows.Count - 1
            arr.Add(dt.Rows(i).Item("GroupName"))
        Next
        drpProductGroup.DataSource = arr
    End Sub

    Private Sub drpProductGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProductGroup.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        arr1.Add("All")
        dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
        For i As Integer = 0 To dt1.Rows.Count - 1
            arr1.Add(dt1.Rows(i).Item("ProductName"))
        Next
        drpProductName.DataSource = arr1
    End Sub
End Class