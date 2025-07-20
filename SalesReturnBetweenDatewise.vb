Imports System.Data.SqlClient
Public Class SalesReturnBetweenDatewise

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim FromDt, Todt As DateTime

        FromDt = dtpfromDate.Text
        Todt = dtpToDate.Text

        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & FromDt & "','" & Todt & "')"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from SingleTitle"
        cmd.ExecuteNonQuery()
        If RadioButton2.Checked = True Then
            cmd.CommandText = "insert into SingleTitle values('Cash Bills only')"
        Else
            cmd.CommandText = "insert into SingleTitle values('Cashless Bills only')"
        End If

        cmd.ExecuteNonQuery()
        con.Close()

        'TODO: This line of code loads data into the 'dsSalesReturnBetweenDate.SalesReturnDetails' table. You can move, or remove it, as needed.
        If RadioButton2.Checked = True Then
            Me.SalesReturnDetailsTableAdapter.Fill(Me.dsSalesReturnBetweenDate.SalesReturnDetails, dtpfromDate.Text, dtpToDate.Text)
        Else
            Me.SalesReturnDetailsTableAdapter.FillBy(Me.dsSalesReturnBetweenDate.SalesReturnDetails, dtpfromDate.Text, dtpToDate.Text)
        End If
        Me.SingleTitleTableAdapter.Fill(Me.dsSalesReturnBetweenDate.SingleTitle)

        Me.FromToDateTableTableAdapter.Fill(Me.dsSalesReturnBetweenDate.FromToDateTable)
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub
End Class