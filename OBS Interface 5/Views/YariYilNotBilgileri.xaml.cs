using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OBS_Interface_5.Views
{
    /// <summary>
    /// Interaction logic for YariYilNotBilgileri.xaml
    /// </summary>
    public partial class YariYilNotBilgileri : UserControl
    {
        public YariYilNotBilgileri()
        {
            InitializeComponent();
            RenkAta();
            
        }

        public void RenkAta()
        {
            if (LabelRow1.Content.ToString()=="AA")
            {
                Color color = GetBlendedColor(100);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow1.Fill = brush;
            }
            if (LabelRow2.Content.ToString() == "BA")
            {
                Color color = GetBlendedColor((100 / 8) * 7);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow2.Fill = brush;
            }
            if (LabelRow3.Content.ToString() == "BB")
            {
                Color color = GetBlendedColor((100 / 8) * 6);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow3.Fill = brush;
            }
            if (LabelRow4.Content.ToString() == "CB")
            {
                Color color = GetBlendedColor((100 / 8) * 5);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow4.Fill = brush;
            }
            if (LabelRow5.Content.ToString() == "CC")
            {
                Color color = GetBlendedColor((100 / 8) * 4);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow5.Fill = brush;
            }
            if (LabelRow6.Content.ToString() == "DC")
            {
                Color color = GetBlendedColor((100 / 8) * 3);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow6.Fill = brush;
            }
            if (LabelRow7.Content.ToString() == "DD")
            {
                Color color = GetBlendedColor((100 / 8) * 2);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow7.Fill = brush;
            }
            if (LabelRow8.Content.ToString() == "FD")
            {
                Color color = GetBlendedColor((100 / 8) * 1);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow8.Fill = brush;
            }
            if (LabelRow9.Content.ToString() == "FF")
            {
                Color color = Color.FromRgb(255, 0, 0);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow9.Fill = brush;
            }
            if (LabelRow10.Content.ToString() == "YE")
            {
                Color color = GetBlendedColor((100 / 8) * 4);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow10.Fill = brush;
            }
            if (LabelRow11.Content.ToString() == "YS")
            {
                Color color = Color.FromRgb(255, 0, 0);
                SolidColorBrush brush = new SolidColorBrush(color);
                RectangleRow11.Fill = brush;
            }
        }

        public Color GetBlendedColor(int percentage)
        {
            if (percentage < 50)
                return Interpolate(Color.FromRgb(255, 255, 0), Color.FromRgb(255, 0, 0), percentage / 50.0);
            return Interpolate(Color.FromRgb(0, 255, 0), Color.FromRgb(255, 255, 0), (percentage - 50) / 50.0);
        }

        private Color Interpolate(Color color1, Color color2, double fraction)
        {
            double r = Interpolate(color1.R, color2.R, fraction);
            double g = Interpolate(color1.G, color2.G, fraction);
            double b = Interpolate(color1.B, color2.B, fraction);
            return Color.FromRgb((byte)Math.Round(r), (byte)Math.Round(g), (byte)Math.Round(b));
        }

        private double Interpolate(double d1, double d2, double fraction)
        {
            return d1 + (d1 - d2) * fraction;
        }
    }
}
