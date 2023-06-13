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
        static public       List<double[]> data;
        Pen pB;
        Brush  bBrush ;
        Panel x;
        string text;

        public List <Point> ps;                       ///<Координаты точек линии в пикселях


//        public graphWnd(string name, int p, Panel graphP)
        public graphWnd(string name, int p, graphPnl graphP)
        {                 
            SuspendLayout();
//            FormBorderStyle = FormBorderStyle.None;
//            FormBorderStyle = FormBorderStyle.Fixed3D;
//            FormBorderStyle = FormBorderStyle.Sizable;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
           if (debug)
              Console.Error.WriteLine( "graphWnd: panel  size Width/Height: {0}/{1} pixs"
                   , graphP.Size.Width, graphP.Size.Height);

            this.Name = "Form1";
            Paint           += new PaintEventHandler(paint);

            InitializeComponent(graphP.Size);

            Brush gBrush  = new SolidBrush (Color.Thistle);
            Brush wBrush  = new SolidBrush (Color.White);
                   bBrush = new SolidBrush (Color.Black);
                pB = new Pen(Color.Black);
            Pen gP = new Pen(Color.Blue);
            Pen rP = new Pen(Color.Red);

            FormBorderStyle = FormBorderStyle.Fixed3D;

            Panel p0 = new Panel ( );
            p0.Size = new Size(graphP.Size.Width, graphP.Size.Height);
            p0.Dock = DockStyle.Left;

            graphP.Dock =  DockStyle.Top;
            Controls.Add(p0);
            Controls.Add(graphP);
            ResumeLayout(false);
           // graphP.curve.
            Paint += new PaintEventHandler(paint);
            if ( graphP.curve  != null){ 
                x = graphP.curve;
                x.Paint += new PaintEventHandler(paint);
                x.Paint += new PaintEventHandler(paint2);
            }     
            else 
                Console.Error.WriteLine( "**** graphWnd: no panel to draw");

            ps = new List <Point> ();            

            if (data !=null) {
             Point foo;
             double []d=null; 
             for (int i = 0; i < data.Count; i++) {
               d = data[i];
               foo = new Point ((int)d[0],  (int)d[1]);
               ps.Add (foo);
             }
             text=String.Format ("paint is ready" );

            }
            else  {
                ps.Add (new Point(100, 100));
                ps.Add (new Point(200, 300));
                ps.Add (new Point(400, 200));
                text=String.Format ( "**** graphWnd: nothing to do!");
                Console.Error.WriteLine( "**** graphWnd: nothing to do!");
            }


         }

        void Draw1(Graphics g) {

           if (debug)
              Console.Error.WriteLine( "paint is ready");
            g.DrawString(text, this.Font, bBrush, 20, 20);
 
         }




        void paint2(object s, PaintEventArgs e)
        {
                 e.Graphics.DrawLines(pB,  ps.ToArray());
        }
        void paint(object s, PaintEventArgs e)
        {
            Draw1(e.Graphics); 
        }


        private void InitializeComponent(Size sz )
        {
//            this.MinimizeBox = false;
//            this.MaximizeBox = false;
//            this.ControlBox = false;
            this.AutoScroll = true;

            Size     = sz;
            AutoSize = true;
            Padding  = new Padding(padding, padding,padding, padding);
         }
    }
}