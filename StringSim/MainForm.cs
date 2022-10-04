using StringSim.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSim
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Scene.Context = SimulationContext;
            for(int i=0;i<360;i+=30)
            {
                double X = 100 * System.Math.Cos(2 * System.Math.PI * i / 360);
                double Y = 100 * System.Math.Sin(2 * System.Math.PI * i / 360);
                SimulationContext.Points.Add(new Data.Point
                {
                    CurrentValue = new Math.Point(X, Y)
                });
            }
        }

        Context SimulationContext = new Context();
        private void Scene_ScrollChanged(object o)
        {            
        }
    }
}
