﻿using StringSim.Data;
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
            get => _Zoom; private set => _Zoom = value;
        }

        public void IncZoom()
        {
            if (Zoom >= 250) Zoom += 25;
            else if (Zoom >= 50) Zoom += 5;
            else Zoom++;
            Zoom = Math.Utils.Clamp(Zoom, 5, 1000);
            Invalidate();
        }

        public void DecZoom()
        {
            if (Zoom > 250) Zoom -= 25;
            else if (Zoom > 50) Zoom -= 5;
            else Zoom--;
            Zoom = Math.Utils.Clamp(Zoom, 5, 1000);
            Invalidate();
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

        void DrawHorizontalGridLine(Graphics g, int y, int transparency = 255)
        {
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(transparency, Color.Black))), 0, y, Width - 1, y);
        }

        void DrawVerticalGridLine(Graphics g, int x, int transparency = 255)
        {
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(transparency, Color.Black))), x, 0, x, Height - 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int cx = Width / 2;
            int cy = Height / 2;

            int gy = -ScrollY + cy;

            for (int y = gy; y < Height; y++) 
            {
                if ((y - gy) % _Zoom == 0)
                    DrawHorizontalGridLine(e.Graphics, y);
                else if (_Zoom >= 50 && (y - gy) % (_Zoom / 5) == 0) 
                    DrawHorizontalGridLine(e.Graphics, y, 128);
                else if (_Zoom >= 250 && (y - gy) % (_Zoom / 25) == 0)
                    DrawHorizontalGridLine(e.Graphics, y, 64);
            }

            for (int y = gy; y >= 0; y--) 
            {
                if ((gy - y) % _Zoom == 0)
                    DrawHorizontalGridLine(e.Graphics, y);
                else if (_Zoom >= 50 && (gy - y) % (_Zoom / 5) == 0) 
                    DrawHorizontalGridLine(e.Graphics, y, 128);
                else if (_Zoom >= 250 && (y - gy) % (_Zoom / 25) == 0)
                    DrawHorizontalGridLine(e.Graphics, y, 64);
            }

            int gx = -ScrollX + cx;

            for (int x = gx; x < Width; x++) 
            {
                if ((gx - x) % _Zoom == 0)
                    DrawVerticalGridLine(e.Graphics, x);
                else if (_Zoom >= 50 && (gx - x) % (_Zoom / 5) == 0)
                    DrawVerticalGridLine(e.Graphics, x, 128);
                else if (_Zoom >= 250 && (gx - x) % (_Zoom / 25) == 0)
                    DrawVerticalGridLine(e.Graphics, x, 64);

            }

            for (int x = gx; x >= 0; x--) 
            {
                if ((gx - x) % _Zoom == 0)
                    DrawVerticalGridLine(e.Graphics, x);
                else if (_Zoom >= 50 && (gx - x) % (_Zoom / 5) == 0)
                    DrawVerticalGridLine(e.Graphics, x, 128);
                else if (_Zoom >= 250 && (gx - x) % (_Zoom / 25) == 0)
                    DrawVerticalGridLine(e.Graphics, x, 64);
            }


            e.Graphics.DrawString($"{ScrollX}, {ScrollY}", Font, Brushes.Black, 0, 0);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            int c = e.Delta / 120;
            if(c<0)
            {
                for (; c != 0; c++) DecZoom();
            }
            else if(c>0)
            {
                for (; c != 0; c--) IncZoom();
            }            
            this.ParentForm.Text = e.Delta.ToString() + " " + Zoom.ToString();
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
