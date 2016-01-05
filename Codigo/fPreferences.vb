Option Strict Off
Option Explicit On
Friend Class fPreferences
	Inherits System.Windows.Forms.Form
	
	Private Sub chkMasterPassword_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkMasterPassword.CheckStateChanged
    If chkMasterPassword.CheckState = System.Windows.Forms.CheckState.Checked Then
      cmdSetMasterPassword.Enabled = True
    Else
      cmdSetMasterPassword.Enabled = False
    End If
  End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		
		Dim OldMasterPassword As String
		OldMasterPassword = GetMasterPassword()
		

    If chkMasterPassword.CheckState = System.Windows.Forms.CheckState.Checked And GetMasterPassword() = "" Then

      If Not RequestMasterPassword(True) Then Exit Sub

    End If

    If OldMasterPassword <> GetMasterPassword() Then

      ChangeMasterPassword(OldMasterPassword, GetMasterPassword)

    End If

    If txPassword.Text <> txPassword2.Text Then

      MsgWarning("La clave y su confirmación no coinciden")
      Exit Sub
    End If

    SetIniValue(csSecConfig, csUseMasterPassword, IIf(chkMasterPassword.CheckState = System.Windows.Forms.CheckState.Checked, 1, 0), GetIniFullFile(csIniFile))
    SetIniValue(csSecConfig, csPasswordTestValue, EncryptData(c_testvalue, GetMasterPassword()), GetIniFullFile(csIniFile))
    SetIniValue(csSecConfig, csDbPath, Me.txPath.Text, GetIniFullFile(csIniFile))
    SetIniValue(csSecConfig, csInitWithWindows, IIf(chkInitWithWindows.CheckState = System.Windows.Forms.CheckState.Checked, 1, 0), GetIniFullFile(csIniFile))

    Dim Password As String
    Password = GetProgramPassword()

    SetIniValue(csSecConfig, csPasswordFiles, EncryptData(txPassword.Text, Password), GetIniFullFile(csIniFile))

    LoadPasswordFiles()

    pSetInitWithWindows()

    Me.Close()
    LoadTask((fMain.lvTask))
    LoadSchedule((fMain.lvSchedule))
  End Sub

  Private Sub cmdOpenFolder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpenFolder.Click
    Dim Fld As cFolder
    Dim sPath As String

    Fld = New cFolder

    sPath = Fld.SelectFolder(Me.Handle.ToInt32)

    If sPath <> "" Then
      Me.txPath.Text = sPath
    End If

    Fld = Nothing
  End Sub

  Private Sub fPreferences_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    Me.txPath.Text = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))

    Me.txPassword.Text = GetPasswordFiles()
    Me.txPassword2.Text = GetPasswordFiles()

    If Val(GetIniValue(csSecConfig, csUseMasterPassword, CStr(0), GetIniFullFile(csIniFile))) Then
      chkMasterPassword.CheckState = System.Windows.Forms.CheckState.Checked
    Else
      chkMasterPassword.CheckState = System.Windows.Forms.CheckState.Unchecked
    End If

    If Val(GetIniValue(csSecConfig, csInitWithWindows, CStr(1), GetIniFullFile(csIniFile))) Then
      chkInitWithWindows.CheckState = System.Windows.Forms.CheckState.Checked
    Else
      chkInitWithWindows.CheckState = System.Windows.Forms.CheckState.Unchecked
    End If


    If GetMasterPassword() <> "" Then
      cmdSetMasterPassword.Text = "Cambiar la clave maestra"
    End If

    chkMasterPassword_CheckStateChanged(chkMasterPassword, New System.EventArgs())

  End Sub
	
End Class