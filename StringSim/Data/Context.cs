using StringSim.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSim.Data
{
    internal class Context
    {
        public List<Point> Points { get; } = new List<Point>();
        public List<Segment> Segments { get; } = new List<Segment>();
        public List<Force> Forces { get; } = new List<Force>();

        public double Delta = 0.1;

        public void SimulateFrame()
        {
            foreach(var p in Points)
            {
                if (!p.Fixed)
                {
                    var tmp_val = p.CurrentValue;                
                    p.CurrentValue += p.CurrentValue - p.PreviousValue;
                    foreach (var f in Forces)
                    {                        
                        p.Velocity += Delta * f.Vector;
                        p.CurrentValue += Delta * p.Velocity;                        
                    }
                    p.CurrentValue += new Vector(0, 1) * 9.8 * Delta * Delta;
                    p.PreviousValue = tmp_val;
                }
            }

            for (int i = 0; i < 1000; i++) 
            {
                foreach (var s in Segments)
                {
                    var mid = s.MiddlePoint;
                    var dir = s.Direction;
                    if (!s.Heads[0].Fixed)
                    {
                        s.Heads[0].CurrentValue = mid + dir * s.Length * 0.5;
                    }

                    if (!s.Heads[1].Fixed)
                    {
                        s.Heads[1].CurrentValue = mid - dir * s.Length * 0.5;
                    }
                }
            }
        }

        public static Force Gravity = new Force(0, 9.8);
    }
}
