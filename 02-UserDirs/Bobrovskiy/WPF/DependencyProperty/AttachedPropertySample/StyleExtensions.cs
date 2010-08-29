using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Controls;

namespace AttachedPropertySample
{
    public static class StyleExtensions
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.RegisterAttached("Title", typeof(string), typeof(StyleExtensions),
                                                new PropertyMetadata(null));

        public static string GetTitle(this UIElement element)
        {
            return (string)element.GetValue(TitleProperty);
        }

        public static void SetTitle(this UIElement element, string title)
        {
            element.SetValue(TitleProperty, title);
        }
    }
}
