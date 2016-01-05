Option Strict Off
Option Explicit On

Public Class cTaskInfo
  Private m_TaskFile As String
  Private m_TaskName As String

  Public Property TaskFile() As String
    Get
      TaskFile = m_TaskFile
    End Get
    Set(ByVal value As String)
      m_TaskFile = value
    End Set
  End Property

  Public Property TaskName() As String
    Get
      TaskName = m_TaskName
    End Get
    Set(ByVal value As String)
      m_TaskName = value
    End Set
  End Property
End Class

Module mTask
	
	Public Function LoadTask(ByRef lvTask As System.Windows.Forms.ListView) As Boolean
		Dim dbPath As String
    Dim FileName As String

    dbPath = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))

    With lvTask.Columns
      .Clear()
      .Add("", "Nombre", 233)
      .Add("", "Path", 300)
    End With

    lvTask.Items.Clear()

    If Not pValidateFolder(dbPath) Then Exit Function

    FileName = Dir(dbPath & "\*_def.xml", FileAttribute.Archive)
    While FileName <> ""

      With lvTask.Items.Add(FileName, 2)

        .SubItems.Add(dbPath & "\" & FileName)

      End With

      FileName = Dir()
    End While
		
		Dim i As Short
		With lvTask.Items
      For i = 0 To .Count - 1

        With .Item(i)
          .Tag = pGetDescrip(.SubItems(1).Text)
        End With
      Next
		End With
	End Function

  Public Function LoadTaskInColl(ByRef collTask As Collection) As Boolean
    Dim dbPath As String
    Dim FileName As String
    Dim TaskInfo As cTaskInfo

    dbPath = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))

    If Not pValidateFolder(dbPath) Then Exit Function

    FileName = Dir(dbPath & "\*_def.xml", FileAttribute.Archive)
    While FileName <> ""

      TaskInfo = New cTaskInfo
      TaskInfo.TaskName = FileName
      TaskInfo.TaskFile = dbPath & "\" & FileName
      collTask.Add(TaskInfo)

      FileName = Dir()
    End While

  End Function

	Private Function pValidateFolder(ByVal dbPath As String) As Boolean
    Try

      If GetAttr(dbPath) <> FileAttribute.Directory Then
        MsgBox("No se pudo acceder a la carpeta " & dbPath)
        Exit Function
      End If

      pValidateFolder = True

    Catch ex As Exception

      pValidateFolder = False

    End Try
  End Function
	
	Private Function pGetDescrip(ByVal TaskFile As String) As String
		Dim Task As cTask
		Task = New cTask
		
		If Task.Load(TaskFile, False) Then
      pGetDescrip = Task.Descrip
    Else
      pGetDescrip = ""
    End If
	End Function
End Module