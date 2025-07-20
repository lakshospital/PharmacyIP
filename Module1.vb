Imports System.Data.SqlClient
Module Module1
    Public con As New SqlConnection("Data Source=DESKTOP-A674QQN\SQLEXPRESS01;Initial Catalog=InPatient_PharmcyDB;User ID=lhs2;Password=lhs2")

    'Public con As New SqlConnection("Data Source=SAM-PC\SQLExpress;Initial Catalog=PharmacyDB;Integrated Security=True")
    Public con1 As New SqlConnection("Data Source=SERVER\SQLEXPRESS;Initial Catalog=LaskhmiHospital;Persist Security Info=True;User ID=sa;Password=''")
    'Public con1 As New SqlConnection("Data Source=SAM-PC\SQLExpress;Initial Catalog=LakshmiHospitalDB;Integrated Security=True")
    Public UserRights, UserName As String
    Public crysBillNo, crysBillYear As String
    Public PrinterName As String
End Module
