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
        '  SaveFileDialog1.Filter = "Text Files|*.txt"
        '  Dim strFullPath As String = SaveFileDialog1.FileName
        ' Dim fileWrite As New FileStream(strFullPath, FileMode.Create, FileAccess.Write)
        ' My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, "" & txtMain.Text, True)


        Save()
    End Sub

    Public Sub Save()
        Try
            SaveFileDialog1.Filter = "Text Files|*.txt"

            Dim strFullPath As String = SaveFileDialog1.FileName
            Dim fileWrite As New FileStream(strFullPath, FileMode.Create, FileAccess.Write)
            Dim writer As New StreamWriter(fileWrite)
            writer.Close()
            System.IO.File.WriteAllText(SaveFileDialog1.FileName, txtMain.Text)

        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Text Files|*.txt"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            System.IO.File.WriteAllText(SaveFileDialog1.FileName, txtMain.Text)
        End If
    End Sub
End Class
