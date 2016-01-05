<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class fPreferences
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents chkInitWithWindows As System.Windows.Forms.CheckBox
	Public WithEvents cmdSetMasterPassword As System.Windows.Forms.Button
	Public WithEvents chkMasterPassword As System.Windows.Forms.CheckBox
	Public WithEvents txPassword2 As System.Windows.Forms.TextBox
	Public WithEvents txPassword As System.Windows.Forms.TextBox
	Public WithEvents cmdOpenFolder As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents txPath As System.Windows.Forms.TextBox
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents Shape1 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPreferences))
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.chkInitWithWindows = New System.Windows.Forms.CheckBox
    Me.cmdSetMasterPassword = New System.Windows.Forms.Button
    Me.chkMasterPassword = New System.Windows.Forms.CheckBox
    Me.txPassword2 = New System.Windows.Forms.TextBox
    Me.txPassword = New System.Windows.Forms.TextBox
    Me.cmdOpenFolder = New System.Windows.Forms.Button
    Me.cmdCancel = New System.Windows.Forms.Button
    Me.cmdOk = New System.Windows.Forms.Button
    Me.txPath = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Line2 = New System.Windows.Forms.Label
    Me.Line1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Image1 = New System.Windows.Forms.PictureBox
    Me.Shape1 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'chkInitWithWindows
    '
    Me.chkInitWithWindows.BackColor = System.Drawing.SystemColors.Control
    Me.chkInitWithWindows.Cursor = System.Windows.Forms.Cursors.Default
    Me.chkInitWithWindows.ForeColor = System.Drawing.SystemColors.ControlText
    Me.chkInitWithWindows.Location = New System.Drawing.Point(8, 248)
    Me.chkInitWithWindows.Name = "chkInitWithWindows"
    Me.chkInitWithWindows.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.chkInitWithWindows.Size = New System.Drawing.Size(357, 17)
    Me.chkInitWithWindows.TabIndex = 14
    Me.chkInitWithWindows.Text = "Ejecutar CSBackup al iniciar Windows"
    Me.chkInitWithWindows.UseVisualStyleBackColor = False
    '
    'cmdSetMasterPassword
    '
    Me.cmdSetMasterPassword.BackColor = System.Drawing.SystemColors.Control
    Me.cmdSetMasterPassword.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdSetMasterPassword.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdSetMasterPassword.Location = New System.Drawing.Point(32, 408)
    Me.cmdSetMasterPassword.Name = "cmdSetMasterPassword"
    Me.cmdSetMasterPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdSetMasterPassword.Size = New System.Drawing.Size(157, 27)
    Me.cmdSetMasterPassword.TabIndex = 8
    Me.cmdSetMasterPassword.Text = "Ingresar Clave Maestra"
    Me.cmdSetMasterPassword.UseVisualStyleBackColor = False
    '
    'chkMasterPassword
    '
    Me.chkMasterPassword.BackColor = System.Drawing.SystemColors.Control
    Me.chkMasterPassword.Cursor = System.Windows.Forms.Cursors.Default
    Me.chkMasterPassword.ForeColor = System.Drawing.SystemColors.ControlText
    Me.chkMasterPassword.Location = New System.Drawing.Point(8, 280)
    Me.chkMasterPassword.Name = "chkMasterPassword"
    Me.chkMasterPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.chkMasterPassword.Size = New System.Drawing.Size(357, 17)
    Me.chkMasterPassword.TabIndex = 7
    Me.chkMasterPassword.Text = "Usar una clave maestra"
    Me.chkMasterPassword.UseVisualStyleBackColor = False
    '
    'txPassword2
    '
    Me.txPassword2.AcceptsReturn = True
    Me.txPassword2.BackColor = System.Drawing.SystemColors.Window
    Me.txPassword2.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txPassword2.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txPassword2.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.txPassword2.Location = New System.Drawing.Point(8, 212)
    Me.txPassword2.MaxLength = 0
    Me.txPassword2.Name = "txPassword2"
    Me.txPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txPassword2.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txPassword2.Size = New System.Drawing.Size(361, 20)
    Me.txPassword2.TabIndex = 6
    '
    'txPassword
    '
    Me.txPassword.AcceptsReturn = True
    Me.txPassword.BackColor = System.Drawing.SystemColors.Window
    Me.txPassword.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txPassword.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.txPassword.Location = New System.Drawing.Point(8, 156)
    Me.txPassword.MaxLength = 0
    Me.txPassword.Name = "txPassword"
    Me.txPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txPassword.Size = New System.Drawing.Size(361, 20)
    Me.txPassword.TabIndex = 4
    '
    'cmdOpenFolder
    '
    Me.cmdOpenFolder.BackColor = System.Drawing.SystemColors.Control
    Me.cmdOpenFolder.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdOpenFolder.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdOpenFolder.Location = New System.Drawing.Point(376, 104)
    Me.cmdOpenFolder.Name = "cmdOpenFolder"
    Me.cmdOpenFolder.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdOpenFolder.Size = New System.Drawing.Size(25, 25)
    Me.cmdOpenFolder.TabIndex = 2
    Me.cmdOpenFolder.Text = "..."
    Me.cmdOpenFolder.UseVisualStyleBackColor = False
    '
    'cmdCancel
    '
    Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
    Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdCancel.Location = New System.Drawing.Point(292, 448)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdCancel.Size = New System.Drawing.Size(105, 27)
    Me.cmdCancel.TabIndex = 10
    Me.cmdCancel.Text = "&Cancelar"
    Me.cmdCancel.UseVisualStyleBackColor = False
    '
    'cmdOk
    '
    Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
    Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdOk.Location = New System.Drawing.Point(180, 448)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdOk.Size = New System.Drawing.Size(105, 27)
    Me.cmdOk.TabIndex = 9
    Me.cmdOk.Text = "&Aceptar"
    Me.cmdOk.UseVisualStyleBackColor = False
    '
    'txPath
    '
    Me.txPath.AcceptsReturn = True
    Me.txPath.BackColor = System.Drawing.SystemColors.Window
    Me.txPath.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txPath.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txPath.Location = New System.Drawing.Point(8, 104)
    Me.txPath.MaxLength = 0
    Me.txPath.Name = "txPath"
    Me.txPath.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txPath.Size = New System.Drawing.Size(361, 20)
    Me.txPath.TabIndex = 1
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label6.Location = New System.Drawing.Point(32, 372)
    Me.Label6.Name = "Label6"
    Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label6.Size = New System.Drawing.Size(345, 33)
    Me.Label6.TabIndex = 13
    Me.Label6.Text = "Le recomendamos que active el uso de clave maestra para aumentar el nivel de segu" & _
        "ridad de CSBackup."
    '
    'Label5
    '
    Me.Label5.BackColor = System.Drawing.SystemColors.Control
    Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label5.Location = New System.Drawing.Point(32, 308)
    Me.Label5.Name = "Label5"
    Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label5.Size = New System.Drawing.Size(341, 61)
    Me.Label5.TabIndex = 12
    Me.Label5.Text = resources.GetString("Label5.Text")
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.SystemColors.Control
    Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label4.Location = New System.Drawing.Point(8, 192)
    Me.Label4.Name = "Label4"
    Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label4.Size = New System.Drawing.Size(213, 21)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "C&onfirme la clave:"
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label3.Location = New System.Drawing.Point(8, 136)
    Me.Label3.Name = "Label3"
    Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label3.Size = New System.Drawing.Size(213, 21)
    Me.Label3.TabIndex = 3
    Me.Label3.Text = "C&lave de encriptación de los archivos:"
    '
    'Line2
    '
    Me.Line2.BackColor = System.Drawing.SystemColors.ControlLight
    Me.Line2.Location = New System.Drawing.Point(-56, 441)
    Me.Line2.Name = "Line2"
    Me.Line2.Size = New System.Drawing.Size(468, 1)
    Me.Line2.TabIndex = 15
    '
    'Line1
    '
    Me.Line1.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Line1.Location = New System.Drawing.Point(-56, 440)
    Me.Line1.Name = "Line1"
    Me.Line1.Size = New System.Drawing.Size(468, 1)
    Me.Line1.TabIndex = 16
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.Color.White
    Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label2.Location = New System.Drawing.Point(80, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label2.Size = New System.Drawing.Size(169, 33)
    Me.Label2.TabIndex = 11
    Me.Label2.Text = "Preferencias"
    '
    'Image1
    '
    Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
    Me.Image1.Location = New System.Drawing.Point(24, 8)
    Me.Image1.Name = "Image1"
    Me.Image1.Size = New System.Drawing.Size(45, 45)
    Me.Image1.TabIndex = 17
    Me.Image1.TabStop = False
    '
    'Shape1
    '
    Me.Shape1.BackColor = System.Drawing.Color.White
    Me.Shape1.Location = New System.Drawing.Point(-8, 0)
    Me.Shape1.Name = "Shape1"
    Me.Shape1.Size = New System.Drawing.Size(417, 65)
    Me.Shape1.TabIndex = 18
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label1.Location = New System.Drawing.Point(8, 80)
    Me.Label1.Name = "Label1"
    Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label1.Size = New System.Drawing.Size(121, 25)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "&Ubicacion de archivos:"
    '
    'fPreferences
    '
    Me.AcceptButton = Me.cmdOk
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.CancelButton = Me.cmdCancel
    Me.ClientSize = New System.Drawing.Size(407, 484)
    Me.Controls.Add(Me.chkInitWithWindows)
    Me.Controls.Add(Me.cmdSetMasterPassword)
    Me.Controls.Add(Me.chkMasterPassword)
    Me.Controls.Add(Me.txPassword2)
    Me.Controls.Add(Me.txPassword)
    Me.Controls.Add(Me.cmdOpenFolder)
    Me.Controls.Add(Me.cmdCancel)
    Me.Controls.Add(Me.cmdOk)
    Me.Controls.Add(Me.txPath)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Line2)
    Me.Controls.Add(Me.Line1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Image1)
    Me.Controls.Add(Me.Shape1)
    Me.Controls.Add(Me.Label1)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Location = New System.Drawing.Point(3, 23)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fPreferences"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.ShowInTaskbar = False
    Me.Text = "Preferencias"
    CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
#End Region 
End Class