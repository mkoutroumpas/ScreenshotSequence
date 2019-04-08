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
            this.cbUsePrintScreen = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbAvailableApps = new System.Windows.Forms.ListBox();
            this.lblOpenApps = new System.Windows.Forms.Label();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.lblCaptureDuration = new System.Windows.Forms.Label();
            this.cbClearFolder = new System.Windows.Forms.CheckBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.fbSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.nudXMargin = new System.Windows.Forms.NumericUpDown();
            this.lblXMargin = new System.Windows.Forms.Label();
            this.nudYMargin = new System.Windows.Forms.NumericUpDown();
            this.lblYMargin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(22, 321);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(481, 66);
            this.btnStartStop.TabIndex = 5;
            this.btnStartStop.Text = "Start (F11)";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // nudInterval
            // 
            this.nudInterval.DecimalPlaces = 1;
            this.nudInterval.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudInterval.Location = new System.Drawing.Point(415, 190);
            this.nudInterval.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(89, 20);
            this.nudInterval.TabIndex = 2;
            this.nudInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(272, 192);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(133, 13);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "Capture interval (seconds):";
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.AutoSize = true;
            this.lblOutputDirectory.Location = new System.Drawing.Point(31, 238);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(71, 13);
            this.lblOutputDirectory.TabIndex = 3;
            this.lblOutputDirectory.Text = "Output folder:";
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.nudXMargin);
            this.pnlMain.Controls.Add(this.lblXMargin);
            this.pnlMain.Controls.Add(this.nudYMargin);
            this.pnlMain.Controls.Add(this.lblYMargin);
            this.pnlMain.Controls.Add(this.cbUsePrintScreen);
            this.pnlMain.Controls.Add(this.btnRefresh);
            this.pnlMain.Controls.Add(this.lbAvailableApps);
            this.pnlMain.Controls.Add(this.lblOpenApps);
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
            this.pnlMain.Size = new System.Drawing.Size(525, 402);
            this.pnlMain.TabIndex = 4;
            // 
            // cbUsePrintScreen
            // 
            this.cbUsePrintScreen.AutoSize = true;
            this.cbUsePrintScreen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUsePrintScreen.Checked = true;
            this.cbUsePrintScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUsePrintScreen.Location = new System.Drawing.Point(22, 29);
            this.cbUsePrintScreen.Name = "cbUsePrintScreen";
            this.cbUsePrintScreen.Size = new System.Drawing.Size(107, 17);
            this.cbUsePrintScreen.TabIndex = 12;
            this.cbUsePrintScreen.Text = "Use Print screen:";
            this.cbUsePrintScreen.UseVisualStyleBackColor = true;
            this.cbUsePrintScreen.CheckedChanged += new System.EventHandler(this.cbUsePrintScreen_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(26, 94);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(91, 53);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbAvailableApps
            // 
            this.lbAvailableApps.FormattingEnabled = true;
            this.lbAvailableApps.Location = new System.Drawing.Point(123, 65);
            this.lbAvailableApps.Name = "lbAvailableApps";
            this.lbAvailableApps.Size = new System.Drawing.Size(380, 82);
            this.lbAvailableApps.TabIndex = 0;
            // 
            // lblOpenApps
            // 
            this.lblOpenApps.AutoSize = true;
            this.lblOpenApps.Location = new System.Drawing.Point(23, 66);
            this.lblOpenApps.Name = "lblOpenApps";
            this.lblOpenApps.Size = new System.Drawing.Size(94, 13);
            this.lblOpenApps.TabIndex = 10;
            this.lblOpenApps.Text = "Select application:";
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(103, 238);
            this.lblDirectory.MaximumSize = new System.Drawing.Size(140, 0);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(0, 13);
            this.lblDirectory.TabIndex = 9;
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(415, 164);
            this.nudDuration.Maximum = new decimal(new int[] {
            60,
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
            this.nudDuration.TabIndex = 1;
            this.nudDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCaptureDuration
            // 
            this.lblCaptureDuration.AutoSize = true;
            this.lblCaptureDuration.Location = new System.Drawing.Point(272, 166);
            this.lblCaptureDuration.Name = "lblCaptureDuration";
            this.lblCaptureDuration.Size = new System.Drawing.Size(137, 13);
            this.lblCaptureDuration.TabIndex = 8;
            this.lblCaptureDuration.Text = "Capture duration (seconds):";
            // 
            // cbClearFolder
            // 
            this.cbClearFolder.AutoSize = true;
            this.cbClearFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbClearFolder.Location = new System.Drawing.Point(30, 267);
            this.cbClearFolder.Name = "cbClearFolder";
            this.cbClearFolder.Size = new System.Drawing.Size(139, 17);
            this.cbClearFolder.TabIndex = 4;
            this.cbClearFolder.Text = "Empty output folder first:";
            this.cbClearFolder.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(468, 233);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(35, 22);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // nudXMargin
            // 
            this.nudXMargin.Location = new System.Drawing.Point(123, 166);
            this.nudXMargin.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudXMargin.Name = "nudXMargin";
            this.nudXMargin.Size = new System.Drawing.Size(89, 20);
            this.nudXMargin.TabIndex = 13;
            this.nudXMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblXMargin
            // 
            this.lblXMargin.AutoSize = true;
            this.lblXMargin.Location = new System.Drawing.Point(31, 166);
            this.lblXMargin.Name = "lblXMargin";
            this.lblXMargin.Size = new System.Drawing.Size(86, 13);
            this.lblXMargin.TabIndex = 16;
            this.lblXMargin.Text = "X margin (pixels):";
            // 
            // nudYMargin
            // 
            this.nudYMargin.Location = new System.Drawing.Point(123, 192);
            this.nudYMargin.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudYMargin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudYMargin.Name = "nudYMargin";
            this.nudYMargin.Size = new System.Drawing.Size(89, 20);
            this.nudYMargin.TabIndex = 14;
            this.nudYMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblYMargin
            // 
            this.lblYMargin.AutoSize = true;
            this.lblYMargin.Location = new System.Drawing.Point(31, 192);
            this.lblYMargin.Name = "lblYMargin";
            this.lblYMargin.Size = new System.Drawing.Size(86, 13);
            this.lblYMargin.TabIndex = 15;
            this.lblYMargin.Text = "Y margin (pixels):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 426);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Capture Screenshot Sequence";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYMargin)).EndInit();
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
        private ListBox lbAvailableApps;
        private Label lblOpenApps;
        private Button btnRefresh;
        private CheckBox cbUsePrintScreen;
        private NumericUpDown nudXMargin;
        private Label lblXMargin;
        private NumericUpDown nudYMargin;
        private Label lblYMargin;
    }
}

