Imports System.Data.SqlClient
Public Class SalesProductwise

    Private Sub SalesProductwise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As New DataTable
        Dim arr As New ArrayList
        'arr.Add("All")
        dt = SelectQuery("SELECT GroupName FROM ProductGroupMaster")
        For i As Integer = 0 To dt.Rows.Count - 1
            arr.Add(dt.Rows(i).Item("GroupName"))
        Next
        drpProductGroup.DataSource = arr
    End Sub

    Private Sub drpProductGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProductGroup.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        If drpProductGroup.Text <> "All" Then
            'arr1.Add("All")
            dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
            For i As Integer = 0 To dt1.Rows.Count - 1
                arr1.Add(dt1.Rows(i).Item("ProductName"))
            Next
            drpProductName.DataSource = arr1
        Else
            'arr1.Add("All")
            dt1 = SelectQuery("Select ProductName from ProductMaster")
            For i As Integer = 0 To dt1.Rows.Count - 1
                arr1.Add(dt1.Rows(i).Item("ProductName"))
            Next
            drpProductName.DataSource = arr1
        End If
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
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails3' table. You can move, or remove it, as needed.
        Me.DrugSlipDetails3TableAdapter.Fill(Me.dsDrugSlipBetweenDate.DrugSlipDetails3, drpProductName.Text, dtpfromDate.Text, dtpToDate.Text)
        Me.FromToDateTableTableAdapter.Fill(Me.dsDrugSlipBetweenDate.FromToDateTable)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class