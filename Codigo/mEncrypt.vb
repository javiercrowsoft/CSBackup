Option Strict Off
Option Explicit On
Module mEncrypt
	
	Public Function EncryptData(ByVal data As String, ByVal Password As String) As String

    If data = "" Then
      EncryptData = ""
      Exit Function
    End If

    Dim oRijndael As RijndaelEnhanced

    If Len(Password) Then

      oRijndael = New RijndaelEnhanced(Password)

      EncryptData = oRijndael.Encrypt(data)

    Else

      EncryptData = data

    End If

  End Function

  Public Function DecryptData(ByVal data As String, ByVal Password As String) As String

    Dim oRijndael As RijndaelEnhanced

    If data <> "" Then

      If Len(Password) Then


        oRijndael = New RijndaelEnhanced(Password)

        DecryptData = oRijndael.Decrypt(data)

      Else

        DecryptData = data

      End If

    Else

      DecryptData = ""

    End If

  End Function
End Module