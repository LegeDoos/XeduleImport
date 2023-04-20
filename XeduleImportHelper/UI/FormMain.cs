using System;
using System.IO;
using System.Windows.Forms;
using XeduleImportHelper.Business;

namespace XeduleImportHelper.UI
{
    public partial class FormMain : Form
    {
        private Settings s;

        public FormMain()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            s = Settings.ReadSettings(@"D:\_XeduleHelper\");
            tbToken.Text = s.BearerToken;
            tbDestinationFolder.Text = s.DestinationFolder;
            tbWorkingFolder.Text = s.WorkingFolder;
            tbFolderName.Text = s.DestinationSubFolder;
            try
            {
                dateTimePickerFrom.Value = s.FromDate;
                dateTimePickerTo.Value = s.ToDate;
            }
            catch (Exception)
            {
            }
        }

        private void SaveSettings()
        {
            s.BearerToken = tbToken.Text;
            s.DestinationFolder = tbDestinationFolder.Text;
            s.WorkingFolder = tbWorkingFolder.Text;
            s.FromDate = dateTimePickerFrom.Value.Date;
            s.ToDate = dateTimePickerTo.Value.Date;
            s.DestinationSubFolder = tbFolderName.Text;
            s.StoreSettings();
        }

        private void tbWorkingFolder_Click(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var s = sender as TextBox;
                s.Text = GetFolder(s.Text);
            }
        }

        private string GetFolder(string text)
        {
            folderBrowserDialog.InitialDirectory = text;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            return text;
        }

        private void tbDestinationFolder_Click(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var s = sender as TextBox;
                s.Text = GetFolder(s.Text);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void btnProcessFile_Click(object sender, EventArgs e)
        {

        }
    }
}
