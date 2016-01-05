<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class fAbout
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
	Public WithEvents picIcon As System.Windows.Forms.PictureBox
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents _Line1_1 As System.Windows.Forms.Label
	Public WithEvents lblDescription As System.Windows.Forms.Label
	Public WithEvents _Line1_0 As System.Windows.Forms.Label
	Public WithEvents lblVersion As System.Windows.Forms.Label
	Public WithEvents lblDisclaimer As System.Windows.Forms.Label
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.
  'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fAbout))
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.picIcon = New System.Windows.Forms.PictureBox
    Me.cmdOk = New System.Windows.Forms.Button
    Me._Line1_1 = New System.Windows.Forms.Label
    Me.lblDescription = New System.Windows.Forms.Label
    Me._Line1_0 = New System.Windows.Forms.Label
    Me.lblVersion = New System.Windows.Forms.Label
    Me.lblDisclaimer = New System.Windows.Forms.Label
    Me.Image1 = New System.Windows.Forms.PictureBox
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
    CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'picIcon
    '
    Me.picIcon.BackColor = System.Drawing.SystemColors.Control
    Me.picIcon.Cursor = System.Windows.Forms.Cursors.Hand
    Me.picIcon.ForeColor = System.Drawing.SystemColors.ControlText
    Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
    Me.picIcon.Location = New System.Drawing.Point(8, 8)
    Me.picIcon.Name = "picIcon"
    Me.picIcon.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.picIcon.Size = New System.Drawing.Size(142, 74)
    Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.picIcon.TabIndex = 1
    Me.picIcon.TabStop = False
    '
    'cmdOk
    '
    Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
    Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdOk.Location = New System.Drawing.Point(359, 151)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdOk.Size = New System.Drawing.Size(84, 23)
    Me.cmdOk.TabIndex = 0
    Me.cmdOk.Text = "&Aceptar"
    Me.cmdOk.UseVisualStyleBackColor = False
    '
    '_Line1_1
    '
    Me._Line1_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
    Me._Line1_1.Location = New System.Drawing.Point(5, 136)
    Me._Line1_1.Name = "_Line1_1"
    Me._Line1_1.Size = New System.Drawing.Size(301, 1)
    Me._Line1_1.TabIndex = 2
    '
    'lblDescription
    '
    Me.lblDescription.BackColor = System.Drawing.Color.Transparent
    Me.lblDescription.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblDescription.ForeColor = System.Drawing.Color.Black
    Me.lblDescription.Location = New System.Drawing.Point(8, 92)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblDescription.Size = New System.Drawing.Size(427, 38)
    Me.lblDescription.TabIndex = 2
    Me.lblDescription.Text = "App Description"
    '
    '_Line1_0
    '
    Me._Line1_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me._Line1_0.Location = New System.Drawing.Point(5, 137)
    Me._Line1_0.Name = "_Line1_0"
    Me._Line1_0.Size = New System.Drawing.Size(301, 1)
    Me._Line1_0.TabIndex = 3
    '
    'lblVersion
    '
    Me.lblVersion.BackColor = System.Drawing.Color.Transparent
    Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblVersion.Location = New System.Drawing.Point(174, 52)
    Me.lblVersion.Name = "lblVersion"
    Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblVersion.Size = New System.Drawing.Size(263, 15)
    Me.lblVersion.TabIndex = 4
    Me.lblVersion.Text = "Version"
    '
    'lblDisclaimer
    '
    Me.lblDisclaimer.BackColor = System.Drawing.Color.Transparent
    Me.lblDisclaimer.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblDisclaimer.ForeColor = System.Drawing.Color.Black
    Me.lblDisclaimer.Location = New System.Drawing.Point(17, 151)
    Me.lblDisclaimer.Name = "lblDisclaimer"
    Me.lblDisclaimer.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblDisclaimer.Size = New System.Drawing.Size(334, 55)
    Me.lblDisclaimer.TabIndex = 3
    '
    'Image1
    '
    Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
    Me.Image1.Location = New System.Drawing.Point(172, 16)
    Me.Image1.Name = "Image1"
    Me.Image1.Size = New System.Drawing.Size(262, 31)
    Me.Image1.TabIndex = 5
    Me.Image1.TabStop = False
    '
    'LinkLabel1
    '
    Me.LinkLabel1.AutoSize = True
    Me.LinkLabel1.Location = New System.Drawing.Point(8, 236)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(140, 13)
    Me.LinkLabel1.TabIndex = 6
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "http://www.crowsoft.com.ar"
    '
    'fAbout
    '
    Me.AcceptButton = Me.cmdOk
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.CancelButton = Me.cmdOk
    Me.ClientSize = New System.Drawing.Size(450, 258)
    Me.Controls.Add(Me.LinkLabel1)
    Me.Controls.Add(Me.picIcon)
    Me.Controls.Add(Me.cmdOk)
    Me.Controls.Add(Me._Line1_1)
    Me.Controls.Add(Me.lblDescription)
    Me.Controls.Add(Me._Line1_0)
    Me.Controls.Add(Me.lblVersion)
    Me.Controls.Add(Me.lblDisclaimer)
    Me.Controls.Add(Me.Image1)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Location = New System.Drawing.Point(156, 129)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fAbout"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "About MyApp"
    CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
#End Region 
End Class