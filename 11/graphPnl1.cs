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
     public partial   class graphPnl : Panel    {
        //
        //        V - Min            v - min
        //       ----------   ==    ----------
        //        Max - Min          max - min
        //
        static int  map (int min, int max,  double V,   double Min, double Max){
            if (max - min > 0 && Max - Min > 0.000000001 ) {
                double t = (( V - Min)*(max - min) / (Max - Min));

                if (debug) {
                   Console.Error.WriteLine( "map: V/dif/DIF: {0}/{1}/{2}", V, V-Min, Max - Min );
                   Console.Error.WriteLine( "map: V/t: {0}/{1}", V, t );
                }
              return    ((int)t) + min;
            }
            return 0;
        }

        public  List <Point> real2pixels(List<double[]> data  ) {
            if (data == null) {
              Console.Error.WriteLine( "graphPnl: real2pixels: no any data");
              return null;
            }
            List <Point> ps = new List <Point>();
            double []    d  = null;
            Point  foo;  // public Point (double x, double y);
            double minX=1.0E308, maxX=-1.0E308, minY=1.0E308, maxY=-1.0E308;
            int i = 0;
            for ( i = 0; i < data.Count; i++) {
              d = data[i];
              if (d!=null && d.Length >1) {
                minX = Math.Min (minX, d[0]);
                maxX = Math.Max (maxX, d[0]);
                minY = Math.Min (minY, d[1]);
                maxY = Math.Max (maxY, d[1]);
              }
            }
            if (debug)
               Console.Error.WriteLine( "graphPnl: minX/maxX/maxY/maxY: {0}/{1}/{2}/{3}",
                      minX, maxX, minY, maxY);
            for ( i = 0; i < data.Count; i++) {
              d = data[i];
              if (d!=null && d.Length >1) {
                 foo = new Point (
                      map(1, w-2, d[0], minX, maxX )
                    , h - map(1, h-2, d[1], minY, maxY )
                 );

                 ps.Add (foo);
                if (debug)
                   Console.Error.WriteLine( "graphPnl: x/y: {0}/{1}",
                          foo.X, foo.Y);
              }
            }
            return ps;         
        }
    }
}