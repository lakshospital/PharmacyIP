Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CrystalBillPrint

    Private Sub CrystalBillPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        crysBillNo = 2
        crysBillYear = "7/12/2010"
        Dim pdv As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim pv As New CrystalDecisions.Shared.ParameterValues
        Dim cryRpt As New ReportDocument
        cryRpt.PrintOptions.PaperSize = PaperSize.PaperEnvelopeC6
        cryRpt.Load("E:\Joe Samraj\MyProject\Pharmacy\Pharmacy\CrystalReport1.rpt")
        pdv.Value = crysBillNo
        pv.Add(pdv)
        cryRpt.DataDefinition.ParameterFields("BillNo").ApplyCurrentValues(pv)
        pdv.Value = crysBillYear
        pv.Add(pdv)
        cryRpt.DataDefinition.ParameterFields("BillDate").ApplyCurrentValues(pv)
        'cryRpt.Refresh()
        cryRpt.PrintToPrinter(1, True, 0, 0)
        Me.Close()


        ''Me.DrugSlipDetails1TableAdapter.FillBy2(Me.dsDrugSlipBetweenDate.DrugSlipDetails1, crysBillNo, crysBillYear)
        ''crystalReport21.Load("E:\Joe Samraj\MyProject\Pharmacy\Pharmacy\CrystalReport2.rpt")
        ''cryRpt.Load("E:\Joe Samraj\MyProject\Pharmacy\Pharmacy\CrystalReport1.rpt")
        'cryRpt.Load(System.IO.Directory.GetCurrentDirectory & "\CrystalReport1.rpt")
        'Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        'Dim crParameterFieldDefinition As ParameterFieldDefinition
        'Dim crParameterValues As New ParameterValues
        'Dim crParameterDiscreteValue As New ParameterDiscreteValue
        'crParameterDiscreteValue.Value = crysBillNo
        'crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields
        'crParameterFieldDefinition = crParameterFieldDefinitions.Item("BillNo")
        ''crParameterDiscreteValue.Value = crysBillYear
        'crParameterValues = crParameterFieldDefinition.CurrentValues





        'crParameterValues.Clear()
        ''crParameterValues1.Clear()
        'crParameterValues.Add(crParameterDiscreteValue)
        ''crParameterValues.Add(crParameterDiscreteValue1)
        'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        ''crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1)
        'CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()
        'cryRpt.PrintOptions.PaperSize = PaperSize.PaperEnvelopeItaly
        'cryRpt.PrintToPrinter(1, False, 1, 1)
        'Me.Close()
    End Sub

    Private Sub crystalReport11_InitReport(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class