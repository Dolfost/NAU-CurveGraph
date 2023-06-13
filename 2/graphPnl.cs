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

    public  class graphPnl : Panel
    {

        public static int  m = 1;
        public static int  w = 800;
        public static int  h = 600;
        public static int  a = 50;
        public static Color     c = Color.Gray;
        public static Color axesC = Color.White;
        public static Color    CR = Color.Red;

        public Panel axisX;
        public Panel axisY;
        public static bool debug   = false;


        
        public graphPnl()
        {                 
            Size     = new Size (w*m+a*m,a*m );
          AutoSize = true;
              Console.Error.WriteLine( "graphPnl: size Width/Height: {0}/{1} pixs"
                   , Size.Width, Size.Height);

          BackColor =  c;

         Panel p0 = new Panel ( );
         p0.Size = new Size (20, a*m );   //int width, int height
         p0.Dock = DockStyle.Top;


//         Control add = new Button ( );
// 
        Control add = new Panel ( );
         add.Size = new Size (a*m,a*m );
         add.Dock = DockStyle.Right;
         add.BackColor =  CR;
         add.AutoSize = false;


//
         Control axisX = new Panel ( );
//         Control axisX = new Button ( );
         axisX.Size = new Size (w*m,a*m );
         axisX.Dock = DockStyle.Right;
         axisX.BackColor =  axesC;
         axisX.AutoSize = false;
         Controls.Add(p0);
         Controls.Add(add);
         Controls.Add(axisX);

         if (debug)
              Console.Error.WriteLine( "graphPnl: size Width/Height: {0}/{1} pixs"
                   , Size.Width, Size.Height);

        }


    }
}