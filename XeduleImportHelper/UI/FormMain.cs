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
        private Settings settings;

        public FormMain()
        {
            formLoading = true;
            InitializeComponent();
            LoadSettings();
            formLoading = false;
        }

        private void LoadSettings()
        {
            settings = Settings.ReadSettings(@"D:\_XeduleHelper\");
            tbToken.Text = settings.BearerToken;
            tbDestinationFolder.Text = settings.DestinationFolder;
            tbWorkingFolder.Text = settings.WorkingFolder;
            tbFolderName.Text = settings.DestinationSubFolder;
            try
            {
                dateTimePickerFrom.Value = settings.FromDate;
                dateTimePickerTo.Value = settings.ToDate;
            }
            catch (Exception)
            {
            }
        }

        private void SaveSettings()
        {
            if (!formLoading)
            {
                settings.BearerToken = tbToken.Text;
                settings.DestinationFolder = tbDestinationFolder.Text;
                settings.WorkingFolder = tbWorkingFolder.Text;
                settings.FromDate = dateTimePickerFrom.Value.Date;
                settings.ToDate = dateTimePickerTo.Value.Date;
                settings.DestinationSubFolder = tbFolderName.Text;
                settings.StoreSettings();
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
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = settings.Persons.Count;
            progressBar.Value = 0;
            progressBar.Step = 1;

            string resultPath = Path.Combine(settings.DestinationFolder, settings.DestinationSubFolder);
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

            bool stop = false;
            int i = 0;
            foreach (var person in settings.Persons.OrderBy(p => p.Name))
            {
                progressBar.PerformStep();
                if (!stop)
                {
                    try
                    {
                        var icsResult = new XeduleAPIHelper(settings.FromDate, settings.ToDate, person.XeduleId) { BearerToken = settings.BearerToken }.CallAPI();
                        UpdateICSFileHelper helper = new(icsResult, person.Name)
                        {
                            ResultPath = resultPath,
                            RemoveAllAttendees = true,
                            AddXeduleCategory = true
                        };
                        var res = helper.HandleFile();
                        i++;
                    }
                    catch (Exception ex)
                    {
                        stop = true;
                        MessageBox.Show($"Something went wrong. Error: {ex.Message}");
                    }
                }
            }
            MessageBox.Show($"{i} persons processed!");
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

        private void tbToken_Click(object sender, EventArgs e)
        {
            tbToken.SelectAll();
        }
    }
}
