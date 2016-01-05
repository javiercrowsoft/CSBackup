Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic

Friend Class fSchedule
	Inherits System.Windows.Forms.Form
	
	'--------------------------------------------------------------------------------
	' fSchedule
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
	Private Const C_Module As String = "fSchedule"
	
	' estructuras
	' variables privadas
	Private m_Schedule As cSchedule
	
	Private m_Changed As Boolean
	
	' eventos
	' propiedadades publicas
	' propiedadades friend
	' propiedades privadas
	' funciones publicas
	Public Function Edit(ByVal ScheduleFile As String) As Boolean
		
		m_Schedule = New cSchedule
		
    If ScheduleFile <> "" Then

      If Not m_Schedule.Load(ScheduleFile, False) Then
        Exit Function
      End If

      With Me
        .txName.Text = m_Schedule.Name
      End With

    End If
		
		m_Changed = False
		
		With lvTask
			.View = System.Windows.Forms.View.Details
			.GridLines = True
			.LabelEdit = False
			.FullRowSelect = True
			.Checkboxes = True
			.BorderStyle = System.Windows.Forms.BorderStyle.None
			.SmallImageList = ImageList1
		End With
		
		LoadTask(lvTask)
		
		Dim Item As System.Windows.Forms.ListViewItem
		Dim Task As cTask
		For	Each Item In lvTask.Items
			For	Each Task In m_Schedule.Tasks
				If Item.Text = Task.Name Then
					Item.Checked = True
					Exit For
				End If
			Next Task
		Next Item
		
		Me.ShowDialog()
		
	End Function
	' funciones friend
	' funciones privadas
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		pSave()
	End Sub
	
	Private Sub cmdSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveAs.Click
		Dim ScheduleName As String
		ScheduleName = InputBox("Ingrese el nombre", "Guardar Como", "Nueva Programación")

    If ScheduleName <> "" Then
      txName.Text = ScheduleName
      pSave()
    End If
	End Sub
	
	Private Sub cmdSchedule_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSchedule.Click
		picSchedule.BringToFront()
	End Sub
	
	Private Sub cmdTasks_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTasks.Click
		picTask.BringToFront()
	End Sub
	
	Private Sub opDaily_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opDaily.CheckedChanged
    Try

      If eventSender.Checked Then

        txEach.Enabled = True
        txEach.BackColor = System.Drawing.SystemColors.Window
        opDay.Visible = False
        lbEachDescrip1.Text = "Dia(s)"
        txEachMonth1.Visible = False
        opCardinalDay.Visible = False
        cbCardinalDay.Visible = False
        cbDayName.Visible = False

        chkMonday.Visible = False
        chkSunday.Visible = False
        chkTuesday.Visible = False
        chkWednesday.Visible = False
        chkThursday.Visible = False
        chkFriday.Visible = False
        chkSaturday.Visible = False

        lbEachDescrip2.Visible = False
        txEachMonth2.Visible = False
        lbMonths1.Visible = False
        lbMonths2.Visible = False

      End If

    Catch ex As Exception

      MngError(ex, "opDaily_CheckedChanged", C_Module, "")

    End Try

  End Sub

  Private Sub opDay_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opDay.CheckedChanged
    Try

      If eventSender.Checked Then


        txEach.Enabled = True
        txEach.BackColor = System.Drawing.SystemColors.Window
        txEachMonth1.Enabled = True
        txEachMonth1.BackColor = System.Drawing.SystemColors.Window

        cbCardinalDay.Enabled = False
        cbDayName.Enabled = False
        cbCardinalDay.BackColor = System.Drawing.SystemColors.Control
        cbDayName.BackColor = System.Drawing.SystemColors.Control
        txEachMonth2.Enabled = False
        txEachMonth2.BackColor = System.Drawing.SystemColors.Control

      End If

    Catch ex As Exception

      MngError(ex, "opDay_CheckedChanged", C_Module, "")

    End Try
  End Sub

  Private Sub opCardinalDay_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opCardinalDay.CheckedChanged
    Try

      If eventSender.Checked Then


        txEach.Enabled = False
        txEach.BackColor = System.Drawing.SystemColors.Control
        txEachMonth1.Enabled = False
        txEachMonth1.BackColor = System.Drawing.SystemColors.Control

        cbCardinalDay.Enabled = True
        cbDayName.Enabled = True
        cbCardinalDay.BackColor = System.Drawing.SystemColors.Window
        cbDayName.BackColor = System.Drawing.SystemColors.Window
        txEachMonth2.Enabled = True
        txEachMonth2.BackColor = System.Drawing.SystemColors.Window

      End If

    Catch ex As Exception

      MngError(ex, "opCardinalDay_CheckedChanged", C_Module, "")

    End Try
  End Sub

  Private Sub opEndDate_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opEndDate.CheckedChanged
    Try

      If eventSender.Checked Then


        txEndDate.Enabled = True
        txEndDate.BackColor = System.Drawing.SystemColors.Window

      End If

    Catch ex As Exception

      MngError(ex, "opEndDate_CheckedChanged", C_Module, "")

    End Try
  End Sub

  Private Sub opEndDateNever_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opEndDateNever.CheckedChanged
    Try

      If eventSender.Checked Then

        txEndDate.Enabled = False
        txEndDate.BackColor = System.Drawing.SystemColors.Control

      End If

    Catch ex As Exception

      MngError(ex, "opEndDate_CheckedChanged", C_Module, "")

    End Try
  End Sub

  Private Sub opMonthly_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opMonthly.CheckedChanged
    Try

      If eventSender.Checked Then

        opDay.Visible = True
        lbEachDescrip1.Text = "de cada :"
        txEachMonth1.Visible = True
        opCardinalDay.Visible = True
        cbCardinalDay.Visible = True
        cbDayName.Visible = True

        chkMonday.Visible = False
        chkSunday.Visible = False
        chkTuesday.Visible = False
        chkWednesday.Visible = False
        chkThursday.Visible = False
        chkFriday.Visible = False
        chkSaturday.Visible = False

        lbEachDescrip2.Visible = True
        txEachMonth2.Visible = True
        lbMonths1.Visible = True
        lbMonths2.Visible = True
        opDay.Checked = True
        opDay_CheckedChanged(opDay, New System.EventArgs())

      End If

    Catch ex As Exception

      MngError(ex, "opMonthly_CheckedChanged", C_Module, "")

    End Try
  End Sub

  Private Sub opOnceAt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opOnceAt.CheckedChanged
    Try

      If eventSender.Checked Then

        txOnceAt.Enabled = True
        txOnceAt.BackColor = System.Drawing.SystemColors.Window

        txOccursEach.Enabled = False
        txOccursEach.BackColor = System.Drawing.SystemColors.Control

        txTimeStart.Enabled = False
        txTimeStart.BackColor = System.Drawing.SystemColors.Control
        txTimeEnd.Enabled = False
        txTimeEnd.BackColor = System.Drawing.SystemColors.Control

        cbTimeType.Enabled = False
        cbTimeType.BackColor = System.Drawing.SystemColors.Control

      End If

    Catch ex As Exception

      MngError(ex, "opOnceAt_Click", C_Module, "")

    End Try
  End Sub

  Private Sub opOccursEach_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opOccursEach.CheckedChanged
    Try

      If eventSender.Checked Then

        txOnceAt.Enabled = False
        txOnceAt.BackColor = System.Drawing.SystemColors.Control

        txOccursEach.Enabled = True
        txOccursEach.BackColor = System.Drawing.SystemColors.Window

        cbTimeType.Enabled = True
        cbTimeType.BackColor = System.Drawing.SystemColors.Window
        txTimeStart.Enabled = True
        txTimeStart.BackColor = System.Drawing.SystemColors.Window
        txTimeEnd.Enabled = True
        txTimeEnd.BackColor = System.Drawing.SystemColors.Window

      End If

    Catch ex As Exception

      MngError(ex, "opOccursEach_Click", C_Module, "")

    End Try
  End Sub

  Private Sub opWeekly_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opWeekly.CheckedChanged
    Try

      If eventSender.Checked Then


        txEach.Enabled = True
        txEach.BackColor = System.Drawing.SystemColors.Window
        opDay.Visible = False
        lbEachDescrip1.Text = "semana(s) en :"
        txEachMonth1.Visible = False
        opCardinalDay.Visible = False
        cbCardinalDay.Visible = False
        cbDayName.Visible = False

        chkMonday.Visible = True
        chkSunday.Visible = True
        chkTuesday.Visible = True
        chkWednesday.Visible = True
        chkThursday.Visible = True
        chkFriday.Visible = True
        chkSaturday.Visible = True

        lbEachDescrip2.Visible = False
        txEachMonth2.Visible = False
        lbMonths1.Visible = False
        lbMonths2.Visible = False

      End If

    Catch ex As Exception

      MngError(ex, "opWeekly_Click", C_Module, "")

    End Try
  End Sub

  Private Sub opRunAt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opRunAt.CheckedChanged
    Try

      If eventSender.Checked Then

        Dim ctl As System.Windows.Forms.Control

        For Each ctl In Controls
          If ctl Is opRunRecurring Then
          ElseIf ctl Is picSchedule Then
          ElseIf ctl Is cmdSchedule Then
          ElseIf ctl Is cmdTasks Then
          ElseIf ctl Is cmdCancel Then
          ElseIf ctl Is cmdSave Then
          ElseIf ctl Is cmdSaveAs Then
          ElseIf TypeOf ctl Is System.Windows.Forms.Label Then
          ElseIf ctl Is txName Then
          ElseIf ctl Is lbName Then
          ElseIf ctl Is ImageList1 Then
          ElseIf ctl Is txOnTime Or ctl Is txOnDate Then
            ctl.Enabled = True
            ctl.BackColor = System.Drawing.SystemColors.Window
          ElseIf ctl Is opRunAt Then
          Else
            ctl.Enabled = False
            If TypeOf ctl Is System.Windows.Forms.TextBox Or TypeOf ctl Is System.Windows.Forms.ComboBox Then
              ctl.BackColor = System.Drawing.SystemColors.Control
            End If
          End If
        Next ctl

      End If

    Catch ex As Exception

      MngError(ex, "opRunAt_Click", C_Module, "")

    Finally

      opRunAt.Focus()

    End Try

  End Sub

  Private Sub opRunRecurring_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opRunRecurring.CheckedChanged
    Try

      If eventSender.Checked Then

        Dim ctl As System.Windows.Forms.Control

        For Each ctl In Controls
          If ctl Is txOnDate Or ctl Is txOnTime Then
            ctl.Enabled = False
            ctl.BackColor = System.Drawing.SystemColors.Control
          ElseIf ctl Is picSchedule Then
          ElseIf ctl Is cmdSchedule Then
          ElseIf ctl Is cmdTasks Then
          ElseIf TypeOf ctl Is System.Windows.Forms.Label Then
          ElseIf ctl Is lbName Then
          ElseIf ctl Is txName Then
          ElseIf ctl Is ImageList1 Then
          ElseIf ctl Is opRunAt Then
          Else
            ctl.Enabled = True
            If TypeOf ctl Is System.Windows.Forms.TextBox Or TypeOf ctl Is System.Windows.Forms.ComboBox Then
              ctl.BackColor = System.Drawing.SystemColors.Window
            End If
          End If
        Next ctl

        opDaily.Checked = True
        opEndDateNever.Checked = True
        opOccursEach.Checked = True

        opDaily_CheckedChanged(opDaily, New System.EventArgs())
        opEndDateNever_CheckedChanged(opEndDateNever, New System.EventArgs())
        opOccursEach_CheckedChanged(opOccursEach, New System.EventArgs())

      End If

    Catch ex As Exception

      MngError(ex, "opRunRecurring_Click", C_Module, "")

    Finally

      opRunRecurring.Focus()

    End Try
  End Sub

  Private Sub txEndDate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txEndDate.KeyPress
    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

    Try

      KeyAscii = CharacterValidForDate(KeyAscii)

    Catch ex As Exception

      MngError(ex, "txEndDate_KeyPress", C_Module, "")

    Finally

      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
        eventArgs.Handled = True
      End If

    End Try

  End Sub

  Private Sub txName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txName.TextChanged
    m_Changed = True
  End Sub

  Private Sub txOccursEach_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txOccursEach.KeyPress
    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    Try

      KeyAscii = CharacterValidForInteger(KeyAscii)

    Catch ex As Exception

      MngError(ex, "txOccursEach_KeyPress", C_Module, "")

    Finally

      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
        eventArgs.Handled = True
      End If

    End Try
  End Sub

  Private Sub txOnceAt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txOnceAt.KeyPress
    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

    Try

      KeyAscii = CharacterValidForTime(KeyAscii)


    Catch ex As Exception

      MngError(ex, "txOnceAt_KeyPress", C_Module, "")

    Finally

      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
        eventArgs.Handled = True
      End If

    End Try

  End Sub

  Private Sub txOnTime_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txOnTime.KeyPress
    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

    Try

      KeyAscii = CharacterValidForTime(KeyAscii)

    Catch ex As Exception

      MngError(ex, "txOnTime_KeyPress", C_Module, "")

    Finally

      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
        eventArgs.Handled = True
      End If

    End Try
  End Sub

  Private Sub txTimeEnd_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txTimeEnd.KeyPress
    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

    Try

      KeyAscii = CharacterValidForTime(KeyAscii)

    Catch ex As Exception

      MngError(ex, "txTimeEnd_KeyPress", C_Module, "")

    Finally

      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
        eventArgs.Handled = True
      End If

    End Try
  End Sub

  Private Sub txTimeStart_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txTimeStart.KeyPress
    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

    Try

      KeyAscii = CharacterValidForTime(KeyAscii)

    Catch ex As Exception

      MngError(ex, "txTimeStart_KeyPress", C_Module, "")

    Finally

      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
        eventArgs.Handled = True
      End If

    End Try
  End Sub

  Private Sub txOnDate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txOnDate.KeyPress
    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

    Try

      KeyAscii = CharacterValidForDate(KeyAscii)

    Catch ex As Exception

      MngError(ex, "txOnDate_KeyPress", C_Module, "")

    Finally

      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
        eventArgs.Handled = True
      End If

    End Try

  End Sub

  Private Sub txStartDate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txStartDate.KeyPress
    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

    Try

      KeyAscii = CharacterValidForDate(KeyAscii)

    Catch ex As Exception

      MngError(ex, "txStartDate_KeyPress", C_Module, "")

    Finally

      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
        eventArgs.Handled = True
      End If

    End Try
  End Sub

  Private Sub txTimeStart_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txTimeStart.Leave
    txTimeStart.Text = CheckValueTime(txTimeStart.Text)
    txTimeStart.Text = FormatTime(txTimeStart.Text)
  End Sub

  Private Sub txOnTime_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txOnTime.Leave
    txOnTime.Text = CheckValueTime(txOnTime.Text)
    txOnTime.Text = FormatTime(txOnTime.Text)
  End Sub

  Private Sub txStartDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txStartDate.Leave
    txStartDate.Text = FormatDate(txStartDate.Text)
  End Sub

  Private Sub txEndDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txEndDate.Leave
    txEndDate.Text = FormatDate(txEndDate.Text)
  End Sub

  Private Sub txOnceAt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txOnceAt.Leave
    txOnceAt.Text = CheckValueTime(txOnceAt.Text)
    txOnceAt.Text = FormatTime(txOnceAt.Text)
  End Sub

  Private Sub txOnDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txOnDate.Leave
    txOnDate.Text = FormatDate(txOnDate.Text)
  End Sub

  Private Sub txTimeEnd_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txTimeEnd.Leave
    txTimeEnd.Text = CheckValueTime(txTimeEnd.Text)
    txTimeEnd.Text = FormatTime(txTimeEnd.Text)
  End Sub

  Private Sub CollectData()
    If m_Schedule Is Nothing Then Exit Sub

    m_Schedule.Name = txName.Text

    If opRunAt.Checked Then
      m_Schedule.RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeOnce
      m_Schedule.Time = CDate(txOnDate.Text & " " & txOnTime.Text)
      Exit Sub

    ElseIf opDaily.Checked Then
      m_Schedule.RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeDaily
      m_Schedule.RunDailyInterval = CShort(txEach.Text)

    ElseIf opMonthly.Checked Then

      If opDay.Checked Then
        m_Schedule.RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeMonthly
        m_Schedule.RunMonthlyNumberDay = Val(txEach.Text)
        m_Schedule.RunMonthlyInterval = Val(txEachMonth1.Text)

      Else
        m_Schedule.RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeMonthlyRelative
        m_Schedule.RunMonthlyCardinalDay = GetItemData(cbCardinalDay)
        m_Schedule.RunMonthlyNameDay = GetItemData(cbDayName)
        m_Schedule.RunMonthlyInterval = CShort(txEachMonth2.Text)
      End If

    ElseIf opWeekly.Checked Then
      m_Schedule.RunType = cScheduleEnums.csScheduleRunType.csSchRunTypeWeekly
      m_Schedule.RunWeeklyInterval = CShort(txEach.Text)
      m_Schedule.RunSunday = chkSunday.CheckState = System.Windows.Forms.CheckState.Checked
      m_Schedule.RunMonday = chkMonday.CheckState = System.Windows.Forms.CheckState.Checked
      m_Schedule.RunTuesday = chkTuesday.CheckState = System.Windows.Forms.CheckState.Checked
      m_Schedule.RunWednesday = chkWednesday.CheckState = System.Windows.Forms.CheckState.Checked
      m_Schedule.RunThursday = chkThursday.CheckState = System.Windows.Forms.CheckState.Checked
      m_Schedule.RunFriday = chkFriday.CheckState = System.Windows.Forms.CheckState.Checked
      m_Schedule.RunSaturday = chkSaturday.CheckState = System.Windows.Forms.CheckState.Checked
    End If

    m_Schedule.TimeStart = CDate(txTimeStart.Text)
    m_Schedule.TimeEnd = CDate(txTimeEnd.Text)

    If opOnceAt.Checked Then
      m_Schedule.TimeType = cScheduleEnums.csScheduleTimeType.csSchTimeTypeAtThisTime
      m_Schedule.TimeStart = CDate(txOnceAt.Text)

    Else
      m_Schedule.TimeType = cScheduleEnums.csScheduleTimeType.csSchTimeTypeRecurring
      m_Schedule.RunEach = CShort(txOccursEach.Text)
      m_Schedule.RunEachType = GetItemData(cbTimeType)
    End If

    m_Schedule.FirtsRunStartAt = CDate(txStartDate.Text)
    If opEndDate.Checked Then
      m_Schedule.LastRunEndAt = CDate(txEndDate.Text)
    Else
      m_Schedule.LastRunEndAt = csSchEndUndefined
    End If

    Dim Item As System.Windows.Forms.ListViewItem
    Dim Task As cTask

    m_Schedule.Tasks = New Collection

    For Each Item In lvTask.Items
      If Item.Checked Then
        Task = New cTask
        Task.Name = Item.Text
        m_Schedule.Tasks.Add(Task)
      End If
    Next Item
  End Sub

  Private Function ValidateValue() As Boolean
    Try

      Dim rtn As Boolean

      If txName.Text = "" Then
        Info("Debe indicar un nombre")
        SetFocusControl(txName)
        Exit Function
      End If

      If opRunAt.Checked Then
        rtn = ValidateRunAt()
      Else
        If opDaily.Checked Then
          rtn = ValidateDaily()
        ElseIf opWeekly.Checked Then
          rtn = ValidateWeekly()
        ElseIf opMonthly.Checked Then
          rtn = ValidateMonthly()
        End If

        If Not rtn Then Exit Function

        If opOnceAt.Checked Then
          rtn = ValidateOnceAt()
        Else
          rtn = ValidateOccursEach()
        End If

        If Not rtn Then Exit Function

        rtn = ValidatePeriod()

      End If

      If Not rtn Then Exit Function

      ValidateValue = True


    Catch ex As Exception

      MngError(ex, "Validate", C_Module, "")

    End Try
  End Function

  Private Function ValidatePeriod() As Boolean
    If Not IsDate(txStartDate.Text) Then
      Info("Debe indicar la fecha de inicio para el periodo en el que estará vigente la tarea")
      SetFocusControl(txStartDate)
      Exit Function
    End If

    If opEndDate.Checked Then
      If Not IsDate(txEndDate.Text) Then
        Info("Debe indicar la fecha de fin para el periodo en el que estará vigente la tarea")
        SetFocusControl(txEndDate)
        Exit Function
      End If

      If DateValue(txEndDate.Text) < DateValue(txStartDate.Text) Then
        Info("La fecha de fin del periodo de vigencia de la tarea debe ser mayor o igual a la fecha de inicio")
        SetFocusControl(txEndDate)
        Exit Function
      End If
    End If

    ValidatePeriod = True
  End Function

  Private Function ValidateOnceAt() As Boolean
    If Not IsDate(txOnceAt.Text) Then
      Info("Debe indicar la hora a la que se ejecuta la tarea")
      SetFocusControl(txOnceAt)
      Exit Function
    End If

    ValidateOnceAt = True
  End Function

  Private Function ValidateOccursEach() As Boolean
    Dim OccursEach As Short

    If GetItemData(cbTimeType) = cScheduleEnums.csScheduleEachType.csSchEachTypeHour Then

      If Not IsNumeric(txOccursEach.Text) Then
        Info("Debe cada cuantas horas se ejecuta la tarea")
        SetFocusControl(txOccursEach)
        Exit Function
      End If

      OccursEach = CShort(txOccursEach.Text)

      If OccursEach > 12 Then
        Info("El rango para el campo 'Ocurre cada' es de 1 a 12")
        SetFocusControl(txOccursEach)
        Exit Function
      End If

    Else
      If Not IsNumeric(txOccursEach.Text) Then
        Info("Debe cada cuantos minutos se ejecuta la tarea")
        SetFocusControl(txOccursEach)
        Exit Function
      End If

      OccursEach = CShort(txOccursEach.Text)

      If OccursEach > 59 Then
        Info("El rango para el campo 'Ocurre cada' es de 1 a 59")
        SetFocusControl(txOccursEach)
        Exit Function
      End If
    End If

    If Not IsDate(txTimeStart.Text) Then
      Info("Debe indicar una hora de inicio")
      SetFocusControl(txTimeStart)
      Exit Function
    End If

    If Not IsDate(txTimeEnd.Text) Then
      Info("Debe indicar una hora de finalización")
      SetFocusControl(txTimeEnd)
      Exit Function
    End If

    If TimeValue(txTimeEnd.Text) <= TimeValue(txTimeStart.Text) Then
      Info("La hora de finalizacion de la tarea debe ser mayor a la de inicio")
      SetFocusControl(txTimeEnd)
      Exit Function
    End If

    ValidateOccursEach = True
  End Function

  Private Function ValidateRunAt() As Boolean
    Dim DateAndTimeValue As Date
    Dim Time As Date

    If Not IsDate(txOnDate.Text) Then
      Info("Debe indicar una fecha valida para la tarea")
      SetFocusControl(txOnDate)
      Exit Function
    End If

    If Not IsDate(txOnTime.Text) Then
      Info("Debe indicar una hora valida para la tarea")
      SetFocusControl(txOnTime)
      Exit Function
    End If

    DateAndTimeValue = DateValue(txOnDate.Text)
    Time = TimeValue(txOnTime.Text)
    DateAndTimeValue = DateAdd(DateInterval.Hour, Hour(Time), DateAndTimeValue)
    DateAndTimeValue = DateAdd(DateInterval.Minute, Minute(Time), DateAndTimeValue)

    If DateAndTimeValue < Today Then
      Info("La fecha de la tarea debe ser mayor a hoy")
      SetFocusControl(txOnDate)
      Exit Function
    End If

    If DateAndTimeValue < Now Then
      Info("La hora de la tarea debe ser mayor a " & FormatTime(Now))
      SetFocusControl(txOnTime)
      Exit Function
    End If

    ValidateRunAt = True
  End Function

  Private Function ValidateDaily() As Boolean
    If Not IsNumeric(txEach.Text) Then
      Info("Debe indicar el día")
      SetFocusControl(txEach)
      Exit Function
    End If

    ValidateDaily = True
  End Function

  Private Function ValidateWeekly() As Boolean
    Dim chk As Boolean

    If Not IsNumeric(txEach.Text) Then
      Info("Debe indicar el día")
      SetFocusControl(txEach)
      Exit Function
    End If

    chk = chk Or chkFriday.CheckState <> System.Windows.Forms.CheckState.Unchecked
    chk = chk Or chkMonday.CheckState <> System.Windows.Forms.CheckState.Unchecked
    chk = chk Or chkSaturday.CheckState <> System.Windows.Forms.CheckState.Unchecked
    chk = chk Or chkSunday.CheckState <> System.Windows.Forms.CheckState.Unchecked
    chk = chk Or chkTuesday.CheckState <> System.Windows.Forms.CheckState.Unchecked
    chk = chk Or chkThursday.CheckState <> System.Windows.Forms.CheckState.Unchecked
    chk = chk Or chkWednesday.CheckState <> System.Windows.Forms.CheckState.Unchecked

    If Not chk Then
      Info("Debe seleccionar al menos un dia")
      SetFocusControl(chkSunday)
      Exit Function
    End If

    ValidateWeekly = True
  End Function

  Private Function ValidateMonthly() As Boolean
    If opDay.Checked Then
      If Not IsNumeric(txEach.Text) Then
        Info("Debe indicar el día")
        SetFocusControl(txEach)
        Exit Function
      End If
      If Not IsNumeric(txEachMonth1.Text) Then
        Info("Debe indicar cada cuantos mese(s) se repite la tarea")
        SetFocusControl(txEachMonth1)
        Exit Function
      End If
    Else
      If Not IsNumeric(txEachMonth2.Text) Then
        Info("Debe indicar cada cuantos mese(s) se repite la tarea")
        SetFocusControl(txEachMonth2)
        Exit Function
      End If
    End If

    ValidateMonthly = True
  End Function

  Private Function pSave() As Boolean

    If Not ValidateValue() Then Exit Function

    CollectData()

    If m_Schedule.Save(False) Then
      m_Changed = False
      pSave = True
    End If
  End Function

  Private Sub ShowData()
    If m_Schedule Is Nothing Then Exit Sub

    txName.Text = m_Schedule.Name

    Select Case m_Schedule.RunType

      Case cScheduleEnums.csScheduleRunType.csSchRunTypeOnce
        opRunAt.Checked = True
        opRunAt_CheckedChanged(opRunAt, New System.EventArgs())
        txOnDate.Text = FormatDate(m_Schedule.Time)
        txOnTime.Text = FormatTime(m_Schedule.Time)
        Exit Sub

      Case cScheduleEnums.csScheduleRunType.csSchRunTypeDaily
        opDaily.Checked = True
        opDaily_CheckedChanged(opDaily, New System.EventArgs())
        txEach.Text = CStr(m_Schedule.RunDailyInterval)

      Case cScheduleEnums.csScheduleRunType.csSchRunTypeMonthly
        opMonthly.Checked = True
        opMonthly_CheckedChanged(opMonthly, New System.EventArgs())
        opDay.Checked = True
        opDay_CheckedChanged(opDay, New System.EventArgs())
        txEach.Text = CStr(m_Schedule.RunMonthlyNumberDay)
        txEachMonth1.Text = CStr(m_Schedule.RunMonthlyInterval)

      Case cScheduleEnums.csScheduleRunType.csSchRunTypeMonthlyRelative
        opMonthly.Checked = True
        opMonthly_CheckedChanged(opMonthly, New System.EventArgs())
        opCardinalDay.Checked = True
        opCardinalDay_CheckedChanged(opCardinalDay, New System.EventArgs())
        SelectItemByItemData(cbCardinalDay, m_Schedule.RunMonthlyCardinalDay)
        SelectItemByItemData(cbDayName, m_Schedule.RunMonthlyNameDay)
        txEachMonth2.Text = CStr(m_Schedule.RunMonthlyInterval)

      Case cScheduleEnums.csScheduleRunType.csSchRunTypeWeekly
        opWeekly.Checked = True
        opWeekly_CheckedChanged(opWeekly, New System.EventArgs())
        txEach.Text = CStr(m_Schedule.RunWeeklyInterval)
        chkSunday.CheckState = IIf(m_Schedule.RunSunday, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
        chkMonday.CheckState = IIf(m_Schedule.RunMonday, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
        chkTuesday.CheckState = IIf(m_Schedule.RunTuesday, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
        chkWednesday.CheckState = IIf(m_Schedule.RunWednesday, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
        chkThursday.CheckState = IIf(m_Schedule.RunThursday, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
        chkFriday.CheckState = IIf(m_Schedule.RunFriday, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
        chkSaturday.CheckState = IIf(m_Schedule.RunSaturday, System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
    End Select

    txTimeStart.Text = FormatTime(m_Schedule.TimeStart)
    txTimeEnd.Text = FormatTime(m_Schedule.TimeEnd)

    If m_Schedule.TimeType = cScheduleEnums.csScheduleTimeType.csSchTimeTypeAtThisTime Then
      opOnceAt.Checked = True
      opOnceAt_CheckedChanged(opOnceAt, New System.EventArgs())
      txOnceAt.Text = FormatTime(m_Schedule.TimeStart)

    ElseIf m_Schedule.TimeType = cScheduleEnums.csScheduleTimeType.csSchTimeTypeRecurring Then
      opOccursEach.Checked = True
      opOccursEach_CheckedChanged(opOccursEach, New System.EventArgs())
      txOccursEach.Text = CStr(m_Schedule.RunEach)
      SelectItemByItemData(cbTimeType, m_Schedule.RunEachType)
    End If

    txStartDate.Text = FormatDate(m_Schedule.FirtsRunStartAt)
    txEndDate.Text = FormatDate(m_Schedule.LastRunEndAt)
    If m_Schedule.LastRunEndAt <> csSchEndUndefined Then
      opEndDate.Checked = True
      opEndDate_CheckedChanged(opEndDate, New System.EventArgs())
    Else
      opEndDateNever.Checked = True
      opEndDateNever_CheckedChanged(opEndDateNever, New System.EventArgs())
    End If

  End Sub

  ' construccion - destruccion
  Private Sub fSchedule_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    Try

      Me.Height = 562
      Me.Width = 435

      opRunRecurring.Checked = True
      opRunRecurring_CheckedChanged(opRunRecurring, New System.EventArgs())

      opDaily.Checked = True
      opDaily_CheckedChanged(opDaily, New System.EventArgs())

      opOnceAt.Checked = True
      opOnceAt_CheckedChanged(opOnceAt, New System.EventArgs())

      opEndDateNever.Checked = True
      opEndDateNever_CheckedChanged(opEndDateNever, New System.EventArgs())

      txEach.Text = "1"
      txEachMonth1.Text = "1"
      txEachMonth2.Text = "1"
      txOccursEach.Text = "1"
      txStartDate.Text = FormatDate(Now)
      txOnDate.Text = FormatDate(Now)
      txOnceAt.Text = FormatTime(Now)
      txOnTime.Text = FormatTime(Now)
      txEndDate.Text = FormatDate(Now)

      txTimeStart.Text = FormatTime("06:00")
      txTimeEnd.Text = FormatTime("22:00")

      AddItemToList(cbTimeType, "Minuto(s)", cScheduleEnums.csScheduleEachType.csSchEachTypeMinute)
      AddItemToList(cbTimeType, "Hora(s)", cScheduleEnums.csScheduleEachType.csSchEachTypeHour)
      SelectItemByItemData(cbTimeType, cScheduleEnums.csScheduleEachType.csSchEachTypeHour)

      AddItemToList(cbCardinalDay, "1ro", cScheduleEnums.csScheduleRunMonthlyCardinal.csSchRunMonCard_1st)
      AddItemToList(cbCardinalDay, "2do", cScheduleEnums.csScheduleRunMonthlyCardinal.csSchRunMonCard_2nd)
      AddItemToList(cbCardinalDay, "3ro", cScheduleEnums.csScheduleRunMonthlyCardinal.csSchRunMonCard_3rd)
      AddItemToList(cbCardinalDay, "4to", cScheduleEnums.csScheduleRunMonthlyCardinal.csSchRunMonCard_4th)
      AddItemToList(cbCardinalDay, "Ultimo", cScheduleEnums.csScheduleRunMonthlyCardinal.csSchRunMonCard_Last)
      SelectItemByItemData(cbCardinalDay, cScheduleEnums.csScheduleRunMonthlyCardinal.csSchRunMonCard_1st)

      AddItemToList(cbDayName, "Domingo", cScheduleEnums.csScheduleRunMonthlyName.csSchRunMonName_Sunday)
      AddItemToList(cbDayName, "Lunes", cScheduleEnums.csScheduleRunMonthlyName.csSchRunMonName_Monday)
      AddItemToList(cbDayName, "Martes", cScheduleEnums.csScheduleRunMonthlyName.csSchRunMonName_Tuesday)
      AddItemToList(cbDayName, "Miercoles", cScheduleEnums.csScheduleRunMonthlyName.csSchRunMonName_Wednesday)
      AddItemToList(cbDayName, "Jueves", cScheduleEnums.csScheduleRunMonthlyName.csSchRunMonName_Thursday)
      AddItemToList(cbDayName, "Viernes", cScheduleEnums.csScheduleRunMonthlyName.csSchRunMonName_FriDay)
      AddItemToList(cbDayName, "Sabado", cScheduleEnums.csScheduleRunMonthlyName.csSchRunMonName_Saturday)
      SelectItemByItemData(cbDayName, cScheduleEnums.csScheduleRunMonthlyName.csSchRunMonName_Sunday)

      ShowData()

      picTask.Top = picSchedule.Top
      picTask.Left = picSchedule.Left
      picTask.Height = picSchedule.Height
      picTask.Width = picSchedule.Width

      cmdSchedule_Click(cmdSchedule, New System.EventArgs())
      lvTask.Height = picTask.ClientRectangle.Height
      lvTask.Width = picTask.ClientRectangle.Width - 7
      lvTask.Top = 0
      lvTask.Left = 0

      FormCenter(Me)

    Catch ex As Exception

      MngError(ex, "Form_Load", C_Module, "")

    End Try
  End Sub
	
	Private Sub fSchedule_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Rslt As MsgBoxResult
		
		If m_Changed Then
			Rslt = MsgBox("Desea guardar los cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
			If Rslt = MsgBoxResult.Cancel Then
				Cancel = True
			ElseIf Rslt = MsgBoxResult.Yes Then 
				If Not pSave Then
					Cancel = True
				End If
			End If
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
End Class