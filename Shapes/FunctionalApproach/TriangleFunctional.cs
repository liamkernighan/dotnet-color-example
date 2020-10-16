using System;
using System.Drawing;
using SomeFunctionalLibrary.Either;

namespace ShapePainter
{
    public class TriangleFunctional: IShape, IEquatable<TriangleFunctional>
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

        public Either<ValidationError, TriangleFunctional> Create(double x, double y, double z, Color? color = null)
        {
            if (new[] { x, y, z}.Any(it => it <= 0.0))
            {
                return Either.Left(new ZeroOrLessDimensionValidationError("None of the dimensions should be less or equal than zero"));
            }

            var isRight = x + y > z && x + z > y && y + z > x;
            if (!isRight) 
            {
                var representation = string.Join(", ", x, y, z);
                return Either.Left(new WrongTriangleDimensionsValidationError($"Invalid coordinates for triangle: {representation}"));
            }

            return Either.Right(new TriangleFunctional(x, y, z, color ?? Color.Black));
        }

        private TriangleFunctional(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        private TriangleFunctional(double x, double y, double z, IColorFactory factory): this(x, y, z)
        {
            Color = factory.Color;
        }
        

        public bool Equals(TriangleFunctional other)
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
            return Equals((TriangleFunctional) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}