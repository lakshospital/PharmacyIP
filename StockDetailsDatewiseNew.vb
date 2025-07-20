Imports System.Data.SqlClient
Public Class StockDetailsDatewiseNew

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

    '--- Process method starts here ---
    Sub Process()
        Try
            CheckConnection()
            ' Get product list before starting transaction
            Dim dtProducts As New DataTable()
            If drpProductGroup.Text = "All" Or drpProductGroup.Text = "" Then
                dtProducts = SelectQuery("Select ProductName from ProductMaster order by ProductName")
            Else
                dtProducts = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "' order by ProductName")
            End If

            Dim tranc As SqlTransaction = con.BeginTransaction
            Dim cmd As New SqlCommand()
            cmd.Connection = con
            cmd.Transaction = tranc
            cmd.CommandText = "Delete from StockPrint"
            cmd.ExecuteNonQuery()
            DataGridView1.Rows.Clear()

            ' Progress bar setup
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = dtProducts.Rows.Count
            ProgressBar1.Value = 0

            For i As Integer = 0 To dtProducts.Rows.Count - 1
                Dim ProductName As String = dtProducts.Rows(i).Item("ProductName").ToString()
                ' Opening Stock and Value as of FromDate (old logic)
                Dim openingstock As Integer = 0
                Dim OpeningValue As Double = 0
                cmd.CommandText = "Select ISNULL(SUM(Qty),0) from InvoiceDetails where ProductName='" & ProductName & "' and InvoiceDateTime<'" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' and Status<>'C'"
                Dim Purchase As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    Purchase = cmd.ExecuteScalar
                End If
                cmd.CommandText = "SELECT Isnull(SUM(Qty*HSR),0) FROM InvoiceDetails WHERE ProductName='" & ProductName & "' and InvoiceDateTime<'" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' and Status<>'C'"
                Dim PurchaseValue As Double = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    PurchaseValue = cmd.ExecuteScalar
                End If
                cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where ProductName='" & ProductName & "' and BillDate<'" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' and Status<>'C'"
                Dim Sales As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    Sales = cmd.ExecuteScalar
                End If
                cmd.CommandText = "Select ISNULL(SUM(ReturnQty),0) from SalesReturnDetails where ProductName='" & ProductName & "' and ReturnBillDate<'" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "'"
                Dim SalesReturn As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    SalesReturn = cmd.ExecuteScalar
                End If
                cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ProductName & "' and ESDate<'" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' and ESType='Excess'"
                Dim Excess As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    Excess = cmd.ExecuteScalar
                End If
                cmd.CommandText = "Select ISNULL(SUM(ESQty),0) from ESTable where ProductName='" & ProductName & "' and ESDate<'" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' and ESType='Shortage'"
                Dim Shortage As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    Shortage = cmd.ExecuteScalar
                End If
                ' OpeningValue calculation (old logic)
                OpeningValue = PurchaseValue + SalesReturn + Excess - Sales - Shortage
                openingstock = Purchase + SalesReturn + Excess - Sales - Shortage

                ' Now get aggregates for the selected date range (new logic)
                cmd.CommandText = "SELECT ISNULL(SUM(Qty),0) FROM InvoiceDetails WHERE ProductName='" & ProductName & "' AND InvoiceDateTime BETWEEN '" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpToDate.Value.ToString("yyyy-MM-dd") & "' AND Status<>'C'"
                Dim PurchasePeriod As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    PurchasePeriod = cmd.ExecuteScalar
                End If
                cmd.CommandText = "SELECT ISNULL(SUM(Qty*HSR),0) FROM InvoiceDetails WHERE ProductName='" & ProductName & "' AND InvoiceDateTime BETWEEN '" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpToDate.Value.ToString("yyyy-MM-dd") & "' AND Status<>'C'"
                Dim PurchaseValuePeriod As Double = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    PurchaseValuePeriod = cmd.ExecuteScalar
                End If
                cmd.CommandText = "SELECT ISNULL(SUM(Qty),0) FROM DrugSlipDetails WHERE ProductName='" & ProductName & "' AND BillDate BETWEEN '" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpToDate.Value.ToString("yyyy-MM-dd") & "' AND Status<>'C'"
                Dim SalesPeriod As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    SalesPeriod = cmd.ExecuteScalar
                End If
                cmd.CommandText = "SELECT ISNULL(SUM(ReturnQty),0) FROM SalesReturnDetails WHERE ProductName='" & ProductName & "' AND ReturnBillDate BETWEEN '" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpToDate.Value.ToString("yyyy-MM-dd") & "'"
                Dim SalesReturnPeriod As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    SalesReturnPeriod = cmd.ExecuteScalar
                End If
                cmd.CommandText = "SELECT ISNULL(SUM(ESQty),0) FROM ESTable WHERE ProductName='" & ProductName & "' AND ESDate BETWEEN '" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpToDate.Value.ToString("yyyy-MM-dd") & "' AND ESType='Excess'"
                Dim ExcessPeriod As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    ExcessPeriod = cmd.ExecuteScalar
                End If
                cmd.CommandText = "SELECT ISNULL(SUM(ESQty),0) FROM ESTable WHERE ProductName='" & ProductName & "' AND ESDate BETWEEN '" & dtpfromDate.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpToDate.Value.ToString("yyyy-MM-dd") & "' AND ESType='Shortage'"
                Dim ShortagePeriod As Integer = 0
                If IsDBNull(cmd.ExecuteScalar) = False Then
                    ShortagePeriod = cmd.ExecuteScalar
                End If

                ' Calculate closing stock
                Dim ClosingStock As Integer = openingstock + PurchasePeriod - SalesPeriod + SalesReturnPeriod + ExcessPeriod - ShortagePeriod

                ' Calculate Stock Value (Rs) using a single JOIN query for batch-wise logic
                Dim ClosingStockValue As Double = 0
                Dim valueCmd As New SqlCommand()
                valueCmd.Connection = con
                valueCmd.Transaction = tranc
                valueCmd.CommandText = "SELECT SUM(s.CurrentQty * i.HSR) AS StockValue FROM StockDetails s INNER JOIN InvoiceDetails i ON s.ProductName = i.ProductName AND s.BatchNo = i.BatchNo AND s.InvoiceNo = i.InvoiceNo WHERE s.ProductName = @ProductName AND s.CurrentQty > 0"
                valueCmd.Parameters.AddWithValue("@ProductName", ProductName)
                Dim valueObj = valueCmd.ExecuteScalar()
                If Not IsDBNull(valueObj) AndAlso valueObj IsNot Nothing Then ClosingStockValue = Convert.ToDouble(valueObj)
                ClosingStockValue = Math.Round(ClosingStockValue, 2)

                If CheckBox1.Checked Then
                    If SalesPeriod > 0 Or SalesReturnPeriod > 0 Then
                        DataGridView1.Rows.Add(dtpfromDate.Value.ToShortDateString(), ProductName, openingstock, PurchasePeriod, SalesPeriod, SalesReturnPeriod, ExcessPeriod, ShortagePeriod, ClosingStock, ClosingStockValue)
                        cmd.CommandText = "insert into StockPrint Values(@Date,@ProductName,@OpeningStock,@Purchase,@Sales,@SalesReturn,@Excess,@Shortage,@ClosingStock,@ClosingStockValue)"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@Date", dtpfromDate.Value.ToShortDateString())
                        cmd.Parameters.AddWithValue("@ProductName", ProductName)
                        cmd.Parameters.AddWithValue("@OpeningStock", openingstock)
                        cmd.Parameters.AddWithValue("@Purchase", PurchasePeriod)
                        cmd.Parameters.AddWithValue("@Sales", SalesPeriod)
                        cmd.Parameters.AddWithValue("@SalesReturn", SalesReturnPeriod)
                        cmd.Parameters.AddWithValue("@Excess", ExcessPeriod)
                        cmd.Parameters.AddWithValue("@Shortage", ShortagePeriod)
                        cmd.Parameters.AddWithValue("@ClosingStock", ClosingStock)
                        cmd.Parameters.AddWithValue("@ClosingStockValue", ClosingStockValue)
                        cmd.ExecuteNonQuery()
                    End If
                Else
                    DataGridView1.Rows.Add(dtpfromDate.Value.ToShortDateString(), ProductName, openingstock, PurchasePeriod, SalesPeriod, SalesReturnPeriod, ExcessPeriod, ShortagePeriod, ClosingStock, ClosingStockValue)
                    cmd.CommandText = "insert into StockPrint Values(@Date,@ProductName,@OpeningStock,@Purchase,@Sales,@SalesReturn,@Excess,@Shortage,@ClosingStock,@ClosingStockValue)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@Date", dtpfromDate.Value.ToShortDateString())
                    cmd.Parameters.AddWithValue("@ProductName", ProductName)
                    cmd.Parameters.AddWithValue("@OpeningStock", openingstock)
                    cmd.Parameters.AddWithValue("@Purchase", PurchasePeriod)
                    cmd.Parameters.AddWithValue("@Sales", SalesPeriod)
                    cmd.Parameters.AddWithValue("@SalesReturn", SalesReturnPeriod)
                    cmd.Parameters.AddWithValue("@Excess", ExcessPeriod)
                    cmd.Parameters.AddWithValue("@Shortage", ShortagePeriod)
                    cmd.Parameters.AddWithValue("@ClosingStock", ClosingStock)
                    cmd.Parameters.AddWithValue("@ClosingStockValue", ClosingStockValue)
                    cmd.ExecuteNonQuery()
                End If
                ProgressBar1.Value = i + 1
                Application.DoEvents() ' Allow UI to update
            Next

            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = dtProducts.Rows.Count
            ProgressBar1.Value = 0

            ProgressBar1.Visible = False
            MsgBox("Process completed!")
            'tranc.Rollback()
            con.Close()
        Catch ex As Exception
        con.Close()
        MsgBox(ex.Message)
        End Try
    End Sub

End Class
