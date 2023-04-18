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
        /// The category id to set
        /// </summary>
        public string CustomCategory { get; set; } = "Xedule";
        /// <summary>
        /// Remove all attendees in the file if true
        /// </summary>
        public bool RemoveAllAttendees { get; set; } = true;
        /// <summary>
        /// The sourcefile to edit
        /// </summary>
        private string SourceICSFile { get; set; }


        /// <summary>
        /// Content of the ICS file
        /// </summary>
        private string targetFileContent;


        public string ResultPath { get; set; } 
        public string ResultFilename { get; private set; }


        /// <summary>
        /// Contsructor to construct the helper class based on a given file
        /// </summary>
        /// <param name="_sourceFile">The sourcefile to edit</param>
        public UpdateICSFileHelper(string _sourceFile)
        {
            if (!string.IsNullOrEmpty(_sourceFile))
            {
                SourceICSFile = _sourceFile;
            }
            ResultFilename = $"{DateTime.Now:yyyyMMddHHmmss}_result.ics";
            ResultPath = Path.GetDirectoryName(SourceICSFile);
    }


        /// <summary>
        /// Constructor to construct the helper class based on the ics file content
        /// </summary>
        /// <param name="icsFileContent">The ICS file content</param>
        /// <param name="personName">The name of the person</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateICSFileHelper(string icsFileContent, string personName)
        {
            if (string.IsNullOrEmpty(icsFileContent))
            {
                throw new ArgumentNullException(nameof(icsFileContent));
            }
            if (string.IsNullOrEmpty(personName))
            {
                throw new ArgumentNullException(nameof(personName));
            }

            targetFileContent = icsFileContent;
            ResultFilename = $"{personName}_{DateTime.Now:yyyyMMddHHmmss}_result.ics";
        }

        /// <summary>
        /// Actually open the file and make the desired changes. Store the new file.
        /// </summary>
        /// <returns>The path to the new file</returns>
        public string HandleFile()
        {
            // check file
            if (!string.IsNullOrEmpty(SourceICSFile))
            {
                try
                {
                    targetFileContent = File.ReadAllText(SourceICSFile);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error reading file {SourceICSFile}", ex);
                }
            }

            if (string.IsNullOrEmpty(targetFileContent))
            {
                throw new Exception("No source defined");
            }

            // Deserialize
            Calendar calendar;
            try
            {
                calendar = Calendar.Load(targetFileContent);
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
                        e.Categories.Add(this.CustomCategory);
                    }
                }
            }

            // serialize
            string newFile;
            try
            {
                newFile = $"{ResultPath}\\{ResultFilename}";
                var serializer = new CalendarSerializer();
                var serializedCalendar = serializer.SerializeToString(calendar);
                File.WriteAllText(newFile, serializedCalendar);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving the new file", ex);
            }

            ResultFilename = newFile;
            return newFile;
        }
    }
}
