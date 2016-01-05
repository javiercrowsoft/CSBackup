Option Strict Off
Option Explicit On

Class cListItem

  Private m_id As Long
  Private m_value As String

  Public Property Id() As Integer
    Get
      Id = m_id
    End Get
    Set(ByVal value As Integer)
      m_id = value
    End Set
  End Property

  Public Property Value() As String
    Get
      Value = m_value
    End Get
    Set(ByVal value As String)
      m_value = value
    End Set
  End Property

End Class

Module mAux

	Public Enum csSQLSecurityType
		csTSNT = 1
		csTSSQL = 2
	End Enum
	
  Public Const csSchEndUndefined As Date = #12/31/9999#

  Public Function CharacterValidForDate(ByVal KeyAscii As Short) As Short
    Select Case KeyAscii
      Case System.Windows.Forms.Keys.D0, System.Windows.Forms.Keys.D1, System.Windows.Forms.Keys.D2, System.Windows.Forms.Keys.D3, System.Windows.Forms.Keys.D4, System.Windows.Forms.Keys.D5, System.Windows.Forms.Keys.D6, System.Windows.Forms.Keys.D7, System.Windows.Forms.Keys.D8, System.Windows.Forms.Keys.D9, System.Windows.Forms.Keys.Back
        CharacterValidForDate = KeyAscii
      Case System.Windows.Forms.Keys.Divide, System.Windows.Forms.Keys.Decimal, System.Windows.Forms.Keys.Subtract, 47, 46, 45
        CharacterValidForDate = 47 ' 47 = /
      Case Else
        CharacterValidForDate = 0
    End Select
  End Function

  Public Function CharacterValidForInteger(ByVal KeyAscii As Short) As Short
    Select Case KeyAscii
      Case System.Windows.Forms.Keys.D0, System.Windows.Forms.Keys.D1, System.Windows.Forms.Keys.D2, System.Windows.Forms.Keys.D3, System.Windows.Forms.Keys.D4, System.Windows.Forms.Keys.D5, System.Windows.Forms.Keys.D6, System.Windows.Forms.Keys.D7, System.Windows.Forms.Keys.D8, System.Windows.Forms.Keys.D9, System.Windows.Forms.Keys.Back
        CharacterValidForInteger = KeyAscii
      Case Else
        CharacterValidForInteger = 0
    End Select
  End Function

  Public Function CharacterValidForTime(ByVal KeyAscii As Short) As Short
    Select Case KeyAscii
      Case System.Windows.Forms.Keys.D0, System.Windows.Forms.Keys.D1, System.Windows.Forms.Keys.D2, System.Windows.Forms.Keys.D3, System.Windows.Forms.Keys.D4, System.Windows.Forms.Keys.D5, System.Windows.Forms.Keys.D6, System.Windows.Forms.Keys.D7, System.Windows.Forms.Keys.D8, System.Windows.Forms.Keys.D9, System.Windows.Forms.Keys.Back
        CharacterValidForTime = KeyAscii
      Case 46, 45, 58
        CharacterValidForTime = 58 ' 58 = :
      Case Else
        CharacterValidForTime = 0
    End Select
  End Function

  Public Function CheckValueTime(ByVal Time As String) As String

    If Not IsNumeric(Time) And Not IsDate(Time) Then
      CheckValueTime = ""
      Exit Function
    End If

    If InStr(1, Time, ":") = 0 Then
      Time = Time & ":00"
    End If

    CheckValueTime = Time
  End Function

  Public Function FormatDate(ByVal varDate As Object) As String
    If TypeOf varDate Is System.DateTime Then
      varDate = varDate.ToShortDateString()
    End If
    FormatDate = String.Format("{0:dd/mm/yyyy}", varDate)
  End Function

  Public Function FormatTime(ByVal varDate As Object, Optional ByVal withSeconds As Boolean = False) As String
    If IsNothing(withSeconds) Then
      FormatTime = String.Format("{0:hh:mm}", varDate)
    ElseIf withSeconds Then
      FormatTime = String.Format("{0:hh:mm:ss}", varDate)
    Else
      FormatTime = String.Format("{0:hh:mm}", varDate)
    End If
  End Function

  Public Function GetItemString(ByRef cbList As Object, ByVal i As Integer) As String
    Dim item As cListItem
    item = DirectCast(cbList.Items.Item(i), cListItem)
    GetItemString = item.Value
  End Function

  Public Function GetItemData(ByRef cbList As Object, Optional ByVal i As Integer = -1) As Integer
    Dim item As cListItem

    If i = -1 Then

      i = cbList.SelectedIndex

    End If

    If i = -1 Then

      GetItemData = 0

    Else

      item = DirectCast(cbList.Items.Item(i), cListItem)
      GetItemData = item.Id

    End If
  End Function

  Public Function SelectItemByItemData(ByRef cbList As Object, ByVal ItemData As Short) As Integer
    Dim i As Integer

    SelectItemByItemData = -1

    For i = 0 To cbList.Items.Count - 1

      If GetItemData(cbList, i) = ItemData Then

        cbList.SelectedIndex = i
        SelectItemByItemData = i
        Exit For
      End If
    Next
  End Function

  Public Function SelectItemByText(ByRef cbList As Object, ByVal Text As String) As Integer
    Dim i As Integer

    SelectItemByText = -1

    For i = 0 To cbList.items.Count - 1
      If GetItemString(cbList, i) = Text Then
        cbList.SelectedIndex = i
        SelectItemByText = i
        Exit For
      End If
    Next
  End Function

  Public Function AddItemToList(ByRef cbList As Object, _
                                ByVal Text As String, _
                                Optional ByVal ItemData As Integer = 0) As Integer

    Dim Item As cListItem = New cListItem
    Dim NewIndex As Integer

    Item.Value = Text
    Item.Id = ItemData

    cbList.DisplayMember = "Value"
    NewIndex = cbList.Items.Add(Item)

    AddItemToList = NewIndex
  End Function

  Public Sub FormCenter(ByRef f As System.Windows.Forms.Form)
    With System.Windows.Forms.Screen.PrimaryScreen.Bounds
      f.SetBounds((.Width - f.Width) * 0.5, _
                  (.Height - f.Height) * 0.5, _
                  0, 0, _
                  Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
    End With
  End Sub

  Public Sub Info(ByVal msg As String)
    MsgBox(msg, MsgBoxStyle.Information)
  End Sub

  Public Sub SetFocusControl(ByRef ctl As Object)
    Try

      ctl.Focus()

    Catch ex As Exception

    End Try
  End Sub

  ' XML
  Public Function pGetChildNodeProperty(ByRef Root As Object, ByRef DocXml As cXml, ByVal NodeName As String, ByVal PropertyName As String, Optional ByVal csType As mPublic.csTypes = mPublic.csTypes.csText) As Object
    Dim Node As Object
    Dim Prop As Object

    Node = DocXml.GetNodeFromNode(Root, NodeName)

    If Not Node Is Nothing Then
      Prop = DocXml.GetNodeProperty(Node, PropertyName)

      If Not Prop Is Nothing Then
        pGetChildNodeProperty = Prop.Value(csType)
        Exit Function
      End If

    End If

    Dim EmptyDate As Date

    Select Case csType
      Case mPublic.csTypes.csInteger
        pGetChildNodeProperty = 0
      Case mPublic.csTypes.csDouble
        pGetChildNodeProperty = 0
      Case mPublic.csTypes.csCurrency
        pGetChildNodeProperty = 0
      Case mPublic.csTypes.csText
        pGetChildNodeProperty = ""
      Case mPublic.csTypes.csId
        pGetChildNodeProperty = 0
      Case mPublic.csTypes.csCuit
        pGetChildNodeProperty = ""
      Case mPublic.csTypes.csBoolean
        pGetChildNodeProperty = False
      Case mPublic.csTypes.csSingle
        pGetChildNodeProperty = 0
      Case mPublic.csTypes.csVariant
        pGetChildNodeProperty = Nothing
      Case mPublic.csTypes.csLong
        pGetChildNodeProperty = 0
      Case mPublic.csTypes.csDate
        pGetChildNodeProperty = EmptyDate
      Case mPublic.csTypes.csDateOrNull
        pGetChildNodeProperty = EmptyDate
      Case Else
        pGetChildNodeProperty = Nothing
    End Select

  End Function

  Public Function pAddTag(ByRef xml As cXml, ByRef NodeFather As Object, ByVal TagName As String, ByVal Value As String) As Object


    Dim Prop As cXmlProperty
    Dim Node As Object

    Prop = New cXmlProperty

    Prop.Name = TagName
    Node = xml.AddNodeToNode(NodeFather, Prop)

    Prop = New cXmlProperty
    Prop.Name = "Value"
    Prop.Value(mPublic.csTypes.csText) = Value
    xml.AddPropertyToNode(Node, Prop)

    pAddTag = Node

  End Function

  Public Function ExistsItemByText(ByRef cbList As Object, ByVal Text As String) As Boolean
    Dim i As Short

    ExistsItemByText = False

    For i = 0 To cbList.Items.Count - 1

      If GetItemString(cbList, i) = Text Then
        ExistsItemByText = True
        Exit For
      End If
    Next
  End Function

  Public Function DivideByZero(ByVal x As Double, ByVal y As Double) As Double
    If y = 0 Then
      DivideByZero = 0
    Else
      DivideByZero = x / y
    End If
  End Function
End Module