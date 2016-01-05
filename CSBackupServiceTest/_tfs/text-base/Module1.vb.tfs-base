Imports CSBackup

Module Module1

  Dim WithEvents Backup As cBackup

  Sub Main()

    Backup = New cBackup

    Backup.InitProcess()

    Do

    Loop

  End Sub

  Private Sub Backup_Message(ByVal sender As Object, ByVal e As CSBackup.BackupMessageEvent) Handles Backup.Message
    System.Console.Out.WriteLine(e.Message)
  End Sub
End Module
