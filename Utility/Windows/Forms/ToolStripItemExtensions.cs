using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utility.Windows.Forms
{
    public static partial class ToolStripDropDownItemExtensions
    {
        public static ToolStripDropDownItem FindByTag<T>(this ToolStripDropDownItem item, T tag) where T : class
        {
            if (item.Tag is T)
            {
                if (item.Tag as T == tag)
                {
                    return item;
                }
            }

            if (item.HasDropDownItems)
            {
                foreach (ToolStripItem child in item.DropDownItems)
                {
                    if (child is ToolStripDropDownItem)
                    {
                        var found = ((ToolStripDropDownItem)child).FindByTag<T>(tag);

                        if (found != null)
                        {
                            return found;
                        }
                    }
                }
            }

            return null;
        }
    }
}
