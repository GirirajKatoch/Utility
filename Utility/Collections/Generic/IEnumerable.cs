using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    public static partial class IEnumerable
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }

        public static IEnumerable<T> RecursiveSelect<T>(this T parent, Func<T, IEnumerable<T>> getChildren)
        {
            foreach (T child in getChildren(parent))
            {
                yield return child;
                foreach (T grandChild in child.RecursiveSelect(getChildren))
                {
                    yield return grandChild;
                }
            }
        }
    }
}
