Option Strict Off
Option Explicit On
Friend Class cTask
	
	'--------------------------------------------------------------------------------
	' cTask
	' 29-01-2006
	'--------------------------------------------------------------------------------
	
	Private m_Name As String
	Private m_File As String
	Private m_Descrip As String
	Private m_Code As String
	Private m_ZipFiles As Integer
	
	Private m_FtpAddress As String
	Private m_FtpUser As String
	Private m_FtpPwd As String
	Private m_FtpPort As Integer
	
	Private m_Folders As Collection
	
	
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
	
	
	Public Property ZipFiles() As String
		Get
			ZipFiles = CStr(m_ZipFiles)
		End Get
		Set(ByVal Value As String)
			m_ZipFiles = CInt(Value)
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
	
	Public ReadOnly Property Folders() As Collection
		Get
			Folders = m_Folders
		End Get
	End Property
	
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
		
		pLoadFolders(DocXml, DocXml.GetNodeFromNode(Root, "Folders"))
		
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
		pAddTag(DocXml, Root, "TaskType", CStr(mPublic.csETaskTypeBackup.c_TaskTypeBackupFile))
		
		Dim Password As String
		Password = GetProgramPassword()
		
		pAddTag(DocXml, Root, "FtpAddress", m_FtpAddress)
		pAddTag(DocXml, Root, "FtpUser", m_FtpUser)
		pAddTag(DocXml, Root, "FtpPwd", EncryptData(m_FtpPwd, Password))
		pAddTag(DocXml, Root, "FtpPort", CStr(m_FtpPort))
		
		pSaveFolders(pAddTag(DocXml, Root, "Folders", ""), DocXml)
		
		Save = DocXml.Save(False)
	End Function
	
	Private Sub pAddProp(ByRef xml As cXml, ByRef Node As Object, ByVal TagName As String, ByVal Value As Object)
		
		
		Dim Prop As cXmlProperty
		
		Prop = New cXmlProperty
		Prop.Name = TagName
    Prop.Value(mPublic.csTypes.csBoolean) = Value
    xml.AddPropertyToNode(Node, Prop)
	End Sub
	
	Private Sub pSaveFolders(ByVal NodeFolders As Object, ByRef DocXml As cXml)
		Dim TaskItem As cTaskItem
		Dim Node As Object
		
		For	Each TaskItem In m_Folders
			
			Node = pAddTag(DocXml, NodeFolders, "Folder", TaskItem.Name)
      pAddProp(DocXml, Node, "Checked", TaskItem.Checked)
      pAddProp(DocXml, Node, "ItemType", TaskItem.ItemType)
			
			If TaskItem.Children.Count() Then
				pSaveFoldersAux(TaskItem.Children, pAddTag(DocXml, Node, "Folders", ""), pAddTag(DocXml, Node, "Files", ""), DocXml)
			End If
		Next TaskItem
	End Sub
	
	Private Sub pSaveFoldersAux(ByVal TaskItems As Collection, ByRef NodeFolders As Object, ByRef NodeFiles As Object, ByRef DocXml As cXml)
		Dim TaskItem As cTaskItem
		Dim Node As Object
		
		For	Each TaskItem In TaskItems
			
			If TaskItem.ItemType = cTaskItem.csEItemTypes.csEIT_File Then
				Node = pAddTag(DocXml, NodeFiles, "File", TaskItem.Name)
			Else
				Node = pAddTag(DocXml, NodeFolders, "Folder", TaskItem.Name)
			End If
			
      pAddProp(DocXml, Node, "Checked", TaskItem.Checked)

			If TaskItem.Children.Count() Then
				pSaveFoldersAux(TaskItem.Children, pAddTag(DocXml, Node, "Folders", ""), pAddTag(DocXml, Node, "Files", ""), DocXml)
			End If
		Next TaskItem
	End Sub
	
	Private Sub pLoadFolders(ByRef DocXml As cXml, ByRef NodeFolders As Object)
		Dim Node As Object
		Dim TaskItem As cTaskItem
		
		If NodeFolders Is Nothing Then Exit Sub
		
    Node = DocXml.GetNodeChild(NodeFolders)
		
		While Not Node Is Nothing
			
			TaskItem = New cTaskItem
			m_Folders.Add(TaskItem)
			TaskItem.ItemType = cTaskItem.csEItemTypes.csEIT_Folder
      TaskItem.Name = DocXml.GetNodeProperty(Node, "Value").Value(mPublic.csTypes.csText)
      TaskItem.Checked = DocXml.GetNodeProperty(Node, "Checked").Value(mPublic.csTypes.csBoolean)
      TaskItem.FullPath = TaskItem.Name

      If TaskItem.Name.Substring(0, 2) = "\\" Then
        TaskItem.ItemType = DocXml.GetNodeProperty(Node, "ItemType").Value(mPublic.csTypes.csInteger)
      End If
			
      If DocXml.NodeHasChild(Node) Then
        pLoadFoldersAux((TaskItem.Children), DocXml, DocXml.GetNodeFromNode2(Node, "Folders"), DocXml.GetNodeFromNode2(Node, "Files"), TaskItem.Name)
      End If
			
      Node = DocXml.GetNextNode(Node)
		End While
	End Sub
	
	Private Sub pLoadFoldersAux(ByRef TaskItems As Collection, ByRef DocXml As cXml, ByRef NodeFolders As Object, ByRef NodeFiles As Object, ByVal FullPath As String)
		Dim Node As Object
		Dim TaskItem As cTaskItem
		

    If FullPath <> "" Then FullPath = FullPath & "\"
		
		If Not NodeFolders Is Nothing Then
			
      Node = DocXml.GetNodeChild(NodeFolders)
			
			While Not Node Is Nothing
				TaskItem = New cTaskItem
				TaskItems.Add(TaskItem)
				TaskItem.ItemType = cTaskItem.csEItemTypes.csEIT_Folder
        TaskItem.Name = DocXml.GetNodeProperty(Node, "Value").Value(mPublic.csTypes.csText)
        TaskItem.Checked = DocXml.GetNodeProperty(Node, "Checked").Value(mPublic.csTypes.csBoolean)
				TaskItem.FullPath = FullPath & TaskItem.Name
				
        If DocXml.NodeHasChild(Node) Then
          pLoadFoldersAux((TaskItem.Children), DocXml, DocXml.GetNodeFromNode2(Node, "Folders"), DocXml.GetNodeFromNode2(Node, "Files"), TaskItem.FullPath)
        End If
				
        Node = DocXml.GetNextNode(Node)
			End While
			
		End If
		
		If Not NodeFiles Is Nothing Then
			
      Node = DocXml.GetNodeChild(NodeFiles)
			
			While Not Node Is Nothing
				TaskItem = New cTaskItem
				TaskItems.Add(TaskItem)
				TaskItem.ItemType = cTaskItem.csEItemTypes.csEIT_File
        TaskItem.Name = DocXml.GetNodeProperty(Node, "Value").Value(mPublic.csTypes.csText)
        TaskItem.Checked = DocXml.GetNodeProperty(Node, "Checked").Value(mPublic.csTypes.csBoolean)
				TaskItem.FullPath = FullPath & TaskItem.Name
        Node = DocXml.GetNextNode(Node)
			End While
		End If
	End Sub
	
  Private Sub ClassInitialize()
    m_Folders = New Collection
  End Sub
  Public Sub New()
    MyBase.New()
    ClassInitialize()
  End Sub
  Private Sub ClassTerminate()
    m_Folders = Nothing
  End Sub
  Protected Overrides Sub Finalize()
    ClassTerminate()
    MyBase.Finalize()
  End Sub
End Class