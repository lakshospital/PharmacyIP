

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class S_OT_DELIVERY




    Dim myconnection As SqlConnection
    Dim mycommand As SqlCommand
    Dim dr As SqlDataReader
    Dim dr1 As SqlDataReader
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Dim xButtonText As String = String.Empty
    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        xButtonText = "OT-CASE REPORT"
        Dim str As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString
        Dim con As New SqlConnection(str)
        Dim xPercentageText As String = String.Empty
        Dim com As String = "SELECT  ROW_NUMBER() OVER (ORDER BY BillNo, DrName, PatientName, BillDateTime,casetype)  Sequence_no,BillNo, DrName, PatientName, BillDateTime,casetype FROM DrugSlipDetails WHERE BillDate >= '" + dtFromDate.Text + "' and BillDate <= '" + dtToDate.Text + "' AND (CaseType IN ('LSCS', 'MTP&DNC', 'DNC', 'BIOPSY', 'UMB.HER', 'MTP&LS', 'LAP&LS', 'LAP&APPENDIX', 'ENTOMETRIC BIOPSY', 'LAP', 'VAG HYS', 'LAP.VARICOCELE', 'OPEN ECTOPIC', 'GS','LAP ECTOPIC', 'FISTULA', 'LS', 'PS', 'HYSTEROTOMY', 'IUD', 'I&D', 'MISSED ABORTION', 'HERNIA', 'MTP', 'TAH&BSO', 'BREAST ABSCEES', 'ABH HYS', 'TAT', 'PAINLESS LABOUR EPIDURAL', 'EPIDORAL & SPINAL', 'CERVICAL STICH', 'FISSURE', 'OVARIAN CYST', 'POLLY PS', 'HEMOTATMO', 'APPEDIX', 'CHOCOLATE CYST', 'D&C L.WARD', 'DVT', 'ENDO BIOPSY', 'FIBRO BREAST',  'LAP CHOLE', 'LSCS& PS', 'LUMP BREAST', 'MYOMECTOMY',     'PILES', 'OPEN CHOLE', 'UMB.HERINA','MTP' ,'TAT' ,'LAP APPENDIX' )) AND (Status <> 'C') GROUP BY BillNo, DrName, PatientName, BillDateTime,casetype"

        Dim Adpt As New SqlDataAdapter(com, con)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Test")

        DataGridView1.DataSource = ds.Tables(0)
        SetUpDataGridView()
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
            .AutoSizeRowsMode = _
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle = _
                DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = _
       DataGridViewAutoSizeColumnsMode.AllCells
            .ReadOnly = True
            ' Make the font italic for row four.
            .Columns(0).DefaultCellStyle.Font = _
                New Font(Control.DefaultFont, _
                    FontStyle.Bold)

            .SelectionMode = _
                DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .BackgroundColor = Color.Honeydew


        End With
    End Sub
    'Private Sub SetUpDataGridView()

    '    Me.Controls.Add(DataGridView1)
    '    'dataGridView1.ColumnCount = 5

    '    With DataGridView1.ColumnHeadersDefaultCellStyle
    '        .BackColor = Color.Navy
    '        .ForeColor = Color.White
    '        .Font = New Font(DataGridView1.Font, FontStyle.Bold)
    '    End With

    '    With DataGridView1
    '        .EditMode = DataGridViewEditMode.EditOnEnter
    '        .Name = "dataGridView1"
    '        .Location = New Point(300, 100)
    '        .Size = New Size(500, 300)

    '        .AutoSizeRowsMode = _
    '            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
    '        .ColumnHeadersBorderStyle = _
    '            DataGridViewHeaderBorderStyle.Raised
    '        .CellBorderStyle = _
    '            DataGridViewCellBorderStyle.Single
    '        .GridColor = SystemColors.ActiveBorder
    '        .RowHeadersVisible = False
    '        .AutoSizeColumnsMode = _
    '   DataGridViewAutoSizeColumnsMode.AllCells
    '        .ReadOnly = True
    '        .Columns(0).HeaderText = "Bill No "
    '        .Columns(1).HeaderText = "Dr.Name"
    '        .Columns(2).HeaderText = "Patient Name"
    '        .Columns(3).HeaderText = "Bill DateTime"
    '        .Columns(4).HeaderText = "Case Type"
    '        ' Make the font italic for row four.
    '        .Columns(0).DefaultCellStyle.Font = _
    '            New Font(Control.DefaultFont, _
    '                FontStyle.Bold)

    '        .SelectionMode = _
    '            DataGridViewSelectionMode.FullRowSelect
    '        .MultiSelect = False

    '        .BackgroundColor = Color.Honeydew

    '        .Dock = DockStyle.Fill
    '    End With
    'End Sub

    Private Sub btnDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelivery.Click
        xButtonText = "DELIVERY CASE REPORT"
        Dim str As String = ConfigurationManager.ConnectionStrings("Pharmacy.My.MySettings.PharmacyConnectionString").ConnectionString


        Dim con As New SqlConnection(str)
        Dim xPercentageText As String = String.Empty
        Dim com As String = "SELECT     BillNo, DrName, PatientName, BillDateTime,casetype FROM DrugSlipDetails WHERE BillDate >= '" + dtFromDate.Text + "' and BillDate <= '" + dtToDate.Text + "' AND (CaseType IN ('NORMAL DELIVERY','LSCS')) AND (Status <> 'C') GROUP BY BillNo, DrName, PatientName, BillDateTime,casetype"
        Dim Adpt As New SqlDataAdapter(com, con)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Test")
        DataGridView1.DataSource = ds.Tables(0)
        SetUpDataGridView()
    End Sub



    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Create string to draw. 
        Dim description As String = ""

        Dim drawString As [String] = xButtonText + " - FROM - " + dtFromDate.Text + " - TO -" + dtToDate.Text + " -PRINTING AS ON -" + DateTime.Now

        ' Create font and brush. 
        Dim drawFont As New Font("Arial", 12)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create rectangle for drawing. 
        Dim x1 As Single = 25.0F
        Dim y1 As Single = 25.0F
        Dim width As Single = 500.0F
        Dim height As Single = 40.0F
        Dim drawRect As New RectangleF(x1, y1, width, height)

        ' Draw rectangle to screen. 
        Dim blackPen As New Pen(Color.Black)
        e.Graphics.DrawRectangle(blackPen, x1, y1, width, height)

        ' Set format of string. 
        Dim drawFormat As New StringFormat
        drawFormat.Alignment = StringAlignment.Center

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, _
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

    Private Sub btnPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'PrintDocument1.Print()
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub frmOtReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
End Class
