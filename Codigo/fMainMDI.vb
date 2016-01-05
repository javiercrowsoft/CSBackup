Option Strict Off
Option Explicit On
Friend Class fMainMDI

  Inherits System.Windows.Forms.Form
	
  Private m_bLoaded As Boolean = False

	Private Const C_Module As String = "fMainMdi"
	
	Public Sub CloseProgram()
		mnuExit_Click(mnuExit, New System.EventArgs())
	End Sub
	
  Private Sub cmdConfig_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConfig.Click
    'fBackup.Hide()
    'fMain.Show()
    'fMain.SetBounds(0, 0, Me.ClientSize.Width - 4, Me.ClientSize.Height - (Me.Picture1.Height + Me.stbMain.Height + 30))
    fMain.Activate()
  End Sub
	
	Private Sub cmdTaskProgress_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTaskProgress.Click
    'fMain.Hide()
    'fBackup.Show()
    'fBackup.SetBounds(0, 0, Me.ClientSize.Width - 4, Me.ClientSize.Height - (Me.Picture1.Height + Me.stbMain.Height + 30))
    fBackup.Activate()
  End Sub
	
	Private Sub fMainMDI_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    Try

      Main()

      Me.NotifyIcon1.Icon = Me.Icon
      Me.NotifyIcon1.Visible = False
      Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1

      With stbMain
        .Items.Clear()
        .Items.Add(New System.Windows.Forms.ToolStripStatusLabel())
        .Items.Add(New System.Windows.Forms.ToolStripStatusLabel())
        .Items.Add(New System.Windows.Forms.ToolStripStatusLabel())
      End With

      m_bLoaded = True

      fMainMDI_SizeChanged(Me, New System.EventArgs())
      cmdConfig_Click(Me, New System.EventArgs())

    Catch ex As Exception

      MngError(ex, "MDIForm_Load", C_Module, "")

    End Try
  End Sub

  Private Sub fMainMDI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If e.CloseReason = CloseReason.UserClosing Then
      Me.NotifyIcon1.Visible = True
      Me.Hide()
      e.Cancel = True
    End If
  End Sub

  Public Sub mnuAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAbout.Click
    ShowAbout()
  End Sub

  Public Sub mnuBackup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuBackup.Click
    fBackup.Show()
    fBackup.BringToFront()
  End Sub

  Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
    Try

      Me.Close()
      End

    Catch ex As Exception

      MngError(ex, "mnuExit_Click", C_Module, "")

    End Try
  End Sub

  Public Sub mnuHelpIndex_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpIndex.Click
    ShowHelp()
  End Sub

  Public Sub mnuPreferences_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPreferences.Click
    Try

      EditPreferences(False)

    Catch ex As Exception

      MngError(ex, "mnuPreferences_Click", C_Module, "")

    End Try
  End Sub

  Public Sub mnuScheduleDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuScheduleDelete.Click
    Try

      If fMain.lvSchedule.FocusedItem Is Nothing Then Exit Sub
      If Ask("¿Confirma que desea borrar?" & vbCrLf & vbCrLf & _
                fMain.lvSchedule.FocusedItem.Text & vbCrLf & _
                fMain.lvSchedule.FocusedItem.SubItems(1).Text, _
                MsgBoxResult.No) Then

        Kill(fMain.lvSchedule.FocusedItem.SubItems(1).Text)
        LoadSchedule((fMain.lvSchedule))
        fBackup.ReLoad()
      End If

    Catch ex As Exception

      MngError(ex, "mnuScheduleDelete_Click", C_Module, "")

    End Try
  End Sub

  Public Sub mnuScheduleEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuScheduleEdit.Click
    Try

      If fMain.lvSchedule.FocusedItem Is Nothing Then Exit Sub

      fSchedule.Edit(fMain.lvSchedule.FocusedItem.SubItems(1).Text)
      LoadSchedule((fMain.lvSchedule))
      fBackup.ReLoad()

    Catch ex As Exception

      MngError(ex, "mnuScheduleEdit_Click", C_Module, "")

    End Try
  End Sub

  Public Sub mnuScheduleNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuScheduleNew.Click
    Try

      fSchedule.Edit("")
      LoadSchedule((fMain.lvSchedule))
      fBackup.ReLoad()

    Catch ex As Exception

      MngError(ex, "mnuScheduleNew_Click", C_Module, "")

    End Try
  End Sub

  Public Sub mnuSQLServerEditTask_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSQLServerEditTask.Click
    mnuTaskEdit_Click(mnuTaskEdit, New System.EventArgs())
  End Sub

  Public Sub mnuSQLServerNewTask_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSQLServerNewTask.Click
    Try

      fTaskCommandBackup.Edit("")
      LoadTask((fMain.lvTask))
      fBackup.ReLoad()

    Catch ex As Exception

      MngError(ex, "mnuSQLServerNewTask_Click", C_Module, "")

    End Try
  End Sub

  Public Sub mnuTaskDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTaskDelete.Click
    Try

      If fMain.lvTask.FocusedItem Is Nothing Then Exit Sub

      If Ask("¿Confirma que desea borrar?" & vbCrLf & vbCrLf & _
                     fMain.lvTask.FocusedItem.Text & vbCrLf & _
                     fMain.lvTask.FocusedItem.SubItems(1).Text, _
                     MsgBoxResult.No) Then

        Kill(fMain.lvTask.FocusedItem.SubItems(1).Text)
        LoadTask((fMain.lvTask))
        fBackup.ReLoad()
      End If

    Catch ex As Exception

      MngError(ex, "mnuTaskDelete_Click", C_Module, "")

    End Try
  End Sub

  Public Sub mnuTaskEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTaskEdit.Click
    Try

      If fMain.lvTask.FocusedItem Is Nothing Then Exit Sub

      Dim TaskFile As String

      TaskFile = fMain.lvTask.FocusedItem.SubItems(1).Text

      If TaskType(TaskFile, False) = mPublic.csETaskTypeBackup.c_TaskTypeBackupDB Then
        fTaskCommandBackup.Edit(TaskFile)
      Else
        fTask.Edit(TaskFile)
      End If
      LoadTask((fMain.lvTask))
      fBackup.ReLoad()

    Catch ex As Exception

      MngError(ex, "mnuTaskEdit_Click", C_Module, "")

    End Try
  End Sub

  Public Sub mnuTaskNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTaskNew.Click
    Try

      fTask.Edit("")
      LoadTask((fMain.lvTask))
      fBackup.ReLoad()

    Catch ex As Exception

      MngError(ex, "mnuTaskNew_Click", C_Module, "")

    End Try
  End Sub

  Public Sub ShowHelp()

  End Sub

  Public Sub ShowAbout()
    fAbout.ShowDialog()
  End Sub

  Private Sub popExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles popExit.Click
    mnuExit_Click(mnuExit, New System.EventArgs())
  End Sub

  Private Sub popRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles popRestore.Click
    Me.NotifyIcon1.Visible = False
    Me.Visible = True
    Me.Show()
  End Sub

  Private Sub fMainMDI_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
    If m_bLoaded Then
      fBackup.SetBounds(0, 0, Me.ClientSize.Width - 4, Me.ClientSize.Height - (Me.Picture1.Height + Me.stbMain.Height + 30))
      fMain.SetBounds(0, 0, Me.ClientSize.Width - 4, Me.ClientSize.Height - (Me.Picture1.Height + Me.stbMain.Height + 30))
    End If
  End Sub
End Class




