Option Strict Off
Option Explicit On

Imports System.Data
Imports system.Data.OleDb

Friend Class cConnection

  '--------------------------------------------------------------------------------
  ' cConection
  ' 15-05-2002

  '--------------------------------------------------------------------------------
  ' notas:
  ' Proposito:   Contiene una conexion con un servidor sql

  '--------------------------------------------------------------------------------
  ' api win32
  ' constantes
  ' estructuras
  ' funciones

  '--------------------------------------------------------------------------------

  ' constantes
  Private Const C_Module As String = "cConection"
  ' estructuras
  ' variables privadas
  Private m_Server As OleDbConnection
  Private m_Connected As Boolean
  ' eventos
  ' propiedades publicas
  Public ReadOnly Property Server() As OleDbConnection
    Get
      Server = m_Server
    End Get
  End Property

  Public ReadOnly Property Connected() As Boolean
    Get
      Connected = m_Connected
    End Get
  End Property

  Public ReadOnly Property ServerName() As String
    Get

      ServerName = ""
      Try

        If Not m_Connected Then Exit Property
        If m_Server Is Nothing Then Exit Property

        ServerName = m_Server.DataSource

      Catch ex As Exception

        MngError(ex, "ServerName", C_Module, "")

      End Try
    End Get
  End Property

  ' propiedades privadas
  ' funciones publicas
  Public Function Execute(ByVal sqlstmt As String, ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean
    Try

      Dim sqlCommand As OleDbCommand
      sqlCommand = m_Server.CreateCommand()
      sqlCommand.CommandText = sqlstmt
      sqlCommand.ExecuteNonQuery()

      Execute = True

    Catch ex As Exception

      strError = ex.Message
      MngError(ex, "Execute", C_Module, "")

      Execute = False

    End Try
  End Function

  Public Function OpenConnectionEx(ByVal ServerName As String, ByVal User As String, ByVal Password As String, ByVal UseTrusted As Boolean, ByVal DataBase As String, ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean
    OpenConnectionEx = pOpenConnection(ServerName, User, Password, UseTrusted, True, DataBase, bSilent, strError)
  End Function

  Private Function pOpenConnection(ByVal ServerName As String, ByVal User As String, ByVal Password As String, ByVal UseTrusted As Boolean, ByVal bDontShowError As Boolean, ByVal DataBase As String, ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean
    Try

      If m_Server Is Nothing Then m_Server = New OleDbConnection

      CloseConnection()

      Dim strConnect As Object

      If UseTrusted Then
        strConnect = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=@@user@@;Initial Catalog=@@database@@;Data Source=@@SERVER@@"
      Else
        strConnect = "Provider=SQLOLEDB.1;Password=@@password@@;Persist Security Info=True;User ID=@@user@@;Initial Catalog=@@database@@;Data Source=@@SERVER@@"
      End If

      strConnect = Replace(strConnect, "@@SERVER@@", ServerName)
      strConnect = Replace(strConnect, "@@user@@", User)
      strConnect = Replace(strConnect, "@@password@@", Password)
      strConnect = Replace(strConnect, "@@database@@", DataBase)

      m_Server.ConnectionString = strConnect
      m_Server.Open()

      m_Connected = True
      pOpenConnection = True

    Catch ex As Exception

      strError = ex.Message
      If Not bSilent Then
        MngError(ex, "OpenConnection", C_Module, "")
      End If
    End Try
  End Function

  Public Function CloseConnection() As Boolean
    Try

      If m_Connected Then

        If Not m_Server Is Nothing Then

          If m_Server.State <> ConnectionState.Closed Then

            Try
              m_Server.Close()
            Catch
            End Try

          End If
        End If

        m_Connected = False

      End If

      CloseConnection = True

    Catch ex As Exception

      MngError(ex, "CloseConnection", C_Module, "")

    End Try
  End Function

  Public Function ListDataBases() As Object
    Try

      Dim coll As Collection
      coll = New Collection

      Dim sqlstmt As String
      Dim rs As DataSet
      Dim da As OleDbDataAdapter

      sqlstmt = "sp_databases"

      da = New OleDbDataAdapter(sqlstmt, m_Server)
      rs = New DataSet()
      da.Fill(rs, "table1")

      Dim dr As DataRow
      For Each dr In rs.Tables(0).Rows

        coll.Add(dr.Item("database_name").ToString)

      Next
      ListDataBases = coll

    Catch ex As Exception

      MngError(ex, "ListDataBases", C_Module, "")
      ListDataBases = Nothing

    End Try
  End Function

  Public Function GetSQLRootPath(ByVal DbName As String) As String

    Dim sqlstmt As String
    Dim rs As DataSet
    Dim da As OleDbDataAdapter

    sqlstmt = "sp_helpdb '" & Replace(DbName, "'", "''") & "'"

    da = New OleDbDataAdapter(sqlstmt, m_Server)
    rs = New DataSet()
    da.Fill(rs, "table1")

    Dim dr As DataRow
    dr = rs.Tables(1).Rows.Item(0)

    Dim i As Long
    Dim rtn As String

    rtn = dr.Item("filename").ToString

    Dim n As Integer

    For i = rtn.Length - 1 To 0 Step -1
      If rtn.Substring(i, 1) = "\" Then
        If n = 0 Then
          n = 1
        Else
          Exit For
        End If
      End If
    Next

    GetSQLRootPath = rtn.Substring(0, i)

  End Function

  ' funciones friend
  ' funciones privadas
  ' construccion - destruccion
  Private Sub ClassInitialize()
    Try

      m_Server = New OleDbConnection

    Catch ex As Exception

      MngError(ex, "ClassInitialize", C_Module, "")

    End Try
  End Sub

  Public Sub New()
    MyBase.New()
    ClassInitialize()
  End Sub

  Private Sub ClassTerminate()
    Try

      CloseConnection()
      m_Server = Nothing

    Catch ex As Exception

      MngError(ex, "ClassTerminate", C_Module, "")

    End Try
  End Sub
  Protected Overrides Sub Finalize()
    ClassTerminate()
    MyBase.Finalize()
  End Sub
End Class