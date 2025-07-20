Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class FindSupplierIDDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If DataGridView1.Rows.Count > 0 And DataGridView1.SelectedRows.Count > 0 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            SupplierMaster.txtSupplierID.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            Try
                CheckConnection()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.CommandText = "Select * from SupplierMaster where SupplierID=" & DataGridView1.SelectedRows.Item(0).Cells(0).Value
                cmd.Connection = con
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    'SupplierMaster.OldSupplierId = dr("SupplierID")
                    SupplierMaster.txtSupplierName.Text = dr("SupplierName")
                    SupplierMaster.txtStreetName1.Text = dr("Street1")
                    SupplierMaster.txtStreetName2.Text = dr("Street2")
                    SupplierMaster.txtCity.Text = dr("City")
                    SupplierMaster.txtPINCode.Text = dr("PINCode")
                    SupplierMaster.txtEMail.Text = dr("eMail")
                    SupplierMaster.txtPhone.Text = dr("Phone")
                    'MakeCancel()
                Else
                    MsgBox("Supplier Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
                    'MakeShow()
                End If
                dr.Close()
                SupplierMaster.DisplaySupplierDetails()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FindSupplierIDDialog_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtSupplierName.Focus()
    End Sub

    Private Sub FindSupplierIDDialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SupplierMaster.Enabled = True
    End Sub

    Private Sub FindSupplierIDDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SupplierMaster.Enabled = False
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim dt As New DataTable
        If Trim(txtSupplierName.Text) = "*" Then
            dt = SelectQuery("Select SupplierID,SupplierName,Street1,Street2,City from SupplierMaster")
        Else
            dt = SelectQuery("Select SupplierID,SupplierName,Street1,Street2,City from SupplierMaster where SupplierName LIKE '" & txtSupplierName.Text & "%'")
        End If
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt.DefaultView
        Else
            DataGridView1.Rows.Clear()
        End If
    End Sub

    Private Sub txtSupplierName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSupplierName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdShow_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdShow.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub
End Class
