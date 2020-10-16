using System;
using System.Drawing;

namespace ShapePainter
{
    public class RandomColorFactory : IColorFactory
    {
        private readonly Random _random = new Random();

        private int randomRgb() => _random.Next(0, 255);

        public Color Color { get; }

        public RandomColorFactory()
        {
            Color = Color.FromArgb(randomRgb(), randomRgb(), randomRgb());
        }
    }
}