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
        public static int  w = 800;
        public static int  h = 500;
        public static int  a = 50;
        public static Color c = Color.Gray;
        public bool debug   = false;


        
        public graphPnl()
        {                 

          Dock = DockStyle.Top;
          Size      = new Size (w,h);
          BackColor =  c;
        }


    }
}