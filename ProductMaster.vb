Imports System.Data.SqlClient
Public Class ProductMaster
    Dim OldProductName As String
    'Dim flag As Boolean
    Dim CheckFlag As Boolean
    Sub ClearControls()
        txtProductName.Text = ""
        drpProductGroup.Text = ""
        txtRackNo.Text = ""
        txtMinimumStockToMaintain.Text = ""
        txtManufacturer.Text = ""
        ErrorProvider1.Clear()
    End Sub
    Sub MakeCancel()
        cmdShow.Text = "&Cancel"
        cmdShow.Image = My.Resources.Resource1.Cancel
    End Sub
    Sub Cancel()
        cmdNew.Text = "&New"
        cmdNew.Image = My.Resources.Resource1._New
        cmdEdit.Text = "&Edit"
        cmdEdit.Image = My.Resources.Resource1.Edit
        cmdShow.Text = "&Show"
        cmdShow.Image = My.Resources.Resource1.Search
        ErrorProvider1.Clear()
    End Sub
    Sub MakeShow()
        cmdShow.Text = "&Show"
        cmdShow.Image = My.Resources.Resource1.Search
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
                txtProductName.Focus()
                CheckFlag = True
                'CheckMe()
            Else
                'flag = False
                CheckConnection()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into ProductMaster values('" & txtProductName.Text & "','" & drpProductGroup.Text & "','" & txtRackNo.Text & "'," & txtMinimumStockToMaintain.Text & ",'" & drpDoctorName.Text & "','" & drpCombination.Text & "','" & txtManufacturer.Text & "','" & drpScheduleH.Text & "')"
                cmd.ExecuteNonQuery()
                cmdNew.Text = "&New"
                cmdNew.Image = My.Resources.Resource1._New
                con.Close()
                MsgBox("Product Details Saved Successfully", MsgBoxStyle.Information, Me.Text)
                MakeShow()
                ClearControls()
                CheckFlag = False
                'CheckMe()
            End If
            OldProductName = Nothing
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("ProductName Already Exist, Please Enter Another Name", MsgBoxStyle.Exclamation, Me.Text)
            Else
                MsgBox(ex.Message)
            End If
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
                If txtProductName.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtProductName, "Enter Product Name")
                    Exit Sub
                Else
                    ErrorProvider1.SetError(txtProductName, "")
                End If
                'flag = True
                'MakeCancel()
                DisplaySupplierDetails()
                If OldProductName = Nothing Then
                    Exit Sub
                End If
                cmdEdit.Text = "&Update"
                cmdEdit.Image = My.Resources.Resource1.Update
                CheckFlag = True
                'CheckMe()
            Else
                'flag = False
                CheckConnection()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "update ProductMaster set ProductName='" & txtProductName.Text & "',ProductGroup='" & drpProductGroup.Text & "',RackNo='" & txtRackNo.Text & "',MinimumStock=" & txtMinimumStockToMaintain.Text & ",DoctorName='" & drpDoctorName.Text & "',CombinationName='" & drpCombination.Text & "',Manufacturer='" & txtManufacturer.Text & "',IsScheduleH='" & drpScheduleH.Text & "' where ProductName='" & OldProductName & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Product Details Updated Successfully", MsgBoxStyle.Information, "Data Updated")
                con.Close()
                OldProductName = Nothing
                cmdEdit.Text = "&Edit"
                cmdEdit.Image = My.Resources.Resource1.Edit
                MakeShow()
                CheckFlag = False
                'CheckMe()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub DisplaySupplierDetails()
        Try
            CheckConnection()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.CommandText = "Select * from ProductMaster where ProductName='" & txtProductName.Text & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                OldProductName = dr("ProductName")
                txtProductName.Text = dr("ProductName")
                drpProductGroup.Text = dr("ProductGroup")
                txtRackNo.Text = dr("RackNo")
                txtMinimumStockToMaintain.Text = dr("MinimumStock")
                drpDoctorName.Text = dr("DoctorName").ToString()
                drpCombination.Text = dr("CombinationName").ToString()
                txtManufacturer.Text = dr("Manufacturer").ToString()
                MakeCancel()
            Else
                MsgBox("Product Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
                MakeShow()
            End If
            dr.Close()
            con.Close()
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
                OldProductName = Nothing
                CheckFlag = False
                'CheckMe()
            Else
                If txtProductName.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtProductName, "Enter Product Name")
                    Exit Sub
                Else
                    ErrorProvider1.SetError(txtProductName, "")
                End If
                'flag = True
                DisplaySupplierDetails()
                CheckFlag = True
                'CheckMe()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub SupplierMaster_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cmdNew.Focus()
    End Sub
    Private Sub GlassButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlassButton1.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindProductNameDialog.Show()
    End Sub
    Private Sub ProductMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt = SelectQuery("Select GroupName from ProductGroupMaster")
        If dt.Rows.Count > 0 Then
            drpProductGroup.DataSource = dt
            drpProductGroup.DisplayMember = "GroupName"
        End If
        dt = SelectQuery("Select DoctorName from DoctorNameMaster")
        drpDoctorName.DisplayMember = "DoctorName"
        drpDoctorName.DataSource = dt
        dt = SelectQuery("Select CombinationName from CombinationMaster")
        drpCombination.DisplayMember = "CombinationName"
        drpCombination.DataSource = dt
        drpScheduleH.Text = "YES"
    End Sub

    Private Sub txtProductName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpProductGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpProductGroup.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtRackNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRackNo.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtMinimumStockToMaintain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMinimumStockToMaintain.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpDoctorName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpDoctorName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub drpCombination_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpCombination.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class