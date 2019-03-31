using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotSequence
{
    public partial class MainForm : Form
    {
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

            btnStartStop.Text = enable ? "Start (F11)" : "Stop (F12)";
        }

        #endregion

        #region Capture

        private async Task Start()
        {
            EnableControls(false);

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
