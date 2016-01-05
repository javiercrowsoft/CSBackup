Option Strict Off
Option Explicit On
Friend Class fMasterPassword
	Inherits System.Windows.Forms.Form
	
	Private m_ok As Boolean
	
	Public ReadOnly Property Ok() As Boolean
		Get
			Ok = m_ok
		End Get
	End Property
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		m_ok = False
		Me.Hide()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		

    If txPassword.Text <> "" Then
      MsgWarning("Debe indicar una clave")
      Exit Sub
    End If
		
		If txPassword.Text <> txPassword2.Text And txPassword2.Visible = True Then
			MsgWarning("La clave y su confirmación no coinciden")
			Exit Sub
		End If
		
		If txPassword2.Visible = False Then
			If Not ValidateMasterPassword(txPassword.Text) Then
				If Not Ask("La clave es invalida." & vbCrLf & vbCrLf & "¿Desea ingresar de todas formas?" & vbCrLf & vbCrLf & "(CSBackup no sera capaz de reconocer las claves de ftp y de encriptación de archivos)", MsgBoxResult.No) Then
					Exit Sub
				End If
        txPassword.Text = ""
			End If
		End If
		
		m_ok = True
		
		Me.Hide()
		
	End Sub
	
	Private Sub fMasterPassword_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		FormCenter(Me)
		m_ok = False
	End Sub
End Class