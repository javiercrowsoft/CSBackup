<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class fBackup
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
		'This form is an MDI child.
		'This code simulates the VB6 
		' functionality of automatically
		' loading and showing an MDI
		' child's parent.
		Me.MDIParent = CSBackup.fMainMDI
		CSBackup.fMainMDI.Show
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
  Public WithEvents ImageList1 As System.Windows.Forms.ImageList
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents tmBackup As System.Windows.Forms.Timer
	Public WithEvents lvTask As System.Windows.Forms.ListView
	Public WithEvents lvProgress As System.Windows.Forms.ListView
	Public WithEvents lvSchedule As System.Windows.Forms.ListView
  Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Shape1 As System.Windows.Forms.Label
	Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuConfig As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuMonitor As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
  Public WithEvents mnuHelpIndex As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fBackup))
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.cmdCancel = New System.Windows.Forms.Button
    Me.tmBackup = New System.Windows.Forms.Timer(Me.components)
    Me.lvTask = New System.Windows.Forms.ListView
    Me.lvProgress = New System.Windows.Forms.ListView
    Me.lvSchedule = New System.Windows.Forms.ListView
    Me.Image1 = New System.Windows.Forms.PictureBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Line2 = New System.Windows.Forms.Label
    Me.Line1 = New System.Windows.Forms.Label
    Me.Shape1 = New System.Windows.Forms.Label
    Me.MainMenu1 = New System.Windows.Forms.MenuStrip
    Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuView = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuConfig = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuMonitor = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuHelpIndex = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem
    Me.picProgress = New System.Windows.Forms.ProgressBar
    Me.popTask = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.popExecute = New System.Windows.Forms.ToolStripMenuItem
    Me.popSchedule = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.popExecuteSchedule = New System.Windows.Forms.ToolStripMenuItem
    CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.MainMenu1.SuspendLayout()
    Me.popTask.SuspendLayout()
    Me.popSchedule.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    '
    'cmdCancel
    '
    Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
    Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdCancel.Location = New System.Drawing.Point(500, 468)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdCancel.Size = New System.Drawing.Size(105, 25)
    Me.cmdCancel.TabIndex = 2
    Me.cmdCancel.Text = "&Cancelar"
    Me.cmdCancel.UseVisualStyleBackColor = False
    '
    'tmBackup
    '
    Me.tmBackup.Interval = 1
    '
    'lvTask
    '
    Me.lvTask.BackColor = System.Drawing.SystemColors.Window
    Me.lvTask.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lvTask.HideSelection = False
    Me.lvTask.LabelEdit = True
    Me.lvTask.Location = New System.Drawing.Point(0, 156)
    Me.lvTask.Name = "lvTask"
    Me.lvTask.Size = New System.Drawing.Size(617, 89)
    Me.lvTask.TabIndex = 0
    Me.lvTask.UseCompatibleStateImageBehavior = False
    '
    'lvProgress
    '
    Me.lvProgress.BackColor = System.Drawing.SystemColors.Window
    Me.lvProgress.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lvProgress.LabelEdit = True
    Me.lvProgress.Location = New System.Drawing.Point(0, 244)
    Me.lvProgress.Name = "lvProgress"
    Me.lvProgress.Size = New System.Drawing.Size(617, 213)
    Me.lvProgress.TabIndex = 1
    Me.lvProgress.UseCompatibleStateImageBehavior = False
    '
    'lvSchedule
    '
    Me.lvSchedule.BackColor = System.Drawing.SystemColors.Window
    Me.lvSchedule.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lvSchedule.HideSelection = False
    Me.lvSchedule.LabelEdit = True
    Me.lvSchedule.Location = New System.Drawing.Point(0, 64)
    Me.lvSchedule.Name = "lvSchedule"
    Me.lvSchedule.Size = New System.Drawing.Size(617, 93)
    Me.lvSchedule.TabIndex = 4
    Me.lvSchedule.UseCompatibleStateImageBehavior = False
    '
    'Image1
    '
    Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
    Me.Image1.Location = New System.Drawing.Point(0, 4)
    Me.Image1.Name = "Image1"
    Me.Image1.Size = New System.Drawing.Size(50, 52)
    Me.Image1.TabIndex = 7
    Me.Image1.TabStop = False
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label1.Location = New System.Drawing.Point(60, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label1.Size = New System.Drawing.Size(329, 41)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Proceso de Tareas de Backup"
    Me.Label1.UseMnemonic = False
    '
    'Line2
    '
    Me.Line2.BackColor = System.Drawing.SystemColors.ControlLight
    Me.Line2.Location = New System.Drawing.Point(0, 461)
    Me.Line2.Name = "Line2"
    Me.Line2.Size = New System.Drawing.Size(734, 1)
    Me.Line2.TabIndex = 8
    '
    'Line1
    '
    Me.Line1.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Line1.Location = New System.Drawing.Point(0, 460)
    Me.Line1.Name = "Line1"
    Me.Line1.Size = New System.Drawing.Size(734, 1)
    Me.Line1.TabIndex = 9
    '
    'Shape1
    '
    Me.Shape1.BackColor = System.Drawing.Color.White
    Me.Shape1.Location = New System.Drawing.Point(0, 0)
    Me.Shape1.Name = "Shape1"
    Me.Shape1.Size = New System.Drawing.Size(619, 65)
    Me.Shape1.TabIndex = 10
    '
    'MainMenu1
    '
    Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuView, Me.mnuHelp})
    Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
    Me.MainMenu1.Name = "MainMenu1"
    Me.MainMenu1.Size = New System.Drawing.Size(618, 24)
    Me.MainMenu1.TabIndex = 11
    '
    'mnuFile
    '
    Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
    Me.mnuFile.Name = "mnuFile"
    Me.mnuFile.Size = New System.Drawing.Size(60, 20)
    Me.mnuFile.Text = "&Archivo"
    '
    'mnuExit
    '
    Me.mnuExit.Name = "mnuExit"
    Me.mnuExit.Size = New System.Drawing.Size(96, 22)
    Me.mnuExit.Text = "&Salir"
    '
    'mnuView
    '
    Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConfig, Me.mnuMonitor})
    Me.mnuView.Name = "mnuView"
    Me.mnuView.Size = New System.Drawing.Size(36, 20)
    Me.mnuView.Text = "&Ver"
    '
    'mnuConfig
    '
    Me.mnuConfig.Name = "mnuConfig"
    Me.mnuConfig.Size = New System.Drawing.Size(178, 22)
    Me.mnuConfig.Text = "&Configuración"
    '
    'mnuMonitor
    '
    Me.mnuMonitor.Checked = True
    Me.mnuMonitor.CheckState = System.Windows.Forms.CheckState.Checked
    Me.mnuMonitor.Name = "mnuMonitor"
    Me.mnuMonitor.Size = New System.Drawing.Size(178, 22)
    Me.mnuMonitor.Text = "&Tareas en Ejecución"
    '
    'mnuHelp
    '
    Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpIndex, Me.mnuHelpAbout})
    Me.mnuHelp.Name = "mnuHelp"
    Me.mnuHelp.Size = New System.Drawing.Size(53, 20)
    Me.mnuHelp.Text = "&Ayuda"
    '
    'mnuHelpIndex
    '
    Me.mnuHelpIndex.Name = "mnuHelpIndex"
    Me.mnuHelpIndex.ShortcutKeys = System.Windows.Forms.Keys.F1
    Me.mnuHelpIndex.Size = New System.Drawing.Size(194, 22)
    Me.mnuHelpIndex.Text = "&Indice"
    '
    'mnuHelpAbout
    '
    Me.mnuHelpAbout.Name = "mnuHelpAbout"
    Me.mnuHelpAbout.Size = New System.Drawing.Size(194, 22)
    Me.mnuHelpAbout.Text = "&Acerca de CSBackup ..."
    '
    'picProgress
    '
    Me.picProgress.Location = New System.Drawing.Point(11, 468)
    Me.picProgress.Name = "picProgress"
    Me.picProgress.Size = New System.Drawing.Size(483, 23)
    Me.picProgress.TabIndex = 12
    '
    'popTask
    '
    Me.popTask.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.popExecute})
    Me.popTask.Name = "popTask"
    Me.popTask.Size = New System.Drawing.Size(149, 26)
    '
    'popExecute
    '
    Me.popExecute.Name = "popExecute"
    Me.popExecute.Size = New System.Drawing.Size(148, 22)
    Me.popExecute.Text = "Ejecutar Tarea"
    '
    'popSchedule
    '
    Me.popSchedule.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.popExecuteSchedule})
    Me.popSchedule.Name = "popTask"
    Me.popSchedule.Size = New System.Drawing.Size(195, 26)
    '
    'popExecuteSchedule
    '
    Me.popExecuteSchedule.Name = "popExecuteSchedule"
    Me.popExecuteSchedule.Size = New System.Drawing.Size(194, 22)
    Me.popExecuteSchedule.Text = "Ejecutar Programación"
    '
    'fBackup
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Window
    Me.CancelButton = Me.cmdCancel
    Me.ClientSize = New System.Drawing.Size(618, 498)
    Me.ControlBox = False
    Me.Controls.Add(Me.picProgress)
    Me.Controls.Add(Me.cmdCancel)
    Me.Controls.Add(Me.lvTask)
    Me.Controls.Add(Me.lvProgress)
    Me.Controls.Add(Me.lvSchedule)
    Me.Controls.Add(Me.Image1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Line2)
    Me.Controls.Add(Me.Line1)
    Me.Controls.Add(Me.Shape1)
    Me.Controls.Add(Me.MainMenu1)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Location = New System.Drawing.Point(4, 50)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fBackup"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
    CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.MainMenu1.ResumeLayout(False)
    Me.MainMenu1.PerformLayout()
    Me.popTask.ResumeLayout(False)
    Me.popSchedule.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents picProgress As System.Windows.Forms.ProgressBar
  Friend WithEvents popTask As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents popExecute As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents popSchedule As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents popExecuteSchedule As System.Windows.Forms.ToolStripMenuItem
#End Region 
End Class