Imports System.Data.SqlClient
Public Class FindSupplierIDQuotation

    Private Sub txtSupplierName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSupplierName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim dt As New DataTable
        If Trim(txtSupplierName.Text) = "*" Then
            dt = SelectQuery("Select SupplierID,SupplierName,Street1,Street2,City from SupplierMaster")
        Else
            dt = SelectQuery("Select SupplierID,SupplierName,Street1,Street2,City from SupplierMaster where SupplierName LIKE '" & txtSupplierName.Text & "%'")
        End If
        DataGridView1.DataSource = dt.DefaultView
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.Focus()
        Else
            txtSupplierName.Focus()
        End If
    End Sub

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
                    QuotationEntry.lblSupplierName.Text = dr("SupplierName")
                    QuotationEntry.txtSupplierID.Text = dr("SupplierID")
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
        Me.Close()
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub FindSupplierIDQuotation_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtSupplierName.Focus()
    End Sub

    Private Sub FindSupplierIDQuotation_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        QuotationEntry.Enabled = True
        QuotationEntry.drpProductName.Focus()
    End Sub
End Class