using System.Windows.Controls;
using System.Windows.Media;

namespace WpfOfficeTheme
{
    public static class TreeViewItemExtension
    {
        public static int GetDepth(this TreeViewItem item)
        {
            var parent = GetParent(item);
            while ((GetParent(item)) != null)
            {
                return GetDepth(parent) + 1;
            }
            return 0;
        }

        public static TreeViewItem GetParent(this TreeViewItem item)
        {
            var parent  = VisualTreeHelper.GetParent(item);
            while (!(parent is TreeViewItem || parent is TreeView))
            {
                if (parent == null) return null;
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as TreeViewItem;
        }
    }
}