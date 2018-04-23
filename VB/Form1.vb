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
            Dim fileName As String = CreateReport()

            Me.BeginInvoke(New MethodInvoker(Sub() PreviewReport(fileName)))
        End Sub

        Private Function CreateReport() As String
            Dim fileName As String = "temp.repx"
            Dim form As New XRDesignForm()
            form.DesignMdiController.CreateNewReportWizard()
            form.ActiveDesignPanel.BeginInvoke(New MethodInvoker(Sub() form.ActiveDesignPanel.Report.SaveLayout(fileName)))
            Return fileName
        End Function
        Private Sub PreviewReport(ByVal fileName As String)
            Dim newReport As XtraReport = XtraReport.FromFile(fileName, True)
            newReport.ShowPreview()
        End Sub

    End Class
End Namespace

