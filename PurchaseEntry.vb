Imports System.Data.SqlClient
Public Class PurchaseEntry
    'Dim flag As Boolean
    Dim OldInvoiceNo, InvoiceYear As String
    Dim CheckFlag As Boolean
    Dim InvoiceDate As System.DateTime
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
        txtInvoiceNo.Text = ""
        txtCompanyInvoice.Text = ""
        txtSupplierID.Text = ""
        lblGrandTotal.Text = ""
        lblSupplierName.Text = ""
        txtBatch.Text = ""
        txtExpDate.Text = ""
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
        txtInvoiceNo.ReadOnly = False
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
            Total = Total + Val(DataGridView1.Rows(i).Cells(8).Value)
        Next
        lblGrandTotal.Text = Total
    End Sub
    Sub DisplayChange()
        If cmdEdit.Text = "&Update" Or cmdNew.Text = "&Save" Then
            drpProductName.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value
            txtQty.Text = DataGridView1.SelectedRows.Item(0).Cells(2).Value
            txtBatch.Text = DataGridView1.SelectedRows.Item(0).Cells(3).Value
            txtExpDate.Text = DataGridView1.SelectedRows.Item(0).Cells(4).Value
            txtVat.Text = DataGridView1.SelectedRows.Item(0).Cells(5).Value
            txtMRP.Text = DataGridView1.SelectedRows.Item(0).Cells(6).Value
            txtHSR.Text = DataGridView1.SelectedRows.Item(0).Cells(7).Value
        End If
    End Sub

   
    Private Sub PurchaseEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        dt = SelectQuery("Select * from DoctorNameMaster")
        drpDrName.DataSource = dt
        drpDrName.DisplayMember = "DoctorName"
        'dt.Clear()
        dt = SelectQuery("Select * from ProductMaster")
        drpProductName.DataSource = dt
        drpProductName.DisplayMember = "ProductName"
        cmdNew.Select()
        txtExpDate.Value = DateTime.Now().AddDays(1) ' new code
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindSupplierIDDialog_PurchaseEntry.Show()
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If Val(txtMRP.Text) < Val(txtHSR.Text) Then
            MsgBox("MRP cannot be lesser than HSR")
            Exit Sub
        End If
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If drpProductName.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(1).Value.ToString.ToUpper And txtBatch.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(3).Value.ToString.ToUpper Then
                MsgBox("This Product is Already in List with this BatchNo, duplicate values cannot be added", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        Next
        Dim total As Double
        total = Val(txtHSR.Text) * Val(txtQty.Text)
        'DataGridView1.Rows.Insert(0, Val(DataGridView1.Rows.Count + 1), drpProductName.Text, txtQty.Text, txtBatch.Text, txtExpDate.Text, txtVat.Text, txtMRP.Text, txtHSR.Text, total)
        DataGridView1.Rows.Insert(DataGridView1.Rows.Count, Val(DataGridView1.Rows.Count + 1), drpProductName.Text, txtQty.Text, txtBatch.Text, txtExpDate.Text, txtVat.Text, txtMRP.Text, txtHSR.Text, total)
        CalcGrandTotal()
        txtQty.Text = ""
        txtBatch.Text = ""
        txtExpDate.Text = ""
        txtVat.Text = ""
        txtMRP.Text = ""
        txtHSR.Text = ""
        drpProductName.Focus()
        DataGridView1.CurrentCell = DataGridView1.Item(1, DataGridView1.Rows.Count - 1)
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
                txtCompanyInvoice.Focus()
                CheckFlag = True
                txtInvoiceNo.ReadOnly = True
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
                    Dim InvoiceNo As Integer
                    'Dim dt As New DataTable
                    Dim da As New SqlDataAdapter("Select InvoiceNo from InvoiceDetails where SupplierID=" & txtSupplierID.Text & " and CompanyInvoiceNo='" & txtCompanyInvoice.Text & "' and YEAR(InvoiceDateTime)='" & System.DateTime.Now.Year & "'", con)
                    Dim ds As New DataSet
                    da.SelectCommand.Transaction = tranc
                    da.Fill(ds)
                    'dt = SelectQuery("Select InvoiceNo from InvoiceDetails where SupplierID=" & txtSupplierID.Text & " and CompanyInvoiceNo='" & txtCompanyInvoice.Text & "' and YEAR(InvoiceDateTime)='" & System.DateTime.Now.Year & "'")
                    If ds.Tables(0).Rows.Count > 0 Then
                        MsgBox("This Invoice Entered Already! Invoice No is: " & ds.Tables(0).Rows(0).Item("InvoiceNo"))
                        Exit Sub
                    End If
                    cmd.CommandText = "Select MAX(InvoiceNo) from InvoiceDetails where YEAR(InvoiceDateTime)='" & System.DateTime.Now.Year & "'"
                    If IsDBNull(cmd.ExecuteScalar) Then
                        InvoiceNo = 1
                    Else
                        InvoiceNo = cmd.ExecuteScalar
                        InvoiceNo = InvoiceNo + 1
                    End If
                    txtInvoiceNo.Text = InvoiceNo
                    Dim InvD As String = CDate(UserControl11.lblDateTime.Text).ToShortDateString
                    Dim InvD1 As String = CDate(UserControl11.lblDateTime.Text)
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "insert into InvoiceDetails values(" & txtInvoiceNo.Text & ",'" & InvD & "','" & txtCompanyInvoice.Text & "','" & drpDrName.Text & "'," & txtSupplierID.Text & "," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ",'" & DataGridView1.Rows(i).Cells(3).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "'," & DataGridView1.Rows(i).Cells(5).Value & "," & DataGridView1.Rows(i).Cells(6).Value & "," & DataGridView1.Rows(i).Cells(7).Value & "," & DataGridView1.Rows(i).Cells(8).Value & ",'P','" & InvD1 & "','" & dtpCompanyDate.Text & "')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "insert into StockDetails  values(" & txtInvoiceNo.Text & ",'" & InvD & "','" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & DataGridView1.Rows(i).Cells(3).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ")"
                        cmd.ExecuteNonQuery()
                    Next
                    tranc.Commit()
                    con.Close()
                    cmdNew.Text = "&New"
                    cmdNew.Image = My.Resources.Resource1._New
                    MsgBox("Product Details Saved Successfully", MsgBoxStyle.Information, Me.Text)
                    MakeShow()
                    'ClearControls()
                    CheckFlag = False
                    'CheckMe()
                    txtInvoiceNo.ReadOnly = False
                Catch ex As Exception
                    tranc.Rollback()
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                'flag = False
            End If
            OldInvoiceNo = Nothing
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If cmdEdit.Text = "&Edit" Then
                cmdNew.Text = "&New"
                cmdNew.Image = My.Resources.Resource1._New
                DataGridView1.Rows.Clear()
                DataGridView1.AllowUserToAddRows = False
                txtCompanyInvoice.Text = ""
                txtSupplierID.Text = ""
                lblGrandTotal.Text = ""
                lblSupplierName.Text = ""
                txtBatch.Text = ""
                txtExpDate.Text = ""
                txtHSR.Text = ""
                txtMRP.Text = ""
                txtQty.Text = ""
                txtVat.Text = ""
                If txtInvoiceNo.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtInvoiceNo, "Enter InvoiceNo")
                    txtInvoiceNo.Focus()
                    Exit Sub
                Else
                    InvoiceYear = InputBox("Please Enter the Year Of the Invoice Saved", "Enter YEAR")
                    ErrorProvider1.SetError(txtInvoiceNo, "")
                End If
                'flag = True
                'MakeCancel()
                DisplayInvoiceDetails()
                If UserName.ToString.ToUpper = "PHARMACIST" Then
                    Dim ts As TimeSpan
                    ts = System.DateTime.Now.Date.Subtract(InvoiceDate.Date)
                    If CInt(ts.TotalDays) > 1 Or CInt(ts.TotalDays) < 0 Then
                        DisableEditDG()
                        MsgBox("Sorry You cannot Edit the Invoice, Contact your Administrator", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                    EnableEditDG()
                ElseIf InvoiceDate.Date <> System.DateTime.Now.Date And UserRights <> "Admin" Then
                    DisableEditDG()
                    MsgBox("Sorry You cannot Edit the Invoice, Contact your Administrator", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                DisplayChange()
                If OldInvoiceNo = Nothing Or InvoiceYear = Nothing Then
                    Exit Sub
                End If
                cmdEdit.Text = "&Update"
                'DisableEditDG()
                EnableEditDG()
                DataGridView1.AllowUserToAddRows = False
                cmdEdit.Image = My.Resources.Resource1.Update
                CheckFlag = True
                DataGridView1.AllowUserToDeleteRows = False
                txtInvoiceNo.ReadOnly = True
                txtCompanyInvoice.Focus()
                'CheckMe()
            Else
                'flag = False
                Dim da_Inv As New SqlDataAdapter("Select * from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' order by SNo", con)
                Dim ds_Inv As New DataSet
                da_Inv.Fill(ds_Inv)
                Dim dt As New DataTable
                dt = SelectQuery("Select * from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' order by SNo")
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Try
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    'cmd.CommandText = "Delete from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and YearInvoiceDateTime=
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        'If Val(dt.Rows.Count - 1) > i Then
                        '    cmd.CommandText = "insert into InvoiceDetails values(" & txtInvoiceNo.Text & ",'" & UserControl11.lblDateTime.Text & "','" & txtCompanyInvoice.Text & "','" & drpDrName.Text & "'," & txtSupplierID.Text & "," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ",'" & DataGridView1.Rows(i).Cells(3).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "'," & DataGridView1.Rows(i).Cells(5).Value & "," & DataGridView1.Rows(i).Cells(6).Value & "," & DataGridView1.Rows(i).Cells(7).Value & "," & DataGridView1.Rows(i).Cells(8).Value & ")"
                        '    cmd.ExecuteNonQuery()
                        '    cmd.CommandText = "insert into StockDetails  values(" & txtInvoiceNo.Text & ",'" & UserControl11.lblDateTime.Text & "','" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ")"
                        '    cmd.ExecuteNonQuery()
                        'Else
                        If ds_Inv.Tables(0).Rows.Count - 1 >= i Then
                            Dim diff As Integer
                            cmd.CommandText = "Update InvoiceDetails set Qty=" & DataGridView1.Rows(i).Cells(2).Value & ",BatchNo='" & DataGridView1.Rows(i).Cells(3).Value & "',ExpDate='" & DataGridView1.Rows(i).Cells(4).Value & "',VAT=" & DataGridView1.Rows(i).Cells(5).Value & ",MRP=" & DataGridView1.Rows(i).Cells(6).Value & ",HSR=" & DataGridView1.Rows(i).Cells(7).Value & ",Total=" & DataGridView1.Rows(i).Cells(8).Value & ",SupplierId=" & txtSupplierID.Text & ",DoctorName='" & drpDrName.Text & "',CompanyInvoiceNo='" & txtCompanyInvoice.Text & "' where InvoiceNo=" & txtInvoiceNo.Text & " and YEAR(InvoiceDateTime)='" & InvoiceYear & "' and SNo=" & DataGridView1.Rows(i).Cells(0).Value & " and ProductName='" & DataGridView1.Rows(i).Cells(1).Value & "'"
                            cmd.ExecuteNonQuery()
                            If Val(DataGridView1.Rows(i).Cells(2).Value) > Val(dt.Rows(i).Item("Qty")) Then
                                diff = Val(DataGridView1.Rows(i).Cells(2).Value) - Val(dt.Rows(i).Item("Qty"))
                                cmd.CommandText = "Update StockDetails set CurrentQty=CurrentQty+" & diff & ",ExpDate='" & DataGridView1.Rows(i).Cells(4).Value & "',BatchNo='" & DataGridView1.Rows(i).Cells(3).Value & "' where InvoiceNo=" & txtInvoiceNo.Text & " and YEAR(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & DataGridView1.Rows(i).Cells(1).Value & "' and BatchNo='" & dt.Rows(i).Item("BatchNo") & "'"
                                cmd.ExecuteNonQuery()
                            Else
                                diff = Val(dt.Rows(i).Item("Qty")) - Val(DataGridView1.Rows(i).Cells(2).Value)
                                cmd.CommandText = "Update StockDetails set CurrentQty=CurrentQty-" & diff & ",ExpDate='" & DataGridView1.Rows(i).Cells(4).Value & "',BatchNo='" & DataGridView1.Rows(i).Cells(3).Value & "'  where InvoiceNo=" & txtInvoiceNo.Text & " and YEAR(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & DataGridView1.Rows(i).Cells(1).Value & "' and BatchNo='" & dt.Rows(i).Item("BatchNo") & "'"
                                cmd.ExecuteNonQuery()
                            End If
                        Else
                            cmd.CommandText = "insert into InvoiceDetails values(" & txtInvoiceNo.Text & ",'" & InvoiceDate & "','" & txtCompanyInvoice.Text & "','" & drpDrName.Text & "'," & txtSupplierID.Text & "," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ",'" & DataGridView1.Rows(i).Cells(3).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "'," & DataGridView1.Rows(i).Cells(5).Value & "," & DataGridView1.Rows(i).Cells(6).Value & "," & DataGridView1.Rows(i).Cells(7).Value & "," & DataGridView1.Rows(i).Cells(8).Value & ",'P','" & ds_Inv.Tables(0).Rows(0).Item("InvoiceDt").ToString & "','" & dtpCompanyDate.Text & "')"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "insert into StockDetails  values(" & txtInvoiceNo.Text & ",'" & InvoiceDate & "','" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & DataGridView1.Rows(i).Cells(3).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ")"
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    tranc.Commit()
                    con.Close()
                    MsgBox("Invoice Details Updated Successfully", MsgBoxStyle.Information, "Data Updated")
                    OldInvoiceNo = Nothing
                    cmdEdit.Text = "&Edit"
                    EnableEditDG()
                    cmdEdit.Image = My.Resources.Resource1.Edit
                    MakeShow()
                    CheckFlag = False
                    txtInvoiceNo.ReadOnly = False
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

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Try
            If cmdShow.Text = "&Cancel" Then
                'flag = False
                Cancel()
                MakeShow()
                ClearControls()
                cmdNew.Focus()
                OldInvoiceNo = Nothing
                CheckFlag = False
                'CheckMe()
            Else
                If txtInvoiceNo.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtInvoiceNo, "Enter InvoiceNo")
                    Exit Sub
                Else
                    InvoiceYear = InputBox("Please Enter the Year Of the Invoice Saved", "Enter YEAR")
                    ErrorProvider1.SetError(txtInvoiceNo, "")
                End If
                'flag = True
                DisplayInvoiceDetails()
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
    Sub DisplayInvoiceDetails()
        Try
            Dim dt As DataTable
            CheckConnection()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.CommandText = "Select * from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                OldInvoiceNo = dr("InvoiceNo")
                txtInvoiceNo.Text = dr("InvoiceNo")
                InvoiceDate = dr("InvoiceDateTime")
                drpDrName.Text = dr("DoctorName")
                txtSupplierID.Text = dr("SupplierID")
                txtCompanyInvoice.Text = dr("CompanyInvoiceNo")
                dtpCompanyDate.Text = CDate(dr("CompanyDate")).ToShortDateString
                MakeCancel()
                dr.Close()
                cmd.CommandText = "Select SupplierName from SupplierMaster where SupplierID=" & txtSupplierID.Text
                dr = cmd.ExecuteReader
                dr.Read()
                lblSupplierName.Text = dr("SupplierName")
                dr.Close()
                dt = SelectQuery("Select * from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and YEAR(InvoiceDateTime)='" & InvoiceYear & "' order by SNo")
                For i As Integer = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Insert(DataGridView1.Rows.Count, dt.Rows(i).Item("SNo"), dt.Rows(i).Item("ProductName"), dt.Rows(i).Item("Qty"), dt.Rows(i).Item("BatchNo"), dt.Rows(i).Item("ExpDate"), dt.Rows(i).Item("VAT"), dt.Rows(i).Item("MRP"), dt.Rows(i).Item("HSR"), dt.Rows(i).Item("Total"))
                Next
                CalcGrandTotal()
            Else
                MsgBox("Invoice Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
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

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        DisplayChange()
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        For i As Integer = 1 To DataGridView1.Rows.Count
            DataGridView1.Rows(i - 1).Cells(0).Value = i
        Next
        CalcGrandTotal()
    End Sub

    Private Sub drpProductName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpProductName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click
        If DataGridView1.Rows.Count > 0 Then
            Dim tcnt As Int16 = 0
            If cmdNew.Text = "&New" And cmdEdit.Text = "&Update" Then
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If drpProductName.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(1).Value.ToString.ToUpper And txtBatch.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(3).Value.ToString.ToUpper Then
                        tcnt = tcnt + 1
                        If tcnt > 1 Then
                            MsgBox("This Product is Already in List with this BatchNo, duplicate values cannot be added", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Sub
                        End If
                    End If
                Next
                Dim t As Integer = 0
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If drpProductName.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(1).Value.ToString.ToUpper And txtBatch.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(3).Value.ToString.ToUpper And t > 1 Then
                        MsgBox("This Product is Already in List with this BatchNo, duplicate values cannot be added", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    ElseIf drpProductName.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(1).Value.ToString.ToUpper And txtBatch.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(3).Value.ToString.ToUpper Then
                        t = t + 1
                    End If
                Next
                Dim dt As New DataTable
                Dim SQty, PQty, diffQty As Double
                Dim cmd As New SqlCommand
                cmd.Connection = con
                If drpProductName.Text <> DataGridView1.SelectedRows.Item(0).Cells(1).Value And txtBatch.Text <> DataGridView1.SelectedRows.Item(0).Cells(3).Value Then
                    MsgBox("Please Dont Change the Product", MsgBoxStyle.Exclamation, "Dont Change Product")
                Else
                    'CheckConnection()
                    'cmd.CommandText = "Select ISNULL(SUM(Qty),0) from DrugSlipDetails where InvoiceNo='" & txtInvoiceNo.Text & "-" & InvoiceYear & "' and ProductName='" & DataGridView1.SelectedRows.Item(0).Cells(1).Value & "' and BatchNo='" & DataGridView1.SelectedRows.Item(0).Cells(1).Value & "' and Status<>'C'"
                    'SQty = cmd.ExecuteScalar
                    'con.Close()
                    dt = SelectQuery("Select * from StockDetails where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & drpProductName.Text & "' and BatchNo='" & txtBatch.Text & "'")
                    If dt.Rows.Count > 0 Then
                        SQty = dt.Rows(0).Item("CurrentQty")
                    End If
                    Dim dt1 As New DataTable
                    dt1 = SelectQuery("Select * from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' and ProductName='" & drpProductName.Text & "' and BatchNo='" & txtBatch.Text & "'")
                    If dt1.Rows.Count > 0 Then
                        PQty = dt1.Rows(0).Item("Qty")
                    End If
                    diffQty = PQty - SQty
                    If diffQty > Val(txtQty.Text) Then
                        MsgBox("You Cannot Change this Item, because this product current Stock is " & SQty & " Qty in this invoice", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    Else
                        If Val(txtMRP.Text) < Val(txtHSR.Text) Then
                            MsgBox("MRP cannot be lesser than HSR")
                            Exit Sub
                        End If
                        DataGridView1.SelectedRows.Item(0).Cells(2).Value = txtQty.Text
                        DataGridView1.SelectedRows.Item(0).Cells(3).Value = txtBatch.Text
                        DataGridView1.SelectedRows.Item(0).Cells(4).Value = txtExpDate.Text
                        DataGridView1.SelectedRows.Item(0).Cells(5).Value = txtVat.Text
                        DataGridView1.SelectedRows.Item(0).Cells(6).Value = txtMRP.Text
                        DataGridView1.SelectedRows.Item(0).Cells(7).Value = txtHSR.Text
                        DataGridView1.SelectedRows.Item(0).Cells(8).Value = Val(txtHSR.Text) * Val(txtQty.Text)
                        CalcGrandTotal()
                    End If
                End If
            Else
                Dim t As Integer = 0
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If drpProductName.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(1).Value.ToString.ToUpper And txtBatch.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(3).Value.ToString.ToUpper And t > 1 Then
                        MsgBox("This Product is Already in List with this BatchNo, duplicate values cannot be added", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    ElseIf drpProductName.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(1).Value.ToString.ToUpper And txtBatch.Text.ToString.ToUpper = DataGridView1.Rows(i).Cells(3).Value.ToString.ToUpper Then
                        t = t + 1
                    End If
                Next
                If Val(txtMRP.Text) < Val(txtHSR.Text) Then
                    MsgBox("MRP cannot be lesser than HSR")
                    Exit Sub
                End If
                DataGridView1.SelectedRows.Item(0).Cells(2).Value = txtQty.Text
                DataGridView1.SelectedRows.Item(0).Cells(3).Value = txtBatch.Text
                DataGridView1.SelectedRows.Item(0).Cells(4).Value = txtExpDate.Text
                DataGridView1.SelectedRows.Item(0).Cells(5).Value = txtVat.Text
                DataGridView1.SelectedRows.Item(0).Cells(6).Value = txtMRP.Text
                DataGridView1.SelectedRows.Item(0).Cells(7).Value = txtHSR.Text
                DataGridView1.SelectedRows.Item(0).Cells(8).Value = Val(txtHSR.Text) * Val(txtQty.Text)
                CalcGrandTotal()
            End If
        End If
    End Sub

    Private Sub txtCompanyInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompanyInvoice.KeyDown
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

    Private Sub drpProductName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles drpProductName.Validating
        If drpProductName.FindStringExact(drpProductName.Text) < 0 Then
            ErrorProvider1.SetError(drpProductName, "Please Select Valid Product Name")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(drpProductName, "")
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

    Private Sub txtExpDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExpDate.KeyDown
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

    Private Sub cmdCancellBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancellBill.Click
        Try
            If cmdShow.Text = "&Cancel" And cmdNew.Text = "&New" And cmdEdit.Text = "&Edit" And OldInvoiceNo <> Nothing Then
                Dim count As Integer
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Try
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    cmd.CommandText = "Select count(*) from InvoiceDetails where Status='C' and InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "'"
                    count = cmd.ExecuteScalar
                    If count = 0 Then
                        cmd.CommandText = "Select count(*) from InvoiceDetails where and InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "'"
                        count = cmd.ExecuteScalar
                        If count > 0 Then
                            cmd.CommandText = "Select Count(*) from DrugSlipDetails where InvoiceNo='" & txtInvoiceNo.Text & "-" & InvoiceYear & "'"
                            count = cmd.ExecuteScalar
                            If IsDBNull(cmd.ExecuteScalar) = False Then
                                MsgBox("Sorry You have sold some products from this Invoice, so you cannot cancel this Invoice", MsgBoxStyle.Exclamation, "Cannot Cancel this")
                                Exit Sub
                            End If
                            If InvoiceDate <> System.DateTime.Now.ToShortDateString And UserRights = "Admin" Then
                                MsgBox("Sorry you cannot cancel this Invoice Contact your administrator", MsgBoxStyle.Exclamation, "Cannot Cancel")
                                Exit Sub
                            End If
                            Dim ds As New DialogResult
                            ds = MsgBox("Are You Sure to Cancel This Invoice", MsgBoxStyle.YesNo, "Cancel Invoice")
                            If ds = Windows.Forms.DialogResult.Yes Then
                                cmd.CommandText = "update InvoiceDetails set Status='C' where InvoiceNo='" & txtInvoiceNo.Text & "' and YEAR(InvoiceDateTime)='" & InvoiceYear & "'"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "Update StockDetails set CurrentQty=0 where InvoiceNo='" & txtInvoiceNo.Text & "' and YEAR(InvoiceDateTime)='" & InvoiceYear & "'"
                                cmd.ExecuteNonQuery()
                                tranc.Commit()
                                con.Close()
                                MakeShow()
                                MsgBox("This Invoice Cancelled Successfully", MsgBoxStyle.Information, Me.Text)
                            End If
                        Else
                            MsgBox("Cannot find Bill", MsgBoxStyle.Exclamation, Me.Text)
                        End If
                    Else
                        con.Close()
                        MsgBox("This Invoice was already Cancelled", MsgBoxStyle.Exclamation, Me.Text)
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

    Private Sub dtpCompanyDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpCompanyDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ContextMenuStrip1_ItemAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemEventArgs) Handles ContextMenuStrip1.ItemAdded

    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        If e.ClickedItem.Text = "Old Price History" Then
            If DataGridView1.RowCount = 1 Then
                frmOldPriceHistory.txtProductName.Text = DataGridView1.Rows(0).Cells(1).Value.ToString
                frmOldPriceHistory.txtProfitPercentage.Text = Math.Round(CDbl((((DataGridView1.Rows(0).Cells(6).Value - DataGridView1.Rows(0).Cells(7).Value) / DataGridView1.Rows(0).Cells(7).Value) * 100)), 2) & " %"
            ElseIf DataGridView1.RowCount > 1 Then
                frmOldPriceHistory.txtProductName.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value.ToString
                frmOldPriceHistory.txtProfitPercentage.Text = Math.Round(CDbl((((DataGridView1.SelectedRows.Item(0).Cells(6).Value - DataGridView1.SelectedRows.Item(0).Cells(7).Value) / DataGridView1.SelectedRows.Item(0).Cells(7).Value) * 100))) & " %"
            End If
            frmOldPriceHistory.ShowDialog()
        End If
    End Sub
    Private Sub ContextMenuStrip1_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Opened
        If DataGridView1.RowCount = 0 Then
            ContextMenuStrip1.Items(0).Enabled = False
        End If
    End Sub

    
End Class
