Imports System.IO

Public Class TcpConnectionForm
    Public C As Client
    Private Sub TcpConnectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Start()
        Try
            Dim B As Byte() = SB("TCPG" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\TCPGET.dll")) & Settings.SPL & Nothing)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("TCPG" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\TCPGET.dll")) & Settings.SPL & Nothing)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub KillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillToolStripMenuItem.Click
        Dim pids As String
        pids = Nothing
        For Each LV As ListViewItem In ListView1.SelectedItems
            pids &= "|" & LV.SubItems(0).Text
        Next
        Try
            Dim B As Byte() = SB("TCPG" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\TCPGET.dll")) & Settings.SPL & pids)
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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            ToolStripStatusLabel1.Text = "Connections [" & ListView1.Items.Count & "]"
            ToolStripStatusLabel2.Text = "Selected [" & ListView1.SelectedItems.Count.ToString & "]"
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Class