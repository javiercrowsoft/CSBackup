Imports System.Net
Imports System.Timers
Imports VB = Microsoft.VisualBasic

Public Class BackupMessageEvent

  Inherits EventArgs

  Private m_Message As String

  Public ReadOnly Property Message() As String
    Get
      Message = m_Message
    End Get
  End Property

  Public Sub New(ByVal Message As String)
    m_Message = Message
  End Sub

End Class

Public Class cBackup

  Private Const C_MaxFilesInZip As Long = 100000 '1022

  Private WithEvents m_cZ As cZip

  Private m_FolderCount As Integer
  Private m_FileCount As Integer
  Private m_IdxFile As Integer
  Private m_Multizip As Integer
  Private m_cancel As Boolean
  Private m_IndexMsg As Integer
  Private m_zipFileName As String
  Private m_vMultiZips() As String
  Private m_Schedules As Collection
  Private m_Tasks As Collection
  Private m_idxTask As Integer

  Private Shared m_Timer As System.Timers.Timer

  Public Event Message As EventHandler(Of BackupMessageEvent)

  Public Sub InitProcess()

    pInitLog()

    m_Schedules = New Collection
    m_Tasks = New Collection

    pLogError("*")
    pLogError("***********************************************")
    pLogError("***********************************************")
    pLogError("***********************************************")
    pLogError("*")

    pLogError("Iniciando la ejecución de CSBackup Service")

    pLogError("Cargando Tareas Programadas")

    pLogError("DataBase Path: " & GetIniValue(csSecConfig, csDbPath, "", GetIniFullFile(csIniFile)))

    ' TODO
    '
    LoadScheduleInColl(m_Schedules)

    pLogError("Tareas Programadas cargadas con éxito")

    pLogError("Cargando Tareas de Backup")

    ' TODO
    '
    LoadTaskInColl(m_Tasks)

    pLogError("Tareas de Backup Cargadas con éxito")

    ReDim m_vMultiZips(0)

    '-------------------------------------------------------
    ' Timer
    '

    ' Normally, the timer is declared at the class level,
    ' so that it stays in scope as long as it is needed.
    ' If the timer is declared in a long-running method,  
    ' KeepAlive must be used to prevent the JIT compiler 
    ' from allowing aggressive garbage collection to occur 
    ' before the method ends. (See end of method.)
    'Dim aTimer As System.Timers.Timer

    ' Create a timer with a ten second interval.
    m_Timer = New System.Timers.Timer(60000)

    ' Hook up the Elapsed event for the timer.
    AddHandler m_Timer.Elapsed, AddressOf OnTimedEvent

    m_Timer.Enabled = True

    ' If the timer is declared in a long-running method, use
    ' KeepAlive to prevent garbage collection from occurring
    ' before the method ends.
    GC.KeepAlive(m_Timer)

    '-------------------------------------------------------

    pLogError("Ejecución de CSBackup Service Iniciada con éxito")
    pLogError("*")
    pLogError("*")

#If DEBUG Then
    pProcessTimer()
#End If

  End Sub

  ' This method is called by the timer delegate.
  Private Sub OnTimedEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)

#If DEBUG Then
    pLogError("Entrando en OnTimedEvent")
#End If

    m_Timer.Stop()

    ' Por si lo necesito
    '
    ' Dim autoEvent As AutoResetEvent = DirectCast(stateInfo, AutoResetEvent)

    Try

#If DEBUG Then
      pLogError("Ejecutando OnTimedEvent")
#End If

      m_cancel = False
      pProcessTimer()

    Catch ex As Exception

      pLogError(ex.Message)

    Finally

      m_Timer.Start()

    End Try

#If DEBUG Then
    pLogError("Saliendo de OnTimedEvent")
