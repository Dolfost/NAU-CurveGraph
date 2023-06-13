using System;     
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace ut {
    public partial    class graphChart : Panel     {
        public List<double[]> data ;
        public static int  m = 1;
        public static int  w = 800;
        public static int  h = 600;
        public static int  a = 50;
        public static Color     c = Color.Gray;
        public static Color axesC = Color.White;
        public static Color    CR = Color.Red;

        public Chart curve;
        public static bool debug   = false;
        private  bool hideEmpty    = false;

        public graphChart( bool hideEmpty)  {
          this.hideEmpty = hideEmpty;             
          Size     = new Size (w, h);
//          Size     = new Size (w*m+a*m,a*m );
          AutoSize = true;
          if (debug)
               Console.Error.WriteLine( "graphChart: start Width/Height: {0}/{1} pixs"
                   , Size.Width, Size.Height);

          BackColor =  c;

         curve           = new Chart ( );        // main panel
         curve.Size      = new Size (w*m, h*m);
         curve.Dock      = DockStyle. Left;//Fill;   //  
         curve.BackColor = Color.Yellow;
         curve.AutoSize  = false;

            curve.ChartAreas.Add("Area1");
            curve.ChartAreas["Area1"].AxisY.Minimum = 0;
            curve.ChartAreas["Area1"].AxisY.TitleAlignment = StringAlignment.Far;
            curve.ChartAreas["Area1"].AxisY.ArrowStyle = AxisArrowStyle.Triangle;
            curve.ChartAreas["Area1"].AxisY.Title = "numbers of values";
            curve.ChartAreas["Area1"].AxisX.TitleAlignment = StringAlignment.Far;
            curve.ChartAreas["Area1"].AxisX.ArrowStyle = AxisArrowStyle.Triangle;
            curve.ChartAreas["Area1"].AxisX.Title = "intervals";














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