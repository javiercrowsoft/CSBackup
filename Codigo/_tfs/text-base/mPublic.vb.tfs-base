Option Strict Off
Option Explicit On

Imports System.Diagnostics
Imports VB = Microsoft.VisualBasic
Imports System.IO

Module mPublic

  Public Const LOG_NAME As String = "CSBackup.log"
  Public Const FTP_COMMAND As String = "ftp_command.txt"

  Public Const csIniFile As String = "CSBackup.ini"
  Public Const csDbPath As String = "db_path"
  Public Const csFtpType As String = "ftp_type"
  Public Const csFtpExePath As String = "ftp_exe_path"
  Public Const csSecConfig As String = "Config"
  Public Const csSecWindows As String = "Windows"
  Public Const csSecSQLServer As String = "SQLServer"
  Public Const csPasswordFiles As String = "PasswordFiles"
  Public Const csPasswordTestValue As String = "PasswordTestValue"
  Public Const csUseMasterPassword As String = "UseMasterPassword"
  Public Const csInitWithWindows As String = "InitWithWindows"

  Public Const c_testvalue As String = "kamekamehaaa"

  Public Const c_K_LoginServers As String = "SERVERS"
  Public Const c_K_LoginLastServer As String = "LAST_SERVER"
  Public Const c_K_LoginUsers As String = "USERS"
  Public Const c_K_SecurityType As String = "TYPE_SECURITY"

  Public Const c_close_folder As Short = 0
  Public Const c_open_folder As Short = 1
  Public Const c_file As Short = 2
  Public Const c_close_folder_selected As Short = 3
  Public Const c_open_folder_selected As Short = 4

  Public Enum csETaskTypeBackup
    c_TaskTypeBackupFile = 1
    c_TaskTypeBackupDB = 2
  End Enum

  Private Const c_CRLF As String = "@;"
  Private Const c_CRLF2 As String = ";"

  Public Enum csErrorLevel
    csErrorWarning = 1
    csErrorFatal = 2
    csErrorInformation = 3
  End Enum

  Public Enum csErrorType
    csErrorAdo = 1
    csErrorVba = 2
  End Enum

  Public Enum csTypes
    csInteger = 2
    csDouble = 5
    csCurrency = 6
    csText = 200
    csId = -1
    csCuit = -100
    csBoolean = -200
    csSingle = -300
    csVariant = -400
    csLong = -500
    csDate = -600
    csDateOrNull = -700
  End Enum

  Private m_MasterPassword As String
  Private m_PasswordFiles As String

  Private m_NextKey As Integer

  Public Sub Main()

    m_NextKey = 0

    If AppIsRunning() Then

      MsgBox("Ya existe una instancia de CSBackup ejecutandose", MsgBoxStyle.Information)

      fMainMDI.Close()

    Else

      If pValidateInstall() Then

        If LoadMasterPassword() Then

          pSetInitWithWindows()

          pLoadIniValues()

          fMain.Show()
          LoadTask((fMain.lvTask))
          LoadSchedule((fMain.lvSchedule))

          fBackup.Show()
          fMain.BringToFront()

          If VB.Command() = "-r" Then
            fMainMDI.WindowState = System.Windows.Forms.FormWindowState.Minimized
            fMainMDI.Hide()
          End If

        Else

          fMainMDI.Close()

        End If

      Else

        fMainMDI.Close()

      End If
    End If
  End Sub

  Private Function AppIsRunning() As Boolean

    Dim aModuleName As String = Diagnostics.Process.GetCurrentProcess.MainModule.ModuleName

    Dim aProcName As String = System.IO.Path.GetFileNameWithoutExtension(aModuleName)

    If Process.GetProcessesByName(aProcName).Length > 1 Then
      Application.Exit()
    End If
  End Function

  Public Sub pSetInitWithWindows()
    Dim s As String
    Dim InitWithWindows As Boolean
    Dim Key As String

    mReg = New cRegistry

    Key = My.Application.Info.Title
    InitWithWindows = Val(GetIniValue(csSecConfig, csInitWithWindows, CStr(1), GetIniFullFile(csIniFile)))

    s = mReg.GetRegRun(Key, "")
    If s <> "" Then
      If Not InitWithWindows Then
        RemoveFromRegistry(Key)
      End If
    Else
      If InitWithWindows Then
        InsertInRegistry(Key, """" & My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe"" -r")
      End If
    End If
  End Sub

  Private Function pValidateInstall() As Boolean
    Dim dbPath As String

    dbPath = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))


    If dbPath = "" Then
      dbPath = FileGetValidPath(My.Application.Info.DirectoryPath) & "database"
      FileCreateFolder(dbPath)
      EditPreferences(True, dbPath)
    End If

    dbPath = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))

    Dim bValid As Boolean


    If dbPath <> "" Then
      bValid = FileFolderExists_(dbPath)
    End If

    If Not bValid Then
      MsgBox("Debe indicar una carpeta donde se guardaran las definiciones de tareas de CSBackup")
      Exit Function
    Else
      pValidateInstall = True
    End If

  End Function

  Private Sub pLoadIniValues()
    LoadPasswordFiles()
  End Sub

  Public Sub LoadPasswordFiles()

    Dim Password As String
    Password = GetProgramPassword()

    m_PasswordFiles = GetIniValue(csSecConfig, csPasswordFiles, "", GetIniFullFile(csIniFile))
    m_PasswordFiles = DecryptData(m_PasswordFiles, Password)

  End Sub

  Public Function LoadMasterPassword() As Boolean
    Dim bUseMasterPassword As Boolean

    bUseMasterPassword = Val(GetIniValue(csSecConfig, csUseMasterPassword, CStr(0), GetIniFullFile(csIniFile)))
    If bUseMasterPassword Then

      LoadMasterPassword = RequestMasterPassword(False)

    Else

      LoadMasterPassword = True

    End If

  End Function

  Public Sub EditPreferences(ByVal bModal As Boolean, Optional ByVal dbPath As String = "")

    If dbPath <> "" Then
      fPreferences.txPath.Text = dbPath
    End If

    If bModal Then
      fPreferences.ShowDialog()
    Else
      fPreferences.Show()
    End If
  End Sub

  Public Sub MngError(ByRef ErrObj As Object, ByVal FunctionName As String, ByVal ModuleName As String, ByVal InfoAdd As String, Optional ByVal Title As String = "@@@@@")
    Title = pGetTitle(Title)
    If TypeOf ErrObj Is SystemException Then
      MsgBox("Error: " & ErrObj.Message & vbCrLf & "Funcion: " & ModuleName & "." & FunctionName & vbCrLf & InfoAdd, MsgBoxStyle.Critical, Title)
    Else
      MsgBox("Error: " & ErrObj.Description & vbCrLf & "Funcion: " & ModuleName & "." & FunctionName & vbCrLf & InfoAdd, MsgBoxStyle.Critical, Title)
    End If
  End Sub

  Public Sub MsgWarning(ByVal msg As String, Optional ByVal Title As String = "@@@@@")
    pMsgAux(msg, MsgBoxStyle.Exclamation, Title)
  End Sub

  Private Sub pMsgAux(ByVal msg As String, ByVal Style As MsgBoxStyle, ByVal Title As String)
    msg = pGetMessage(msg)
    Title = pGetTitle(Title)
    MsgBox(msg, Style, Title)
  End Sub

  Private Function pGetMessage(ByVal msg As String) As String
    msg = Replace(msg, c_CRLF, vbCrLf)
    msg = Replace(msg, c_CRLF2, vbCrLf)

    pGetMessage = msg
  End Function

  Private Function pGetTitle(ByVal Title As String) As String
    If Title = "" Then Title = "CrowSoft"
    If Title = "@@@@@" Then Title = "CrowSoft"
    pGetTitle = Title
  End Function

  Public Function Ask(ByVal msg As String, ByVal DefaultValue As MsgBoxResult, Optional ByVal Title As String = "") As Boolean
    Dim N As Short
    msg = pGetMessage(msg)
    If InStr(1, msg, "?") = 0 Then msg = "¿" & msg & "?"
    If DefaultValue = MsgBoxResult.No Then N = MsgBoxStyle.DefaultButton2
    pGetTitle(Title)
    Ask = MsgBoxResult.Yes = MsgBox(msg, MsgBoxStyle.YesNo + N + MsgBoxStyle.Question, Title)

  End Function

  Public Function TaskType(ByVal TaskFile As String, ByVal bSilent As Boolean, Optional ByRef strError As String = "") As csETaskTypeBackup
    Dim DocXml As cXml
    DocXml = New cXml

    DocXml.Init(Nothing)
    DocXml.Name = GetFileName_(TaskFile)
    DocXml.Path = GetPath_(TaskFile)

    If Not DocXml.OpenXml(bSilent, strError) Then Exit Function


    Dim Root As Object

    Root = DocXml.GetRootNode()

    TaskType = Val(pGetChildNodeProperty(Root, DocXml, "TaskType", "Value"))

  End Function

  Public Function GetPasswordFiles() As String
    GetPasswordFiles = m_PasswordFiles
  End Function

  Public Function RequestMasterPassword(ByVal bWithConfirm As Boolean) As Boolean
    If Not bWithConfirm Then
      fMasterPassword.txPassword2.Visible = False
      fMasterPassword.lbConfirm.Visible = False
    End If
    fMasterPassword.ShowDialog()

    If fMasterPassword.Ok Then

      m_MasterPassword = fMasterPassword.txPassword.Text
      RequestMasterPassword = True
    End If
    fMasterPassword.Close()
  End Function

  Public Function ValidateMasterPassword(ByVal Password As String) As Boolean
    Dim testValue As String
    testValue = GetIniValue(csSecConfig, csPasswordTestValue, "", GetIniFullFile(csIniFile))
    ValidateMasterPassword = DecryptData(testValue, Password) = c_testvalue
  End Function

  Public Function GetMasterPassword() As String
    GetMasterPassword = m_MasterPassword
  End Function

  Public Sub ChangeMasterPassword(ByVal OldMasterPassword As String, ByVal NewMasterPassword As String)

    ' Tengo que levantar todas las tareas
    ' y grabar con la nueva password
    '
    Dim i As Integer
    Dim Task As Object

    With fMain.lvTask.Items
      For i = 0 To .Count - 1
        If TaskType(.Item(i).SubItems(1).Text, False) = csETaskTypeBackup.c_TaskTypeBackupFile Then
          Task = New cTask
        Else
          Task = New cSQLTaskCommandBackup
        End If

        m_MasterPassword = OldMasterPassword

        If Task.Load(.Item(i).SubItems(1).Text, False) Then

          m_MasterPassword = NewMasterPassword
          Task.Save()
        End If

      Next
    End With

    m_MasterPassword = NewMasterPassword
  End Sub

  Public Function GetDriveSerialNumber(Optional ByVal DriveLetter As String = "") As Integer

    Dim drive As DriveInfo
    Dim DriveSerial As Integer

    'Assign the current drive letter if not specified
    If DriveLetter <> "" Then
      drive = New DriveInfo(DriveLetter)
    Else
      drive = New DriveInfo(Path.GetPathRoot(My.Application.Info.DirectoryPath))
    End If

    With drive
      If .IsReady Then
        DriveSerial = 804552315 ' TODO: pa' cuando exista de forma nativa una forma de obtener info del HD System.Math.Abs(.SerialNumber)
      Else '"Drive Not Ready!"
        DriveSerial = -1
      End If
    End With

    GetDriveSerialNumber = DriveSerial

  End Function

  Public Function GetProgramPassword() As String
    Dim Pwd As String

    Pwd = CStr(GetDriveSerialNumber("c"))

    If m_MasterPassword <> "" Then
      Pwd = EncryptData(Pwd, m_MasterPassword)
    End If

    GetProgramPassword = Pwd
  End Function

  Public Function NotUnloadFromAppOrWindows(ByVal UnloadMode As System.Windows.Forms.CloseReason) As Boolean

    NotUnloadFromAppOrWindows = UnloadMode <> CloseReason.FormOwnerClosing _
                            And UnloadMode <> System.Windows.Forms.CloseReason.MdiFormClosing _
                            And UnloadMode <> System.Windows.Forms.CloseReason.WindowsShutDown _
                            And UnloadMode <> System.Windows.Forms.CloseReason.TaskManagerClosing
  End Function

  Public Function GetKey(ByVal sValue As String) As String
    GetKey = "K" & sValue
  End Function

  Public Function NextKey() As Integer
    m_NextKey = m_NextKey + 1
    NextKey = m_NextKey
  End Function
End Module