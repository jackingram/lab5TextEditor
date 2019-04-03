Option Strict On
Imports System.IO

Public Class frmMain

    Private Sub OpenCtrlOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenCtrlOToolStripMenuItem.Click
        Try
            OpenFileDialog1.Filter = "Text Files|*.txt"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            End If

            Dim strFullPath As String = OpenFileDialog1.FileName
            Dim fileRead As New FileStream(strFullPath, FileMode.Open, FileAccess.Read)
            Dim reader As New StreamReader(fileRead)
            txtMain.Text = reader.ReadToEnd()
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error")
        End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SaveCtrlSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveCtrlSToolStripMenuItem.Click
        Save()
    End Sub

    Public Sub Save()
        Try
            Dim strFullPath As String = SaveFileDialog1.FileName

            If File.Exists(strFullPath) Then
                Dim fileWrite As New FileStream(strFullPath, FileMode.Create, FileAccess.Write)
                Dim writer As New IO.StreamWriter(fileWrite)
                writer.WriteLine(txtMain.Text)
                writer.Close()
            Else
                SaveFileDialog1.Filter = "Text Files|*.txt"
                SaveFileDialog1.ShowDialog()
                System.IO.File.WriteAllText(SaveFileDialog1.FileName, txtMain.Text)
            End If


        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Text Files|*.txt"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Save()
        End If
    End Sub

    Private Sub NewCtrlNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewCtrlNToolStripMenuItem.Click
        txtMain.Text = ""
        SaveFileDialog1.FileName = ""


    End Sub

    Private Sub CutCtrlXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutCtrlXToolStripMenuItem.Click
        If (txtMain.SelectedText = "") Then
            MessageBox.Show("Please Select Some Text to CUT!")
        Else
            My.Computer.Clipboard.SetText(txtMain.SelectedText)
            txtMain.SelectedText = ""
        End If
    End Sub

    Private Sub CopyCtrlCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyCtrlCToolStripMenuItem.Click
        If (txtMain.SelectedText = "") Then
            MessageBox.Show("Please Select Some Text to COPY!")
        Else
            My.Computer.Clipboard.SetText(txtMain.SelectedText)
        End If
    End Sub

    Private Sub PasteCtrlVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteCtrlVToolStripMenuItem.Click
        txtMain.Text += My.Computer.Clipboard.GetText()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("NETD 2202 - JACK INGRAM ")
    End Sub
End Class
