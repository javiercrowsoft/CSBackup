Option Strict Off
Option Explicit On

Friend Class fSQLLogin
  Inherits System.Windows.Forms.Form

  '--------------------------------------------------------------------------------
  ' fSQLLogin
  ' 07-10-2007

  '--------------------------------------------------------------------------------
  ' notas:

  '--------------------------------------------------------------------------------
  ' api win32
  ' constantes
  ' estructuras
  ' funciones

  '--------------------------------------------------------------------------------

  ' constantes
  Private Const C_Module As String = "fSQLLogin"

  ' estructuras
  ' variables privadas
  Private m_Ok As Boolean

  Private m_vUsers() As String
  Private m_vSecurityType() As String

  ' eventos
  Public Event Connect(ByRef Cancel As Boolean)
  ' propiedadades publicas
  Public Property Ok() As Boolean
    Get
      Ok = m_Ok
    End Get
    Set(ByVal Value As Boolean)
      m_Ok = Value
    End Set
  End Property

  ' propiedadades friend
  ' propiedades privadas
  ' funciones publicas
  Public Sub SetLogin(ByVal Server As String, ByVal User As String, ByVal Pwd As String, ByVal SecurityType As mAux.csSQLSecurityType)

    Dim i As Integer

    If Not ExistsItemByText(cbServer, Server) Then

      ReDim Preserve m_vUsers(UBound(m_vUsers) + 1)
      ReDim Preserve m_vSecurityType(UBound(m_vSecurityType) + 1)

      m_vUsers(UBound(m_vUsers)) = User
      m_vSecurityType(UBound(m_vSecurityType)) = CStr(SecurityType)

      AddItemToList(cbServer, Server, UBound(m_vUsers))

    Else

      For i = 0 To cbServer.Items.Count - 1
        If GetItemString(cbServer, i) = Server Then
          m_vUsers(i) = User
          m_vSecurityType(i) = CStr(SecurityType)
          Exit For
        End If
      Next
    End If

    SelectItemByText(cbServer, Server)

    txPassword.Text = Pwd

  End Sub

  ' funciones friend
  ' funciones privadas
  Private Sub cmdConnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConnect.Click
    Try

      Dim Cancel As Boolean
      RaiseEvent Connect(Cancel)

      If Cancel Then Exit Sub

      SaveLoginToIni()

      m_Ok = True
      Me.Hide()

    Catch ex As Exception

      MngError(ex, "cmdConnect_Click", C_Module, "")

    End Try
  End Sub

  Private Sub cbServer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbServer.SelectedIndexChanged
    Try

      Dim i As Short

      i = cbServer.SelectedIndex

      If i >= 0 Then

        Select Case Val(m_vSecurityType(i))
          Case mAux.csSQLSecurityType.csTSNT
            opNt.Checked = True
          Case mAux.csSQLSecurityType.csTSSQL
            opSQL.Checked = True
        End Select

        If UBound(m_vUsers) < i Then Exit Sub

        txUser.Text = m_vUsers(i)
      End If

    Catch ex As Exception

    End Try
  End Sub

  Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
    Try

      m_Ok = False
      Me.Hide()

    Catch ex As Exception

    End Try
  End Sub

  Private Sub opNt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opNt.CheckedChanged
    Try
      If eventSender.Checked Then
        If opNt.Checked Then
          txPassword.Enabled = False
          txUser.Enabled = False
          txPassword.BackColor = System.Drawing.SystemColors.Control
          txUser.BackColor = System.Drawing.SystemColors.Control
        End If
      End If

    Catch ex As Exception

    End Try
  End Sub

  Private Sub opSQL_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opSQL.CheckedChanged
    Try

      If eventSender.Checked Then

        If opSQL.Checked Then
          txPassword.Enabled = True
          txUser.Enabled = True

          txPassword.BackColor = System.Drawing.SystemColors.Window
          txUser.BackColor = System.Drawing.SystemColors.Window
        End If
      End If

    Catch ex As Exception

    End Try
  End Sub

  Private Sub LoadLoginFromIni()
    Dim Servers As String = ""
    Dim Users As String = ""
    Dim TypeS As String = ""
    Dim LastServer As String = ""

    GetMainIniLogin(Servers, Users, TypeS, LastServer)

    Dim vServers() As String

    vServers = Split(Servers, ",")
    m_vUsers = Split(Users, ",")
    m_vSecurityType = Split(TypeS, ",")

    Dim i As Short

    For i = 0 To UBound(vServers)
      If Not ExistsItemByText(cbServer, vServers(i)) Then
        AddItemToList(cbServer, vServers(i), i)
      End If
    Next

    SelectItemByText(cbServer, LastServer)
  End Sub

  Private Sub SaveLoginToIni()
    Dim Servers As String
    Dim Users As String
    Dim TypeS As String
    Dim vServers() As String
    Dim i As Short

    If cbServer.Text = "" Then Exit Sub

    If cbServer.Items.Count > 0 Then

      ReDim Preserve vServers(cbServer.Items.Count - 1)

      For i = 0 To cbServer.Items.Count - 1
        vServers(i) = GetItemString(cbServer, i)
      Next

      If cbServer.SelectedIndex = -1 Then

        ReDim Preserve vServers(cbServer.Items.Count)
        vServers(cbServer.Items.Count) = cbServer.Text
        i = UBound(vServers)
        ReDim Preserve m_vUsers(i)
        ReDim Preserve m_vSecurityType(i)

      Else

        i = cbServer.SelectedIndex

      End If

    Else

      ReDim vServers(0)

    End If

    If UBound(m_vUsers) < i Then
      ReDim Preserve m_vUsers(i)
    End If

    m_vUsers(i) = txUser.Text

    If opNt.Checked Then
      m_vSecurityType(i) = CStr(mAux.csSQLSecurityType.csTSNT)
    Else
      m_vSecurityType(i) = CStr(mAux.csSQLSecurityType.csTSSQL)
    End If

    Servers = Join(vServers, ",")
    Users = Join(m_vUsers, ",")
    TypeS = Join(m_vSecurityType, ",")

    SaveMainIniLogin(Servers, Users, TypeS, (cbServer.Text))
  End Sub

  ' construccion - destruccion
  Private Sub fSQLLogin_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    Try

      opNt.Checked = True
      txPassword.Text = ""

      LoadLoginFromIni()

      FormCenter(Me)

    Catch ex As Exception

      MngError(ex, "Form_Load", C_Module, "")

    End Try
  End Sub

  Private Sub fSQLLogin_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Try

      Dim Cancel As Boolean = eventArgs.Cancel
      Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
      If UnloadMode <> CloseReason.FormOwnerClosing And UnloadMode <> CloseReason.None Then
        cmdCancel_Click(cmdCancel, New System.EventArgs())
      End If
      eventArgs.Cancel = Cancel

    Catch ex As Exception

    End Try
  End Sub
End Class