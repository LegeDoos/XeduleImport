using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using XeduleImportHelper.Business;

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
        /// JSON API response content from the Appointment endpoint
        /// </summary>
        private string targetFileContent;
        /// <summary>
        /// Targe filename for the new file. Will be generated based on the person name and current timestamp.
        /// </summary>
        private string resultFilename;
        /// <summary>
        /// Lookup from group id to group code
        /// </summary>
        private Dictionary<int, string> groupLookup = new();

        /// <summary>
        /// Lookup from classroom id to classroom code
        /// </summary>
        private Dictionary<int, string> classroomLookup = new();
        /// <summary>
        /// Gets or sets the file system path where the result is stored.
        /// </summary>
        public string ResultPath { get; set; }



        /// <summary>
        /// Constructor to construct the helper class based on the JSON API response content.
        /// </summary>
        /// <param name="appointmentJsonContent">The JSON API response content from the Appointment endpoint</param>
        /// <param name="personName">The name of the person</param>
        /// <param name="groups">List of groups to resolve group ids to codes</param>
        /// <param name="classrooms">List of classrooms to resolve classroom ids to codes</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateICSFileHelper(string appointmentJsonContent, string personName, List<Group> groups = null, List<Classroom> classrooms = null)
        {
            if (string.IsNullOrEmpty(appointmentJsonContent))
            {
                throw new ArgumentNullException(nameof(appointmentJsonContent));
            }
            if (string.IsNullOrEmpty(personName))
            {
                throw new ArgumentNullException(nameof(personName));
            }

            targetFileContent = appointmentJsonContent;
            resultFilename = $"{personName}_{DateTime.Now:yyyyMMddHHmmss}_result.ics";

            if (groups != null)
            {
                foreach (var g in groups)
                    groupLookup[g.Id] = g.Code;
            }

            if (classrooms != null)
            {
                foreach (var c in classrooms)
                    classroomLookup[c.Id] = c.Code;
            }
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

            var calendar = BuildCalendarFromJson(targetFileContent, groupLookup, classroomLookup);

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
                newFile = $"{ResultPath}\\{resultFilename}";
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

        /// <summary>
        /// Builds a Calendar from the JSON response of the new Appointment API.
        /// </summary>
        private static Calendar BuildCalendarFromJson(string json, Dictionary<int, string> groupLookup, Dictionary<int, string> classroomLookup)
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

                    string code = appt.TryGetProperty("code", out var codeProp)
                        ? codeProp.GetString() ?? string.Empty
                        : string.Empty;

                    string summary = appt.TryGetProperty("summary", out var summaryProp)
                        ? summaryProp.GetString() ?? string.Empty
                        : (appt.TryGetProperty("name", out var nameProp) ? nameProp.GetString() ?? string.Empty : string.Empty);

                    string published = appt.TryGetProperty("published", out var publishedProp)
                        ? publishedProp.GetString() ?? string.Empty
                        : string.Empty;

                    string publishedBy = appt.TryGetProperty("publishedBy", out var publishedByProp)
                        ? publishedByProp.GetString() ?? string.Empty
                        : string.Empty;

                    string uid = appt.TryGetProperty("id", out var idProp)
                        ? idProp.GetInt64().ToString()
                        : Guid.NewGuid().ToString();

                    // Resolve group ids to codes
                    var groupCodes = new List<string>();
                    appt.TryGetProperty("attendeeIds", out var attendeeIds);
                    if (attendeeIds.ValueKind == JsonValueKind.Object &&
                        attendeeIds.TryGetProperty("group", out var groupIds) &&
                        groupIds.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var gid in groupIds.EnumerateArray())
                        {
                            int id = gid.GetInt32();
                            if (groupLookup.TryGetValue(id, out var gCode))
                                groupCodes.Add(gCode);
                        }
                    }

                    // Resolve classroom ids to codes
                    var classroomCodes = new List<string>();
                    if (attendeeIds.ValueKind == JsonValueKind.Object &&
                        attendeeIds.TryGetProperty("classroom", out var classroomIds) &&
                        classroomIds.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var cid in classroomIds.EnumerateArray())
                        {
                            int id = cid.GetInt32();
                            if (classroomLookup.TryGetValue(id, out var cCode))
                                classroomCodes.Add(cCode);
                        }
                    }

                    string classroomsText = classroomCodes.Count > 0 ? string.Join(", ", classroomCodes) : string.Empty;

                    string groupsText = groupCodes.Count > 0 ? string.Join(", ", groupCodes) : string.Empty;
                    string title = string.IsNullOrEmpty(groupsText) ? code : $"{code} | {groupsText}";

                    var bodyLines = new System.Text.StringBuilder();
                    if (!string.IsNullOrEmpty(summary))
                        bodyLines.AppendLine($"Omschrijving: {summary}");
                    if (!string.IsNullOrEmpty(groupsText))
                        bodyLines.AppendLine($"Groep(en): {groupsText}");
                    if (!string.IsNullOrEmpty(classroomsText))
                        bodyLines.AppendLine($"Lokaal: {classroomsText}");
                    if (!string.IsNullOrEmpty(published) && DateTime.TryParse(published, out var publishedDate))
                        bodyLines.AppendLine($"Gepubliceerd: {publishedDate:dd-MM-yyyy HH:mm}");
                    if (!string.IsNullOrEmpty(publishedBy))
                        bodyLines.AppendLine($"Gepubliceerd door: {publishedBy}");

                    var calEvent = new CalendarEvent
                    {
                        Uid = uid,
                        Summary = title,
                        Location = classroomsText,
                        Description = bodyLines.ToString().TrimEnd(),
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
