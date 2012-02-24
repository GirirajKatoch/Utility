using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utility.Windows.Forms
{
    public static class UiThreadExtensions
    {
        static public void SafeInvoke(this Control control, Action code)
        {
            if (control == null) { return; }

            if (control.InvokeRequired)
            {
                control.Invoke(code);

                return;
            }
            code.Invoke();
        }
    }
}
