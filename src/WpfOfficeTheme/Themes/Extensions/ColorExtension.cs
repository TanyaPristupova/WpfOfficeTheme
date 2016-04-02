using System.Windows;
using System.Windows.Media;

namespace WpfOfficeTheme
{
    public static class ColorExtension
    {
        private const string AccentBrush = "AccentBrush";
        private const string AccentColor = "AccentColor";

        private const string AccentBrush1 = "AccentBrush1";
        private const string AccentColor1 = "AccentColor1";

        private const string MouseOverBorderBrush = "MouseOver.BorderBrush";
        private const string MouseOverBorderColor = "MouseOver.BorderColor";
        private const string MouseOverBackgroundBrush = "MouseOver.BackgroundBrush";
        private const string MouseOverBackgroundColor = "MouseOver.BackgroundColor";

        private const string PressedBackgroundBrush = "Pressed.BackgroundBrush";
        private const string PressedBackgroundColor = "Pressed.BackgroundColor";
        private const string PressedBorderBrush = "Pressed.BorderBrush";
        private const string PressedBorderColor = "Pressed.BorderColor";

        private const string PressedBackgroundBrushDark = "Pressed.BackgroundBrushDark";
        private const string PressedBackgroundColorDark = "Pressed.BackgroundColorDark";
        private const string PressedBorderBrushDark = "Pressed.BorderBrushDark";
        private const string PressedBorderColorDark = "Pressed.BorderColorDark";

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
            resources.Add(AccentColor1, color.GetAccentColor1());
            resources.Add(MouseOverBorderColor, color.GetMouseOverBorderColor());
            resources.Add(MouseOverBackgroundColor, color.GetMouseOverBackgroundColor());
            resources.Add(PressedBorderColor, color.GetPressedBorderColor());
            resources.Add(PressedBackgroundColor, color.GetPressedBackgroundColor());
            resources.Add(PressedBorderColorDark, color.GetPressedBorderColorDark());
            resources.Add(PressedBackgroundColorDark, color.GetPressedBackgroundColorDark());

            resources.Add(AccentBrush, new SolidColorBrush((Color) resources[AccentColor]));
            resources.Add(AccentBrush1, new SolidColorBrush((Color)resources[AccentColor1]));
            resources.Add(MouseOverBorderBrush, new SolidColorBrush((Color) resources[MouseOverBorderColor]));
            resources.Add(MouseOverBackgroundBrush, new SolidColorBrush((Color) resources[MouseOverBackgroundColor]));
            resources.Add(PressedBorderBrush, new SolidColorBrush((Color)resources[PressedBorderColor]));
            resources.Add(PressedBackgroundBrush, new SolidColorBrush((Color)resources[PressedBackgroundColor]));
            resources.Add(PressedBorderBrushDark, new SolidColorBrush((Color)resources[PressedBorderColorDark]));
            resources.Add(PressedBackgroundBrushDark, new SolidColorBrush((Color)resources[PressedBackgroundColorDark]));
        }

        private static Color GetAccentColor1(this Color color)
        {
            var c = Color.FromArgb(180, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        private static Color GetMouseOverBackgroundColor(this Color color)
        {
            var c = Color.FromArgb(30, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        private static Color GetMouseOverBorderColor(this Color color)
        {
            var c = Color.FromArgb(70, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        private static Color GetPressedBackgroundColor(this Color color)
        {
            var c = Color.FromArgb(70, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        private static Color GetPressedBorderColor(this Color color)
        {
            var c = Color.FromArgb(110, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        private static Color GetPressedBackgroundColorDark(this Color color)
        {
            var c = Color.FromArgb(180, color.R, color.G, color.B);
            return MixColors(c, Colors.Black);
        }

        private static Color GetPressedBorderColorDark(this Color color)
        {
            var c = Color.FromArgb(200, color.R, color.G, color.B);
            return MixColors(c, Colors.Black);
        }

        private static Color MakeOpaque(this Color color)
        {
            return MixColors(color, Colors.White);
        }

        private static Color MixColors(Color color1, Color color2)
        {
            var r = (color1.R * color1.A / 255) + (color2.R * color2.A * (255 - color1.A) / (255 * 255));
            var g = (color1.G * color1.A / 255) + (color2.G * color2.A * (255 - color1.A) / (255 * 255));
            var b = (color1.B * color1.A / 255) + (color2.B * color2.A * (255 - color1.A) / (255 * 255));

            return Color.FromRgb((byte)r, (byte)g, (byte)b);
        }
    }
}