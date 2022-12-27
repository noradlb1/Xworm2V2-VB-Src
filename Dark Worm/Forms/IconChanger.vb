Public Class IconChanger
    Private Sub IconChanger_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OfD As New OpenFileDialog
        With OfD
            .Title = "Select Exe File"
            .Filter = "(*.exe|*.exe"
            If OfD.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = OfD.FileName
            Else
                TextBox1.Text = "..."
            End If
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OfD As New OpenFileDialog
        With OfD
            .Title = "Select Icon"
            .Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico"
            .InitialDirectory = Application.StartupPath & "\Icons"
            If OfD.ShowDialog() = DialogResult.OK Then
                If OfD.FileName.EndsWith(".exe") Then
                    TextBox2.Text = EXEICO.GetIcon(OfD.FileName)
                    PictureBox1.ImageLocation = (TextBox2.Text)
                    GC.Collect()
                Else
                    TextBox2.Text = OfD.FileName
                    PictureBox1.ImageLocation = (TextBox2.Text)
                End If
            Else
                TextBox2.Text = "..."
                PictureBox1.Image = Nothing
            End If

        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox1.Text = "..." Or TextBox2.Text = "..." Then
            Else
                IconInjector.InjectIcon(TextBox1.Text, TextBox2.Text)
                MessageBox.Show(TextBox1.Text, "DONE!")
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class