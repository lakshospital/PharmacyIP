Imports System.Data.SqlClient
Public Class DrugSlip
    Dim OldBillNo, BillYear As String
    Dim CheckFlag As Boolean
    Public BillDate As System.DateTime
    Dim PaymentUpdate As New SqlCommand
    Dim PaymentInsert As New SqlCommand
    Dim Cashless As String
    Sub EnableEditDG()

    End Sub
    Sub DisableEditDG()

    End Sub

    Sub ClearControls()
        txtBillNo.Text = ""
        txtQty.Text = ""
        txtPatientID.Text = ""
        txtPatientName.Text = ""
        lblGrandTotal.Text = ""
        ErrorProvider1.Clear()
        Dim fmt As DateTimePickerFormat = txtExpDate.Format
        dtpIncidentDate.Format = DateTimePickerFormat.Long
        dtpIncidentDate.Format = DateTimePickerFormat.Custom
        dtpIncidentDate.Format = fmt
        DataGridView1.Rows.Clear()
    End Sub
    Sub MakeCancel()
        drpCase.Enabled = True
        cmdShow.Text = "&Cancel"
        cmdShow.Image = My.Resources.Resource1.Cancel
    End Sub
    Sub Cancel()
        drpCase.Enabled = True
        txtBillNo.ReadOnly = False
        cmdNew.Text = "&New"
        cmdNew.Image = My.Resources.Resource1._New
        cmdEdit.Text = "&Edit"
        cmdEdit.Image = My.Resources.Resource1.Edit
        cmdShow.Text = "&Show"
        cmdShow.Image = My.Resources.Resource1.Search
        ErrorProvider1.Clear()
    End Sub
    Sub MakeShow()
        cmdPaymentDue.Visible = False
        cmdShow.Text = "&Show"
        cmdShow.Image = My.Resources.Resource1.Search
    End Sub
    Sub CalcGrandTotal()
        Dim Total As Double
        Total = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Total = Total + Val(DataGridView1.Rows(i).Cells(8).Value)
        Next
        lblGrandTotal.Text = Total
    End Sub

    Private Sub DrugSlip_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Main.Enabled = True
    End Sub

    Private Sub Billing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Enabled = False
        Dim dt As New DataTable
        PaymentUpdate.Connection = con
        PaymentInsert.Connection = con
        dt = SelectQuery("Select ProductName from ProductMaster")
        drpProductName.DisplayMember = "ProductName"
        drpProductName.DataSource = dt
        dt = SelectQuery("Select DoctorName from DoctorNameMaster")
        drpDrName.DataSource = dt
        drpDrName.DisplayMember = "DoctorName"
        dt = SelectQuery("Select CaseName from CaseTypeMaster")
        drpCase.DataSource = dt
        drpCase.DisplayMember = "CaseName"
        DispLastBill()
        cmdNew.Select()
        lblDt.Visible = False
    End Sub
    Sub DispLastBill()
        Dim cmd As New SqlCommand("Select isnull(Max(BillNo),0) from DrugSlipDetails where Year(BillDate)='" & System.DateTime.Now.Year & "'", con)
        Dim lastbill As String
        CheckConnection()
        lastbill = cmd.ExecuteScalar
        con.Close()
        If lastbill = 0 Then
            lblLastBillNo.Text = "No Last Bill found"
        Else
            lblLastBillNo.Text = "Last BillNo: " & lastbill
        End If
    End Sub
    Private Sub drpProductName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpProductName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyData = Keys.Right Then
            If chkCashlessBill.Enabled = False Then
                cmdNew.Focus()
            Else
                chkCashlessBill.Focus()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub drpProductName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProductName.SelectedIndexChanged
        Dim dt As New DataTable
        Dim invoiceno, year As String
        Dim arr As New ArrayList
        Dim totalStock As Integer

        txtQty.Text = ""
        txtCurrentStockQty.Text = ""
        txtRackNo.Text = ""
        txtBatch.Text = ""
        txtVat.Text = ""
        txtDoctorWhoPurchased.Text = ""
        txtMRP.Text = ""
        totalStock = 0
        dt = SelectQuery("Select InvoiceNo,InvoiceDateTime,CurrentQty from StockDetails where ProductName='" & drpProductName.Text & "' and CurrentQty>0 and ExpDate>'" & System.DateTime.Now & "' order by InvoiceNo asc")
        For i As Integer = 0 To dt.Rows.Count - 1
            invoiceno = dt.Rows(i).Item("InvoiceNo")
            year = CDate(dt.Rows(i).Item("InvoiceDateTime").ToString).Year
            arr.Add(invoiceno & "-" & year)
            totalStock += dt.Rows(i).Item("CurrentQty")
        Next
        If dt.Rows.Count <= 0 Then
            txtBatch.DataSource = arr
        End If
        lblTotalStock.Text = totalStock.ToString()
        'drpInvoiceNo.DisplayMember = "InvoiceNo"
        drpInvoiceNo.DataSource = arr
    End Sub
    Sub DisplayProductDetails()
        Dim dt As New DataTable
        dt = SelectQuery("Select * from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceNo=" & txtBillNo.Text)
    End Sub
    Function ValidateBill() As Boolean
        Dim dt As New DataTable
        If txtPatientID.Text.Length = 0 Then
            MsgBox("Please Select Valid Patient ID", MsgBoxStyle.Exclamation, "Validation")
            Button1.Focus()
            Return False
        ElseIf txtPatientName.Text.Length = 0 Then
            MsgBox("Please Select Valid Patient ID", MsgBoxStyle.Exclamation, "Validation")
            Button1.Focus()
            Return False
        ElseIf drpCase.Text.Length = 0 Then
            MsgBox("Please Select Valid Case", MsgBoxStyle.Exclamation, "Validation")
            drpCase.Focus()
            Return False
        ElseIf DataGridView1.Rows.Count <= 0 Then
            MsgBox("Bill should contain minimum 1 Prouduct", MsgBoxStyle.Exclamation, "Validation")
            drpProductName.Focus()
            Return False
        ElseIf drpCase.Text <> "OP" And txtPatientID.Text = "10" And UserRights = "User" Then
            MsgBox("This bill cannot have patient id as 10, Please change patient id", MsgBoxStyle.Exclamation)
            Return False
        ElseIf drpCase.Text <> "OP" And (cmdNew.Text = "&Save" Or cmdEdit.Text = "&Update") Then
            dt = SelectQuery("Select * from DrugSlipDetails where PatientID='" & txtPatientID.Text & "' and Status<>'C' and CaseType='" & drpCase.Text & "'")
            If dt.Rows.Count > 0 Then
                If cmdNew.Text = "&Save" Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(i).Item("CaseType") = "ABD HYS" Or
                           dt.Rows(i).Item("CaseType") = "ABH HYS" Or
                           dt.Rows(i).Item("CaseType") = "GS" Or
                           dt.Rows(i).Item("CaseType") = "DIA LAP" Or
                           dt.Rows(i).Item("CaseType") = "HYS LAP" Or
                           dt.Rows(i).Item("CaseType") = "LAP" Or
                           dt.Rows(i).Item("CaseType") = "LAP HYS" Or
                           dt.Rows(i).Item("CaseType") = "LSCS" Or
                           dt.Rows(i).Item("CaseType") = "PS" Or
                           dt.Rows(i).Item("CaseType") = "VAG HYS" Or
                           dt.Rows(i).Item("CaseType") = "NORMAL DELIVERY" Or
                           dt.Rows(i).Item("CaseType") = "NEW BORN" Or
                           dt.Rows(i).Item("CaseType") = "BIOPSY" Or
                           dt.Rows(i).Item("CaseType") = "CERVICAL STICH" Or
                           dt.Rows(i).Item("CaseType") = "DNC" Or
                           dt.Rows(i).Item("CaseType") = "I&D" Or
                           dt.Rows(i).Item("CaseType") = "LAP ECTOPIC" Or
                           dt.Rows(i).Item("CaseType") = "LS" Or
                           dt.Rows(i).Item("CaseType") = "MYOMECTOMY" Or
                           dt.Rows(i).Item("CaseType") = "BABY CASE" Or
                           dt.Rows(i).Item("CaseType") = "HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "BREAST I&D" Or
                           dt.Rows(i).Item("CaseType") = "HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "THYROID" Or
                           dt.Rows(i).Item("CaseType") = "PILES" Or
                           dt.Rows(i).Item("CaseType") = "MASTECTOMY" Or
                           dt.Rows(i).Item("CaseType") = "LUMPBREAST" Or
                           dt.Rows(i).Item("CaseType") = "FISTULA" Or
                           dt.Rows(i).Item("CaseType") = "SABEACIANCYST" Or
                           dt.Rows(i).Item("CaseType") = "BREAST ABSCEES" Or
                           dt.Rows(i).Item("CaseType") = "UMB. HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "PERINAL ABSCEES" Or
                           dt.Rows(i).Item("CaseType") = "LABIAL CYST" Or
                           dt.Rows(i).Item("CaseType") = "APPENDIX" Or
                           dt.Rows(i).Item("CaseType") = "FIBROADENOMA BREAST" Or
                           dt.Rows(i).Item("CaseType") = "FISSURE" Or
                           dt.Rows(i).Item("CaseType") = "FISTULA" Or
                           dt.Rows(i).Item("CaseType") = "GS" Or
                           dt.Rows(i).Item("CaseType") = "HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "I&D" Or
                           dt.Rows(i).Item("CaseType") = "LAP.APPENDIX" Or
                           dt.Rows(i).Item("CaseType") = "LUMPBREAST" Or
                           dt.Rows(i).Item("CaseType") = "MASTECTOMY" Or
                           dt.Rows(i).Item("CaseType") = "PAPILOMA" Or
                           dt.Rows(i).Item("CaseType") = "PILES" Or
                           dt.Rows(i).Item("CaseType") = "POLYP REMOVEL" Or
                           dt.Rows(i).Item("CaseType") = "SABEACIANCYST" Or
                           dt.Rows(i).Item("CaseType") = "UMB. HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "MTP" Or
                           dt.Rows(i).Item("CaseType") = "VAGINAL HYSTRECTOMY" Then
                            MsgBox("A Bill Saved for this patient Already in this case Old Bill No is: " & dt.Rows(0).Item("BillNo"))
                            Return False
                        End If
                    Next
                ElseIf cmdEdit.Text = "&Update" Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(i).Item("CaseType") = "ABD HYS" Or
                           dt.Rows(i).Item("CaseType") = "ABH HYS" Or
                           dt.Rows(i).Item("CaseType") = "GS" Or
                           dt.Rows(i).Item("CaseType") = "DIA LAP" Or
                           dt.Rows(i).Item("CaseType") = "HYS LAP" Or
                           dt.Rows(i).Item("CaseType") = "LAP" Or
                           dt.Rows(i).Item("CaseType") = "LAP HYS" Or
                           dt.Rows(i).Item("CaseType") = "LSCS" Or
                           dt.Rows(i).Item("CaseType") = "PS" Or
                           dt.Rows(i).Item("CaseType") = "VAG HYS" Or
                           dt.Rows(i).Item("CaseType") = "NORMAL DELIVERY" Or
                           dt.Rows(i).Item("CaseType") = "NEW BORN" Or
                           dt.Rows(i).Item("CaseType") = "BIOPSY" Or
                           dt.Rows(i).Item("CaseType") = "CERVICAL STICH" Or
                           dt.Rows(i).Item("CaseType") = "DNC" Or
                           dt.Rows(i).Item("CaseType") = "I&D" Or
                           dt.Rows(i).Item("CaseType") = "LAP ECTOPIC" Or
                           dt.Rows(i).Item("CaseType") = "LS" Or
                           dt.Rows(i).Item("CaseType") = "MYOMECTOMY" Or
                           dt.Rows(i).Item("CaseType") = "BABY CASE" Or
                           dt.Rows(i).Item("CaseType") = "HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "BREAST I&D" Or
                           dt.Rows(i).Item("CaseType") = "HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "THYROID" Or
                           dt.Rows(i).Item("CaseType") = "PILES" Or
                           dt.Rows(i).Item("CaseType") = "MASTECTOMY" Or
                           dt.Rows(i).Item("CaseType") = "LUMPBREAST" Or
                           dt.Rows(i).Item("CaseType") = "FISTULA" Or
                           dt.Rows(i).Item("CaseType") = "SABEACIANCYST" Or
                           dt.Rows(i).Item("CaseType") = "BREAST ABSCEES" Or
                           dt.Rows(i).Item("CaseType") = "UMB. HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "PERINAL ABSCEES" Or
                           dt.Rows(i).Item("CaseType") = "LABIAL CYST" Or
                           dt.Rows(i).Item("CaseType") = "APPENDIX" Or
                           dt.Rows(i).Item("CaseType") = "FIBROADENOMA BREAST" Or
                           dt.Rows(i).Item("CaseType") = "FISSURE" Or
                           dt.Rows(i).Item("CaseType") = "FISTULA" Or
                           dt.Rows(i).Item("CaseType") = "GS" Or
                           dt.Rows(i).Item("CaseType") = "HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "I&D" Or
                           dt.Rows(i).Item("CaseType") = "LAP.APPENDIX" Or
                           dt.Rows(i).Item("CaseType") = "LUMPBREAST" Or
                           dt.Rows(i).Item("CaseType") = "MASTECTOMY" Or
                           dt.Rows(i).Item("CaseType") = "PAPILOMA" Or
                           dt.Rows(i).Item("CaseType") = "PILES" Or
                           dt.Rows(i).Item("CaseType") = "POLYP REMOVEL" Or
                           dt.Rows(i).Item("CaseType") = "SABEACIANCYST" Or
                           dt.Rows(i).Item("CaseType") = "UMB. HERNIA" Or
                           dt.Rows(i).Item("CaseType") = "MTP" Or
                           dt.Rows(i).Item("CaseType") = "VAGINAL HYSTRECTOMY" Then
                            MsgBox("A Bill Saved for this patient Already in this case Old Bill No is: " & dt.Rows(0).Item("BillNo"))
                            Return False
                        End If
                    Next
                End If
                Return True
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Function CheckMoney(ByVal str As String) As Boolean
        If str.Contains("$") = True Then
            Return False
        ElseIf IsNumeric(str) = True And str.IndexOf(".") < 0 Then
            Return True
            'ElseIf str.IndexOf(".") >= 0 And str.Substring(str.IndexOf(".") + 1).Length <= 2 Then
            '    Return True
        ElseIf IsNumeric(str) = False Then
            Return False
        End If
        Return True
    End Function
    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Try
            If cmdNew.Text = "&New" Then
                lblDt.Visible = False
                drpCase.Enabled = True
                'flag = True
                ClearControls()
                MakeCancel()
                cmdPaymentDue.Visible = False
                cmdNew.Image = My.Resources.Resource1.Save
                cmdEdit.Text = "&Edit"
                cmdEdit.Image = My.Resources.Resource1.Edit
                cmdNew.Text = "&Save"
                drpDrName.Focus()
                CheckFlag = True
                txtBillNo.ReadOnly = True
                'CheckMe()
                DispLastBill()
                chkCashlessBill.Checked = False
            Else
                Dim DueAmount, Balance, AmountReturned As Double
                Dim CreditStatus As String
                If chkCashlessBill.Checked = False Then
                    DueAmount = InputBox("Enter the amount received", "Due", lblGrandTotal.Text)
                Else
                    DueAmount = lblGrandTotal.Text
                End If
                AmountReturned = Nothing
                If (DueAmount - CDbl(lblGrandTotal.Text) > 0) And chkCashlessBill.Checked = False Then
                    AmountReturned = InputBox("Enter the amount returned", "Returned", Math.Round(DueAmount - CDbl(lblGrandTotal.Text), 2))
                    CreditStatus = "D"
                ElseIf DueAmount = CDbl(lblGrandTotal.Text) Then
                    CreditStatus = "P"
                Else
                    CreditStatus = "C"
                End If
                If CheckMoney(DueAmount) = False Then
                    MsgBox("Please Enter Valid amount for Amount Received", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                If CheckMoney(AmountReturned) = False And AmountReturned <> Nothing Then
                    MsgBox("Please Enter Valid amount for Amount Returned", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf AmountReturned > DueAmount - CDbl(lblGrandTotal.Text) And AmountReturned <> Nothing Then
                    MsgBox("Return amount cannot be greater than : " & (DueAmount - CDbl(lblGrandTotal.Text)), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                If ValidateBill() = False Then
                    Exit Sub
                End If
                If drpCase.Text <> "OP" And chkCashlessBill.Checked = False Then
                    Dim daC As New SqlDataAdapter("Select * from DrugSlipDetails where PatientId='" & txtPatientID.Text & "' and Cash='Y'", con)
                    Dim dsC As New DataSet
                    daC.Fill(dsC)
                    If dsC.Tables(0).Rows.Count > 0 Then
                        Dim diars As DialogResult
                        diars = MsgBox("This patient has a cashless Bill already? do you want to make this bill too cashless bill?", MsgBoxStyle.YesNo, "Cashless Bill")
                        If diars = Windows.Forms.DialogResult.Yes Then
                            chkCashlessBill.Checked = True
                        ElseIf diars = Windows.Forms.DialogResult.No Then
                            chkCashlessBill.Checked = False
                        End If
                    End If
                End If
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Try
                    'CheckConnection()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    Dim BillNo As Decimal
                    cmd.CommandText = "Select MAX(BillNo) from DrugSlipDetails where YEAR(BillDate)='" & System.DateTime.Now.Year & "'"
                    If IsDBNull(cmd.ExecuteScalar) Then
                        BillNo = 1
                    Else
                        BillNo = cmd.ExecuteScalar
                        BillNo = BillNo + 1
                    End If
                    Dim cash As String
                    If chkCashlessBill.Checked = True Then
                        cash = "Y"
                    Else
                        cash = "N"
                    End If
                    txtBillNo.Text = BillNo
                    Dim md As New System.DateTime
                    md = System.DateTime.Now
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        Dim cqty As Integer
                        Dim drd As SqlDataReader
                        cmd.CommandText = "Select CurrentQty from StockDetails where ProductName='" & drpProductName.Text & "' and InvoiceNo=" & drpInvoiceNo.Text.Substring(0, drpInvoiceNo.Text.IndexOf("-")) & " and YEAR(InvoiceDateTime)='" & drpInvoiceNo.Text.Substring(drpInvoiceNo.Text.IndexOf("-") + 1) & "' and BatchNo='" & txtBatch.Text & "'"
                        drd = cmd.ExecuteReader()
                        If drd.HasRows = True Then
                            drd.Read()
                        End If
                        cqty = drd(0)
                        drd.Close()
                        If cqty <= 0 Then
                            tranc.Rollback()
                            MsgBox("The bill is not saved, because the product " & DataGridView1.Rows(i).Cells(1).Value & " has 0 Qty", MsgBoxStyle.Exclamation, "Warning")
                            Exit Sub
                        End If
                        ' cmd.CommandText = "insert into DrugSlipDetails values(" & txtBillNo.Text & ",'" & md.ToShortDateString & "','" & drpDrName.Text & "','" & txtPatientID.Text & "','" & txtPatientName.Text & "','" & drpCase.Text & "'," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ",'" & DataGridView1.Rows(i).Cells(3).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "'," & DataGridView1.Rows(i).Cells(5).Value & "," & DataGridView1.Rows(i).Cells(6).Value & ",'" & DataGridView1.Rows(i).Cells(7).Value & "'," & DataGridView1.Rows(i).Cells(8).Value & ",'P','" & md & "',Null,'" & cash & "','" & CreditStatus & "','" & dtpIncidentDate.Text & "',Null,'" & UserName & "')"
                        cmd.CommandText = "insert into DrugSlipDetails values(" & txtBillNo.Text & ",'" & md.ToShortDateString & "','" & drpDrName.Text & "','" & txtPatientID.Text & "','" & txtPatientName.Text & "','" & drpCase.Text & "'," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ",'" & DataGridView1.Rows(i).Cells(3).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "'," & DataGridView1.Rows(i).Cells(5).Value & "," & DataGridView1.Rows(i).Cells(6).Value & ",'" & DataGridView1.Rows(i).Cells(7).Value & "'," & DataGridView1.Rows(i).Cells(8).Value & ",'P','" & md & "',Null,'" & cash & "','" & CreditStatus & "','" & dtpIncidentDate.Text & "',Null,'" & UserName & "'," & Val(DataGridView1.Rows(i).Cells(8).Value) & ",'N',0," & Val(DataGridView1.Rows(i).Cells(6).Value) & " )"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "update StockDetails  set CurrentQty=CurrentQty-" & DataGridView1.Rows(i).Cells(2).Value & " where InvoiceNo=" & DataGridView1.Rows(i).Cells(7).Value.Substring(0, DataGridView1.Rows(i).Cells(7).Value.IndexOf("-")) & " and YEAR(InvoiceDateTime)='" & DataGridView1.Rows(i).Cells(7).Value.Substring(DataGridView1.Rows(i).Cells(7).Value.IndexOf("-") + 1) & "' and ProductName='" & DataGridView1.Rows(i).Cells(1).Value & "' and BatchNo='" & DataGridView1.Rows(i).Cells(3).Value & "'"
                        cmd.ExecuteNonQuery()
                    Next
                    If CDbl(lblGrandTotal.Text) > DueAmount Then
                        Balance = CDbl(lblGrandTotal.Text) - DueAmount
                        cmd.CommandText = "insert into PaymentDue values(" & txtBillNo.Text & ",'" & md.ToShortDateString & "'," & lblGrandTotal.Text & ",1,'" & md & "'," & DueAmount & ",0," & Balance & ",'CT','P','" & UserName & "')"
                        cmd.ExecuteNonQuery()
                    ElseIf CDbl(lblGrandTotal.Text) < DueAmount And AmountReturned = 0 Then
                        Balance = DueAmount - CDbl(lblGrandTotal.Text)
                        cmd.CommandText = "insert into PaymentDue values(" & txtBillNo.Text & ",'" & md.ToShortDateString & "'," & lblGrandTotal.Text & ",1,'" & md & "'," & AmountReturned & "," & DueAmount & "," & Balance & ",'AT','P','" & UserName & "')"
                        cmd.ExecuteNonQuery()
                    ElseIf Not (AmountReturned = Nothing) And (DueAmount - CDbl(lblGrandTotal.Text) - AmountReturned) = 0 Then
                        Balance = DueAmount - CDbl(lblGrandTotal.Text) - AmountReturned
                        cmd.CommandText = "insert into PaymentDue values(" & txtBillNo.Text & ",'" & md.ToShortDateString & "'," & lblGrandTotal.Text & ",1,'" & md & "'," & AmountReturned & "," & DueAmount & "," & Balance & ",'AR','P','" & UserName & "')"
                        cmd.ExecuteNonQuery()
                    Else
                        cmd.CommandText = "insert into PaymentDue values(" & txtBillNo.Text & ",'" & md.ToShortDateString & "'," & lblGrandTotal.Text & ",1,'" & md & "'," & lblGrandTotal.Text & ",0,0,'FP','P','" & UserName & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    crysBillNo = txtBillNo.Text
                    crysBillYear = CDate(UserControl11.lblDateTime.Text).Year
                    BillDate = md.ToShortDateString
                    tranc.Commit()
                    con.Close()
                    drpCase.Enabled = True
                    cmdNew.Text = "&New"
                    cmdNew.Image = My.Resources.Resource1._New
                    MsgBox("Bill Details Saved Successfully", MsgBoxStyle.Information, Me.Text)
                    MakeShow()
                    'ClearControls()
                    CheckFlag = False
                    'CheckMe()
                    txtBillNo.ReadOnly = False
                    'DrugPrint.Show()
                    'CrystalBillPrint.Show()
                    NewPrint()
                Catch ex As Exception
                    tranc.Rollback()
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                'flag = False
            End If
            OldBillNo = Nothing
            DispLastBill()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub drpInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpInvoiceNo.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpInvoiceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpInvoiceNo.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim arr1 As New ArrayList
        dt1 = SelectQuery("Select BatchNo from StockDetails where ProductName='" & drpProductName.Text & "' and InvoiceNo=" & drpInvoiceNo.Text.Substring(0, drpInvoiceNo.Text.IndexOf("-")) & " and Year(InvoiceDateTime)='" & drpInvoiceNo.Text.Substring(drpInvoiceNo.Text.IndexOf("-") + 1) & "' and CurrentQty>0 and ExpDate>'" & System.DateTime.Now & "'")
        For i As Integer = 0 To dt1.Rows.Count - 1
            arr1.Add(dt1.Rows(i).Item("BatchNo").ToString)
        Next
        txtBatch.DataSource = arr1
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If cmdEdit.Text = "&Edit" Then
                chkCashlessBill.Checked = False
                cmdNew.Text = "&New"
                cmdPaymentDue.Visible = False
                cmdNew.Image = My.Resources.Resource1._New
                If txtBillNo.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtBillNo, "Enter DrugSlipNo")
                    txtBillNo.Focus()
                    Exit Sub
                Else
                    ErrorProvider1.SetError(txtBatch, "")
                    BillYear = InputBox("Please Enter the Year Of the DrugSlip Saved", "Enter YEAR")
                End If
                'flag = True
                'MakeCancel()
                DisplayBillDetails()
                If OldBillNo = Nothing Or BillYear = Nothing Then
                    Exit Sub
                End If
                'If BillDate.Date <> System.DateTime.Now.Date And UserRights <> "Admin" Then
                '    MsgBox("Sorry You cannot Edit the Bill, Contact your Administrator", MsgBoxStyle.Exclamation, Me.Text)
                '    Exit Sub
                'End If
                cmdEdit.Text = "&Update"
                cmdEdit.Image = My.Resources.Resource1.Update
                CheckFlag = True
                lblDt.Visible = True
                txtBillNo.ReadOnly = True
                drpDrName.Focus()
                'CheckMe()
            Else
                'flag = False
                If ValidateBill() = False Then
                    Exit Sub
                End If
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.Transaction = tranc
                Try
                    Dim cash As String
                    If chkCashlessBill.Checked = True Then
                        cash = "Y"
                    Else
                        cash = "N"
                    End If
                    If Cashless = "Y" And cash = "N" Then
                        Dim ts As TimeSpan
                        ts = System.DateTime.Now.Date.Subtract(BillDate.Date)
                        If (System.DateTime.Now.Date = BillDate.Date Or ts.TotalDays = 1) And UserName.ToString.ToUpper = "PHARMACIST" Then
                            cmd.CommandText = "delete from paymentDue where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "insert into paymentdue values(" & OldBillNo & ",'" & BillDate & "'," & lblGrandTotal.Text & ",1,'" & lblDt.Text & "',0,0," & lblGrandTotal.Text & ",'CT','P','" & UserName & "')"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "update drugslipdetails set cash='N' where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            cmd.ExecuteNonQuery()

                        ElseIf (BillDate.Date <> System.DateTime.Now.Date Or BillDate.Date = System.DateTime.Now.Date) And UserRights = "Admin" Then
                            cmd.CommandText = "delete from paymentDue where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "insert into paymentdue values(" & OldBillNo & ",'" & BillDate & "'," & lblGrandTotal.Text & ",1,'" & lblDt.Text & "',0,0," & lblGrandTotal.Text & ",'CT','P','" & UserName & "')"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "update drugslipdetails set cash='N' where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            cmd.ExecuteNonQuery()
                        Else
                            MsgBox("Sorry you cannot change cashless status for this bill, DrugSlip cannot be updated", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    ElseIf Cashless = "N" And cash = "Y" Then
                        If UserRights = "Admin" Then
                            cmd.CommandText = "delete from paymentDue where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "insert into paymentdue values(" & OldBillNo & ",'" & BillDate & "'," & lblGrandTotal.Text & ",1,'" & lblDt.Text & "'," & lblGrandTotal.Text & ",0,0,'FP','P','" & UserName & "')"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "update drugslipdetails set cash='Y' where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            cmd.ExecuteNonQuery()
                            'ElseIf UserRights = "User" And System.DateTime.Now.Date = BillDate.Date Then
                            '    Dim dr As SqlDataReader
                            '    cmd.CommandText = "Select DueStatus from PaymentDue where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "' and DueNo=1"
                            '    dr = cmd.ExecuteReader
                            '    If dr.HasRows = True Then
                            '        dr.Read()
                            '        If dr("DueStatus") = "AT" Then
                            '            dr.Close()
                            '            MsgBox("This bill is Amount to be returned, so you cannot made this bill as  Cashless")
                            '            Exit Sub
                            '        ElseIf dr("DueStatus") = "CT" Then
                            '            dr.Close()
                            '            Dim sumAmt As Integer
                            '            cmd.CommandText = "Select isnull(SUM(DueAmount),0) from PaymentDue where BillNo=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            '            sumAmt = cmd.ExecuteScalar
                            '            If sumAmt = 0 Then
                            '                cmd.CommandText = "delete from paymentDue where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            '                cmd.ExecuteNonQuery()
                            '                cmd.CommandText = "insert into paymentdue values(" & OldBillNo & ",'" & BillDate & "'," & lblGrandTotal.Text & ",1,'" & lblDt.Text & "'," & lblGrandTotal.Text & ",0,0,'FP','P')"
                            '                cmd.ExecuteNonQuery()
                            '                cmd.CommandText = "update drugslipdetails set cash='Y' where billno=" & OldBillNo & " and Year(BillDate)='" & BillDate.Year & "'"
                            '                cmd.ExecuteNonQuery()
                            '            Else
                            '                MsgBox("Sorry you cannot change Cashless status of this bill, it may have more than one Payment transaction or may have Amount received greater than zero")
                            '                Exit Sub
                            '            End If

                            '        End If
                            '    Else
                            '        MsgBox("Problem in this bill contact  your administrator")
                            '    End If
                        Else
                            MsgBox("Sorry you cannot change cashless status for this bill, DrugSlip cannot be updated", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    End If

            If UserName.ToString.ToUpper = "PHARMACIST" Then
                Dim ts As TimeSpan
                ts = System.DateTime.Now.Date.Subtract(BillDate.Date)
                If CInt(ts.TotalDays) > 1 Or CInt(ts.TotalDays) < 0 Then
                    MsgBox("Sorry You cannot Edit Bill, Contact your Administrator", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                cmd.CommandText = "Update DrugSlipDetails set PatientID='" & txtPatientID.Text & "',PatientName='" & txtPatientName.Text & "',DrName='" & drpDrName.Text & "',CaseType='" & drpCase.Text & "',Cash='" & cash & "',IncidentDate='" & dtpIncidentDate.Text & "'  Where BillNo=" & txtBillNo.Text & " and Year(BillDate)='" & BillYear & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Bill Details Updated Successfully", MsgBoxStyle.Information, "Data Updated")
            ElseIf (BillDate.Date <> System.DateTime.Now.Date Or BillDate.Date = System.DateTime.Now.Date) And UserRights = "Admin" Then
                cmd.CommandText = "Update DrugSlipDetails set PatientID='" & txtPatientID.Text & "',PatientName='" & txtPatientName.Text & "',DrName='" & drpDrName.Text & "',CaseType='" & drpCase.Text & "',Cash='" & cash & "',IncidentDate='" & dtpIncidentDate.Text & "' Where BillNo=" & txtBillNo.Text & " and Year(BillDate)='" & BillYear & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Bill Details Updated Successfully", MsgBoxStyle.Information, "Data Updated")
            Else
                cmd.CommandText = "Update DrugSlipDetails set IncidentDate='" & dtpIncidentDate.Text & "' Where BillNo=" & txtBillNo.Text & " and Year(BillDate)='" & BillYear & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Bill Details Updated Successfully (Date of incident only updated)", MsgBoxStyle.Information, "Data Updated")
            End If
            lblDt.Visible = False
            tranc.Commit()
            con.Close()
            OldBillNo = Nothing
            cmdEdit.Text = "&Edit"
            cmdEdit.Image = My.Resources.Resource1.Edit
            MakeShow()
            CheckFlag = False
            txtBillNo.ReadOnly = False
        Catch ex As Exception
            tranc.Rollback()
            con.Close()
            MsgBox(ex.Message)
        End Try
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub DisplayBillDetails()
        Try
            Dim dt As DataTable
            Dim cash As String
            CheckConnection()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.CommandText = "Select * from DrugSlipDetails where BillNo=" & txtBillNo.Text & " and Year(BillDate)='" & BillYear & "' order by SNo"
            cmd.Connection = con
            ClearControls()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                OldBillNo = dr("BillNo")
                BillYear = CStr(CDate(dr("BillDate")).Year)
                BillDate = dr("BillDate")
                txtBillNo.Text = dr("BillNo")
                crysBillNo = dr("BillNo")
                crysBillYear = CDate(dr("BillDate")).Year
                drpDrName.Text = dr("DrName")
                txtPatientID.Text = dr("PatientID")
                txtPatientName.Text = dr("PatientName")
                drpCase.Text = dr("CaseType")
                cash = dr("Cash").ToString
                Cashless = dr("Cash").ToString
                dtpIncidentDate.Text = dr("IncidentDate").ToString
                lblDt.Text = dr("BillDateTime").ToString
                If cash = "N" Then
                    chkCashlessBill.Checked = False
                ElseIf cash = "Y" Then
                    chkCashlessBill.Checked = True
                End If
                MakeCancel()
                dr.Close()
                dt = SelectQuery("Select * from DrugSlipDetails where BillNo=" & txtBillNo.Text & " and YEAR(BillDate)='" & BillYear & "' order by SNo")
                For i As Integer = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Insert(DataGridView1.Rows.Count, dt.Rows(i).Item("SNo"), dt.Rows(i).Item("ProductName"), dt.Rows(i).Item("Qty"), dt.Rows(i).Item("BatchNo"), dt.Rows(i).Item("ExpDate"), dt.Rows(i).Item("VAT"), dt.Rows(i).Item("MRP"), dt.Rows(i).Item("InvoiceNo"), dt.Rows(i).Item("Total"))
                Next
                CalcGrandTotal()
                cmdPaymentDue.Visible = True
                txtBillNo.Enabled = False
            Else
                OldBillNo = Nothing
                MsgBox("Drug Slip Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
                ClearControls()
                txtBillNo.Focus()
                MakeShow()
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Dim da As New SqlDataAdapter("Select * from StockDetails where ProductName='" & drpProductName.Text & "' and Year(InvoiceDateTime)='" & drpInvoiceNo.Text.Substring(drpInvoiceNo.Text.IndexOf("-") + 1) & "' and InvoiceNo=" & drpInvoiceNo.Text.Substring(0, drpInvoiceNo.Text.IndexOf("-")) & " and BatchNo='" & txtBatch.Text & "' and CurrentQty>0", con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Please Select the product again", MsgBoxStyle.Information)
            Exit Sub
        End If

        If drpInvoiceNo.Text.Length = 0 Then
            MsgBox("No Stock in this product", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        ElseIf Val(txtQty.Text) > Val(txtCurrentStockQty.Text) Or Val(txtQty.Text) = 0 Then
            MsgBox("Please Enter Valid Qty", MsgBoxStyle.Exclamation, Me.Text)
            txtQty.Text = ""
            txtQty.Focus()
            Exit Sub
        End If

        Dim total As Double
        total = Val(txtQty.Text) * Val(txtMRP.Text)
        'DataGridView1.Rows.Insert(0, Val(DataGridView1.Rows.Count + 1), drpProductName.Text, txtQty.Text, txtBatch.Text, txtExpDate.Text, txtVat.Text, txtMRP.Text, txtHSR.Text, total)
        DataGridView1.Rows.Insert(DataGridView1.Rows.Count, Val(DataGridView1.Rows.Count + 1), drpProductName.Text, txtQty.Text, txtBatch.Text, txtExpDate.Text, txtVat.Text, txtMRP.Text, drpInvoiceNo.Text, total)
        CalcGrandTotal()
        drpProductName.Focus()
        Dim i As Integer
        For i = DataGridView1.Rows.Count - 1 To 0 Step -1
            If DataGridView1.Rows(i).Cells(1).Value = drpProductName.Text And DataGridView1.Rows(i).Cells(7).Value = drpInvoiceNo.Text Then
                txtCurrentStockQty.Text = Val(txtCurrentStockQty.Text) - Val(DataGridView1.Rows(i).Cells(2).Value)
            End If
            Exit For
        Next
        txtQty.Text = ""
        DataGridView1.CurrentCell = DataGridView1.Item(1, DataGridView1.Rows.Count - 1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindPatienID.Show()
    End Sub
    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        Dim dt As New DataTable
        If drpInvoiceNo.Text.Length > 0 Then
            dt = SelectQuery("Select CurrentQty from StockDetails where ProductName='" & drpProductName.Text & "' and InvoiceNo=" & drpInvoiceNo.Text.Substring(0, drpInvoiceNo.Text.IndexOf("-")))
            If dt.Rows.Count > 0 Then
                txtCurrentStockQty.Text = dt.Rows(0).Item("CurrentQty")
                Dim i As Integer
                For i = DataGridView1.Rows.Count - 1 To 0 Step -1
                    If DataGridView1.Rows(i).Cells(1).Value = drpProductName.Text And DataGridView1.Rows(i).Cells(7).Value = drpInvoiceNo.Text And DataGridView1.Rows(i).Cells(7).Value = txtBatch.Text Then
                        txtCurrentStockQty.Text = Val(txtCurrentStockQty.Text) - Val(DataGridView1.Rows(i).Cells(2).Value)
                    End If
                Next
            End If
        End If
        Dim j As String = DataGridView1.RowCount.ToString
        For i As Integer = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).Cells(0).Value = (i + 1)
        Next
        CalcCurrentQty()
        CalcGrandTotal()
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Try
            If cmdShow.Text = "&Cancel" Then
                'flag = False
                Cancel()
                MakeShow()
                ClearControls()
                cmdNew.Focus()
                OldBillNo = Nothing
                CheckFlag = False
                lblDt.Visible = False
                txtBillNo.Enabled = True
                'CheckMe()
            Else
                If txtBillNo.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtBillNo, "Enter InvoiceNo")
                    Exit Sub
                Else
                    ErrorProvider1.SetError(txtBillNo, "")
                End If
                BillYear = InputBox("Please Enter the Year Of the DrugSlip Saved", "Enter YEAR")
                'flag = True
                DisplayBillDetails()
                lblDt.Visible = True
                CheckFlag = True
                'CheckMe()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdCancellBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancellBill.Click
        Try
            If cmdShow.Text = "&Cancel" And cmdNew.Text = "&New" And cmdEdit.Text = "&Edit" And OldBillNo <> Nothing Then
                Dim count As Integer
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Try
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    cmd.CommandText = "Select count(*) from DrugSlipDetails where Status='C' and BillNo=" & txtBillNo.Text & " and Year(BillDate)='" & BillYear & "'"
                    count = cmd.ExecuteScalar
                    If count = 0 Then
                        cmd.CommandText = "Select count(*) from DrugSlipDetails where BillNo=" & txtBillNo.Text & " and Year(BillDate)='" & BillYear & "'"
                        count = cmd.ExecuteScalar
                        If BillDate <> System.DateTime.Now.ToShortDateString And UserRights = "User" Then
                            MsgBox("Sorry you cannot cancel this bill Contact your administrator", MsgBoxStyle.Exclamation, "Cannot Cancel")
                            Exit Sub
                        End If
                        If count > 0 Then
                            Dim ds As New DialogResult
                            ds = MsgBox("Are You Sure to Cancel This Bill", MsgBoxStyle.YesNo, "Cancel Bill")
                            If ds = Windows.Forms.DialogResult.Yes Then
                                cmd.CommandText = "update DrugSlipDetails set Status='C',CancelDate='" & System.DateTime.Now & "' where BillNo='" & txtBillNo.Text & "' and YEAR(BillDate)='" & BillYear & "'"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "Update PaymentDue set BillStatus='C' where BillNo='" & txtBillNo.Text & "' and YEAR(BillDate)='" & BillYear & "'"
                                cmd.ExecuteNonQuery()
                                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                                    cmd.CommandText = "Update StockDetails set CurrentQty=CurrentQty+" & DataGridView1.Rows(i).Cells(2).Value & " where ProductName='" & DataGridView1.Rows(i).Cells(1).Value & "' and InvoiceNo=" & DataGridView1.Rows(i).Cells(7).Value.Substring(0, DataGridView1.Rows(i).Cells(7).Value.IndexOf("-")) & " and YEAR(InvoiceDateTime)='" & DataGridView1.Rows(i).Cells(7).Value.Substring(DataGridView1.Rows(i).Cells(7).Value.IndexOf("-") + 1) & "' and BatchNo='" & DataGridView1.Rows(i).Cells(3).Value & "'"
                                    cmd.ExecuteNonQuery()
                                Next
                                tranc.Commit()
                                con.Close()
                                MakeShow()
                                MsgBox("This Bill Cancelled Successfully", MsgBoxStyle.Information, Me.Text)
                            End If
                        Else
                            MsgBox("Cannot find Bill", MsgBoxStyle.Exclamation, Me.Text)
                        End If
                    Else
                        con.Close()
                        MsgBox("This Bill was already Cancelled", MsgBoxStyle.Exclamation, Me.Text)
                    End If
                    con.Close()
                Catch ex As Exception
                    tranc.Rollback()
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cmdNew.Text = "&New" And cmdEdit.Text = "&Edit" And cmdShow.Text = "&Cancel" Then
            'DrugPrint.Show()
            NewPrint()
            'CrystalBillPrint.Show()

            'Dim c As New CrystalReport1
            'Dim dt As New DataTable
            'dt = SelectQuery("")
            'Me.crystalReport11.FileName = "CrystalReport1"
            'me.crystalReport11.PrintOptions.
            'Me.crystalReport11.PrintToPrinter(1, False, 1, 1)
        End If
    End Sub

    Private Sub drpProductName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles drpProductName.Validating
        If drpProductName.FindStringExact(drpProductName.Text) < 0 Then
            ErrorProvider1.SetError(drpProductName, "Please Select Product Name")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(drpProductName, "")
        End If
    End Sub

    Private Sub drpDrName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpDrName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpCase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpCase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpCase_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles drpCase.Validating
        If drpCase.FindStringExact(drpCase.Text) < 0 Then
            ErrorProvider1.SetError(drpCase, "Please Select Valid Case")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(drpCase, "")
        End If
    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtBatch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBatch.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBatch.SelectedIndexChanged
        Dim dt As New DataTable
        If drpInvoiceNo.Text.Length > 0 Then
                dt = SelectQuery("Select CurrentQty from StockDetails where ProductName='" & drpProductName.Text & "' and InvoiceNo=" & drpInvoiceNo.Text.Substring(0, drpInvoiceNo.Text.IndexOf("-")) & " and YEAR(InvoiceDateTime)='" & drpInvoiceNo.Text.Substring(drpInvoiceNo.Text.IndexOf("-") + 1) & "' and BatchNo='" & txtBatch.Text & "'")
            txtCurrentStockQty.Text = dt.Rows(0).Item("CurrentQty")
            dt.Clear()
            dt = SelectQuery("Select * from InvoiceDetails where InvoiceNo=" & drpInvoiceNo.Text.Substring(0, drpInvoiceNo.Text.IndexOf("-")) & " and YEAR(InvoiceDateTime)='" & drpInvoiceNo.Text.Substring(drpInvoiceNo.Text.IndexOf("-") + 1) & "' and  ProductName='" & drpProductName.Text & "' and BatchNo='" & txtBatch.Text & "'")
            'txtBatch.Text = dt.Rows(0).Item("BatchNo")
            txtExpDate.Text = dt.Rows(0).Item("ExpDate")
            txtVat.Text = dt.Rows(0).Item("VAT")
            txtDoctorWhoPurchased.Text = dt.Rows(0).Item("DoctorName")
            txtMRP.Text = dt.Rows(0).Item("MRP")
            dt.Clear()
            dt = SelectQuery("Select RackNo from ProductMaster where ProductName='" & drpProductName.Text & "'")
            txtRackNo.Text = dt.Rows(0).Item("RackNo")
            CalcCurrentQty()
        End If
    End Sub
    Sub CalcCurrentQty()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(1).Value = drpProductName.Text And DataGridView1.Rows(i).Cells(7).Value = drpInvoiceNo.Text And DataGridView1.Rows(i).Cells(3).Value = txtBatch.Text Then
                txtCurrentStockQty.Text = Val(txtCurrentStockQty.Text) - Val(DataGridView1.Rows(i).Cells(2).Value)
            End If
        Next
    End Sub
    Private Sub chkCashlessBill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkCashlessBill.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdPaymentDue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPaymentDue.Click
        If cmdShow.Text = "&Cancel" And cmdNew.Text = "&New" And cmdEdit.Text = "&Edit" Then
            frmPaymentDue.ShowDialog()
        End If
    End Sub
    Sub NewPrint()
        If PrinterName <> "" Then
            Dim pdv As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim pv As New CrystalDecisions.Shared.ParameterValues
            Dim cryRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            cryRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
            cryRpt.Load(System.IO.Directory.GetCurrentDirectory & "\CrystalReport2.rpt")
            'cryRpt.Load("E:\Joe Samraj\MyProject\Medical Store 13-10-2010\Medical Store\Pharmacy\Pharmacy\CrystalReport1.rpt")
            pdv.Value = crysBillNo
            pv.Add(pdv)
            cryRpt.DataDefinition.ParameterFields("BillNo").ApplyCurrentValues(pv)
            pdv.Value = BillDate
            pv.Add(pdv)
            cryRpt.DataDefinition.ParameterFields("BillDate").ApplyCurrentValues(pv)
            'cryRpt.PrintToPrinter(1, True, 0, cryRpt.FormatEngine.GetLastPageNumber(New CrystalDecisions.Shared.ReportPageRequestContext))
            cryRpt.PrintToPrinter(1, True, 0, 0)
            Dim cmd As New SqlClient.SqlCommand("Update drugSlipDetails set LastPrint='" & System.DateTime.Now & "' where BillNo=" & crysBillNo & " and Year(BillDate)='" & crysBillYear & "'", con)
            CheckConnection()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            MsgBox("Cannot find printer name please contact your administrator", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dtpIncidentDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpIncidentDate.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdCombination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCombination.Click
        ShowCombination()
    End Sub
    Sub ShowCombination()
        Dim da As New SqlDataAdapter("Select * from productmaster where productname='" & drpProductName.Text & "' and CombinationName<>'N/A'", con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            frmCombinationFinder.Show()
            frmCombinationFinder.drpCombinationName.Text = ds.Tables(0).Rows(0).Item("CombinationName").ToString
        Else
            MsgBox("No Combination found")
        End If
    End Sub
End Class