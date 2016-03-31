using System.Windows;
using System.Windows.Media;

namespace WpfOfficeTheme
{
    public static class ColorExtension
    {
        private const string AccentBrush = "AccentBrush";
        private const string AccentColor = "AccentColor";
        private const string MouseOverBorderBrush = "MouseOver.BorderBrush";
        private const string MouseOverBorderColor = "MouseOver.BorderColor";
        private const string MouseOverBackgroundBrush = "MouseOver.BackgroundBrush";
        private const string MouseOverBackgroundColor = "MouseOver.BackgroundColor";
        private const string PressedBackgroundBrush = "Pressed.BackgroundBrush";
        private const string PressedBackgroundColor = "Pressed.BackgroundColor";
        private const string PressedBorderBrush = "Pressed.BorderBrush";
        private const string PressedBorderColor = "Pressed.BorderColor";
        private static ResourceDictionary _accentResources;

        public static void CreateAccentColors(this Color color)
        {
            var accentColor = Application.Current.TryFindResource(AccentBrush) as SolidColorBrush;

            if (accentColor != null) return;

            if (_accentResources != null)
            {
                _accentResources.AddResources(color);
            }

            var resources = new ResourceDictionary();
            resources.AddResources(color);
            var application = Application.Current;
            var applicationResources = application.Resources;
            applicationResources.MergedDictionaries.Insert(0, resources);
            _accentResources = resources;
        }

        private static void AddResources(this ResourceDictionary resources, Color color)
        {
            resources.Add(AccentColor, color);
            resources.Add(MouseOverBorderColor, color.GetMouseOverBorderColor());
            resources.Add(MouseOverBackgroundColor, color.GetMouseOverBackgroundColor());
            resources.Add(PressedBorderColor, color.GetPressedBorderColor());
            resources.Add(PressedBackgroundColor, color.GetPressedBackgroundColor());

            resources.Add(AccentBrush, new SolidColorBrush((Color) resources[AccentColor]));
            resources.Add(MouseOverBorderBrush, new SolidColorBrush((Color) resources[MouseOverBorderColor]));
            resources.Add(MouseOverBackgroundBrush, new SolidColorBrush((Color) resources[MouseOverBackgroundColor]));
            resources.Add(PressedBorderBrush, new SolidColorBrush((Color)resources[PressedBorderColor]));
            resources.Add(PressedBackgroundBrush, new SolidColorBrush((Color)resources[PressedBackgroundColor]));
        }

        private static Color GetMouseOverBackgroundColor(this Color color)
        {
            return Color.FromArgb(30, color.R, color.G, color.B);
        }

        private static Color GetMouseOverBorderColor(this Color color)
        {
            return Color.FromArgb(70, color.R, color.G, color.B);
        }

        private static Color GetPressedBackgroundColor(this Color color)
        {
            return Color.FromArgb(70, color.R, color.G, color.B);
        }

        private static Color GetPressedBorderColor(this Color color)
        {
            return Color.FromArgb(100, color.R, color.G, color.B);
        }
    }
}