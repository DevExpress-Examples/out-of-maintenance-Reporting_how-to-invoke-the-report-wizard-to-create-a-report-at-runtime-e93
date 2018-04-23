using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
// ...

namespace docNewReportWizard {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            // The name for a file to save a report.
            string tempFile = "temp.repx";

            // Run the Wizard to create a new report.
            CreateReport(tempFile);

            // Preview the previously created report.
            PreviewReport(tempFile);
        }

        private void CreateReport(string fileName) {
            // Create the End-User Designer form.
            XRDesignForm form = new XRDesignForm();

            // Load a blank report to the End-User Designer.
            form.OpenReport(new XtraReport());

            // Run the Report Wizard.
            form.DesignMdiController.CreateNewReportWizard();

            // Save the report to the temp file.
            form.ActiveDesignPanel.Report.SaveLayout(fileName);
        }

        private void PreviewReport(string fileName) {
            // Load the report from the temp file.
            XtraReport newReport = XtraReport.FromFile(fileName, true);

            // Show its print preview.
            newReport.ShowPreview();
        }

    }
}

