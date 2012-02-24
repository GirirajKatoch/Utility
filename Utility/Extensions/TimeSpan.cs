using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class TimeSpanExtension
    {
        public static System.TimeSpan WholeSeconds(this System.TimeSpan timeSpan)
        {
            return System.TimeSpan.FromSeconds(Math.Round(timeSpan.TotalSeconds));
        }

        public static string ToNiceString(this System.TimeSpan timeSpan)
        {
            string nice = String.Empty;

            if (timeSpan.TotalHours >= 1)
            {
                nice += Math.Floor(timeSpan.TotalHours).ToString() + "h";
            }
            if (timeSpan.Minutes > 0)
            {
                nice += " " + timeSpan.Minutes.ToString() + "m";
            }
            if (timeSpan.Seconds > 0)
            {
                nice += " " + timeSpan.Seconds.ToString() + "s";
            }

            return nice.Trim();
        }
    }
}
