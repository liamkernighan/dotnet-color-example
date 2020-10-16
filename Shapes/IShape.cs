using System;
using System.Drawing;

namespace ShapePainter
{
    public interface IShape
    {
        double Area { get;  }
        double Length { get; }
        
        Color Color { get; }
    }
}