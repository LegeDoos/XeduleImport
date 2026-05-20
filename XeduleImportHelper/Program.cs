using System;
using System.Windows.Forms;
using XeduleImportHelper.UI;

namespace XeduleImportHelper
{
    class Program
    {
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
