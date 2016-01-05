Option Strict Off
Option Explicit On
Friend Class cXmlProperty
	
	'--------------------------------------------------------------------------------
	' cXmlProperty
	' 25-01-06
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes
	' estructuras
	' funciones

	'--------------------------------------------------------------------------------
	
	' constantes
	Private Const C_Module As String = "cXmlProperty"
	' estructuras
	' variables privadas
	Private m_Name As String
	Private m_Value As String
	Private m_Parent As String
	Private m_BinaryValue As Object
	
	' eventos
	' propiedades publicas
	
	Public Property BinaryValue() As Object
		Get
      BinaryValue = m_BinaryValue
		End Get
		Set(ByVal Value As Object)
			Dim vBytes() As Byte
			Dim vSource() As Byte
			
			If IsNothing(Value) Then
        m_BinaryValue = Nothing
			Else
				If Not pIsNullArray(Value) Then
					ReDim vBytes(UBound(Value))
					vSource = Value
          Array.Copy(vSource, vBytes, UBound(vSource) + 1)
				Else
					ReDim vBytes(0)
				End If
        Array.Copy(vBytes, m_BinaryValue, vBytes.Length)
			End If
		End Set
	End Property
	
	
	Public Property Name() As String
		Get
			Name = m_Name
		End Get
		Set(ByVal Value As String)
			m_Name = Value
		End Set
	End Property
	
	
	Public Property Value(ByVal ValType As mPublic.csTypes) As Object
		Get
			Select Case ValType
				Case mPublic.csTypes.csBoolean
					Select Case m_Value
						Case "True", "Verdadero"
              Value = -1
						Case "False", "Falso"
              Value = 0
						Case Else
							If IsNumeric(m_Value) Then
                Value = CBool(m_Value)
							Else
                Value = 0
							End If
					End Select
				Case mPublic.csTypes.csDate, mPublic.csTypes.csDateOrNull, mPublic.csTypes.csDouble
					If IsDate(m_Value) Then
            Value = m_Value
					Else
            Value = #1/1/1900#
					End If
				Case mPublic.csTypes.csLong, mPublic.csTypes.csInteger, mPublic.csTypes.csId, mPublic.csTypes.csSingle, mPublic.csTypes.csCurrency
					If IsNumeric(m_Value) Then
            Value = m_Value
					Else
            Value = 0
					End If
				Case mPublic.csTypes.csText, mPublic.csTypes.csVariant, mPublic.csTypes.csCuit
          Value = m_Value
				Case Else
          Value = m_Value
			End Select
		End Get
		Set(ByVal Value As Object)
      If VarType(Value) = VariantType.Boolean Then
        m_Value = IIf(Value, -1, 0)
      Else
        If IsDBNull(Value) Then
          m_Value = CStr(Nothing)
        Else
          m_Value = Value
        End If
      End If
		End Set
	End Property
	
	
	Public Property Parent() As String
		Get
			Parent = m_Parent
		End Get
		Set(ByVal Value As String)
			m_Parent = Value
		End Set
	End Property
	
	Private Function pIsNullArray(ByVal v As Object) As Boolean
    Try

      Dim n As Integer

      n = UBound(v)

      pIsNullArray = False

    Catch

      pIsNullArray = True

    End Try
  End Function
	
	' propiedades privadas
	' funciones publicas
	' funciones privadas
	' construccion - destruccion
End Class