Imports System.Data.SqlClient
Public Class QuotationEntry
    Dim OldQuotationNo, QuotationYear As String
    Dim CheckFlag As Boolean
    Dim QuotationDate As System.DateTime
    Sub EnableEditDG()
        DataGridView1.AllowUserToDeleteRows = True
        DataGridView1.AllowUserToAddRows = True
        cmdNext.Enabled = True
    End Sub
    Sub DisableEditDG()
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToAddRows = False
        cmdNext.Enabled = False
    End Sub

    Sub ClearControls()
        DataGridView1.Rows.Clear()
        DataGridView1.AllowUserToAddRows = False
        txtQuotationNo.Text = ""
        txtCompanyQuotation.Text = ""
        txtSupplierID.Text = ""
        lblGrandTotal.Text = ""
        lblSupplierName.Text = ""
        txtHSR.Text = ""
        txtMRP.Text = ""
        txtQty.Text = ""
        txtVat.Text = ""
        ErrorProvider1.Clear()
    End Sub
    Sub MakeCancel()
        cmdShow.Text = "&Cancel"
        cmdShow.Image = My.Resources.Resource1.Cancel
    End Sub
    Sub Cancel()
        txtQuotationNo.ReadOnly = False
        cmdNew.Text = "&New"
        cmdNew.Image = My.Resources.Resource1._New
        cmdEdit.Text = "&Edit"
        cmdEdit.Image = My.Resources.Resource1.Edit
        cmdShow.Text = "&Show"
        cmdShow.Image = My.Resources.Resource1.Search
        EnableEditDG()
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
            Total = Total + Val(DataGridView1.Rows(i).Cells(6).Value)
        Next
        lblGrandTotal.Text = Total
    End Sub
    Sub DisplayChange()
        If cmdEdit.Text = "&Update" Or cmdNew.Text = "&Save" Then
            drpProductName.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value
            txtQty.Text = DataGridView1.SelectedRows.Item(0).Cells(2).Value
            txtVat.Text = DataGridView1.SelectedRows.Item(0).Cells(3).Value
            txtMRP.Text = DataGridView1.SelectedRows.Item(0).Cells(4).Value
            txtHSR.Text = DataGridView1.SelectedRows.Item(0).Cells(5).Value
        End If
    End Sub
    Sub DisplayQuotationDetails()
        Try
            Dim dt As DataTable
            CheckConnection()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.CommandText = "Select * from QuotationDetails where QuotationNo=" & txtQuotationNo.Text & " and Year(QuotationDate)='" & QuotationYear & "' and Status='P'"
            cmd.Connection = con
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                OldQuotationNo = dr("QuotationNo")
                txtQuotationNo.Text = dr("QuotationNo")
                QuotationDate = dr("QuotationDate")
                drpDrName.Text = dr("DoctorName")
                txtSupplierID.Text = dr("SupplierID")
                txtCompanyQuotation.Text = dr("CompanyQuotationNo")
                MakeCancel()
                dr.Close()
                cmd.CommandText = "Select SupplierName from SupplierMaster where SupplierID=" & txtSupplierID.Text
                dr = cmd.ExecuteReader
                dr.Read()
                lblSupplierName.Text = dr("SupplierName")
                dr.Close()
                dt = SelectQuery("Select * from QuotationDetails where QuotationNo=" & txtQuotationNo.Text & " and YEAR(QuotationDate)='" & QuotationYear & "' order by SNo")
                For i As Integer = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Insert(DataGridView1.Rows.Count, dt.Rows(i).Item("SNo"), dt.Rows(i).Item("ProductName"), dt.Rows(i).Item("Qty"), dt.Rows(i).Item("VAT"), dt.Rows(i).Item("MRP"), dt.Rows(i).Item("HSR"), dt.Rows(i).Item("Total"))
                Next
                CalcGrandTotal()
            Else
                MsgBox("Quotation Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
                ClearControls()
                txtQuotationNo.Focus()
                MakeShow()
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub QuotationEntry_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cmdNew.Focus()
    End Sub

    Private Sub QuotationEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        dt = SelectQuery("Select * from DoctorNameMaster")
        drpDrName.DataSource = dt
        drpDrName.DisplayMember = "DoctorName"
        'dt.Clear()
        dt = SelectQuery("Select * from ProductMaster")
        drpProductName.DataSource = dt
        drpProductName.DisplayMember = "ProductName"
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If drpProductName.Text = DataGridView1.Rows(i).Cells(1).Value Then
                MsgBox("This Product is Already in List, duplicate values cannot be added", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        Next
        Dim total As Double
        total = Val(txtHSR.Text) * Val(txtQty.Text)
        'DataGridView1.Rows.Insert(0, Val(DataGridView1.Rows.Count + 1), drpProductName.Text, txtQty.Text, txtBatch.Text, txtExpDate.Text, txtVat.Text, txtMRP.Text, txtHSR.Text, total)
        DataGridView1.Rows.Insert(DataGridView1.Rows.Count, Val(DataGridView1.Rows.Count + 1), drpProductName.Text, txtQty.Text, txtVat.Text, txtMRP.Text, txtHSR.Text, total)
        CalcGrandTotal()
        txtQty.Text = ""
        txtVat.Text = ""
        txtMRP.Text = ""
        txtHSR.Text = ""
        drpProductName.Focus()
        DataGridView1.CurrentCell = DataGridView1.Item(1, DataGridView1.Rows.Count - 1)
    End Sub

    Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click
        If DataGridView1.Rows.Count > 0 Then
            If cmdNew.Text = "&New" And cmdEdit.Text = "&Update" Then
                DataGridView1.SelectedRows.Item(0).Cells(1).Value = drpProductName.Text
                DataGridView1.SelectedRows.Item(0).Cells(2).Value = txtQty.Text
                DataGridView1.SelectedRows.Item(0).Cells(5).Value = txtVat.Text
                DataGridView1.SelectedRows.Item(0).Cells(6).Value = txtMRP.Text
                DataGridView1.SelectedRows.Item(0).Cells(7).Value = txtHSR.Text
                DataGridView1.SelectedRows.Item(0).Cells(8).Value = Val(txtHSR.Text) * Val(txtQty.Text)
                CalcGrandTotal()
            End If
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If cmdEdit.Text = "&Edit" Then
                cmdNew.Text = "&New"
                cmdNew.Image = My.Resources.Resource1._New
                DataGridView1.Rows.Clear()
                DataGridView1.AllowUserToAddRows = False
                txtCompanyQuotation.Text = ""
                txtSupplierID.Text = ""
                lblGrandTotal.Text = ""
                lblSupplierName.Text = ""
                txtHSR.Text = ""
                txtMRP.Text = ""
                txtQty.Text = ""
                txtVat.Text = ""
                If txtQuotationNo.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtQuotationNo, "Enter QuotationNo")
                    txtQuotationNo.Focus()
                    Exit Sub
                Else
                    QuotationYear = InputBox("Please Enter the Year Of the Quotation Saved", "Enter YEAR")
                    ErrorProvider1.SetError(txtQuotationNo, "")
                End If
                'flag = True
                'MakeCancel()
                DisplayQuotationDetails()
                If QuotationDate.Date <> System.DateTime.Now.Date And UserRights <> "Admin" Then
                    MsgBox("Sorry You cannot Edit the Quotation, Contact your Administrator", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                DisplayChange()
                If OldQuotationNo = Nothing Or QuotationYear = Nothing Then
                    Exit Sub
                End If
                cmdEdit.Text = "&Update"
                DisableEditDG()
                cmdEdit.Image = My.Resources.Resource1.Update
                CheckFlag = True
                txtQuotationNo.ReadOnly = True
                txtCompanyQuotation.Focus()
                'CheckMe()
            Else
                'flag = False
                Dim dt As New DataTable
                dt = SelectQuery("Select * from QuotationDetails where QuotationNo=" & txtQuotationNo.Text & " and Year(QuotationDateTime)='" & QuotationYear & "' order by SNo")
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Try
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    'cmd.CommandText = "Delete from QuotationDetails where QuotationNo=" & txtQuotationNo.Text & " and YearQuotationDateTime=
                    cmd.CommandText = "Delete from QuotationDetails where QuotationNo='" & OldQuotationNo & "' and Year(QuotaionDate)='" & QuotationDate.Year & "'"
                    cmd.ExecuteNonQuery()
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "insert into QuotationDetails values(" & txtQuotationNo.Text & ",'" & QuotationDate & "','" & txtCompanyQuotation.Text & "','" & drpDrName.Text & "'," & txtSupplierID.Text & "," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & "," & DataGridView1.Rows(i).Cells(3).Value & "," & DataGridView1.Rows(i).Cells(4).Value & "," & DataGridView1.Rows(i).Cells(5).Value & "," & DataGridView1.Rows(i).Cells(6).Value & ",'P')"
                        cmd.ExecuteNonQuery()
                    Next

                    tranc.Commit()
                    con.Close()
                    MsgBox("Quotataion Details Updated Successfully", MsgBoxStyle.Information, "Data Updated")
                    OldQuotationNo = Nothing
                    cmdEdit.Text = "&Edit"
                    EnableEditDG()
                    cmdEdit.Image = My.Resources.Resource1.Edit
                    MakeShow()
                    CheckFlag = False
                    txtQuotationNo.ReadOnly = False
                    'CheckMe()
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

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Try
            If cmdNew.Text = "&New" Then
                'flag = True
                ClearControls()
                MakeCancel()
                cmdNew.Image = My.Resources.Resource1.Save
                cmdEdit.Text = "&Edit"
                cmdEdit.Image = My.Resources.Resource1.Edit
                cmdNew.Text = "&Save"
                txtCompanyQuotation.Focus()
                CheckFlag = True
                txtQuotationNo.ReadOnly = True
                'CheckMe()
            Else
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Try
                    'CheckConnection()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    Dim QuotationNo As Integer
                    'Dim dt As New DataTable
                    Dim da As New SqlDataAdapter("Select QuotationNo from QuotationDetails where SupplierID=" & txtSupplierID.Text & " and CompanyQuotationNo='" & txtCompanyQuotation.Text & "' and YEAR(QuotationDate)='" & System.DateTime.Now.Year & "'", con)
                    Dim ds As New DataSet
                    da.SelectCommand.Transaction = tranc
                    da.Fill(ds)
                    'dt = SelectQuery("Select QuotationNo from QuotationDetails where SupplierID=" & txtSupplierID.Text & " and CompanyQuotationNo='" & txtCompanyQuotation.Text & "' and YEAR(QuotationDateTime)='" & System.DateTime.Now.Year & "'")
                    If ds.Tables(0).Rows.Count > 0 Then
                        MsgBox("This Quotation Entered Already! Quotation No is: " & ds.Tables(0).Rows(0).Item("QuotationNo"))
                        Exit Sub
                    End If
                    cmd.CommandText = "Select MAX(QuotationNo) from QuotationDetails where YEAR(QuotationDate)='" & System.DateTime.Now.Year & "'"
                    If IsDBNull(cmd.ExecuteScalar) Then
                        QuotationNo = 1
                    Else
                        QuotationNo = cmd.ExecuteScalar
                        QuotationNo = QuotationNo + 1
                    End If
                    txtQuotationNo.Text = QuotationNo
                    Dim InvD As String = CDate(UserControl11.lblDateTime.Text).ToShortDateString
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "insert into QuotationDetails values(" & txtQuotationNo.Text & ",'" & InvD & "','" & txtCompanyQuotation.Text & "','" & drpDrName.Text & "'," & txtSupplierID.Text & "," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & "," & DataGridView1.Rows(i).Cells(3).Value & "," & DataGridView1.Rows(i).Cells(4).Value & "," & DataGridView1.Rows(i).Cells(5).Value & "," & DataGridView1.Rows(i).Cells(6).Value & ",'P')"
                        cmd.ExecuteNonQuery()
                    Next
                    tranc.Commit()
                    con.Close()
                    cmdNew.Text = "&New"
                    cmdNew.Image = My.Resources.Resource1._New
                    MsgBox("Quotation Details Saved Successfully", MsgBoxStyle.Information, Me.Text)
                    MakeShow()
                    'ClearControls()
                    CheckFlag = False
                    'CheckMe()
                    txtQuotationNo.ReadOnly = False
                Catch ex As Exception
                    tranc.Rollback()
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                'flag = False
            End If
            OldQuotationNo = Nothing
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdCancellBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancellBill.Click
        Try
            If cmdShow.Text = "&Cancel" And cmdNew.Text = "&New" And cmdEdit.Text = "&Edit" And OldQuotationNo <> Nothing Then
                Dim count As Integer
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Try
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    cmd.CommandText = "Select count(*) from QuotationDetails where Status='C' and QuotationNo=" & txtQuotationNo.Text & " and Year(QuotationDate)='" & QuotationYear & "'"
                    count = cmd.ExecuteScalar
                    If count = 0 Then
                        cmd.CommandText = "Select count(*) from QuotationDetails where and QuotationNo=" & txtQuotationNo.Text & " and Year(QuotationDate)='" & QuotationYear & "'"
                        count = cmd.ExecuteScalar
                        If count > 0 Then
                            If QuotationDate <> System.DateTime.Now.ToShortDateString And UserRights = "Admin" Then
                                MsgBox("Sorry you cannot cancel this Quotation Contact your administrator", MsgBoxStyle.Exclamation, "Cannot Cancel")
                                Exit Sub
                            End If
                            Dim ds As New DialogResult
                            ds = MsgBox("Are You Sure to Cancel This Quotation", MsgBoxStyle.YesNo, "Cancel Quotation")
                            If ds = Windows.Forms.DialogResult.Yes Then
                                cmd.CommandText = "update QuotationDetails set Status='C' where QuotationNo='" & txtQuotationNo.Text & "' and YEAR(QuotationDate)='" & QuotationYear & "'"
                                cmd.ExecuteNonQuery()
                                tranc.Commit()
                                con.Close()
                                MakeShow()
                                MsgBox("This Quotation Cancelled Successfully", MsgBoxStyle.Information, Me.Text)
                            End If
                        Else
                            MsgBox("Cannot find Bill", MsgBoxStyle.Exclamation, Me.Text)
                        End If
                    Else
                        con.Close()
                        MsgBox("This Quotation was already Cancelled", MsgBoxStyle.Exclamation, Me.Text)
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

    Private Sub txtCompanyQuotation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompanyQuotation.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue >= 65 And e.KeyValue <= 90) Or (e.KeyValue >= 96 And e.KeyValue <= 122) Or (e.KeyValue = 8) Or (e.KeyValue = 46) Or (e.KeyValue = 37) Or (e.KeyValue = 39) Or (e.KeyValue = 35) Or (e.KeyValue = 36) Then
            e.SuppressKeyPress = False
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub drpDrName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpDrName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpProductName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpProductName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtVat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVat.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtMRP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMRP.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtHSR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHSR.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpProductName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles drpProductName.Validating
        If drpProductName.FindStringExact(drpProductName.Text) < 0 Then
            ErrorProvider1.SetError(drpProductName, "Please Select Valid Product Name")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(drpProductName, "")
        End If
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Try
            If cmdShow.Text = "&Cancel" Then
                'flag = False
                Cancel()
                MakeShow()
                ClearControls()
                cmdNew.Focus()
                OldQuotationNo = Nothing
                CheckFlag = False
                'CheckMe()
            Else
                If txtQuotationNo.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtQuotationNo, "Enter QuotationNo")
                    Exit Sub
                Else
                    QuotationYear = InputBox("Please Enter the Year Of the Quotation Saved", "Enter YEAR")
                    ErrorProvider1.SetError(txtQuotationNo, "")
                End If
                'flag = True
                DisplayQuotationDetails()
                CheckFlag = True
                'CheckMe()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub GlassButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlassButton1.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindSupplierIDQuotation.Show()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        DisplayChange()
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        For i As Integer = 1 To DataGridView1.Rows.Count
            DataGridView1.Rows(i - 1).Cells(0).Value = i
        Next
        CalcGrandTotal()
    End Sub
End Class