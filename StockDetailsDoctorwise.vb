Imports System.Data.SqlClient
Public Class StockDetailsDoctorwise

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Process()
        lblPurchase.Text = "Purchase - Product Purchased By " & drpDrName.Text
        lblSalesFromOwnPurchase.Text = "Sales From Own Purchase - Sales From Purchase of " & drpDrName.Text & " and Sold by " & drpDrName.Text
        lblSalesFromPurchase.Text = "Sales From Purchase - Sales (Including other doctors) From Purchase of " & drpDrName.Text
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub StockDetailsDoctorwise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        dt = SelectQuery("Select * from DoctorNameMaster")
        drpDrName.DataSource = dt
        drpDrName.DisplayMember = "DoctorName"
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
    Sub Process()
        Try
            CheckConnection()
            Dim tranc As SqlTransaction
            tranc = con.BeginTransaction
            Try
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.Transaction = tranc
                cmd.CommandText = "Delete from StockPrint1"
                cmd.ExecuteNonQuery()
                DataGridView1.Rows.Clear()
                Dim openingstock, Purchase, Sales, OwnSales, SalesReturn, Excess, Shortage, ClosingStock As Integer
                Dim ts As TimeSpan
                Dim totaldays As Integer
                ts = CDate(dtpToDate.Text) - CDate(dtpfromDate.Text)
                totaldays = ts.TotalDays
                Dim mydate As DateTime
                mydate = dtpfromDate.Text
                'Dim dt As New DataTable
                If drpProductName.Text = "All" Then
                    Dim da As New SqlDataAdapter("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "' order by ProductName", con)
                    da.SelectCommand.Transaction = tranc
                    Dim ds As New DataSet
                    da.Fill(ds)
                    'dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C' and DoctorName='" & drpDrName.Text & "'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Purchase = cmd.ExecuteScalar
                        End If

                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and Status<>'C' and DrName='" & drpDrName.Text & "'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            'Actual Sales Including all invoice
                            Sales = cmd.ExecuteScalar
                        End If

                        Dim ownda As New SqlDataAdapter("SELECT DISTINCT d.BillNo,d.BillDate, d.SNo, d.BillDate, d.ProductName, d.Qty, d.InvoiceNo, i.DoctorName FROM DrugSlipDetails d INNER JOIN InvoiceDetails i ON d.DrName = i.DoctorName AND SUBSTRING(d.InvoiceNo, 0, LEN(d.InvoiceNo) - 4) = i.InvoiceNo WHERE (d.BillDate<'" & dtpfromDate.Text & " 12:00:00 AM') AND (d.ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (d.DrName ='" & drpDrName.Text & "') and d.Status<>'C' ORDER BY d.BillNo", con)
                        Dim ownds As New DataSet
                        ownda.SelectCommand.Transaction = tranc
                        ownda.Fill(ownds)
                        OwnSales = 0
                        For i As Integer = 0 To ownds.Tables(0).Rows.Count - 1
                            'Sales from His own invoice
                            OwnSales = OwnSales + ownds.Tables(0).Rows(i).Item("Qty")
                        Next

                        Dim ownss As Integer
                        Dim ownsda As New SqlDataAdapter("SELECT DISTINCT d.BillNo,d.BillDate, d.SNo, d.BillDate, d.ProductName, d.Qty, d.InvoiceNo, i.DoctorName FROM DrugSlipDetails d INNER JOIN InvoiceDetails i ON SUBSTRING(d.InvoiceNo, 0, LEN(d.InvoiceNo) - 4) =  i.InvoiceNo AND d.ProductName = i.ProductName and YEAR(i.InvoiceDateTime) = SUBSTRING(d.InvoiceNo, CHARINDEX('-', d.InvoiceNo) + 1, LEN(d.InvoiceNo))  WHERE (d.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (d.BillDate < '" & dtpfromDate.Text & "') AND (i.DoctorName = '" & drpDrName.Text & "')  and d.Status<>'C' ORDER BY d.BillNo", con)
                        Dim ownsds As New DataSet
                        ownsda.SelectCommand.Transaction = tranc
                        ownsda.Fill(ownsds)
                        ownss = 0

                        For i As Integer = 0 To ownsds.Tables(0).Rows.Count - 1
                            ownss = ownss + ownsds.Tables(0).Rows(i).Item("Qty")
                        Next

                        'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and DrName='" & drpDrName.Text & "'"
                        Dim SalesReturnda As New SqlDataAdapter("SELECT DISTINCT s.ReturnBillNo, s.ReturnBillDate, s.SalesBillDate, s.ProductName, s.ReturnQty, s.InvoiceNo, s.DrName FROM   SalesReturnDetails s INNER JOIN InvoiceDetails i ON s.ProductName = i.ProductName AND SUBSTRING(s.InvoiceNo, 0, LEN(s.InvoiceNo) - 4) = i.InvoiceNo WHERE  (s.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (s.ReturnBillDate < '" & dtpfromDate.Text & "') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY s.ReturnBillNo", con)
                        Dim SalesReturnds As New DataSet
                        SalesReturnda.SelectCommand.Transaction = tranc
                        SalesReturnda.Fill(SalesReturnds)
                        SalesReturn = 0
                        For i As Integer = 0 To SalesReturnds.Tables(0).Rows.Count - 1
                            SalesReturn = SalesReturn + SalesReturnds.Tables(0).Rows(i).Item("ReturnQty")
                        Next

                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    SalesReturn = cmd.ExecuteScalar
                        'End If
                        Dim Excessda As New SqlDataAdapter("SELECT DISTINCT e.ESNo, e.ESDate, e.ProductName, e.ESQty, e.InvoiceNo, i.DoctorName FROM  ESTable e INNER JOIN InvoiceDetails i ON e.ProductName = i.ProductName AND e.InvoiceNo = i.InvoiceNo AND YEAR(i.InvoiceDateTime) = e.InvoiceYear WHERE  (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (e.ESDate < '" & dtpfromDate.Text & "') AND (e.ESType = 'Excess') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY e.ESNo", con)
                        Dim Excessds As New DataSet
                        Excessda.SelectCommand.Transaction = tranc
                        Excessda.Fill(Excessds)
                        Excess = 0
                        For i As Integer = 0 To Excessds.Tables(0).Rows.Count - 1
                            Excess = Excess + Excessds.Tables(0).Rows(i).Item("ESQty")
                        Next

                        'cmd.CommandText = "SELECT ISNULL(SUM(e.ESQty),0) as Expr1 FROM ESTable e INNER JOIN InvoiceDetails i ON e.InvoiceNo = i.InvoiceNo WHERE (i.DoctorName = '" & drpDrName.Text & "') AND (e.ESType = 'Excess') AND (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Excess = cmd.ExecuteScalar
                        'End If


                        Dim Shortageda As New SqlDataAdapter("SELECT DISTINCT e.ESNo, e.ESDate, e.ProductName, e.ESQty, e.InvoiceNo, i.DoctorName FROM  ESTable e INNER JOIN InvoiceDetails i ON e.ProductName = i.ProductName AND e.InvoiceNo = i.InvoiceNo AND YEAR(i.InvoiceDateTime) = e.InvoiceYear WHERE  (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (e.ESDate < '" & dtpfromDate.Text & "') AND (e.ESType = 'Shortage') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY e.ESNo", con)
                        Dim Shortageds As New DataSet
                        Shortageda.SelectCommand.Transaction = tranc
                        Shortageda.Fill(Shortageds)
                        Shortage = 0
                        For i As Integer = 0 To Shortageds.Tables(0).Rows.Count - 1
                            Shortage = Shortage + Shortageds.Tables(0).Rows(i).Item("ESQty")
                        Next

                      
                        openingstock = Val(Purchase) + Val(SalesReturn) + Val(Excess) - Val(ownss) - Val(Shortage)

                        'Next
                        'Next
                        'Next

                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and InvoiceDateTime Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C' and DoctorName='" & drpDrName.Text & "'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            Purchase = cmd.ExecuteScalar
                        End If

                        cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C' and DrName='" & drpDrName.Text & "'"
                        If IsDBNull(cmd.ExecuteScalar) = False Then
                            'Actual Sales Including all invoice
                            Sales = cmd.ExecuteScalar
                        End If

                        Dim ownda1 As New SqlDataAdapter("SELECT DISTINCT d.BillNo,d.BillDate, d.SNo, d.BillDate, d.ProductName, d.Qty, d.InvoiceNo, i.DoctorName FROM DrugSlipDetails d INNER JOIN InvoiceDetails i ON d.DrName = i.DoctorName AND SUBSTRING(d.InvoiceNo, 0, LEN(d.InvoiceNo) - 4) = i.InvoiceNo WHERE (d.BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (d.ProductName ='" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (d.DrName ='" & drpDrName.Text & "')  and d.Status<>'C'  ORDER BY d.BillNo", con)
                        Dim ownds1 As New DataSet
                        ownda1.SelectCommand.Transaction = tranc
                        ownda1.Fill(ownds1)
                        OwnSales = 0
                        For i As Integer = 0 To ownds1.Tables(0).Rows.Count - 1
                            'Sales from His own invoice
                            OwnSales = OwnSales + ownds1.Tables(0).Rows(i).Item("Qty")
                        Next


                        Dim ownsda1 As New SqlDataAdapter("SELECT DISTINCT d.BillNo,d.BillDate, d.SNo, d.BillDate, d.ProductName, d.Qty, d.InvoiceNo, i.DoctorName FROM DrugSlipDetails d INNER JOIN InvoiceDetails i ON SUBSTRING(d.InvoiceNo, 0, LEN(d.InvoiceNo) - 4) = i.InvoiceNo AND d.ProductName = i.ProductName and YEAR(i.InvoiceDateTime) = SUBSTRING(d.InvoiceNo, CHARINDEX('-', d.InvoiceNo) + 1, LEN(d.InvoiceNo)) WHERE (d.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (d.BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (i.DoctorName = '" & drpDrName.Text & "') and d.Status<>'C'   ORDER BY d.BillNo", con)
                        Dim ownsds1 As New DataSet
                        ownsda1.SelectCommand.Transaction = tranc
                        ownsda1.Fill(ownsds1)
                        ownss = 0
                        For i As Integer = 0 To ownsds1.Tables(0).Rows.Count - 1
                            ownss = ownss + ownsds1.Tables(0).Rows(i).Item("Qty")
                        Next

                        'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and DrName='" & drpDrName.Text & "'"
                        Dim SalesReturnda1 As New SqlDataAdapter("SELECT DISTINCT s.ReturnBillNo, s.ReturnBillDate, s.SalesBillDate, s.ProductName, s.ReturnQty, s.InvoiceNo, s.DrName FROM   SalesReturnDetails s INNER JOIN InvoiceDetails i ON s.ProductName = i.ProductName AND SUBSTRING(s.InvoiceNo, 0, LEN(s.InvoiceNo) - 4) = i.InvoiceNo WHERE  (s.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (s.ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY s.ReturnBillNo", con)
                        Dim SalesReturnds1 As New DataSet
                        SalesReturnda1.SelectCommand.Transaction = tranc
                        SalesReturnda1.Fill(SalesReturnds1)
                        SalesReturn = 0
                        For i As Integer = 0 To SalesReturnds1.Tables(0).Rows.Count - 1
                            SalesReturn = SalesReturn + SalesReturnds1.Tables(0).Rows(i).Item("ReturnQty")
                        Next

                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    SalesReturn = cmd.ExecuteScalar
                        'End If
                        Dim Excessda1 As New SqlDataAdapter("SELECT DISTINCT e.ESNo, e.ESDate, e.ProductName, e.ESQty, e.InvoiceNo, i.DoctorName FROM  ESTable e INNER JOIN InvoiceDetails i ON e.ProductName = i.ProductName AND e.InvoiceNo = i.InvoiceNo AND YEAR(i.InvoiceDateTime) = e.InvoiceYear WHERE  (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (e.ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (e.ESType = 'Excess') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY e.ESNo", con)
                        Dim Excessds1 As New DataSet
                        Excessda1.SelectCommand.Transaction = tranc
                        Excessda1.Fill(Excessds1)
                        Excess = 0
                        For i As Integer = 0 To Excessds1.Tables(0).Rows.Count - 1
                            Excess = Excess + Excessds1.Tables(0).Rows(i).Item("ESQty")
                        Next

                        'cmd.CommandText = "SELECT ISNULL(SUM(e.ESQty),0) as Expr1 FROM ESTable e INNER JOIN InvoiceDetails i ON e.InvoiceNo = i.InvoiceNo WHERE (i.DoctorName = '" & drpDrName.Text & "') AND (e.ESType = 'Excess') AND (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Excess = cmd.ExecuteScalar
                        'End If


                        Dim Shortageda1 As New SqlDataAdapter("SELECT DISTINCT e.ESNo, e.ESDate, e.ProductName, e.ESQty, e.InvoiceNo, i.DoctorName FROM  ESTable e INNER JOIN InvoiceDetails i ON e.ProductName = i.ProductName AND e.InvoiceNo = i.InvoiceNo AND YEAR(i.InvoiceDateTime) = e.InvoiceYear WHERE  (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') AND (e.ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (e.ESType = 'Shortage') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY e.ESNo", con)
                        Dim Shortageds1 As New DataSet
                        Shortageda1.SelectCommand.Transaction = tranc
                        Shortageda1.Fill(Shortageds1)
                        Shortage = 0
                        For i As Integer = 0 To Shortageds1.Tables(0).Rows.Count - 1
                            Shortage = Shortage + Shortageds1.Tables(0).Rows(i).Item("ESQty")
                        Next
                       

                        '''''''''''''''paste here
                        'cmd.CommandText = "SELECT ISNULL(SUM(e.ESQty),0) as Expr1 FROM ESTable e INNER JOIN InvoiceDetails i ON e.InvoiceNo = i.InvoiceNo WHERE (i.DoctorName = '" & drpDrName.Text & "') AND (e.ESType = 'Shortage') AND (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') and ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "'"
                        'If IsDBNull(cmd.ExecuteScalar) = False Then
                        '    Shortage = cmd.ExecuteScalar
                        'End If

                        Dim myda As New SqlDataAdapter("SELECT s.CurrentQty, s.ProductName, s.BatchNo, s.InvoiceNo, i.HSR, s.CurrentQty * i.HSR AS TotalValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo and s.ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and s.CurrentQty>0 and i.DoctorName = '" & drpDrName.Text & "'", con)
                        myda.SelectCommand.Transaction = tranc
                        Dim myds As New DataSet
                        myda.Fill(myds)
                        Dim myvalue As Double = 0
                        For i As Integer = 0 To myds.Tables(0).Rows.Count - 1
                            myvalue = myvalue + myds.Tables(0).Rows(i).Item("TotalValue")
                        Next
                        myvalue = Math.Round(myvalue, 2)
                        ClosingStock = Val(openingstock) + Val(Purchase) + Val(SalesReturn) + Val(Excess) - Val(ownss) - Val(Shortage)
                        DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), ds.Tables(0).Rows(j).Item("ProductName"), openingstock, Purchase, Sales, OwnSales, ownss, SalesReturn, Excess, Shortage, ClosingStock, myvalue)
                        cmd.CommandText = "insert into StockPrint1 Values('" & ds.Tables(0).Rows(j).Item("ProductName") & "'," & openingstock & "," & Purchase & "," & Sales & "," & OwnSales & "," & ownss & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & myvalue & ",'" & drpDrName.Text & "')"
                        cmd.ExecuteNonQuery()
                        'mydate = mydate.AddDays(1)
                    Next
                Else

                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime<'" & mydate.ToShortDateString & " 12:00:00 AM' and Status<>'C' and DoctorName='" & drpDrName.Text & "'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Purchase = cmd.ExecuteScalar
                    End If

                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "' and BillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and Status<>'C' and DrName='" & drpDrName.Text & "'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        'Actual Sales Including all invoice
                        Sales = cmd.ExecuteScalar
                    End If

                    Dim ownda As New SqlDataAdapter("SELECT DISTINCT d.BillNo,d.BillDate, d.SNo, d.BillDate, d.ProductName, d.Qty, d.InvoiceNo, i.DoctorName FROM DrugSlipDetails d INNER JOIN InvoiceDetails i ON d.DrName = i.DoctorName AND SUBSTRING(d.InvoiceNo, 0, LEN(d.InvoiceNo) - 4) = i.InvoiceNo WHERE (d.BillDate<'" & dtpfromDate.Text & " 12:00:00 AM') AND (d.ProductName ='" & drpProductName.Text & "') AND (d.DrName ='" & drpDrName.Text & "') and d.Status<>'C' ORDER BY d.BillNo", con)
                    Dim ownds As New DataSet
                    ownda.SelectCommand.Transaction = tranc
                    ownda.Fill(ownds)
                    OwnSales = 0
                    For i As Integer = 0 To ownds.Tables(0).Rows.Count - 1
                        'Sales from His own invoice
                        OwnSales = OwnSales + ownds.Tables(0).Rows(i).Item("Qty")
                    Next

                    Dim ownss As Integer
                    Dim ownsda As New SqlDataAdapter("SELECT DISTINCT d.BillNo,d.BillDate, d.SNo, d.BillDate, d.ProductName, d.Qty, d.InvoiceNo, i.DoctorName FROM DrugSlipDetails d INNER JOIN InvoiceDetails i ON SUBSTRING(d.InvoiceNo, 0, LEN(d.InvoiceNo) - 4) = i.InvoiceNo AND d.ProductName = i.ProductName and YEAR(i.InvoiceDateTime) = SUBSTRING(d.InvoiceNo, CHARINDEX('-', d.InvoiceNo) + 1, LEN(d.InvoiceNo)) WHERE (d.ProductName = '" & drpProductName.Text & "') AND (d.BillDate < '" & dtpfromDate.Text & "') AND (i.DoctorName = '" & drpDrName.Text & "')  and d.Status<>'C'  ORDER BY d.BillNo", con)
                    Dim ownsds As New DataSet
                    ownsda.SelectCommand.Transaction = tranc
                    ownsda.Fill(ownsds)
                    ownss = 0

                    For i As Integer = 0 To ownsds.Tables(0).Rows.Count - 1
                        ownss = ownss + ownsds.Tables(0).Rows(i).Item("Qty")
                    Next

                    'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and DrName='" & drpDrName.Text & "'"
                    Dim SalesReturnda As New SqlDataAdapter("SELECT DISTINCT s.ReturnBillNo, s.ReturnBillDate, s.SalesBillDate, s.ProductName, s.ReturnQty, s.InvoiceNo, s.DrName FROM   SalesReturnDetails s INNER JOIN InvoiceDetails i ON s.ProductName = i.ProductName AND SUBSTRING(s.InvoiceNo, 0, LEN(s.InvoiceNo) - 4) = i.InvoiceNo WHERE  (s.ProductName = '" & drpProductName.Text & "') AND (s.ReturnBillDate < '" & dtpfromDate.Text & "') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY s.ReturnBillNo", con)
                    Dim SalesReturnds As New DataSet
                    SalesReturnda.SelectCommand.Transaction = tranc
                    SalesReturnda.Fill(SalesReturnds)
                    SalesReturn = 0
                    For i As Integer = 0 To SalesReturnds.Tables(0).Rows.Count - 1
                        SalesReturn = SalesReturn + SalesReturnds.Tables(0).Rows(i).Item("ReturnQty")
                    Next

                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    SalesReturn = cmd.ExecuteScalar
                    'End If
                    Dim Excessda As New SqlDataAdapter("SELECT DISTINCT e.ESNo, e.ESDate, e.ProductName, e.ESQty, e.InvoiceNo, i.DoctorName FROM  ESTable e INNER JOIN InvoiceDetails i ON e.ProductName = i.ProductName AND e.InvoiceNo = i.InvoiceNo AND YEAR(i.InvoiceDateTime) = e.InvoiceYear WHERE  (e.ProductName = '" & drpProductName.Text & "') AND (e.ESDate < '" & dtpfromDate.Text & "') AND (e.ESType = 'Excess') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY e.ESNo", con)
                    Dim Excessds As New DataSet
                    Excessda.SelectCommand.Transaction = tranc
                    Excessda.Fill(Excessds)
                    Excess = 0
                    For i As Integer = 0 To Excessds.Tables(0).Rows.Count - 1
                        Excess = Excess + Excessds.Tables(0).Rows(i).Item("ESQty")
                    Next

                    'cmd.CommandText = "SELECT ISNULL(SUM(e.ESQty),0) as Expr1 FROM ESTable e INNER JOIN InvoiceDetails i ON e.InvoiceNo = i.InvoiceNo WHERE (i.DoctorName = '" & drpDrName.Text & "') AND (e.ESType = 'Excess') AND (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM'"
                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    Excess = cmd.ExecuteScalar
                    'End If


                    Dim Shortageda As New SqlDataAdapter("SELECT DISTINCT e.ESNo, e.ESDate, e.ProductName, e.ESQty, e.InvoiceNo, i.DoctorName FROM  ESTable e INNER JOIN InvoiceDetails i ON e.ProductName = i.ProductName AND e.InvoiceNo = i.InvoiceNo AND YEAR(i.InvoiceDateTime) = e.InvoiceYear WHERE  (e.ProductName = '" & drpProductName.Text & "') AND (e.ESDate < '" & dtpfromDate.Text & "') AND (e.ESType = 'Shortage') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY e.ESNo", con)
                    Dim Shortageds As New DataSet
                    Shortageda.SelectCommand.Transaction = tranc
                    Shortageda.Fill(Shortageds)
                    Shortage = 0
                    For i As Integer = 0 To Shortageds.Tables(0).Rows.Count - 1
                        Shortage = Shortage + Shortageds.Tables(0).Rows(i).Item("ESQty")
                    Next


                    openingstock = Val(Purchase) + Val(SalesReturn) + Val(Excess) - Val(ownss) - Val(Shortage)

                    'Next
                    'Next
                    'Next

                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceDateTime Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C' and DoctorName='" & drpDrName.Text & "'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        Purchase = cmd.ExecuteScalar
                    End If

                    cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & drpProductName.Text & "' and BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "' and Status<>'C' and DrName='" & drpDrName.Text & "'"
                    If IsDBNull(cmd.ExecuteScalar) = False Then
                        'Actual Sales Including all invoice
                        Sales = cmd.ExecuteScalar
                    End If

                    Dim ownda1 As New SqlDataAdapter("SELECT DISTINCT d.BillNo,d.BillDate, d.SNo, d.BillDate, d.ProductName, d.Qty, d.InvoiceNo, i.DoctorName FROM DrugSlipDetails d INNER JOIN InvoiceDetails i ON d.DrName = i.DoctorName AND SUBSTRING(d.InvoiceNo, 0, LEN(d.InvoiceNo) - 4) = i.InvoiceNo WHERE (d.BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (d.ProductName ='" & drpProductName.Text & "') AND (d.DrName ='" & drpDrName.Text & "')  and d.Status<>'C'  ORDER BY d.BillNo", con)
                    Dim ownds1 As New DataSet
                    ownda1.SelectCommand.Transaction = tranc
                    ownda1.Fill(ownds1)
                    OwnSales = 0
                    For i As Integer = 0 To ownds1.Tables(0).Rows.Count - 1
                        'Sales from His own invoice
                        OwnSales = OwnSales + ownds1.Tables(0).Rows(i).Item("Qty")
                    Next


                    Dim ownsda1 As New SqlDataAdapter("SELECT DISTINCT d.BillNo,d.BillDate, d.SNo, d.BillDate, d.ProductName, d.Qty, d.InvoiceNo, i.DoctorName FROM DrugSlipDetails d INNER JOIN InvoiceDetails i ON SUBSTRING(d.InvoiceNo, 0, LEN(d.InvoiceNo) - 4) = i.InvoiceNo AND d.ProductName = i.ProductName and YEAR(i.InvoiceDateTime) = SUBSTRING(d.InvoiceNo, CHARINDEX('-', d.InvoiceNo) + 1, LEN(d.InvoiceNo)) WHERE (d.ProductName = '" & drpProductName.Text & "') AND (d.BillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (i.DoctorName = '" & drpDrName.Text & "') and d.Status<>'C'   ORDER BY d.BillNo", con)
                    Dim ownsds1 As New DataSet
                    ownsda1.SelectCommand.Transaction = tranc
                    ownsda1.Fill(ownsds1)
                    ownss = 0
                    For i As Integer = 0 To ownsds1.Tables(0).Rows.Count - 1
                        ownss = ownss + ownsds1.Tables(0).Rows(i).Item("Qty")
                    Next

                    'cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ds.Tables(0).Rows(j).Item("ProductName") & "' and ReturnBillDate<'" & dtpfromDate.Text & " 12:00:00 AM' and DrName='" & drpDrName.Text & "'"
                    Dim SalesReturnda1 As New SqlDataAdapter("SELECT DISTINCT s.ReturnBillNo, s.ReturnBillDate, s.SalesBillDate, s.ProductName, s.ReturnQty, s.InvoiceNo, s.DrName FROM   SalesReturnDetails s INNER JOIN InvoiceDetails i ON s.ProductName = i.ProductName AND SUBSTRING(s.InvoiceNo, 0, LEN(s.InvoiceNo) - 4) = i.InvoiceNo WHERE  (s.ProductName = '" & drpProductName.Text & "') AND (s.ReturnBillDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY s.ReturnBillNo", con)
                    Dim SalesReturnds1 As New DataSet
                    SalesReturnda1.SelectCommand.Transaction = tranc
                    SalesReturnda1.Fill(SalesReturnds1)
                    SalesReturn = 0
                    For i As Integer = 0 To SalesReturnds1.Tables(0).Rows.Count - 1
                        SalesReturn = SalesReturn + SalesReturnds1.Tables(0).Rows(i).Item("ReturnQty")
                    Next

                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    SalesReturn = cmd.ExecuteScalar
                    'End If
                    Dim Excessda1 As New SqlDataAdapter("SELECT DISTINCT e.ESNo, e.ESDate, e.ProductName, e.ESQty, e.InvoiceNo, i.DoctorName FROM  ESTable e INNER JOIN InvoiceDetails i ON e.ProductName = i.ProductName AND e.InvoiceNo = i.InvoiceNo AND YEAR(i.InvoiceDateTime) = e.InvoiceYear WHERE  (e.ProductName = '" & drpProductName.Text & "') AND (e.ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (e.ESType = 'Excess') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY e.ESNo", con)
                    Dim Excessds1 As New DataSet
                    Excessda1.SelectCommand.Transaction = tranc
                    Excessda1.Fill(Excessds1)
                    Excess = 0
                    For i As Integer = 0 To Excessds1.Tables(0).Rows.Count - 1
                        Excess = Excess + Excessds1.Tables(0).Rows(i).Item("ESQty")
                    Next

                    'cmd.CommandText = "SELECT ISNULL(SUM(e.ESQty),0) as Expr1 FROM ESTable e INNER JOIN InvoiceDetails i ON e.InvoiceNo = i.InvoiceNo WHERE (i.DoctorName = '" & drpDrName.Text & "') AND (e.ESType = 'Excess') AND (e.ProductName = '" & ds.Tables(0).Rows(j).Item("ProductName") & "') and ESDate<'" & dtpfromDate.Text & " 12:00:00 AM'"
                    'If IsDBNull(cmd.ExecuteScalar) = False Then
                    '    Excess = cmd.ExecuteScalar
                    'End If


                    Dim Shortageda1 As New SqlDataAdapter("SELECT DISTINCT e.ESNo, e.ESDate, e.ProductName, e.ESQty, e.InvoiceNo, i.DoctorName FROM  ESTable e INNER JOIN InvoiceDetails i ON e.ProductName = i.ProductName AND e.InvoiceNo = i.InvoiceNo AND YEAR(i.InvoiceDateTime) = e.InvoiceYear WHERE  (e.ProductName = '" & drpProductName.Text & "') AND (e.ESDate Between '" & dtpfromDate.Text & "' and '" & dtpToDate.Text & "') AND (e.ESType = 'Shortage') AND (i.DoctorName = '" & drpDrName.Text & "') ORDER BY e.ESNo", con)
                    Dim Shortageds1 As New DataSet
                    Shortageda1.SelectCommand.Transaction = tranc
                    Shortageda1.Fill(Shortageds1)
                    Shortage = 0
                    For i As Integer = 0 To Shortageds1.Tables(0).Rows.Count - 1
                        Shortage = Shortage + Shortageds1.Tables(0).Rows(i).Item("ESQty")
                    Next


                    Dim myda As New SqlDataAdapter("SELECT s.CurrentQty, s.ProductName, s.BatchNo, s.InvoiceNo, i.HSR, s.CurrentQty * i.HSR AS TotalValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo and s.ProductName='" & drpProductName.Text & "' and s.CurrentQty>0 and i.DoctorName = '" & drpDrName.Text & "'", con)
                    myda.SelectCommand.Transaction = tranc
                    Dim myds As New DataSet
                    myda.Fill(myds)
                    Dim myvalue As Double = 0
                    For i As Integer = 0 To myds.Tables(0).Rows.Count - 1
                        myvalue = myvalue + myds.Tables(0).Rows(i).Item("TotalValue")
                    Next
                    myvalue = Math.Round(myvalue, 2)
                    ClosingStock = Val(openingstock) + Val(Purchase) + Val(SalesReturn) + Val(Excess) - Val(ownss) - Val(Shortage)
                    DataGridView1.Rows.Insert(Val(DataGridView1.Rows.Count), drpProductName.Text, openingstock, Purchase, Sales, OwnSales, ownss, SalesReturn, Excess, Shortage, ClosingStock, myvalue)
                    cmd.CommandText = "insert into StockPrint1 Values('" & drpProductName.Text & "'," & openingstock & "," & Purchase & "," & Sales & "," & OwnSales & "," & ownss & "," & SalesReturn & "," & Excess & "," & Shortage & "," & ClosingStock & "," & myvalue & ",'" & drpDrName.Text & "')"
                    cmd.ExecuteNonQuery()
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
        frmStockDoctorwisePrint.Show()
    End Sub
End Class