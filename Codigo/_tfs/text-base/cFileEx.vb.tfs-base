Option Strict Off
Option Explicit On
Friend Class cFileEx
	'--------------------------------------------------------------------------------
	' cFileEx
	' -01-2004
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes
	' estructuras
	' funciones
	
	'--------------------------------------------------------------------------------
	
	' constantes
	Private Const C_Module As String = "cFileEx"
	' estructuras
	' variables privadas
	' eventos
	' propiedades publicas
	' propiedades friend
	' propiedades privadas
	' funciones publicas
	Public Function FileGetName(ByVal FullPath As String) As String
		FileGetName = GetFileName_(FullPath)
	End Function
	
	Public Function FileExists(ByVal File As String) As Boolean
		FileExists = FileExists_(File)
	End Function
	
	Public Function GetWindowsDir() As String
    GetWindowsDir = GetWindowsDir_()
	End Function
	
	Public Function FileGetNameWithoutExt(ByVal FullPath As String) As String
		FileGetNameWithoutExt = GetFileNameWithoutExt_(FullPath)
	End Function
	
	Public Function FileGetPath(ByVal FullPath As String) As String
		FileGetPath = GetPath_(FullPath)
	End Function
	
	Public Function FileGetFileExt(ByVal FullPath As String) As String
		FileGetFileExt = GetFileExt_(FullPath)
	End Function
	
	Public Sub FileGetPathAndFileName(ByRef FullPath As String, Optional ByRef Path As String = "", Optional ByRef FileName As String = "")
		
		SeparatePathAndFileName_(FullPath, Path, FileName)
	End Sub
	
	Public Function FileCopyFile(ByVal Fuente As String, ByVal Destino As String) As Boolean
		FileCopyFile = CopyFile_(Fuente, Destino)
	End Function
	
	Public Function FileDelete(ByVal File As String) As Boolean
		FileDelete = Delete_(File)
	End Function
	' funciones friend
	' funciones privadas
	' construccion - destruccion
End Class