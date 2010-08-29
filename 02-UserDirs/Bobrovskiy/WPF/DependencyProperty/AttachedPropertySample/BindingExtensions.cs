using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AttachedPropertySample
{
    public static class BindingExtensions
    {
        public static readonly DependencyProperty FormatProperty =
            DependencyProperty.RegisterAttached("Format", typeof (string), typeof (BindingExtensions));

        public static string GetFormat(this Binding binding)
        {
            if (binding.Converter is StringFormatConverter)
                return ((StringFormatConverter) binding.Converter).Format;
            return string.Empty;
        }

        public static void SetFormat(this Binding binding, string stringFormat)
        {
            if (binding.Converter == null)
                binding.Converter = new StringFormatConverter(stringFormat);
        }
        
        private class StringFormatConverter : IValueConverter
        {
            public string Format { get; private set; }

            public StringFormatConverter(string format)
            {
                Format = format;
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return string.Format(culture, GetEffectiveStringFormat(Format), value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }

            private static string GetEffectiveStringFormat(string stringFormat)
            {
                if (stringFormat.IndexOf('{') < 0)
                {
                    stringFormat = "{0:" + stringFormat + "}";
                }
                return stringFormat;
            }
        }
    }
}
