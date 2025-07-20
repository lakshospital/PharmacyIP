Imports System.Data.SqlClient
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dt As New DataTable
            dt = SelectQuery("Select * from InvoiceDetails")
            Dim dt1 As New DataTable
            dt1 = SelectQuery("Select * from DrugSlipDetails")
            CheckConnection()
            Dim tranc As SqlTransaction
            tranc = con.BeginTransaction
            Try
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.Transaction = tranc
                cmd.CommandText = "delete from StockDetails"
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To dt.Rows.Count - 1
                    cmd.CommandText = "insert into StockDetails values(" & dt.Rows(i).Item("InvoiceNo") & ",'" & dt.Rows(i).Item("InvoiceDateTime") & "','" & dt.Rows(i).Item("ProductName") & "','" & dt.Rows(i).Item("ExpDate") & "','" & dt.Rows(i).Item("BatchNo") & "'," & dt.Rows(i).Item("Qty") & ")"
                    cmd.ExecuteNonQuery()
                Next
                For i As Integer = 0 To dt1.Rows.Count - 1
                    cmd.CommandText = "update StockDetails set CurrentQty=CurrentQty-" & dt1.Rows(i).Item("Qty") & " where ProductName='" & dt1.Rows(i).Item("ProductName") & "' and InvoiceNo=" & dt1.Rows(i).Item("InvoiceNo").ToString.Substring(0, dt1.Rows(i).Item("InvoiceNo").ToString.IndexOf("-")) & " and Year(InvoiceDateTime)='" & dt1.Rows(i).Item("InvoiceNo").ToString.Substring(dt1.Rows(i).Item("InvoiceNo").ToString.IndexOf("-") + 1) & "' and BatchNo='" & dt1.Rows(i).Item("BatchNo") & "'"
                    cmd.ExecuteNonQuery()
                Next
                tranc.Commit()
            Catch ex As Exception
                tranc.Rollback()
            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class