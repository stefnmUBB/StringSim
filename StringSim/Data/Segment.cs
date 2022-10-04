using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSim.Data
{
    internal class Segment
    {
        public Segment(Point p1, Point p2)
        {
            Heads[0] = p1;
            Heads[1] = p2;
            Length = (Heads[1].CurrentValue - Heads[0].CurrentValue).Length;
        }
        public Point[] Heads { get; set; } = new Point[2];        
        
        public double Length { get; }

        public Math.Point MiddlePoint
        {
            get => Heads[1].CurrentValue + (Heads[0].CurrentValue - Heads[1].CurrentValue) * 0.5;
        }

        public Math.Vector Direction
        {
            get => (Heads[0].CurrentValue - Heads[1].CurrentValue).Norm;
        }
    }
}
