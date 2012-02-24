using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utility.Windows.Forms
{
    public static partial class Extensions
    {

        public static TreeNode GetParentWhere(this TreeNode node, Func<TreeNode, bool> where)
        {
            if (node.Parent != null)
            {
                if (where(node.Parent))
                {
                    return node.Parent;
                }

                return node.Parent.GetParentWhere(where);
            }

            return null;
        }

        public static bool ContainsDataBoundItem(this TreeNodeCollection container, object dataBoundItem)
        {
            var nodes = container.OfType<TreeNode>();

            if (dataBoundItem is DateTime)
            {
                DateTime day = (DateTime)dataBoundItem;

                bool found = nodes.Any(r => r.Tag is DateTime && ((DateTime)r.Tag).ToDay() == day);

                return found;
            }

            return nodes.Any(r => r.Tag == dataBoundItem);
        }

        public static TreeNode FindByDataBoundItem(this TreeNodeCollection container, object dataBoundItem)
        {
            var nodes = container.OfType<TreeNode>();

            if (dataBoundItem is DateTime)
            {
                DateTime day = (DateTime)dataBoundItem;

                TreeNode node = nodes.FirstOrDefault(r => r.Tag is DateTime && ((DateTime)r.Tag).ToDay() == day);

                return node;
            }

            return nodes.FirstOrDefault(r => r.Tag == dataBoundItem);
        }
    }
}
