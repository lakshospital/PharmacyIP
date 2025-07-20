Imports System.Data.SqlClient
Public Class DrugSlipBetweenDateConsolidate

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        CheckConnection()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from FromToDateTable"
        cmd.ExecuteNonQuery()
        If chkIncludeTime.Checked = False Then
            cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & "','" & dtpToDate.Text & "')"
        Else
            cmd.CommandText = "insert into FromToDateTable values('" & dtpfromDate.Text & " " & dtpFromTime.Text & "','" & dtpToDate.Text & " " & dtpToTime.Text & "')"
        End If
        cmd.ExecuteNonQuery()
        con.Close()

        Dim fd, td As String
        If chkIncludeTime.Checked = True Then
            fd = dtpfromDate.Text & " " & CDate(dtpFromTime.Text).ToString("hh:mm:ss tt").ToString
            td = dtpToDate.Text & " " & CDate(dtpToTime.Text).AddSeconds(59).ToString("hh:mm:ss tt").ToString
        Else
            fd = dtpfromDate.Text & " 12:00:00 AM"
            td = dtpToDate.Text & " 11:59:59 PM"
        End If

        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails' table. You can move, or remove it, as needed.
        If chkIncludeTime.Checked = True Then
            Me.DrugSlipDetailsTableAdapter.FillBy(Me.dsDrugSlipBetweenDate.DrugSlipDetails, fd, td)
        Else
            Me.DrugSlipDetailsTableAdapter.Fill(Me.dsDrugSlipBetweenDate.DrugSlipDetails, fd, td)
        End If
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails1' table. You can move, or remove it, as needed.
        Me.DrugSlipDetails1TableAdapter.Fill(Me.dsDrugSlipBetweenDate.DrugSlipDetails1, fd, td)
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.FromToDateTable' table. You can move, or remove it, as needed.
        Me.FromToDateTableTableAdapter.Fill(Me.dsDrugSlipBetweenDate.FromToDateTable)
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.DrugSlipDetails4' table. You can move, or remove it, as needed.
        If chkIncludeTime.Checked = False Then
            Me.DrugSlipDetails4TableAdapter.Fill(Me.dsDrugSlipBetweenDate.DrugSlipDetails4, fd, td)
        Else
            Me.DrugSlipDetails4TableAdapter.FillBy(Me.dsDrugSlipBetweenDate.DrugSlipDetails4, fd, td)
        End If
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.AmountReturn' table. You can move, or remove it, as needed.
        Me.AmountReturnTableAdapter.Fill(Me.dsDrugSlipBetweenDate.AmountReturn, fd, td)
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.SalesReturnTot' table. You can move, or remove it, as needed.
        If chkIncludeTime.Checked = False Then
            Me.SalesReturnTotTableAdapter.Fill(Me.dsDrugSlipBetweenDate.SalesReturnTot, fd, td)
        Else
            Me.SalesReturnTotTableAdapter.FillBy(Me.dsDrugSlipBetweenDate.SalesReturnTot, fd, td)
        End If
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.Cashless' table. You can move, or remove it, as needed.
        If chkIncludeTime.Checked = False Then
            Me.CashlessTableAdapter.Fill(Me.dsDrugSlipBetweenDate.Cashless, fd, td)
        Else
            Me.CashlessTableAdapter.FillBy(Me.dsDrugSlipBetweenDate.Cashless, fd, td)
        End If
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.AmountToReturn' table. You can move, or remove it, as needed.
        Me.AmountToReturnTableAdapter.Fill(Me.dsDrugSlipBetweenDate.AmountToReturn, fd, td)
        Me.ExcessAmountTableAdapter.Fill(Me.dsDrugSlipBetweenDate.ExcessAmount, fd)
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.Credit1' table. You can move, or remove it, as needed.
        Me.Credit1TableAdapter.Fill(Me.dsDrugSlipBetweenDate.Credit1, fd, td)
        'TODO: This line of code loads data into the 'dsDrugSlipBetweenDate.Credit2' table. You can move, or remove it, as needed.
        Me.Credit2TableAdapter.Fill(Me.dsDrugSlipBetweenDate.Credit2, fd, td)
        If chkIncludeTime.Checked = False Then
            Me.CancelBillsTableAdapter.Fill(Me.dsDrugSlipBetweenDate.CancelBills, fd, td)
        Else
            Me.CancelBillsTableAdapter.FillBy(Me.dsDrugSlipBetweenDate.CancelBills, fd, td)
        End If
        If chkIncludeTime.Checked = False Then
            Me.SalesReturnTotCashLessTableAdapter.Fill(Me.dsDrugSlipBetweenDate.SalesReturnTotCashLess, fd, td)
        Else
            Me.SalesReturnTotCashLessTableAdapter.FillBy(Me.dsDrugSlipBetweenDate.SalesReturnTotCashLess, fd, td)
        End If

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub DrugSlipBetweenDateConsolidate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

    End Sub
End Class