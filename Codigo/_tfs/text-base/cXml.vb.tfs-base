Option Strict Off
Option Explicit On

Imports System.Xml

Friend Class cXml
	
	'--------------------------------------------------------------------------------
	' cXml
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
	Private Const C_Module As String = "cXml"
	' estructuras
	' variables privadas
	Private m_Name As String
	Private m_Path As String
  Private m_DomDoc As XmlDocument
	Private m_CommDialog As Object
	Private m_Filter As String
	
	' eventos
	' propiedades publicas
	
	Public Property Name() As String
		Get
			Name = m_Name
		End Get
		Set(ByVal Value As String)
			m_Name = Value
		End Set
	End Property
	
	
	Public Property Path() As String
		Get
			If Right(m_Path, 1) = "\" Then
				Path = m_Path
			Else
				Path = m_Path & "\"
			End If
		End Get
		Set(ByVal Value As String)
			m_Path = Value
		End Set
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
  ' funciones publicas
  Public Sub Init(ByRef CommDialog As Object)
    m_CommDialog = CommDialog
  End Sub

  Public Function OpenXmlWithDialog() As Boolean
    Try

      Dim File As cFile

      File = New cFile

      File.FileFilter = m_Filter

      File.Init("OpenXmlWithDialog", C_Module, m_CommDialog)

      If Not File.FOpen(m_Name, cFile.csFile.csRead, False, False, cFile.csFileAcces.csLockReadWrite, True, True) Then Exit Function

      m_Name = File.Name
      m_Path = File.Path

      File = Nothing

      OpenXmlWithDialog = OpenXml(False)

    Catch ex As Exception

      MngError(ex, "OpenXmlWithDialog", C_Module, "Error al abrir el archivo " & m_Name)

    End Try
  End Function

  Public Function OpenXml(ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean

    Dim File As String

    Try

      m_DomDoc = Nothing
      m_DomDoc = New XmlDocument

      'm_DomDoc.async = False

      File = Path & m_Name

      Dim FileEx As cFileEx
      FileEx = New cFileEx

      If FileEx.FileExists(File) Then

        Try

          m_DomDoc.Load(File)

        Catch ex As Exception

          strError = "No se pudo cargar el archivo.;;" & File & ";;Error: " & ex.Message

          If Not bSilent Then
            MsgWarning(strError)
          End If

          Exit Function

        End Try

      Else

        strError = "El archivo;;" & File & ";;no existe."

        If Not bSilent Then
          MsgWarning(strError)
        End If

        Exit Function

      End If

    Catch ex As Exception

      strError = "Error al cargar el archivo " & m_Name

      If Not bSilent Then
        MngError(Ex, "OpenXml", C_Module, strError)
      End If

    End Try

    OpenXml = True

  End Function

  Public Function NewXmlWithDialog() As Boolean
    Try

      Dim File As cFile = New cFile
      Dim msg As String = ""

      File.Init("NewXmlWithDialog", C_Module, m_CommDialog)
      File.FileFilter = m_Filter

      Dim bExiste As Boolean
      Dim bReadOnly As Boolean

      If Not File.FSave(m_Name, bExiste, bReadOnly) Then Exit Function

      If bExiste And bReadOnly Then
        msg = "El archivo ya existe y es de solo lectura. ¿Desea reemplazarlo?"
      ElseIf bExiste Then
        If m_Name <> File.Name Then
          msg = "El archivo ya existe. ¿Desea reemplazarlo?"
        End If
      End If

      If msg <> "" Then
        If Not Ask(msg, MsgBoxResult.No, "Guardando") Then Exit Function
      End If

      m_Name = File.Name
      m_Path = File.Path

      File = Nothing

      NewXmlWithDialog = NewXml()

    Catch ex As Exception

      MngError(ex, "NewXmlWithDialog", C_Module, "Error al crear el archivo " & m_Name)

    End Try
  End Function

  Public Function NewXml() As Boolean
    Try

      m_DomDoc = Nothing
      m_DomDoc = New XmlDocument

      Dim Node As XmlNode

      Node = m_DomDoc.CreateNode(XmlNodeType.Element, "Root", "")

      m_DomDoc.AppendChild(Node)

      NewXml = True

    Catch ex As Exception

      MngError(ex, "NewXml", C_Module, "Error al crear el archivo " & m_Name)

    End Try
  End Function

  Public Function SaveWithDialog() As Boolean
    Try

      Dim File As cFile

      File = New cFile

      If Not File.FOpen(m_Name, cFile.csFile.csWrite, False, False, cFile.csFileAcces.csLockWrite) Then Exit Function

      m_Name = File.Name
      m_Path = File.Path

      File = Nothing

      SaveWithDialog = Save(False)

    Catch ex As Exception

      MngError(ex, "SaveWithDialog", C_Module, "Error al guardar el archivo " & m_Name)

    End Try
  End Function

  Public Sub SetNodeText(ByRef Node As XmlElement, ByVal Text As String)
    Node.Value = Text
  End Sub

  Public Function Save(ByVal bSilent As Boolean, Optional ByRef strError As String = "") As Boolean
    Try

      m_DomDoc.Save(Path & m_Name)

      Save = True

    Catch ex As Exception

      strError = "Error al guardar el archivo " & m_Name & vbCrLf & vbCrLf & ex.Message
      If Not bSilent Then
        MngError(ex, "Save", C_Module, strError)
      End If

    End Try
  End Function
	
	Public Function AddProperty(ByRef xProperty As cXmlProperty) As Boolean
		AddPropertyToNodeByTag("Root", xProperty)
	End Function
	
	Public Function AddPropertyToNodeByTag(ByVal NodeTag As String, ByRef xProperty As cXmlProperty) As Boolean
		With m_DomDoc.getElementsByTagName(NodeTag)
      AddPropertyToNodeByTag = AddPropertyToNode(.item(0), xProperty)
		End With
	End Function
	
  Public Function AddPropertyToNode(ByRef Node As XmlElement, ByRef xProperty As cXmlProperty) As Boolean
    Dim Attr As XmlAttribute

    Attr = m_DomDoc.CreateAttribute(xProperty.Name)
    Attr.value = xProperty.Value(mPublic.csTypes.csVariant)

    Node.setAttributeNode(Attr)

    AddPropertyToNode = True
  End Function
	
  Public Function AddBinaryPropertyToNode(ByRef Node As XmlElement, ByRef xProperty As cXmlProperty) As Boolean
    Dim Attr As XmlAttribute

    Attr = m_DomDoc.CreateAttribute(xProperty.Name)

    Attr.Value = System.Convert.ToBase64String(xProperty.BinaryValue)

    Node.SetAttributeNode(Attr)

    AddBinaryPropertyToNode = True
  End Function
	
  Public Function AddNode(ByRef xProperty As cXmlProperty) As XmlElement
    AddNode = AddNodeToNodeByTag("Root", xProperty)
  End Function
	
  Public Function AddNodeToNodeByTag(ByVal NodeTag As String, ByRef xProperty As cXmlProperty) As XmlElement
    With m_DomDoc.GetElementsByTagName(NodeTag)
      AddNodeToNodeByTag = AddNodeToNode(.Item(0), xProperty)
    End With

  End Function
	
  Public Function AddNodeToNode(ByRef NodeFather As XmlElement, ByRef xProperty As cXmlProperty) As XmlElement
    Dim Node As XmlElement

    Node = m_DomDoc.CreateNode(XmlNodeType.Element, xProperty.Name, "")
    NodeFather.appendChild(Node)

    AddNodeToNode = Node
  End Function
	
  Public Function GetRootNode() As XmlElement
    If m_DomDoc.GetElementsByTagName("Root").Count > 0 Then
      GetRootNode = m_DomDoc.GetElementsByTagName("Root").Item(0)
    Else
      GetRootNode = Nothing
    End If
  End Function
	
  Public Function GetNode(ByVal NodeTag As String) As XmlElement
    If m_DomDoc.GetElementsByTagName(NodeTag).Count > 0 Then
      GetNode = m_DomDoc.GetElementsByTagName(NodeTag).Item(0)
    Else
      GetNode = Nothing
    End If
  End Function
	
  Public Function GetNodeFromNode(ByRef Node As XmlElement, ByVal NodeTag As String) As XmlElement
    If Node.GetElementsByTagName(NodeTag).Count > 0 Then
      GetNodeFromNode = Node.GetElementsByTagName(NodeTag).Item(0)
    Else
      GetNodeFromNode = Nothing
    End If
  End Function
	
  Public Function GetNodeFromNode2(ByRef Node As XmlElement, ByVal NodeTag As String) As XmlElement
    Dim rtn As XmlElement = Nothing
    Dim Child As XmlElement

    If Node Is Nothing Then
      GetNodeFromNode2 = Nothing
      Exit Function
    End If

    If NodeHasChild(Node) Then
      Child = Node.firstChild

      Do While Not Child Is Nothing
        If Child.Name = NodeTag Then
          rtn = Child
          Exit Do
        End If
        Child = Child.nextSibling
      Loop
    End If

    GetNodeFromNode2 = rtn
  End Function
	
  Public Function GetNodeChild(ByRef Node As XmlElement) As XmlElement
    If NodeHasChild(Node) Then
      GetNodeChild = Node.childNodes(0)
    Else
      GetNodeChild = Nothing
    End If
  End Function
	
  Public Function GetNextNode(ByRef Node As XmlElement) As XmlElement
    GetNextNode = Node.nextSibling
  End Function
	
  Public Function GetNodeValue(ByRef Node As XmlElement) As cXmlProperty
    Dim o As cXmlProperty
    o = New cXmlProperty
    o.Value(mPublic.csTypes.csText) = Node.Name
    GetNodeValue = o
  End Function
	
  Public Function GetNodeProperty(ByRef Node As XmlElement, ByVal PropertyName As String) As cXmlProperty
    Dim o As cXmlProperty
    o = New cXmlProperty
    Dim txt As String = ""

    If Not IsDBNull(Node.getAttribute(PropertyName)) Then
      txt = Node.getAttribute(PropertyName)
    End If

    txt = Replace(txt, vbLf, vbCrLf)
    o.Value(mPublic.csTypes.csVariant) = txt
    GetNodeProperty = o
  End Function
	
  Public Function GetBinaryNodeProperty(ByRef Node As XmlElement, ByVal PropertyName As String) As cXmlProperty
    Dim Attr As XmlAttribute
    Dim o As cXmlProperty
    Dim vBuffer() As Byte

    o = New cXmlProperty
    Attr = Node.GetAttributeNode(PropertyName)
    If Not Attr Is Nothing Then
      vBuffer = System.Convert.FromBase64String(Attr.Value)
    Else
      ReDim vBuffer(0)
    End If

    Array.Copy(vBuffer, o.BinaryValue, vBuffer.Length)
    GetBinaryNodeProperty = o
  End Function
	
  Public Function NodeHasChild(ByRef Node As XmlElement) As Boolean
    NodeHasChild = Node.ChildNodes.Count > 0
  End Function
	' funciones privadas
	' construccion - destruccion
  Private Sub ClassInitialize()
    m_DomDoc = New XmlDocument
  End Sub

  Public Sub New()
    MyBase.New()
    ClassInitialize()
  End Sub
	
  Private Sub ClassTerminate()
    m_DomDoc = Nothing
    m_CommDialog = Nothing
  End Sub
  Protected Overrides Sub Finalize()
    ClassTerminate()
    MyBase.Finalize()
  End Sub
End Class