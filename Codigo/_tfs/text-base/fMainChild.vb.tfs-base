Option Strict Off
Option Explicit On
Friend Class fMain
	Inherits System.Windows.Forms.Form
	
	Private Const C_Module As String = "fMainChild"
	
	Private Sub fMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    Try

      With lvTask
        .View = System.Windows.Forms.View.Details
        .GridLines = True
        .LabelEdit = False
        .FullRowSelect = True
        .BorderStyle = System.Windows.Forms.BorderStyle.None
        .SmallImageList = ImageList1
      End With

      With lvSchedule
        .View = System.Windows.Forms.View.Details
        .GridLines = True
        .LabelEdit = False
        .FullRowSelect = True
        .BorderStyle = System.Windows.Forms.BorderStyle.None
        .SmallImageList = ImageList1
      End With

      Me.ControlBox = False
      Me.MaximizeBox = False
      Me.MinimizeBox = False

    Catch ex As Exception

      MngError(ex, "Form_Load", C_Module, "")

    End Try
  End Sub

  Private Sub fMain_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim Cancel As Boolean = eventArgs.Cancel
    Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
    If NotUnloadFromAppOrWindows(UnloadMode) Then
      Cancel = True
    End If
    eventArgs.Cancel = Cancel
  End Sub

  Private Sub lvSchedule_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvSchedule.DoubleClick
    fMainMDI.mnuScheduleEdit_Click(Nothing, New System.EventArgs())
  End Sub

  Private Sub lvTask_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvTask.DoubleClick
    fMainMDI.mnuTaskEdit_Click(Nothing, New System.EventArgs())
  End Sub

  Private Sub lvTask_ItemClick(ByVal Item As System.Windows.Forms.ListViewItem)
    lbDescrip.Text = Item.Tag
  End Sub

  Private Sub fMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    Try

      Const csBottomHeight As Short = 66
      Dim iHeight As Single

      iHeight = (Me.ClientRectangle.Height - csBottomHeight - shTop.Height) / 2
      lvTask.SetBounds(0, shTop.Height, Me.ClientRectangle.Width, iHeight)
      lvSchedule.SetBounds(0, lvTask.Top + iHeight, Me.ClientRectangle.Width, iHeight)
      lbDescrip.SetBounds(7, Me.ClientRectangle.Height - csBottomHeight + 7, Me.ClientRectangle.Width - 14, csBottomHeight - 14)
      shBottom.SetBounds(0, Me.ClientRectangle.Height - csBottomHeight, Me.ClientRectangle.Width, csBottomHeight)
      shBottomBorder.SetBounds(3, Me.ClientRectangle.Height - csBottomHeight + 3, Me.ClientRectangle.Width - 7, csBottomHeight - 7)

    Catch

    End Try
  End Sub

End Class