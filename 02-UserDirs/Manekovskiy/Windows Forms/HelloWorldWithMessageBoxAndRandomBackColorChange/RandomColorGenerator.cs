using System;
using System.Drawing;


namespace Helpers
{
    public static class RandomColorGenerator
    {
        private static readonly Random randomByteGenerator = new Random();

        public static Color Generate24BytesColor()
        {
            return Color.FromArgb(randomByteGenerator.Next(byte.MinValue, byte.MaxValue),
                                  randomByteGenerator.Next(byte.MinValue, byte.MaxValue),
                                  randomByteGenerator.Next(byte.MinValue, byte.MaxValue),
                                  randomByteGenerator.Next(byte.MinValue, byte.MaxValue));
        }

    }
}
