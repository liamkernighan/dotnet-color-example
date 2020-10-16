using System;
using System.Drawing;

namespace ShapePainter
{
    public class Triangle: IShape, IEquatable<Triangle>
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Color Color { get; } = Color.Black;

        public double Area
        {
            get
            {
                var p = (X * Y * Z) / 2.0;
                var areaSq = p * (p - X) * (p - Y) * (p - Z);
                return Math.Sqrt(areaSq);
            }
        }

        public double Length => X + Y + Z;

        private void Validate(double x, double y, double z)
        {
            Helpers.AssertIsPositive(x, y, z);
            
            var isRight = x + y > z && x + z > y && y + z > x;
            if (!isRight) 
            {
                var representation = string.Join(", ", x, y, z);
                throw new ArgumentException($"Invalid coordinates for triangle: {representation}");
            }
        }


        public Triangle(double x, double y, double z)
        {
            Validate(x, y, z);

            X = x;
            Y = y;
            Z = z;
        }

        public Triangle(double x, double y, double z, IColorFactory factory): this(x, y, z)
        {
            Color = factory.Color;
        }
        

        public bool Equals(Triangle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Triangle) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}