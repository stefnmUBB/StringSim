using StringSim.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSim.Data
{
    internal class Point
    {
        public Point(double x = 0, double y = 0)
        {
            CurrentValue = new Math.Point(x, y);
            PreviousValue = new Math.Point(x, y);
        }
        public Math.Point CurrentValue { get; set; }
        public Math.Point PreviousValue { get; set; }
        public Vector Velocity { get; set; } = Vector.Null;

        public bool Fixed { get; set; } = false;

        public static implicit operator System.Drawing.PointF(Point p)
            => new System.Drawing.PointF((float)p.CurrentValue.X, (float)p.CurrentValue.Y);
    }
}
