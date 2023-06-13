using System;     
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace ut {
    public partial    class graphPnl : Panel     {
        public static int  m = 1;
        public static int  w = 800;
        public static int  h = 600;
        public static int  a = 50;
        public static Color     c = Color.Gray;
        public static Color axesC = Color.White;
        public static Color    CR = Color.Red;

        public Panel axisX;
        public Panel axisY;
        public Panel curve;
        public static bool debug   = false;
        public graphPnl()
        {                 
          Size     = new Size (w*m+a*m,a*m );
          AutoSize = true;
              Console.Error.WriteLine( "graphPnl: size Width/Height: {0}/{1} pixs"
                   , Size.Width, Size.Height);

          BackColor =  c;

         Panel s1 = new Panel ( );
         s1.Size = new Size(1,1);
         s1.AutoSize = true;

         Panel p0 = new Panel ( );
         p0.Size = new Size (20, a*m );   //int width, int height
         p0.Dock = DockStyle.Top;

        Control add = new Panel ( );
         add.Size = new Size (a*m,a*m );
         add.Dock = DockStyle.Right;
         add.BackColor =  CR;
         add.AutoSize = false;



//       Control
         axisX = new Panel ( );
//         Control axisX = new Button ( );
         axisX.Size = new Size (w*m,a*m );
         axisX.Dock = DockStyle.Right;
         axisX.BackColor =  axesC;
         axisX.AutoSize  = false;
         axisX.Paint           += new PaintEventHandler(paint2);

         s1.Controls.Add(p0);    
         s1.Controls.Add(add);   
         s1.Controls.Add(axisX); 
         s1.Dock = DockStyle.Top;
         Controls.Add(s1);

         Panel s2 = new Panel ( );
         s2.Dock = DockStyle.Top;
         s2.Size = new Size(1,1);
         s2.AutoSize = true;

         Panel p20 = new Panel ( );
         p20.Size = new Size (a, h*m );   //int width, int height
         p20.Dock = DockStyle.Top;
         s2.Controls.Add(p20);    
         //Control
          axisY = new Panel ( );
         axisY.Size = new Size (a*m,h*m  );
         axisY.Dock = DockStyle.Right;
         axisY.BackColor = Color.Cyan;
         axisY.AutoSize = false;
         s2.Controls.Add(axisY);    

         curve = new Panel ( );           // main panel
         curve.Size = new Size (w*m,h*m  );
         curve.Dock = DockStyle.Right;
         curve.BackColor = Color.Yellow;
         curve.AutoSize = false;
         s2.Controls.Add(curve);    
         Controls.Add(s2);
         if (debug)
              Console.Error.WriteLine( "graphPnl: size Width/Height: {0}/{1} pixs"
                   , Size.Width, Size.Height);
        }
        void paint2(object s, PaintEventArgs e)
        {
         if (debug)
              Console.Error.WriteLine( "graphPnl: paint is here!");
          e.Graphics.DrawLine( new Pen(Color.Blue), 0, 0, 799, 0  );
        }
    }
}