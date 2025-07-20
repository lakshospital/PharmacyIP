Imports System.Data.SqlClient
Public Class CancelBillsBetweenDatewiseConsolidate

    Private Sub CancelBillsBetweenDatewiseConsolidate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


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
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails1' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsDrugSlipBetweenDate.FromToDateTable)
        Me.DrugSlipDetails1TableAdapter.FillBy(Me.dsDrugSlipBetweenDate.DrugSlipDetails1, dtpfromDate.Text, dtpToDate.Text)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class