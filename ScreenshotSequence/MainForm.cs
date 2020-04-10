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
        private int _imageSuffix = 0;

        private CancellationTokenSource _source = null;
        private IntPtr _selectedAppHandle = default(IntPtr);

        private readonly string _appFriendlyName;
        private readonly Screenshot _screenshot = null;
        private readonly List<Bitmap> _images = null;

        // This is a test change in branch change-one.

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

        private void ShowWritingImagesOnButton()
        {
            btnStartStop.Enabled = false;
            btnStartStop.Text = "Writing images ...";
            btnStartStop.Enabled = true;
        }

        private void EnableControls(bool enable)
        {
            _proceed = enable;

            btnStartStop.Text = enable ? "Start (F11)" : "Stop (F12)";

            nudXMargin.Enabled = enable;
            nudYMargin.Enabled = enable;
            nudInterval.Enabled = enable;
            nudDuration.Enabled = enable;
            nudStartupDelay.Enabled = enable;
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

            EnableControls(false);

            btnStartStop.Text = "Waiting ...";

            await Task.Delay((int)nudStartupDelay.Value * 1000);

            btnStartStop.Text = "Capturing ...";

            _selectedAppHandle = GetAppWindowHanle(lbAvailableApps.SelectedItem.ToString());

            _imageSuffix = _random.Next() * 900000000 + 100000000;

            _source = new CancellationTokenSource((int)nudDuration.Value * 1000);

            await Task.Run(() => StartNewCaptureSequence((int)nudInterval.Value * 1000, cbUsePrintScreen.Checked, (int)nudXMargin.Value, (int)nudYMargin.Value), _source.Token);

            ShowWritingImagesOnButton();

            await DumpImages(cbClearFolder.Checked);

            EnableControls(true);
        }

        #endregion

        #region File I/O

        private async Task DumpImages(bool clear)
        {
            if (string.IsNullOrEmpty(_folderPath))
                return;

            DirectoryInfo di = new DirectoryInfo(_folderPath);

            if (!di.Exists)
            {
                MessageBox.Show("Directory " + _folderPath + " not found.", "Missing folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await Task.Run(() =>
            {
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
                    for (int i = 0; i < _images.Count; i++)
                    {
                        DumpImage(_images[i], di, i);
                    }
                }
            });
        }

        private void DumpImage(Bitmap image, DirectoryInfo di, int i) 
        {
            if (di == null || image == null)
                return;

            image.Save(Path.Combine(di.FullName, _appFriendlyName + "_" + (_imageSuffix + i) + ".png"), ImageFormat.Png);
        }

        #endregion

        #region Capture

        private async Task StartNewCaptureSequence(int intervalms, bool screenshot = false, int xmargin = 0, int ymargin = 0)
        {
            if (_source == null)
                return;

            _images.Clear();

            while (true)
            {
                if (_source.IsCancellationRequested)
                    return;

                await Task.Delay(intervalms);

                var image = screenshot ? _screenshot.PrintScreen(xmargin, ymargin) : CaptureScreenshot(_selectedAppHandle);
                if (image != null)
                {
                    _images.Add(image);
                }
            }
        }

        private Bitmap CaptureScreenshot(IntPtr handle)
        {
            if (_selectedAppHandle == default(IntPtr))
                return null;

            return _screenshot.CaptureWindow(handle);
        }

        private void BreakCurrentCaptureSequence()
        {
            _source.Cancel();
        }

        #endregion
    }
}
