Imports System.IO

Module Helper
    Function log(ByVal ip As String, ByVal mode As Boolean)
        Try
            Dim LV As ListViewItem = New ListViewItem()
            LV.Text = ip
            If mode = True Then
                LV.SubItems.Add("Connected")
                LV.ForeColor = Color.Lime
                LV.ImageIndex = 0
            End If
            If mode = False Then
                LV.SubItems.Add("Disconnected")
                LV.ForeColor = Color.Red
                LV.ImageIndex = 1
            End If
            LV.SubItems.Add(DateTime.Now.ToLongTimeString())
            Form1.Lv2.Items.Insert(0, LV)
            Form1.Lv2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function
    Function SB(ByVal s As String) As Byte()
        Return Text.Encoding.Default.GetBytes(s)
    End Function

    Function BS(ByVal b As Byte()) As String
        Return Text.Encoding.Default.GetString(b)
    End Function
    Public Function BytesToString(ByVal byteCount As Long) As String
        Dim suf As String() = {"B", "KB", "MB", "GB", "TB", "PB", "EB"}
        If byteCount = 0 Then Return "0" & suf(0)
        Dim bytes As Long = Math.Abs(byteCount)
        Dim place As Integer = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)))
        Dim num As Double = Math.Round(bytes / Math.Pow(1024, place), 1)
        Return (Math.Sign(byteCount) * num).ToString() & suf(place)
    End Function

    Function AES_Encryptor(ByVal input As Byte()) As Byte()
        Dim AES As New Security.Cryptography.RijndaelManaged
        Dim Hash As New Security.Cryptography.MD5CryptoServiceProvider
        Dim ciphertext As String = ""
        Try
            AES.Key = Hash.ComputeHash(SB(Settings.KEY))
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = input
            Return DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
            Debug.WriteLine("AES_Encryptor" + ex.Message)
        End Try
    End Function

    Function AES_Decryptor(ByVal input As Byte(), Optional C As Client = Nothing) As Byte()
        Dim AES As New Security.Cryptography.RijndaelManaged
        Dim Hash As New Security.Cryptography.MD5CryptoServiceProvider
        Try
            AES.Key = Hash.ComputeHash(SB(Settings.KEY))
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = input
            Return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
            Debug.WriteLine("AES_Decryptor" + ex.Message)
            If C.IsConnected Then
                If Not Settings.Blocked.Contains(C.IP.ToString.Split(":")(0)) Then
                    Settings.Blocked.Add(C.IP.ToString.Split(":")(0))
                    C.isDisconnected()
                    Exit Function
                End If
            End If
        End Try
        Return Nothing
    End Function
    Public Async Sub FadeIn(ByVal o As Form, ByVal Optional interval As Integer = 80)

        While o.Opacity < 1.0
            Await Task.Delay(interval)
            o.Opacity += 0.05
        End While

        o.Opacity = 1
    End Sub


    Public Async Sub FadeInMain(ByVal o As Form, ByVal Optional interval As Integer = 80)


        While o.Opacity < 1.0
            Await Task.Delay(interval)
            o.Opacity += 0.05
        End While

        Try
            My.Computer.Audio.Play(Path.Combine(Application.StartupPath, "Intro.wav"))
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        o.Opacity = 1

        Form1.trans = True
    End Sub

    Friend Function aes_function() As Object
        Return check.server_app
    End Function
End Module