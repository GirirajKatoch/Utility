using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Utility.Windows.Forms
{
    public class AeroForm : System.Windows.Forms.Form
    {
        protected bool EnableClientExpand = true;
        protected bool EnableTransparency = true;

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;      // width of left border that retains its size
            public int cxRightWidth;     // width of right border that retains its size
            public int cyTopHeight;      // height of top border that retains its size
            public int cyBottomHeight;   // height of bottom border that retains its size
        }

        [DllImport("DwmApi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS pMarInset);

        protected override void OnLoad(EventArgs e)
        {
            MARGINS margins = new MARGINS()
            {
                cxLeftWidth = 1,
                cxRightWidth = 1,
                cyBottomHeight = 1,
                cyTopHeight = -1
            };

            if (this.EnableClientExpand)
            {
                int result = DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                //this.BackColor = Color.Gainsboro;
            }

            base.OnLoad(e);
        }

        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        public void FadeIn(int duration)
        {
            AnimateWindow(this.Handle, duration, 0X80000 | 0X20000);
        }

        public void FadeOut(int duration)
        {
            AnimateWindow(this.Handle, duration, 0X80000 | 0X10000);
        }

        protected bool UnMovable = false;

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;

        protected override void WndProc(ref Message message)
        {
            if (this.UnMovable) {
                switch(message.Msg)
                {
                    case WM_SYSCOMMAND:
                        int command = message.WParam.ToInt32() & 0xfff0;
                        if (command == SC_MOVE)
                        return;
                        break;
                }
            }
            base.WndProc(ref message);
        }
    }
}
