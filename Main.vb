Public Class Main

    Private Sub ProductMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductMasterToolStripMenuItem.Click
        ProductMaster.Show()
    End Sub

    Private Sub SupplierMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierMasterToolStripMenuItem.Click
        SupplierMaster.Show()
    End Sub

    Private Sub DoctorNameMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoctorNameMasterToolStripMenuItem.Click
        DrNameMaster.Show()
    End Sub

    Private Sub ProductGroupMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductGroupMasterToolStripMenuItem.Click
        ProductGroupMaster.Show()
    End Sub

    Private Sub CaseTypeMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaseTypeMasterToolStripMenuItem.Click
        If UserRights = "User" Then
            MsgBox("You dont have permission, please  contact administrator", MsgBoxStyle.Information)
        Else
            CaseTypeMaster.Show()
        End If
    End Sub

    Private Sub SupplierDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierDetailsToolStripMenuItem.Click
        SupplierReport.Show()
    End Sub

    Private Sub ProductDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductDetailsToolStripMenuItem.Click
        ProductReport.Show()
    End Sub

    Private Sub SalesBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesBillToolStripMenuItem.Click
        DrugSlip.Show()
    End Sub

    Private Sub PurchaseEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseEntryToolStripMenuItem.Click
        If UserRights = "User" Then
            MsgBox("You dont have permission, please  contact administrator", MsgBoxStyle.Information)
        Else
            PurchaseEntry.Show()
        End If
    End Sub

    Private Sub SalesReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnToolStripMenuItem.Click
        SalesReturn.Show()
    End Sub

    Private Sub MasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterToolStripMenuItem.Click

    End Sub

    Private Sub DrugSlipBetweenDateConsolidateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrugSlipBetweenDateConsolidateToolStripMenuItem.Click
        DrugSlipBetweenDateConsolidate.Show()
    End Sub

    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        niLowStock.Visible = False
        niExpDate.Visible = False
        End
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dt As New DataTable
        'Dim fd, td As New System.DateTime
        'fd = System.DateTime.Now.ToShortDateString
        'Dim ts As New TimeSpan
        'fd = System.DateTime.Now.Subtract(TimeSpan.FromDays(30)).ToShortDateString
        'td = System.DateTime.Now.ToShortDateString
        'dt = SelectQuery("SELECT ProductName, ROUND(SUM(Qty) / 30 * 7,0) AS Average, (SELECT  SUM(CurrentQty)  FROM   StockDetails   WHERE  StockDetails.ProductName = DrugSlipDetails.ProductName) AS CurrentStock FROM    DrugSlipDetails WHERE   (BillDate BETWEEN '" & fd & "' AND '" & td & "') AND (Status <> 'C') GROUP BY ProductName ORDER BY ProductName")
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    If CInt(dt.Rows(i).Item("Average")) > CInt(dt.Rows(i).Item("CurrentStock")) Then
        '        'niLowStock.Icon
        '        niLowStock.BalloonTipIcon = ToolTipIcon.Warning
        '        niLowStock.BalloonTipText = "There is some low stock products,Click me to See Report"
        '        niLowStock.BalloonTipTitle = "Low Stock in Pharmacy"
        '        niLowStock.Visible = True
        '        niLowStock.ShowBalloonTip(1)
        '        'MsgBox("There is Some Low Stock for Some Products")
        '        'LowStock.Show()
        '    End If
        'Next

        'dt = SelectQuery("SELECT p.ProductName, ISNULL(SUM(s.CurrentQty), 0) AS TotalStock FROM StockDetails s RIGHT OUTER JOIN ProductMaster p ON s.ProductName = p.ProductName GROUP BY p.ProductName HAVING (ISNULL(SUM(s.CurrentQty), 0) < (SELECT minimumstock FROM productmaster WHERE productname = p.productname))")
        'If dt.Rows.Count > 0 Then
        '    'niLowStock.Icon
        '    niLowStock.BalloonTipIcon = ToolTipIcon.Warning
        '    niLowStock.BalloonTipText = "There is some low stock products,Click me to See Report"
        '    niLowStock.BalloonTipTitle = "Low Stock in Pharmacy"
        '    niLowStock.Visible = True
        '    niLowStock.ShowBalloonTip(1)
        '    'MsgBox("There is Some Low Stock for Some Products")
        '    'LowStock.Show()
        'End If
        'dt = SelectQuery("Select * from StockDetails where ExpDate<='" & System.DateTime.Now.Date & "' and ExpDate>='" & System.DateTime.Now.AddMonths(1) & "'")
        'dt = SelectQuery("Select * from StockDetails where ExpDate<='" & System.DateTime.Now.AddMonths(1) & "' and CurrentQty>0")
        'If dt.Rows.Count > 0 Then
        '    niExpDate.BalloonTipIcon = ToolTipIcon.Warning
        '    niExpDate.BalloonTipText = "There is some products near to Exp.Date,Click me to See Report"
        '    niExpDate.BalloonTipTitle = "Products Near Exp.Date in Pharmacy"
        '    niExpDate.Visible = True
        '    niExpDate.ShowBalloonTip(3)
        'End If
    End Sub

    Private Sub CancelBillsBetweenDateConsolidateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBillsBetweenDateConsolidateToolStripMenuItem.Click
        CancelBillsBetweenDatewiseConsolidate.Show()
    End Sub

    Private Sub SalesReturnBetweenDateConsolidateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnBetweenDateConsolidateToolStripMenuItem.Click
        SalesReturnBetweenDatewise.Show()
    End Sub

    Private Sub CasewiseReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CasewiseReportToolStripMenuItem.Click
        Casewise_Report.Show()
    End Sub

    Private Sub DrugSlipBetweenDateFullToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrugSlipBetweenDateFullToolStripMenuItem.Click
        DrugSlipBetweenDatewiseFull.Show()
    End Sub

    Private Sub DrugSlipBetweenBillNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrugSlipBetweenBillNoToolStripMenuItem.Click
        DrugSlipBetweenBillNoFull.Show()
    End Sub

    Private Sub PurchaseReportDatewiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReportDatewiseToolStripMenuItem.Click
        PurchaseReportDatewise.Show()
    End Sub

    Private Sub PurchaseProfitReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseProfitReportToolStripMenuItem.Click
        PurchaseProfitPercentage.Show()
    End Sub
    Private Sub ExcessShortageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcessShortageToolStripMenuItem.Click
        ExcessShortage.Show()
    End Sub

    Private Sub StockDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockDetailsToolStripMenuItem.Click
        StockDetails.Show()
    End Sub

    Private Sub OTCasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTCasesToolStripMenuItem.Click
        OTReportsBetweenDatewise.Show()
    End Sub

    Private Sub DeliveryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryReportToolStripMenuItem.Click
        DeliveryReport.Show()
    End Sub

    Private Sub StockDetailsBetweenDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockDetailsBetweenDateToolStripMenuItem.Click
        StockDetailsDatewise.Show()
    End Sub

    Private Sub LowStockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LowStockReportToolStripMenuItem.Click
        LowStock.Show()
    End Sub

    Private Sub niLowStock_BalloonTipClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles niLowStock.BalloonTipClicked
        LowStock.Show()
    End Sub
    Private Sub niLowStock_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niLowStock.MouseDoubleClick
        LowStock.Show()
    End Sub

    Private Sub niExpDate_BalloonTipClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles niExpDate.BalloonTipClicked
        ProductNearExpDate.Show()
    End Sub

    Private Sub niExpDate_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niExpDate.MouseDoubleClick
        ProductNearExpDate.Show()
    End Sub

    Private Sub ExpProductReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpProductReportToolStripMenuItem.Click
        ProductNearExpDate.Show()
    End Sub

    Private Sub IPNoWiseFullToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IPNoWiseFullToolStripMenuItem.Click
        IPNowiseBill.Show()
    End Sub

    Private Sub IPNoWiseConsolidatedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IPNoWiseConsolidatedToolStripMenuItem.Click
        IPNowiseConsolidated.Show()
    End Sub

    Private Sub ProductWiseDrugSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductWiseDrugSlipToolStripMenuItem.Click
        SalesProductwise.Show()
    End Sub

    Private Sub CloudButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloudButton1.Click
        DrugSlip.Show()
    End Sub

    Private Sub CloudButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloudButton2.Click
        If UserRights = "User" Then
            MsgBox("You dont have permission, please  contact administrator", MsgBoxStyle.Information)
        Else
            PurchaseEntry.Show()
        End If
    End Sub

    Private Sub CloudButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloudButton3.Click
        SalesReturn.Show()
    End Sub

    Private Sub CloudButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloudButton4.Click
        End
    End Sub

    Private Sub ExcessShortageReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcessShortageReportToolStripMenuItem.Click
        ExcessShortageReport.Show()
    End Sub

    Private Sub StockDetailsDoctorwiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockDetailsDoctorwiseToolStripMenuItem.Click
        StockDetailsDoctorwise.Show()
    End Sub

    Private Sub QuotationEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationEntryToolStripMenuItem1.Click
        QuotationEntry.Show()
    End Sub

    Private Sub QuotationReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationReportToolStripMenuItem1.Click
        QuotationReport.Show()
    End Sub

    Private Sub SalesReturnCategorywiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnCategorywiseToolStripMenuItem.Click
        frmSalesReturnCategorywise.Show()
    End Sub

    Private Sub SalesTaxReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTaxReportToolStripMenuItem.Click
        frmSalesTaxReport.Show()
    End Sub

    Private Sub PurchaseReportSalesTaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReportSalesTaxToolStripMenuItem.Click
        frmPurchaseReportSalesTax.Show()
    End Sub

    Private Sub CashlessBillsFullToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashlessBillsFullToolStripMenuItem.Click
        CashLessBillBetweenDateFull.Show()
    End Sub

    Private Sub SupplierwiseSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierwiseSalesReportToolStripMenuItem.Click
        frmSupplierwiseSales.Show()
    End Sub

    Private Sub NewSalesTaxReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSalesTaxReportToolStripMenuItem.Click
        frmNewSalesTax.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        If UserRights = "Admin" Then
            frmChangePassword.Show()
        Else
            MsgBox("You dont have permission to change password", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CreditToBePaidTillDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToBePaidTillDateToolStripMenuItem.Click
        frmCreditToBePaid.Show()
    End Sub

    Private Sub AmountToBeReturnedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmountToBeReturnedToolStripMenuItem.Click
        frmAmountToReturn.Show()
    End Sub

    Private Sub AmountToBeReturnedToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmountToBeReturnedToolStripMenuItem1.Click
        frmAmoutToBeReturnBetweenDate.Show()
    End Sub

    Private Sub CreditToBePaidToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToBePaidToolStripMenuItem.Click
        frmCreditToBePaidBetweenDate.Show()
    End Sub

    Private Sub CreditPaidToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditPaidToolStripMenuItem.Click
        frmCreditPaidBetweenDate.Show()
    End Sub

    Private Sub AmountReturnedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmountReturnedToolStripMenuItem.Click
        frmAmountReturnedBetweenDate.Show()
    End Sub

    Private Sub CombinationNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CombinationNameToolStripMenuItem.Click
        CombinationMaster.Show()
    End Sub

    Private Sub ScheduleHReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleHReportToolStripMenuItem.Click
        ScheduleHDrug.Show()
    End Sub

    
    Private Sub OTTemlateReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTTemlateReportToolStripMenuItem.Click
        OTTemplateReport.Show()
    End Sub

    Private Sub OTTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTTemplateToolStripMenuItem.Click
        If UserRights = "Admin" Then
            OTTemplate.Show()
        Else
            MsgBox("You dont have permission to access this form", MsgBoxStyle.Information, "Access denied")
        End If

    End Sub


    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        S_OT_DELIVERY.Show()
    End Sub

    Private Sub PurchaseOrderFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderFormToolStripMenuItem.Click
        S_PO.Show()
    End Sub

    Private Sub InformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformationToolStripMenuItem.Click
        frmInformation.Show()
    End Sub

    Private Sub ClaimPatientNameChangesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaimPatientNameChangesToolStripMenuItem.Click

    End Sub

    Private Sub ReportDailySalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportDailySalesToolStripMenuItem.Click
        frmDailySalesReport.Show()
    End Sub
End Class