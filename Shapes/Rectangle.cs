using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace ShapePainter
{
    public class Rectangle : IShape, IEquatable<Rectangle>
    {
        public double X { get; }
        public double Y { get; }

        public bool IsSquare => X == Y;
        
        public double Area => X * Y;
        public double Length => (X + Y) * 2;
        public Color Color { get; } = Color.Black;
 
        
        public Rectangle(double x, double y)
        {
            Helpers.AssertIsPositive(x, y);

            X = x;
            Y = y;
        }

        public Rectangle(double x, double y, IColorFactory factory) : this(x, y)
        {
            Color = factory.Color;
        }

        public bool Equals(Rectangle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rectangle) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}