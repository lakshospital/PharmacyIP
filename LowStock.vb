Public Class LowStock

    Private Sub LowStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim arr As New ArrayList
        arr.Add("All")
        dt = SelectQuery("SELECT GroupName FROM ProductGroupMaster")
        For i As Integer = 0 To dt.Rows.Count - 1
            arr.Add(dt.Rows(i).Item("GroupName"))
        Next
        drpProductGroup.DataSource = arr
        
    End Sub

  

    Private Sub drpProductGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpProductGroup.SelectedIndexChanged
        'TODO: This line of code loads data into the 'dsLowStock.DrugSlipDetails1' table. You can move, or remove it, as needed.
        Dim fd, td As New System.DateTime
        fd = System.DateTime.Now.ToShortDateString
        Dim ts As New TimeSpan
        fd = System.DateTime.Now.Subtract(TimeSpan.FromDays(30)).ToShortDateString
        td = System.DateTime.Now.ToShortDateString
        If drpProductGroup.Text = "All" Then
            Me.DrugSlipDetails1TableAdapter.Fill(Me.dsLowStock.DrugSlipDetails1, fd, td)
        Else
            Me.DrugSlipDetails1TableAdapter.FillBy(Me.dsLowStock.DrugSlipDetails1, fd, td, drpProductGroup.Text)
        End If


        Me.ReportViewer1.RefreshReport()
    End Sub
End Class