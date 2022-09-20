
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
            this.openICSFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectICSFile = new System.Windows.Forms.Button();
            this.btnProcessFile = new System.Windows.Forms.Button();
            this.cbRemoveAttendees = new System.Windows.Forms.CheckBox();
            this.cbAddCategory = new System.Windows.Forms.CheckBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.groupBoxProcess = new System.Windows.Forms.GroupBox();
            this.groupBoxSelectFile = new System.Windows.Forms.GroupBox();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkLabelInfo = new System.Windows.Forms.LinkLabel();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.groupBoxProcess.SuspendLayout();
            this.groupBoxSelectFile.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // openICSFileDialog
            // 
            this.openICSFileDialog.FileName = "openFileDialog1";
            // 
            // btnSelectICSFile
            // 
            this.btnSelectICSFile.Location = new System.Drawing.Point(13, 29);
            this.btnSelectICSFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectICSFile.Name = "btnSelectICSFile";
            this.btnSelectICSFile.Size = new System.Drawing.Size(137, 31);
            this.btnSelectICSFile.TabIndex = 0;
            this.btnSelectICSFile.Text = "Select ICS file";
            this.btnSelectICSFile.UseVisualStyleBackColor = true;
            this.btnSelectICSFile.Click += new System.EventHandler(this.BtnSelectICSFile_Click);
            // 
            // btnProcessFile
            // 
            this.btnProcessFile.Location = new System.Drawing.Point(18, 109);
            this.btnProcessFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProcessFile.Name = "btnProcessFile";
            this.btnProcessFile.Size = new System.Drawing.Size(137, 31);
            this.btnProcessFile.TabIndex = 1;
            this.btnProcessFile.Text = "Process and save";
            this.btnProcessFile.UseVisualStyleBackColor = true;
            this.btnProcessFile.Click += new System.EventHandler(this.BtnProcessFile_Click);
            // 
            // cbRemoveAttendees
            // 
            this.cbRemoveAttendees.AutoSize = true;
            this.cbRemoveAttendees.Checked = true;
            this.cbRemoveAttendees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemoveAttendees.Location = new System.Drawing.Point(18, 29);
            this.cbRemoveAttendees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRemoveAttendees.Name = "cbRemoveAttendees";
            this.cbRemoveAttendees.Size = new System.Drawing.Size(174, 24);
            this.cbRemoveAttendees.TabIndex = 2;
            this.cbRemoveAttendees.Text = "Remove all attendees";
            this.cbRemoveAttendees.UseVisualStyleBackColor = true;
            // 
            // cbAddCategory
            // 
            this.cbAddCategory.AutoSize = true;
            this.cbAddCategory.Checked = true;
            this.cbAddCategory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAddCategory.Location = new System.Drawing.Point(18, 61);
            this.cbAddCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbAddCategory.Name = "cbAddCategory";
            this.cbAddCategory.Size = new System.Drawing.Size(121, 24);
            this.cbAddCategory.TabIndex = 3;
            this.cbAddCategory.Text = "Add category";
            this.cbAddCategory.UseVisualStyleBackColor = true;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(13, 69);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(151, 20);
            this.lblFilename.TabIndex = 4;
            this.lblFilename.Text = "Selected file: <none>";
            // 
            // groupBoxProcess
            // 
            this.groupBoxProcess.Controls.Add(this.tbCategory);
            this.groupBoxProcess.Controls.Add(this.cbRemoveAttendees);
            this.groupBoxProcess.Controls.Add(this.btnProcessFile);
            this.groupBoxProcess.Controls.Add(this.cbAddCategory);
            this.groupBoxProcess.Enabled = false;
            this.groupBoxProcess.Location = new System.Drawing.Point(14, 280);
            this.groupBoxProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxProcess.Name = "groupBoxProcess";
            this.groupBoxProcess.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxProcess.Size = new System.Drawing.Size(375, 165);
            this.groupBoxProcess.TabIndex = 5;
            this.groupBoxProcess.TabStop = false;
            this.groupBoxProcess.Text = "Process";
            // 
            // groupBoxSelectFile
            // 
            this.groupBoxSelectFile.Controls.Add(this.btnSelectICSFile);
            this.groupBoxSelectFile.Controls.Add(this.lblFilename);
            this.groupBoxSelectFile.Location = new System.Drawing.Point(14, 152);
            this.groupBoxSelectFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxSelectFile.Name = "groupBoxSelectFile";
            this.groupBoxSelectFile.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxSelectFile.Size = new System.Drawing.Size(375, 120);
            this.groupBoxSelectFile.TabIndex = 6;
            this.groupBoxSelectFile.TabStop = false;
            this.groupBoxSelectFile.Text = "Select file";
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.labelVersion);
            this.groupBoxInfo.Controls.Add(this.linkLabelInfo);
            this.groupBoxInfo.Location = new System.Drawing.Point(15, 36);
            this.groupBoxInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxInfo.Size = new System.Drawing.Size(374, 108);
            this.groupBoxInfo.TabIndex = 7;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(11, 56);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(64, 20);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "Version: ";
            // 
            // linkLabelInfo
            // 
            this.linkLabelInfo.AutoSize = true;
            this.linkLabelInfo.Location = new System.Drawing.Point(11, 31);
            this.linkLabelInfo.Name = "linkLabelInfo";
            this.linkLabelInfo.Size = new System.Drawing.Size(148, 20);
            this.linkLabelInfo.TabIndex = 0;
            this.linkLabelInfo.TabStop = true;
            this.linkLabelInfo.Text = "Online documentatie";
            this.linkLabelInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInfo_LinkClicked);
            // 
            // tbCategory
            // 
            this.tbCategory.Location = new System.Drawing.Point(145, 59);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(125, 27);
            this.tbCategory.TabIndex = 4;
            this.tbCategory.Text = "Xedule";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 473);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.groupBoxSelectFile);
            this.Controls.Add(this.groupBoxProcess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "Importhelper for Xedule";
            this.groupBoxProcess.ResumeLayout(false);
            this.groupBoxProcess.PerformLayout();
            this.groupBoxSelectFile.ResumeLayout(false);
            this.groupBoxSelectFile.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openICSFileDialog;
        private System.Windows.Forms.Button btnSelectICSFile;
        private System.Windows.Forms.Button btnProcessFile;
        private System.Windows.Forms.CheckBox cbRemoveAttendees;
        private System.Windows.Forms.CheckBox cbAddCategory;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.GroupBox groupBoxProcess;
        private System.Windows.Forms.GroupBox groupBoxSelectFile;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.LinkLabel linkLabelInfo;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TextBox tbCategory;
    }
}