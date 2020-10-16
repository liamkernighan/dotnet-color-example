using System;
using System.Drawing;

namespace ShapePainter
{
    public class Circle : IShape, IEquatable<Circle>
    {
        public double Radius { get; }
        public Color Color { get; } = Color.Black;
        
        public Circle(double radius)
        {
            Helpers.AssertIsPositive(radius);
            Radius = radius;
        }

        public Circle(double radius, IColorFactory factory) : this(radius)
        {
            Color = factory.Color;
        }
        
        public double Area => Math.Pow(Math.PI * Radius, 2);
        public double Length => Math.PI * Radius * 2;

        public bool Equals(Circle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Radius.Equals(other.Radius);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Circle) obj);
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }
    }
}