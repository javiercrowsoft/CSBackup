Option Strict Off
Option Explicit On
Module mSchedule
	
  Public Function LoadSchedule(ByRef lvSchedule As System.Windows.Forms.ListView) As Boolean
    Dim dbPath As String
    Dim FileName As String

    dbPath = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))

    With lvSchedule.Columns
      .Clear()
      .Add("", "Nombre", 233)
      .Add("", "Path", 300)
    End With

    lvSchedule.Items.Clear()

    If Not pValidateFolder(dbPath) Then Exit Function

    FileName = Dir(dbPath & "\*_sch.xml", FileAttribute.Archive)
    While FileName <> ""

      With lvSchedule.Items.Add(FileName, 1)

        .SubItems.Add(dbPath & "\" & FileName)

      End With

      FileName = Dir()
    End While
  End Function

  Public Function LoadScheduleInColl(ByRef collSchedule As Collection) As Boolean
    Dim dbPath As String
    Dim FileName As String

    dbPath = GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile))

    If Not pValidateFolder(dbPath) Then Exit Function

    FileName = Dir(dbPath & "\*_sch.xml", FileAttribute.Archive)

    While FileName <> ""

      collSchedule.Add(dbPath & "\" & FileName)

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
End Module