using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bag3WinForm
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // clsBag.LoadPaintingForm = new clsBag.LoadPaintingFormDelegate(frmBag.Run);
          //  clsbrand.LoadPhotographForm = new clsbrand.LoadPhotographFormDelegate(frmbrand.Run);
            Application.Run(frmMain.Instance);
        }
    }
}

