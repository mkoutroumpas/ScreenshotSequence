using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotSequence
{
    public partial class MainForm : Form
    {
        #region Members

        private string _folderPath = "";
        private bool _proceed = true;
        private Random _random;

        private CancellationTokenSource _source = null;
        private IntPtr _selectedAppHandle = default(IntPtr);

        private readonly string _appFriendlyName;
        private readonly Screenshot _screenshot = null;
        private readonly List<Bitmap> _images = null;

        #endregion

        #region Initialization

        public MainForm()
        {
            InitializeComponent();

            _appFriendlyName = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "");

            _random = new Random();

            _images = new List<Bitmap>();
            _screenshot = new Screenshot();
        }

        #endregion

        #region UI interaction

        private void MainForm_Load(object sender, EventArgs e)
        {
            EnableControls(true);

            LoadAvailableApps();
        }

        private async void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F11)
            {
                await Start();
            }
            else if (e.KeyChar == (char)Keys.F12)
            {
                BreakCurrentCaptureSequence();
            }

            e.Handled = true;
        }

        private void LoadAvailableApps()
        {
            var apps = new List<string>();
            foreach (var p in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(p.MainWindowTitle) && !p.MainWindowTitle.Contains(_appFriendlyName))
                {
                    apps.Add(p.MainWindowTitle);
                }
            }

            lbAvailableApps.DataSource = apps;
        }

        private IntPtr GetAppWindowHanle(string appname)
        {
            if (string.IsNullOrEmpty(appname))
                return default(IntPtr);

            foreach (var p in Process.GetProcesses())
            {
                if (p.MainWindowTitle.Contains(appname))
                {
                    return p.MainWindowHandle;
                }
            }

            return default(IntPtr);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAvailableApps();
        }

        private async void btnStartStop_Click(object sender, EventArgs e)
        {
            if (_proceed)
            {
                await Start();
            }
            else
            {
                BreakCurrentCaptureSequence();
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            var dialogResult = fbSelectFolder.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(fbSelectFolder.SelectedPath))
                {
                    _folderPath = fbSelectFolder.SelectedPath;
                    lblOutputDirectory.Text = "Output folder: " + _folderPath;
                }
            }
        }

        private void cbUsePrintScreen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EnableControls(bool enable)
        {
            _proceed = enable;

            btnStartStop.Text = enable ? "Start (F11)" : "Stop (F12)";

            nudInterval.Enabled = enable;
            nudDuration.Enabled = enable;
            btnSelectFolder.Enabled = enable;
            btnRefresh.Enabled = enable;
            cbClearFolder.Enabled = enable;
            cbUsePrintScreen.Enabled = enable;
            lbAvailableApps.Enabled = enable;
        }

        #endregion

        #region Flow control

        private async Task Start()
        {
            if (string.IsNullOrEmpty(_folderPath))
            {
                MessageBox.Show("You must select a target folder.", "Missing selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedAppHandle = GetAppWindowHanle(lbAvailableApps.SelectedItem.ToString());

            _source = new CancellationTokenSource((int)nudDuration.Value * 1000);

            EnableControls(false);

            _proceed = await Task.Run(() => StartNewCaptureSequence((int)nudInterval.Value * 1000, cbUsePrintScreen.Checked), _source.Token);

            EnableControls(!_proceed);

            DumpImages(cbClearFolder.Checked);

            _source.Dispose();
        }

        #endregion

        #region File I/O

        private void DumpImages(bool clear)
        {
            if (string.IsNullOrEmpty(_folderPath))
                return;

            DirectoryInfo di = new DirectoryInfo(_folderPath);

            if (!di.Exists)
            {
                MessageBox.Show("Directory " + _folderPath + " not found.", "Missing folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clear)
            {
                foreach (var file in di.GetFiles())
                {
                    if (file.Name.Contains(_appFriendlyName))
                    {
                        file.Delete();
                    }
                }
            }

            if (_images.Count > 0)
            {
                foreach (var image in _images)
                {
                    DumpImage(image, di);
                }
            }
        }

        private void DumpImage(Bitmap image, DirectoryInfo di) 
        {
            if (di == null || image == null)
                return;

            image.Save(Path.Combine(di.FullName, _appFriendlyName + "_" + GetRandomFileSuffix().Replace("-", "") + ".png"), ImageFormat.Png);
        }

        private string GetRandomFileSuffix()
        {
            return (_random.Next() * 900000000 + 100000000).ToString();
        }

        #endregion

        #region Capture

        private async Task<bool> StartNewCaptureSequence(int intervalms, bool screenshot = false)
        {
            if (_source == null)
                return false;

            _images.Clear();

            while (true)
            {
                if (_source.IsCancellationRequested)
                    return false;

                var image = screenshot ? _screenshot.PrintScreen() : CaptureScreenshot(_selectedAppHandle);
                if (image != null)
                {
                    _images.Add(image);
                }

                await Task.Delay(intervalms);
            }
        }

        private Bitmap CaptureScreenshot(IntPtr handle)
        {
            if (_selectedAppHandle == default(IntPtr))
                return null;

            return _screenshot?.CaptureWindow(handle);
        }

        private void BreakCurrentCaptureSequence()
        {
            _source.Cancel();
        }

        #endregion
    }
}
