Imports System.data.SqlClient
Public Class OTTemplate
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

    Function DisplayTemplateDetails() As Boolean
        Try
            Dim dt As DataTable
            CheckConnection()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.CommandText = "Select * from OTTemplate where DrName='" & drpDrName.Text & "' and CaseType='" & drpCase.Text & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                'OldInvoiceNo = dr("InvoiceNo")
                'txtInvoiceNo.Text = dr("InvoiceNo")
                'InvoiceDate = dr("InvoiceDateTime")
                'drpDrName.Text = dr("DoctorName")
                'txtSupplierID.Text = dr("SupplierID")
                'txtCompanyInvoice.Text = dr("CompanyInvoiceNo")
                'dtpCompanyDate.Text = CDate(dr("CompanyDate")).ToShortDateString
                'MakeCancel()
                'dr.Close()
                'cmd.CommandText = "Select SupplierName from SupplierMaster where SupplierID=" & txtSupplierID.Text
                'dr = cmd.ExecuteReader
                'dr.Read()
                'lblSupplierName.Text = dr("SupplierName")
                dr.Close()
                dt = SelectQuery("Select * from OTTemplate where DrName='" & drpDrName.Text & "' and CaseType='" & drpCase.Text & "'")
                For i As Integer = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Insert(DataGridView1.Rows.Count, dt.Rows(i).Item("SNo"), dt.Rows(i).Item("ProductName"), dt.Rows(i).Item("Qty"))
                Next
                'CalcGrandTotal()
            Else
                MsgBox("Template Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
                ClearControls()
                'txtInvoiceNo.Focus()
                con.Close()
                MakeShow()
                Return False
            End If
            con.Close()
            Return True
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
    Sub ClearControls()
        DataGridView1.Rows.Clear()
        DataGridView1.AllowUserToAddRows = False
        'txtInvoiceNo.Text = ""
        'txtCompanyInvoice.Text = ""
        'txtSupplierID.Text = ""
        'lblGrandTotal.Text = ""
        'lblSupplierName.Text = ""
        'txtBatch.Text = ""
        'txtExpDate.Text = ""
        'txtHSR.Text = ""
        'txtMRP.Text = ""
        txtQty.Text = ""
        'txtVat.Text = ""
        ErrorProvider1.Clear()
    End Sub
    Sub MakeCancel()
        'cmdShow.Text = "&Cancel"
        'cmdShow.Image = My.Resources.Resource1.Cancel
    End Sub
    Sub MakeShow()
        'cmdShow.Text = "&Show"
        'cmdShow.Image = My.Resources.Resource1.Search
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
                'txtCompanyInvoice.Focus()
                'CheckFlag = True
                'txtInvoiceNo.ReadOnly = True
                'CheckMe()
                drpDrName.Select()
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
                    Dim da As New SqlDataAdapter("Select * from OTTemplate  where DrName='" & drpDrName.Text & "' and CaseType='" & drpCase.Text & "'", con)
                    Dim ds As New DataSet
                    da.SelectCommand.Transaction = tranc
                    da.Fill(ds)
                    'dt = SelectQuery("Select InvoiceNo from InvoiceDetails where SupplierID=" & txtSupplierID.Text & " and CompanyInvoiceNo='" & txtCompanyInvoice.Text & "' and YEAR(InvoiceDateTime)='" & System.DateTime.Now.Year & "'")
                    If ds.Tables(0).Rows.Count > 0 Then
                        MsgBox("This Template Entered Already!")
                        Exit Sub
                    End If
                    'cmd.CommandText = "Select MAX(InvoiceNo) from InvoiceDetails where YEAR(InvoiceDateTime)='" & System.DateTime.Now.Year & "'"
                    'If IsDBNull(cmd.ExecuteScalar) Then
                    '    InvoiceNo = 1
                    'Else
                    '    InvoiceNo = cmd.ExecuteScalar
                    '    InvoiceNo = InvoiceNo + 1
                    'End If
                    ''txtInvoiceNo.Text = InvoiceNo
                    'Dim InvD As String = CDate(UserControl11.lblDateTime.Text).ToShortDateString
                    'Dim InvD1 As String = CDate(UserControl11.lblDateTime.Text)

                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "insert into OTTemplate values('" & drpDrName.Text & "','" & drpCase.Text & "'," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ")"
                        cmd.ExecuteNonQuery()
                        'cmd.CommandText = "insert into StockDetails  values(" & txtInvoiceNo.Text & ",'" & InvD & "','" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & DataGridView1.Rows(i).Cells(3).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ")"
                        'cmd.ExecuteNonQuery()
                    Next
                    tranc.Commit()
                    con.Close()
                    cmdNew.Text = "&New"
                    cmdNew.Image = My.Resources.Resource1._New
                    MsgBox("Template Details Saved Successfully", MsgBoxStyle.Information, Me.Text)
                    MakeShow()
                    'ClearControls()
                    'CheckFlag = False
                    'CheckMe()
                    'txtInvoiceNo.ReadOnly = False
                Catch ex As Exception
                    tranc.Rollback()
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                'flag = False
            End If
            'OldInvoiceNo = Nothing
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub OTTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        dt = SelectQuery("Select * from DoctorNameMaster")
        drpDrName.DataSource = dt
        drpDrName.DisplayMember = "DoctorName"
        'dt.Clear()
        dt = SelectQuery("Select * from ProductMaster")
        drpProductName.DataSource = dt
        drpProductName.DisplayMember = "ProductName"

        dt = SelectQuery("Select CaseName from CaseTypeMaster")
        drpCase.DataSource = dt
        drpCase.DisplayMember = "CaseName"

        cmdNew.Select()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If cmdEdit.Text = "&Edit" Then
                cmdNew.Text = "&New"
                cmdNew.Image = My.Resources.Resource1._New
                DataGridView1.Rows.Clear()
                DataGridView1.AllowUserToAddRows = False
                'txtCompanyInvoice.Text = ""
                'txtSupplierID.Text = ""
                lblGrandTotal.Text = ""
                'lblSupplierName.Text = ""
                'txtBatch.Text = ""
                'txtExpDate.Text = ""
                'txtHSR.Text = ""
                'txtMRP.Text = ""
                txtQty.Text = ""
                'txtVat.Text = ""

                'If txtInvoiceNo.Text = "" Then
                '    MakeShow()
                '    ErrorProvider1.SetError(txtInvoiceNo, "Enter InvoiceNo")
                '    txtInvoiceNo.Focus()
                '    Exit Sub
                'Else
                '    InvoiceYear = InputBox("Please Enter the Year Of the Invoice Saved", "Enter YEAR")
                '    ErrorProvider1.SetError(txtInvoiceNo, "")
                'End If
                'flag = True
                'MakeCancel()
                If DisplayTemplateDetails() = False Then
                    Exit Sub
                End If
                'If UserName.ToString.ToUpper = "PHARMACIST" Then
                '    Dim ts As TimeSpan
                '    ts = System.DateTime.Now.Date.Subtract(InvoiceDate.Date)
                '    If CInt(ts.TotalDays) > 1 Or CInt(ts.TotalDays) < 0 Then
                '        DisableEditDG()
                '        MsgBox("Sorry You cannot Edit the Invoice, Contact your Administrator", MsgBoxStyle.Exclamation, Me.Text)
                '        Exit Sub
                '    End If
                '    EnableEditDG()
                'ElseIf InvoiceDate.Date <> System.DateTime.Now.Date And UserRights <> "Admin" Then
                '    DisableEditDG()
                '    MsgBox("Sorry You cannot Edit the Invoice, Contact your Administrator", MsgBoxStyle.Exclamation, Me.Text)
                '    Exit Sub
                'End If
                'DisplayChange()
                'If OldInvoiceNo = Nothing Or InvoiceYear = Nothing Then
                '    Exit Sub
                'End If
                cmdEdit.Text = "&Update"
                'DisableEditDG()
                EnableEditDG()
                DataGridView1.AllowUserToAddRows = False
                cmdEdit.Image = My.Resources.Resource1.Update

                DataGridView1.AllowUserToDeleteRows = True
                'CheckMe()
            Else
                'flag = False
                'Dim da_Inv As New SqlDataAdapter("Select * from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' order by SNo", con)
                'Dim ds_Inv As New DataSet
                'da_Inv.Fill(ds_Inv)
                'Dim dt As New DataTable
                'dt = SelectQuery("Select * from InvoiceDetails where InvoiceNo=" & txtInvoiceNo.Text & " and Year(InvoiceDateTime)='" & InvoiceYear & "' order by SNo")
                CheckConnection()
                Dim tranc As SqlTransaction
                tranc = con.BeginTransaction
                Try
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.Transaction = tranc
                    cmd.CommandText = "Delete from OTTemplate where DrName='" & drpDrName.Text & "' and CaseType='" & drpCase.Text & "'"
                    cmd.ExecuteNonQuery()
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "insert into OTTemplate values('" & drpDrName.Text & "','" & drpCase.Text & "'," & DataGridView1.Rows(i).Cells(0).Value & ",'" & DataGridView1.Rows(i).Cells(1).Value & "'," & DataGridView1.Rows(i).Cells(2).Value & ")"
                        cmd.ExecuteNonQuery()
                    Next
                    tranc.Commit()
                    con.Close()
                    MsgBox("Template Details Updated Successfully", MsgBoxStyle.Information, "Data Updated")
                    'OldInvoiceNo = Nothing
                    cmdEdit.Text = "&Edit"
                    EnableEditDG()
                    cmdEdit.Image = My.Resources.Resource1.Edit
                    MakeShow()
                    'CheckFlag = False
                    'txtInvoiceNo.ReadOnly = False
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click

        If Val(txtQty.Text) <= 0 Then
            MsgBox("Please Enter Valid Qty", MsgBoxStyle.Exclamation, Me.Text)
            txtQty.Text = ""
            txtQty.Focus()
            Exit Sub
        End If

        'Dim total As Double
        'total = Val(txtQty.Text) * Val(txtMRP.Text)
        'DataGridView1.Rows.Insert(0, Val(DataGridView1.Rows.Count + 1), drpProductName.Text, txtQty.Text, txtBatch.Text, txtExpDate.Text, txtVat.Text, txtMRP.Text, txtHSR.Text, total)
        DataGridView1.Rows.Insert(DataGridView1.Rows.Count, Val(DataGridView1.Rows.Count + 1), drpProductName.Text, txtQty.Text)
        drpProductName.Focus()
        txtQty.Text = ""
        DataGridView1.CurrentCell = DataGridView1.Item(1, DataGridView1.Rows.Count - 1)
    End Sub

    Private Sub drpProductName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpProductName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
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

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        For i As Integer = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).Cells(0).Value = (i + 1)
        Next
    End Sub
End Class