Option Strict Off
Option Explicit On

Imports System.Windows.Forms.Application

Friend Class cMouseWait
	
  Private m_OldMouse As System.Windows.Forms.Cursor
	
  Private Sub ClassInitialize()
    m_OldMouse = System.Windows.Forms.Cursor.Current
    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
    DoEvents()
  End Sub
  Public Sub New()
    MyBase.New()
    ClassInitialize()
  End Sub
	
  Private Sub ClassTerminate()
    System.Windows.Forms.Cursor.Current = m_OldMouse
  End Sub
  Protected Overrides Sub Finalize()
    ClassTerminate()
    MyBase.Finalize()
  End Sub
End Class