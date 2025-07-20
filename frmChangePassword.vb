Public Class frmChangePassword

  
    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt = SelectQuery("Select * from UserDetails")
        drpUserName.DataSource = dt.DefaultView
        drpUserName.DisplayMember = "UserName"
        drpUserName.ValueMember = "UserName"
    End Sub

    Private Sub cmdChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePassword.Click
        If Validation() = True Then
            Dim dt As New DataTable
            dt = SelectQuery("Select * from UserDetails where UserName='" & drpUserName.Text & "' and Password='" & txtOldPassword.Text & "'")
            If dt.Rows.Count > 0 Then
                Dim cmd As New SqlClient.SqlCommand("Update UserDetails set Password='" & txtNewPassword.Text & "' where UserName='" & drpUserName.Text & "'", con)
                CheckConnection()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Password changed successfully", MsgBoxStyle.Information)
                txtConfirmPassword.Text = ""
                txtNewPassword.Text = ""
                txtOldPassword.Text = ""
            Else
                MsgBox("Old Password is not correct", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub
    Function Validation() As Boolean
        If txtOldPassword.Text.Length = 0 Then
            ErrorProvider1.SetError(txtOldPassword, "Please Enter Old Password")
            Return False
        ElseIf txtNewPassword.Text <> txtConfirmPassword.Text Then
            ErrorProvider1.SetError(txtNewPassword, "Both the password are not same")
            Return False
        ElseIf txtNewPassword.Text.Length < 8 Then
            ErrorProvider1.SetError(txtNewPassword, "Password length should be minimum 8 letters")
            Return False
        End If
        ErrorProvider1.Clear()
        Return True
    End Function
End Class