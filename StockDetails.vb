Imports System.Data.SqlClient
Public Class StockDetails

    Private Sub StockDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        arr1.Add("All")
        dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
        For i As Integer = 0 To dt1.Rows.Count - 1
            arr1.Add(dt1.Rows(i).Item("ProductName"))
        Next
        drpProductName.DataSource = arr1
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        process()
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Sub process()
        Try
            CheckConnection()
            Dim tranc As SqlTransaction
            tranc = con.BeginTransaction
            Try
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.Transaction = tranc
                cmd.CommandText = "Delete from StockPrint"
                cmd.ExecuteNonQuery()
                DataGridView1.Rows.Clear()
                Dim openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock As Integer
                Dim ts As TimeSpan
                Dim totaldays As Integer
                ts = CDate(dtpToDate.Text) - CDate(dtpfromDate.Text)
                totaldays = ts.TotalDays
                Dim mydate As DateTime
                mydate = dtpfromDate.Text
                If drpProductName.Text = "All" Then
                    Dim da As New SqlDataAdapter("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "' ORDER BY ProductName", con)
                    da.SelectCommand.Transaction = tranc
                    Dim ds As New DataSet
                    da.Fill(ds)
                    'dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        For i As Integer = 0 To totaldays
                            cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                Purchase = cmd.ExecuteScalar
                            End If
                            cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                Sales = cmd.ExecuteScalar
                            End If
                            cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                SalesReturn = cmd.ExecuteScalar
                            End If
                            cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                Excess = cmd.ExecuteScalar
                            End If
                            cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                Shortage = cmd.ExecuteScalar
                            End If
                            openingstock = Val(Purchase) - Val(Sales) - Val(Shortage) + Val(SalesReturn) + Val(Excess)

                            'Next
                            'Next
                            'Next

                            cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime='" & mydate.ToShortDateString & "' and Status<>'C'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                Purchase = cmd.ExecuteScalar
                            End If
                            cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and BillDate='" & mydate.ToShortDateString & "' and Status<>'C'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                Sales = cmd.ExecuteScalar
                            End If
                            cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ReturnBillDate='" & mydate.ToShortDateString & "'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                SalesReturn = cmd.ExecuteScalar
                            End If
                            cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate='" & mydate.ToShortDateString & "' and ESType='Excess'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                Excess = cmd.ExecuteScalar
                            End If
                            cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate='" & mydate.ToShortDateString & "' and ESType='Shortage'"
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                Shortage = cmd.ExecuteScalar
                            End If
                            ClosingStock = Val(openingstock) + Val(Purchase) - Val(Sales) + Val(SalesReturn) + Val(Excess) - Val(Shortage)
                            DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock)
                            cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & ",NULL)"
                            cmd.ExecuteNonQuery()
                            'mydate = mydate.AddDays(1)
                        Next
                    Next
                Else
                    For i As Integer = 0 To totaldays
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Purchase = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Sales = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & drpProductName.Text & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            SalesReturn = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Excess = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "'and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Shortage = cmd.ExecuteScalar
                        End If
                        openingstock = Val(Purchase) - Val(Sales) - Val(Shortage) + Val(SalesReturn) + Val(Excess)

                        'Next
                        'Next
                        'Next

                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime='" & mydate.ToShortDateString & "' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Purchase = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "'and BillDate='" & mydate.ToShortDateString & "' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Sales = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & drpProductName.Text & "'and ReturnBillDate='" & mydate.ToShortDateString & "'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            SalesReturn = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate='" & mydate.ToShortDateString & "' and ESType='Excess'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Excess = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate='" & mydate.ToShortDateString & "' and ESType='Shortage'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Shortage = cmd.ExecuteScalar
                        End If
                        ClosingStock = Val(openingstock) + Val(Purchase) - Val(Sales) + Val(SalesReturn) + Val(Excess) - Val(Shortage)
                        DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, drpProductName.Text, openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock)
                        cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & drpProductName.Text & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & ",NULL)"
                        cmd.ExecuteNonQuery()
                        mydate = mydate.AddDays(1)
                    Next
                End If
                tranc.Commit()
            Catch ex As Exception
                tranc.Rollback()
                con.Close()
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)

        End Try
        
    End Sub

    Private Sub GlassButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlassButton1.Click
        process()
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        StockDatewisePrint.Show()
    End Sub
End Class