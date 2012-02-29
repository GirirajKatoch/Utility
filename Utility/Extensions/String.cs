using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace System
{
    public static class StringExtensions
    {
        public static Nullable<T> ToNullable<T>(this string s) where T : struct
        {
            Nullable<T> result = new Nullable<T>();
            try
            {
                if (!string.IsNullOrEmpty(s))
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                    result = (T)conv.ConvertFrom(s);
                }
            }
            catch { }
            return result;
        }

        public static string MaximumLength(this string s, int length)
        {
            return s.MaximumLength(length, String.Empty);
        }

        public static string MaximumLength(this string s, int length, string ellipsis)
        {
            if (String.IsNullOrWhiteSpace(s)) { return s; }

            return s.Length > length ? s.Substring(0, length - ellipsis.Length) + ellipsis : s;
        }
    }
}
