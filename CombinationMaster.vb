Imports System.Data.SqlClient

Public Class CombinationMaster

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If ListBox1.FindString(Trim(txtCombinationName.Text)) > 0 Then
            MsgBox("This Combination Name Already Exist")
        Else
            ListBox1.Items.Add(txtCombinationName.Text)
            txtCombinationName.Text = ""
            txtCombinationName.Focus()
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
        cmd.CommandText = "delete from CombinationMaster"
        cmd.ExecuteNonQuery()
        For i As Integer = 0 To ListBox1.Items.Count - 1
            cmd.CommandText = "insert into CombinationMaster values('" & ListBox1.Items.Item(i).ToString & "')"
            cmd.ExecuteNonQuery()
        Next
        con.Close()
        MsgBox("Combinations Saved Successfully", MsgBoxStyle.Information, "Saved")
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub CombinationMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt = SelectQuery("Select * from CombinationMaster")
        If dt.Rows.Count > 0 Then
            ListBox1.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                ListBox1.Items.Add(dt.Rows(i).Item("CombinationName"))
            Next
        Else
            ListBox1.Items.Clear()
        End If
    End Sub
End Class