Public Class frmInformation

    Private Sub frmInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\DeveloperNotes\DeveloperNotes.txt")
    End Sub
End Class