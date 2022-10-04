using StringSim.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSim
{
    public partial class MainForm : Form
    {
        static double f(double x)
        {
            return System.Math.Sin(x) + System.Math.Sin(2 * x);
        }
        public MainForm()
        {
            InitializeComponent();
            Scene.Context = SimulationContext;
            SimulationContext.Points.Add(new Data.Point(0, 0));
            int step = 6;
            double a = 0;
            double b = 4 * System.Math.PI;
            double r = 100;
            for(int i=0;i<360;i+=step)
            {
                double t = 2 * System.Math.PI * (i) / 360;
                double X = r * System.Math.Cos(t);
                double Y = r * System.Math.Sin(t);
                X *= f(a + (b - a) * t / 2 / System.Math.PI);
                Y *= f(a + (b - a) * t / 2 / System.Math.PI);

                SimulationContext.Points.Add(new Data.Point(X, Y));
            }
            SimulationContext.Points[0].Fixed = true;
            //SimulationContext.Points.Last().Fixed = true;
            //SimulationContext.Points[SimulationContext.Points.Count / 2].Fixed = true;
            for (int i = 1; i < SimulationContext.Points.Count - 1; i++) 
            {
                SimulationContext.Segments.Add(new Segment(
                    SimulationContext.Points[i],
                    SimulationContext.Points[i + 1])
                );
            }

            SimulationContext.Segments.Add(new Segment(
                    SimulationContext.Points[1],
                    SimulationContext.Points.Last())
                );

            var rand = new Random();
            for (int i = 1; i < SimulationContext.Points.Count; i++) 
            {
                if (rand.Next() % 2 == 0) 
                SimulationContext.Segments.Add(new Segment(
                    SimulationContext.Points[0],
                    SimulationContext.Points[i]));
                if (i % 5 == 0) 
                {
                    SimulationContext.Points[i].Fixed = true;
                }
            }

            SimulationContext.Forces.Add(Context.Gravity);
            //SimulationContext.Forces.Add(new Force(, 0));
        }

        Context SimulationContext = new Context();
        private void Scene_ScrollChanged(object o)
        {            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.D1 && e.Modifiers==Keys.Control)
                Scene.StartSimulation();    
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }
    }
}
