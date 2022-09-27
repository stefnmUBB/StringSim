using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSim.Math
{
    internal class Vector
    {
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;

        public static Vector operator + (Vector u, Vector v) => new Vector(u.X + v.X, u.Y + v.Y);
        public static Vector operator - (Vector u, Vector v) => new Vector(u.X - v.X, u.Y - v.Y);
        public static Vector operator - (Vector u) => new Vector(-u.X, u.Y);
        public static Vector operator *(double a, Vector u) => new Vector(a * u.X, a * u.Y);
        public static Vector operator *(Vector u, double a) => new Vector(a * u.X, a * u.Y);
        public double LengthSquared { get => X * X + Y * Y; }
        public double Length { get => System.Math.Sqrt(LengthSquared); }
        
        public static Vector Null { get => new Vector(0, 0); }

        public Vector Norm
        {
            get => X == 0 && Y == 0 ? Vector.Null : new Vector(X / Length, Y / Length);
        }
    }
}
