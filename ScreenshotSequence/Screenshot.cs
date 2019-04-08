using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenshotSequence
{
    public class Screenshot
    {
        public Bitmap PrintScreen(int xmargin = 0, int ymargin = 0)
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width - 2 * xmargin, Screen.PrimaryScreen.Bounds.Height - 2 * ymargin);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(xmargin, ymargin, 0, 0, printscreen.Size);

            return printscreen;
        }

        public Bitmap CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }

        public Bitmap CaptureWindow()
        {
            var foregroundWindowsHandle = User32.GetForegroundWindow();
            var rect = new User32.RECT();
            User32.GetWindowRect(foregroundWindowsHandle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var g = Graphics.FromImage(result))
            {
                g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }

        public Bitmap CaptureWindow(IntPtr handle)
        {
            IntPtr hdcSrc = User32.GetWindowDC(handle);

            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.Right - windowRect.Left;
            int height = windowRect.Bottom - windowRect.Top;
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            GDI32.SelectObject(hdcDest, hOld);
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            Bitmap img = Image.FromHbitmap(hBitmap);
            GDI32.DeleteObject(hBitmap);

            return img;
        }

        #region Windows API interfaces

        class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();
        }

        class GDI32
        {

            public const int SRCCOPY = 0x00CC0020;
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        #endregion
    }
}
