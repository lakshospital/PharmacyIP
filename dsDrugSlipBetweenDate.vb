Partial Class dsDrugSlipBetweenDate
    Partial Class DrugSlipDetailsDataTable

        Private Sub DrugSlipDetailsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            'If (e.Column.ColumnName = Me.Column.ColumnName) Then
            '    'Add user code here
            'End If

        End Sub

    End Class

    Partial Class Credit2DataTable

        Private Sub Credit2DataTable_Credit2RowChanging(ByVal sender As System.Object, ByVal e As Credit2RowChangeEvent) Handles Me.Credit2RowChanging

        End Sub

    End Class

    Partial Class Credit1DataTable

        Private Sub Credit1DataTable_Credit1RowChanging(ByVal sender As System.Object, ByVal e As Credit1RowChangeEvent) Handles Me.Credit1RowChanging

        End Sub

    End Class

    Partial Class ReportTitlesDataTable

        Private Sub ReportTitlesDataTable_ReportTitlesRowChanging(ByVal sender As System.Object, ByVal e As ReportTitlesRowChangeEvent) Handles Me.ReportTitlesRowChanging

        End Sub

    End Class

End Class
