using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XeduleImportHelper.Business;

namespace XeduleImportHelper.UI
{
    public partial class FormMain : Form
    {
        bool formLoading;
        private Settings s;

        public FormMain()
        {
            formLoading = true;
            InitializeComponent();
            LoadSettings();
            formLoading = false;
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
            if (!formLoading)
            {
                s.BearerToken = tbToken.Text;
                s.DestinationFolder = tbDestinationFolder.Text;
                s.WorkingFolder = tbWorkingFolder.Text;
                s.FromDate = dateTimePickerFrom.Value.Date;
                s.ToDate = dateTimePickerTo.Value.Date;
                s.DestinationSubFolder = tbFolderName.Text;
                s.StoreSettings();
            }
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
            string resultPath = Path.Combine(s.DestinationFolder, s.DestinationSubFolder);
            if (!Directory.Exists(resultPath))
            {
                Directory.CreateDirectory(resultPath);
            }
            else
            {
                foreach (var file in new DirectoryInfo(resultPath).GetFiles())
                {
                    file.Delete();
                }
            }

            foreach (var person in s.Persons.OrderBy(p => p.Name))
            {
                var icsResult = new XeduleAPIHelper(s.FromDate, s.ToDate, person.XeduleId) { BearerToken = s.BearerToken }.CallAPI();
                UpdateICSFileHelper helper = new(icsResult, person.Name)
                {
                    ResultPath = resultPath,
                    RemoveAllAttendees = true,
                    AddXeduleCategory = true
                };
                var res = helper.HandleFile();
                Console.WriteLine(res);
                Console.ReadLine();
            }

        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void tbFolderName_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var s = sender as TextBox;
                if (s.Modified)
                {
                    SaveSettings();
                }
            }
        }

        private void tbWorkingFolder_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var s = sender as TextBox;
                if (s.Modified)
                {
                    SaveSettings();
                }
            }
        }

        private void tbDestinationFolder_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var s = sender as TextBox;
                if (s.Modified)
                {
                    SaveSettings();
                }
            }
        }

        private void tbToken_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var s = sender as TextBox;
                if (s.Modified)
                {
                    SaveSettings();
                }
            }
        }
    }
}
