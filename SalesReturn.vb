Imports System.Data.SqlClient
Public Class SalesReturn
    Dim cash As String
    Dim SalesBillNo, SalesBillYear As String
    Dim SalesBillDate As System.DateTime
    Sub MakeCancel()
        cmdShow.Text = "&Cancel"
        cmdShow.Image = My.Resources.Resource1.Cancel
    End Sub
    Sub Cancel()
        txtInvoiceNo.ReadOnly = False
        cmdShow.Text = "&Show"
        cmdShow.Image = My.Resources.Resource1.Search
        ErrorProvider1.Clear()
    End Sub
    Sub MakeShow()
        cmdShow.Text = "&Show"
        cmdShow.Image = My.Resources.Resource1.Search
    End Sub
    Sub CalcGrandTotal()
        Dim Total As Double
        Total = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Total = Total + Val(DataGridView1.Rows(i).Cells(9).Value)
        Next
        lblGrandTotal.Text = Total
    End Sub
    Sub CalcReturnGrandTotal()
        Dim Total As Double
        Total = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Total = Total + Val(DataGridView1.Rows(i).Cells(10).Value)
        Next
        lblReturnGrandTotal.Text = Total
    End Sub
    Sub ClearControls()
        txtSalesBillNo.Text = ""
        txtBillDate.Text = ""
        txtReturnBillNo.Text = ""
        txtDrName.Text = ""
        txtPatientID.Text = ""
        txtPatientName.Text = ""
        txtCase.Text = ""
        DataGridView1.Rows.Clear()
        txtInvoiceNo.Text = ""
        txtQty.Text = ""
        txtReturnQty.Text = ""
        txtRackNo.Text = ""
        txtBatch.Text = ""
        txtVat.Text = ""
        txtMRP.Text = ""
        lblGrandTotal.Text = ""
        ErrorProvider1.Clear()
    End Sub
    Sub DisplayBillDetails()
        Try
            Dim dt As DataTable
            CheckConnection()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.CommandText = "Select * from DrugSlipDetails where BillNo=" & txtSalesBillNo.Text & " and Year(BillDate)='" & SalesBillYear & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                txtSalesBillNo.Text = dr("BillNo")
                SalesBillNo = dr("BillNo")
                txtBillDate.Text = dr("BillDate")
                SalesBillDate = dr("BillDate")
                txtDrName.Text = dr("DrName")
                txtPatientID.Text = dr("PatientID")
                txtPatientName.Text = dr("PatientName")
                txtCase.Text = dr("CaseType")
                DataGridView1.Rows.Clear()
                MakeCancel()
                dr.Close()
                dt = SelectQuery("Select * from DrugSlipDetails where BillNo=" & txtSalesBillNo.Text & " and YEAR(BillDate)='" & SalesBillYear & "' order by SNo")
                drpProductName.DisplayMember = "ProductName"
                drpProductName.DataSource = dt.DefaultView
                For i As Integer = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Insert(DataGridView1.Rows.Count, dt.Rows(i).Item("SNo"), dt.Rows(i).Item("ProductName"), dt.Rows(i).Item("Qty"), "0", dt.Rows(i).Item("BatchNo"), CDate(dt.Rows(i).Item("ExpDate")).Date.ToShortDateString, dt.Rows(i).Item("VAT"), dt.Rows(i).Item("MRP"), dt.Rows(i).Item("InvoiceNo"), dt.Rows(i).Item("Total"), "0")
                Next
                CalcGrandTotal()
                txtSalesBillNo.ReadOnly = True
                txtReturnBillNo.ReadOnly = True
            Else
                MsgBox("Bill Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
                ClearControls()
                txtInvoiceNo.Focus()
                MakeShow()
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        ShowProcess()
    End Sub

    Private Sub SalesReturn_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtSalesBillNo.Focus()
    End Sub
    Private Sub drpProductName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProductName.SelectedIndexChanged
        Dim dt As New DataTable
        dt = SelectQuery("Select RackNo from ProductMaster where ProductName='" & drpProductName.Text & "'")
        If dt.Rows.Count > 0 Then
            txtRackNo.Text = dt.Rows(0).Item("RackNo")
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        drpProductName.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value
        txtQty.Text = DataGridView1.SelectedRows.Item(0).Cells(2).Value
        txtBatch.Text = DataGridView1.SelectedRows.Item(0).Cells(4).Value
        txtExpDate.Text = DataGridView1.SelectedRows.Item(0).Cells(5).Value
        txtVat.Text = DataGridView1.SelectedRows.Item(0).Cells(6).Value
        txtMRP.Text = DataGridView1.SelectedRows.Item(0).Cells(7).Value
        txtInvoiceNo.Text = DataGridView1.SelectedRows.Item(0).Cells(8).Value
        txtReturnQty.Text = ""
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If drpProductName.Text <> DataGridView1.SelectedRows.Item(0).Cells(1).Value Then
            MsgBox("Please Select Correct Product", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        ElseIf Val(txtQty.Text) >= Val(txtReturnQty.Text) And txtReturnQty.Text <> "" Then
            DataGridView1.SelectedRows.Item(0).Cells(3).Value = txtReturnQty.Text
            DataGridView1.SelectedRows.Item(0).Cells(10).Value = Val(txtReturnQty.Text) * Val(txtMRP.Text)
            CalcReturnGrandTotal()
        Else
            MsgBox("Please Enter a Valid Qty", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        CalcReturnGrandTotal()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub txtSalesBillNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSalesBillNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            ShowProcess()
        End If
    End Sub

    Private Sub txtSalesBillNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesBillNo.TextChanged

    End Sub
    Sub ShowProcess()
        Try
            If cmdShow.Text = "&Cancel" Then
                'flag = False
                Cancel()
                MakeShow()
                ClearControls()
                drpProductName.Focus()
                'OldInvoiceNo = Nothing
                'CheckFlag = False
                'CheckMe()
                txtSalesBillNo.ReadOnly = False
                txtReturnBillNo.ReadOnly = False
            Else
                If txtSalesBillNo.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtSalesBillNo, "Enter InvoiceNo")
                    Exit Sub
                Else
                    SalesBillYear = InputBox("Please Enter the Year Of the Invoice Saved", "Enter YEAR")
                    ErrorProvider1.SetError(txtSalesBillNo, "")
                    Dim dt As DataTable
                    dt = SelectQuery("Select * from SalesReturnDetails where SalesBillNo=" & txtSalesBillNo.Text & " and YEAR(SalesBillDate)='" & SalesBillYear & "'")
                    If dt.Rows.Count > 0 Then
                        MsgBox("Some products return already from this Drug Slip, Return SlipNo= " & dt.Rows(0).Item("ReturnBillNo"), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                    dt = SelectQuery("Select * from DrugSlipDetails where BillNo=" & txtSalesBillNo.Text & " and Year(BillDate)='" & SalesBillYear & "' and Status='C'")
                    If dt.Rows.Count > 0 Then
                        MsgBox("This Bill Cancelled So you Cannot Return Bill", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                    cash = "N"
                    dt = SelectQuery("Select * from DrugSlipDetails where BillNo=" & txtSalesBillNo.Text & " and Year(BillDate)='" & SalesBillYear & "' and Cash='Y'")
                    If dt.Rows.Count > 0 Then
                        cash = "Y"
                        'MsgBox("This Bill is a cashless bill So you Cannot Return Bill", MsgBoxStyle.Exclamation, Me.Text)
                        'Exit Sub
                    End If
                    dt = SelectQuery("Select * from DrugSlipDetails where BillNo=" & txtSalesBillNo.Text & " and Year(BillDate)='" & SalesBillYear & "' and CreditStatus='C'")
                    If dt.Rows.Count > 0 Then
                        dt = SelectQuery("Select * from PaymentDue where BillNo=" & txtSalesBillNo.Text & " and Year(BillDate)='" & SalesBillYear & "' and DueStatus='CP'")
                        If dt.Rows.Count <= 0 Then
                            MsgBox("This Bill is a credit bill So you Cannot Return Bill", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Sub
                        End If
                    End If
                    dt = SelectQuery("Select * from DrugSlipDetails where BillNo=" & txtSalesBillNo.Text & " and Year(BillDate)='" & SalesBillYear & "' and CreditStatus='D'")
                    If dt.Rows.Count > 0 Then
                        dt = SelectQuery("Select * from PaymentDue where BillNo=" & txtSalesBillNo.Text & " and Year(BillDate)='" & SalesBillYear & "' and DueStatus='AR'")
                        If dt.Rows.Count <= 0 Then
                            MsgBox("This Bill has amount to be returned bill So you Cannot Return Bill", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Sub
                        End If
                        'MsgBox("This Bill has amount to be returned bill So you Cannot Return Bill", MsgBoxStyle.Exclamation, Me.Text)
                        'Exit Sub
                    End If
                End If
                'flag = True
                DisplayBillDetails()
                'CheckFlag = True
                'CheckMe()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReturn.Click
        Try
            CheckConnection()
            Dim tranc As SqlTransaction
            tranc = con.BeginTransaction
            Try
                If cmdShow.Text = "&Cancel" And Val(lblReturnGrandTotal.Text) > 0 Then
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    Dim ReturnBillNo As Integer
                    cmd.CommandText = "Select MAX(ReturnBillNo) from SalesReturnDetails where YEAR(ReturnBillDate)='" & System.DateTime.Now.Year & "'"
                    If IsDBNull(cmd.ExecuteScalar) Then
                        ReturnBillNo = 1
                    Else
                        ReturnBillNo = cmd.ExecuteScalar
                        ReturnBillNo = ReturnBillNo + 1
                    End If
                    txtReturnBillNo.Text = ReturnBillNo
                    If cash = "N" Then
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            If Val(DataGridView1.Rows(i).Cells(3).Value) > 0 Then
                                cmd.CommandText = "insert into SalesReturnDetails Values(" & txtReturnBillNo.Text & ",'" & CDate(UserControl11.lblDateTime.Text).ToShortDateString & "'," & SalesBillNo & ",'" & SalesBillDate & "','" & txtDrName.Text & "','" & txtPatientID.Text & "','" & txtPatientName.Text & "'," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(3).Value & ",'" & DataGridView1.Rows(i).Cells(8).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "'," & DataGridView1.Rows(i).Cells(7).Value & "," & DataGridView1.Rows(i).Cells(6).Value & "," & DataGridView1.Rows(i).Cells(10).Value & ",'" & System.DateTime.Now & "')"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "update StockDetails set CurrentQty=CurrentQty+" & DataGridView1.Rows(i).Cells(3).Value & " where ProductName='" & DataGridView1.Rows(i).Cells(1).Value & "' and BatchNo='" & DataGridView1.Rows(i).Cells(4).Value & "' and InvoiceNo=" & DataGridView1.Rows(i).Cells(8).Value.Substring(0, DataGridView1.Rows(i).Cells(8).Value.IndexOf("-")) & " and YEAR(InvoiceDateTime)='" & DataGridView1.Rows(i).Cells(8).Value.Substring(DataGridView1.Rows(i).Cells(8).Value.IndexOf("-") + 1) & "'"
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    ElseIf cash = "Y" And (UserRights = "Admin" Or UserName = "PHARMACIST") Then
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            If Val(DataGridView1.Rows(i).Cells(3).Value) > 0 Then
                                cmd.CommandText = "insert into SalesReturnDetails Values(" & txtReturnBillNo.Text & ",'" & CDate(UserControl11.lblDateTime.Text).ToShortDateString & "'," & SalesBillNo & ",'" & SalesBillDate & "','" & txtDrName.Text & "','" & txtPatientID.Text & "','" & txtPatientName.Text & "'," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(3).Value & ",'" & DataGridView1.Rows(i).Cells(8).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "'," & DataGridView1.Rows(i).Cells(7).Value & "," & DataGridView1.Rows(i).Cells(6).Value & "," & DataGridView1.Rows(i).Cells(10).Value & ",'" & System.DateTime.Now & "')"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "update StockDetails set CurrentQty=CurrentQty+" & DataGridView1.Rows(i).Cells(3).Value & " where ProductName='" & DataGridView1.Rows(i).Cells(1).Value & "' and BatchNo='" & DataGridView1.Rows(i).Cells(4).Value & "' and InvoiceNo=" & DataGridView1.Rows(i).Cells(8).Value.Substring(0, DataGridView1.Rows(i).Cells(8).Value.IndexOf("-")) & " and YEAR(InvoiceDateTime)='" & DataGridView1.Rows(i).Cells(8).Value.Substring(DataGridView1.Rows(i).Cells(8).Value.IndexOf("-") + 1) & "'"
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    ElseIf cash = "Y" And (UserRights.ToUpper = "USER" And UserName.ToUpper = "ADMIN") Then
                        MsgBox("You cannot save sales return, because this is a cashless bill,contact your administrator or pharmacist")
                        Exit Sub
                    End If
                End If
                tranc.Commit()
                con.Close()
                MakeShow()
                MsgBox("Product Return Stroed Successfully", MsgBoxStyle.Information, Me.Text)
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

    Private Sub SalesReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class