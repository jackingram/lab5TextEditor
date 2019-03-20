Option Strict On
Imports System.IO

Public Class frmMain
    Private Sub FIleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FIleToolStripMenuItem.Click

    End Sub

    Private Sub OpenCtrlOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenCtrlOToolStripMenuItem.Click
        Try
            OpenFileDialog1.Filter = "Text Files|*.txt"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            End If

            Dim strFullPath As String = OpenFileDialog1.FileName
            Dim fileRead As New FileStream(strFullPath, FileMode.Open, FileAccess.Read)
            Dim reader As New StreamReader(strFullPath)
            txtMain.Text = reader.ReadToEnd()
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error")

        End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class
