using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XeduleImportHelper.UI
{
    public partial class FormMain : Form
    {
        public UpdateICSFileHelper icsHelper { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSelectICSFile_Click(object sender, EventArgs e)
        {
            // Select the file
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ics files (*.ics)|*.ics";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    lblFilename.Text = $"Selected file: {filePath}";
                    icsHelper = new UpdateICSFileHelper(filePath);

                    // enable process group
                    groupProcess.Enabled = true;
                }
            }

        }

        private void btnProcessFile_Click(object sender, EventArgs e)
        {
            // process the file
            if (icsHelper != null)
            {
                icsHelper.AddXeduleCategory = cbAddCategory.Checked;
                icsHelper.RemoveAllAttendees = cbRemoveAttendees.Checked;
                icsHelper.HandleFile();
                MessageBox.Show($"Result saved: {icsHelper.ResultFilename}");
            }
            else
            {
                throw new Exception("No file selected!");
            }
        }
    }
}
