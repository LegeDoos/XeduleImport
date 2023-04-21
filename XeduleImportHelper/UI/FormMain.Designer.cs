
namespace XeduleImportHelper.UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            openICSFileDialog = new System.Windows.Forms.OpenFileDialog();
            btnProcessFile = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            tbToken = new System.Windows.Forms.TextBox();
            tbDestinationFolder = new System.Windows.Forms.TextBox();
            tbWorkingFolder = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            tbFolderName = new System.Windows.Forms.TextBox();
            labelToken = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            labelFolderName = new System.Windows.Forms.Label();
            labelTo = new System.Windows.Forms.Label();
            dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            labelFromDate = new System.Windows.Forms.Label();
            dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            progressBar = new System.Windows.Forms.ProgressBar();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // openICSFileDialog
            // 
            openICSFileDialog.FileName = "openFileDialog1";
            // 
            // btnProcessFile
            // 
            btnProcessFile.Location = new System.Drawing.Point(196, 187);
            btnProcessFile.Name = "btnProcessFile";
            btnProcessFile.Size = new System.Drawing.Size(120, 23);
            btnProcessFile.TabIndex = 6;
            btnProcessFile.Text = "Process and save";
            btnProcessFile.UseVisualStyleBackColor = true;
            btnProcessFile.Click += btnProcessFile_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tbToken);
            panel1.Controls.Add(tbDestinationFolder);
            panel1.Controls.Add(btnProcessFile);
            panel1.Controls.Add(tbWorkingFolder);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbFolderName);
            panel1.Controls.Add(labelToken);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelFolderName);
            panel1.Controls.Add(labelTo);
            panel1.Controls.Add(dateTimePickerTo);
            panel1.Controls.Add(labelFromDate);
            panel1.Controls.Add(dateTimePickerFrom);
            panel1.Location = new System.Drawing.Point(12, 8);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(360, 227);
            panel1.TabIndex = 7;
            // 
            // tbToken
            // 
            tbToken.Location = new System.Drawing.Point(116, 158);
            tbToken.Name = "tbToken";
            tbToken.Size = new System.Drawing.Size(200, 23);
            tbToken.TabIndex = 5;
            tbToken.Leave += tbToken_Leave;
            // 
            // tbDestinationFolder
            // 
            tbDestinationFolder.Location = new System.Drawing.Point(116, 129);
            tbDestinationFolder.Name = "tbDestinationFolder";
            tbDestinationFolder.Size = new System.Drawing.Size(200, 23);
            tbDestinationFolder.TabIndex = 4;
            tbDestinationFolder.Click += tbDestinationFolder_Click;
            tbDestinationFolder.Leave += tbDestinationFolder_Leave;
            // 
            // tbWorkingFolder
            // 
            tbWorkingFolder.Enabled = false;
            tbWorkingFolder.Location = new System.Drawing.Point(116, 101);
            tbWorkingFolder.Name = "tbWorkingFolder";
            tbWorkingFolder.Size = new System.Drawing.Size(200, 23);
            tbWorkingFolder.TabIndex = 3;
            tbWorkingFolder.Leave += tbWorkingFolder_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 161);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 15);
            label2.TabIndex = 4;
            label2.Text = "Token:";
            // 
            // tbFolderName
            // 
            tbFolderName.Location = new System.Drawing.Point(116, 72);
            tbFolderName.Name = "tbFolderName";
            tbFolderName.Size = new System.Drawing.Size(200, 23);
            tbFolderName.TabIndex = 2;
            tbFolderName.Text = "2020BP1";
            tbFolderName.Leave += tbFolderName_Leave;
            // 
            // labelToken
            // 
            labelToken.AutoSize = true;
            labelToken.Location = new System.Drawing.Point(3, 132);
            labelToken.Name = "labelToken";
            labelToken.Size = new System.Drawing.Size(104, 15);
            labelToken.TabIndex = 4;
            labelToken.Text = "Destination folder:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 104);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 15);
            label1.TabIndex = 4;
            label1.Text = "Working folder:";
            // 
            // labelFolderName
            // 
            labelFolderName.AutoSize = true;
            labelFolderName.Location = new System.Drawing.Point(3, 75);
            labelFolderName.Name = "labelFolderName";
            labelFolderName.Size = new System.Drawing.Size(63, 15);
            labelFolderName.TabIndex = 4;
            labelFolderName.Text = "ICS Folder:";
            // 
            // labelTo
            // 
            labelTo.AutoSize = true;
            labelTo.Location = new System.Drawing.Point(3, 50);
            labelTo.Name = "labelTo";
            labelTo.Size = new System.Drawing.Size(22, 15);
            labelTo.TabIndex = 3;
            labelTo.Text = "To:";
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new System.Drawing.Point(116, 44);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new System.Drawing.Size(200, 23);
            dateTimePickerTo.TabIndex = 1;
            dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
            // 
            // labelFromDate
            // 
            labelFromDate.AutoSize = true;
            labelFromDate.Location = new System.Drawing.Point(3, 21);
            labelFromDate.Name = "labelFromDate";
            labelFromDate.Size = new System.Drawing.Size(38, 15);
            labelFromDate.TabIndex = 1;
            labelFromDate.Text = "From:";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new System.Drawing.Point(116, 15);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new System.Drawing.Size(200, 23);
            dateTimePickerFrom.TabIndex = 0;
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
            // 
            // folderBrowserDialog
            // 
            folderBrowserDialog.Description = "Select folder";
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(12, 241);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(360, 23);
            progressBar.TabIndex = 8;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(379, 271);
            Controls.Add(progressBar);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "ICS generator";
            FormClosing += FormMain_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openICSFileDialog;
        private System.Windows.Forms.Button btnProcessFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbWorkingFolder;
        private System.Windows.Forms.TextBox tbFolderName;
        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFolderName;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelFromDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.TextBox tbDestinationFolder;
        private System.Windows.Forms.TextBox tbToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}