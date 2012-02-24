using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Events
{
    /// <summary>
    /// http://houseofbilz.com/archive/2009/02/15/re-thinking-c-events.aspx
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            this.value = value;
        }

        private T value;

        public T Value
        {
            get { return this.value; }
        }
    }
}
