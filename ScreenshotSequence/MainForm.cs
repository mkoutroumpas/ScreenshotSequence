using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotSequence
{
    public partial class MainForm : Form
    {
        private IntPtr _selectedAppHandle = default(IntPtr);
        private string _folderPath = "";
        private bool _isStarted = false;
        private CancellationTokenSource _source = null;

        #region Initialization

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _source = new CancellationTokenSource((int)nudDuration.Value * 1000);

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
                Stop();
            }

            e.Handled = true;
        }

        private void LoadAvailableApps()
        {
            string appFriendlyName = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "");

            var apps = new List<string>();
            foreach (var p in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(p.MainWindowTitle) && !p.MainWindowTitle.Contains(appFriendlyName))
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

        #endregion

        #region UI interaction

        private async void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!_isStarted)
            {
                await Start();
            }
            else
            {
                Stop();
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
                    lblOutputDirectory.Text = _folderPath;
                }
            }
        }

        private void EnableControls(bool enable)
        {
            nudInterval.Enabled = enable;
            nudDuration.Enabled = enable;
            btnSelectFolder.Enabled = enable;
            cbClearFolder.Enabled = enable;
            lbAvailableApps.Enabled = enable;

            btnStartStop.Text = enable ? "Start (F11)" : "Stop (F12)";
        }

        #endregion

        #region Capture

        private async Task Start()
        {
            EnableControls(false);

            _selectedAppHandle = GetAppWindowHanle(lbAvailableApps.SelectedItem.ToString());

            _isStarted = true;

            await Task.Run(() => StartNewCaptureSequence((int)nudInterval.Value * 1000), _source.Token).ConfigureAwait(false);
        }

        private void Stop()
        {
            BreakCurrentCaptureSequence();

            EnableControls(true);

            _isStarted = false;
        }

        private void StartNewCaptureSequence(int intervalms)
        {
            if (_source == null)
                return;

            int cTicks = Environment.TickCount;

            while (true)
            {
                if (_source.IsCancellationRequested)
                {
                    Stop();

                    return;
                }

                if (Environment.TickCount == cTicks + intervalms)
                {
                    cTicks = Environment.TickCount;

                    CaptureScreenshot();
                }
            }
        }

        private void CaptureScreenshot()
        {
            
        }

        private void BreakCurrentCaptureSequence()
        {
            _source?.Cancel();
        }

        #endregion
    }
}
