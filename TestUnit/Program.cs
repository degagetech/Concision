using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Concision;
using System.IO.Ports;

namespace TestUnit
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            Application.EnableVisualStyles();
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LightForm());
            Application.Run(new Form2());
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
           // throw new NotImplementedException();
        }
    }
}
