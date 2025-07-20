Imports System.Data.SqlClient
Public Class SupplierMaster
    Dim OldSupplierId As String
    'Dim flag As Boolean
    Dim CheckFlag As Boolean
    Sub ClearControls()
        txtSupplierID.Text = ""
        txtSupplierName.Text = ""
        txtStreetName1.Text = ""
        txtStreetName2.Text = ""
        txtCity.Text = ""
        txtPINCode.Text = ""
        txtEMail.Text = ""
        txtPhone.Text = ""
        txtTINNo.Text = ""
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
                txtSupplierName.Focus()
                CheckFlag = True
                'CheckMe()
            Else
                'flag = False
                CheckConnection()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "Select Max(SupplierID) from SupplierMaster"
                Dim sid As Double
                If IsDBNull(cmd.ExecuteScalar) = True Then
                    sid = 1
                Else
                    sid = cmd.ExecuteScalar
                    sid = sid + 1
                End If
                txtSupplierID.Text = sid
                cmd.CommandText = "insert into SupplierMaster values(" & txtSupplierID.Text & ",'" & txtSupplierName.Text & "','" & txtStreetName1.Text & "','" & txtStreetName2.Text & "','" & txtCity.Text & "','" & txtPINCode.Text & "','" & txtEMail.Text & "','" & txtPhone.Text & "','" & txtTINNo.Text & "')"
                cmd.ExecuteNonQuery()
                cmdNew.Text = "&New"
                cmdNew.Image = My.Resources.Resource1._New
                con.Close()
                MsgBox("Supplier Details Saved Successfully", MsgBoxStyle.Information, Me.Text)
                MakeShow()
                ClearControls()
                CheckFlag = False
                'CheckMe()
            End If
            OldSupplierId = Nothing
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("Supplier ID Already Exist, Please Try Again", MsgBoxStyle.Exclamation, Me.Text)
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
                If txtSupplierID.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtSupplierID, "Enter Course Code")
                    Exit Sub
                Else
                    ErrorProvider1.SetError(txtSupplierID, "")
                End If
                'flag = True
                'MakeCancel()
                DisplaySupplierDetails()
                If OldSupplierId = Nothing Then
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
                cmd.CommandText = "update SupplierMaster set SupplierName='" & txtSupplierName.Text & "',Street1='" & txtStreetName1.Text & "',Street2='" & txtStreetName2.Text & "',City='" & txtCity.Text & "',PINCode='" & txtPINCode.Text & "',eMail='" & txtEMail.Text & "',Phone='" & txtPhone.Text & "',TINNo='" & txtTINNo.Text & "' where SupplierID='" & txtSupplierID.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Supplier Details Updated Successfully", MsgBoxStyle.Information, "Data Updated")
                con.Close()
                OldSupplierId = Nothing
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
            cmd.CommandText = "Select * from SupplierMaster where SupplierID=" & txtSupplierID.Text
            cmd.Connection = con
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                OldSupplierId = dr("SupplierID")
                txtSupplierName.Text = dr("SupplierName")
                txtStreetName1.Text = dr("Street1")
                txtStreetName2.Text = dr("Street2")
                txtCity.Text = dr("City")
                txtPINCode.Text = dr("PINCode")
                txtEMail.Text = dr("eMail")
                txtPhone.Text = dr("Phone")
                txtTINNo.Text = dr("TINNO").ToString
                MakeCancel()
            Else
                MsgBox("Supplier Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
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
                OldSupplierId = Nothing
                CheckFlag = False
                'CheckMe()
            Else
                If txtSupplierID.Text = "" Then
                    MakeShow()
                    ErrorProvider1.SetError(txtSupplierID, "Enter Course Code")
                    Exit Sub
                Else
                    ErrorProvider1.SetError(txtSupplierID, "")
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
        FindSupplierIDDialog.Show()
    End Sub
End Class
