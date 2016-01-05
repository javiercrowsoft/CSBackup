Option Strict Off
Option Explicit On

Imports System.Windows.Forms.Application

Friend Class fTask
  Inherits System.Windows.Forms.Form

  Private m_Changed As Boolean

  Private WithEvents m_fExplorer As fExplorer

  Public Function Edit(ByVal TaskFile As String) As Boolean

    Dim Task As cTask

    If TaskFile <> "" Then

      Task = New cTask

      If Not Task.Load(TaskFile, False) Then
        Exit Function
      End If

      With Me
        .txCode.Text = Task.Code
        .txDescrip.Text = Task.Descrip
        .txFile.Text = Task.File
        .txName.Text = Task.Name
        .txZips.Text = Task.ZipFiles

        .txFtpAddress.Text = Task.FtpAddress
        .txFtpUser.Text = Task.FtpUser
        .txFtpPwd.Text = Task.FtpPwd
        .txFtpPort.Text = CStr(Task.FtpPort)

        .txCode.Enabled = False

        .tvDir.Nodes.Clear()
        .lsNetFolder.Items.Clear()
      End With

      pLoadFolders(Task)

    Else

      With Me
        .txCode.Text = ""
        .txDescrip.Text = ""
        .txFile.Text = ""
        .txName.Text = ""
        .txZips.Text = ""

        .txFtpAddress.Text = ""
        .txFtpUser.Text = "anonymous"
        .txFtpPwd.Text = ""
        .txFtpPort.Text = "21"

        .txCode.Enabled = True

        .tvDir.Nodes.Clear()
        .lsNetFolder.Items.Clear()
      End With

    End If

    m_Changed = False

    Me.ShowDialog()

  End Function

  Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
    Me.Close()
  End Sub

  Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
    Dim mouse As cMouseWait
    mouse = New cMouseWait

    picLoadingFolder.Visible = True
    DoEvents()
    m_fExplorer = fExplorer
    fExplorer.LoadDrives()
    pLoadTaskItems(fExplorer)
    picLoadingFolder.Visible = False

    mouse = Nothing

    fExplorer.ShowDialog()
    If fExplorer.Ok Then
      pSetFiles()
    End If

    fExplorer.Close()
    m_fExplorer = Nothing
  End Sub

  Private Sub cmdOpenFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpenFile.Click

    With dlgSave
      .Filter = "Archivos de Backup de CrowSoft|*.cszip"
      .ShowDialog()
      If .FileName <> "" Then
        txFile.Text = .FileName
      End If
    End With
  End Sub

  Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
    pSave()
  End Sub

  Private Sub cmdSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveAs.Click
    Dim TaskName As String
    TaskName = InputBox("Ingrese el nombre", "Guardar Como", "Nueva Tarea")

    If TaskName <> "" Then
      txCode.Text = TaskName
      pSave()
    End If
  End Sub

  Private Sub fTask_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    tvDir.ImageList = ilDir
  End Sub

  Private Sub fTask_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim Cancel As Boolean = eventArgs.Cancel
    Dim Rslt As MsgBoxResult

    If m_Changed Then
      Rslt = MsgBox("Desea guardar los cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
      If Rslt = MsgBoxResult.Cancel Then
        Cancel = True
      ElseIf Rslt = MsgBoxResult.Yes Then
        If Not pSave() Then
          Cancel = True
        End If
      End If
    End If

    eventArgs.Cancel = Cancel
  End Sub

  Private Sub fTask_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    m_fExplorer = Nothing
  End Sub

  Private Sub m_fExplorer_UpdateNode(ByRef Node As System.Windows.Forms.TreeNode) Handles m_fExplorer.UpdateNode
    pUpdateNode(Node)
  End Sub

  Private Sub txCode_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txCode.TextChanged
    m_Changed = True
  End Sub

  Private Sub txDescrip_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txDescrip.TextChanged
    m_Changed = True
  End Sub

  Private Sub txFile_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txFile.TextChanged
    m_Changed = True
  End Sub

  Private Sub txName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txName.TextChanged
    m_Changed = True
  End Sub

  Private Function ValidateValue() As Boolean

    If txName.Text = "" Then
      Info("Debe indicar un nombre para la tarea")
      SetFocusControl(txName)
      Exit Function
    End If

    If txFile.Text = "" Then
      Info("Debe indicar el nombre del archivo de backup que sera generado por la tarea")
      SetFocusControl(txFile)
      Exit Function
    End If

    If txCode.Text = "" Then
      Info("Debe indicar un codigo para la tarea")
      SetFocusControl(txCode)
      Exit Function
    End If

    ValidateValue = True
  End Function

  Private Function pSave() As Boolean

    If Not ValidateValue() Then Exit Function

    Dim Task As cTask

    Task = New cTask

    With Me
      Task.Code = .txCode.Text
      Task.Descrip = .txDescrip.Text
      Task.File = .txFile.Text
      Task.Name = .txName.Text
      Task.ZipFiles = CStr(Val(txZips.Text))

      Task.FtpAddress = .txFtpAddress.Text
      Task.FtpUser = .txFtpUser.Text
      Task.FtpPwd = .txFtpPwd.Text
      Task.FtpPort = Val(.txFtpPort.Text)
    End With

    pAddFolders(Task)

    If Task.Save Then
      m_Changed = False
      pSave = True
    End If
  End Function

  Private Sub pSetFiles()
    Dim Node As System.Windows.Forms.TreeNode

    tvDir.Nodes.Clear()

    For Each Node In fExplorer.tvDir.Nodes
      pCheckNodes(Node)
    Next Node

    For Each Node In fExplorer.tvDir.Nodes
      pCheckNodesByParent(Node)
    Next Node

    Node = fExplorer.tvDir.Nodes.Item(0)

    pSetFilesAux(Node, Nothing)

    lsNetFolder.Items.Clear()

    Dim i As Integer

    For i = 0 To fExplorer.lsNetFolders.Items.Count - 1

      lsNetFolder.Items.Add(fExplorer.lsNetFolders.Items.Item(i).ToString)

    Next
  End Sub

  Private Sub pCheckNodes(ByRef Node As System.Windows.Forms.TreeNode)
    Dim ChildNode As System.Windows.Forms.TreeNode

    If Node.Checked Then
      Node.Tag = CStr(1)
    Else
      Node.Tag = CStr(0)
    End If

    For Each ChildNode In Node.Nodes
      pCheckNodes(ChildNode)
    Next

  End Sub

  Private Sub pCheckNodesByParent(ByRef Node As System.Windows.Forms.TreeNode)
    Dim ChildNode As System.Windows.Forms.TreeNode
    Dim oParent As System.Windows.Forms.TreeNode

    If Node.Checked Then
      oParent = Node.Parent
      While Not oParent Is Nothing
        oParent.Checked = True
        oParent = oParent.Parent
      End While
    End If

    For Each ChildNode In Node.Nodes
      pCheckNodesByParent(ChildNode)
    Next

  End Sub

  Private Sub pSetFilesAux(ByRef NodeAux As System.Windows.Forms.TreeNode, _
                           ByRef oParent As System.Windows.Forms.TreeNode)

    Dim Node As System.Windows.Forms.TreeNode
    Dim NewNode As System.Windows.Forms.TreeNode

    Node = NodeAux

    If Node.Checked Then
      If oParent Is Nothing Then
        NewNode = tvDir.Nodes.Add(GetKey(NextKey()), Node.Text, IIf(Node.ImageIndex > 2, _
                                                     Node.ImageIndex - 2, _
                                                     Node.ImageIndex))
      Else
        NewNode = tvDir.Nodes.Find(oParent.Name, True)(0).Nodes.Add(GetKey(NextKey()), _
                                                                    Node.Text, _
                                                                    IIf(Node.ImageIndex > 2, _
                                                                        Node.ImageIndex - 2, _
                                                                        Node.ImageIndex))
      End If

      NewNode.Tag = Node.Tag

      If Node.Nodes.Count Then
        pSetFilesAux(Node.FirstNode, NewNode)
      End If
    End If

    Node = Node.NextNode
    If Not Node Is Nothing Then
      pSetFilesAux(Node, oParent)
    End If
  End Sub

  Private Sub pAddFolders(ByRef Task As cTask)

    Dim TaskItem As cTaskItem
    Dim Node As System.Windows.Forms.TreeNode

    If tvDir.Nodes.Count Then

      Node = tvDir.Nodes.Item(0)

      While Not Node Is Nothing

        If Node.Parent Is Nothing Then
          TaskItem = New cTaskItem
          Task.Folders.Add(TaskItem)
        End If

        TaskItem.Name = Node.Text
        TaskItem.ItemType = IIf(Node.ImageIndex = 0 Or Node.ImageIndex = 1, _
                                cTaskItem.csEItemTypes.csEIT_Folder, _
                                cTaskItem.csEItemTypes.csEIT_File)
        TaskItem.Checked = Val(Node.Tag)

        If Node.GetNodeCount(False) Then
          pAddFolderAux(Node.FirstNode, TaskItem)
        End If

        Node = Node.NextNode

      End While

    End If

    Dim i As Integer

    For i = 0 To lsNetFolder.Items.Count - 1
      TaskItem = New cTaskItem
      TaskItem.Name = lsNetFolder.Items.Item(i).ToString
      If GetAttr(TaskItem.Name) = FileAttribute.Directory Then
        TaskItem.ItemType = cTaskItem.csEItemTypes.csEIT_Folder
      Else
        TaskItem.ItemType = cTaskItem.csEItemTypes.csEIT_File
      End If
      TaskItem.Checked = True
      Task.Folders.Add(TaskItem)
    Next

  End Sub

  Private Sub pAddFolderAux(ByRef NodeAux As System.Windows.Forms.TreeNode, _
                            ByRef oParent As cTaskItem)

    Dim Node As System.Windows.Forms.TreeNode
    Dim TaskItem As cTaskItem

    Node = NodeAux

    While Not Node Is Nothing

      TaskItem = New cTaskItem
      oParent.Children.Add(TaskItem)
      TaskItem.Name = Node.Text
      TaskItem.ItemType = IIf(Node.ImageIndex = 0 Or Node.ImageIndex = 1, _
                              cTaskItem.csEItemTypes.csEIT_Folder, _
                              cTaskItem.csEItemTypes.csEIT_File)
      TaskItem.Checked = Val(Node.Tag)

      If Node.GetNodeCount(False) Then
        pAddFolderAux(Node.FirstNode, TaskItem)
      End If

      Node = Node.NextNode
    End While

  End Sub

  Private Sub pLoadFolders(ByRef Task As cTask)
    Dim TaskItem As cTaskItem
    Dim Node As System.Windows.Forms.TreeNode

    For Each TaskItem In Task.Folders
      If TaskItem.Name.Substring(0, 2) = "\\" Then
        lsNetFolder.Items.Add(TaskItem.Name)
      Else
        Node = pAddNode(TaskItem.Name, c_close_folder, Nothing, TaskItem.Checked)
        If TaskItem.Children.Count() Then
          pLoadFoldersAux((TaskItem.Children), Node)
        End If
      End If
    Next TaskItem
  End Sub

  Private Sub pLoadFoldersAux(ByRef TaskItems As Collection, ByRef NodeFather As System.Windows.Forms.TreeNode)
    Dim TaskItem As cTaskItem
    Dim Node As System.Windows.Forms.TreeNode

    For Each TaskItem In TaskItems
      If TaskItem.ItemType = cTaskItem.csEItemTypes.csEIT_File Then

        pAddNode(TaskItem.Name, c_file, NodeFather, TaskItem.Checked)

      Else

        Node = pAddNode(TaskItem.Name, c_close_folder, NodeFather, TaskItem.Checked)

        If TaskItem.Children.Count() Then
          pLoadFoldersAux((TaskItem.Children), Node)
        End If
      End If
    Next TaskItem
  End Sub


  Private Function pAddNode(ByVal strText As String, ByVal Image As Short, ByRef NodeFather As System.Windows.Forms.TreeNode, ByVal Checked As Boolean) As System.Windows.Forms.TreeNode
    Dim Node As System.Windows.Forms.TreeNode
    If NodeFather Is Nothing Then
      Node = tvDir.Nodes.Add(GetKey(NextKey()), strText, Image)

    Else
      Node = tvDir.Nodes.Find(NodeFather.Name, True)(0).Nodes.Add(GetKey(NextKey()), strText, Image)
    End If

    Node.Tag = IIf(Checked, 1, 0)

    pAddNode = Node
  End Function

  Private Sub pUpdateNode(ByRef Node As System.Windows.Forms.TreeNode)
    Dim Child As System.Windows.Forms.TreeNode
    Child = Node.FirstNode

    While Not Child Is Nothing

      pSetChecked(Child)

      Child = Child.NextNode
    End While
  End Sub

  Private Sub pSetChecked(ByRef Node As System.Windows.Forms.TreeNode)
    Dim taskNode As System.Windows.Forms.TreeNode

    For Each taskNode In Me.tvDir.Nodes
      If Node.FullPath = taskNode.FullPath Then
        Node.Checked = Val(taskNode.Tag)
        Exit For
      End If
    Next taskNode
  End Sub

  Private Sub pLoadTaskItems(ByRef fExplorer As fExplorer)
    Dim taskNode As System.Windows.Forms.TreeNode

    For Each taskNode In Me.tvDir.Nodes

      pLoadTaskItemsAux(fExplorer, taskNode)

    Next

    Dim i As Integer

    fExplorer.lsNetFolders.Items.Clear()

    For i = 0 To lsNetFolder.Items.Count - 1

      fExplorer.lsNetFolders.Items.Add(lsNetFolder.Items.Item(i).ToString())

    Next

  End Sub

  Private Sub pLoadTaskItemsAux(ByRef fExplorer As fExplorer, _
                                ByRef taskNode As System.Windows.Forms.TreeNode)

    Dim folderNode As System.Windows.Forms.TreeNode
    Dim childNode As System.Windows.Forms.TreeNode

    For Each folderNode In fExplorer.tvDir.Nodes

      If pLoadTaskItemsAux2(fExplorer, taskNode, folderNode) Then

        For Each childNode In taskNode.Nodes

          pLoadTaskItemsAux(fExplorer, childNode)

        Next

      End If
    Next

  End Sub

  ' Si devuelve False es por que encontro el nodo y no se debe seguir con la recursividad
  '
  Private Function pLoadTaskItemsAux2(ByRef fExplorer As fExplorer, _
                                      ByRef taskNode As System.Windows.Forms.TreeNode, _
                                      ByRef folderNode As System.Windows.Forms.TreeNode) As Boolean

    If folderNode.FullPath = taskNode.FullPath Then

      folderNode.Checked = Val(taskNode.Tag)

      If folderNode.ImageIndex <> c_file Then
        folderNode.ImageIndex = c_close_folder_selected
        folderNode.SelectedImageIndex = c_open_folder_selected
      End If

      fExplorer.ExpandNode(folderNode)
      pLoadTaskItemsAux2 = False

    End If

    Dim childNode As System.Windows.Forms.TreeNode

    For Each childNode In folderNode.Nodes

      pLoadTaskItemsAux2(fExplorer, taskNode, childNode)

    Next

    pLoadTaskItemsAux2 = True

  End Function
End Class