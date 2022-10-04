using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSim.Math
{
    internal class Utils
    {
        public static int Clamp(int x, int a, int b)
        {
            if (x < a) return a;
            if (x > b) return b;
            return x;
        }
    }
}
