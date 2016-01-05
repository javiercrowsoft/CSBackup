Option Strict Off
Option Explicit On
Friend Class cSQLServerTask
	
	'--------------------------------------------------------------------------------
	' cSQLServerTask
	' 07-10-2007
	'--------------------------------------------------------------------------------
	
	Private m_Name As String
	Private m_File As String
	Private m_Descrip As String
	Private m_Code As String
	
	
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
    m_Descrip = pGetChildNodeProperty(Root, DocXml, "Descrip", "Value")
		
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
		pAddTag(DocXml, Root, "Descrip", m_Descrip)
		
		Save = DocXml.Save(False)
	End Function
End Class