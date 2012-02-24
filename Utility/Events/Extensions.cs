using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Events
{
    public static class Extensions
    {
        /// <summary>
        /// http://houseofbilz.com/archive/2009/02/15/re-thinking-c-events.aspx
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        /// <param name="sender"></param>
        /// <param name="payload"></param>
        public static void Fire<T>(this EventHandler<EventArgs<T>> handler, object sender, T payload)
        {
            if (handler != null)
            {
                handler(sender, new EventArgs<T>(payload));
            }
        }
    }
}
