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
            string fileName = CreateReport();

            this.BeginInvoke(new MethodInvoker(
                () => {
                    PreviewReport(fileName);
                }
                ));
        }

        private string CreateReport() {
            string fileName = "temp.repx";
            XRDesignForm form = new XRDesignForm();
            form.DesignMdiController.CreateNewReportWizard();
            form.ActiveDesignPanel.BeginInvoke(new MethodInvoker(() => { form.ActiveDesignPanel.Report.SaveLayout(fileName); }));
            return fileName;
        }
        private void PreviewReport(string fileName) {
            XtraReport newReport = XtraReport.FromFile(fileName, true);
            newReport.ShowPreview();
        }

    }
}

