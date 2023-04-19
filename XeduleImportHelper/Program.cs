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
        static void Main()
        {
            Settings s = Settings.ReadSettings(@"D:\_XeduleHelper\");

            DateTime from = new DateTime(2023, 4, 24);
            string resultPath = Path.Combine(s.DestinationFolder, from.ToString("yyyyMMdd"));
            if (!Directory.Exists(resultPath))
            {
                Directory.CreateDirectory(resultPath);
            }
            else
            {
                foreach (var file in new DirectoryInfo(resultPath).GetFiles())
                {
                    file.Delete();
                }
            }

            foreach (var person in s.Persons)
            {
                var icsResult = new XeduleAPIHelper(from, new DateTime(2023, 8, 1), person.XeduleId) { BearerToken = s.BearerToken }.CallAPI();
                UpdateICSFileHelper helper = new UpdateICSFileHelper(icsResult, person.Name) { ResultPath = resultPath };
                helper.RemoveAllAttendees = true;
                helper.AddXeduleCategory = true;
                var res = helper.HandleFile();
                Console.WriteLine(res);
                Console.ReadLine();
            }

            s.StoreSettings();
        }
    }
}
