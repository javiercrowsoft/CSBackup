Option Strict Off
Option Explicit On
Friend Class cSQLTaskCommandBackup
	'--------------------------------------------------------------------------------
	' cSQLTaskCommandBackup
	' 17-05-2002
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes
	' estructuras
	' funciones
	
	'--------------------------------------------------------------------------------
	
	' interfaces
	
	' constantes
	Private Const C_Module As String = "cSQLTaskCommandBackup"
	
	' estructuras
	' variables privadas
	Private m_Name As String
	Private m_File As String
	Private m_Descrip As String
	Private m_Code As String
	Private m_ZipFiles As Integer
	
	Private m_FtpAddress As String
	Private m_FtpUser As String
	Private m_FtpPwd As String
	Private m_FtpPort As Integer
	
	Private m_DataBase As String
	Private m_IsFull As Boolean ' Hace un backup de data
	Private m_IsLog As Boolean ' Hace un backup del log
	Private m_InitLog As Boolean ' Inicializa el Log
	Private m_FileDataBase As String
	Private m_FileLog As String
	Private m_ServerFolder As String
	Private m_OverWrite As Boolean
	Private m_LogUseDefaultPath As Boolean
	Private m_DataBaseUseDefaultPath As Boolean
	Private m_Server As String
	Private m_User As String
	Private m_Pwd As String
	Private m_SecurityType As mAux.csSQLSecurityType
	
	Private m_Connection As cConnection
	
	' eventos
	' propiedadades publicas
	
	Public Property OverWrite() As Boolean
		Get
			OverWrite = m_OverWrite
		End Get
		Set(ByVal Value As Boolean)
			m_OverWrite = Value
		End Set
	End Property
	
	
	Public Property Server() As String
		Get
			Server = m_Server
		End Get
		Set(ByVal Value As String)
			m_Server = Value
		End Set
	End Property
	
	
	Public Property User() As String
		Get
			User = m_User
		End Get
		Set(ByVal Value As String)
			m_User = Value
		End Set
	End Property
	
	
	Public Property Pwd() As String
		Get
			Pwd = m_Pwd
		End Get
		Set(ByVal Value As String)
			m_Pwd = Value
		End Set
	End Property
	
	
	Public Property SecurityType() As mAux.csSQLSecurityType
		Get
			SecurityType = m_SecurityType
		End Get
		Set(ByVal Value As mAux.csSQLSecurityType)
			m_SecurityType = Value
		End Set
	End Property
	
	
	Public Property DataBase() As String
		Get
			DataBase = m_DataBase
		End Get
		Set(ByVal Value As String)
			m_DataBase = Value
		End Set
	End Property
	
	
	Public Property IsFull() As Boolean
		Get
			IsFull = m_IsFull
		End Get
		Set(ByVal Value As Boolean)
			m_IsFull = Value
		End Set
	End Property
	
	
	Public Property IsLog() As Boolean
		Get
			IsLog = m_IsLog
		End Get
		Set(ByVal Value As Boolean)
			m_IsLog = Value
		End Set
	End Property
	
	
	Public Property InitLog() As Boolean
		Get
			InitLog = m_InitLog
		End Get
		Set(ByVal Value As Boolean)
			m_InitLog = Value
		End Set
	End Property
	
	
	Public Property FileDataBase() As String
		Get
			FileDataBase = m_FileDataBase
		End Get
		Set(ByVal Value As String)
			m_FileDataBase = Value
		End Set
	End Property
	
	
	Public Property FileLog() As String
		Get
			FileLog = m_FileLog
		End Get
		Set(ByVal Value As String)
			m_FileLog = Value
		End Set
	End Property
	
	
	Public Property ServerFolder() As String
		Get
			ServerFolder = m_ServerFolder
		End Get
		Set(ByVal Value As String)
			m_ServerFolder = Value
		End Set
	End Property
	
	
	Public Property ZipFiles() As String
		Get
			ZipFiles = CStr(m_ZipFiles)
		End Get
		Set(ByVal Value As String)
			m_ZipFiles = CInt(Value)
		End Set
	End Property
	
	
	Public Property LogUseDefaultPath() As Boolean
		Get
			LogUseDefaultPath = m_LogUseDefaultPath
		End Get
		Set(ByVal Value As Boolean)
			m_LogUseDefaultPath = Value
		End Set
	End Property
	
	
	Public Property DataBaseUseDefaultPath() As Boolean
		Get
			DataBaseUseDefaultPath = m_DataBaseUseDefaultPath
		End Get
		Set(ByVal Value As Boolean)
			m_DataBaseUseDefaultPath = Value
		End Set
	End Property

  Public ReadOnly Property BackupFileName() As String
    Get
      If m_DataBaseUseDefaultPath Then
        BackupFileName = FileGetValidPath(m_Connection.GetSQLRootPath(m_DataBase)) & "Backup\" & m_FileDataBase & "'"
      Else
        BackupFileName = m_FileDataBase
      End If
    End Get
  End Property

  Public ReadOnly Property BackupLogFileName() As String
    Get
      If m_LogUseDefaultPath Then
        BackupLogFileName = FileGetValidPath(m_Connection.GetSQLRootPath(m_DataBase)) & "Backup\" & m_FileLog & "'"
      Else
        BackupLogFileName = m_FileLog
      End If
    End Get
  End Property

  Public ReadOnly Property SqlstmtBackup() As String
    Get

      Dim rtn As String = ""

      If m_IsFull Then

        rtn = "BACKUP DATABASE " & m_DataBase & " TO DISK='"
        If m_DataBaseUseDefaultPath Then
          rtn = rtn & FileGetValidPath(m_Connection.GetSQLRootPath(m_DataBase)) & "Backup\" & m_FileDataBase & "'"
        Else
          rtn = rtn & m_FileDataBase & "'"
        End If
        rtn = rtn & " WITH NOUNLOAD ,  NOSKIP"
        If m_OverWrite Then
          rtn = rtn & ",  INIT"
        End If
      End If

      If m_IsLog Then
        rtn = rtn & "BACKUP LOG " & m_DataBase & " TO DISK '"
        If m_LogUseDefaultPath Then
          rtn = rtn & FileGetValidPath(m_Connection.GetSQLRootPath(m_DataBase)) & "Backup\" & m_FileLog & "'"
        Else
          rtn = rtn & m_FileLog & "'"
        End If
        rtn = rtn & "WITH NOINIT , NOUNLOAD"
        If m_InitLog Then
          rtn = rtn & "NOSKIP"
        End If
      End If

      SqlstmtBackup = rtn
    End Get
  End Property

  Public ReadOnly Property Conn() As cConnection
    Get
      Conn = m_Connection
    End Get
  End Property


  Public Property Name() As String
    Get
      Name = m_Name
    End Get
    Set(ByVal Value As String)
      m_Name = Value
    End Set
  End Property


  Public Property File() As String
    Get
      File = m_File
    End Get
    Set(ByVal Value As String)
      m_File = Value
    End Set
  End Property


  Public Property Descrip() As String
    Get
      Descrip = m_Descrip
    End Get
    Set(ByVal Value As String)
      m_Descrip = Value
    End Set
  End Property


  Public Property Code() As String
    Get
      Code = m_Code
    End Get
    Set(ByVal Value As String)
      m_Code = Value
    End Set
  End Property


  Public Property FtpAddress() As String
    Get
      FtpAddress = m_FtpAddress
    End Get
    Set(ByVal Value As String)
      m_FtpAddress = Value
    End Set
  End Property


  Public Property FtpUser() As String
    Get
      FtpUser = m_FtpUser
    End Get
    Set(ByVal Value As String)
      m_FtpUser = Value
    End Set
  End Property


  Public Property FtpPwd() As String
    Get
      FtpPwd = m_FtpPwd
    End Get
    Set(ByVal Value As String)
      m_FtpPwd = Value
    End Set
  End Property


  Public Property FtpPort() As Integer
    Get
      FtpPort = m_FtpPort
    End Get
    Set(ByVal Value As Integer)
      m_FtpPort = Value
    End Set
  End Property

  ' propiedadades friend
  ' propiedades privadas
  ' funciones publicas
  Public Function Connect(ByVal Server As String, ByVal User As String, ByVal Pwd As String, ByVal SecurityType As mAux.csSQLSecurityType, ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean

    m_Connection = Nothing
    m_Connection = New cConnection

    m_Connection.OpenConnectionEx(Server, User, Pwd, SecurityType = mAux.csSQLSecurityType.csTSNT, "master", bSilent, strError)

    Connect = True
  End Function

  Public Function Load(ByVal TaskFile As String, ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean
    Dim DocXml As cXml
    DocXml = New cXml

    DocXml.Init(Nothing)
    DocXml.Name = GetFileName_(TaskFile)
    DocXml.Path = GetPath_(TaskFile)

    If Not DocXml.OpenXml(bSilent, strError) Then Exit Function

    m_Name = ""
    m_Code = ""
    m_File = ""
    m_Descrip = ""

    Dim Root As Object

    Root = DocXml.GetRootNode()

    m_Name = pGetChildNodeProperty(Root, DocXml, "Name", "Value")
    m_Code = pGetChildNodeProperty(Root, DocXml, "Code", "Value")
    m_File = pGetChildNodeProperty(Root, DocXml, "File", "Value")
    m_ZipFiles = Val(pGetChildNodeProperty(Root, DocXml, "ZipFiles", "Value"))
    m_Descrip = pGetChildNodeProperty(Root, DocXml, "Descrip", "Value")

    m_FtpAddress = pGetChildNodeProperty(Root, DocXml, "FtpAddress", "Value")
    m_FtpUser = pGetChildNodeProperty(Root, DocXml, "FtpUser", "Value")
    m_FtpPwd = pGetChildNodeProperty(Root, DocXml, "FtpPwd", "Value")
    m_FtpPwd = DecryptData(m_FtpPwd, GetProgramPassword())
    m_FtpPort = Val(pGetChildNodeProperty(Root, DocXml, "FtpPort", "Value"))

    m_DataBase = pGetChildNodeProperty(Root, DocXml, "DataBase", "Value")
    m_IsFull = Val(pGetChildNodeProperty(Root, DocXml, "IsFull", "Value"))
    m_IsLog = Val(pGetChildNodeProperty(Root, DocXml, "IsLog", "Value"))
    m_InitLog = Val(pGetChildNodeProperty(Root, DocXml, "InitLog", "Value"))
    m_FileDataBase = pGetChildNodeProperty(Root, DocXml, "FileDataBase", "Value")
    m_FileLog = pGetChildNodeProperty(Root, DocXml, "FileLog", "Value")
    m_ServerFolder = pGetChildNodeProperty(Root, DocXml, "ServerFolder", "Value")
    m_OverWrite = Val(pGetChildNodeProperty(Root, DocXml, "OverWrite", "Value"))
    m_DataBaseUseDefaultPath = Val(pGetChildNodeProperty(Root, DocXml, "DataBaseUseDefaultPath", "Value"))
    m_LogUseDefaultPath = Val(pGetChildNodeProperty(Root, DocXml, "LogUseDefaultPath", "Value"))
    m_Server = pGetChildNodeProperty(Root, DocXml, "Server", "Value")
    m_User = pGetChildNodeProperty(Root, DocXml, "User", "Value")
    m_Pwd = pGetChildNodeProperty(Root, DocXml, "Pwd", "Value")
    m_Pwd = DecryptData(m_Pwd, GetProgramPassword())
    m_SecurityType = Val(pGetChildNodeProperty(Root, DocXml, "SecurityType", "Value"))

    Load = True
  End Function

  Public Function Save() As Boolean
    Dim DocXml As cXml
    Dim dbPath As String
    Dim Root As Object

    DocXml = New cXml

    dbPath = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))

    DocXml.Init(Nothing)
    DocXml.Name = m_Code & "_def.xml"
    DocXml.Path = dbPath

    If Not DocXml.NewXml() Then Exit Function

    Root = DocXml.GetRootNode()

    pAddTag(DocXml, Root, "Name", m_Name)
    pAddTag(DocXml, Root, "Code", m_Code)
    pAddTag(DocXml, Root, "File", m_File)
    pAddTag(DocXml, Root, "ZipFiles", CStr(m_ZipFiles))
    pAddTag(DocXml, Root, "Descrip", m_Descrip)
    pAddTag(DocXml, Root, "TaskType", CStr(mPublic.csETaskTypeBackup.c_TaskTypeBackupDB))

    Dim Password As String
    Password = GetProgramPassword()

    pAddTag(DocXml, Root, "FtpAddress", m_FtpAddress)
    pAddTag(DocXml, Root, "FtpUser", m_FtpUser)
    pAddTag(DocXml, Root, "FtpPwd", EncryptData(m_FtpPwd, Password))
    pAddTag(DocXml, Root, "FtpPort", CStr(m_FtpPort))

    pAddTag(DocXml, Root, "DataBase", m_DataBase)
    pAddTag(DocXml, Root, "IsFull", CStr(CShort(m_IsFull)))
    pAddTag(DocXml, Root, "IsLog", CStr(CShort(m_IsLog)))
    pAddTag(DocXml, Root, "InitLog", CStr(CShort(m_InitLog)))
    pAddTag(DocXml, Root, "FileDataBase", m_FileDataBase)
    pAddTag(DocXml, Root, "FileLog", m_FileLog)
    pAddTag(DocXml, Root, "ServerFolder", m_ServerFolder)
    pAddTag(DocXml, Root, "OverWrite", CStr(CShort(m_OverWrite)))
    pAddTag(DocXml, Root, "DataBaseUseDefaultPath", CStr(CShort(m_DataBaseUseDefaultPath)))
    pAddTag(DocXml, Root, "LogUseDefaultPath", CStr(CShort(m_LogUseDefaultPath)))
    pAddTag(DocXml, Root, "Server", m_Server)
    pAddTag(DocXml, Root, "User", m_User)
    pAddTag(DocXml, Root, "Pwd", EncryptData(m_Pwd, Password))
    pAddTag(DocXml, Root, "SecurityType", CStr(CShort(m_SecurityType)))

    pAddTag(DocXml, Root, "Command", SqlstmtBackup)

    Save = DocXml.Save(False)
  End Function
	
	Public Function ShowFindFileBackup(ByVal DataBase As String, ByVal File As String, ByVal Title As String) As String
		fExplorer.LoadDrives()
		fExplorer.tvDir.CheckBoxes = False
		fExplorer.ShowDialog()
		If fExplorer.Ok Then
			If Not fExplorer.tvDir.SelectedNode Is Nothing Then
        ShowFindFileBackup = FileGetValidPath(fExplorer.tvDir.SelectedNode.FullPath) & DataBase
      Else
        ShowFindFileBackup = ""
      End If
    Else
      ShowFindFileBackup = ""
    End If
		fExplorer.Close()
	End Function
	
	' funciones friend
	' funciones privadas
	' construccion - destruccion
  Private Sub ClassTerminate()
    Try

      m_Connection = Nothing

    Catch ex As Exception

      MngError(ex, "ClassTerminate", C_Module, "")

    End Try
  End Sub

  Protected Overrides Sub Finalize()
    ClassTerminate()
    MyBase.Finalize()
  End Sub
	
End Class