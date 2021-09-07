using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeduleImportHelper
{
    /// <summary>
    /// Class to import the ICS file and change the desired properties
    /// </summary>
    public class UpdateICSFileHelper
    {
        /// <summary>
        /// Add the schedule category to each event if true
        /// </summary>
        public bool AddXeduleCategory { get; set; } = true;
        /// <summary>
        /// Remove all attendees in the file if true
        /// </summary>
        public bool RemoveAllAttendees { get; set; } = true;
        /// <summary>
        /// The sourcefile to edit
        /// </summary>
        private string SourceICSFile { get; set; }

        /// <summary>
        /// Contsructor to construct the helper class
        /// </summary>
        /// <param name="_sourceFile">The sourcefile to edit</param>
        public UpdateICSFileHelper(string _sourceFile)
        {
            if (!string.IsNullOrEmpty(_sourceFile))
            {
                SourceICSFile = _sourceFile;
            }
        }

        /// <summary>
        /// Actually open the file and make the desired changes. Store the new file.
        /// </summary>
        /// <returns>The path to the new file</returns>
        public string HandleFile()
        {
            // check file            
            string icsFileContent;
            if (SourceICSFile == null)
            {
                throw new Exception("No sourcefile defined");
            }
            try
            {
                icsFileContent = File.ReadAllText(SourceICSFile);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading file {SourceICSFile}", ex);
            }

            // Deserialize
            Calendar calendar;
            try
            {
                calendar = Calendar.Load(icsFileContent);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deserializing calendar", ex);
            }

            // remove all attendees
            if (calendar != null && (RemoveAllAttendees || AddXeduleCategory))
            {
                foreach (var e in calendar.Events)
                {
                    if (RemoveAllAttendees)
                    {
                        e.Attendees.Clear();
                    }
                    if (AddXeduleCategory)
                    {
                        e.Categories.Add("Xedule");
                    }
                }
            }

            // serialize
            string newFile;
            try
            {
                newFile = $"{Path.GetDirectoryName(SourceICSFile)}\\{DateTime.Now:yyyyMMddHHmmss}_result.ics";
                var serializer = new CalendarSerializer();
                var serializedCalendar = serializer.SerializeToString(calendar);
                File.WriteAllText(newFile, serializedCalendar);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving the new file", ex);
            }

            return newFile;
        }
    }
}
