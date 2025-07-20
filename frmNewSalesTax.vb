Public Class frmNewSalesTax

    Private Sub frmNewSalesTax_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        CheckConnection()
        Dim cmd As New SqlClient.SqlCommand("delete from AccountTitle", con)
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into AccountTitle values('" & DateTimePicker1.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()

        Dim EndDate As System.DateTime
        Dim i As Integer
        i = Date.DaysInMonth(CDate(DateTimePicker1.Text).Year, CDate(DateTimePicker1.Text).Month)
        'TODO: This line of code loads data into the 'dsAccounts.DrugSlipDetails' table. You can move, or remove it, as needed.
        EndDate = i & "-" & DateTimePicker1.Text
        'TODO: This line of code loads data into the 'dsSalesTax.AccountTitle' table. You can move, or remove it, as needed.
        Me.AccountTitleTableAdapter.Fill(Me.dsSalesTax.AccountTitle)
        'TODO: This line of code loads data into the 'dsSalesTax.DrugSlipDetails' table. You can move, or remove it, as needed.
        Me.DrugSlipDetailsTableAdapter.Fill(Me.dsSalesTax.DrugSlipDetails, DateTimePicker1.Text, EndDate)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class