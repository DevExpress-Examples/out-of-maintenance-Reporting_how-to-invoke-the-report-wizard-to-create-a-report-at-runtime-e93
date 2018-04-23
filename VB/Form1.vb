Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
' ...

Namespace docNewReportWizard
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			' The name for a file to save a report.
			Dim tempFile As String = "temp.repx"

			' Run the Wizard to create a new report.
			CreateReport(tempFile)

			' Preview the previously created report.
			PreviewReport(tempFile)
		End Sub

		Private Sub CreateReport(ByVal fileName As String)
			' Create the End-User Designer form.
			Dim form As New XRDesignForm()

			' Load a blank report to the End-User Designer.
			form.OpenReport(New XtraReport())

			' Run the Report Wizard.
			form.ActiveDesignPanel.ExecCommand(ReportCommand.NewReportWizard)

			' Save the report to the temp file.
			form.ActiveDesignPanel.Report.SaveLayout(fileName)
		End Sub

		Private Sub PreviewReport(ByVal fileName As String)
			' Load the report from the temp file.
			Dim newReport As XtraReport = XtraReport.FromFile(fileName, True)

			' Show its print preview.
			newReport.ShowPreview()
		End Sub

	End Class
End Namespace

