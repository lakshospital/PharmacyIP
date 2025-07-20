Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class FindProductNameDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim dt As New DataTable
        If Trim(txtProductName.Text) = "*" Then
            dt = SelectQuery("Select * from ProductMaster")
        Else
            dt = SelectQuery("Select * from ProductMaster where ProductName LIKE '" & txtProductName.Text & "%'")
        End If
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt.DefaultView
        Else
            DataGridView1.Rows.Clear()
        End If
    End Sub

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If DataGridView1.Rows.Count > 0 And DataGridView1.SelectedRows.Count > 0 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            ProductMaster.txtProductName.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            Try
                CheckConnection()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.CommandText = "Select * from ProductMaster where ProductName='" & DataGridView1.SelectedRows.Item(0).Cells(0).Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    'SupplierMaster.OldSupplierId = dr("SupplierID")
                    ProductMaster.txtProductName.Text = dr("ProductName")
                    ProductMaster.drpProductGroup.Text = dr("ProductGroup")
                    ProductMaster.txtMinimumStockToMaintain.Text = dr("MinimumStock")
                    'ProductMaster.drpScheduleH.Text = dr("IsScheduleH")


                    'MakeCancel()
                Else
                    MsgBox("Product Details Not Found", MsgBoxStyle.Exclamation, Me.Text)
                    'MakeShow()
                End If
                dr.Close()
                ProductMaster.DisplaySupplierDetails()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub FindProductNameDialog_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtProductName.Focus()
    End Sub

    Private Sub FindProductNameDialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ProductMaster.Enabled = True
    End Sub

    Private Sub FindProductNameDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProductMaster.Enabled = False
    End Sub

    Private Sub Cancel_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
