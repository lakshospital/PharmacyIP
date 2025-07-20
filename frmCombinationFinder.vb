Imports System.Data.SqlClient
Imports System.Data
Public Class frmCombinationFinder

    Private Sub drpCombinationName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCombinationName.SelectedIndexChanged
        Dim da As New SqlDataAdapter("Select ProductName,(SELECT SUM(currentQty) FROM StockDetails WHERE  productname = productmaster.productname) AS Qty,DoctorName,RackNo from ProductMaster where CombinationName='" & drpCombinationName.Text & "'", con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then
            DataGridView1.DataSource = ds.Tables(0).DefaultView
            MsgBox("No Product found with same combination")
        Else
            DataGridView1.DataSource = ds.Tables(0).DefaultView
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Select()
        End If
    End Sub

    Private Sub frmCombinationFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim da As New SqlDataAdapter("Select distinct(CombinationName) from ProductMaster where (combinationname is not null)", con)
        Dim ds As New DataSet
        da.Fill(ds)
        drpCombinationName.DisplayMember = "CombinationName"
        drpCombinationName.ValueMember = "CombinationName"
        drpCombinationName.DataSource = ds.Tables(0).DefaultView
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyData = Keys.Enter Then
            DrugSlip.drpProductName.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
            DrugSlip.drpProductName.Select()
            Me.Close()
        End If
    End Sub
End Class