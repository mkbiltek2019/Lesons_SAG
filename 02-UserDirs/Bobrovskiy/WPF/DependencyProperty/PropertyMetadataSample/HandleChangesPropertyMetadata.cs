using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace PropertyMetadataSample
{
    public class HandleChangesPropertyMetadata : FrameworkPropertyMetadata
    {
        private readonly EventHandlerList handlers = new EventHandlerList();
        private DependencyObjectType doType;
        private PropertyChangedCallback propertyChangedCallbackInternal;

        public HandleChangesPropertyMetadata(object defaultValue) : base(defaultValue)
        {
        }

        protected override void OnApply(DependencyProperty dp, Type targetType)
        {
            doType = DependencyObjectType.FromSystemType(targetType);
            propertyChangedCallbackInternal = PropertyChangedCallback;
            PropertyChangedCallback = OnPropertyChanged;
            base.OnApply(dp, targetType);
        }

        private void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (propertyChangedCallbackInternal != null)
                propertyChangedCallbackInternal(d, e);

            var handler = handlers[d.DependencyObjectType] as DependencyPropertyChangedEventHandler;
            if (handler != null)
                handler(d, e);
        }

        private void AddPropertyChanged(DependencyObjectType type, DependencyPropertyChangedEventHandler handler)
        {
            if (type != doType && !type.IsSubclassOf(doType))
                throw new ArgumentException();
            handlers.AddHandler(type, handler);
        }

        private void RemovePropertyChanged(DependencyObjectType type, DependencyPropertyChangedEventHandler handler)
        {
            if (type != doType && !type.IsSubclassOf(doType))
                throw new ArgumentException();
            handlers.RemoveHandler(type, handler);
        }

        public static void AddPropertyChanged(DependencyProperty dp, DependencyObjectType type,
                                              DependencyPropertyChangedEventHandler handler)
        {
            var hcpm = dp.GetMetadata(type) as HandleChangesPropertyMetadata;
            if (hcpm == null)
                throw new ArgumentException();
            hcpm.AddPropertyChanged(type, handler);
        }

        public static void RemovePropertyChanged(DependencyProperty dp, DependencyObjectType type,
                                                 DependencyPropertyChangedEventHandler handler)
        {
            var hcpm = dp.GetMetadata(type) as HandleChangesPropertyMetadata;
            if (hcpm == null)
                throw new ArgumentException();
            hcpm.RemovePropertyChanged(type, handler);
        }
    }
}
