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
            Application.Run(new ManagerForm1("101",""));
            //Application.Run(new Excel_Import());
            //Application.Run(new DialogForm("فایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشد فایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشدفایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشدفایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشد." , "خطا","error"));
            //Application.Run(new DialogForm("فایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشد فایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشدفایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشدفایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشد.", "ثبت موفقیت آمیز", "success"));
            //Application.Run(new DialogForm("فایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشد فایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشدفایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشدفایل ورودی اشتباه است، تعداد ستون ها یا یکی از اطلاعات اشتباه می باشد.", "اطلاعات", "information"));
        }
    }
}
