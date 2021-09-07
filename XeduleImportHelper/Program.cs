using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XeduleImportHelper.UI;

namespace XeduleImportHelper
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Remove all attendees from the ics file");
        //    UpdateICSFileHelper helper = new(@"d:\ICSData\2021-2022 Periode 1.ics");
        //    helper.RemoveAllAttendees = true;
        //    helper.AddXeduleCategory = true;
        //    Console.WriteLine(helper.HandleFile());
        //}

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
