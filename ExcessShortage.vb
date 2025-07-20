Imports System.Data.SqlClient
Public Class ExcessShortage
    Dim InvoiceYear As String
    Dim ESNo As Integer
    Sub DisplayInvoiceDetails()
        If txtInvoiceNo.Text.Length = 0 Or IsNumeric(txtInvoiceNo.Text) = False Then
            ErrorProvider1.SetError(txtInvoiceNo, "Enter Invoice Number")
            txtInvoiceNo.Focus()
            Exit Sub
        End If
        InvoiceYear = InputBox("Please Enter Invoice Year", "Invoice Year")
        Dim dt As New DataTable
        dt = SelectQuery("Select Distinct(ProductName) from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and YEAR(InvoiceDateTime)='" & InvoiceYear & "'")
        drpProductName.DisplayMember = "ProductName"
        drpProductName.DataSource = dt.DefaultView
        Dim dt1 As New DataTable
        dt1 = SelectQuery("Select * from InvoiceDetails where ProductName='" & drpProductName.Text & "' and InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "'")
        If dt1.Rows.Count > 0 Then
            txtInvoiceDate.Text = dt1.Rows(0).Item("InvoiceDateTime")
        End If
        If dt.Rows.Count > 0 Then
            cmdNew.Text = "&Save"
            txtInvoiceNo.ReadOnly = True
            txtInvoiceNo.TabStop = False
        Else
            cmdNew.Text = "&New"
            txtInvoiceNo.ReadOnly = False
            txtInvoiceNo.TabStop = True
        End If
    End Sub
    Function ValidateExcessShortage() As Boolean
        If txtInvoiceNo.Text.Length = 0 Then
            ErrorProvider1.SetError(txtInvoiceNo, "Enter Invoice No")
            Return False
        Else
            ErrorProvider1.SetError(txtInvoiceNo, "")
        End If
        If txtInvoiceDate.Text.Length = 0 Then
            ErrorProvider1.SetError(txtInvoiceNo, "Enter Invoice No")
            Return False
        Else
            ErrorProvider1.SetError(txtInvoiceNo, "")
        End If
        If txtExcessShortageQty.Text.Length = 0 Then
            ErrorProvider1.SetError(txtExcessShortageQty, "Enter Qty")
            Return False
        Else
            ErrorProvider1.SetError(txtExcessShortageQty, "")
        End If
        If IsNumeric(txtExcessShortageQty.Text) = False Then
            ErrorProvider1.SetError(txtExcessShortageQty, "Enter Number Only")
            Return False
        Else
            ErrorProvider1.SetError(txtExcessShortageQty, "")
        End If
        If txtDescription.Text.Length = 0 Then
            ErrorProvider1.SetError(txtDescription, "Please Enter Description")
            Return False
        Else
            ErrorProvider1.SetError(txtDescription, "")
        End If
        Return True
    End Function

    Private Sub drpProductName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpProductName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpProductName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProductName.SelectedIndexChanged
        Dim dt1 As New DataTable
        dt1 = SelectQuery("Select Distinct(BatchNo) from InvoiceDetails where  InvoiceNo=" & txtInvoiceNo.Text & " and YEAR(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & drpProductName.Text & "'")
        drpBatch.DisplayMember = "BatchNo"
        drpBatch.DataSource = dt1.DefaultView
    End Sub

    Private Sub drpBatch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpBatch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpBatch.SelectedIndexChanged
        Dim dt2 As New DataTable
        dt2 = SelectQuery("Select * from InvoiceDetails where  InvoiceNo=" & txtInvoiceNo.Text & " and YEAR(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & drpProductName.Text & "' and BatchNo='" & drpBatch.Text & "'")
        If dt2.Rows.Count > 0 Then
            txtExpDate.Text = dt2.Rows(0).Item("ExpDate")
            txtPurchaseQty.Text = dt2.Rows(0).Item("Qty")
        End If
    End Sub

    Private Sub txtInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvoiceNo.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue = 8) Or (e.KeyValue = 46) Or (e.KeyValue = 37) Or (e.KeyValue = 39) Or (e.KeyValue = 35) Or (e.KeyValue = 36) Then
            e.SuppressKeyPress = False
        ElseIf e.KeyCode = Keys.Enter Then
            DisplayInvoiceDetails()
            SendKeys.Send("{TAB}")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Try
            If cmdNew.Text = "&New" Then
                DisplayInvoiceDetails()
            Else
                If ValidateExcessShortage() = True Then
                    If drpType.Text = "Shortage" Then
                        Dim dt1 As New DataTable
                        dt1 = SelectQuery("Select * from StockDetails where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & drpProductName.Text & "' and BatchNo='" & drpBatch.Text & "'")
                        If dt1.Rows.Count > 0 Then
                            If Val(txtExcessShortageQty.Text) > dt1.Rows(0).Item("CurrentQty") Then
                                MsgBox("Shortage exceeding the current Stock, cannot proceed")
                                Exit Sub
                            End If
                        End If
                    End If
                    Dim dr As DialogResult
                    dr = MsgBox("Are You Sure To Proceed?", MsgBoxStyle.YesNo, Me.Text)
                    If dr = Windows.Forms.DialogResult.Yes Then
                        CheckConnection()
                        Dim tranc As SqlTransaction
                        tranc = con.BeginTransaction
                        Try
                            Dim cmd As New SqlCommand
                            cmd.Connection = con
                            cmd.Transaction = tranc
                            cmd.CommandText = "Select MAX(ESNo) from ESTable where YEAR(ESDate)='" & System.DateTime.Now.Year & "'"
                            If IsDBNull(cmd.ExecuteScalar) Then
                                ESNo = 1
                            Else
                                ESNo = cmd.ExecuteScalar
                                ESNo = ESNo + 1
                            End If
                            cmd.CommandText = "insert into ESTable values(" & ESNo & ",'" & System.DateTime.Now.ToShortDateString & "'," & txtInvoiceNo.Text & ",'" & InvoiceYear & "','" & drpProductName.Text & "','" & drpBatch.Text & "','" & txtExpDate.Text & "'," & txtPurchaseQty.Text & "," & txtExcessShortageQty.Text & ",'" & txtDescription.Text & "','" & drpType.Text & "')"
                            cmd.ExecuteNonQuery()
                            If drpType.Text = "Excess" Then
                                cmd.CommandText = "Update StockDetails set CurrentQty=CurrentQty+" & txtExcessShortageQty.Text & " where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & drpProductName.Text & "' and BatchNo='" & drpBatch.Text & "'"
                                cmd.ExecuteNonQuery()
                            Else
                                cmd.CommandText = "Update StockDetails set CurrentQty=CurrentQty-" & txtExcessShortageQty.Text & " where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & drpProductName.Text & "' and BatchNo='" & drpBatch.Text & "'"
                                cmd.ExecuteNonQuery()
                            End If
                            tranc.Commit()
                            con.Close()
                            cmdNew.Text = "&New"
                            MsgBox("Entry Saved Successfully", MsgBoxStyle.Information, Me.Text)
                            txtInvoiceNo.ReadOnly = False
                        Catch ex As Exception
                            txtInvoiceNo.ReadOnly = False
                            txtInvoiceNo.ReadOnly = True
                            tranc.Rollback()
                            con.Close()
                            MsgBox(ex.Message)
                        End Try
                    Else
                        ClearControls()
                        txtInvoiceNo.ReadOnly = True
                        cmdNew.Text = "&New"
                    End If
                End If
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ClearControls()
        txtInvoiceNo.Text = ""
        txtExpDate.Text = ""
        txtPurchaseQty.Text = ""
        txtExcessShortageQty.Text = ""
        txtDescription.Text = ""
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ExcessShortage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim arr As New ArrayList
        arr.Add("Excess")
        arr.Add("Shortage")
        drpType.DataSource = arr
    End Sub

    Private Sub txtDescription_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyDown
        If (e.KeyValue >= 65 And e.KeyValue <= 90) Or (e.KeyValue >= 96 And e.KeyValue <= 122) Or (e.KeyValue = 8) Or (e.KeyValue = 46) Or (e.KeyValue = 37) Or (e.KeyValue = 39) Or (e.KeyValue = 35) Or (e.KeyValue = 36) Or (e.KeyValue = 32) Or (e.KeyValue = 190) Then
            e.SuppressKeyPress = False
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtExcessShortageQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExcessShortageQty.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue = 8) Or (e.KeyValue = 46) Or (e.KeyValue = 37) Or (e.KeyValue = 39) Or (e.KeyValue = 35) Or (e.KeyValue = 36) Then
            e.SuppressKeyPress = False
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub drpType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class