using System.Threading;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using ut;
using Args;

#pragma warning disable 642 



namespace tstCurveGraph {                         
    static partial class gbl {
        static public ArgFlg  hlpF ;
        static public ArgFlg  dbgF ;
//        static public ArgFlg  expF ;
        static public ArgFlg  vF ;    
        //  подписывать номера точек
        static public ArgFlg  lnF ;  // рисовать линии или точки
      //  static public ArgFloatMM  perCent ;
        static public ArgStr  flNm ;  // имя файла с точками
         static  gbl (){
           hlpF   =  new ArgFlg(false, "?","help",    "to see this help");
           vF     =  new ArgFlg(false, "v",  "verbose", "additional info");
           lnF    =  new ArgFlg(false, "ln",  "line",    "line flag");
           dbgF   =  new ArgFlg(false, "d",  "debug",   "debug mode");
//           expF   =  new ArgFlg(false, "e",  "expFunc",   "new func");
            //logLvl.show = false;
           flNm   =  new ArgStr("null", "f", "file", "data file", "FLNM");
         //  flNm.required = true;
/*
           perCent   =  new ArgFloatMM(0.05, "p", "percent", "percent for something",  "PPP");
           perCent.setMax(100.0);
*/      }
        static public  void usage(){
           Args.Arg.mkVHelp("to show functions of two arguments", "", vF
                ,hlpF
                ,dbgF
//                ,expF
                ,vF
                ,flNm
                );
                Environment.Exit(1);
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(	string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU", false);
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);

           for (int i = 0; i<args.Length; i++){
             if (hlpF.check(ref i, args))
               usage();
             else if (dbgF.check(ref i, args))
               ;
             else if (vF.check(ref i, args))
               ;
             else if (lnF.check(ref i, args))
               ;
             else if (flNm.check(ref i, args))
               ;
           }

           DateTime st = 	DateTime.Now;

              if (vF)
              Console.Error.WriteLine("I'l started  with {0}/{1} ",  (string)flNm, (bool)dbgF);

              Process proc = Process.GetCurrentProcess();

              long gTMst, pWSst, pVMst; 

              if ((bool)dbgF) graphPnl.debug = true;

              graphPnl   p = new graphPnl();

              List<double[]> data= null;
                                                                      
              if ((bool)dbgF)  
                 graphWnd.debug = true;



              graphWnd   x = new graphWnd("test1", 10, p);

              {
                 ArgStr user = new ArgStr("NuFoo", "pwd", "user", "input your login here");
                 user.edit = false;           // запрет редактирования

                 ArgStr pwd = new ArgStr("default", "pwd", "password", "input your password here");
                 pwd.isPassword = true;       // забить звездочками вводимое значение

                 ArgStr email = new ArgStr("email@example.com", "email", "email", "email of user");
                 email.txtChanged = check;    // вызвать метод check для проверки правильности ввода
                 ArgStr test_Str_Arr = new ArgStr("Black", "c", "color", "color", "chose some color"
                   , WCNST.colors             // показать список возможных альтернатив
                 
                 );
                        

                 OkCancelDlg it = new OkCancelDlg( "window to input some params", null //Logger
                                    , user
                                    , pwd
                                    , email
                                    , perCent
                                    , test_Str_Arr );

                 DialogResult rc = it.ShowDialog();

                 if (rc == DialogResult.OK) {
                    Console.WriteLine ("your input : {0}/{1}/{2}/{3}/{4}"
                      ,  (string)user
                      ,  (string)pwd
                      ,  (string)email
                      ,  (string)test_Str_Arr
                      ,  (double) perCent
                      
                      );
                 }
                 else 
                    Console.WriteLine ("nothing to show");
              
              
              
              
              }



              if (flNm != "null") {
                 data = readFile (flNm);
                 x.data = data;
              }
              else {
                 ArgFloatMM  minX   =  new ArgFloatMM(0.00, "min", "minimum X", "minimum X",  "MIN");
                 minX.setMax(90.0);
                 ArgFloatMM  maxX   =  new ArgFloatMM(720.00, "max", "maximum X", "maximum X",  "MAX");
                 minX.setMin(650.0);
                 ArgFloatMM  stepX   =  new ArgFloatMM(720.00, "step", "step X", "step X",  "STEP");
                 minX.setMin(650.0);

                 OkCancelDlg tblPar = new OkCancelDlg( "window to input some params", null //Logger
                                      , minX
                                      , maxX
                                      , stepX );

                 DialogResult rc = tblPar.ShowDialog();

                 if (rc == DialogResult.OK)
                     x.table(minX, maxX, stepX);
                 else
                     goto finish;

              }
              if ((bool)dbgF)   { 
                Console.Error.WriteLine("data  count {0}", x.data.Count );
              }




              string info = String.Format(
                "Total Mem/virMem/GC mem: {0}/{1}/{2} kBytes"
                    , (pWSst = proc.PeakWorkingSet64/1024)
                       , (pVMst = proc.PeakVirtualMemorySize64/1024)
                          , (gTMst = GC.GetTotalMemory(false)/1024));   //Retrieves the number of bytes currently thought to be allocated. 


              if (vF)
                Console.Error.WriteLine(info);
                
              x.ShowDialog();


              finish:
              proc = Process.GetCurrentProcess();

              info = String.Format(
                "Total Mem/virMem/GC mem: {0}/{1}/{2} kBytes"
                    , (proc.PeakWorkingSet64/1024 )
                       , (proc.PeakVirtualMemorySize64/1024 )
                          , (GC.GetTotalMemory(false)/1024));   //Retrieves the number of bytes currently thought to be allocated. 


              if (vF)
              Console.Error.WriteLine(info);

              DateTime fn = DateTime.Now;

              if (vF)
              Console.Error.WriteLine( "time of work with file '{1}' is {0} secs"
                   , (fn - st).TotalSeconds, (string)flNm);

//              Thread.Sleep(1000);
           }

        }


}                	