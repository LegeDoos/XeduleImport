using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using XeduleImportHelper.Business;
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
            Settings s = Settings.ReadSettings(@"D:\_XeduleHelper\");
            s.BearerToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhMjU2Iiwia2lkIjpudWxsLCJ0eXAiOiJKV1QifQ.eyJ1c2VyIjoiOWQwMjRiOTEtMDk4ZC00NTA1LTk4NWYtZDQyYTI0NzQ2N2UwIiwibmFtZSI6ImNpbGlzciIsImF0bklkIjoxOTI3NCwicm9sZSI6InRlYWNoZXIiLCJhdWQiOiJsaXZlLnp1eWQvQXBpIiwiaXNzIjoibGl2ZS56dXlkL0F1dGhlbnRpY2F0aW9uIiwiZXhwIjoiMTY4MTg1MjA3NCIsImlhdCI6IjE2ODE4MDg4NzQiLCJuYmYiOiIxNjgxODA4ODc0In0.D3Te9wMmO7hg5tRCa8SkoLhGrWAPG1YU-Q-d7I7QTk7k33h27PW4Y9r_V88Ze5lwcd5kPQ52pGoPioA0IlLehyP3gZzayP2YsXuZZCTXoU8-evJGO6wbWCFBfLocrQ9UJS-5DQE9pbc4Ah3m0RLdGi91vpt_8PfqGeQcL85_1RV4Z5cbtKtUNyU6w61tMkR_1EQl0yFanLAeRbI1AihZsiakHcVnaevaFOPorXuAJFKyVqbiPQ3paIorELBFWiVa-5-B6bZPDbeohiGcgJLn9i9FzbaBRPnHuI0XGAw7HK07J9LAkNZzx1DMTChkCryQaf0tbWtVGb-EUBEOQmi5Vg";
            s.DestinationFolder = @"D:\_XeduleHelper\";
            
            s.Persons.Add(new Person() { XeduleId = 19274, Name = "cilissenr" }  );
            s.StoreSettings();


            var icsResult = new XeduleAPIHelper(19456) { BearerToken = s.BearerToken }.CallAPI();
            UpdateICSFileHelper helper = new UpdateICSFileHelper(icsResult, "tossaintbgm") { ResultPath = @"d:\CorrectieWerk" };
            helper.RemoveAllAttendees = true;
            helper.AddXeduleCategory = true;
            var res = helper.HandleFile();
            Console.WriteLine(res);
            Console.ReadLine();
            /*
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());*/
        }
    }
}
