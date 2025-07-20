Imports System.Data.SqlClient
Public Class ProductGroupMaster

    Private Sub ProductGroupMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt = SelectQuery("Select * from ProductGroupMaster")
        If dt.Rows.Count > 0 Then
            ListBox1.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                ListBox1.Items.Add(dt.Rows(i).Item("GroupName"))
            Next
        Else
            ListBox1.Items.Clear()
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If ListBox1.FindString(Trim(txtProductGroupName.Text)) > 0 Then
            MsgBox("This Group Name Already Exist")
        Else
            ListBox1.Items.Add(txtProductGroupName.Text)
            txtProductGroupName.Text = ""
            txtProductGroupName.Focus()
        End If
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        If UserRights = "User" Then
            MsgBox("You dont have permission to remove a product Group")
            Exit Sub
        End If
        If ListBox1.SelectedIndex >= 0 Then
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim cmd As New SqlCommand
        cmd.Connection = con
        CheckConnection()
        cmd.CommandText = "delete from ProductGroupMaster"
        cmd.ExecuteNonQuery()
        For i As Integer = 0 To ListBox1.Items.Count - 1
            cmd.CommandText = "insert into ProductGroupMaster values('" & ListBox1.Items.Item(i).ToString & "')"
            cmd.ExecuteNonQuery()
        Next
        MsgBox("Product Group Saved Successfully", MsgBoxStyle.Information, "Saved")
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class