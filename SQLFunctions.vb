Imports System.Data.SqlClient
Module SQLFunctions
    Function AggregateQuery(ByVal str As String) As Object
        CheckConnection()
        Dim cmd As New SqlCommand(str, con)
        AggregateQuery = cmd.ExecuteScalar
        con.Close()
        Return AggregateQuery
    End Function
    Function SelectQuery(ByVal str As String) As DataTable
        Dim da As New SqlDataAdapter(str, con)
        Dim ds As New DataSet
        da.Fill(ds)
        SelectQuery = ds.Tables(0)
        Return SelectQuery
    End Function
    Sub CheckConnection()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
    End Sub
End Module
