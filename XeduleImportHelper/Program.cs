using Ical.Net;
using Ical.Net.Serialization;
using System;
using System.IO;

namespace XeduleImportHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Remove all attendees from the ics file");
            UpdateICSFileHelper helper = new(@"d:\ICSData\2021-2022 Periode 1.ics");
            helper.RemoveAllAttendees = true;
            helper.AddXeduleCategory = true;
            Console.WriteLine(helper.HandleFile());
        }
    }
}
