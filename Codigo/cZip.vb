Option Strict Off
Option Explicit On
Friend Class cZip
	
  Public Event Progress(ByVal lCount As Integer, ByVal sMsg As String)
  Public Event UpdateProgress(ByVal lCount As Integer, ByVal sMsg As String)

  Private m_sFileName As String
	Private m_sFileSpecs() As String
	Private m_iCount As Integer
  Private m_Result As Boolean
  Private m_password As String
  Private m_cancel As Boolean

  Public Property Password() As String
    Get
      Password = m_password
    End Get
    Set(ByVal value As String)
      m_password = value
    End Set
  End Property
	
	Public Property ZipFile() As String
		Get
			ZipFile = m_sFileName
		End Get
		Set(ByVal Value As String)
			m_sFileName = Value
		End Set
  End Property

  Public Property Cancel() As Boolean
    Get
      Cancel = m_cancel
    End Get
    Set(ByVal value As Boolean)
      m_cancel = value
    End Set
  End Property

  Public ReadOnly Property FileSpecCount() As Integer
    Get
      FileSpecCount = m_iCount
    End Get
  End Property
	Public ReadOnly Property FileSpec(ByVal nIndex As Integer) As Object
		Get
			FileSpec = m_sFileSpecs(nIndex)
		End Get
	End Property
  Public ReadOnly Property Success() As Boolean
    Get
      Success = m_Result
    End Get
  End Property
	
	Friend Sub ProgressReport(ByVal sMsg As String)
		RaiseEvent Progress(1, sMsg)
	End Sub

  Friend Sub UpdateProgressReport(ByVal sMsg As String)
    RaiseEvent UpdateProgress(1, sMsg)
  End Sub

  Public Sub ClearFileSpecs()
    m_iCount = 0
    Erase m_sFileSpecs
  End Sub

  Public Function AddFileSpec(ByVal sSpec As String) As Integer
    ReDim Preserve m_sFileSpecs(m_iCount)
    m_sFileSpecs(m_iCount) = sSpec
    m_iCount = m_iCount + 1
  End Function

  Public Sub Zip()
    m_Result = False
    m_cancel = False
    m_Result = mZip.ZipFiles(Me, m_sFileSpecs)
  End Sub
End Class