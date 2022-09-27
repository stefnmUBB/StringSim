using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSim.Data
{
    internal class Segment
    {
        public Point[] Heads { get; set; } = new Point[2];        
        
        public double Length { get => (Heads[0].CurrentValue - Heads[1].CurrentValue).Length; }

        public Math.Point MiddlePoint
        {
            get => Heads[0].CurrentValue + (Heads[1].CurrentValue - Heads[0].CurrentValue) * 0.5;
        }

        public Math.Vector Direction
        {
            get => (Heads[0].CurrentValue - Heads[1].CurrentValue).Norm;
        }
    }
}
