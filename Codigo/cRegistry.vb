Option Strict Off
Option Explicit On

Imports Microsoft.Win32

Friend Class cRegistry

  Private Const C_Module As String = "cRegistry"

  Public Function GetRegRun(ByVal sName As String, ByVal defaultValue As Object) As String

    Try

      Dim regKey As RegistryKey
      regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
      regKey = regKey.OpenSubKey("Microsoft\Windows\CurrentVersion\Run\", True)
      GetRegRun = regKey.GetValue(sName, defaultValue).ToString

      regKey.Close()

    Catch e As SystemException

      MngError(e, "SetReg", C_Module, "")

      GetRegRun = defaultValue

    End Try

  End Function

  Public Function SetRegRun(ByVal sName As String, _
                            ByVal vValue As Object) As Boolean

    Try

      Dim regKey As RegistryKey
      regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
      regKey = regKey.OpenSubKey("Microsoft\Windows\CurrentVersion\Run\", True)
      regKey.CreateSubKey(sName)
      regKey.SetValue(sName, vValue)
      regKey.Close()

      SetRegRun = True

    Catch e As SystemException

      'MngError(e, "SetReg", C_Module, "")

      SetRegRun = True

    End Try

  End Function

  Public Function DeleteRegRun(ByVal sKey As String) As Boolean

    Try

      Dim regKey As RegistryKey
      regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
      regKey.OpenSubKey("Microsoft\Windows\CurrentVersion\Run\", True)
      regKey.DeleteSubKey(sKey, True)
      regKey.Close()

      DeleteRegRun = True

    Catch e As SystemException

      'MngError(e, "SetReg", C_Module, "")

      DeleteRegRun = True

    End Try
  End Function

End Class