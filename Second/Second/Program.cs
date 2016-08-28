using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Second
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new login1());
            //Application.Run(new ManagerForm1());
            //Application.Run(new Excel_Import());
            Application.Run(new Error("فایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشد."));
        }
    }
}
