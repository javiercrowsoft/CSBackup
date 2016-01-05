Option Strict Off
Option Explicit On
Module mFile
	
	'--------------------------------------------------------------------------------
	' mFile
	' 29-01-06
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes
	' estructuras
	' funciones

	'--------------------------------------------------------------------------------
	
	' constantes
	Private Const C_Module As String = "mFile"
	
	Public Const gstrSEP_DIR As String = "\" ' Directory separator character
	Public Const gstrSEP_DIRALT As String = "/" ' Alternate directory separator character
	' estructuras
	' variables privadas
	' eventos
	' propiedades publicas
	' propiedades friend
	' propiedades privadas
	' funciones publicas
	Public Function GetFileName_(ByVal FullPath As String) As String
		GetFileName_ = GetFileNameWithoutExt_(FullPath) & "." & GetFileExt_(FullPath)
	End Function
	
	Public Function GetFileNameWithoutExt_(ByVal FullPath As String) As String
    Dim Path As String = ""
    Dim FileName As String = ""
		Dim nSepPos As Integer
		Dim sSEP As String
		
		SeparatePathAndFileName_(FullPath, Path, FileName)
		
		nSepPos = Len(FileName)
		
		If nSepPos = 0 Then
			GetFileNameWithoutExt_ = FullPath
			Exit Function
		End If
		
		sSEP = Mid(FileName, nSepPos, 1)
		Do Until sSEP = "."
			nSepPos = nSepPos - 1
			If nSepPos = 0 Then Exit Do
			sSEP = Mid(FileName, nSepPos, 1)
		Loop 
		
		Select Case nSepPos
			Case 0
				'Si el separador no es encontrado entonces es un archivo sin extencion
				GetFileNameWithoutExt_ = FileName
			Case Else
				GetFileNameWithoutExt_ = Left(FileName, nSepPos - 1)
		End Select
	End Function
	
	Public Function GetPath_(ByVal FullPath As String) As String
    Dim Path As String = ""
    Dim FileName As String = ""
		
		SeparatePathAndFileName_(FullPath, Path, FileName)
		
		GetPath_ = Path
	End Function
	
	Public Function GetFileExt_(ByVal FullPath As String) As String
    Dim Path As String = ""
    Dim FileName As String = ""
		Dim nSepPos As Integer
		Dim sSEP As String
		
		SeparatePathAndFileName_(FullPath, Path, FileName)
		
		nSepPos = Len(FileName)
		
		If nSepPos = 0 Then
			GetFileExt_ = ""
			Exit Function
		End If
		
		sSEP = Mid(FileName, nSepPos, 1)
		Do Until sSEP = "."
			nSepPos = nSepPos - 1
			If nSepPos = 0 Then Exit Do
			sSEP = Mid(FileName, nSepPos, 1)
		Loop 
		
		Select Case nSepPos
			Case 0
				'Si el separador no es encontrado entonces es un archivo sin extencion
				GetFileExt_ = ""
			Case Else
				' Devuelvo la extension
				GetFileExt_ = Mid(FileName, nSepPos + 1)
		End Select
	End Function
	
	Public Sub SeparatePathAndFileName_(ByRef FullPath As String, Optional ByRef Path As String = "", Optional ByRef FileName As String = "")
		Dim nSepPos As Integer
		Dim sSEP As String
		
		nSepPos = Len(FullPath)
		
		If nSepPos = 0 Then
			Path = FullPath
			FileName = FullPath
			Exit Sub
		End If
		sSEP = Mid(FullPath, nSepPos, 1)
		Do Until IsSeparator(sSEP)
			nSepPos = nSepPos - 1
			If nSepPos = 0 Then Exit Do
			sSEP = Mid(FullPath, nSepPos, 1)
		Loop 
		
		Select Case nSepPos
			Case Len(FullPath)
				'Si el separador es encontrado al final entonces, se trata de un directorio raiz ej. c:\, d:\, etc.
				Path = Left(FullPath, nSepPos - 1)
				FileName = FullPath
			Case 0
				'Si el separador no es encontrado entonces, se trata de un directorio raiz ej. c:, d:, etc.
				Path = FullPath
				FileName = FullPath
			Case Else
				Path = Left(FullPath, nSepPos - 1)
				FileName = Mid(FullPath, nSepPos + 1)
		End Select
	End Sub
	
	Public Function CopyFile_(ByVal Fuente As String, ByVal Destino As String) As Boolean
    Try

      FileCopy(Fuente, Destino)
      CopyFile_ = True

    Catch ex As Exception

      MngError(ex, "CopyFile_", C_Module, "")

    End Try
  End Function

  Public Function Delete_(ByVal File As String) As Boolean
    Try

      If Dir(File) <> "" Then


        SetAttr(File, FileAttribute.Normal)
        Kill(File)

      End If

      Delete_ = True

    Catch ex As Exception

      MngError(ex, "Delete_", C_Module, "")

    End Try
  End Function
	
	Public Function FileGetValidPath(ByVal Path As String) As Object
		If Right(Path, 1) = "\" Then
      FileGetValidPath = Path
		Else
      FileGetValidPath = Path & "\"
		End If
	End Function
	
  Public Sub FileCreateFolder(ByVal Folder As String)
    If Not FileFolderExists_(Folder) Then
      MkDir(Folder)
    End If
  End Sub
	
	Public Function FileFolderExists_(ByVal File As String) As Boolean
    Try

      FileFolderExists_ = Dir(File, FileAttribute.Directory) <> ""

    Catch ex As Exception

      FileFolderExists_ = False

    End Try
  End Function
	
	Public Function FileExists_(ByVal File As String) As Boolean
    Try

      FileExists_ = Dir(File) <> ""

    Catch ex As Exception

      FileExists_ = False

    End Try
  End Function
	
  Public Function GetWindowsDir_() As String
    GetWindowsDir_ = System.Environment.GetFolderPath(Environment.SpecialFolder.System)
  End Function
	' funciones friend
	' funciones privadas
	
	' Determines if a character is a path separator (\ or /).
	Private Function IsSeparator(ByRef Character As String) As Boolean
		Select Case Character
			Case gstrSEP_DIR
				IsSeparator = True
			Case gstrSEP_DIRALT
				IsSeparator = True
		End Select
	End Function
End Module