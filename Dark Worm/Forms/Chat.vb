Imports System.IO

Public Class Chat
    Public C As Client
    Public chatE As Boolean
    Public Nickname As String
    Private Sub Chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nick As String = Interaction.InputBox("NICKNAME", "CLIENT CHAT", "Admin")

        If String.IsNullOrEmpty(nick) Then
            Me.Close()
        Else
            Nickname = nick
            Try
                Dim B As Byte() = SB("LLCHAT" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Chat.dll")))
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Chat_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim B As Byte() = SB("ENDChat")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If chatE AndAlso e.KeyData = Keys.Enter AndAlso Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            e.SuppressKeyPress = True
            TextBox2.Text &= "ME: " + TextBox1.Text + Environment.NewLine


            Dim B As Byte() = SB("GETChat" + Settings.SPL & Nickname + ": " + TextBox1.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)



            TextBox2.SelectionStart = TextBox2.Text.Length
            TextBox2.ScrollToCaret()
            TextBox2.Refresh()
            TextBox1.Clear()
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