Imports System.Data.SqlClient
Public Class frmDailySalesReport
    Dim totalAmount As String = 0
    Private Sub frmDailySalesReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDailySalesData("SELECT BillDate,ProductName,SUM(Qty)as Qty FROM [PharmacyDB].[dbo].[DrugSlipDetails]  where BillDate ='" & dtpFromDate.Text & "' GROUP BY ProductName,BillDate order by ProductName", 2)
    End Sub
    Private Sub LoadDailySalesData(ByVal xQry As String, ByVal xFieldId As Integer)
        Dim da As New SqlDataAdapter(xQry, con)
        Dim ds As New DataSet
        CheckConnection()

        Using cmd As New SqlCommand(xQry, con)
            cmd.CommandType = CommandType.Text
            Using sda As New SqlDataAdapter(cmd)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    DataGridView1.DataSource = dt
                End Using
            End Using
        End Using
        totalAmount = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            totalAmount += DataGridView1.Rows(i).Cells(xFieldId).Value
        Next
        lblTotalAmount.Text = totalAmount.ToString()
        con.Close()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromAndToDateView.Click
        LoadDailySalesData("SELECT ProductName,SUM(Qty)as Qty FROM [PharmacyDB].[dbo].[DrugSlipDetails]  where BillDate >='" & dtpFromDate.Text & "'  and BillDate <='" & dtpToDate.Text & "' GROUP BY ProductName order by ProductName", 1)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        'Dim xlApp As Microsoft.Office.Interop.Excel.Application
        'Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        'Dim misValue As Object = System.Reflection.Missing.Value
        'Dim i As Integer
        'Dim j As Integer

        '//xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        'xlWorkSheet = xlWorkBook.Sheets("sheet1")


        'For i = 0 To DataGridView1.RowCount - 2
        '    For j = 0 To DataGridView1.ColumnCount - 1
        '        For k As Integer = 1 To DataGridView1.Columns.Count
        '            xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
        '            xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
        '        Next
        '    Next
        'Next

        'xlWorkSheet.SaveAs("D:\dailysales.xlsx")
        'xlWorkBook.Close()
        'xlApp.Quit()

        'releaseObject(xlApp)
        'releaseObject(xlWorkBook)
        'releaseObject(xlWorkSheet)

        'MsgBox("You can find the file D:\dailysales.xlsx")
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub btnSummaryView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromDateView.Click
        LoadDailySalesData("SELECT BillDate,ProductName,SUM(Qty)as Qty FROM [PharmacyDB].[dbo].[DrugSlipDetails]  where BillDate ='" & dtpFromDate.Text & "' GROUP BY ProductName,BillDate order by ProductName", 2)
    End Sub
End Class