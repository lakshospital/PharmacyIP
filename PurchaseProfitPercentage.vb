Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class PurchaseProfitPercentage

    Private Sub PurchaseProfitPercentage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


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

        Dim ords As New ArrayList
        ords.Add("InvoiceNo")
        ords.Add("ProductName")
        ords.Add("SupplierName")
        drpOrder.DataSource = ords

    End Sub
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
        cmd.CommandText = "delete from InvoiceTitle"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into InvoiceTitle values('" & drpProductName.Text & "','" & drpProductGroup.Text & "')"
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
            'TODO: This line of code loads data into the 'dsPurchaseProfitPercentage.InvoiceDetails' table. You can move, or remove it, as needed.
            Me.InvoiceDetailsTableAdapter.Fill(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString)
            '2
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text = "All" And drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, SupplierID)
            '3
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text <> "All" And drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy1(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, drpDrName.Text)
            '4
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy2(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, drpProductGroup.Text)
            '5
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text = "All" And drpProductName.Text <> "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy3(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, drpProductName.Text)
            '6
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text <> "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy3(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, drpProductName.Text)
            '7
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text <> "All" And drpProductGroup.Text = "All" And drpProductName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy4(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, SupplierID, drpDrName.Text)
            '8
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy5(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, SupplierID, drpProductGroup.Text)
            '9
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text = "All" And drpProductGroup.Text = "All" And drpProductName.Text <> "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy6(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, SupplierID, drpProductName.Text)
            '10
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text <> "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy7(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, drpDrName.Text, drpProductGroup.Text)
            '11
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text <> "All" And drpProductGroup.Text = "All" And drpProductName.Text <> "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy8(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, drpDrName.Text, drpProductName.Text)
            '12
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text <> "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy9(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, SupplierID, drpDrName.Text, drpProductGroup.Text)
            '13
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text <> "All" And drpProductGroup.Text <> "All" And drpProductName.Text <> "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy10(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, drpDrName.Text, drpProductName.Text)
            '14
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text <> "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy11(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, SupplierID, drpProductName.Text)
            '15
        ElseIf drpSupplierName.Text <> "All" And drpDrName.Text <> "All" And drpProductGroup.Text = "All" And drpProductName.Text <> "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy12(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, SupplierID, drpDrName.Text, drpProductName.Text)
            '16
        ElseIf drpSupplierName.Text = "All" And drpDrName.Text = "All" And drpProductGroup.Text <> "All" And drpProductName.Text = "All" Then
            Me.InvoiceDetailsTableAdapter.FillBy13(Me.dsPurchaseProfitPercentage.InvoiceDetails, FromDt.ToString, Todt.ToString, SupplierID, drpDrName.Text, drpProductName.Text)
        End If
        'TODO: This line of code loads data into the 'dsPurchaseProfitPercentage.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsPurchaseProfitPercentage.FromToDateTable)
        Me.InvoiceTitleTableAdapter.Fill(Me.dsPurchaseProfitPercentage.InvoiceTitle)
        'Dim params(0) As ReportParameter
        'params(0) = New ReportParameter("Ord", "InvoiceDetails" & drpOrder.Text.ToString, False)
        'Me.ReportViewer1.LocalReport.SetParameters(params)
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

    Private Sub ReportViewer1_Drillthrough(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.DrillthroughEventArgs) Handles ReportViewer1.Drillthrough
        Dim lc As LocalReport = DirectCast(e.Report, LocalReport)
        Dim i As Integer
        Dim arr As New ArrayList
        i = 0
        Dim DrillThroughValues As ReportParameterInfoCollection
        DrillThroughValues = e.Report.GetParameters()

        For Each d As ReportParameterInfo In DrillThroughValues
            arr.Add(d.Values(0).ToString.Trim)
            i = i + 1
        Next

        Me.InvoiceDetails_HistoryTableAdapter.Fill(Me.DataSet4.InvoiceDetails_History, arr(0).ToString)


        lc.DataSources.Add(New ReportDataSource("DataSet4_InvoiceDetails_History", DataSet4.InvoiceDetails_History))


        'lc.DataSources.Add(New ReportDataSource("DataSet1_PaymentHistory", DataSet1.PaymentHistory))
        'Dim paymentHistory = New ReportDataSource("DataSet1_PaymentHistory", DataSet1.PaymentHistory.DefaultView)
        'Me.ReportViewer1.LocalReport.DataSources.Add(paymentHistory)


        lc.Refresh()
    End Sub
End Class