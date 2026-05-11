using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System;
using System.IO;
using System.Text.Json;

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
        /// Content of the ICS file
        /// </summary>
        private string targetFileContent;

        public string ResultPath { get; set; }
        public string ResultFilename { get; private set; }


        /// <summary>
        /// Constructor to construct the helper class based on the JSON API response content.
        /// </summary>
        /// <param name="icsFileContent">The JSON API response content</param>
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
            if (string.IsNullOrEmpty(targetFileContent))
            {
                throw new Exception("No source defined");
            }

            var calendar = BuildCalendarFromJson(targetFileContent);

            // apply options
            if (AddXeduleCategory)
            {
                foreach (var e in calendar.Events)
                {
                    e.Categories.Add(this.CustomCategory);
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

        /// <summary>
        /// Builds a Calendar from the JSON response of the new Appointment API.
        /// </summary>
        private static Calendar BuildCalendarFromJson(string json)
        {
            var calendar = new Calendar();

            try
            {
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (!root.TryGetProperty("result", out var result) ||
                    !result.TryGetProperty("appointments", out var appointments))
                {
                    return calendar;
                }

                foreach (var appointmentEntry in appointments.EnumerateObject())
                {
                    var appt = appointmentEntry.Value;

                    if (!appt.TryGetProperty("start", out var startProp) ||
                        !appt.TryGetProperty("end", out var endProp))
                    {
                        continue;
                    }

                    if (!DateTime.TryParse(startProp.GetString(), out var start) ||
                        !DateTime.TryParse(endProp.GetString(), out var end))
                    {
                        continue;
                    }

                    string summary = appt.TryGetProperty("summary", out var summaryProp)
                        ? summaryProp.GetString() ?? string.Empty
                        : (appt.TryGetProperty("name", out var nameProp) ? nameProp.GetString() ?? string.Empty : string.Empty);

                    string uid = appt.TryGetProperty("id", out var idProp)
                        ? idProp.GetInt64().ToString()
                        : Guid.NewGuid().ToString();

                    var calEvent = new CalendarEvent
                    {
                        Uid = uid,
                        Summary = summary,
                        DtStart = new CalDateTime(start),
                        DtEnd = new CalDateTime(end)
                    };

                    calendar.Events.Add(calEvent);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing JSON appointment response", ex);
            }

            return calendar;
        }
    }
}
