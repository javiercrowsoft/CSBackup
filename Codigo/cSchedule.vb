Option Strict Off
Option Explicit On
Friend Class cSchedule
	
	'--------------------------------------------------------------------------------
	' cSchedule
	' 22-05-2002
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes
	' estructuras
	' funciones
	
	'--------------------------------------------------------------------------------
	
	' constantes
	Private Const C_Module As String = "cSchedule"
	
	' estructuras
	' variables privadas
	Private m_RunType As cScheduleEnums.csScheduleRunType
	Private m_TimeType As cScheduleEnums.csScheduleTimeType
	
	Private m_FirtsRunStartAt As Date ' Para todas las tareas indican cuando empiezan y cuando terminan
	Private m_LastRunEndAt As Date ' Nota si m_LastRunEndAt = csSchEndUndefined  -> nunca termina
	
	Private m_LastRun As Date
	
	Private m_Time As Date ' Para tereas de tipo csScheduleTimeType.csSchTimeTypeAtThisTime
	' Indica la hora de ejecucion
	
	
	' Para tareas csScheduleTimeType.csSchTimeTypeRecurring
	Private m_TimeStart As Date
	Private m_TimeEnd As Date
	Private m_RunEach As Short
	Private m_RunEachType As cScheduleEnums.csScheduleEachType
	
	' Cada cuantos dia corre si es Daily
	Private m_RunDailyInterval As Short
	
	' Que dias corre si es Weekly
	Private m_RunWeeklyInterval As Short
	Private m_RunSunday As Boolean
	Private m_RunMonday As Boolean
	Private m_RunTuesday As Boolean
	Private m_RunWednesday As Boolean
	Private m_RunThursday As Boolean
	Private m_RunFriday As Boolean
	Private m_RunSaturday As Boolean
	
	' Si es Monthly
	Private m_RunMonthlyNumberDay As Short ' El 1ro, 2, 5,... etc
	Private m_RunMonthlyInterval As Short ' Cada 1, 2, 4,... meses
	' El primero, segundo, ... lunes, martes, ... del mes.
	Private m_RunMonthlyCardinalDay As cScheduleEnums.csScheduleRunMonthlyCardinal
	Private m_RunMonthlyNameDay As cScheduleEnums.csScheduleRunMonthlyName
	
	Private m_Name As String
	
	Private m_Tasks As Collection
	
	' eventos
	' propiedadades publicas
	
	Public Property RunType() As cScheduleEnums.csScheduleRunType
		Get
			RunType = m_RunType
		End Get
		Set(ByVal Value As cScheduleEnums.csScheduleRunType)
			m_RunType = Value
		End Set
	End Property
	Public Property TimeType() As cScheduleEnums.csScheduleTimeType
		Get
			TimeType = m_TimeType
		End Get
		Set(ByVal Value As cScheduleEnums.csScheduleTimeType)
			m_TimeType = Value
		End Set
	End Property
	Public Property FirtsRunStartAt() As Date
		Get
			FirtsRunStartAt = m_FirtsRunStartAt
		End Get
		Set(ByVal Value As Date)
			m_FirtsRunStartAt = Value
		End Set
	End Property
	Public Property LastRunEndAt() As Date
		Get
			LastRunEndAt = m_LastRunEndAt
		End Get
		Set(ByVal Value As Date)
			m_LastRunEndAt = Value
		End Set
	End Property
	Public Property LastRun() As Date
		Get
			LastRun = m_LastRun
		End Get
		Set(ByVal Value As Date)
			m_LastRun = Value
		End Set
	End Property
	
	Public Property Time() As Date
		Get
			Time = m_Time
		End Get
		Set(ByVal Value As Date)
			m_Time = Value
		End Set
	End Property
	Public Property TimeStart() As Date
		Get
			TimeStart = m_TimeStart
		End Get
		Set(ByVal Value As Date)
			m_TimeStart = Value
		End Set
	End Property
	Public Property TimeEnd() As Date
		Get
			TimeEnd = m_TimeEnd
		End Get
		Set(ByVal Value As Date)
			m_TimeEnd = Value
		End Set
	End Property
	Public Property RunEach() As Short
		Get
			RunEach = m_RunEach
		End Get
		Set(ByVal Value As Short)
			m_RunEach = Value
		End Set
	End Property
	
	Public Property RunEachType() As cScheduleEnums.csScheduleEachType
		Get
			RunEachType = m_RunEachType
		End Get
		Set(ByVal Value As cScheduleEnums.csScheduleEachType)
			m_RunEachType = Value
		End Set
	End Property
	Public Property RunDailyInterval() As Short
		Get
			RunDailyInterval = m_RunDailyInterval
		End Get
		Set(ByVal Value As Short)
			m_RunDailyInterval = Value
		End Set
	End Property
	Public Property RunWeeklyInterval() As Short
		Get
			RunWeeklyInterval = m_RunWeeklyInterval
		End Get
		Set(ByVal Value As Short)
			m_RunWeeklyInterval = Value
		End Set
	End Property
	Public Property RunMonday() As Boolean
		Get
			RunMonday = m_RunMonday
		End Get
		Set(ByVal Value As Boolean)
			m_RunMonday = Value
		End Set
	End Property
	Public Property RunSunday() As Boolean
		Get
			RunSunday = m_RunSunday
		End Get
		Set(ByVal Value As Boolean)
			m_RunSunday = Value
		End Set
	End Property
	Public Property RunTuesday() As Boolean
		Get
			RunTuesday = m_RunTuesday
		End Get
		Set(ByVal Value As Boolean)
			m_RunTuesday = Value
		End Set
	End Property
	Public Property RunWednesday() As Boolean
		Get
			RunWednesday = m_RunWednesday
		End Get
		Set(ByVal Value As Boolean)
			m_RunWednesday = Value
		End Set
	End Property
	Public Property RunThursday() As Boolean
		Get
			RunThursday = m_RunThursday
		End Get
		Set(ByVal Value As Boolean)
			m_RunThursday = Value
		End Set
	End Property
	Public Property RunFriday() As Boolean
		Get
			RunFriday = m_RunFriday
		End Get
		Set(ByVal Value As Boolean)
			m_RunFriday = Value
		End Set
	End Property
	Public Property RunSaturday() As Boolean
		Get
			RunSaturday = m_RunSaturday
		End Get
		Set(ByVal Value As Boolean)
			m_RunSaturday = Value
		End Set
	End Property
	Public Property RunMonthlyNumberDay() As Short
		Get
			RunMonthlyNumberDay = m_RunMonthlyNumberDay
		End Get
		Set(ByVal Value As Short)
			m_RunMonthlyNumberDay = Value
		End Set
	End Property
	Public Property RunMonthlyInterval() As Short
		Get
			RunMonthlyInterval = m_RunMonthlyInterval
		End Get
		Set(ByVal Value As Short)
			m_RunMonthlyInterval = Value
		End Set
	End Property
	Public Property RunMonthlyCardinalDay() As cScheduleEnums.csScheduleRunMonthlyCardinal
		Get
			RunMonthlyCardinalDay = m_RunMonthlyCardinalDay
		End Get
		Set(ByVal Value As cScheduleEnums.csScheduleRunMonthlyCardinal)
			m_RunMonthlyCardinalDay = Value
		End Set
	End Property
	Public Property RunMonthlyNameDay() As cScheduleEnums.csScheduleRunMonthlyName
		Get
			RunMonthlyNameDay = m_RunMonthlyNameDay
		End Get
		Set(ByVal Value As cScheduleEnums.csScheduleRunMonthlyName)
			m_RunMonthlyNameDay = Value
		End Set
	End Property
	
	
	Public Property Name() As String
		Get
			Name = m_Name
		End Get
		Set(ByVal Value As String)
			m_Name = Value
		End Set
	End Property
	
	
	Public Property Tasks() As Collection
		Get
			Tasks = m_Tasks
		End Get
		Set(ByVal Value As Collection)
			m_Tasks = Value
		End Set
	End Property
	
	' propiedadades friend
	' propiedades privadas
	' funciones publicas
	Public Function Load(ByVal ScheduleFile As String, ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean
		Dim DocXml As cXml
		DocXml = New cXml
		
		DocXml.Init(Nothing)
		DocXml.Name = GetFileName_(ScheduleFile)
		DocXml.Path = GetPath_(ScheduleFile)
		
		If Not DocXml.OpenXml(bSilent, strError) Then Exit Function
		
		m_Name = ""
		
		Dim Root As Object

		Root = DocXml.GetRootNode()
		
    m_Name = pGetChildNodeProperty(Root, DocXml, "Name", "Value")
		
    m_RunType = pGetChildNodeProperty(Root, DocXml, "RunType", "Value")
    m_TimeType = pGetChildNodeProperty(Root, DocXml, "TimeType", "Value")
    m_FirtsRunStartAt = pGetChildNodeProperty(Root, DocXml, "FirtsRunStartAt", "Value", mPublic.csTypes.csDate)
    m_LastRunEndAt = pGetChildNodeProperty(Root, DocXml, "LastRunEndAt", "Value", mPublic.csTypes.csDate)
    m_LastRun = pGetChildNodeProperty(Root, DocXml, "LastRun", "Value", mPublic.csTypes.csDate)
    m_Time = pGetChildNodeProperty(Root, DocXml, "Time", "Value", mPublic.csTypes.csDate)
    m_TimeStart = pGetChildNodeProperty(Root, DocXml, "TimeStart", "Value", mPublic.csTypes.csDate)
    m_TimeEnd = pGetChildNodeProperty(Root, DocXml, "TimeEnd", "Value", mPublic.csTypes.csDate)
    m_RunEach = pGetChildNodeProperty(Root, DocXml, "RunEach", "Value")
    m_RunEachType = pGetChildNodeProperty(Root, DocXml, "RunEachType", "Value")
    m_RunDailyInterval = pGetChildNodeProperty(Root, DocXml, "RunDailyInterval", "Value")
		m_RunWeeklyInterval = pGetChildNodeProperty(Root, DocXml, "RunWeeklyInterval", "Value")
    m_RunMonthlyInterval = pGetChildNodeProperty(Root, DocXml, "RunMonthlyInterval", "Value")
    m_RunMonthlyNumberDay = pGetChildNodeProperty(Root, DocXml, "RunMonthlyNumberDay", "Value")
		m_RunMonthlyCardinalDay = pGetChildNodeProperty(Root, DocXml, "RunMonthlyCardinalDay", "Value")
    m_RunMonthlyNameDay = pGetChildNodeProperty(Root, DocXml, "RunMonthlyNameDay", "Value")
    m_RunSunday = pGetChildNodeProperty(Root, DocXml, "RunSunday", "Value")
    m_RunMonday = pGetChildNodeProperty(Root, DocXml, "RunMonday", "Value")
    m_RunTuesday = pGetChildNodeProperty(Root, DocXml, "RunTuesday", "Value")
    m_RunWednesday = pGetChildNodeProperty(Root, DocXml, "RunWednesday", "Value")
    m_RunThursday = pGetChildNodeProperty(Root, DocXml, "RunThursday", "Value")
    m_RunFriday = pGetChildNodeProperty(Root, DocXml, "RunFriday", "Value")
    m_RunSaturday = pGetChildNodeProperty(Root, DocXml, "RunSaturday", "Value")
		
    pLoadTasks(DocXml, DocXml.GetNodeFromNode(Root, "Tasks"))
		
		Load = True
	End Function
	
	Public Function Save(ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean
		Dim DocXml As cXml
		Dim dbPath As String
		Dim Root As Object
		
		DocXml = New cXml
		
    dbPath = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))
		
		DocXml.Init(Nothing)
		DocXml.Name = m_Name & "_sch.xml"
		DocXml.Path = dbPath
		
		If Not DocXml.NewXml() Then Exit Function
		
		Root = DocXml.GetRootNode()
		
		pAddTag(DocXml, Root, "Name", m_Name)
		pAddTag(DocXml, Root, "RunType", CStr(m_RunType))
		pAddTag(DocXml, Root, "TimeType", CStr(m_TimeType))
		pAddTag(DocXml, Root, "FirtsRunStartAt", CStr(m_FirtsRunStartAt))
		pAddTag(DocXml, Root, "LastRunEndAt", CStr(m_LastRunEndAt))
		pAddTag(DocXml, Root, "LastRun", CStr(m_LastRun))
		pAddTag(DocXml, Root, "Time", CStr(m_Time))
		pAddTag(DocXml, Root, "TimeStart", CStr(m_TimeStart))
		pAddTag(DocXml, Root, "TimeEnd", CStr(m_TimeEnd))
		pAddTag(DocXml, Root, "RunEach", CStr(m_RunEach))
		pAddTag(DocXml, Root, "RunEachType", CStr(m_RunEachType))
		pAddTag(DocXml, Root, "RunDailyInterval", CStr(CShort(m_RunDailyInterval)))
		pAddTag(DocXml, Root, "RunWeeklyInterval", CStr(CShort(m_RunWeeklyInterval)))
		pAddTag(DocXml, Root, "RunSunday", CStr(CShort(m_RunSunday)))
		pAddTag(DocXml, Root, "RunMonday", CStr(CShort(m_RunMonday)))
		pAddTag(DocXml, Root, "RunTuesday", CStr(CShort(m_RunTuesday)))
		pAddTag(DocXml, Root, "RunWednesday", CStr(CShort(m_RunWednesday)))
		pAddTag(DocXml, Root, "RunThursday", CStr(CShort(m_RunThursday)))
		pAddTag(DocXml, Root, "RunFriday", CStr(CShort(m_RunFriday)))
		pAddTag(DocXml, Root, "RunSaturday", CStr(CShort(m_RunSaturday)))
		pAddTag(DocXml, Root, "RunMonthlyNumberDay", CStr(m_RunMonthlyNumberDay))
		pAddTag(DocXml, Root, "RunMonthlyInterval", CStr(m_RunMonthlyInterval))
		pAddTag(DocXml, Root, "RunMonthlyCardinalDay", CStr(m_RunMonthlyCardinalDay))
		pAddTag(DocXml, Root, "RunMonthlyNameDay", CStr(m_RunMonthlyNameDay))
		
		pSaveTask(pAddTag(DocXml, Root, "Tasks", ""), DocXml)
		
		Save = DocXml.Save(bSilent, strError)
	End Function
	' funciones friend
	' funciones privadas
	
	Private Sub pSaveTask(ByVal NodeTasks As Object, ByRef DocXml As cXml)
		Dim Task As cTask
		Dim Node As Object
		
		For	Each Task In m_Tasks
			
			Node = pAddTag(DocXml, NodeTasks, "Task", Task.Name)
			
		Next Task
	End Sub
	
	Private Sub pLoadTasks(ByRef DocXml As cXml, ByRef NodeTasks As Object)
		Dim Node As Object
		Dim Task As cTask
		
		If NodeTasks Is Nothing Then Exit Sub
		
    Node = DocXml.GetNodeChild(NodeTasks)
		
		While Not Node Is Nothing
			
			Task = New cTask
			m_Tasks.Add(Task)
      Task.Name = DocXml.GetNodeProperty(Node, "Value").Value(mPublic.csTypes.csText)
			
      Node = DocXml.GetNextNode(Node)
		End While
	End Sub
	
	' construccion - destruccion
  Private Sub ClassInitialize()
    m_FirtsRunStartAt = Now
    m_LastRunEndAt = csSchEndUndefined
    m_Tasks = New Collection
  End Sub
  Public Sub New()
    MyBase.New()
    ClassInitialize()
  End Sub
	
  Private Sub ClassTerminate()
    m_Tasks = Nothing
  End Sub
  Protected Overrides Sub Finalize()
    ClassTerminate()
    MyBase.Finalize()
  End Sub
End Class