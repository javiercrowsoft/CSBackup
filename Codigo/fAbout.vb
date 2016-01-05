Option Strict Off
Option Explicit On
Friend Class fAbout
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		Me.Close()
	End Sub
	
	Private Sub fAbout_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Text = "Acerca de " & My.Application.Info.Title
		lblVersion.Text = "Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		lblDisclaimer.Text = "Advertencia: Este programa esta protegido por las leyes de CopyRight y tratados internacionales. " & "La reproducción, copia o distribución no autorizada de este programa o parte de él, puede llevar a " & "realizar acciones civiles y/o penales en su contra."
		lblDescription.Text = "Esta aplicación permite configurar las tareas de Backup " & "y recuperar archivos de resguardo CrowSoft (*.cszip)."
	End Sub

  Private Sub pShowCrowSoftSite()
    System.Diagnostics.Process.Start(LinkLabel1.Text)
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    pShowCrowSoftSite()
  End Sub

  Private Sub picIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picIcon.Click
    pShowCrowSoftSite()
  End Sub
End Class