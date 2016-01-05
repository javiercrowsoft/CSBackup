<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class fExplorer
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents ilDir As System.Windows.Forms.ImageList
  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.
  'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fExplorer))
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.cmdOk = New System.Windows.Forms.Button
    Me.cmdCancel = New System.Windows.Forms.Button
    Me.ilDir = New System.Windows.Forms.ImageList(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.cmdRemove = New System.Windows.Forms.Button
    Me.cmdAdd = New System.Windows.Forms.Button
    Me.lsNetFolders = New System.Windows.Forms.ListBox
    Me.TxNetPath = New System.Windows.Forms.TextBox
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.tvDir = New System.Windows.Forms.TreeView
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmdOk
    '
    Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
    Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdOk.Location = New System.Drawing.Point(339, 382)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdOk.Size = New System.Drawing.Size(105, 25)
    Me.cmdOk.TabIndex = 2
    Me.cmdOk.Text = "&Aceptar"
    Me.cmdOk.UseVisualStyleBackColor = False
    '
    'cmdCancel
    '
    Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
    Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdCancel.Location = New System.Drawing.Point(450, 382)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdCancel.Size = New System.Drawing.Size(105, 25)
    Me.cmdCancel.TabIndex = 1
    Me.cmdCancel.Text = "&Cancelar"
    Me.cmdCancel.UseVisualStyleBackColor = False
    '
    'ilDir
    '
    Me.ilDir.ImageStream = CType(resources.GetObject("ilDir.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ilDir.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.ilDir.Images.SetKeyName(0, "")
    Me.ilDir.Images.SetKeyName(1, "")
    Me.ilDir.Images.SetKeyName(2, "")
    Me.ilDir.Images.SetKeyName(3, "")
    Me.ilDir.Images.SetKeyName(4, "")
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.cmdRemove)
    Me.GroupBox1.Controls.Add(Me.cmdAdd)
    Me.GroupBox1.Controls.Add(Me.lsNetFolders)
    Me.GroupBox1.Controls.Add(Me.TxNetPath)
    Me.GroupBox1.Location = New System.Drawing.Point(7, 184)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(549, 192)
    Me.GroupBox1.TabIndex = 6
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Carpetas y Archivos en la Red"
    '
    'cmdRemove
    '
    Me.cmdRemove.BackColor = System.Drawing.SystemColors.Control
    Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdRemove.Location = New System.Drawing.Point(126, 55)
    Me.cmdRemove.Name = "cmdRemove"
    Me.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdRemove.Size = New System.Drawing.Size(105, 25)
    Me.cmdRemove.TabIndex = 10
    Me.cmdRemove.Text = "&Borrar"
    Me.cmdRemove.UseVisualStyleBackColor = False
    '
    'cmdAdd
    '
    Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
    Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdAdd.Location = New System.Drawing.Point(15, 55)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdAdd.Size = New System.Drawing.Size(105, 25)
    Me.cmdAdd.TabIndex = 8
    Me.cmdAdd.Text = "&Agregar"
    Me.cmdAdd.UseVisualStyleBackColor = False
    '
    'lsNetFolders
    '
    Me.lsNetFolders.FormattingEnabled = True
    Me.lsNetFolders.Location = New System.Drawing.Point(15, 86)
    Me.lsNetFolders.Name = "lsNetFolders"
    Me.lsNetFolders.Size = New System.Drawing.Size(514, 82)
    Me.lsNetFolders.TabIndex = 7
    '
    'TxNetPath
    '
    Me.TxNetPath.Location = New System.Drawing.Point(17, 29)
    Me.TxNetPath.Name = "TxNetPath"
    Me.TxNetPath.Size = New System.Drawing.Size(512, 20)
    Me.TxNetPath.TabIndex = 6
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.tvDir)
    Me.GroupBox2.Location = New System.Drawing.Point(7, 7)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(548, 165)
    Me.GroupBox2.TabIndex = 7
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Carpetas y Archivos Locales"
    '
    'tvDir
    '
    Me.tvDir.CheckBoxes = True
    Me.tvDir.Indent = 24
    Me.tvDir.Location = New System.Drawing.Point(15, 19)
    Me.tvDir.Name = "tvDir"
    Me.tvDir.Size = New System.Drawing.Size(514, 129)
    Me.tvDir.TabIndex = 1
    '
    'fExplorer
    '
    Me.AcceptButton = Me.cmdOk
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.CancelButton = Me.cmdCancel
    Me.ClientSize = New System.Drawing.Size(563, 417)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.cmdOk)
    Me.Controls.Add(Me.cmdCancel)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Location = New System.Drawing.Point(4, 25)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fExplorer"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Text = "Ubicar archivo de backup"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Public WithEvents cmdAdd As System.Windows.Forms.Button
  Friend WithEvents lsNetFolders As System.Windows.Forms.ListBox
  Friend WithEvents TxNetPath As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Public WithEvents tvDir As System.Windows.Forms.TreeView
  Public WithEvents cmdRemove As System.Windows.Forms.Button
#End Region
End Class