#End If

  End Sub

  Public Sub EndProcess()

    pLogError("*")
    pLogError("*")

    pLogError("Terminando la ejecución de CSBackup Service")

    Try

      m_Timer.Stop()

      m_cancel = True
      m_cZ = Nothing
      ReDim m_vMultiZips(0)

    Catch ex As Exception

      pLogError(ex.Message)

    End Try

    pLogError("Ejecución de CSBackup Service terminada con éxito")

    pLogError("*")
    pLogError("***********************************************")
    pLogError("***********************************************")
    pLogError("***********************************************")
    pLogError("*")
    pLogError("*")

  End Sub

  Private Sub pInitLog()
    Dim oldPath As String = FileGetValidPath(My.Application.Info.DirectoryPath) & LOG_NAME
    Dim newPath As String = FileGetValidPath(My.Application.Info.DirectoryPath) & LOG_NAME.Substring(1, LOG_NAME.Length - 4) & Now.ToString("dd-mm-yy-hh-mm-ss") & ".log"
    If Dir(oldPath) <> "" Then
      Rename(oldPath, newPath)
    End If
  End Sub

  Private Sub pLogError(ByVal msg As String)
    Dim e As BackupMessageEvent = New BackupMessageEvent(msg)
    RaiseEvent Message(Me, e)

    ' To File

    Dim f As Short
    f = FreeFile()
    FileOpen(f, FileGetValidPath(My.Application.Info.DirectoryPath) & LOG_NAME, OpenMode.Append, OpenAccess.Write, OpenShare.Shared)
    PrintLine(f, Now.ToString("dd/MM/yy hh:mm:ss   ") & msg)
    FileClose(f)
  End Sub

  Private Sub pProcessTimer()
    Dim i As Integer
    Dim ScheduleFile As String

    For i = 1 To m_Schedules.Count

      ScheduleFile = m_Schedules.Item(i)

      If pIsTimeToExecute(ScheduleFile) Then

        pProcessSechedule(ScheduleFile)

      End If
    Next
  End Sub

  Private Function pIsTimeToExecute(ByVal ScheduleFile As String) As Boolean

    Dim Schedule As cSchedule
    Schedule = New cSchedule

    Dim strError As String = ""
    Dim NextRun As Date

    If Not Schedule.Load(ScheduleFile, True, strError) Then

      pAddToLog("No se pudo cargar la programación [" & ScheduleFile & "]")
      pAddToLog("Error: " & strError)
      Exit Function
    End If

    Dim bIsTime As Boolean
    Dim bIsDay As Boolean

    Dim EmptyDate As Date
    With Schedule

      If .RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeOnce Then


        If .LastRun = EmptyDate Then
          bIsTime = .Time <= Now
          bIsDay = bIsTime
        End If

      Else

        '                           (RPrg_TimeType = @csSchTypeTimeRecurring
        If .TimeType = cScheduleEnums.csScheduleTimeType.csSchTimeTypeRecurring Then

          '                             and (     (RPrg_RunEachType = @csSchEachTypeHour
          If .RunEachType = cScheduleEnums.csScheduleEachType.csSchEachTypeHour Then
            '                                         and   datepart(hh,dateadd(hh,RPrg_RunEach,RPrg_lastRun))*100
            '                                             + datepart(n,dateadd(hh,RPrg_RunEach,RPrg_lastRun))
            '                                             <=
            '                                               datepart(hh,@hora)*100
            '                                             + datepart(n,@hora)
            '                                       )
            If .FirtsRunStartAt <= Now Then

              If .LastRunEndAt >= Now Then

                If Hour(.TimeStart) * 100 + Minute(.TimeStart) <= Hour(Now) * 100 + Minute(Now) Then

                  If Hour(.TimeEnd) * 100 + Minute(.TimeEnd) >= Hour(Now) * 100 + Minute(Now) Then

                    NextRun = DateAdd(DateInterval.Hour, .RunEach, .LastRun)

                    If Hour(NextRun) * 100 + Minute(NextRun) <= Hour(Now) * 100 + Minute(Now) Then

                      bIsTime = True

                    End If
                  End If
                End If
              End If
            End If
            '                                   or  (RPrg_RunEachType = @csSchEachTypeMinute
          ElseIf .RunEachType = cScheduleEnums.csScheduleEachType.csSchEachTypeMinute Then

            '                                         and   datepart(hh,dateadd(n,RPrg_RunEach,RPrg_lastRun))*100
            '                                             + datepart(n,dateadd(n,RPrg_RunEach,RPrg_lastRun))
            '                                             <=
            '                                               datepart(hh,@hora)*100
            '                                             + datepart(n,@hora)
            '                                       )
            '                                 )
            '                           )

            If .FirtsRunStartAt <= Now Then

              If .LastRunEndAt >= Now Then

                If Hour(.TimeStart) * 100 + Minute(.TimeStart) <= Hour(Now) * 100 + Minute(Now) Then

                  If Hour(.TimeEnd) * 100 + Minute(.TimeEnd) >= Hour(Now) * 100 + Minute(Now) Then

                    NextRun = DateAdd(DateInterval.Minute, .RunEach, .LastRun)

                    If Hour(NextRun) * 100 + Minute(NextRun) <= Hour(Now) * 100 + Minute(Now) Then

                      bIsTime = True

                    End If
                  End If
                End If
              End If
            End If

          End If

        ElseIf .TimeType = cScheduleEnums.csScheduleTimeType.csSchTimeTypeAtThisTime Then

          '                       or  (RPrg_TimeType = @csSchTypeTimeAtThisTime
          '
          '                             and     datepart(hh,RPrg_Time)*100+datepart(n,RPrg_Time)
          '                                 <=  datepart(hh,@hora)*100+datepart(n,@hora)
          '                           )
          '                     )
          If Hour(.Time) * 100 + Minute(.Time) <= Hour(Now) * 100 + Minute(Now) Then

            If DateSerial(Year(.LastRun), Month(.LastRun), VB.Day(.LastRun)) < DateSerial(Year(Now), Month(Now), VB.Day(Now)) Then

              bIsTime = True
            End If
          End If

        End If

        If bIsTime Then
          If .FirtsRunStartAt > Now Then

            bIsTime = False

          ElseIf .LastRunEndAt < Now Then

            bIsTime = False

          End If
        End If

        If .RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeDaily Then

          '                 and (     (RPrg_RunType = @csSchTypeRunDaily
          '                             and     datepart(hh,dateadd(d,RPrg_RunDailyInterval,RPrg_lastRun))*100
          '                                   + datepart(n,dateadd(d,RPrg_RunDailyInterval,RPrg_lastRun))
          '                                  <=
          '                                     datepart(hh,@hora)*100
          '                                   + datepart(n,@hora)
          '                           )

          NextRun = DateAdd(DateInterval.Day, .RunDailyInterval, .LastRun)
          If NextRun <= Now Then

            bIsDay = True

          Else

            If .TimeType = cScheduleEnums.csScheduleTimeType.csSchTimeTypeRecurring Then

              If .LastRun <= Now And bIsTime Then

                bIsDay = True
              End If
            End If
          End If

        ElseIf .RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeWeekly Then

          '                       or  (RPrg_RunType = @csSchTypeRunWeekly
          '                             and datepart(wk,
          '                                   dateadd(d,
          '                                           7*(RPrg_RunWeeklyInterval-1),
          '                                           RPrg_lastRun)
          '                                 ) <= datepart(wk,@ahora)
          '                             and (     (datepart(dw,@ahora) = 1 and RPrg_RunSunday <> 0)
          '                                   or  (datepart(dw,@ahora) = 2 and RPrg_RunMonday <> 0)
          '                                   or  (datepart(dw,@ahora) = 3 and RPrg_RunTuesday <> 0)
          '                                   or  (datepart(dw,@ahora) = 4 and RPrg_RunWednesday <> 0)
          '                                   or  (datepart(dw,@ahora) = 5 and RPrg_RunThursday <> 0)
          '                                   or  (datepart(dw,@ahora) = 6 and RPrg_RunFriday <> 0)
          '                                   or  (datepart(dw,@ahora) = 7 and RPrg_RunSaturday <> 0)
          '                                 )
          '                           )

          NextRun = DateAdd(DateInterval.Day, 7 * (.RunWeeklyInterval - 1), .LastRun)
          If DatePart(DateInterval.WeekOfYear, NextRun, FirstDayOfWeek.Sunday) <= DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Sunday) Then

            If (DatePart(DateInterval.Weekday, NextRun, FirstDayOfWeek.Sunday) = 1 And .RunSunday) _
            Or (DatePart(DateInterval.Weekday, NextRun, FirstDayOfWeek.Sunday) = 2 And .RunMonday) _
            Or (DatePart(DateInterval.Weekday, NextRun, FirstDayOfWeek.Sunday) = 3 And .RunTuesday) _
            Or (DatePart(DateInterval.Weekday, NextRun, FirstDayOfWeek.Sunday) = 4 And .RunWednesday) _
            Or (DatePart(DateInterval.Weekday, NextRun, FirstDayOfWeek.Sunday) = 5 And .RunThursday) _
            Or (DatePart(DateInterval.Weekday, NextRun, FirstDayOfWeek.Sunday) = 6 And .RunFriday) _
            Or (DatePart(DateInterval.Weekday, NextRun, FirstDayOfWeek.Sunday) = 7 And .RunSaturday) Then

              bIsDay = True

            End If
          End If
        ElseIf .RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeMonthly Then
          '                       or  (RPrg_RunType = @csSchTypeRunMonthly
          '                             and RPrg_RunMonthlyNumberDay = datepart(d,@ahora)
          '                             and datepart(m,dateadd(m,RPrg_RunMonthlyInterval,RPrg_lastRun)) <= datepart(m,@ahora)
          '                           )

          If .RunMonthlyNumberDay = VB.Day(Now) Then

            NextRun = DateAdd(DateInterval.Month, .RunMonthlyInterval, .LastRun)
            If Month(NextRun) <= Month(Now) Then
              bIsDay = True
            End If
          End If

        ElseIf .RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeMonthlyRelative Then
          '                       or  (RPrg_RunType = @csSchTypeRunMonthlyRelative
          '                             and RPrg_RunMonthlyCardinalDay = datepart(d,@ahora) / 7 +1
          '                             and RPrg_RunMonthlyNameDay = datepart(dw,@ahora)
          '                             and datepart(m,dateadd(m,RPrg_RunMonthlyInterval,RPrg_lastRun)) <= datepart(m,@ahora)
          '                           )
          '                     )

          If .RunMonthlyCardinalDay = DatePart(DateInterval.Day, Now) / 7 + 1 Then

            If .RunMonthlyNameDay = DatePart(DateInterval.Weekday, Now, FirstDayOfWeek.Sunday) Then

              NextRun = DateAdd(DateInterval.Month, .RunMonthlyInterval, .LastRun)
              If Month(NextRun) = Month(Now) Then
                bIsDay = True
              End If
            End If
          End If

        End If
        '
        '                 and RPrg_TimeStart        <= @hora
        '                 and RPrg_TimeEnd          >= @hora
        '                 and RPrg_FirtsRunStartAt  <= @ahora
        '                 and RPrg_LastRunEndAt     >= @ahora
        '               )

      End If
    End With

    pAddToLog("La programación " & Schedule.Name)
    pAddToLog("se ejecuto por ultima vez el " & Schedule.LastRun)
    pAddToLog("La proxima ejecucion sera el " & NextRun)

    If bIsDay And bIsTime Then

      Schedule.LastRun = Now

      If Not Schedule.Save(True, strError) Then
        pAddToLog("No se pudo actualizar la tarea")
        pAddToLog("Error: " & strError)
        Exit Function
      End If

      pIsTimeToExecute = True
    End If

  End Function

  Private Function pProcessSechedule(ByVal ScheduleFile As String) As Boolean

    pAddToLog("Cargando programación")
    pAddToLog(ScheduleFile)

    Dim strError As String = ""
    Dim Schedule As cSchedule
    Schedule = New cSchedule

    Dim i As Integer
    If Schedule.Load(ScheduleFile, True, strError) Then

      pAddToLog("Procesando Programación")
      pAddToLog(Schedule.Name)


      For i = 1 To Schedule.Tasks.Count()

        If pSelectTask(Schedule.Tasks.Item(i).Name) Then

          pProcessTask(m_Tasks.Item(m_idxTask).TaskFile)
        Else

          pAddToLog("No se encontro la tarea " & Schedule.Tasks.Item(i).Name & " en la lista de tareas")
        End If

      Next

      pProcessSechedule = True

    Else

      pAddToLog("No se pudo cargar la programación")
      pAddToLog(ScheduleFile)
      pAddToLog("Error: " & strError)

      pProcessSechedule = False

    End If

  End Function

  Private Sub pAddToLog(ByVal msg As String)
    pLogError(msg)
  End Sub

  Private Sub pUpdateLog(ByVal msg As String, ByVal Index As Integer)
    pLogError(msg)
  End Sub

  Private Function pProcessTask(ByVal TaskFile As String) As Boolean

    Dim strError As String = ""

    pAddToLog("Cargando Tarea")
    pAddToLog(TaskFile)

    m_Multizip = 0

    If TaskType(TaskFile, True, strError) = mPublic.csETaskTypeBackup.c_TaskTypeBackupDB Then
      pProcessTask = pProcessTaskDB(TaskFile)
    Else
      pProcessTask = pProcessTaskFile(TaskFile)
    End If

    If strError <> "" Then
      pAddToLog("Error: " & strError)
    End If

  End Function

  Private Function pProcessTaskDB(ByVal TaskFile As String) As Boolean

    Dim Task As cSQLTaskCommandBackup
    Task = New cSQLTaskCommandBackup

    Dim strError As String = ""

    Dim Zip As cZip
    If Task.Load(TaskFile, True, strError) Then

      pAddToLog("Procesando Tarea de Backup de Base de Datos SQL")
      pAddToLog(Task.Name)

      If Task.Connect(Task.Server, Task.User, Task.Pwd, Task.SecurityType, True, strError) Then

        pAddToLog("Generando el backup")
        If Task.Conn.Execute(Task.SqlstmtBackup, True, strError) Then

          pAddToLog("Generando el zip")

          Zip = pCreateZip(Task.File)

          If Task.IsLog Then
            pAddToZip(Zip, pGetFilInServer(Task.BackupLogFileName, Task.ServerFolder))
          Else
            pAddToZip(Zip, pGetFilInServer(Task.BackupFileName, Task.ServerFolder))
          End If

          If CBool(Task.ZipFiles) Then
            pRenameZipFiles(Zip.ZipFile, CInt(Task.ZipFiles))
          End If

          pZip(Zip)

          If Task.FtpAddress <> "" Then

            pAddToLog("Subiendo el archivo al FTP [" & Task.FtpAddress & "]")
            pAddToLog("...")

            If pWriteFile(Task.File, Task.FtpAddress, Task.FtpUser, Task.FtpPwd, Task.FtpPort, strError) Then

              pAddToLog("El archivo se subio con éxito")

              pProcessTaskDB = True

            Else

              pAddToLog("No se pudo subir el archivo al FTP")
              pAddToLog("Error " & strError)
              pProcessTaskDB = False
            End If
          Else

            pProcessTaskDB = True

          End If

        Else

          pAddToLog("No se pudo el backup de la base [" & Task.Server & "." & Task.DataBase & "]")
          pAddToLog("Error: " & strError)

          pProcessTaskDB = False

        End If

      Else

        pAddToLog("No se pudo abrir la conexion con el servidor [" & Task.Server & "]")
        pAddToLog("Usando [" & Task.User & "]")
        pAddToLog("Y seguridad por [" & IIf(Task.SecurityType = mAux.csSQLSecurityType.csTSNT, "NT", "SQL") & "]")
        pAddToLog("Error: " & strError)

        pProcessTaskDB = False

      End If

    Else

      pAddToLog("No se pudo cargar la tarea")
      pAddToLog(TaskFile)
      pAddToLog("Error: " & strError & " - ")

      pProcessTaskDB = False

    End If

  End Function

  Private Function pGetCountFoldersToRead(ByRef Task As cTask) As Long
    Dim i As Long
    Dim rtn As Long

    For i = 1 To Task.Folders.Count()

      rtn = rtn + pGetCountFoldersToReadAux(Task.Folders.Item(i))

      If m_cancel Then Exit Function

    Next

    pGetCountFoldersToRead = rtn
  End Function

  Private Function pGetCountFoldersToReadAux(ByRef TaskItem As cTaskItem) As Long
    Dim Item As cTaskItem
    Dim rtn As Long

    If TaskItem.Children.Count() Then

      rtn = TaskItem.Children.Count()

      For Each Item In TaskItem.Children
        rtn = rtn + pGetCountFoldersToReadAux(Item)
      Next Item

    End If

    pGetCountFoldersToReadAux = rtn
  End Function

  Private Sub pInitProgress()
    m_FileCount = 0
    m_FolderCount = 0
    m_IdxFile = 0
  End Sub

  Private Function pProcessTaskFile(ByVal TaskFile As String) As Boolean

    Dim Task As cTask
    Task = New cTask

    Dim strError As String = ""

    Dim Zip As cZip
    Dim i As Integer

    pInitProgress()

    If Task.Load(TaskFile, True, strError) Then

      pAddToLog("Procesando Tarea de Backup de Carpetas y Archivos")
      pAddToLog(Task.Name)

      ' Por si hay mas de c_MaxFilesInZip archivos
      '
      m_zipFileName = Task.File
      ReDim m_vMultiZips(0)

      If CBool(Task.ZipFiles) Then
        pRenameZipFiles(Task.File, CInt(Task.ZipFiles))
      End If

      Zip = pCreateZip(Task.File)

      m_FolderCount = pGetCountFoldersToRead(Task)

      For i = 1 To Task.Folders.Count()

        pProcessTaskFolder(Task.Folders.Item(i), Zip)

        If m_cancel Then Exit Function

      Next

      pZip(Zip)

      If m_Multizip Then

        Zip = pCreateZip(Task.File)

        For i = 1 To UBound(m_vMultiZips)
          pAddToZip(Zip, m_vMultiZips(i))
        Next

        pZip(Zip)

        For i = 1 To UBound(m_vMultiZips) - 1
          pKill(m_vMultiZips(i))
        Next

      End If

      If Task.FtpAddress <> "" Then

        pAddToLog("Subiendo el archivo al FTP [" & Task.FtpAddress & "]")
        pAddToLog("...")

        If pWriteFile(Task.File, Task.FtpAddress, Task.FtpUser, Task.FtpPwd, Task.FtpPort, strError) Then

          pAddToLog("El archivo se subio con éxito")

          pProcessTaskFile = True

        Else

          pAddToLog("No se pudo subir el archivo al FTP")
          pAddToLog("Error " & strError)
          pProcessTaskFile = False
        End If
      Else

        pProcessTaskFile = True

      End If

    Else
      pAddToLog("No se pudo cargar la programación")
      pAddToLog(TaskFile)
      pAddToLog("Error: " & strError & " - ")

      pProcessTaskFile = False

    End If
  End Function

  Private Sub pAddFileToProgress()
    Dim i As Long

    m_IdxFile = m_IdxFile + 1
    i = DivideByZero(m_IdxFile, m_FileCount) * 100
    pShowProgress(i)

  End Sub

  Private Sub pAddFolderToProgress()
    Dim i As Long

    m_IdxFile = m_IdxFile + 1
    i = DivideByZero(m_IdxFile, m_FolderCount) * 100
    pShowProgress(i)

  End Sub

  Private Function pProcessTaskFolder(ByVal TaskItem As cTaskItem, ByRef Zip As cZip) As Boolean

    If TaskItem.Checked Then

      If TaskItem.ItemType = cTaskItem.csEItemTypes.csEIT_File Then

        pAddToLog("Procesando Archivo")
        pAddToLog(TaskItem.Name)

        pAddToZip(Zip, TaskItem.FullPath)

      Else

        pAddToLog("Procesando Carpeta")
        pAddToLog(TaskItem.Name)

        pAddFolderToZip(Zip, TaskItem.FullPath)

      End If

    Else

      pAddToLog("Procesando Carpeta")
      pAddToLog(TaskItem.Name)

    End If

    Dim Item As cTaskItem
    If TaskItem.Children.Count() Then

      For Each Item In TaskItem.Children
        pProcessTaskFolder(Item, Zip)
      Next Item
    End If

    pAddFolderToProgress()

  End Function

  Private Function pSelectTask(ByVal TaskName As String) As Boolean
    Dim i As Integer

    m_idxTask = 0

    For i = 1 To m_Tasks.Count

      If m_Tasks.Item(i).TaskName = TaskName Then

        m_idxTask = i
        pSelectTask = True
        Exit Function
      End If
    Next
  End Function

  Private Function pCreateZip(ByVal ZipFile As String) As cZip

    pInitProgress()

    ' Creo el zip
    '
    Dim Zip As cZip = New cZip

    m_cZ = Zip

    With Zip

      '.Encrypt = GetPasswordFiles() <> ""
      '.AddComment = False
      .Password = GetPasswordFiles()
      .ZipFile = ZipFile
      '.StoreFolderNames = True
      '.RecurseSubDirs = False
      '.ClearFileSpecs()

    End With

    pKill(ZipFile)

    pCreateZip = Zip

  End Function

  Private Function pZip(ByRef Zip As cZip) As Boolean

    With Zip

      ' Si estamos en un zip multipart y no hay
      ' archivos que comprimir, no generamos un
      ' archivo zip vacio. Esto se da por que el
      ' limite es de C_MaxFilesInZip archivos por zip, y
      ' la funcion pAddToZip cuando se alcanza este
      ' limite llama a esta funcion pZip y se genera
      ' el zip, y cuando justo era el ultimo archivo
      ' que se agregaba al zip, el ultimo multipart
      ' no es necesario.
      '
      If m_Multizip > 0 And .FileSpecCount = 0 Then
        pZip = True
      Else

        ' Agrego tres renglones al
        ' log par ir mostrando los
        ' progresos
        '
        pAddToLog("")
        pAddToLog("")
        pAddToLog("")
        m_IndexMsg = 0

        .Zip()

        If (.Success) Then

          pAddToLog("Archivo generado: " & .ZipFile)
          pZip = True
        Else
          pAddToLog("Falló la creación del zip.")
          pZip = False
        End If
      End If

      ReDim Preserve m_vMultiZips(UBound(m_vMultiZips) + 1)
      m_vMultiZips(UBound(m_vMultiZips)) = Zip.ZipFile

    End With

  End Function

  Private Sub pAddToZip(ByRef Zip As cZip, ByVal FullFileName As String)

    If Zip.FileSpecCount = C_MaxFilesInZip Then

      Zip.ZipFile = pGetMultiZipName(m_zipFileName, CStr(m_Multizip))

      pZip(Zip)

      m_Multizip = m_Multizip + 1
      Zip = pCreateZip(pGetMultiZipName(m_zipFileName, CStr(m_Multizip)))

    Else

      Zip.AddFileSpec(FullFileName)
      m_FileCount = m_FileCount + 3

    End If
  End Sub

  Private Sub pAddFolderToZip(ByRef Zip As cZip, ByVal FullFolderName As String)
    Dim s As String
    Dim FullFileName As String

    FullFolderName = FileGetValidPath(FullFolderName)

    s = Dir(FullFolderName & "*.*")

    While s <> ""
      FullFileName = FullFolderName & s
      pAddToZip(Zip, FullFileName)
      pUpdateLog(FullFileName, m_IndexMsg)
      s = Dir()
      If m_cancel Then Exit Sub
    End While

    Dim vDirs() As String
    ReDim vDirs(0)

    s = Dir(FullFolderName, FileAttribute.Directory)

    Do
      If s = "" Then Exit Do
      If (GetAttr(FullFolderName & s) And FileAttribute.Directory) = FileAttribute.Directory And s <> ".." And s <> "." Then
        ReDim Preserve vDirs(UBound(vDirs) + 1)
        vDirs(UBound(vDirs)) = FullFolderName & s
      End If
      s = Dir()
      If m_cancel Then Exit Sub
    Loop

    Dim i As Short

    For i = 1 To UBound(vDirs)
      pAddFolderToZip(Zip, vDirs(i))
      If m_cancel Then Exit Sub
    Next

  End Sub

  Private Function pGetMultiZipName(ByVal FullFileName As String, ByVal nIndex As String) As String
    Dim rtn As String

    rtn = GetFileNameWithoutExt_(FullFileName) & "_" & String.Format("{0:000}", nIndex) & "." & GetFileExt_(FullFileName)

    pGetMultiZipName = FileGetValidPath(GetPath_(FullFileName)) & rtn
  End Function

  Private Sub m_cZ_Progress(ByVal lCount As Integer, ByVal sMsg As String) Handles m_cZ.Progress

    pAddToLog(sMsg)
    pAddFileToProgress()

  End Sub

  Private Sub pShowProgress(ByVal i As Long)
  End Sub

  Private Sub pKill(ByVal FullFileName As String)
    Try

      If Dir(FullFileName) <> "" Then
        Kill(FullFileName)
      End If

    Catch ex As Exception

    End Try
  End Sub

  Private Function pWriteFile(ByVal FullFileName As String, _
                              ByVal IPaddress As String, _
                              ByVal User As String, _
                              ByVal Password As String, _
                              ByVal Port As Integer, _
                              ByRef strError As String) As Boolean

    Try

      Dim ftpFolder As String = IPaddress

      If ftpFolder <> "" Then

        ' Usamos el objeto ftp de .net
        '
        If GetIniValue(csSecConfig, csFtpType, "1", GetIniFullFile(csIniFile)) = "1" Then

          If ftpFolder.Substring(ftpFolder.Length - 1, 1) <> "/" Then
            ftpFolder = ftpFolder & "/"
          End If

          '----------------------------------
          ' set up request...
          Dim clsRequest As System.Net.FtpWebRequest
          clsRequest = DirectCast(WebRequest.Create(ftpFolder & GetFileName_(FullFileName)), System.Net.FtpWebRequest)
          clsRequest.Credentials = New System.Net.NetworkCredential(User, Password)
          clsRequest.Proxy = Nothing
          clsRequest.UsePassive = False
          clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

          ' read in file...
          Dim bFile() As Byte = System.IO.File.ReadAllBytes(FullFileName)

          ' upload file...
          Dim clsStream As System.IO.Stream

          clsStream = clsRequest.GetRequestStream()
          clsStream.Write(bFile, 0, bFile.Length)
          clsStream.Close()
          clsStream.Dispose()

          pWriteFile = True

        Else

          ' Llamamos al comando ftp de windows
          ' 

          Dim console_command As String
          Dim file_command As String
          Dim file_ftp_exe As String

          file_command = FileGetValidPath(My.Application.Info.DirectoryPath) & FTP_COMMAND
          file_ftp_exe = GetIniValue(csSecConfig, csFtpExePath, "1", GetIniFullFile(csIniFile))

          Try

            Kill(file_command)

          Catch ex As Exception

          End Try

          ftpFolder = Replace(ftpFolder, "ftp://", "")

          Dim f As Short
          f = FreeFile()
          FileOpen(f, file_command, OpenMode.Append, OpenAccess.Write, OpenShare.Shared)
          PrintLine(f, "open " & ftpFolder)
          PrintLine(f, "user")
          PrintLine(f, User)
          PrintLine(f, Password)
          PrintLine(f, "put """ & FullFileName & """")
          PrintLine(f, "bye")
          FileClose(f)

          pLogError("*************************************")

          pLogError("Contenido de ftpFolder:")
          pLogError("open " & ftpFolder)
          pLogError("user")
          pLogError(User)
          pLogError("*******")
          pLogError("put """ & FullFileName & """")
          pLogError("bye")

          pLogError("*************************************")

          console_command = "-n -s:""" & file_command & """"

          pLogError("Ejecutando console_command")

          ShellandWait(file_ftp_exe, console_command)

          Try

            Kill(file_command)

          Catch ex As Exception

            pLogError(ex.Message)

          End Try

          pWriteFile = True

        End If

      Else

        pWriteFile = False

      End If

    Catch ex As Exception

      strError = ex.Message
      pLogError(ex.Message)

    End Try
  End Function

  Private Function pGetFilInServer(ByVal File As String, ByVal Folder As String) As String

    If Folder <> "" Then
      File = GetFileName_(File)
      File = FileGetValidPath(Folder) & File
    End If

    pGetFilInServer = File

  End Function

  Private Sub pRenameZipFiles(ByVal ZipFile As String, ByVal ZipFiles As Integer)
    Dim zf As String
    Dim fzf As String
    Dim zfe As String

    If ZipFiles = 0 Then Exit Sub

    zf = GetFileNameWithoutExt_(ZipFile)
    zfe = GetFileExt_(ZipFile)

    ' Borro el ultimo
    '
    fzf = FileGetValidPath(GetPath_(ZipFile)) & zf & String.Format("{0:0000}", ZipFiles) & "." & zfe
    pKill(fzf)

    Dim i As Integer

    For i = ZipFiles - 1 To 1 Step -1
      fzf = FileGetValidPath(GetPath_(ZipFile)) & zf & String.Format("{0:0000}", i) & "." & zfe
      If FileExists_(fzf) Then
        Rename(fzf, FileGetValidPath(GetPath_(ZipFile)) & zf & String.Format("{0:0000}", i + 1) & "." & zfe)
      End If
    Next

    If FileExists_(ZipFile) Then
      Rename(ZipFile, FileGetValidPath(GetPath_(ZipFile)) & zf & "0001." & zfe)
    End If

  End Sub

  Public Sub ShellandWait(ByVal ProcessPath As String, ByVal args As String)
    Dim objProcess As System.Diagnostics.Process

    Try
      objProcess = New System.Diagnostics.Process()
      objProcess.StartInfo.Arguments = args
      objProcess.StartInfo.FileName = ProcessPath
      objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
      objProcess.StartInfo.CreateNoWindow = True
      objProcess.StartInfo.UseShellExecute = True
      objProcess.Start()

      'Wait until the process passes back an exit code 
      objProcess.WaitForExit()

      'Free resources associated with this process
      objProcess.Close()
    Catch
      MessageBox.Show("Could not start process " & ProcessPath, "Error")
    End Try
  End Sub

End Class
