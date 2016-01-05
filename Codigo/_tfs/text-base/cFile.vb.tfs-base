Option Strict Off
Option Explicit On
Friend Class cFile
	
	'--------------------------------------------------------------------------------
	' cFile
	' 29-01-06
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	'    ' constantes
	
	'--------------------------------------------------------------------------------
	
	' constantes
	
	Public Enum csFile
		csRead = 1
		csWrite
		csAppend
		csBinaryRead
		csBinaryWrite
	End Enum
	
	Public Enum csFileAcces
		csShared = 1
		csLockRead
		csLockWrite
		csLockReadWrite
	End Enum
	
	' estructuras
	' variables privadas
  Private m_iFile As Short
  Private m_Function As String
  Private m_Module As String
  Private m_Open As Boolean
  Private m_CurPath As String
  Private m_Name As String
  Private m_Path As String
  Private m_BinaryMode As Boolean

  Private m_CommDialog As Object

  Private m_Filter As String

  ' propiedades publicas
  Public ReadOnly Property IsEOF() As Boolean
    Get
      If Not m_Open Then
        IsEOF = True
        Exit Property
      End If

      If m_BinaryMode Then
        IsEOF = LOF(m_iFile) <= Loc(m_iFile)
      Else
        IsEOF = EOF(m_iFile)
      End If
    End Get
  End Property

  Public Property FileFilter() As String
    Get
      FileFilter = m_Filter
    End Get
    Set(ByVal Value As String)
      m_Filter = Value
    End Set
  End Property

  ' propiedades privadas
  ' Funciones publicas
  Public ReadOnly Property Name() As String
    Get
      Name = m_Name
    End Get
  End Property
  Public ReadOnly Property Path() As String
    Get
      Path = m_Path
    End Get
  End Property
  Public ReadOnly Property FullName() As String
    Get
      FullName = m_Path & "\" & m_Name
    End Get
  End Property

  Public ReadOnly Property File() As Short
    Get
      File = m_iFile
    End Get
  End Property

  Public Sub Init(ByVal FunctionName As String, ByVal ModuleName As String, ByRef CommDialog As Object)

    m_Function = FunctionName
    m_Module = ModuleName
    m_CommDialog = CommDialog
  End Sub

  Public Function FOpen(ByVal sFile As String, ByVal Mode As csFile, Optional ByRef bNew As Boolean = False, Optional ByRef bSilens As Boolean = True, Optional ByRef TypeAccess As csFileAcces = csFileAcces.csShared, Optional ByVal WithDialog As Boolean = False, Optional ByVal CanOpenOther As Boolean = False) As Boolean
    Dim Exists As Boolean

    FClose()

    m_BinaryMode = False

    If sFile <> "" Then
      ' Primero busco si existe en el path original
      Exists = Dir(sFile) <> ""
    Else
      sFile = " "
      Exists = False
    End If

    ' si no existe y no hay que crearlo
    If (Not Exists And Not bNew) Or WithDialog Then

      ' busco en el ultimo path en que tuve exito
      Exists = Dir(m_CurPath & "\" & GetFileName(sFile)) <> ""

      ' Si existe continuo con este file
      If Exists And Not WithDialog Then
        sFile = m_CurPath & "\" & GetFileName(sFile)
        ' y tengo que mantener silencio todo mal
      ElseIf (bSilens = True) Then
        Exit Function

        ' Le permito al usuario ubicar el archivo
      ElseIf Not UserUbicFile(sFile, False, "Abrir archivo", False, CanOpenOther) Then
        Exit Function
      End If
    End If

    Try

      If bNew Then
        Kill(sFile)
      End If

    Catch ex As Exception

      MngError(ex, m_Function, m_Module, "", "Error al borrar el archivo")
      Exit Function

    End Try

    m_iFile = FreeFile()

    Try

      Select Case Mode
        Case csFile.csAppend
          Select Case TypeAccess
            Case csFileAcces.csShared
              FileOpen(m_iFile, sFile, OpenMode.Append, OpenAccess.Write, OpenShare.Shared)
            Case csFileAcces.csLockRead
              FileOpen(m_iFile, sFile, OpenMode.Append, OpenAccess.Write, OpenShare.LockRead)
            Case csFileAcces.csLockReadWrite
              FileOpen(m_iFile, sFile, OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
            Case csFileAcces.csLockWrite
              FileOpen(m_iFile, sFile, OpenMode.Append, OpenAccess.Write, OpenShare.LockWrite)
          End Select
        Case csFile.csWrite
          Select Case TypeAccess
            Case csFileAcces.csShared
              FileOpen(m_iFile, sFile, OpenMode.Output, OpenAccess.Write, OpenShare.Shared)
            Case csFileAcces.csLockRead
              FileOpen(m_iFile, sFile, OpenMode.Output, OpenAccess.Write, OpenShare.LockRead)
            Case csFileAcces.csLockReadWrite
              FileOpen(m_iFile, sFile, OpenMode.Output, OpenAccess.Write, OpenShare.LockReadWrite)
            Case csFileAcces.csLockWrite
              FileOpen(m_iFile, sFile, OpenMode.Output, OpenAccess.Write, OpenShare.LockWrite)
          End Select
        Case csFile.csRead
          Select Case TypeAccess
            Case csFileAcces.csShared
              FileOpen(m_iFile, sFile, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
            Case csFileAcces.csLockRead
              FileOpen(m_iFile, sFile, OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)
            Case csFileAcces.csLockReadWrite
              FileOpen(m_iFile, sFile, OpenMode.Input, OpenAccess.Read, OpenShare.LockReadWrite)
            Case csFileAcces.csLockWrite
              FileOpen(m_iFile, sFile, OpenMode.Input, OpenAccess.Read, OpenShare.LockWrite)
          End Select
        Case csFile.csBinaryRead
          Select Case TypeAccess
            Case csFileAcces.csShared
              FileOpen(m_iFile, sFile, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared)
            Case csFileAcces.csLockRead
              FileOpen(m_iFile, sFile, OpenMode.Binary, OpenAccess.Read, OpenShare.LockRead)
            Case csFileAcces.csLockReadWrite
              FileOpen(m_iFile, sFile, OpenMode.Binary, OpenAccess.Read, OpenShare.LockReadWrite)
            Case csFileAcces.csLockWrite
              FileOpen(m_iFile, sFile, OpenMode.Binary, OpenAccess.Read, OpenShare.LockWrite)
          End Select
          m_BinaryMode = True
        Case csFile.csBinaryWrite
          Select Case TypeAccess
            Case csFileAcces.csShared
              FileOpen(m_iFile, sFile, OpenMode.Binary, OpenAccess.Write, OpenShare.Shared)
            Case csFileAcces.csLockRead
              FileOpen(m_iFile, sFile, OpenMode.Binary, OpenAccess.Write, OpenShare.LockRead)
            Case csFileAcces.csLockReadWrite
              FileOpen(m_iFile, sFile, OpenMode.Binary, OpenAccess.Write, OpenShare.LockReadWrite)
            Case csFileAcces.csLockWrite
              FileOpen(m_iFile, sFile, OpenMode.Binary, OpenAccess.Write, OpenShare.LockWrite)
          End Select
          m_BinaryMode = True
        Case Else
          Exit Function
      End Select
      m_Open = True
      FOpen = True
      Exit Function

    Catch ex As Exception

      MngError(ex, "FOpen", "clsFile - " & m_Module, "llamada por " & m_Function, "Error al abrir el archivo")

    End Try
  End Function

  Public Function FSave(ByVal sFile As String, ByRef Exists As Boolean, ByRef bReadOnly As Boolean, Optional ByVal Descrip As String = "Guardar") As Boolean
    Try

      ' Le permito al usuario ubicar el archivo
      If sFile = "" Then sFile = " "

      If Not UserUbicFile(sFile, True, Descrip, True) Then Exit Function

      If sFile <> "" Then
        ' Primero busco si existe en el path original
        Exists = Dir(sFile, FileAttribute.Normal) <> ""
        If Exists Then
          If GetAttr(sFile) And vbNormal Or GetAttr(sFile) And FileAttribute.ReadOnly Or GetAttr(sFile) And FileAttribute.Archive Then
            If GetAttr(sFile) And FileAttribute.ReadOnly Then
              bReadOnly = True
            End If
          Else
            Exists = False
          End If
        End If
      Else
        sFile = " "
        Exists = False
      End If

      FSave = True

    Catch ex As Exception

      MngError(ex, "FSave", "clsFile - " & m_Module, "llamada por " & m_Function, "Error al guardar el archivo")

    End Try
  End Function

  Public Function FWrite(ByVal sText As String) As Boolean
    Try

      If Not m_Open Then Exit Function

      PrintLine(m_iFile, sText)
      FWrite = True

    Catch ex As Exception

      MngError(ex, "FWrite", "clsFile - " & m_Module, "llamada por " & m_Function, "Error al escribir el archivo")

    End Try
  End Function

  Public Function FRead(ByRef sText As String, ByRef bEof As Boolean) As Boolean
    Try

      If Not m_Open Then Exit Function

      If EOF(m_iFile) Then
        bEof = True
      Else
        sText = LineInput(m_iFile)
        bEof = False
      End If
      FRead = True

    Catch ex As Exception

      MngError(ex, "FRead", "clsFile - " & m_Module, "llamada por " & m_Function, "Error al leer del archivo")

    End Try
  End Function

  Public Function FBinaryWrite(ByRef bBuffer() As Byte) As Boolean
    Try

      If Not m_Open Then Exit Function
      FilePut(m_iFile, bBuffer)
      FBinaryWrite = True

    Catch ex As Exception

      MngError(ex, "FBinaryWrite", "clsFile - " & m_Module, "llamada por " & m_Function, "Error al escribir el archivo")

    End Try
  End Function
  Public Function FBinaryRead(ByRef bBuffer() As Byte, ByRef bEof As Boolean) As Boolean
    Try

      If Not m_Open Then Exit Function

      If IsEOF Then
        bEof = True
      Else
        If LOF(m_iFile) - Loc(m_iFile) < UBound(bBuffer) Then ReDim bBuffer(LOF(m_iFile) - Loc(m_iFile))
        FileGet(m_iFile, bBuffer)
        bEof = False
      End If
      FBinaryRead = True

    Catch ex As Exception

      MngError(ex, "FBinaryRead", "clsFile - " & m_Module, "llamada por " & m_Function, "Error al leer del archivo")

    End Try
  End Function

  Public Sub FClose()
    Try

      FileClose(m_iFile)
      m_iFile = 0
      m_Open = False

    Catch ex As Exception

    End Try
  End Sub

  '////////////////////////////////////
  ' Manejo de nombres de archivos
  Public Function GetFileName(ByVal FullPath As String) As String
    GetFileName = GetFileName_(FullPath)
  End Function

  Public Function GetFileNameWithoutExt(ByVal FullPath As String) As String
    GetFileNameWithoutExt = GetFileNameWithoutExt_(FullPath)
  End Function

  Public Function GetPath(ByVal FullPath As String) As String
    GetPath = GetPath_(FullPath)
  End Function

  Public Function GetFileExt(ByVal FullPath As String) As String
    GetFileExt = GetFileExt_(FullPath)
  End Function

  Public Sub SeparatePathAndFileName(ByRef FullPath As String, Optional ByRef Path As String = "", Optional ByRef FileName As String = "")

    SeparatePathAndFileName_(FullPath, Path, FileName)
  End Sub

  Public Function CopyFile(ByVal Fuente As String, ByVal Destino As String) As Boolean
    CopyFile = CopyFile_(Fuente, Destino)
  End Function

  ' Funciones privadas
  Private Function UserUbicFile(ByRef sFile As String, Optional ByRef SiNoExisteDaIgual As Boolean = False, Optional ByVal Descrip As String = "Abrir archivo", Optional ByVal Guardando As Boolean = False, Optional ByVal CanOpenOther As Boolean = False) As Boolean
    Dim sFile2 As String = ""
    Dim bExtValid As Boolean
    Dim bNameValid As Boolean
    Dim Exists As Boolean

    Do
      If ShowOpenFileDLG(sFile2, GetFileExt(sFile), GetFileName(sFile), GetPath(sFile), Descrip, Guardando) Then

        Exists = Dir(sFile2) <> ""

        ' si no existe no sirve
        If Not Exists And Not SiNoExisteDaIgual Then
          GoTo continuar
        End If

        If GetFileNameWithoutExt(sFile) = "*" Or sFile = " " Then
          bNameValid = True
        Else
          ' Compruebo que el archivo que abrio el usuario sea el mismo que
          ' me pidio el programa que abra.
          If (GetFileNameWithoutExt(sFile) = GetFileNameWithoutExt(sFile2)) Or SiNoExisteDaIgual Or CanOpenOther Then
            bNameValid = True
          Else
            bNameValid = False

            GoTo continuar
          End If
        End If

        If GetFileExt(sFile) = "*" Or sFile = " " Then
          bExtValid = True
        Else
          If (GetFileExt(sFile) = GetFileExt(sFile2)) Or SiNoExisteDaIgual Then
            bExtValid = True
          Else
            bExtValid = False
          End If
        End If

        If bExtValid And bNameValid And (Exists Or SiNoExisteDaIgual) Then Exit Do
continuar:
      Else
        Exit Function
      End If
    Loop

    ' Guardo el path para la proxima vez que busque
    m_CurPath = GetPath(sFile2)

    sFile = sFile2
    m_Name = GetFileName(sFile)
    m_Path = GetPath(sFile)
    UserUbicFile = True
  End Function

  '//////////////////////////////
  ' show common dialog
  Private Function ShowOpenFileDLG(ByRef srtvalFile As String, Optional ByVal sFilter As Object = Nothing, Optional ByVal sFileToSearch As Object = Nothing, Optional ByVal sCurDir As Object = Nothing, Optional ByVal sTitle As String = "Abrir", Optional ByVal Guardando As Boolean = False) As Boolean
    Try

      With m_CommDialog

        .CancelError = True

        If Not IsNothing(sFileToSearch) Then
          ' Este Name de archivo es usado cuando quiero que el usuario elija un archivo
          If sFileToSearch <> " ." And Left(sFileToSearch, 2) <> "*." Then
            .FileName = sFileToSearch
          Else
            .FileName = ""
          End If
        End If

        If m_Filter <> "" Then
          .Filter = m_Filter
        Else
          If Not IsNothing(sFilter) Then
            .Filter = sFilter & "|" & sFilter
          End If
        End If

        If Not IsNothing(sCurDir) And Not Trim(sCurDir) = "" Then
          If Dir(sCurDir, FileAttribute.Directory) <> "" Then
            .InitDir = Dir(sCurDir, FileAttribute.Directory)
          End If
        End If

        .DialogTitle = sTitle

        If Not Guardando Then
          .ShowOpen()
        Else
          .ShowSave()
        End If

        If GetFileExt(.FileName) <> "" Then
          srtvalFile = GetPath(.FileName) & "\" & GetFileNameWithoutExt(.FileName) & "." & GetFileExt(.FileTitle)
        Else
          srtvalFile = GetFileNameWithoutExt(.FileName)
        End If
      End With

      ShowOpenFileDLG = True

    Catch ex As Exception

    End Try
  End Function
	
	' construccion - destruccion
  Private Sub ClassTerminate()
    FClose()
    m_CommDialog = Nothing
  End Sub
  Protected Overrides Sub Finalize()
    ClassTerminate()
    MyBase.Finalize()
  End Sub
End Class