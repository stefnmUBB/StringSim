using StringSim.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSim.Data
{
    internal class Force
    {
        public Force(double X, double Y)
        {
            Vector = new Vector(X, Y);
        }
        public Vector Vector { get; set; } = Vector.Null;
    }
}
