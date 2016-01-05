Option Strict Off
Option Explicit On
Friend Class cFolder
	
	
	'--------------------------------------------------------------------------------
	' cFolder
	' 29-01-2006
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes

  ' funciones

  '--------------------------------------------------------------------------------

  ' constantes
  Private Const C_Module As String = "cFolder"
  ' estructuras
  ' variables privadas
  ' eventos
  ' propiedades publicas
  ' propiedades friend
  ' propiedades privadas
  ' funciones publicas
  Public Function SelectFolder(ByVal hWnd As Integer, Optional ByVal Descript As String = "") As String
    Try

      Dim strFolder As String = ""

      If Descript = "" Then Descript = "Seleccione una carpeta"

      strFolder = ""

      Dim FldBDlg As New FolderBrowserDialog

      With FldBDlg
        .Description = Descript
        .RootFolder = Environment.SpecialFolder.Desktop
        .Description = "Select the source directory"
        If .ShowDialog = DialogResult.OK Then
          strFolder = .SelectedPath
        End If
      End With

      If Trim(strFolder) <> "" Then
        SelectFolder = strFolder
      Else
        SelectFolder = ""
      End If

    Catch ex As Exception

      SelectFolder = ""

    End Try

  End Function
  ' funciones friend
  ' funciones privadas
  ' construccion - destruccion
End Class