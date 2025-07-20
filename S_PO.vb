
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class S_PO
    Dim myconnection As SqlConnection
    Dim mycommand As SqlCommand
    Dim dr As SqlDataReader
    Dim dr1 As SqlDataReader
    Dim ra As Integer
    Dim PrintDialog1 As New PrintDialog()
    Private bitmap As Bitmap
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Dim xCurrentDate As String = String.Empty
    Dim xFromDate As String = String.Empty
    Dim xToDate As String = String.Empty
    Dim xCount As Integer = 0
    Dim xReportString As String = String.Empty


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()

        Dim connetionString As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing

        sql = "SELECT * FROM ProductGroupMaster WHERE     (DATALENGTH(GroupName) > 0)"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.ValueMember = "GroupName"
            ComboBox1.DisplayMember = "GroupName"
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try
    End Sub

    'Dim str As String = "data source=NEWSERVER;initial catalog=PharmacyDB;integrated security=false;user id=sa"
    'Dim con As New SqlConnection(str)
    'Dim com As String = "SELECT     ProductName,Purchase, Sales, ClosingStock, " _
    ' & " Sales - ClosingStock AS zero, " _
    ' & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * 10 / 100 AS ten, " _
    ' & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * 25 / 100 AS twentyfive, " _
    ' & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * 50 / 100 AS fifty, " _
    ' & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * 75 / 100 AS seventyfive, " _
    ' & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * 100 / 100 AS hundred FROM StockPrint order by ProductName"
    'Dim Adpt As New SqlDataAdapter(com, con)
    'Dim ds As New DataSet()
    'Adpt.Fill(ds, "Test")
    ''DataGridView2.DataSource = ds.Tables(0)

    Private Sub btnPercentageCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPercentageCalculate.Click
        xReportString = "FULL VIEW"
        LoadDate()

        Dim str As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
        Dim con As New SqlConnection(str)
        Dim xPercentageText As String = String.Empty
        xPercentageText = txtPercentage.Text + " (%)"
        Dim com As String = "SELECT     ProductName, Sales, ClosingStock, " _
         & " Sales - ClosingStock AS zero, " _
         & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * " + txtPercentage.Text + " / 100 AS '" + xPercentageText + "' FROM StockPrint order by ProductName"
        Dim Adpt As New SqlDataAdapter(com, con)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Test")
        DataGridView1.DataSource = ds.Tables(0)
        SetUpDataGridView()
    End Sub
    Private Sub LoadDate()
        myconnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString)
        Dim cmd As SqlCommand = myconnection.CreateCommand()
        'cmd.CommandText = "SELECT * from ConsultantNames "
        myconnection.Open()
        mycommand = New SqlCommand("select FromDate,ToDate from FromToDateTable ", myconnection)
        Using reader As SqlDataReader = mycommand.ExecuteReader
            While (reader.Read())
                xFromDate = reader("FromDate")
                xToDate = reader("ToDate")
                lblFromDate.Text = xFromDate
                lblToDate.Text = xToDate
                xCurrentDate = DateTime.Now
                lblReport.Text = xReportString
            End While
        End Using
        myconnection.Close()
    End Sub
    Private Sub SetUpDataGridView()

        Me.Controls.Add(DataGridView1)
        'dataGridView1.ColumnCount = 5

        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView1.Font, FontStyle.Bold)
        End With

        With DataGridView1
            .EditMode = DataGridViewEditMode.EditOnEnter
            .Name = "dataGridView1"
            .AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle =
                DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .RowHeadersVisible = False
            .AutoSizeColumnsMode =
       DataGridViewAutoSizeColumnsMode.AllCells
            .ReadOnly = True
            ' Make the font italic for row four.
            .Columns(0).DefaultCellStyle.Font =
                New Font(Control.DefaultFont,
                    FontStyle.Bold)

            .SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .BackgroundColor = Color.Honeydew


        End With
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'PrintDocument1.Print()
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Create string to draw. 
        Dim description As String = ""

        description = ComboBox1.Text
        Dim drawString As [String] = "Product Name - " + description + " , From Date " + xFromDate + " ,To Date " + xToDate + ", Printing Date " + xCurrentDate + ", Report -" + xReportString

        ' Create font and brush. 
        Dim drawFont As New Font("Arial", 12)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create rectangle for drawing. 
        Dim x1 As Single = 25.0F
        Dim y1 As Single = 25.0F
        Dim width As Single = 500.0F
        Dim height As Single = 60.0F
        Dim drawRect As New RectangleF(x1, y1, width, height)

        ' Draw rectangle to screen. 
        Dim blackPen As New Pen(Color.Black)
        e.Graphics.DrawRectangle(blackPen, x1, y1, width, height)

        ' Set format of string. 
        Dim drawFormat As New StringFormat
        drawFormat.Alignment = StringAlignment.Center

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush,
        drawRect, drawFormat)
        With DataGridView1
            Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
            fmt.LineAlignment = StringAlignment.Center
            fmt.Trimming = StringTrimming.EllipsisCharacter
            Dim y As Single = e.MarginBounds.Top
            Do While mRow < .RowCount
                Dim row As DataGridViewRow = .Rows(mRow)
                Dim x As Single = e.MarginBounds.Left
                Dim h As Single = 0

                For Each cell As DataGridViewCell In row.Cells
                    Dim rc As RectangleF = New RectangleF(x, y, cell.Size.Width, cell.Size.Height)
                    e.Graphics.DrawRectangle(Pens.Black, rc.Left, rc.Top, rc.Width, rc.Height)

                    If (newpage) Then
                        e.Graphics.DrawString(DataGridView1.Columns(cell.ColumnIndex).HeaderText, .Font, Brushes.Black, rc, fmt)
                    Else
                        e.Graphics.DrawString(DataGridView1.Rows(cell.RowIndex).Cells(cell.ColumnIndex).FormattedValue.ToString(), .Font, Brushes.Black, rc, fmt)
                    End If

                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                Next



                newpage = False
                y += h
                mRow += 1
                If y + h > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    mRow -= 1
                    newpage = True
                    Exit Sub
                End If
            Loop
            mRow = 0
        End With
    End Sub

    Private Sub btnToOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToOrder.Click

        xReportString = "TO ORDER"
        LoadDate()
        Dim str As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
        Dim con As New SqlConnection(str)
        Dim xPercentageText As String = String.Empty
        xPercentageText = txtPercentage.Text + " (%)"
        Dim com As String = "SELECT     ProductName, Sales, ClosingStock,ceiling(( " _
        & txtPercentage.Text + " / 100.00)* Sales) - ClosingStock AS '" + xPercentageText + "' FROM StockPrint where Sales - ClosingStock  + ABS(Sales -ClosingStock) * " + txtPercentage.Text + " / 100>0 order by ProductName"

        Dim Adpt As New SqlDataAdapter(com, con)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Test")
        DataGridView1.DataSource = ds.Tables(0)

        'Dim ds As DataSet = ProgramDataset()
        'Dim p As New ReportParameter("programName", "Test")
        'Form2.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        'Form2.ReportViewer1.LocalReport.ReportPath = "..\..\Reports\PurchasedReport.rdlc"
        ' Form2.ReportViewer1.LocalReport.SetParameters(p)
        'Form2.ReportViewer1.LocalReport.DataSources.Clear()
        'Form2.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Test", ds.Tables(0)))
        'Form2.ReportViewer1.DocumentMapCollapsed = True
        'Form2.ReportViewer1.RefreshReport()
        'Form2.Show()

        SetUpDataGridView()
    End Sub

    Private Sub btnZeroOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZeroOrder.Click
        xReportString = "ZERO ORDER"
        LoadDate()
        Dim str As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
        Dim con As New SqlConnection(str)
        Dim xPercentageText As String = String.Empty
        xPercentageText = txtPercentage.Text + " (%)"
        Dim com As String = "SELECT     ProductName, Sales, ClosingStock, " _
         & " Sales - ClosingStock AS zero, " _
         & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * " + txtPercentage.Text + " / 100 AS '" + xPercentageText + "' FROM StockPrint where Sales - ClosingStock  + ABS(Sales -ClosingStock) * " + txtPercentage.Text + " / 100 =0 AND sales!=0 order by ProductName"
        Dim Adpt As New SqlDataAdapter(com, con)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Test")
        DataGridView1.DataSource = ds.Tables(0)
        SetUpDataGridView()
    End Sub

    Private Sub btnNonMoving_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNonMoving.Click
        xReportString = "NON-MOVING"
        LoadDate()
        Dim str As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
        Dim con As New SqlConnection(str)
        Dim xPercentageText As String = String.Empty
        xPercentageText = txtPercentage.Text + " (%)"
        Dim com As String = "SELECT     ProductName, Sales, ClosingStock, " _
         & " Sales - ClosingStock AS zero, " _
         & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * " + txtPercentage.Text + " / 100 AS '" + xPercentageText + "' FROM StockPrint where Sales=0 order by ProductName"
        Dim Adpt As New SqlDataAdapter(com, con)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Test")
        DataGridView1.DataSource = ds.Tables(0)
        SetUpDataGridView()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        S_OT_DELIVERY.Show()
    End Sub

    Private Sub btnPurchased_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchased.Click
        xReportString = "PURCHASED"
        LoadDate()
        Dim str As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
        Dim con As New SqlConnection(str)
        Dim com As String = "SELECT    ProductName,Purchase FROM StockPrint where Purchase>0 order by ProductName"
        Dim Adpt As New SqlDataAdapter(com, con)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Test")
        DataGridView1.DataSource = ds.Tables(0)
        SetUpDataGridView()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()
    End Sub

    'Private Sub btnZeroLastColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZeroLastColumn.Click
    '    xReportString = "ZERO ORDER LAST COLUMN"
    '    LoadDate()

    '    Dim str As String = "data source=NEWSERVER;initial catalog=PharmacyDB;integrated security=false;user id=sa"
    '    Dim con As New SqlConnection(str)
    '    Dim xPercentageText As String = String.Empty
    '    xPercentageText = txtPercentage.Text + " (%)"
    '    Dim com As String = "SELECT     ProductName, Sales, ClosingStock, " _
    '     & " Sales - ClosingStock AS zero, " _
    '     & " Sales - ClosingStock  + ABS(Sales -ClosingStock) * " + txtPercentage.Text + " / 100 AS '" + xPercentageText + "' FROM StockPrint where Sales - ClosingStock  + ABS(Sales -ClosingStock) * " + txtPercentage.Text + " / 100=0 and sales>0 order by ProductName"
    '    Dim Adpt As New SqlDataAdapter(com, con)
    '    Dim ds As New DataSet()
    '    Adpt.Fill(ds, "Test")
    '    DataGridView1.DataSource = ds.Tables(0)
    '    SetUpDataGridView()
    'End Sub

    Private Sub btnToOrderNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToOrderNew.Click

        xReportString = "TO ORDER"
        LoadDate()
        Dim str As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
        Dim con As New SqlConnection(str)
        Dim xPercentageText As String = String.Empty
        xPercentageText = txtPercentage.Text + " (%)"
        'Dim com As String = "SELECT     ProductName, Sales, ClosingStock,ceiling(( " _
        '& txtPercentage.Text + " / 100.00)* Sales) - ClosingStock AS '" + xPercentageText + "' FROM StockPrint where Sales - ClosingStock  + ABS(Sales -ClosingStock) * " + txtPercentage.Text + " / 100>0 order by ProductName"
        Dim com As String = "SELECT     ProductName, Sales, ClosingStock,ceiling(( " _
         & txtPercentage.Text + " / 100.00)* Sales) - ClosingStock AS '" + xPercentageText + "' FROM StockPrint where Sales!=0  order by ProductName"

        Dim Adpt As New SqlDataAdapter(com, con)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Test")
        DataGridView1.DataSource = ds.Tables(0)

        'Dim ds As DataSet = ProgramDataset()
        'Dim p As New ReportParameter("programName", "Test")
        'Form2.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        'Form2.ReportViewer1.LocalReport.ReportPath = "..\..\Reports\PurchasedReport.rdlc"
        ' Form2.ReportViewer1.LocalReport.SetParameters(p)
        'Form2.ReportViewer1.LocalReport.DataSources.Clear()
        'Form2.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Test", ds.Tables(0)))
        'Form2.ReportViewer1.DocumentMapCollapsed = True
        'Form2.ReportViewer1.RefreshReport()
        'Form2.Show()

        SetUpDataGridView()
    End Sub
End Class
