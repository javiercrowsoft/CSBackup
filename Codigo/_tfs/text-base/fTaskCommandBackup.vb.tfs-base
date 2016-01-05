Option Strict Off
Option Explicit On
Friend Class fTaskCommandBackup
	Inherits System.Windows.Forms.Form
	
	'--------------------------------------------------------------------------------
	' fTaskCommandBackup
	' 25-05-2002
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes
	' estructuras
	' funciones
	
	'--------------------------------------------------------------------------------
	
	' constantes
	Private Const C_Module As String = "fTaskCommandBackup"
	
	' estructuras
	' variables privadas
	Private m_CmdBackup As cSQLTaskCommandBackup
	
	Private m_Changed As Boolean
	
	Private WithEvents m_fSQLLogin As fSQLLogin
	
	' eventos
	' propiedadades publicas
	' propiedadades friend
	' propiedades privadas
	' funciones publicas
	Public Function Edit(ByVal SQLServerTaskFile As String) As Boolean
		
		Dim Server As String
		Dim User As String
		Dim Password As String
		Dim SecurityType As mAux.csSQLSecurityType
		
		m_CmdBackup = New cSQLTaskCommandBackup
		
    If SQLServerTaskFile <> "" Then

      If Not m_CmdBackup.Load(SQLServerTaskFile, False) Then
        Exit Function
      End If

      If Not m_CmdBackup.Connect(m_CmdBackup.Server, m_CmdBackup.User, m_CmdBackup.Pwd, m_CmdBackup.SecurityType, False) Then

        Server = m_CmdBackup.Server
        User = m_CmdBackup.DataBase
        Password = m_CmdBackup.Pwd
        SecurityType = m_CmdBackup.SecurityType

        fSQLLogin.SetLogin(Server, User, Password, SecurityType)

        If Not pLogin() Then Exit Function

      End If

    Else

      If Not pLogin() Then Exit Function

    End If

    With Me

      .txName.Text = m_CmdBackup.Name
      SelectItemByText(.cbDataBases, m_CmdBackup.DataBase)
      .txCode.Text = m_CmdBackup.Code
      .txFile.Text = m_CmdBackup.File
      .txDescrip.Text = m_CmdBackup.Descrip

      .txFtpAddress.Text = m_CmdBackup.FtpAddress
      .txFtpUser.Text = m_CmdBackup.FtpUser
      .txFtpPwd.Text = m_CmdBackup.FtpPwd
      .txFtpPort.Text = CStr(m_CmdBackup.FtpPort)

    End With

    m_Changed = False

    Me.ShowDialog()

  End Function
  ' funciones friend
  ' funciones privadas
  Private Function pLogin() As Boolean

    m_fSQLLogin = fSQLLogin
    fSQLLogin.ShowDialog()

    If Not fSQLLogin.Ok Then Exit Function

    m_CmdBackup.Server = fSQLLogin.cbServer.Text
    m_CmdBackup.User = fSQLLogin.txUser.Text
    m_CmdBackup.Pwd = fSQLLogin.txPassword.Text
    m_CmdBackup.SecurityType = IIf(fSQLLogin.opNt.Checked, mAux.csSQLSecurityType.csTSNT, mAux.csSQLSecurityType.csTSSQL)

    pLogin = True
  End Function

  Private Sub LoadDataBases()
    Try

      Dim i As Integer
      Dim coll As Collection

      coll = m_CmdBackup.Conn.ListDataBases()

      cbDataBases.Items.Clear()

      For i = 1 To coll.Count()
        If LCase(coll.Item(i)) <> "master" Then
          AddItemToList(cbDataBases, coll.Item(i))
        End If
      Next

      cbDataBases.SelectedIndex = 0

    Catch ex As Exception
      MngError(Ex, "LoadDataBases", C_Module, "")
    End Try
  End Sub

  Private Sub cbDataBases_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbDataBases.SelectedIndexChanged
    Dim Path As String
    Path = GetPath_(txFileData.Text)
    If Mid(Path, 2, 1) <> ":" Then Path = ""
    If Path <> "" Then Path = FileGetValidPath(Path)
    txFileData.Text = Path & cbDataBases.Text & "_dat.bak"

    Path = GetPath_(txFileLog.Text)
    If Mid(Path, 2, 1) <> ":" Then Path = ""
    If Path <> "" Then Path = FileGetValidPath(Path)
    txFileLog.Text = Path & cbDataBases.Text & "_log.bak"
  End Sub

  Private Sub chkDataBaseFileDefault_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDataBaseFileDefault.CheckStateChanged
    cmdFindFile.Enabled = chkDataBaseFileDefault.CheckState <> System.Windows.Forms.CheckState.Checked
    txFileData.Text = GetFileName_(txFileData.Text)
  End Sub

  Private Sub chkLofFileDefault_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkLofFileDefault.CheckStateChanged
    cmdFileLog.Enabled = chkLofFileDefault.CheckState <> System.Windows.Forms.CheckState.Checked
    txFileLog.Text = GetFileName_(txFileLog.Text)
  End Sub

  Private Sub cmdFileLog_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFileLog.Click
    Try

      Dim File As String
      Dim DataBase As String

      DataBase = cbDataBases.Text & "_log.dat"

      File = m_CmdBackup.ShowFindFileBackup(DataBase, txFileLog.Text, Me.Text)
      If File <> "" Then txFileLog.Text = File

    Catch ex As Exception

      MngError(ex, "cmdFileLog_Click", C_Module, "")

    End Try
  End Sub

  Private Sub cmdFindFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFindFile.Click
    Try


      Dim File As String
      Dim DataBase As String

      DataBase = cbDataBases.Text & "_db.dat"

      File = m_CmdBackup.ShowFindFileBackup(DataBase, txFileData.Text, Me.Text)
      If File <> "" Then txFileData.Text = File

    Catch ex As Exception

      MngError(ex, "cmdFindFile_Click", C_Module, "")

    End Try
  End Sub

  Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
    Me.Close()
  End Sub

  Private Sub cmdOpenFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpenFile.Click

    With dlgSave
      .Filter = "Archivos de Backup de CrowSoft|*.cszip"
      .ShowDialog()
      If .FileName <> "" Then
        txFile.Text = .FileName
      End If
    End With
  End Sub

  Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
    pSave()
  End Sub

  Private Sub cmdSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveAs.Click
    Dim TaskName As String
    TaskName = InputBox("Ingrese el nombre", "Guardar Como", "Nueva Tarea")

    If TaskName <> "" Then
      txCode.Text = TaskName
      pSave()
    End If

  End Sub

  Private Sub cmdServerFolder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdServerFolder.Click
    Try

      Dim File As String = ""

      With dlgOpen
        .Filter = "Archivos de Backup de Base de datos|*.dat|Todos los archivos|*.*"
        .ShowDialog()
        If .FileName <> "" Then
          File = .FileName
        End If
      End With
      If File <> "" Then txServerFolder.Text = GetPath_(File)

    Catch ex As Exception

      MngError(ex, "cmdServerFolder_Click", C_Module, "")

    End Try
  End Sub

  Private Sub m_fSQLLogin_Connect(ByRef Cancel As Boolean) Handles m_fSQLLogin.Connect
    Cancel = Not m_CmdBackup.Connect(m_fSQLLogin.cbServer.Text, m_fSQLLogin.txUser.Text, m_fSQLLogin.txPassword.Text, IIf(m_fSQLLogin.opNt.Checked, mAux.csSQLSecurityType.csTSNT, mAux.csSQLSecurityType.csTSSQL), False)
  End Sub

  Private Sub opDataBase_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opDataBase.CheckedChanged
    If eventSender.Checked Then
      chkInitLog.Enabled = True
    End If
  End Sub

  Private Sub opLog_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opLog.CheckedChanged
    If eventSender.Checked Then
      chkInitLog.Enabled = False
    End If
  End Sub

  Private Sub ShowData()
    If m_CmdBackup.DataBase = "" Then Exit Sub
    txName.Text = m_CmdBackup.Name
    SelectItemByText(cbDataBases, m_CmdBackup.DataBase)
    txFileData.Text = m_CmdBackup.FileDataBase
    txFileLog.Text = m_CmdBackup.FileLog
    txServerFolder.Text = m_CmdBackup.ServerFolder
    txZips.Text = m_CmdBackup.ZipFiles
    chkDataBaseFileDefault.CheckState = IIf(m_CmdBackup.DataBaseUseDefaultPath, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
    chkLofFileDefault.CheckState = IIf(m_CmdBackup.LogUseDefaultPath, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
    chkInitLog.CheckState = IIf(m_CmdBackup.InitLog, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
    chkOverWrite.CheckState = IIf(m_CmdBackup.OverWrite, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
    opDataBase.Checked = m_CmdBackup.IsLog = False
    opLog.Checked = m_CmdBackup.IsLog = True
  End Sub

  Private Function pSave() As Boolean

    If Not ValidateValue() Then Exit Function

    CollectData()

    If m_CmdBackup.Save Then
      m_Changed = False
      pSave = True
    End If
  End Function

  Private Function ValidateValue() As Boolean

    If txName.Text = "" Then
      Info("Debe indicar un nombre para la tarea")
      SetFocusControl(txName)
      Exit Function
    End If

    If txFile.Text = "" Then
      Info("Debe indicar el nombre del archivo de backup que sera generado por la tarea")
      SetFocusControl(txFile)
      Exit Function
    End If

    If txCode.Text = "" Then
      Info("Debe indicar un codigo para la tarea")
      SetFocusControl(txCode)
      Exit Function
    End If

    If txFileData.Text = "" Then
      Info("Debe indicar el nombre del archivo de backup para la base de datos")
      SetFocusControl(txFileData)
      Exit Function
    End If

    If txFileLog.Text = "" Then
      Info("Debe indicar el nombre del archivo de backup para el log de transacciones")
      SetFocusControl(txFileLog)
      Exit Function
    End If

    ValidateValue = True
  End Function

  Private Sub CollectData()

    Dim Init As Boolean
    Dim OverWrite As Boolean
    Dim DataBase As String
    Dim FileDataBase As String
    Dim FileLog As String
    Dim ServerFolder As String
    Dim ZipFiles As Integer
    Dim IsFull As Boolean
    Dim LogDefaultPath As Boolean
    Dim DataBaseDefaultPath As Boolean

    Init = chkInitLog.CheckState = System.Windows.Forms.CheckState.Checked
    OverWrite = chkOverWrite.CheckState = System.Windows.Forms.CheckState.Checked
    DataBase = cbDataBases.Text
    FileDataBase = txFileData.Text
    FileLog = txFileLog.Text
    ServerFolder = txServerFolder.Text
    ZipFiles = Val(txZips.Text)
    IsFull = opDataBase.Checked

    DataBaseDefaultPath = chkDataBaseFileDefault.CheckState = System.Windows.Forms.CheckState.Checked
    LogDefaultPath = chkLofFileDefault.CheckState = System.Windows.Forms.CheckState.Checked

    m_CmdBackup.Name = txName.Text
    m_CmdBackup.File = txFile.Text
    m_CmdBackup.Descrip = txDescrip.Text
    m_CmdBackup.Code = txCode.Text

    m_CmdBackup.FtpAddress = txFtpAddress.Text
    m_CmdBackup.FtpUser = txFtpUser.Text
    m_CmdBackup.FtpPwd = txFtpPwd.Text
    m_CmdBackup.FtpPort = Val(txFtpPort.Text)

    m_CmdBackup.DataBase = DataBase
    m_CmdBackup.InitLog = Init
    m_CmdBackup.IsFull = IsFull
    m_CmdBackup.IsLog = Not IsFull
    m_CmdBackup.FileDataBase = FileDataBase
    m_CmdBackup.FileLog = FileLog
    m_CmdBackup.ServerFolder = ServerFolder
    m_CmdBackup.OverWrite = OverWrite
    m_CmdBackup.LogUseDefaultPath = LogDefaultPath
    m_CmdBackup.DataBaseUseDefaultPath = DataBaseDefaultPath

  End Sub

  ' construccion - destruccion
  Private Sub fTaskCommandBackup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    Try

      opDataBase.Checked = True
      chkInitLog.CheckState = System.Windows.Forms.CheckState.Checked
      chkOverWrite.CheckState = System.Windows.Forms.CheckState.Checked

      LoadDataBases()
      ShowData()

      FormCenter(Me)

    Catch ex As Exception

      MngError(ex, "Form_Load", C_Module, "")

    End Try
  End Sub

  Private Sub fTaskCommandBackup_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim Cancel As Boolean = eventArgs.Cancel
    Dim Rslt As MsgBoxResult

    If m_Changed Then
      Rslt = MsgBox("Desea guardar los cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
      If Rslt = MsgBoxResult.Cancel Then
        Cancel = True
      ElseIf Rslt = MsgBoxResult.Yes Then
        If Not pSave Then
          Cancel = True
        End If
      End If
    End If

    eventArgs.Cancel = Cancel
  End Sub

  Private Sub fTaskCommandBackup_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try

      m_CmdBackup = Nothing

    Catch ex As Exception

      MngError(ex, "Form_Unload", C_Module, "")

    End Try
  End Sub
End Class