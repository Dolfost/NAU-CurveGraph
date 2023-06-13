using System;     
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace ut{

    public  partial class graphWnd : Form {
       public List<double[]> data ;

       protected  static double sin( double degree){
               return Math.Sin(degree*(Math.PI/180) )* 3.0;
       }                                  

       public virtual double f ( double v) {return sin(v); }

       public int  table ( double min, double max, double step) {
         data =  new List<double[]>();
         int i = 0;
         double [] d = null;
         for (double x= min; x < max ; x+=step,i++){
            d= new double[2];
            d[0]= x;
            d[1]= f(x);
            data.Add(d);
         }
         return i;
       }

       private void Form1_Load(object sender, System.EventArgs e) {
              ps = new List <Point> ();            
              if (data !=null) {
                ps =  main.real2pixels(data);
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
    }

}