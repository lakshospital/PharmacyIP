Public Class frmLogin

    Function validation() As Boolean
        If UsernameTextBox.Text.Length = 0 Then
            MsgBox("Enter User Name")
            Return False
        ElseIf UsernameTextBox.Text.Contains("'") = True Then
            MsgBox("Single quote should not be in the User name")
            Return False
        ElseIf PasswordTextBox.Text.Length = 0 Then
            MsgBox("Enter Password")
            Return False
        ElseIf PasswordTextBox.Text.Contains("'") = True Then
            MsgBox("Single quote should not be in the Password")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        Process()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = "Select Max(LastLoginTime) from LastLogin"
        cmd.Connection = con
        Dim LDate As System.DateTime
        CheckConnection()
        If IsDBNull(cmd.ExecuteScalar) = False Then
            LDate = cmd.ExecuteScalar
            If LDate > System.DateTime.Now Then
                con.Close()
                MsgBox("Please Check your time, Contact your administrator", MsgBoxStyle.Information, "Time is not correct")
                End
            Else
            End If
        End If
        cmd.CommandText = "delete from LastLogin"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into LastLogin values('" & System.DateTime.Now & "')"
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Sub Process()
        If validation() = True Then
            Try
                'Check whether the User Name and Password are correct
                UserName = UsernameTextBox.Text
                'LoginTime = DateAndTime.Now
                Dim LoginAs As String
                If Admin.Checked = True Then
                    UserRights = "Admin"
                    LoginAs = Admin.Text.Trim
                    'frmMain.MenuStrip1.Items("AdminToolStripMenuItem").Visible = True
                    Main.ExcessShortageToolStripMenuItem.Visible = True
                ElseIf Pharmacy.Checked = True Then
                    UserRights = "Pharmacy"
                    LoginAs = Pharmacy.Text.Trim
                    'frmMain.MenuStrip1.Items("AdminToolStripMenuItem").Visible = False
                    Main.ExcessShortageToolStripMenuItem.Visible = False
                Else
                    UserRights = "User"
                    LoginAs = User.Text.Trim
                    'frmMain.MenuStrip1.Items("AdminToolStripMenuItem").Visible = False
                    Main.ExcessShortageToolStripMenuItem.Visible = False
                End If
                Dim dt As DataTable = SelectQuery("Select * from UserDetails where UserName='" & UsernameTextBox.Text.Trim & "' and Password='" & PasswordTextBox.Text.Trim & "' and Rights='" & LoginAs & "'")
                If dt.Rows.Count > 0 Then
                    'sql = "Select max(LogOutDateTime) from LoginDetails"
                    'Dim maxdate As System.Object = AggregateQuery(sql)
                    'If IsDBNull(maxdate) = True Then
                    '    'Prompt for confirming whether the system time is correct when a User login for the first time
                    '    Dim result As DialogResult
                    '    result = MsgBox("Is this your current date and time? " & DateAndTime.Now.ToString, MsgBoxStyle.YesNo, "Check Your Time")
                    '    If result = Windows.Forms.DialogResult.Yes Then
                    '        'if the user said true then show main form
                    '        sql = "insert into LoginDetails values('" & UserName & "','" & LoginTime & "',NULL)"
                    '        Dim i As Integer = DML(sql)
                    '        Me.Hide()
                    '        frmMain.Show()
                    '    Else
                    '        'if it is not current date time then end
                    '        MsgBox("Please Change System Time On the System Tray then Login", MsgBoxStyle.Information, "Change System Time")
                    '        End
                    '    End If
                    Main.Show()
                    Me.Hide()
                Else
                    'if any user user had already logined then compare the system date time with last user logout time
                    '    Dim LastLogOutTime As Date
                    '    LastLogOutTime = maxdate
                    '    If LastLogOutTime <= DateAndTime.Now Then
                    '        Sql = "insert into LoginDetails values('" & UserName & "','" & LoginTime & "',NULL)"
                    '        Dim i As Integer = DML(Sql)
                    '        Me.Hide()
                    '        frmMain.Show()
                    '    Else
                    '        MsgBox("Please Change System Time On the System Tray then Login", MsgBoxStyle.Information, "Change System Time")
                    '        End
                    '    End If
                    'End If
                    'Else
                    MsgBox("Please Enter a valid UserName and Password", MsgBoxStyle.Exclamation, "Unauthorized user")
                    UsernameTextBox.Focus()
                End If
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub frmLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UsernameTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue >= 65 And e.KeyValue <= 90) Or (e.KeyValue >= 96 And e.KeyValue <= 122) Or (e.KeyValue = 8) Or (e.KeyValue = 46) Or (e.KeyValue = 37) Or (e.KeyValue = 39) Or (e.KeyValue = 35) Or (e.KeyValue = 36) Then
            e.SuppressKeyPress = False
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub PasswordTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue >= 65 And e.KeyValue <= 90) Or (e.KeyValue >= 96 And e.KeyValue <= 122) Or (e.KeyValue = 8) Or (e.KeyValue = 46) Or (e.KeyValue = 37) Or (e.KeyValue = 39) Or (e.KeyValue = 35) Or (e.KeyValue = 36) Then
            e.SuppressKeyPress = False
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub User_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles User.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue >= 65 And e.KeyValue <= 90) Or (e.KeyValue >= 96 And e.KeyValue <= 122) Or (e.KeyValue = 8) Or (e.KeyValue = 46) Or (e.KeyValue = 37) Or (e.KeyValue = 39) Or (e.KeyValue = 35) Or (e.KeyValue = 36) Then
            e.SuppressKeyPress = False
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub Admin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Admin.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue >= 65 And e.KeyValue <= 90) Or (e.KeyValue >= 96 And e.KeyValue <= 122) Or (e.KeyValue = 8) Or (e.KeyValue = 46) Or (e.KeyValue = 37) Or (e.KeyValue = 39) Or (e.KeyValue = 35) Or (e.KeyValue = 36) Then
            e.SuppressKeyPress = False
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub
End Class