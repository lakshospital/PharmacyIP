Imports System.Data.SqlClient
Public Class frmPaymentDue

    Private Sub frmPaymentDue_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtAmountReceived.Focus()
    End Sub

    Private Sub frmPaymentDue_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmPaymentDue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim loc As System.Drawing.Point
        lblBillAmount.Text = DrugSlip.lblGrandTotal.Text
        txtBillNo.Text = DrugSlip.txtBillNo.Text
        lblBillDate.Text = DrugSlip.BillDate.ToShortDateString
        txtPatientID.Text = DrugSlip.txtPatientID.Text
        txtPatientName.Text = DrugSlip.txtPatientName.Text
        txtAmountReceived.Text = ""
        Dim da As New SqlDataAdapter("", con)
        Dim ds As New DataSet
        Dim cmd As New SqlCommand("select isnull(count(*),0) from PaymentDue where (DueStatus='CT' or DueStatus='CP') and BillNo=" & DrugSlip.txtBillNo.Text & " and BillDate='" & DrugSlip.BillDate & "' and BillStatus='P'", con)
        CheckConnection()
        If cmd.ExecuteScalar > 0 Then
            da.SelectCommand.CommandText = "SELECT     DueNo, DueDate, CONVERT(VARCHAR, Amount, 0) AS BillAmount, CASE WHEN dueno = 1 THEN CONVERT(varchar, DueAmount, 0) WHEN dueno <> 1 THEN '-' END AS AmountReceived, CASE WHEN dueno = 1 THEN '-' WHEN dueno <> 1 THEN CONVERT(varchar, DueAmount, 0) END AS CreditPaid, CONVERT(varchar, BalanceAmount, 0) AS BalanceAMount, CASE WHEN DueStatus = 'CT' THEN 'Credit to be paid' WHEN DueStatus = 'AT' THEN 'Amount to be returned' ELSE 'Completed' END AS Status FROM  PaymentDue where BillNo=" & DrugSlip.txtBillNo.Text & " and BillDate='" & DrugSlip.BillDate & "' order by DueNo"
            da.Fill(ds)
            DataGridView1.Width = 800
            loc.X = 80
            loc.Y = 88
            DataGridView1.Location = loc
            lblReceiveReturn.Text = "Amount Received"
        Else
            cmd.CommandText = "select isnull(count(*),0) from PaymentDue where (DueStatus='AT' or DueStatus='AR') and BillNo=" & DrugSlip.txtBillNo.Text & " and BillDate='" & DrugSlip.BillDate & "'"
            If cmd.ExecuteScalar > 0 Then
                da.SelectCommand.CommandText = "Select DueNo,DueDate,convert(varchar,Amount,0) as BillAmount,convert(varchar,AmountReceived,0) as AmountReceived,convert(varchar,DueAmount,0) as AmountReturned,convert(varchar,BalanceAmount,0) as BalanceAmount,CASE WHEN DueStatus = 'CT' THEN 'Credit to be paid' WHEN DueStatus = 'AT' THEN 'Amount to be returned' ELSE 'Completed' END AS Status from PaymentDue where BillNo=" & DrugSlip.txtBillNo.Text & " and BillDate='" & DrugSlip.BillDate & "' order by DueNo"
                da.Fill(ds)
                DataGridView1.Width = 850
                loc.X = 24
                loc.Y = 88
                DataGridView1.Location = loc
                lblReceiveReturn.Text = "Amount Returned"
            Else
                cmd.CommandText = "select isnull(count(*),0) from PaymentDue where DueStatus='FP' and BillNo=" & DrugSlip.txtBillNo.Text & " and BillDate='" & DrugSlip.BillDate & "'"
                If cmd.ExecuteScalar > 0 Then
                    da.SelectCommand.CommandText = "Select DueNo,DueDate,convert(varchar,Amount,0) as BillAmount,convert(varchar,DueAmount,0) as DueAmount,convert(varchar,BalanceAmount,0) as BalanceAmount,CASE WHEN DueStatus = 'CT' THEN 'Credit to be paid' WHEN DueStatus = 'AT' THEN 'Amount to be returned' ELSE 'Completed' END AS Status from PaymentDue where BillNo=" & DrugSlip.txtBillNo.Text & " and BillDate='" & DrugSlip.BillDate & "' order by DueNo"
                    da.Fill(ds)
                    DataGridView1.Width = 800
                    loc.X = 80
                    loc.Y = 88
                    DataGridView1.Location = loc
                    lblReceiveReturn.Text = "Paid Fully"
                Else
                    MsgBox("No payment history found", MsgBoxStyle.Exclamation)
                    Me.Dispose()
                    Exit Sub
                End If
            End If
        End If
        con.Close()
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            If UserRights = "Admin" And IsNumeric(txtAmountReceived.Text) And Val(txtAmountReceived.Text) < 0 Then
                MsgBox("Cannot Enter Negative values")
                Exit Sub
            End If
            CheckConnection()
            Dim tranc As SqlTransaction
            tranc = con.BeginTransaction
            Try
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.Transaction = tranc
                cmd.CommandText = "Select isnull(count(*),0) from PaymentDue where BillNo=" & DrugSlip.txtBillNo.Text & " and BillDate='" & DrugSlip.BillDate & "' and BalanceAmount=0"
                If cmd.ExecuteScalar > 0 Then
                    MsgBox("Payment transactions completed for this bill`, you cannot enter another due", MsgBoxStyle.Exclamation)
                Else
                    Dim TotalDue As Double = 0.0
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If i = 0 Then
                            TotalDue = TotalDue + DataGridView1.Rows(i).Cells(3).Value
                        Else
                            TotalDue = TotalDue + DataGridView1.Rows(i).Cells(4).Value
                        End If
                    Next
                    Dim rc As Integer
                    rc = Val(DataGridView1.Rows.Count - 1)
                    If DataGridView1.Rows(rc).Cells(6).Value = "Credit to be paid" Then
                        If (TotalDue - lblBillAmount.Text) = 0 Then
                            MsgBox("Payment for this bill is paid fully, you cannot enter another due", MsgBoxStyle.Exclamation)
                        ElseIf Math.Round(lblBillAmount.Text - (TotalDue + txtAmountReceived.Text), 2) > 0 Then
                            cmd.CommandText = "insert into PaymentDue values(" & txtBillNo.Text & ",'" & lblBillDate.Text & "'," & lblBillAmount.Text & "," & DataGridView1.Rows.Count + 1 & ",'" & System.DateTime.Now & "'," & txtAmountReceived.Text & ",0," & (lblBillAmount.Text - (TotalDue + txtAmountReceived.Text)) & ",'CT','P','" & UserName & "')"
                            cmd.ExecuteScalar()
                            MsgBox("Due Saved Balance Amout: " & (lblBillAmount.Text - (TotalDue + txtAmountReceived.Text)), MsgBoxStyle.Information)
                        ElseIf Math.Round(lblBillAmount.Text - (TotalDue + txtAmountReceived.Text), 2) = 0 Then
                            cmd.CommandText = "insert into PaymentDue values(" & txtBillNo.Text & ",'" & lblBillDate.Text & "'," & lblBillAmount.Text & "," & DataGridView1.Rows.Count + 1 & ",'" & System.DateTime.Now & "'," & txtAmountReceived.Text & ",0," & (lblBillAmount.Text - (TotalDue + txtAmountReceived.Text)) & ",'CP','P','" & UserName & "')"
                            cmd.ExecuteScalar()
                            MsgBox("Due Saved, No balance to be paid", MsgBoxStyle.Information)
                        Else
                            MsgBox("Please contact administrator, there is some problem in Payment Due", MsgBoxStyle.Critical)
                        End If
                    ElseIf DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(6).Value = "Amount to be returned" Then
                        TotalDue = 0.0
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            TotalDue = TotalDue + DataGridView1.Rows(i).Cells(4).Value
                        Next
                        Dim temp As Double
                        temp = Math.Round(CDbl(DataGridView1.Rows(0).Cells(3).Value) - CDbl(DataGridView1.Rows(0).Cells(2).Value) - TotalDue, 2)
                        If Math.Round(((CDbl(DataGridView1.Rows(0).Cells(3).Value) - CDbl(DataGridView1.Rows(0).Cells(2).Value)) - TotalDue), 2) = 0 Then
                            MsgBox("Amount returned fully for this bill", MsgBoxStyle.Exclamation)
                        ElseIf Math.Round((CDbl(DataGridView1.Rows(0).Cells(3).Value) - CDbl(DataGridView1.Rows(0).Cells(2).Value) - TotalDue - CDbl(txtAmountReceived.Text)), 2) > 0 Then
                            cmd.CommandText = "insert into PaymentDue values(" & txtBillNo.Text & ",'" & lblBillDate.Text & "'," & lblBillAmount.Text & "," & DataGridView1.Rows.Count + 1 & ",'" & System.DateTime.Now & "'," & txtAmountReceived.Text & "," & DataGridView1.Rows(0).Cells(3).Value & "," & (CDbl(DataGridView1.Rows(0).Cells(3).Value) - CDbl(DataGridView1.Rows(0).Cells(2).Value) - TotalDue - CDbl(txtAmountReceived.Text)) & ",'AT','P','" & UserName & "')"
                            cmd.ExecuteScalar()
                            MsgBox("Due Saved, Balance Amount to return: " & (CDbl(DataGridView1.Rows(0).Cells(3).Value) - CDbl(DataGridView1.Rows(0).Cells(2).Value) - TotalDue - CDbl(txtAmountReceived.Text)), MsgBoxStyle.Information)
                        ElseIf Math.Round((CDbl(DataGridView1.Rows(0).Cells(3).Value) - CDbl(DataGridView1.Rows(0).Cells(2).Value) - TotalDue - CDbl(txtAmountReceived.Text)), 2) = 0 Then
                            cmd.CommandText = "insert into PaymentDue values(" & txtBillNo.Text & ",'" & lblBillDate.Text & "'," & lblBillAmount.Text & "," & DataGridView1.Rows.Count + 1 & ",'" & System.DateTime.Now & "'," & txtAmountReceived.Text & "," & DataGridView1.Rows(0).Cells(3).Value & "," & (CDbl(DataGridView1.Rows(0).Cells(3).Value) - CDbl(DataGridView1.Rows(0).Cells(2).Value) - TotalDue - CDbl(txtAmountReceived.Text)) & ",'AR','P','" & UserName & "')"
                            cmd.ExecuteScalar()
                            MsgBox("Due Saved, No Balance Amount to return", MsgBoxStyle.Information)
                        Else
                            MsgBox("Please contact administrator, there is some problem in Payment Due", MsgBoxStyle.Critical)
                        End If
                    End If
                End If
                tranc.Commit()
                con.Close()
                Me.Close()
            Catch ex As Exception
                tranc.Rollback()
                con.Close()
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try

        DrugSlip.cmdPaymentDue.Visible = False
        DrugSlip.cmdShow.Text = "&Show"
        DrugSlip.txtBillNo.Enabled = True

        
    End Sub

    Private Sub txtAmountReceived_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmountReceived.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class