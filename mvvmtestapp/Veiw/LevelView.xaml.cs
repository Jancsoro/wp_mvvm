using System;
using System.Globalization;
using Windows.UI.Xaml.Controls;
using System.Windows;
using Windows.UI.Xaml.Data;

namespace MVVMTestApp.View
{
    public partial class LevelView : UserControl
    {
        public LevelView()
        {
            InitializeComponent();
        }
    }


    public class BoolOpposite : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool b = (bool)value;
            return !b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string s = value as string;
            bool b;

            if (bool.TryParse(s, out b))
            {
                return !b;
            }
            return false;
        }
    }
}