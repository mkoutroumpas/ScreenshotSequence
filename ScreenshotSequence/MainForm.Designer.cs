using System.Windows.Forms;

namespace ScreenshotSequence
{
    partial class MainForm
    {
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

            _source?.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartStop = new System.Windows.Forms.Button();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblOutputDirectory = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.lblCaptureDuration = new System.Windows.Forms.Label();
            this.cbClearFolder = new System.Windows.Forms.CheckBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.fbSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblDirectory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(22, 219);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(286, 66);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start (F11)";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // nudInterval
            // 
            this.nudInterval.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudInterval.Location = new System.Drawing.Point(219, 108);
            this.nudInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(89, 20);
            this.nudInterval.TabIndex = 1;
            this.nudInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(23, 110);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(133, 13);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "Capture interval (seconds):";
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.AutoSize = true;
            this.lblOutputDirectory.Location = new System.Drawing.Point(23, 144);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(71, 13);
            this.lblOutputDirectory.TabIndex = 3;
            this.lblOutputDirectory.Text = "Output folder:";
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblDirectory);
            this.pnlMain.Controls.Add(this.nudDuration);
            this.pnlMain.Controls.Add(this.lblCaptureDuration);
            this.pnlMain.Controls.Add(this.cbClearFolder);
            this.pnlMain.Controls.Add(this.btnSelectFolder);
            this.pnlMain.Controls.Add(this.btnStartStop);
            this.pnlMain.Controls.Add(this.lblOutputDirectory);
            this.pnlMain.Controls.Add(this.nudInterval);
            this.pnlMain.Controls.Add(this.lblInterval);
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(329, 302);
            this.pnlMain.TabIndex = 4;
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(219, 73);
            this.nudDuration.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(89, 20);
            this.nudDuration.TabIndex = 7;
            this.nudDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCaptureDuration
            // 
            this.lblCaptureDuration.AutoSize = true;
            this.lblCaptureDuration.Location = new System.Drawing.Point(23, 75);
            this.lblCaptureDuration.Name = "lblCaptureDuration";
            this.lblCaptureDuration.Size = new System.Drawing.Size(137, 13);
            this.lblCaptureDuration.TabIndex = 8;
            this.lblCaptureDuration.Text = "Capture duration (seconds):";
            // 
            // cbClearFolder
            // 
            this.cbClearFolder.AutoSize = true;
            this.cbClearFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbClearFolder.Location = new System.Drawing.Point(22, 176);
            this.cbClearFolder.Name = "cbClearFolder";
            this.cbClearFolder.Size = new System.Drawing.Size(149, 17);
            this.cbClearFolder.TabIndex = 6;
            this.cbClearFolder.Text = "Empty selected folder first:";
            this.cbClearFolder.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(273, 139);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(35, 22);
            this.btnSelectFolder.TabIndex = 4;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(95, 144);
            this.lblDirectory.MaximumSize = new System.Drawing.Size(140, 0);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(0, 13);
            this.lblDirectory.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 326);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Capture Screenshot Sequence";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Label lblOutputDirectory;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FolderBrowserDialog fbSelectFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.CheckBox cbClearFolder;
        private NumericUpDown nudDuration;
        private Label lblCaptureDuration;
        private Label lblDirectory;
    }
}

