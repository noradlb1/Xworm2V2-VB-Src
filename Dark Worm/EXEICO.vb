Imports System.IO
Imports Toolbelt.Drawing

Public Class EXEICO
    Friend Shared Function color() As Object
        TXT.helper()
    End Function

    Public Shared Function GetIcon(ByVal path As String) As String
        Try
            Dim tempFile As String = IO.Path.GetTempFileName() & ".ico"

            Using fs As FileStream = New FileStream(tempFile, FileMode.Create)
                IconExtractor.Extract1stIconTo(path, fs)
            End Using

            Return tempFile
        Catch
        End Try

        Return ""
    End Function
End Class
