using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace HelloWPF.Model
{
    public class Cucumber
    {
        public int DotsCount { get; set; }
        public int PricePerDot { get; set; }
        public Color Color { get; set; }

        public int TotalPrice 
        {
            get 
            {
                return DotsCount * PricePerDot;
            }
        }

        public override string ToString()
        {
            return string.Format("Color: {0}\nDots: {1}\nPrice: {2}\n\n", Color, DotsCount, TotalPrice);
        }
    }
}
