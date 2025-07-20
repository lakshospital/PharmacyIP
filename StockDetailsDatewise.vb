Imports System.Data.SqlClient
Public Class StockDetailsDatewise

    Private Sub StockDetailsDatewise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim arr As New ArrayList
        'arr.Add("All")
        dt = SelectQuery("SELECT GroupName FROM ProductGroupMaster")
        arr.Add("All")
        For i As Integer = 0 To dt.Rows.Count - 1
            arr.Add(dt.Rows(i).Item("GroupName"))
        Next
        drpProductGroup.DataSource = arr
    End Sub
    Private Sub drpProductGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProductGroup.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        arr1.Add("All")
        If drpProductGroup.Text = "All" Then
            dt1 = SelectQuery("Select ProductName from ProductMaster")
            For i As Integer = 0 To dt1.Rows.Count - 1
                arr1.Add(dt1.Rows(i).Item("ProductName"))
            Next
        Else
            dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
            For i As Integer = 0 To dt1.Rows.Count - 1
                arr1.Add(dt1.Rows(i).Item("ProductName"))
            Next
        End If
        drpProductName.DataSource = arr1
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Process()
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Sub Process()
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
                Dim OpeningValue, PurchaseValue, SalesValue, SalesReturnValue, ExcessValue, ShortageValue, ClosingStockValue As Double
                Dim ts As TimeSpan
                Dim totaldays As Integer
                ts = CDate(dtpToDate.Text) - CDate(dtpfromDate.Text)
                totaldays = ts.TotalDays
                Dim mydate As DateTime
                mydate = dtpfromDate.Text
                'Dim FromDate, ToDate As DateTime
                'If chkIncludeTime.Checked = True Then
                '    FromDate = dtpfromDate.ToString
                '    ToDate = dtpToDate.ToString
                'Else
                '    FromDate = CDate(dtpfromDate.ToString).ToShortDateString()
                '    ToDate = CDate(dtpToDate.ToString()).ToShortDateString()
                'End If
                'Dim dt As New DataTable
                If drpProductName.Text = "All" And drpProductGroup.Text <> "All" Then
                    Dim da As New SqlDataAdapter("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "' order by ProductName", con)
                    da.SelectCommand.Transaction = tranc
                    Dim ds As New DataSet
                    da.Fill(ds)
                    'dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        'If ds.Tables(0).Rows(j).Item("ProductName") = "LARICEF 2GM" Then
                        '    MsgBox("")
                        'End If
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Purchase = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty*HSR as total FROM InvoiceDetails WHERE ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C') DERIVEDTBL"
                            PurchaseValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Sales = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT TOP 1  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C')) DERIVEDTBL"
                            SalesValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & dtpfromDate.Text & " 12:00:00 AM'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            SalesReturn = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM')) DERIVEDTBL"
                            SalesReturnValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM' and ESType='Excess'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Excess = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess')) DERIVEDTBL"
                            ExcessValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM' and ESType='Shortage'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Shortage = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage')) DERIVEDTBL"
                            ShortageValue = cmd.ExecuteScalar
                        End If
                        'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Sales = cmd.ExecuteScalar
                        'End If
                        'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    SalesReturn = cmd.ExecuteScalar
                        'End If
                        'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Excess = cmd.ExecuteScalar
                        'End If
                        'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & dt1.Rows(j).Item("ProductName") & "'and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Shortage = cmd.ExecuteScalar
                        'End If
                        openingstock = Val(Purchase) + Val(SalesReturn) + Val(Excess) - Val(Sales) - Val(Shortage)
                        OpeningValue = Val(PurchaseValue) + Val(SalesReturnValue) + Val(ExcessValue) - Val(SalesValue) - Val(ShortageValue)
                        'Next
                        'Next
                        'Next

                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime Between '" & mydate.ToShortDateString & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Purchase = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty *HSR as total FROM InvoiceDetails WHERE ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C') DERIVEDTBL"
                            PurchaseValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Sales = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C')) DERIVEDTBL"
                            SalesValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            SalesReturn = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "')) DERIVEDTBL"
                            SalesReturnValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Excess = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess')) DERIVEDTBL"
                            ExcessValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Shortage = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage')) DERIVEDTBL"
                            ShortageValue = cmd.ExecuteScalar
                        End If
                        'Dim myda As New SqlDataAdapter("SELECT s.CurrentQty, s.ProductName, s.BatchNo, s.InvoiceNo, i.HSR, s.CurrentQty * i.HSR AS TotalValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo and s.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and s.CurrentQty>0 where i.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'", con)
                        'myda.SelectCommand.Transaction = tranc
                        'Dim myds As New DataSet
                        'myda.Fill(myds)
                        'Dim myvalue As Double = 0
                        'For i As Integer = 0 To myds.Tables(0).Rows.Count - 1
                        '    myvalue = myvalue + myds.Tables(0).Rows(i).Item("TotalValue")
                        'Next
                        'myvalue = Math.Round(myvalue, 2)
                        ClosingStock = Val(openingstock) + Val(Purchase) - Val(Sales) + Val(SalesReturn) + Val(Excess) - Val(Shortage)
                        ClosingStockValue = (OpeningValue + PurchaseValue) - (SalesValue + SalesReturnValue + Excess) - ShortageValue
                        ClosingStockValue = Math.Round(ClosingStockValue, 2)
                        If CheckBox1.Checked Then
                            If Sales > 0 Or SalesReturn > 0 Then
                                DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
                                cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
                                cmd.ExecuteNonQuery()
                            End If

                        ElseIf CheckBox2.Checked Then
                            If Sales > 0 Or SalesReturn > 0 Then
                            Else
                                DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
                                cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
                                cmd.ExecuteNonQuery()

                            End If
                        Else

                            DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
                            cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
                            cmd.ExecuteNonQuery()

                        End If


                        'mydate = mydate.AddDays(1)
                    Next
                ElseIf drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
                    Dim da As New SqlDataAdapter("Select ProductName from ProductMaster order by ProductName", con)
                    da.SelectCommand.Transaction = tranc
                    Dim ds As New DataSet
                    da.Fill(ds)
                    'dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Purchase = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty*HSR as total FROM InvoiceDetails WHERE ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C') DERIVEDTBL"
                            PurchaseValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Sales = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C')) DERIVEDTBL"
                            SalesValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & dtpfromDate.Text & " 12:00:00 AM'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            SalesReturn = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM')) DERIVEDTBL"
                            SalesReturnValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM' and ESType='Excess'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Excess = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess')) DERIVEDTBL"
                            ExcessValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM' and ESType='Shortage'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Shortage = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage')) DERIVEDTBL"
                            ShortageValue = cmd.ExecuteScalar
                        End If
                        'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Sales = cmd.ExecuteScalar
                        'End If
                        'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    SalesReturn = cmd.ExecuteScalar
                        'End If
                        'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Excess = cmd.ExecuteScalar
                        'End If
                        'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & dt1.Rows(j).Item("ProductName") & "'and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Shortage = cmd.ExecuteScalar
                        'End If
                        openingstock = Val(Purchase) + Val(SalesReturn) + Val(Excess) - Val(Sales) - Val(Shortage)
                        OpeningValue = Val(PurchaseValue) + Val(SalesReturnValue) + Val(ExcessValue) - Val(SalesValue) - Val(ShortageValue)
                        'Next
                        'Next
                        'Next

                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime Between '" & mydate.ToShortDateString & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Purchase = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty *HSR as total FROM InvoiceDetails WHERE ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C') DERIVEDTBL"
                            PurchaseValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Sales = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C')) DERIVEDTBL"
                            SalesValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            SalesReturn = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "')) DERIVEDTBL"
                            SalesReturnValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Excess = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess')) DERIVEDTBL"
                            ExcessValue = cmd.ExecuteScalar
                        End If
                        cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Shortage = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage')) DERIVEDTBL"
                            ShortageValue = cmd.ExecuteScalar
                        End If
                        Dim myda As New SqlDataAdapter("SELECT s.CurrentQty, s.ProductName, s.BatchNo, s.InvoiceNo, i.HSR, s.CurrentQty * i.HSR AS TotalValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo and s.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and s.CurrentQty>0 where i.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'", con)
                        myda.SelectCommand.Transaction = tranc
                        Dim myds As New DataSet
                        myda.Fill(myds)
                        Dim myvalue As Double = 0
                        For i As Integer = 0 To myds.Tables(0).Rows.Count - 1
                            myvalue = myvalue + myds.Tables(0).Rows(i).Item("TotalValue")
                        Next
                        'myvalue = Math.Round(myvalue, 2)
                        ClosingStock = Val(openingstock) + Val(Purchase) - Val(Sales) + Val(SalesReturn) + Val(Excess) - Val(Shortage)
                        ClosingStockValue = OpeningValue + PurchaseValue - SalesValue + SalesReturnValue + ExcessValue - ShortageValue
                        ClosingStockValue = Math.Round(ClosingStockValue, 2)
                        'cmd.CommandText = "Select ISNULL(SUM(CurrentQty),0) from StockDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'"
                        'Dim cq As Integer
                        'cq = cmd.ExecuteScalar
                        'If cq <> ClosingStock Then
                        '    MsgBox("PRoduct : " & ds.Tables(0).Rows(j).Item("ProductName") & " Closing Stock: " & ClosingStock & ". Current Qty" & cq)
                        'End If
                        If CheckBox1.Checked Then
                            If Sales > 0 Or SalesReturn > 0 Then
                                DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
                                cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
                                cmd.ExecuteNonQuery()
                            End If
                        Else
                            DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
                            cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
                            cmd.ExecuteNonQuery()


                        End If

                        'mydate = mydate.AddDays(1)
                    Next
                Else
                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Purchase = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty*HSR as total FROM InvoiceDetails WHERE ProductName='" & drpProductName.Text & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C') DERIVEDTBL"
                        PurchaseValue = cmd.ExecuteScalar
                    End If
                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                    ' Commented as on  04 June 2019 Saleem 
                    'Reason -Warning: Null value is eliminated by an aggregate or other SET operation
                    Try
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Sales = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & drpProductName.Text & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C')) DERIVEDTBL"
                            SalesValue = cmd.ExecuteScalar
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Sales Value Skipped - Might be wrong ")
                        'MessageBox.Show(ex.ToString())

                    End Try
                
                    cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & drpProductName.Text & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM'"
                    Try
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            SalesReturn = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & drpProductName.Text & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM')) DERIVEDTBL"
                            SalesReturnValue = cmd.ExecuteScalar
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Sales Return Value Skipped - Might be wrong ")
                    End Try
                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Excess = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & drpProductName.Text & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess')) DERIVEDTBL"
                        ExcessValue = cmd.ExecuteScalar
                    End If
                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "'and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Shortage = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & drpProductName.Text & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage')) DERIVEDTBL"
                        ShortageValue = cmd.ExecuteScalar
                    End If

                    openingstock = Val(Purchase) - Val(Sales) - Val(Shortage) + Val(SalesReturn) + Val(Excess)
                    OpeningValue = Val(PurchaseValue) + Val(SalesReturnValue) + Val(ExcessValue) - Val(SalesValue) - Val(ShortageValue)
                    'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    Purchase = cmd.ExecuteScalar
                    'End If
                    'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    Sales = cmd.ExecuteScalar
                    'End If
                    'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & drpProductName.Text & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    SalesReturn = cmd.ExecuteScalar
                    'End If
                    'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    Excess = cmd.ExecuteScalar
                    'End If
                    'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "'and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    Shortage = cmd.ExecuteScalar
                    'End If
                    'openingstock = Val(Purchase) - Val(Sales) - Val(Shortage) + Val(SalesReturn) + Val(Excess)

                    'Next
                    'Next
                    'Next

                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Purchase = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty *HSR as total FROM InvoiceDetails WHERE ProductName='" & drpProductName.Text & "' and InvoiceDateTime between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C') DERIVEDTBL"
                        PurchaseValue = cmd.ExecuteScalar
                    End If
                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "'and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Sales = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT Top 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & drpProductName.Text & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C')) DERIVEDTBL"
                        SalesValue = cmd.ExecuteScalar
                    End If
                    cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & drpProductName.Text & "'and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        SalesReturn = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & drpProductName.Text & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "')) DERIVEDTBL"
                        SalesReturnValue = cmd.ExecuteScalar
                    End If
                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Excess = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess')) DERIVEDTBL"
                        ExcessValue = cmd.ExecuteScalar
                    End If
                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Shortage = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage')) DERIVEDTBL"
                        ShortageValue = cmd.ExecuteScalar
                    End If
                    'Dim myda As New SqlDataAdapter("SELECT s.CurrentQty, s.ProductName, s.BatchNo, s.InvoiceNo, i.HSR, s.CurrentQty * i.HSR AS TotalValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo and s.ProductName='" & drpProductName.Text & "' and s.CurrentQty>0 where i.productname='" & drpProductName.Text & "'", con)
                    'myda.SelectCommand.Transaction = tranc
                    'Dim myds As New DataSet
                    'myda.Fill(myds)
                    'Dim myvalue As Double = 0
                    'For i As Integer = 0 To myds.Tables(0).Rows.Count - 1
                    '    myvalue = myvalue + myds.Tables(0).Rows(i).Item("TotalValue")
                    'Next
                    ClosingStock = Val(openingstock) + Val(Purchase) - Val(Sales) + Val(SalesReturn) + Val(Excess) - Val(Shortage)
                    ClosingStockValue = (OpeningValue + PurchaseValue) - (SalesValue + SalesReturnValue + ExcessValue) - ShortageValue
                    ClosingStockValue = Math.Round(ClosingStockValue, 2)
                    If CheckBox1.Checked Then
                        If Sales > 0 Or SalesReturn > 0 Then
                            DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, drpProductName.Text, openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
                            'mydate = mydate.AddDays(1)
                            cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & drpProductName.Text & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
                            cmd.ExecuteNonQuery()
                        End If
                    Else
                        DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, drpProductName.Text, openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
                        'mydate = mydate.AddDays(1)
                        cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & drpProductName.Text & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
                        cmd.ExecuteNonQuery()


                    End If
                End If
                    Dim myTot As Double = 0
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        myTot = myTot + DataGridView1.Rows(i).Cells(9).Value
                    Next
                    myTot = Math.Round(myTot, 2)
                    DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), " ", " ", " ", " ", " ", " ", " ", " ", "Total", myTot)
                    tranc.Commit()
                    con.Close()
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

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Process()
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

    'Sub Process1()
    '    Try
    '        CheckConnection()
    '        Dim tranc As SqlTransaction
    '        tranc = con.BeginTransaction
    '        Try
    '            Dim cmd As New SqlCommand
    '            cmd.Connection = con
    '            cmd.Transaction = tranc
    '            cmd.CommandText = "Delete from StockPrint"
    '            cmd.ExecuteNonQuery()
    '            DataGridView1.Rows.Clear()
    '            Dim openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock As Integer
    '            Dim OpeningValue, PurchaseValue, SalesValue, SalesReturnValue, ExcessValue, ShortageValue, ClosingStockValue As Double
    '            Dim ts As TimeSpan
    '            Dim totaldays As Integer
    '            ts = CDate(dtpToDate.Text) - CDate(dtpfromDate.Text)
    '            totaldays = ts.TotalDays
    '            Dim mydate As DateTime
    '            mydate = dtpfromDate.Text
    '            Dim FromDate, ToDate As DateTime
    '            If chkIncludeTime.Checked = True Then
    '                FromDate = dtpfromDate.ToString
    '                ToDate = dtpToDate.ToString
    '            Else
    '                FromDate = CDate(dtpfromDate.ToString).ToShortDateString()
    '                ToDate = CDate(dtpToDate.ToString()).ToShortDateString()
    '            End If
    '            'Dim dt As New DataTable
    '            If drpProductName.Text = "All" And drpProductGroup.Text <> "All" Then
    '                Dim da As New SqlDataAdapter("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "' order by ProductName", con)
    '                da.SelectCommand.Transaction = tranc
    '                Dim ds As New DataSet
    '                da.Fill(ds)
    '                'dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
    '                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '                    'If ds.Tables(0).Rows(j).Item("ProductName") = "LARICEF 2GM" Then
    '                    '    MsgBox("")
    '                    'End If
    '                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDt<'" & FromDate.ToString() & "' and Status<>'C'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Purchase = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty*HSR as total FROM InvoiceDetails WHERE ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDt<'" & FromDate.ToString() & "' and Status<>'C') DERIVEDTBL"
    '                        PurchaseValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDateTime<'" & FromDate.ToString() & "' and Status<>'C'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Sales = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDateTime<'" & FromDate.ToString() & "' and Status<>'C')) DERIVEDTBL"
    '                        SalesValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & dtpfromDate.Text & " 12:00:00 AM'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        SalesReturn = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDateTime<'" & FromDate.ToString() & "')) DERIVEDTBL"
    '                        SalesReturnValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM' and ESType='Excess'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Excess = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess')) DERIVEDTBL"
    '                        ExcessValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM' and ESType='Shortage'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Shortage = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage')) DERIVEDTBL"
    '                        ShortageValue = cmd.ExecuteScalar
    '                    End If
    '                    'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                    'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    '    Sales = cmd.ExecuteScalar
    '                    'End If
    '                    'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
    '                    'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    '    SalesReturn = cmd.ExecuteScalar
    '                    'End If
    '                    'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
    '                    'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    '    Excess = cmd.ExecuteScalar
    '                    'End If
    '                    'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & dt1.Rows(j).Item("ProductName") & "'and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
    '                    'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    '    Shortage = cmd.ExecuteScalar
    '                    'End If
    '                    openingstock = Val(Purchase) + Val(SalesReturn) + Val(Excess) - Val(Sales) - Val(Shortage)
    '                    OpeningValue = Val(PurchaseValue) + Val(SalesReturnValue) + Val(ExcessValue) - Val(SalesValue) - Val(ShortageValue)
    '                    'Next
    '                    'Next
    '                    'Next

    '                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime Between '" & mydate.ToShortDateString & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Purchase = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty *HSR as total FROM InvoiceDetails WHERE ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C') DERIVEDTBL"
    '                        PurchaseValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Sales = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C')) DERIVEDTBL"
    '                        SalesValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        SalesReturn = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "')) DERIVEDTBL"
    '                        SalesReturnValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Excess = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess')) DERIVEDTBL"
    '                        ExcessValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Shortage = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage')) DERIVEDTBL"
    '                        ShortageValue = cmd.ExecuteScalar
    '                    End If
    '                    'Dim myda As New SqlDataAdapter("SELECT s.CurrentQty, s.ProductName, s.BatchNo, s.InvoiceNo, i.HSR, s.CurrentQty * i.HSR AS TotalValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo and s.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and s.CurrentQty>0 where i.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'", con)
    '                    'myda.SelectCommand.Transaction = tranc
    '                    'Dim myds As New DataSet
    '                    'myda.Fill(myds)
    '                    'Dim myvalue As Double = 0
    '                    'For i As Integer = 0 To myds.Tables(0).Rows.Count - 1
    '                    '    myvalue = myvalue + myds.Tables(0).Rows(i).Item("TotalValue")
    '                    'Next
    '                    'myvalue = Math.Round(myvalue, 2)
    '                    ClosingStock = Val(openingstock) + Val(Purchase) - Val(Sales) + Val(SalesReturn) + Val(Excess) - Val(Shortage)
    '                    ClosingStockValue = (OpeningValue + PurchaseValue) - (SalesValue + SalesReturnValue + Excess) - ShortageValue
    '                    ClosingStockValue = Math.Round(ClosingStockValue, 2)
    '                    If CheckBox1.Checked Then
    '                        If Sales > 0 Or SalesReturn > 0 Then
    '                            DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
    '                            cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
    '                            cmd.ExecuteNonQuery()
    '                        End If
    '                    Else
    '                        DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
    '                        cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
    '                        cmd.ExecuteNonQuery()

    '                    End If

    '                    'mydate = mydate.AddDays(1)
    '                Next
    '            ElseIf drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
    '                Dim da As New SqlDataAdapter("Select ProductName from ProductMaster order by ProductName", con)
    '                da.SelectCommand.Transaction = tranc
    '                Dim ds As New DataSet
    '                da.Fill(ds)
    '                'dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
    '                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Purchase = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty*HSR as total FROM InvoiceDetails WHERE ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C') DERIVEDTBL"
    '                        PurchaseValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and Status<>'C'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Sales = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C')) DERIVEDTBL"
    '                        SalesValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & dtpfromDate.Text & " 12:00:00 AM'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        SalesReturn = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM')) DERIVEDTBL"
    '                        SalesReturnValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM' and ESType='Excess'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Excess = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess')) DERIVEDTBL"
    '                        ExcessValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM' and ESType='Shortage'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Shortage = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage')) DERIVEDTBL"
    '                        ShortageValue = cmd.ExecuteScalar
    '                    End If
    '                    'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                    'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    '    Sales = cmd.ExecuteScalar
    '                    'End If
    '                    'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
    '                    'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    '    SalesReturn = cmd.ExecuteScalar
    '                    'End If
    '                    'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & dt1.Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
    '                    'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    '    Excess = cmd.ExecuteScalar
    '                    'End If
    '                    'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & dt1.Rows(j).Item("ProductName") & "'and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
    '                    'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    '    Shortage = cmd.ExecuteScalar
    '                    'End If
    '                    openingstock = Val(Purchase) + Val(SalesReturn) + Val(Excess) - Val(Sales) - Val(Shortage)
    '                    OpeningValue = Val(PurchaseValue) + Val(SalesReturnValue) + Val(ExcessValue) - Val(SalesValue) - Val(ShortageValue)
    '                    'Next
    '                    'Next
    '                    'Next

    '                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime Between '" & mydate.ToShortDateString & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Purchase = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty *HSR as total FROM InvoiceDetails WHERE ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C') DERIVEDTBL"
    '                        PurchaseValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Sales = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C')) DERIVEDTBL"
    '                        SalesValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        SalesReturn = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "')) DERIVEDTBL"
    '                        SalesReturnValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Excess = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess')) DERIVEDTBL"
    '                        ExcessValue = cmd.ExecuteScalar
    '                    End If
    '                    cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
    '                    If IsDBNull(cmd.ExecuteScalar) = False Then
    '                        Shortage = cmd.ExecuteScalar
    '                        cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage')) DERIVEDTBL"
    '                        ShortageValue = cmd.ExecuteScalar
    '                    End If
    '                    Dim myda As New SqlDataAdapter("SELECT s.CurrentQty, s.ProductName, s.BatchNo, s.InvoiceNo, i.HSR, s.CurrentQty * i.HSR AS TotalValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo and s.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and s.CurrentQty>0 where i.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'", con)
    '                    myda.SelectCommand.Transaction = tranc
    '                    Dim myds As New DataSet
    '                    myda.Fill(myds)
    '                    Dim myvalue As Double = 0
    '                    For i As Integer = 0 To myds.Tables(0).Rows.Count - 1
    '                        myvalue = myvalue + myds.Tables(0).Rows(i).Item("TotalValue")
    '                    Next
    '                    'myvalue = Math.Round(myvalue, 2)
    '                    ClosingStock = Val(openingstock) + Val(Purchase) - Val(Sales) + Val(SalesReturn) + Val(Excess) - Val(Shortage)
    '                    ClosingStockValue = OpeningValue + PurchaseValue - SalesValue + SalesReturnValue + ExcessValue - ShortageValue
    '                    ClosingStockValue = Math.Round(ClosingStockValue, 2)
    '                    'cmd.CommandText = "Select ISNULL(SUM(CurrentQty),0) from StockDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "'"
    '                    'Dim cq As Integer
    '                    'cq = cmd.ExecuteScalar
    '                    'If cq <> ClosingStock Then
    '                    '    MsgBox("PRoduct : " & ds.Tables(0).Rows(j).Item("ProductName") & " Closing Stock: " & ClosingStock & ". Current Qty" & cq)
    '                    'End If
    '                    If CheckBox1.Checked Then
    '                        If Sales > 0 Or SalesReturn > 0 Then
    '                            DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
    '                            cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
    '                            cmd.ExecuteNonQuery()
    '                        End If
    '                    Else
    '                        DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
    '                        cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
    '                        cmd.ExecuteNonQuery()


    '                    End If

    '                    'mydate = mydate.AddDays(1)
    '                Next
    '            Else
    '                cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    Purchase = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty*HSR as total FROM InvoiceDetails WHERE ProductName='" & drpProductName.Text & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C') DERIVEDTBL"
    '                    PurchaseValue = cmd.ExecuteScalar
    '                End If
    '                cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    Sales = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & drpProductName.Text & "' and BillDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C')) DERIVEDTBL"
    '                    SalesValue = cmd.ExecuteScalar
    '                End If
    '                cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & drpProductName.Text & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    SalesReturn = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & drpProductName.Text & "' and ReturnBillDate<'" & mydate.ToShortDateString & " 12:00:00 AM')) DERIVEDTBL"
    '                    SalesReturnValue = cmd.ExecuteScalar
    '                End If
    '                cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    Excess = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & drpProductName.Text & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Excess')) DERIVEDTBL"
    '                    ExcessValue = cmd.ExecuteScalar
    '                End If
    '                cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "'and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    Shortage = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & drpProductName.Text & "' and ESDate<'" & mydate.ToShortDateString & " 12:00:00 AM' and ESType='Shortage')) DERIVEDTBL"
    '                    ShortageValue = cmd.ExecuteScalar
    '                End If

    '                openingstock = Val(Purchase) - Val(Sales) - Val(Shortage) + Val(SalesReturn) + Val(Excess)
    '                OpeningValue = Val(PurchaseValue) + Val(SalesReturnValue) + Val(ExcessValue) - Val(SalesValue) - Val(ShortageValue)
    '                'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C'"
    '                'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                '    Purchase = cmd.ExecuteScalar
    '                'End If
    '                'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                '    Sales = cmd.ExecuteScalar
    '                'End If
    '                'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & drpProductName.Text & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
    '                'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                '    SalesReturn = cmd.ExecuteScalar
    '                'End If
    '                'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
    '                'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                '    Excess = cmd.ExecuteScalar
    '                'End If
    '                'cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "'and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
    '                'If IsDBNull(cmd.ExecuteScalar) = False Then
    '                '    Shortage = cmd.ExecuteScalar
    '                'End If
    '                'openingstock = Val(Purchase) - Val(Sales) - Val(Shortage) + Val(SalesReturn) + Val(Excess)

    '                'Next
    '                'Next
    '                'Next

    '                cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    Purchase = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty *HSR as total FROM InvoiceDetails WHERE ProductName='" & drpProductName.Text & "' and InvoiceDateTime between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C') DERIVEDTBL"
    '                    PurchaseValue = cmd.ExecuteScalar
    '                End If
    '                cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "'and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    Sales = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  Qty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM DrugSlipDetails d WHERE (ProductName ='" & drpProductName.Text & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C')) DERIVEDTBL"
    '                    SalesValue = cmd.ExecuteScalar
    '                End If
    '                cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & drpProductName.Text & "'and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    SalesReturn = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ReturnQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = SUBSTRING(d .InvoiceNo, 0, LEN(d .InvoiceNo)- 4) AND year(i.invoicedatetime) = SUBSTRING(d .InvoiceNo, CHARINDEX('-', d .InvoiceNo) + 1, LEN(d .InvoiceNo)))  AS total FROM SalesReturnDetails d WHERE (ProductName ='" & drpProductName.Text & "' and ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "')) DERIVEDTBL"
    '                    SalesReturnValue = cmd.ExecuteScalar
    '                End If
    '                cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    Excess = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Excess')) DERIVEDTBL"
    '                    ExcessValue = cmd.ExecuteScalar
    '                End If
    '                cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage'"
    '                If IsDBNull(cmd.ExecuteScalar) = False Then
    '                    Shortage = cmd.ExecuteScalar
    '                    cmd.CommandText = "SELECT Isnull(SUM(total),0) AS Expr1 FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d .InvoiceYear)  AS total FROM ESTable d WHERE (ProductName ='" & drpProductName.Text & "' and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and ESType='Shortage')) DERIVEDTBL"
    '                    ShortageValue = cmd.ExecuteScalar
    '                End If
    '                'Dim myda As New SqlDataAdapter("SELECT s.CurrentQty, s.ProductName, s.BatchNo, s.InvoiceNo, i.HSR, s.CurrentQty * i.HSR AS TotalValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo and s.ProductName='" & drpProductName.Text & "' and s.CurrentQty>0 where i.productname='" & drpProductName.Text & "'", con)
    '                'myda.SelectCommand.Transaction = tranc
    '                'Dim myds As New DataSet
    '                'myda.Fill(myds)
    '                'Dim myvalue As Double = 0
    '                'For i As Integer = 0 To myds.Tables(0).Rows.Count - 1
    '                '    myvalue = myvalue + myds.Tables(0).Rows(i).Item("TotalValue")
    '                'Next
    '                ClosingStock = Val(openingstock) + Val(Purchase) - Val(Sales) + Val(SalesReturn) + Val(Excess) - Val(Shortage)
    '                ClosingStockValue = (OpeningValue + PurchaseValue) - (SalesValue + SalesReturnValue + ExcessValue) - ShortageValue
    '                ClosingStockValue = Math.Round(ClosingStockValue, 2)
    '                If CheckBox1.Checked Then
    '                    If Sales > 0 Or SalesReturn > 0 Then
    '                        DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, drpProductName.Text, openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
    '                        'mydate = mydate.AddDays(1)
    '                        cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & drpProductName.Text & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
    '                        cmd.ExecuteNonQuery()
    '                    End If
    '                Else
    '                    DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), mydate.ToShortDateString, drpProductName.Text, openingstock, Purchase, Sales, SalesReturn, Excess, Shortage, ClosingStock, ClosingStockValue)
    '                    'mydate = mydate.AddDays(1)
    '                    cmd.CommandText = "insert into StockPrint Values('" & mydate.ToShortDateString & "','" & drpProductName.Text & "'," & openingstock & "," & Purchase & "," & Sales & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & ClosingStockValue & ")"
    '                    cmd.ExecuteNonQuery()


    '                End If
    '            End If
    '            Dim myTot As Double = 0
    '            For i As Integer = 0 To DataGridView1.Rows.Count - 1
    '                myTot = myTot + DataGridView1.Rows(i).Cells(9).Value
    '            Next
    '            myTot = Math.Round(myTot, 2)
    '            DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), " ", " ", " ", " ", " ", " ", " ", " ", "Total", myTot)
    '            tranc.Commit()
    '            con.Close()
    '        Catch ex As Exception
    '            tranc.Rollback()
    '            con.Close()
    '            MsgBox(ex.Message)
    '        End Try
    '    Catch ex As Exception
    '        con.Close()
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

End Class
