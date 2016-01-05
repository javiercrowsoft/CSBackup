Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip

Module mZip

  Public Function ZipFiles(ByRef Zip As cZip, ByRef files() As String) As Boolean

    Dim strmZipOutputStream As ZipOutputStream

    If File.Exists(Zip.ZipFile) Then
      File.Delete(Zip.ZipFile)
    End If

    strmZipOutputStream = New ZipOutputStream(File.Create(Zip.ZipFile))

    REM Compression Level: 0-9
    REM 0: no(Compression)
    REM 9: maximum compression
    strmZipOutputStream.SetLevel(9)
    strmZipOutputStream.Password = Zip.Password

    Dim strFile As String
    Dim buffer() As Byte

    ReDim buffer(1048576)

    For Each strFile In files

      Zip.ProgressReport(strFile & " - zipping")

      Dim entry As ZipEntry = New ZipEntry(Path.GetFileName(strFile))

      entry.DateTime = DateTime.Now

      strmZipOutputStream.PutNextEntry(entry)

      Dim fs As FileStream = File.Open(strFile, FileMode.Open, FileAccess.Read, FileShare.Read)

      Dim sourceBytes As Long = 1
      Dim bytesZiped As Long = 0

      Do Until (sourceBytes <= 0)

        sourceBytes = fs.Read(Buffer, 0, Buffer.Length)

        strmZipOutputStream.Write(buffer, 0, sourceBytes)

        bytesZiped += sourceBytes

        Zip.UpdateProgressReport(strFile & " - zipping " & (DivideByZero(bytesZiped, fs.Length) * 100.0).ToString("00.00"))

        System.Windows.Forms.Application.DoEvents()

        If Zip.Cancel Then Exit Function

      Loop

      Zip.ProgressReport(strFile & " - zipped")

      fs.Close()

    Next
    '-----------------------------

    strmZipOutputStream.Finish()
    strmZipOutputStream.Close()

    'MessageBox.Show("Operation complete")

    ZipFiles = True
  End Function

  Public Sub ZipFile(ByVal source As String, ByVal dest As String)

    Dim entry As New ZipEntry(Path.GetFileName(source))
    Dim fi As New FileInfo(source)
    entry.ExternalFileAttributes = fi.Attributes
    entry.Size = fi.Length

    Dim input As FileStream = File.OpenRead(source)
    Dim output As New ZipOutputStream(File.Create(dest))

    output.PutNextEntry(entry)

    Dim buffer(8191) As Byte
    Dim len As Integer
    Do
      len = input.Read(buffer, 0, buffer.Length)
      If len > 0 Then
        output.Write(buffer, 0, len)
      End If
    Loop Until len = 0
    output.Close()
    input.Close()
  End Sub

End Module
