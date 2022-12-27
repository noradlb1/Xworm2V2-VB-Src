<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Binder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Binder))
        Me.L1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FalseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunonceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrueToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FalseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'L1
        '
        Me.L1.AllowDrop = True
        Me.L1.BackColor = System.Drawing.Color.Black
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.L1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.L1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.L1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.White
        Me.L1.FullRowSelect = True
        Me.L1.HideSelection = False
        Me.L1.Location = New System.Drawing.Point(0, 0)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(369, 198)
        Me.L1.SmallImageList = Me.ImageList1
        Me.L1.TabIndex = 32
        Me.L1.UseCompatibleStateImageBehavior = False
        Me.L1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "[ Path ]"
        Me.ColumnHeader1.Width = 88
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "[ Size ]"
        Me.ColumnHeader2.Width = 72
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "[ Running ]"
        Me.ColumnHeader3.Width = 85
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "[ Runonce ]"
        Me.ColumnHeader4.Width = 79
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.ClearToolStripMenuItem, Me.RunningToolStripMenuItem, Me.RunonceToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 114)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.add
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.AddToolStripMenuItem.Text = "[ Add ]"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.del
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.RemoveToolStripMenuItem.Text = "[ Remove ]"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.b
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ClearToolStripMenuItem.Text = "[ Clear ]"
        '
        'RunningToolStripMenuItem
        '
        Me.RunningToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrueToolStripMenuItem, Me.FalseToolStripMenuItem})
        Me.RunningToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources._00
        Me.RunningToolStripMenuItem.Name = "RunningToolStripMenuItem"
        Me.RunningToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.RunningToolStripMenuItem.Text = "[ Running ]"
        '
        'TrueToolStripMenuItem
        '
        Me.TrueToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.yes
        Me.TrueToolStripMenuItem.Name = "TrueToolStripMenuItem"
        Me.TrueToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.TrueToolStripMenuItem.Text = "[ True ]"
        '
        'FalseToolStripMenuItem
        '
        Me.FalseToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.no
        Me.FalseToolStripMenuItem.Name = "FalseToolStripMenuItem"
        Me.FalseToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.FalseToolStripMenuItem.Text = "[ False ]"
        '
        'RunonceToolStripMenuItem
        '
        Me.RunonceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrueToolStripMenuItem1, Me.FalseToolStripMenuItem1})
        Me.RunonceToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources._00
        Me.RunonceToolStripMenuItem.Name = "RunonceToolStripMenuItem"
        Me.RunonceToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.RunonceToolStripMenuItem.Text = "[ Runonce ]"
        '
        'TrueToolStripMenuItem1
        '
        Me.TrueToolStripMenuItem1.Image = Global.XWorm.My.Resources.Resources.yes
        Me.TrueToolStripMenuItem1.Name = "TrueToolStripMenuItem1"
        Me.TrueToolStripMenuItem1.Size = New System.Drawing.Size(114, 22)
        Me.TrueToolStripMenuItem1.Text = "[ True ]"
        '
        'FalseToolStripMenuItem1
        '
        Me.FalseToolStripMenuItem1.Image = Global.XWorm.My.Resources.Resources.no
        Me.FalseToolStripMenuItem1.Name = "FalseToolStripMenuItem1"
        Me.FalseToolStripMenuItem1.Size = New System.Drawing.Size(114, 22)
        Me.FalseToolStripMenuItem1.Text = "[ False ]"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(20, 20)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.Black
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox2.ForeColor = System.Drawing.Color.White
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"%Temp%", "%AppData%", "%Userprofile%", "%Allusersprofile%", "%Public%", "%ProgramData%", "%LocalAppdata%", "%Current%"})
        Me.ComboBox2.Location = New System.Drawing.Point(58, 8)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(123, 21)
        Me.ComboBox2.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Path : "
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(325, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Cursor = System.Windows.Forms.Cursors.Cross
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
        Me.CheckBox2.Location = New System.Drawing.Point(272, 18)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(47, 17)
        Me.CheckBox2.TabIndex = 28
        Me.CheckBox2.Text = "Icon"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Cursor = System.Windows.Forms.Cursors.Cross
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(195, 18)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox1.TabIndex = 27
        Me.CheckBox1.Text = "Assembly"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(12, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(345, 38)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Build"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboBox2)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 198)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(369, 106)
        Me.Panel1.TabIndex = 33
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.XWorm.My.Resources.Resources.ddddddddddddd
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(322, 23)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(47, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'Binder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(369, 304)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Binder"
        Me.Text = "Multi File Binder"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents L1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunningToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TrueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FalseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunonceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TrueToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FalseToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
End Class
