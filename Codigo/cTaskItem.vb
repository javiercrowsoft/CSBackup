Option Strict Off
Option Explicit On
Friend Class cTaskItem
	
	Public Enum csEItemTypes
    csEIT_Folder = 1
    csEIT_File = 2
	End Enum
	
	Private m_Name As String
	Private m_Children As Collection
	Private m_Type As csEItemTypes
	Private m_Checked As Boolean
	Private m_FullPath As String
	
	
	Public Property Name() As String
		Get
			Name = m_Name
		End Get
		Set(ByVal Value As String)
			m_Name = Value
		End Set
	End Property
	
	
	Public Property FullPath() As String
		Get
			FullPath = m_FullPath
		End Get
		Set(ByVal Value As String)
			m_FullPath = Value
		End Set
	End Property
	
	Public ReadOnly Property Children() As Collection
		Get
			Children = m_Children
		End Get
	End Property
	
	
	Public Property ItemType() As csEItemTypes
		Get
			ItemType = m_Type
		End Get
		Set(ByVal Value As csEItemTypes)
			m_Type = Value
		End Set
	End Property
	
	Public Property Checked() As Boolean
		Get
			Checked = m_Checked
		End Get
		Set(ByVal Value As Boolean)
			m_Checked = Value
		End Set
	End Property
	
  Private Sub ClassInitialize()
    m_Children = New Collection
  End Sub
  Public Sub New()
    MyBase.New()
    ClassInitialize()
  End Sub
	
  Private Sub ClassTerminate()
    m_Children = Nothing
  End Sub
  Protected Overrides Sub Finalize()
    ClassTerminate()
    MyBase.Finalize()
  End Sub
End Class