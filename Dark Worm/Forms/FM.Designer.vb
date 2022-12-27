<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FM))
        Me.Button1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.NewFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HiddenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowHideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowFolderFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideFolderFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnZipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadToServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendFromLinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DecryptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaySoundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.XWorm.My.Resources.Resources.baccc
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 20)
        Me.Button1.Text = "Back"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(0, 334)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(613, 20)
        Me.TextBox1.TabIndex = 8
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Button1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(613, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "cd.ico")
        Me.ImageList1.Images.SetKeyName(1, "drive.ico")
        Me.ImageList1.Images.SetKeyName(2, "folder.ico")
        Me.ImageList1.Images.SetKeyName(3, "network.ico")
        Me.ImageList1.Images.SetKeyName(4, "usb.ico")
        Me.ImageList1.Images.SetKeyName(5, "image (2) (1).ico")
        '
        'NewFolderToolStripMenuItem
        '
        Me.NewFolderToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.newfolder
        Me.NewFolderToolStripMenuItem.Name = "NewFolderToolStripMenuItem"
        Me.NewFolderToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.NewFolderToolStripMenuItem.Text = "[ New Folder ]"
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.down
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.DownloadToolStripMenuItem.Text = "[ Download ]"
        '
        'UploadToolStripMenuItem
        '
        Me.UploadToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.up
        Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
        Me.UploadToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.UploadToolStripMenuItem.Text = "[ Upload ]"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.delllll
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.DeleteToolStripMenuItem.Text = "[ Delete ]"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.renm
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.RenameToolStripMenuItem.Text = "[ Rename ]"
        '
        'ExecuteToolStripMenuItem
        '
        Me.ExecuteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NormalToolStripMenuItem, Me.HiddenToolStripMenuItem})
        Me.ExecuteToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.runnn
        Me.ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem"
        Me.ExecuteToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ExecuteToolStripMenuItem.Text = "[ Execute ]"
        '
        'NormalToolStripMenuItem
        '
        Me.NormalToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.showwww
        Me.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem"
        Me.NormalToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.NormalToolStripMenuItem.Text = "[ Normal ]"
        '
        'HiddenToolStripMenuItem
        '
        Me.HiddenToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.hideeeeee
        Me.HiddenToolStripMenuItem.Name = "HiddenToolStripMenuItem"
        Me.HiddenToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.HiddenToolStripMenuItem.Text = "[ Hidden ]"
        '
        'RedreshToolStripMenuItem
        '
        Me.RedreshToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.re1
        Me.RedreshToolStripMenuItem.Name = "RedreshToolStripMenuItem"
        Me.RedreshToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.RedreshToolStripMenuItem.Text = "[ Refresh ]"
        '
        'BackToolStripMenuItem
        '
        Me.BackToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.baccc
        Me.BackToolStripMenuItem.Name = "BackToolStripMenuItem"
        Me.BackToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.BackToolStripMenuItem.Text = "[ Back ]"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackToolStripMenuItem, Me.RedreshToolStripMenuItem, Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PastToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExecuteToolStripMenuItem, Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.UploadToolStripMenuItem, Me.DownloadToolStripMenuItem, Me.NewFolderToolStripMenuItem, Me.CreateFileToolStripMenuItem, Me.ShowHideToolStripMenuItem, Me.ZToolStripMenuItem, Me.UploadToServerToolStripMenuItem, Me.SendFromLinkToolStripMenuItem, Me.EncryptToolStripMenuItem, Me.DecryptToolStripMenuItem, Me.PlaySoundToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(198, 444)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.Copy
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.CopyToolStripMenuItem.Text = "[ Copy ]"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources._6622123_preview
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.CutToolStripMenuItem.Text = "[ Cut ]"
        '
        'PastToolStripMenuItem
        '
        Me.PastToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.Editing_Paste_icon
        Me.PastToolStripMenuItem.Name = "PastToolStripMenuItem"
        Me.PastToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.PastToolStripMenuItem.Text = "[ Paste ]"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.tex
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.EditToolStripMenuItem.Text = "[ Edit ]"
        '
        'CreateFileToolStripMenuItem
        '
        Me.CreateFileToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.file_icon_png_23
        Me.CreateFileToolStripMenuItem.Name = "CreateFileToolStripMenuItem"
        Me.CreateFileToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.CreateFileToolStripMenuItem.Text = "[ New File ]"
        '
        'ShowHideToolStripMenuItem
        '
        Me.ShowHideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowFolderFileToolStripMenuItem1, Me.HideFolderFileToolStripMenuItem1})
        Me.ShowHideToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.file
        Me.ShowHideToolStripMenuItem.Name = "ShowHideToolStripMenuItem"
        Me.ShowHideToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ShowHideToolStripMenuItem.Text = "[ Show/Hide ]"
        '
        'ShowFolderFileToolStripMenuItem1
        '
        Me.ShowFolderFileToolStripMenuItem1.Image = Global.XWorm.My.Resources.Resources.showwww
        Me.ShowFolderFileToolStripMenuItem1.Name = "ShowFolderFileToolStripMenuItem1"
        Me.ShowFolderFileToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.ShowFolderFileToolStripMenuItem1.Text = "[ Show Folder/File ]"
        '
        'HideFolderFileToolStripMenuItem1
        '
        Me.HideFolderFileToolStripMenuItem1.Image = Global.XWorm.My.Resources.Resources.hideeeeee
        Me.HideFolderFileToolStripMenuItem1.Name = "HideFolderFileToolStripMenuItem1"
        Me.HideFolderFileToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.HideFolderFileToolStripMenuItem1.Text = "[ Hide Folder/File ]"
        '
        'ZToolStripMenuItem
        '
        Me.ZToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstallToolStripMenuItem, Me.ZipToolStripMenuItem, Me.UnZipToolStripMenuItem})
        Me.ZToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources._28814
        Me.ZToolStripMenuItem.Name = "ZToolStripMenuItem"
        Me.ZToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ZToolStripMenuItem.Text = "[ 7-Zip ]"
        '
        'InstallToolStripMenuItem
        '
        Me.InstallToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.down
        Me.InstallToolStripMenuItem.Name = "InstallToolStripMenuItem"
        Me.InstallToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.InstallToolStripMenuItem.Text = "[ Install ]"
        '
        'ZipToolStripMenuItem
        '
        Me.ZipToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.archive_rar_extract_zip_file_data_diocument_secure_31759
        Me.ZipToolStripMenuItem.Name = "ZipToolStripMenuItem"
        Me.ZipToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ZipToolStripMenuItem.Text = "[ Zip ]"
        '
        'UnZipToolStripMenuItem
        '
        Me.UnZipToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources._62107
        Me.UnZipToolStripMenuItem.Name = "UnZipToolStripMenuItem"
        Me.UnZipToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.UnZipToolStripMenuItem.Text = "[ Unzip ]"
        '
        'UploadToServerToolStripMenuItem
        '
        Me.UploadToServerToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources._005071cbf1fdd17673607ecd7b7e88f6
        Me.UploadToServerToolStripMenuItem.Name = "UploadToServerToolStripMenuItem"
        Me.UploadToServerToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.UploadToServerToolStripMenuItem.Text = "[ Upload File To Server ]"
        '
        'SendFromLinkToolStripMenuItem
        '
        Me.SendFromLinkToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources._005071cbf1fdd17673607ecd7b7e88f6
        Me.SendFromLinkToolStripMenuItem.Name = "SendFromLinkToolStripMenuItem"
        Me.SendFromLinkToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.SendFromLinkToolStripMenuItem.Text = "[ Upload From Link ]"
        '
        'EncryptToolStripMenuItem
        '
        Me.EncryptToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.unlock_icon_0_copy
        Me.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem"
        Me.EncryptToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.EncryptToolStripMenuItem.Text = "[ Encrypt ]"
        '
        'DecryptToolStripMenuItem
        '
        Me.DecryptToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.unlock_icon_0
        Me.DecryptToolStripMenuItem.Name = "DecryptToolStripMenuItem"
        Me.DecryptToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.DecryptToolStripMenuItem.Text = "[ Decrypt ]"
        '
        'PlaySoundToolStripMenuItem
        '
        Me.PlaySoundToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayToolStripMenuItem, Me.StopToolStripMenuItem})
        Me.PlaySoundToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.sound_play_sound
        Me.PlaySoundToolStripMenuItem.Name = "PlaySoundToolStripMenuItem"
        Me.PlaySoundToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.PlaySoundToolStripMenuItem.Text = "[ Play Wav ]"
        '
        'PlayToolStripMenuItem
        '
        Me.PlayToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.play_icon_png_transparent_28
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        Me.PlayToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.PlayToolStripMenuItem.Text = "[ Play ]"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Image = Global.XWorm.My.Resources.Resources.black_stop_icon_26
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.StopToolStripMenuItem.Text = "[ Stop ]"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "[ File Size ]"
        Me.ColumnHeader2.Width = 91
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "[ Name ]"
        Me.ColumnHeader1.Width = 242
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.Black
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.White
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 24)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(613, 310)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 9
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(369, 189)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(232, 139)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.XWorm.My.Resources.Resources.ddddddddddddd
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(566, 49)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(47, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'FM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(613, 354)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FM"
        Me.Text = "File Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As ToolStripMenuItem
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents NewFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExecuteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RedreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ListView1 As ListView
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ShowHideToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowFolderFileToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents HideFolderFileToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ZToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstallToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZipToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnZipToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PastToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncryptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DecryptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlaySoundToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SendFromLinkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadToServerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HiddenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox2 As PictureBox
End Class
