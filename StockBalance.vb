Imports System.Data.SqlClient
Public Class StockBalance

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim da As New SqlDataAdapter("SELECT  InvoiceNo, InvoiceDateTime, ProductName, ExpDate, BatchNo, CurrentQty  FROM StockDetails  WHERE(CurrentQty < 0)", con)
        Dim ds As New DataSet
        da.Fill(ds)

        Dim cmd As New SqlCommand
        cmd.Connection = con

        Dim openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock As Integer
        CheckConnection()
        For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
            cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceNo=" & ds.Tables(0).Rows(j).Item("InvoiceNo") & " and Year(InvoiceDateTime)='" & CDate(ds.Tables(0).Rows(j).Item("InvoiceDateTime")).Year & "' and Status<>'C' and BatchNo='" & ds.Tables(0).Rows(j).Item("BatchNo") & "'"
            If IsDBNull(cmd.ExecuteScalar) = False Then
                Purchase = cmd.ExecuteScalar
            End If
            cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceNo='" & ds.Tables(0).Rows(j).Item("InvoiceNo") & "-" & CDate(ds.Tables(0).Rows(j).Item("InvoiceDateTime")).Year & "' and Status<>'C' and BatchNo='" & ds.Tables(0).Rows(j).Item("BatchNo") & "'"
            If IsDBNull(cmd.ExecuteScalar) = False Then
                Sales = cmd.ExecuteScalar
            End If
            cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceNo='" & ds.Tables(0).Rows(j).Item("InvoiceNo") & "-" & CDate(ds.Tables(0).Rows(j).Item("InvoiceDateTime")).Year & "' and BatchNo='" & ds.Tables(0).Rows(j).Item("BatchNo") & "'"
            If IsDBNull(cmd.ExecuteScalar) = False Then
                SalesReturn = cmd.ExecuteScalar
            End If
            cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceNo=" & ds.Tables(0).Rows(j).Item("InvoiceNo") & " and InvoiceYear='" & CDate(ds.Tables(0).Rows(j).Item("InvoiceDateTime")).Year & "'  and BatchNo='" & ds.Tables(0).Rows(j).Item("BatchNo") & "' and ESType='Excess'"
            If IsDBNull(cmd.ExecuteScalar) = False Then
                Excess = cmd.ExecuteScalar
            End If
            cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and  InvoiceNo=" & ds.Tables(0).Rows(j).Item("InvoiceNo") & " and InvoiceYear='" & CDate(ds.Tables(0).Rows(j).Item("InvoiceDateTime")).Year & "'  and BatchNo='" & ds.Tables(0).Rows(j).Item("BatchNo") & "' and ESType='Shortage'"
            If IsDBNull(cmd.ExecuteScalar) = False Then
                Shortage = cmd.ExecuteScalar
            End If
            openingstock = Val(Purchase) - Val(Sales) - Val(Shortage) + Val(SalesReturn) + Val(Excess)

        Next

    End Sub
End Class