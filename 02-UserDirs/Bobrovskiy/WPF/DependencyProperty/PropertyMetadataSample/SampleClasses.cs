using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PropertyMetadataSample
{
    public class DepObj1 : DependencyObject
    {
        public static readonly DependencyProperty TestProperty =
            DependencyProperty.Register("Test", typeof(int), typeof(DepObj1), 
                new PropertyMetadata(0));

        public int Test
        {
            get { return (int)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }
    }

    public class DepObj2 : DepObj1
    {
        static DepObj2()
        {
            TestProperty.OverrideMetadata(typeof(DepObj2), 
                new HandleChangesPropertyMetadata(10));
        }
    }
    
    public class DepObj3 : DepObj2
    {
    }
    
    public class DepObj4 : DependencyObject
    {
        public static readonly DependencyProperty TestProperty;
        
        static DepObj4()
        {
            TestProperty = DepObj1.TestProperty.AddOwner(typeof(DepObj4),
                new HandleChangesPropertyMetadata(30));
        }

        public int Test
        {
            get { return (int)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }
    }
}
