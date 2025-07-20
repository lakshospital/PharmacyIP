Imports System.io
Public NotInheritable Class SplashScreen1
    Dim J As Integer
    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If File.Exists("E:\PrinterInfo.txt") = True Then
            'Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader("E:\PrinterInfo.txt")
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            PrinterName = sr.ReadLine()
            sr.Close()
        Else
            PrinterName = ""
        End If
        

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        'Copyright info
        'Try
        '    If File.Exists("C:\WINDOWS\AuoInfo.txt") = True Then
        '        ' Create an instance of StreamReader to read from a file.
        '        Dim sr As StreamReader = New StreamReader("C:\WINDOWS\AuoInfo.txt")
        '        Dim line As String
        '        ' Read and display the lines from the file until the end 
        '        ' of the file is reached.
        '        line = sr.ReadLine()
        '        sr.Close()
        '        sql = "select * from keycode"
        '        Dim dt As DataTable = SelectQuery(sql)
        '        Dim key As String = dt.Rows(0).Item("KeyCode").ToString
        '        If line = key Then
        '            Dim i As Integer
        '            'sql = "Update AdvanceBillNumbers set Status='A' where Status='B'"
        '            'i = DML(sql)
        '            'sql = "Update InvoiceNumbers set Status='A' where Status='B'"
        '            'i = DML(sql)
        '            'sql = "Update IPNumbers set Status='A' where Status='B'"
        '            'i = DML(sql)
        '            'sql = "Update ReceiptNumbers set Status='A' where Status='B'"
        '            'i = DML(sql)
        J = 0
        Timer1.Enabled = True
        'Else
        'MsgBox("Your license key is wrong contact AUOSYS Technologies", MsgBoxStyle.Critical, "AUOSYS Technologies")
        'Timer1.Enabled = False
        'End
        '        End If
        '    Else
        'MsgBox("You are using illegal version of the sotware", MsgBoxStyle.Critical, "AUOSYS Technologies")
        'Timer1.Enabled = False
        'End
        '    End If
        'Catch Ex As Exception
        '    MsgBox(Ex.Message, MsgBoxStyle.Critical, "InfirmarySoft")
        '    End
        '    ' Let the user know what went wrong.
        'End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If J > 5 Then
            Timer1.Enabled = False
            Me.Hide()
            frmLogin.Show()
        Else
            J = J + 1
        End If

    End Sub
End Class
