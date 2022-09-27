using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSim.Math
{
    internal class Point
    {
        public Point(double x, double y) 
        {
            X = x;
            Y = y;
        }
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        

        public static Point operator +(Point p, Vector v) => new Point(p.X + v.X, p.Y + v.Y);
        public static Point operator -(Point p, Vector v) => new Point(p.X - v.X, p.Y - v.Y);
        public static Vector operator -(Point p, Point q) => new Vector(p.X - q.X, p.Y - q.Y);

        public static Point Null { get => new Point(0, 0); }
    }
}
