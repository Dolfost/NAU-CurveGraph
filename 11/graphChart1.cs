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
        Series ss =null;

        private void fillChart()  
        {  
            //AddXY value in chart1 in series named as Salary  
            ss =  new Series("disrtibute");
            ss.ChartType = SeriesChartType.Column;





            curve.Series.Add(ss);
            double []    d  = null;

            for (int i = 0; i < data.Count; i++) {
              d = data[i];
              if (d!=null && d.Length >1 ) {

                 if (hideEmpty && d[1] == 0.0)
                    continue;

                 curve.Series["disrtibute"].
                        Points.AddXY(d[0].ToString(),d[1].ToString() );  
              }
             if (debug)
                Console.Error.WriteLine( "fillChart: i{0}",i);
            }



           if (debug)
               Console.Error.WriteLine( "fillChart: is here");
        }  





         public void BarExample() {

           if (debug)
               Console.Error.WriteLine( "BarExample: is here");
 
            this.curve.Series.Clear();

            // Set palette
            this.curve.Palette = ChartColorPalette.EarthTones;

            // Set title
            this.curve.Titles.Add(">>distribution of data by class<<");

             /*
            / Add series.
            for (int i = 0; i < seriesArray.Length; i++) {
                Series series = this.curve.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }  */
            

//            this.curve.Remove();
            curve.Series.Remove (ss);
            fillChart(); 
        }  
    }
}