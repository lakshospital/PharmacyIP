Imports System.Data.SqlClient
Public Class CaseTypeMaster

    Private Sub CaseTypeMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt = SelectQuery("Select * from CaseTypeMaster")
        If dt.Rows.Count > 0 Then
            ListBox1.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                ListBox1.Items.Add(dt.Rows(i).Item("CaseName"))
            Next
        Else
            ListBox1.Items.Clear()
        End If
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If ListBox1.FindStringExact(Trim(txtCaseName.Text)) >= 0 Then
            MsgBox("This Case Name Already Exist")
            txtCaseName.Focus()
            txtCaseName.SelectAll()
        ElseIf txtCaseName.Text.Length = 0 Then
            MsgBox("Please Enter Case Type")
            txtCaseName.Focus()
        Else
            ListBox1.Items.Add(txtCaseName.Text)
            txtCaseName.Text = ""
            txtCaseName.Focus()
        End If
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        If ListBox1.SelectedIndex >= 0 Then
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim cmd As New SqlCommand
        cmd.Connection = con
        CheckConnection()
        cmd.CommandText = "delete from CaseTypeMaster"
        cmd.ExecuteNonQuery()
        For i As Integer = 0 To ListBox1.Items.Count - 1
            cmd.CommandText = "insert into CaseTypeMaster values('" & ListBox1.Items.Item(i).ToString & "')"
            cmd.ExecuteNonQuery()
        Next
        MsgBox("Case Names Saved Successfully", MsgBoxStyle.Information, "Saved")
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class