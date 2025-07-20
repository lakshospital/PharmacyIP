Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class FindPatienID
    Dim PatientID, PatientName As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If drpPatientType.Text.Length = 0 Then
            MsgBox("Please Select Patient Type", MsgBoxStyle.Exclamation, Me.Text)
        ElseIf drpPatientType.Text = "In" And IsNumeric(txtPatientName.Text) = True And UserRights = "Admin" Then
            Dim da As New SqlDataAdapter("Select IPNO,PatientName,Address,RoomNo from AdmissionDetails where IPNo=" & txtPatientName.Text, con1)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            End If
        ElseIf drpPatientType.Text = "In" Then
            Dim da As New SqlDataAdapter("Select IPNO,PatientName,Address,RoomNo from AdmissionDetails where PatientName Like '" & txtPatientName.Text & "%' and Status='A'", con1)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            End If
        Else
            CheckConnection()
            Dim cmd As New SqlCommand("Select Max(PatientID) from DrugSlipDetails where YEAR(BillDate)='" & System.DateTime.Now.Date.Year & "' and CaseType='OP'", con)
            If IsDBNull(cmd.ExecuteScalar) = True Then
                PatientID = 1
            Else
                PatientID = cmd.ExecuteScalar
                PatientID = Val(PatientID) + 1
            End If
            PatientName = txtPatientName.Text
        End If
        DataGridView1.Focus()
    End Sub

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If drpPatientType.Text = "Out" Then
            DrugSlip.txtPatientID.Text = PatientID
            DrugSlip.txtPatientName.Text = PatientName
            DrugSlip.drpCase.Text = "OP"
            'DrugSlip.chkCashlessBill.Checked = False
            'DrugSlip.chkCashlessBill.Enabled = False
        ElseIf drpPatientType.Text = "In" Then
            DrugSlip.drpCase.Enabled = True
            If DataGridView1.RowCount = 0 Then
                MsgBox("No patient Admitted in this name", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            DrugSlip.txtPatientID.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            DrugSlip.txtPatientName.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value
            DrugSlip.chkCashlessBill.Enabled = True
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Main.Enabled = True
        Me.Close()
    End Sub

    Private Sub FindPatienID_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        DrugSlip.Enabled = True
        If drpPatientType.Text = "Out" Then
            DrugSlip.drpCase.Enabled = False
            DrugSlip.drpProductName.Focus()
        Else
            DrugSlip.drpCase.Focus()
        End If
    End Sub

    Private Sub FindPatienID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DrugSlip.Enabled = False
        Dim arr As New ArrayList
        arr.Add("In")
        arr.Add("Out")
        drpPatientType.DataSource = arr
    End Sub

    Private Sub drpPatientType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpPatientType.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPatientName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPatientName.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
