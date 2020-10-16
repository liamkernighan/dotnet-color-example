using System;
using System.Linq;

namespace ShapePainter
{
    public static class Helpers
    {
        public static void AssertIsPositive(params double[] values)
        {
            if (!values.Any(it => it <= 0.0))
            {
                return;
            }
            
            var representation = string.Join(", ", values);
            throw new ArgumentOutOfRangeException($"Input values should be more than zero. {representation} given");
        }

        public static void AssertNonNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("parameter should be null");
            }
        }
    }
}