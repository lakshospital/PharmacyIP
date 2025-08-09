Imports System.Data.SqlClient
Imports System.Configuration

Module Module1
    Dim connStr As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
    Dim connStrIPBilling As String = ConfigurationManager.ConnectionStrings("LakshmiHospital.My.MySettings.LakshmiHospitalDBConnectionString").ConnectionString

    ' Now you can use connStr to create your SqlConnection
    Public con As New SqlConnection(connStr)
    'Public con1 As New SqlConnection("Data Source=SERVER\SQLEXPRESS;Initial Catalog=LaskhmiHospital;Persist Security Info=True;User ID=sa;Password=''")
    Public con1 As New SqlConnection(connStrIPBilling)

    'Public con1 As New SqlConnection("Data Source=SAM-PC\SQLExpress;Initial Catalog=LakshmiHospitalDB;Integrated Security=True")
    Public UserRights, UserName As String
    Public crysBillNo, crysBillYear As String
    Public PrinterName As String
End Module
