<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class fSQLLogin
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
	Public WithEvents cbServer As System.Windows.Forms.ComboBox
	Public WithEvents txPassword As System.Windows.Forms.TextBox
	Public WithEvents txUser As System.Windows.Forms.TextBox
	Public WithEvents opNt As System.Windows.Forms.RadioButton
	Public WithEvents opSQL As System.Windows.Forms.RadioButton
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdConnect As System.Windows.Forms.Button
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Line4 As System.Windows.Forms.Label
	Public WithEvents Line3 As System.Windows.Forms.Label
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSQLLogin))
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.cbServer = New System.Windows.Forms.ComboBox
    Me.txPassword = New System.Windows.Forms.TextBox
    Me.txUser = New System.Windows.Forms.TextBox
    Me.opNt = New System.Windows.Forms.RadioButton
    Me.opSQL = New System.Windows.Forms.RadioButton
    Me.cmdCancel = New System.Windows.Forms.Button
    Me.cmdConnect = New System.Windows.Forms.Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.Line4 = New System.Windows.Forms.Label
    Me.Line3 = New System.Windows.Forms.Label
    Me.Image1 = New System.Windows.Forms.PictureBox
    Me.Line1 = New System.Windows.Forms.Label
    Me.Line2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cbServer
    '
    Me.cbServer.BackColor = System.Drawing.SystemColors.Window
    Me.cbServer.Cursor = System.Windows.Forms.Cursors.Default
    Me.cbServer.ForeColor = System.Drawing.SystemColors.WindowText
    Me.cbServer.Location = New System.Drawing.Point(88, 12)
    Me.cbServer.Name = "cbServer"
    Me.cbServer.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cbServer.Size = New System.Drawing.Size(224, 21)
    Me.cbServer.Sorted = True
    Me.cbServer.TabIndex = 0
    '
    'txPassword
    '
    Me.txPassword.AcceptsReturn = True
    Me.txPassword.BackColor = System.Drawing.SystemColors.Menu
    Me.txPassword.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txPassword.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.txPassword.Location = New System.Drawing.Point(130, 161)
    Me.txPassword.MaxLength = 0
    Me.txPassword.Name = "txPassword"
    Me.txPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txPassword.Size = New System.Drawing.Size(167, 24)
    Me.txPassword.TabIndex = 4
    '
    'txUser
    '
    Me.txUser.AcceptsReturn = True
    Me.txUser.BackColor = System.Drawing.SystemColors.Menu
    Me.txUser.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txUser.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txUser.Location = New System.Drawing.Point(130, 133)
    Me.txUser.MaxLength = 0
    Me.txUser.Name = "txUser"
    Me.txUser.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txUser.Size = New System.Drawing.Size(167, 24)
    Me.txUser.TabIndex = 3
    '
    'opNt
    '
    Me.opNt.BackColor = System.Drawing.Color.White
    Me.opNt.Cursor = System.Windows.Forms.Cursors.Default
    Me.opNt.ForeColor = System.Drawing.SystemColors.ControlText
    Me.opNt.Location = New System.Drawing.Point(27, 84)
    Me.opNt.Name = "opNt"
    Me.opNt.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.opNt.Size = New System.Drawing.Size(178, 22)
    Me.opNt.TabIndex = 1
    Me.opNt.TabStop = True
    Me.opNt.Text = "Autentificación por Windows"
    Me.opNt.UseVisualStyleBackColor = False
    '
    'opSQL
    '
    Me.opSQL.BackColor = System.Drawing.Color.White
    Me.opSQL.Cursor = System.Windows.Forms.Cursors.Default
    Me.opSQL.ForeColor = System.Drawing.SystemColors.ControlText
    Me.opSQL.Location = New System.Drawing.Point(27, 108)
    Me.opSQL.Name = "opSQL"
    Me.opSQL.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.opSQL.Size = New System.Drawing.Size(181, 22)
    Me.opSQL.TabIndex = 2
    Me.opSQL.TabStop = True
    Me.opSQL.Text = "Seguridad de SQL Server"
    Me.opSQL.UseVisualStyleBackColor = False
    '
    'cmdCancel
    '
    Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
    Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdCancel.Location = New System.Drawing.Point(246, 204)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdCancel.Size = New System.Drawing.Size(79, 22)
    Me.cmdCancel.TabIndex = 6
    Me.cmdCancel.Text = "&Cancel"
    Me.cmdCancel.UseVisualStyleBackColor = False
    '
    'cmdConnect
    '
    Me.cmdConnect.BackColor = System.Drawing.SystemColors.Control
    Me.cmdConnect.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdConnect.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdConnect.Location = New System.Drawing.Point(159, 204)
    Me.cmdConnect.Name = "cmdConnect"
    Me.cmdConnect.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdConnect.Size = New System.Drawing.Size(79, 22)
    Me.cmdConnect.TabIndex = 5
    Me.cmdConnect.Text = "C&onectar"
    Me.cmdConnect.UseVisualStyleBackColor = False
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.Color.Transparent
    Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label4.Location = New System.Drawing.Point(9, 60)
    Me.Label4.Name = "Label4"
    Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label4.Size = New System.Drawing.Size(109, 25)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Conectarse usando :"
    '
    'Line4
    '
    Me.Line4.BackColor = System.Drawing.SystemColors.ControlLight
    Me.Line4.Location = New System.Drawing.Point(-3, 49)
    Me.Line4.Name = "Line4"
    Me.Line4.Size = New System.Drawing.Size(334, 1)
    Me.Line4.TabIndex = 11
    '
    'Line3
    '
    Me.Line3.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Line3.Location = New System.Drawing.Point(-3, 48)
    Me.Line3.Name = "Line3"
    Me.Line3.Size = New System.Drawing.Size(334, 1)
    Me.Line3.TabIndex = 12
    '
    'Image1
    '
    Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
    Me.Image1.Location = New System.Drawing.Point(9, 6)
    Me.Image1.Name = "Image1"
    Me.Image1.Size = New System.Drawing.Size(32, 32)
    Me.Image1.TabIndex = 13
    Me.Image1.TabStop = False
    '
    'Line1
    '
    Me.Line1.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Line1.Location = New System.Drawing.Point(-3, 195)
    Me.Line1.Name = "Line1"
    Me.Line1.Size = New System.Drawing.Size(334, 1)
    Me.Line1.TabIndex = 14
    '
    'Line2
    '
    Me.Line2.BackColor = System.Drawing.SystemColors.ControlLight
    Me.Line2.Location = New System.Drawing.Point(-3, 196)
    Me.Line2.Name = "Line2"
    Me.Line2.Size = New System.Drawing.Size(334, 1)
    Me.Line2.TabIndex = 15
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label1.Location = New System.Drawing.Point(48, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label1.Size = New System.Drawing.Size(40, 25)
    Me.Label1.TabIndex = 9
    Me.Label1.Text = "Server:"
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.Color.White
    Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label2.Location = New System.Drawing.Point(66, 135)
    Me.Label2.Name = "Label2"
    Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label2.Size = New System.Drawing.Size(55, 19)
    Me.Label2.TabIndex = 8
    Me.Label2.Text = "User:"
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.Color.White
    Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label3.Location = New System.Drawing.Point(66, 165)
    Me.Label3.Name = "Label3"
    Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label3.Size = New System.Drawing.Size(55, 16)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Password:"
    '
    'fSQLLogin
    '
    Me.AcceptButton = Me.cmdConnect
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.CancelButton = Me.cmdCancel
    Me.ClientSize = New System.Drawing.Size(330, 232)
    Me.Controls.Add(Me.cbServer)
    Me.Controls.Add(Me.txPassword)
    Me.Controls.Add(Me.txUser)
    Me.Controls.Add(Me.opNt)
    Me.Controls.Add(Me.opSQL)
    Me.Controls.Add(Me.cmdCancel)
    Me.Controls.Add(Me.cmdConnect)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Line4)
    Me.Controls.Add(Me.Line3)
    Me.Controls.Add(Me.Image1)
    Me.Controls.Add(Me.Line1)
    Me.Controls.Add(Me.Line2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label3)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.ForeColor = System.Drawing.SystemColors.WindowText
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Location = New System.Drawing.Point(3, 22)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fSQLLogin"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.ShowInTaskbar = False
    Me.Text = "Login"
    CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
#End Region 
End Class