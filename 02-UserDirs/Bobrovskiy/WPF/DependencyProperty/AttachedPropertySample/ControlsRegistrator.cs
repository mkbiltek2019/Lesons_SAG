using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;

namespace AttachedPropertySample
{
    public class ControlsRegistrator
    {
        static ControlsRegistrator()
        {
            registeredUIElements = new List<string>();
        }

        private static List<string> registeredUIElements;
        public static List<string> RegisteredUIElements
        {
            get 
            {
                return registeredUIElements; 
            }
            set 
            { 
                registeredUIElements = value; 
            }
        }

        public static UIElement GetRegister(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(RegisterProperty);
        }

        public static void SetRegister(DependencyObject obj, UIElement value)
        {
            obj.SetValue(RegisterProperty, value);
        }

        // Using a DependencyProperty as the backing store for Register.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegisterProperty =
            DependencyProperty.RegisterAttached("Register", typeof(UIElement), typeof(ControlsRegistrator), new UIPropertyMetadata(OnPropertyChanged));

        public static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                RegisteredUIElements.Add(e.NewValue.GetType().Name);
            }
        }
    }
}
