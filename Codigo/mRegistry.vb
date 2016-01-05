Option Strict Off
Option Explicit On
Module mRegistry
	
	Public mReg As cRegistry
	
  Public Function VerifyReg(ByVal Key As String, ByVal InitWithWindows As Boolean) As Boolean
    Dim s As String

    s = mReg.GetRegRun(Key, "")
    If s <> "" Then
      If Not InitWithWindows Then
        RemoveFromRegistry(Key)
      End If
    Else
      InsertInRegistry(Key, """" & My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe"" -r")
    End If
  End Function
	
	
	Public Function InsertInRegistry(ByVal Key As String, ByVal Exe As String) As Boolean
		Dim s As String
		
    s = mReg.GetRegRun(Key, "")
    If s = "" Then
      If mReg.SetRegRun(Key, Exe) Then
        InsertInRegistry = True
      Else
        MsgBox("No se pudo resgistrar la Aplicación", MsgBoxStyle.Critical)
      End If
    End If
	End Function
	
	Public Function RemoveFromRegistry(ByVal Key As String) As Boolean
		Dim s As String
		
    s = mReg.GetRegRun(Key, "")
		If s <> "" Then
      If Not mReg.DeleteRegRun(Key) Then
        MsgBox("ERROR al eliminar la clave.")
      End If
		End If
	End Function
End Module