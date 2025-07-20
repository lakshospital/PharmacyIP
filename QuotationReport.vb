Imports System.Data.SqlClient
Public Class QuotationReport

    Private Sub QuotationReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim arr As New ArrayList
        arr.Add("All")
        dt = SelectQuery("SELECT GroupName FROM ProductGroupMaster")
        For i As Integer = 0 To dt.Rows.Count - 1
            arr.Add(dt.Rows(i).Item("GroupName"))
        Next
        drpProductGroup.DataSource = arr

        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        arr1.Add("All")
        dt1 = SelectQuery("Select SupplierName from SupplierMaster")
        For i As Integer = 0 To dt1.Rows.Count - 1
            arr1.Add(dt1.Rows(i).Item("SupplierName"))
        Next
        drpSupplierName.DataSource = arr1

        Dim dt2 As New DataTable
        Dim arr2 As New ArrayList
        arr2.Add("All")
        dt2 = SelectQuery("Select DoctorName from DoctorNameMaster")
        For i As Integer = 0 To dt2.Rows.Count - 1
            arr2.Add(dt2.Rows(i).Item("DoctorName"))
        Next
        drpDrName.DataSource = arr2


        ' ''TODO: This line of code loads data into the 'dsQuotationProfit.DataTable1' table. You can move, or remove it, as needed.
        ''Me.DataTable1TableAdapter.Fill(Me.dsQuotationProfit.DataTable1)
        ' ''TODO: This line of code loads data into the 'dsQuotationProfit.FromToDateTable' table. You can move, or remove it, as needed.
        ''Me.FromToDateTableTableAdapter.Fill(Me.dsQuotationProfit.FromToDateTable)

        ''Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        Dim SupplierID As Integer
        Dim dt As New DataTable
        dt = SelectQuery("Select SupplierID from SupplierMaster where SupplierName='" & drpSupplierName.Text & "'")
        If dt.Rows.Count > 0 Then
            SupplierID = dt.Rows(0).Item("SupplierID")
        End If
        '1
        If drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
            'TODO: This line of code loads data into the 'dsQuotationProfit.InvoiceDetails' table. You can move, or remove it, as needed.
            Me.DataTable1TableAdapter.Fill(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text)
            '2
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text = "All" And drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, SupplierID)
            '3
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text <> "All" And drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy1(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, drpDrName.Text)
            '4
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy2(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, drpProductGroup.Text)
            '5
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text = "All" And drpProductName.Text <> "All" Then
            Me.DataTable1TableAdapter.FillBy3(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, drpProductName.Text)
            '6
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text <> "All" Then
            Me.DataTable1TableAdapter.FillBy3(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, drpProductName.Text)
            '7
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text <> "All" And drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy4(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, SupplierID, drpDrName.Text)
            '8
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy5(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, SupplierID, drpProductGroup.Text)
            '9
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text = "All" And drpProductGroup.Text = "All" And drpProductName.Text <> "All" Then
            Me.DataTable1TableAdapter.FillBy6(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, SupplierID, drpProductName.Text)
            '10
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text <> "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy7(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, drpDrName.Text, drpProductGroup.Text)
            '11
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text <> "All" And drpProductGroup.Text = "All" And drpProductName.Text <> "All" Then
            Me.DataTable1TableAdapter.FillBy8(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, drpDrName.Text, drpProductName.Text)
            '12
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text <> "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy9(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, SupplierID, drpDrName.Text, drpProductGroup.Text)
            '13
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text <> "All" And drpProductGroup.Text <> "All" And drpProductName.Text <> "All" Then
            Me.DataTable1TableAdapter.FillBy10(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, drpDrName.Text, drpProductName.Text)
            '14
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text <> "All" Then
            Me.DataTable1TableAdapter.FillBy11(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, SupplierID, drpProductName.Text)
            '15
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text <> "All" And drpProductGroup.Text = "All" And drpProductName.Text <> "All" Then
            Me.DataTable1TableAdapter.FillBy12(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, SupplierID, drpDrName.Text, drpProductName.Text)
            '16
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.DataTable1TableAdapter.FillBy13(Me.dsQuotationProfit.DataTable1, dtpfromDate.Text, dtpToDate.Text, SupplierID, drpDrName.Text, drpProductName.Text)
        End If
        'TODO: This line of code loads data into the 'dsPurchaseProfitPercentage.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsQuotationProfit.FromToDateTable)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub drpProductGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProductGroup.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        If drpProductGroup.Text <> "All" Then
            arr1.Add("All")
            dt1 = SelectQuery("Select ProductName from ProductMaster where ProductGroup='" & drpProductGroup.Text & "'")
            For i As Integer = 0 To dt1.Rows.Count - 1
                arr1.Add(dt1.Rows(i).Item("ProductName"))
            Next
            drpProductName.DataSource = arr1
        Else
            arr1.Add("All")
            dt1 = SelectQuery("Select ProductName from ProductMaster")
            For i As Integer = 0 To dt1.Rows.Count - 1
                arr1.Add(dt1.Rows(i).Item("ProductName"))
            Next
            drpProductName.DataSource = arr1
        End If
    End Sub
End Class