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
    public partial    class graphChart : Panel     {
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
        public graphChart()
        {                 
          Size     = new Size (w, h);
//          Size     = new Size (w*m+a*m,a*m );
          AutoSize = true;
          if (debug)
               Console.Error.WriteLine( "graphChart: start Width/Height: {0}/{1} pixs"
                   , Size.Width, Size.Height);

          BackColor =  c;

         curve           = new Panel ( );        // main panel
         curve.Size      = new Size (w*m, h*m);
         curve.Dock      = DockStyle.Right;
         curve.BackColor = Color.Yellow;
         curve.AutoSize  = false;
         Controls.Add(curve);

          if (debug)
               Console.Error.WriteLine( "graphChart: finish Width/Height: {0}/{1} pixs"
                   , Size.Width, Size.Height);



         if (debug)
              Console.Error.WriteLine( "graphChart: size Width/Height: {0}/{1} pixs"
                   , Size.Width, Size.Height);
        }
        void paint2(object s, PaintEventArgs e)
        {
         if (debug)
              Console.Error.WriteLine( "graphChart: paint is here!");
          e.Graphics.DrawLine( new Pen(Color.Blue), 0, 0, 799, 0  );
        }
    }
}