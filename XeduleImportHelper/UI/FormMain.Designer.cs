
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
            this.groupProcess = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupProcess.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.cbAddCategory.Size = new System.Drawing.Size(183, 24);
            this.cbAddCategory.TabIndex = 3;
            this.cbAddCategory.Text = "Add category \"Xedule\"";
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
            // groupProcess
            // 
            this.groupProcess.Controls.Add(this.cbRemoveAttendees);
            this.groupProcess.Controls.Add(this.btnProcessFile);
            this.groupProcess.Controls.Add(this.cbAddCategory);
            this.groupProcess.Enabled = false;
            this.groupProcess.Location = new System.Drawing.Point(14, 280);
            this.groupProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupProcess.Name = "groupProcess";
            this.groupProcess.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupProcess.Size = new System.Drawing.Size(375, 165);
            this.groupProcess.TabIndex = 5;
            this.groupProcess.TabStop = false;
            this.groupProcess.Text = "Process";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectICSFile);
            this.groupBox1.Controls.Add(this.lblFilename);
            this.groupBox1.Location = new System.Drawing.Point(14, 125);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(375, 147);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select file";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 36);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(374, 81);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupProcess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "Importhelper for Xedule";
            this.groupProcess.ResumeLayout(false);
            this.groupProcess.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openICSFileDialog;
        private System.Windows.Forms.Button btnSelectICSFile;
        private System.Windows.Forms.Button btnProcessFile;
        private System.Windows.Forms.CheckBox cbRemoveAttendees;
        private System.Windows.Forms.CheckBox cbAddCategory;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.GroupBox groupProcess;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}