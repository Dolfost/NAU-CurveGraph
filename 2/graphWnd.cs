using System;     
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace ut
{
    public  class PanelX : Panel{ 
      public   PanelX(): base(){DoubleBuffered=true;}
    }
    



    public  class graphWnd : Form

    {
        const int padding = 10;
        public static bool debug   = false;
        
//        public graphWnd(string name, int p, Panel graphP)
        public graphWnd(string name, int p, graphPnl graphP)
        {                 
            SuspendLayout();

           if (debug)
              Console.Error.WriteLine( "graphWnd: panel  size Width/Height: {0}/{1} pixs"
                   , graphP.Size.Width, graphP.Size.Height);

            this.Name = "Form1";
            Paint           += new PaintEventHandler(paint);

            InitializeComponent(graphP.Size);

            Brush gBrush = new SolidBrush (Color.Thistle);
            Brush wBrush = new SolidBrush (Color.White);
            Brush  bBrush = new SolidBrush (Color.Black);
            Pen pB = new Pen(Color.Black);
            Pen gP = new Pen(Color.Blue);
            Pen rP = new Pen(Color.Red);

            FormBorderStyle = FormBorderStyle.Fixed3D;

            Panel p0 = new Panel ( );
            p0.Size = new Size(30, graphP.Size.Height);
            p0.Dock = DockStyle.Top;

            this.Controls.Add(p0);
            graphP.Dock =  DockStyle.Left;
            this.Controls.Add(graphP);
            ResumeLayout(false);

         }


         void Draw() 
        {
        }

        void paint(object s, PaintEventArgs e)
        {
//           e.Graphics.FillRectangle (gBrush, 5,5, ClientSize.Width-10, ClientSize.Height-10);
        }


        void paint1(object s, PaintEventArgs e)
        {
        }

         private void 
        _close (object sender, System.EventArgs e)
        {
           Close();
        }                                     
        private void InitializeComponent(Size sz )
        {
//            this.MinimizeBox = false;
//            this.MaximizeBox = false;
//            this.ControlBox = false;
            this.AutoScroll = false;

            Size     = sz;
            AutoSize = true;
            Padding  = new Padding(padding, padding,padding, padding);
         }
    }
}