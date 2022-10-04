using StringSim.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSim.Controls
{
    internal partial class Scene : UserControl
    {
        public Scene()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        public Context Context { get; set; }

        int _Zoom = 100;

        public int Zoom
        {
            get => _Zoom;
            set
            {
                _Zoom = Math.Utils.Clamp(value, 5, 1000);
                Invalidate();
            }
        }

        int _ScrollX = 0, _ScrollY = 0;

        public int ScrollX
        {
            get => _ScrollX;
            set
            {
                _ScrollX = value;
                Invalidate();
                ScrollChanged?.Invoke(this);
            }
        }

        public int ScrollY
        {
            get => _ScrollY;
            set
            {
                _ScrollY = value;
                Invalidate();
                ScrollChanged?.Invoke(this);
            }
        }

        void DrawHorizontalGridLine(Graphics g, int y)
        {
            g.DrawLine(Pens.Gray, 0, y, Width - 1, y);
        }

        void DrawVerticalGridLine(Graphics g, int x)
        {
            g.DrawLine(Pens.Gray, x, 0, x, Height-1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int cx = Width / 2;
            int cy = Height / 2;

            int gy = -ScrollY + cy;

            for (int y = gy; y < Height; y += Zoom) 
            {
                DrawHorizontalGridLine(e.Graphics, y);
            }

            for (int y = gy; y >= 0; y -= Zoom) 
            {
                DrawHorizontalGridLine(e.Graphics, y);
            }

            int gx = -ScrollX + cx;

            for(int x=gx;x<Width;x+=Zoom)
            {
                DrawVerticalGridLine(e.Graphics, x);
            }

            for (int x = gx; x >= 0; x -= Zoom) 
            {
                DrawVerticalGridLine(e.Graphics, x);
            }


        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);            
            Zoom += e.Delta / 120;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.DrawLine(Pens.Black, 0, 0, Width - 1, Height - 1);
            e.Graphics.DrawLine(Pens.Black, 0, Height - 1, Width - 1, 0);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {                      
            if (keyData == Keys.Left)
            {
                ScrollX--;
                return true;
            }
            else if (keyData == Keys.Right) 
            {
                ScrollX++;
                return true;
            }

            if(keyData == Keys.Up)
            {
                ScrollY--;
                return true;
            }
            else if(keyData==Keys.Down)
            {
                ScrollY ++;
                return true;
            }

            int speed = System.Math.Max(2, 500 / Zoom);

            if (keyData == (Keys.Control | Keys.Left))
            {
                ScrollX-=speed;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Right))
            {
                ScrollX+=speed;
                return true;
            }

            if (keyData == (Keys.Control | Keys.Up))
            {
                ScrollY-=speed;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Down))
            {
                ScrollY += speed;
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        public delegate void OnScrollChanged(object o);
        public event OnScrollChanged ScrollChanged;
    }
}
