using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace PanelSample
{
    public class SpacePanel : UniformGrid
    {
        #region Scales  used for difrent direction Scale Action

        public double HorizontalScale
        {
            get { return (double)GetValue(HorizontalScaleProperty); }
            set { SetValue(HorizontalScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HorizontalScale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalScaleProperty =
            DependencyProperty.Register("HorizontalScale",
            typeof(double), typeof(SpacePanel),
            new FrameworkPropertyMetadata(1.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double VerticalScale
        {
            get { return (double)GetValue(VerticalScaleProperty); }
            set { SetValue(VerticalScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VerticalScale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerticalScaleProperty =
            DependencyProperty.Register("VerticalScale",
            typeof(double),
            typeof(SpacePanel),
             new FrameworkPropertyMetadata(1.0,
                 FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double MargineScale
        {
            get { return (double)GetValue(MargineScaleProperty); }
            set { SetValue(MargineScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MargineScale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MargineScaleProperty =
            DependencyProperty.Register("MargineScale",
            typeof(double),
            typeof(SpacePanel),
            new FrameworkPropertyMetadata(1.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure));


        #endregion

        //#region  Unused Scale  DependencyProperty

        //public double Scale
        //{
        //    get { return (double)GetValue(ScaleProperty); }
        //    set { SetValue(ScaleProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Scale.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ScaleProperty =
        //    DependencyProperty.Register("Scale", typeof(double), typeof(SpacePanel), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
        //#endregion


        #region ArrangeDirection DependencyProperty

        public ArrangeDirection ArrangeDirection
        {
            get { return (ArrangeDirection)GetValue(ArrangeDirectionProperty); }
            set { SetValue(ArrangeDirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ArrangeDirection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArrangeDirectionProperty =
            DependencyProperty.Register("ArrangeDirection",
            typeof(ArrangeDirection),
            typeof(SpacePanel),
            new FrameworkPropertyMetadata(ArrangeDirection.LeftToRight,
                FrameworkPropertyMetadataOptions.AffectsArrange));

        #endregion


        protected override Size MeasureOverride(Size constraint)
        { 
            return base.MeasureOverride(new Size(constraint.Width * HorizontalScale,
                                                 constraint.Height * VerticalScale));
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            base.Margin = new Thickness((1 - MargineScale) * arrangeSize.Width/2,
                                        (1 - MargineScale) * arrangeSize.Height / 2,
                                        (1 - MargineScale) * arrangeSize.Width/2,
                                        (1 - MargineScale) * arrangeSize.Height / 2);
            switch (ArrangeDirection)
            {
                case ArrangeDirection.LeftToRight:
                    ArrangeLeftToRight(arrangeSize);
                    break;
                case ArrangeDirection.TopToBottom:
                    ArrangeTopToBottom(arrangeSize);
                    break;
            }

            return arrangeSize;
        }

        private void ArrangeTopToBottom(Size arrangeSize)
        {
            var elementOuterRect =
                    new Rect(0.0, 0.0, arrangeSize.Width / Columns, arrangeSize.Height / Rows);
            double width = elementOuterRect.Width;
            double rowHeight = arrangeSize.Height - 1.0;
            //double rowWidth = arrangeSize.Width - 1.0;
            elementOuterRect.X += elementOuterRect.Width * FirstColumn;

            foreach (UIElement element in InternalChildren)
            {
                var elementInnerRect = new Rect(
                        elementOuterRect.Left + elementOuterRect.Width * (1 - HorizontalScale) / 2,
                        elementOuterRect.Top + elementOuterRect.Height * (1 - VerticalScale) / 2,
                        elementOuterRect.Width * HorizontalScale,
                        elementOuterRect.Height * VerticalScale
                    );
                element.Arrange(elementInnerRect);
                if (element.Visibility != Visibility.Collapsed)
                {
                    elementOuterRect.Y += elementOuterRect.Height;
                    if (elementOuterRect.Y >= rowHeight)
                    {
                        elementOuterRect.X += width;
                        elementOuterRect.Y = 0.0;
                    }
                }
            }
            
        }

        private void ArrangeLeftToRight(Size arrangeSize)
        {
            var elementOuterRect = new Rect(0.0, 0.0, arrangeSize.Width / Columns, arrangeSize.Height / Rows);
            double width = elementOuterRect.Width;
            double rowWidth = arrangeSize.Width - 1.0;
            elementOuterRect.X += elementOuterRect.Width * FirstColumn;

            foreach (UIElement element in InternalChildren)
            {
                var elementInnerRect = new Rect(
                        elementOuterRect.Left + elementOuterRect.Width * (1 - HorizontalScale) / 2,
                        elementOuterRect.Top + elementOuterRect.Height * (1 - VerticalScale) / 2,
                        elementOuterRect.Width * HorizontalScale,
                        elementOuterRect.Height * VerticalScale
                    );
                element.Arrange(elementInnerRect);
                if (element.Visibility != Visibility.Collapsed)
                {
                    elementOuterRect.X += width;
                    if (elementOuterRect.X >= rowWidth)
                    {
                        elementOuterRect.Y += elementOuterRect.Height;
                        elementOuterRect.X = 0.0;
                    }
                }
            }
            //arrangeSize.Height = arrangeSize.Height * MargineScale;
            //arrangeSize.Width = arrangeSize.Width * MargineScale;
        }

    }

    public enum ArrangeDirection
    {
        LeftToRight,
        TopToBottom
    }
}
