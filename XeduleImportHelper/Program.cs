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
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());


          //  Settings s = Settings.ReadSettings(@"D:\_XeduleHelper\");
          //
          //  // create teacherlist from api result
          //  //https://zuyd.myx.nl/api/Attendee/Type/Teacher
          //  //var tlist = JsonSerializer.Deserialize<Teachers>(File.ReadAllText(@"D:\_XeduleHelper\teachers.json"));
          //  //s.Persons = tlist.Result.Where(t => t.Teams != null && t.Teams.Contains(19821)).Select(i => new Person() { XeduleId = i.Id, Name = i.Code.ToLower() } ).OrderBy(p => p.Name).ToList();
          //
          //  DateTime from = new(2023, 4, 24);
          //  string resultPath = Path.Combine(s.DestinationFolder, "2022BP4");
          //  if (!Directory.Exists(resultPath))
          //  {
          //      Directory.CreateDirectory(resultPath);
          //  }
          //  else
          //  {
          //      foreach (var file in new DirectoryInfo(resultPath).GetFiles())
          //      {
          //          file.Delete();
          //      }
          //  }
          //
          //  foreach (var person in s.Persons.OrderBy(p => p.Name))
          //  {
          //      var icsResult = new XeduleAPIHelper(from, new DateTime(2023, 8, 1), person.XeduleId) { BearerToken = s.BearerToken }.CallAPI();
          //      UpdateICSFileHelper helper = new(icsResult, person.Name)
          //      {
          //          ResultPath = resultPath,
          //          RemoveAllAttendees = true,
          //          AddXeduleCategory = true
          //      };
          //      var res = helper.HandleFile();
          //      Console.WriteLine(res);
          //      Console.ReadLine();
          //  }
          //
          //  s.StoreSettings();
        }
    }
}
