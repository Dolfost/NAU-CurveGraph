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
    public  partial class graphWnd : Form {
        const int padding = 10;
        public static bool debug   = false;
        Pen pB;
        Brush  bBrush ;
        Panel x;
        graphPnl main;
        string text;

        public List <Point> ps;                       ///<���������� ����� ����� � ��������

//        public graphWnd(string name, int p, Panel graphP)
        public graphWnd(string name, int p, graphPnl graphP) {                 
            main =  graphP;
            SuspendLayout();
             ToolBar tb = new ToolBar();
             tb.ButtonSize = new System.Drawing.Size((int)(200/ 3),  (int)(40)  );
             ToolBarButton tlbExit = new ToolBarButton("Exit");
             tlbExit.ToolTipText = "������� ���� �������";
             ToolBarButton tIns  = new ToolBarButton("Insert");
             tIns.ToolTipText = "�������� ������";

             Padding = new Padding(2);
             tb.Buttons.AddRange(new ToolBarButton[] { 
                    tIns
                  , tlbExit
                  }
             );
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
            Controls.Add(tb);
            
            
            
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


            Load +=  Form1_Load;
         }

        void Draw1(Graphics g) {

           if (debug)
              Console.Error.WriteLine( "paint is ready");
            g.DrawString(text, this.Font, bBrush, 20, 20);
 
         }


        void paint2(object s, PaintEventArgs e)
        {
           if (ps == null)
              Console.Error.WriteLine( "paint2: no any data");
           else
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