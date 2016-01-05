<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class fMainMDI
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
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public CommonDialog1Save As System.Windows.Forms.SaveFileDialog
	Public CommonDialog1Font As System.Windows.Forms.FontDialog
	Public CommonDialog1Color As System.Windows.Forms.ColorDialog
	Public CommonDialog1Print As System.Windows.Forms.PrintDialog
	Public WithEvents cmdTaskProgress As System.Windows.Forms.Button
	Public WithEvents cmdConfig As System.Windows.Forms.Button
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents _stbMain_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents stbMain As System.Windows.Forms.StatusStrip
	Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTaskNew As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTaskEdit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTaskDelete As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTask As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuScheduleNew As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuScheduleEdit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuScheduleDelete As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSchedule As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSQLServerNewTask As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSQLServerEditTask As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSQLServer As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuBackup As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuToolsSep As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuPreferences As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelpIndex As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
  Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMainMDI))
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
    Me.CommonDialog1Save = New System.Windows.Forms.SaveFileDialog
    Me.CommonDialog1Font = New System.Windows.Forms.FontDialog
    Me.CommonDialog1Color = New System.Windows.Forms.ColorDialog
    Me.CommonDialog1Print = New System.Windows.Forms.PrintDialog
    Me.Picture1 = New System.Windows.Forms.Panel
    Me.cmdTaskProgress = New System.Windows.Forms.Button
    Me.cmdConfig = New System.Windows.Forms.Button
    Me.stbMain = New System.Windows.Forms.StatusStrip
    Me._stbMain_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
    Me.MainMenu1 = New System.Windows.Forms.MenuStrip
    Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuTask = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuTaskNew = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuTaskEdit = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuTaskDelete = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuSchedule = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuScheduleNew = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuScheduleEdit = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuScheduleDelete = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuSQLServer = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuSQLServerNewTask = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuSQLServerEditTask = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuBackup = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuToolsSep = New System.Windows.Forms.ToolStripSeparator
    Me.mnuPreferences = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuHelpIndex = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
    Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.popRestore = New System.Windows.Forms.ToolStripMenuItem
    Me.popExit = New System.Windows.Forms.ToolStripMenuItem
    Me.Picture1.SuspendLayout()
    Me.stbMain.SuspendLayout()
    Me.MainMenu1.SuspendLayout()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Picture1
    '
    Me.Picture1.BackColor = System.Drawing.SystemColors.Control
    Me.Picture1.Controls.Add(Me.cmdTaskProgress)
    Me.Picture1.Controls.Add(Me.cmdConfig)
    Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Picture1.Location = New System.Drawing.Point(0, 24)
    Me.Picture1.Name = "Picture1"
    Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Picture1.Size = New System.Drawing.Size(622, 33)
    Me.Picture1.TabIndex = 1
    Me.Picture1.TabStop = True
    '
    'cmdTaskProgress
    '
    Me.cmdTaskProgress.BackColor = System.Drawing.SystemColors.Control
    Me.cmdTaskProgress.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdTaskProgress.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdTaskProgress.Location = New System.Drawing.Point(136, 4)
    Me.cmdTaskProgress.Name = "cmdTaskProgress"
    Me.cmdTaskProgress.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdTaskProgress.Size = New System.Drawing.Size(129, 25)
    Me.cmdTaskProgress.TabIndex = 3
    Me.cmdTaskProgress.Text = "Tareas en Ejecución"
    Me.cmdTaskProgress.UseVisualStyleBackColor = False
    '
    'cmdConfig
    '
    Me.cmdConfig.BackColor = System.Drawing.SystemColors.Control
    Me.cmdConfig.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdConfig.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdConfig.Location = New System.Drawing.Point(4, 4)
    Me.cmdConfig.Name = "cmdConfig"
    Me.cmdConfig.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdConfig.Size = New System.Drawing.Size(129, 25)
    Me.cmdConfig.TabIndex = 2
    Me.cmdConfig.Text = "Configuración"
    Me.cmdConfig.UseVisualStyleBackColor = False
    '
    'stbMain
    '
    Me.stbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._stbMain_Panel1})
    Me.stbMain.Location = New System.Drawing.Point(0, 594)
    Me.stbMain.Name = "stbMain"
    Me.stbMain.Size = New System.Drawing.Size(622, 22)
    Me.stbMain.TabIndex = 0
    '
    '_stbMain_Panel1
    '
    Me._stbMain_Panel1.AutoSize = False
    Me._stbMain_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
    Me._stbMain_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
    Me._stbMain_Panel1.Margin = New System.Windows.Forms.Padding(0)
    Me._stbMain_Panel1.Name = "_stbMain_Panel1"
    Me._stbMain_Panel1.Size = New System.Drawing.Size(96, 22)
    Me._stbMain_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'MainMenu1
    '
    Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuTask, Me.mnuSchedule, Me.mnuSQLServer, Me.mnuTools, Me.mnuHelp})
    Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
    Me.MainMenu1.Name = "MainMenu1"
    Me.MainMenu1.Size = New System.Drawing.Size(622, 24)
    Me.MainMenu1.TabIndex = 2
    '
    'mnuFile
    '
    Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
    Me.mnuFile.MergeAction = System.Windows.Forms.MergeAction.Remove
    Me.mnuFile.Name = "mnuFile"
    Me.mnuFile.Size = New System.Drawing.Size(55, 20)
    Me.mnuFile.Text = "&Archivo"
    '
    'mnuExit
    '
    Me.mnuExit.Name = "mnuExit"
    Me.mnuExit.Size = New System.Drawing.Size(94, 22)
    Me.mnuExit.Text = "&Salir"
    '
    'mnuTask
    '
    Me.mnuTask.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTaskNew, Me.mnuTaskEdit, Me.mnuTaskDelete})
    Me.mnuTask.MergeAction = System.Windows.Forms.MergeAction.Remove
    Me.mnuTask.Name = "mnuTask"
    Me.mnuTask.Size = New System.Drawing.Size(52, 20)
    Me.mnuTask.Text = "&Tareas"
    '
    'mnuTaskNew
    '
    Me.mnuTaskNew.Name = "mnuTaskNew"
    Me.mnuTaskNew.Size = New System.Drawing.Size(120, 22)
    Me.mnuTaskNew.Text = "&Nueva ..."
    '
    'mnuTaskEdit
    '
    Me.mnuTaskEdit.Name = "mnuTaskEdit"
    Me.mnuTaskEdit.Size = New System.Drawing.Size(120, 22)
    Me.mnuTaskEdit.Text = "&Editar ..."
    '
    'mnuTaskDelete
    '
    Me.mnuTaskDelete.Name = "mnuTaskDelete"
    Me.mnuTaskDelete.Size = New System.Drawing.Size(120, 22)
    Me.mnuTaskDelete.Text = "&Borrar"
    '
    'mnuSchedule
    '
    Me.mnuSchedule.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuScheduleNew, Me.mnuScheduleEdit, Me.mnuScheduleDelete})
    Me.mnuSchedule.MergeAction = System.Windows.Forms.MergeAction.Remove
    Me.mnuSchedule.Name = "mnuSchedule"
    Me.mnuSchedule.Size = New System.Drawing.Size(95, 20)
    Me.mnuSchedule.Text = "&Programaciones"
    '
    'mnuScheduleNew
    '
    Me.mnuScheduleNew.Name = "mnuScheduleNew"
    Me.mnuScheduleNew.Size = New System.Drawing.Size(120, 22)
    Me.mnuScheduleNew.Text = "&Nueva ..."
    '
    'mnuScheduleEdit
    '
    Me.mnuScheduleEdit.Name = "mnuScheduleEdit"
    Me.mnuScheduleEdit.Size = New System.Drawing.Size(120, 22)
    Me.mnuScheduleEdit.Text = "&Editar ..."
    '
    'mnuScheduleDelete
    '
    Me.mnuScheduleDelete.Name = "mnuScheduleDelete"
    Me.mnuScheduleDelete.Size = New System.Drawing.Size(120, 22)
    Me.mnuScheduleDelete.Text = "&Borrar"
    '
    'mnuSQLServer
    '
    Me.mnuSQLServer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSQLServerNewTask, Me.mnuSQLServerEditTask})
    Me.mnuSQLServer.MergeAction = System.Windows.Forms.MergeAction.Remove
    Me.mnuSQLServer.Name = "mnuSQLServer"
    Me.mnuSQLServer.Size = New System.Drawing.Size(73, 20)
    Me.mnuSQLServer.Text = "&SQL Server"
    '
    'mnuSQLServerNewTask
    '
    Me.mnuSQLServerNewTask.Name = "mnuSQLServerNewTask"
    Me.mnuSQLServerNewTask.Size = New System.Drawing.Size(203, 22)
    Me.mnuSQLServerNewTask.Text = "&Nueva Tarea de Backup ..."
    '
    'mnuSQLServerEditTask
    '
    Me.mnuSQLServerEditTask.Name = "mnuSQLServerEditTask"
    Me.mnuSQLServerEditTask.Size = New System.Drawing.Size(203, 22)
    Me.mnuSQLServerEditTask.Text = "&Editar Tarea de Backup ..."
    '
    'mnuTools
    '
    Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBackup, Me.mnuToolsSep, Me.mnuPreferences})
    Me.mnuTools.MergeAction = System.Windows.Forms.MergeAction.Remove
    Me.mnuTools.Name = "mnuTools"
    Me.mnuTools.Size = New System.Drawing.Size(83, 20)
    Me.mnuTools.Text = "&Herramientas"
    '
    'mnuBackup
    '
    Me.mnuBackup.Name = "mnuBackup"
    Me.mnuBackup.Size = New System.Drawing.Size(182, 22)
    Me.mnuBackup.Text = "&Tareas en Ejecución..."
    '
    'mnuToolsSep
    '
    Me.mnuToolsSep.Name = "mnuToolsSep"
    Me.mnuToolsSep.Size = New System.Drawing.Size(179, 6)
    '
    'mnuPreferences
    '
    Me.mnuPreferences.Name = "mnuPreferences"
    Me.mnuPreferences.Size = New System.Drawing.Size(182, 22)
    Me.mnuPreferences.Text = "&Opciones ..."
    '
    'mnuHelp
    '
    Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpIndex, Me.mnuAbout})
    Me.mnuHelp.MergeAction = System.Windows.Forms.MergeAction.Remove
    Me.mnuHelp.Name = "mnuHelp"
    Me.mnuHelp.Size = New System.Drawing.Size(50, 20)
    Me.mnuHelp.Text = "A&yuda"
    '
    'mnuHelpIndex
    '
    Me.mnuHelpIndex.Name = "mnuHelpIndex"
    Me.mnuHelpIndex.ShortcutKeys = System.Windows.Forms.Keys.F1
    Me.mnuHelpIndex.Size = New System.Drawing.Size(187, 22)
    Me.mnuHelpIndex.Text = "&Indice"
    '
    'mnuAbout
    '
    Me.mnuAbout.Name = "mnuAbout"
    Me.mnuAbout.Size = New System.Drawing.Size(187, 22)
    Me.mnuAbout.Text = "&Acerca de CSBackup ..."
    '
    'NotifyIcon1
    '
    Me.NotifyIcon1.Text = "NotifyIcon1"
    Me.NotifyIcon1.Visible = True
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.popRestore, Me.popExit})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(132, 48)
    Me.ContextMenuStrip1.Text = "dfsdfsd"
    '
    'popRestore
    '
    Me.popRestore.Name = "popRestore"
    Me.popRestore.Size = New System.Drawing.Size(131, 22)
    Me.popRestore.Text = "Restablecer"
    '
    'popExit
    '
    Me.popExit.Name = "popExit"
    Me.popExit.Size = New System.Drawing.Size(131, 22)
    Me.popExit.Text = "Salir"
    '
    'fMainMDI
    '
    Me.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.ClientSize = New System.Drawing.Size(622, 616)
    Me.Controls.Add(Me.Picture1)
    Me.Controls.Add(Me.stbMain)
    Me.Controls.Add(Me.MainMenu1)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.IsMdiContainer = True
    Me.Location = New System.Drawing.Point(11, 57)
    Me.MinimumSize = New System.Drawing.Size(630, 650)
    Me.Name = "fMainMDI"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Text = "CSBackup"
    Me.Picture1.ResumeLayout(False)
    Me.stbMain.ResumeLayout(False)
    Me.stbMain.PerformLayout()
    Me.MainMenu1.ResumeLayout(False)
    Me.MainMenu1.PerformLayout()
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents popRestore As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents popExit As System.Windows.Forms.ToolStripMenuItem
#End Region 
End Class