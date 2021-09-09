using System;
using System.Windows.Forms;
using XeduleImportHelper.Business;

namespace XeduleImportHelper.UI
{
    public partial class FormMain : Form
    {
        public UpdateICSFileHelper IcsHelper { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void BtnSelectICSFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "ics files (*.ics)|*.ics";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Select the file
                // Get the path of specified file
                string filePath = openFileDialog.FileName;
                lblFilename.Text = $"Selected file: {filePath}";
                IcsHelper = new UpdateICSFileHelper(filePath);

                // Enable process group
                groupBoxProcess.Enabled = true;
            }

        }

        private void BtnProcessFile_Click(object sender, EventArgs e)
        {
            // process the file
            if (IcsHelper != null)
            {
                IcsHelper.AddXeduleCategory = cbAddCategory.Checked;
                IcsHelper.RemoveAllAttendees = cbRemoveAttendees.Checked;
                IcsHelper.HandleFile();
                MessageBox.Show($"Result saved: {IcsHelper.ResultFilename}");
            }
            else
            {
                throw new Exception("No file selected!");
            }
        }

        private void linkLabelInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DocumentationHelper.ShowDocsOnline();
        }
    }
}
