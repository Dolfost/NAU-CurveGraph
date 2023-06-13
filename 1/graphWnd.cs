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
        public bool debug   = false;
        
        public graphWnd(string name, int p, Panel graphP)
        {                 
            this.Name = "Form1";
            Paint           += new PaintEventHandler(paint);
            InitializeComponent();

            Brush gBrush = new SolidBrush (Color.Thistle);
            Brush wBrush = new SolidBrush (Color.White);
            Brush  bBrush = new SolidBrush (Color.Black);
            Pen pB = new Pen(Color.Black);
            Pen gP = new Pen(Color.Blue);
            Pen rP = new Pen(Color.Red);

            FormBorderStyle = FormBorderStyle.Fixed3D;
            Panel p0 = new Panel ( );
            p0.Size = graphP.Size;
            p0.Dock = DockStyle.Left;

            this.Controls.Add(p0);
            this.Controls.Add(graphP);

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
        private void InitializeComponent( )
        {
            Size     = new Size (10, 10);
            AutoSize = true;
            Padding  = new Padding(padding, padding,padding, padding);
         }
    }
}