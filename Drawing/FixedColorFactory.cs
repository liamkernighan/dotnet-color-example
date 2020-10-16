using System.Drawing;

namespace ShapePainter
{
    public class FixedColorFactory : IColorFactory
    {
        public FixedColorFactory(byte r, byte g, byte b)
        {
            this.Color = Color.FromArgb(r, g, b);
        }

        public FixedColorFactory(Color color)
        {
            this.Color = color;
        }
        
        public Color Color { get; }
    }
}