Option Strict Off
Option Explicit On
Friend Class cScheduleEnums
	
	'--------------------------------------------------------------------------------
	' cScheduleEnums
	' 15-05-2002
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes
	' estructuras
	' funciones
	
	'--------------------------------------------------------------------------------
	
	' constantes
	Private Const C_Module As String = "cScheduleEnums"
	
	Public Enum csVwType
		csVwSystem = 1
		csVwUser = 2
	End Enum
	
	Public Enum csTblType
		csTblSystem = 1
		csTblUser = 2
	End Enum
	
	Public Enum csSpType
		csSpSystem = 1
		csSpUser = 2
	End Enum
	
	Public Enum csScrType
		csScrTypeScript = 1
		csScrTaskType = 2
	End Enum
	
	Public Enum csToolsError
		csConnectionClosed = vbObjectError + 1
		csDataBaseNotExists = vbObjectError + 2
		csSepDecimalConfig = vbObjectError + 3
	End Enum
	
	Public Enum csSchCommandScriptType
		csSchCmdScrpTypeSqlCommand = 1
		csSchCmdScrpTypeOSCommand = 2
	End Enum
	
	Public Enum csBackupAction
		csBakActionBackup = 1
		csBakActionRestore = 2
	End Enum
	
	Public Enum csScheduleTimeType
		csSchTimeTypeRecurring = 1
		csSchTimeTypeAtThisTime = 2
		csSchTimeTypeUnSupported = 3
	End Enum
	
	Public Enum csScheduleEachType
		csSchEachTypeHour = 1
		csSchEachTypeMinute = 2
	End Enum
	
	Public Enum csScheduleRunType
		csSchRunTypeDaily = 1
		csSchRunTypeWeekly = 2
		csSchRunTypeMonthly = 3
		csSchRunTypeMonthlyRelative = 4
		csSchRunTypeOnce = 5
		csSchTypeUnSupported = 6
	End Enum
	
	Public Enum csScheduleRunMonthlyCardinal
		csSchRunMonCard_1st = 1
		csSchRunMonCard_2nd = 2
		csSchRunMonCard_3rd = 3
		csSchRunMonCard_4th = 4
		csSchRunMonCard_Last = 5
		csSchRunMonCard_UnSupported = 6
	End Enum
	
	Public Enum csScheduleRunMonthlyName
		csSchRunMonName_Monday = 1
		csSchRunMonName_Sunday = 2
		csSchRunMonName_Tuesday = 3
		csSchRunMonName_Wednesday = 4
		csSchRunMonName_Thursday = 5
		csSchRunMonName_FriDay = 6
		csSchRunMonName_Saturday = 7
	End Enum
	
	Public Enum csScheduleTaskType
		csSchTypeBackup = 1
		csSchTypeScript = 2
	End Enum
	' estructuras
	' variables privadas
	' eventos
	' propiedadades publicas
	Public ReadOnly Property csSchEndUndefined() As Date
		Get
			csSchEndUndefined = mAux.csSchEndUndefined
		End Get
	End Property
	' propiedadades friend
	' propiedades privadas
	' funciones publicas
	' funciones friend
	' funciones privadas
	' construccion - destruccion
End Class