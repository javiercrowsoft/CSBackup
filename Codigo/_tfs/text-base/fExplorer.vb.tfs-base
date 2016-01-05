Option Strict Off
Option Explicit On

Imports VB = Microsoft.VisualBasic
Imports System.IO

Friend Class fExplorer
	Inherits System.Windows.Forms.Form
	'--------------------------------------------------------------------------------
	' fExplorer
	' 15-05-2002
	
	'--------------------------------------------------------------------------------
	' notas:
	
	'--------------------------------------------------------------------------------
	' api win32
	' constantes
	' estructuras
	' funciones
	
	'--------------------------------------------------------------------------------
	
	' constantes
	Private Const C_Module As String = "fExplorer."
	' estructuras
	' variables privadas
	Private m_Leaf As Boolean
	Private m_ok As Boolean
	' eventos
	Public Event UpdateNode(ByRef Node As System.Windows.Forms.TreeNode)
	' propiedadades publicas
	Public ReadOnly Property Ok() As Boolean
		Get
			Ok = m_ok
		End Get
	End Property
	
	' propiedadades friend
	' propiedades privadas
	' funciones publicas
	Public Function LoadDrives() As Boolean
    Try

      Dim Drive As String
      Dim sKey As String

      tvDir.Nodes.Clear()

      For Each drive_info As DriveInfo In DriveInfo.GetDrives()

        Select Case drive_info.DriveType

          Case DriveType.CDRom, DriveType.Ram, DriveType.NoRootDirectory
            ' Estos no sirven

          Case DriveType.Fixed, DriveType.Network

            Drive = drive_info.RootDirectory.FullName
            Drive = VB.Left(Drive, Len(Drive) - 1)
            sKey = AddNode("", Drive)
            tvDir_NodeClick(tvDir, _
                            New System.Windows.Forms.TreeNodeMouseClickEventArgs( _
                              tvDir.Nodes.Find(sKey, True)(0), _
                              System.Windows.Forms.MouseButtons.None, _
                              0, 0, 0))

        End Select

      Next drive_info

      LoadDrives = True

    Catch ex As Exception

      MngError(ex.Message, "LoadDrives", C_Module, "")

    End Try

  End Function

  Public Sub ExpandNode(ByVal Node As System.Windows.Forms.TreeNode)
    tvDir_NodeClick(tvDir, New System.Windows.Forms.TreeNodeMouseClickEventArgs(Node, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
  End Sub

  ' funciones friend
  ' funciones privadas

  Private Function LoadFolders(ByVal FolderPath As String, ByVal NodeFather As String) As Boolean
    Try

      Dim i As Short
      Dim Path2 As String
      Dim Folder As String
      Dim vFolders() As String

      ReDim vFolders(0)

      Path2 = FileGetValidPath(FolderPath)

      ' Obtengo el path del siguiente hijo
      Folder = Dir(Path2, FileAttribute.Directory)

      While Folder <> ""

        If Folder <> "." And Folder <> ".." And Folder <> "?" And Folder <> "pagefile.sys" Then

          If (GetAttr(FileGetValidPath(Path2) & Folder) And FileAttribute.Directory) = FileAttribute.Directory Then

            ReDim Preserve vFolders(UBound(vFolders) + 1)
            vFolders(UBound(vFolders)) = Folder

          End If
        End If

        Folder = Dir()
      End While

      Sort(vFolders)

      For i = 1 To UBound(vFolders)
        AddNode(NodeFather, vFolders(i))
      Next

      LoadFolders = True

    Catch ex As Exception

      MngError(ex.Message, "LoadFolders", C_Module, "")

    End Try
  End Function

  Private Sub LoadFiles(ByVal Folder As String)
    Try

      Dim i As Short
      Dim Path2 As String
      Dim File As String
      Dim vFiles() As String

      ReDim vFiles(0)

      Path2 = tvDir.Nodes.Find(Folder, True)(0).FullPath

      ' Obtengo el path del siguiente hijo
      File = Dir(FileGetValidPath(Path2) & "*.*", FileAttribute.Archive)

      While File <> ""

        ReDim Preserve vFiles(UBound(vFiles) + 1)
        vFiles(UBound(vFiles)) = File

        File = Dir()
      End While

      Sort(vFiles)

      For i = 1 To UBound(vFiles)
        AddNode(Folder, vFiles(i), True)
      Next


    Catch ex As Exception

      MngError(ex.Message, "LoadFiles", C_Module, "")

    End Try

  End Sub

  Private Function AddNode(ByVal KeyFather As String, ByVal strText As String, Optional ByRef IsFile As Boolean = False) As String
    Dim Node As System.Windows.Forms.TreeNode
    Dim Key As String

    With tvDir

      ' Incremento la clave
      Key = "KEY " & Trim(CStr(NextKey()))

      ' Agrego el Node al arbol
      If Not KeyFather = "" Then
        Node = .Nodes.Find(KeyFather, True)(0).Nodes.Add(Key, strText, c_close_folder)
      Else
        Node = .Nodes.Add(Key, strText, c_close_folder)
      End If

      ' Seteo su imagen cuando esta colapsada
      Node.SelectedImageIndex = c_open_folder

      If IsFile Then
        Node.SelectedImageIndex = c_file
        Node.ImageIndex = c_file
        Node.Tag = "Leaf"
      End If
    End With

    AddNode = Key
  End Function

  Private Sub tvDir_NodeClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvDir.NodeMouseClick
    Try

      Dim Node As System.Windows.Forms.TreeNode = eventArgs.Node
      Dim Node2 As System.Windows.Forms.TreeNode

      m_Leaf = False

      With Node

        If .Tag = "" Or .Tag = "preloaded" Then

          If .Tag = "preloaded" Then
            Node2 = .FirstNode

            Do While Not Node2 Is Nothing

              If Node2.Text = "Vacio%%%@@@!!!" Then

                tvDir.Nodes.Remove(Node2)
                Exit Do
              End If
              Node2 = Node2.NextNode
            Loop

          End If

          LoadFolders(.FullPath, .Name)

          For Each Node2 In .Nodes

            If Node2.Tag = "" Then
              AddNode(Node2.Name, "Vacio%%%@@@!!!", True)
              Node2.Tag = "preloaded"
            End If
            Node2 = Node2.NextNode

          Next

          LoadFiles(.Name)

          RaiseEvent UpdateNode(Node)

          .Tag = "loaded"

        ElseIf .Tag = "Leaf" Then

          m_Leaf = True

        End If
      End With

    Catch ex As Exception

      MngError(ex.Message, "tvDir_NodeMouseClick", C_Module, "")

    End Try
  End Sub

  Private Sub tvDir_AfterExpand(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.TreeViewEventArgs) Handles tvDir.AfterExpand
    Dim Node As System.Windows.Forms.TreeNode = eventArgs.Node
    tvDir_NodeClick(tvDir, New System.Windows.Forms.TreeNodeMouseClickEventArgs(Node, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
  End Sub

  Private Sub Sort(ByRef vString() As String)
    Dim i As Short
    Dim j As Short
    Dim s As String

    vString(0) = ""

    For i = 2 To UBound(vString)
      j = i
      While LCase(vString(j)) < LCase(vString(j - 1))
        s = vString(j)
        vString(j) = vString(j - 1)
        vString(j - 1) = s
        j = j - 1
      End While
    Next

  End Sub

  Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
    m_ok = False
    Hide()
  End Sub

  Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
    m_ok = True
    Hide()
  End Sub
  ' construccion - destruccion
  Private Sub fExplorer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    Try

      tvDir.ImageList = ilDir
      m_ok = False

    Catch ex As Exception

      MngError(ex.Message, "fExplorer_load", C_Module, "")

    End Try
  End Sub

  Private Sub fExplorer_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    Dim Cancel As Boolean = eventArgs.Cancel
    Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

    Try

      If UnloadMode <> CloseReason.FormOwnerClosing And UnloadMode <> CloseReason.None Then
        Cancel = True
        cmdCancel_Click(cmdCancel, New System.EventArgs())
      End If

    Catch ex As Exception

      MngError(ex, "fExplorer_FormClosing", C_Module, "")

    Finally

      eventArgs.Cancel = Cancel

    End Try
  End Sub
	
  Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
    If TxNetPath.Text <> "" Then
      lsNetFolders.Items.Add(TxNetPath.Text)
    End If
  End Sub

  Private Sub lsNetFolders_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsNetFolders.DoubleClick
    If lsNetFolders.SelectedIndex >= 0 Then
      lsNetFolders.Items.RemoveAt(lsNetFolders.SelectedIndex)
    End If
  End Sub

  Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
    If lsNetFolders.SelectedIndex >= 0 Then
      lsNetFolders.Items.RemoveAt(lsNetFolders.SelectedIndex)
    End If
  End Sub

End Class