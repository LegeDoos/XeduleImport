using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace XeduleImportHelper.Business
{
    public class Settings
    {
        /// <summary>
        /// The token
        /// </summary>
        [JsonIgnore]
        public string BearerToken { get; set; }

        /// <summary>
        /// Destination folder for file storage
        /// </summary>
        public string DestinationFolder { get; set; }

        public string DestinationSubFolder { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Persons to get information for
        /// </summary>
        [JsonIgnore]
        public List<Person> Persons { get; set; }

        public string WorkingFolder { get; set; }
        
        const string fileNameSettings = "_setting.json";
        const string fileNamePeeps = "_peeps.txt"; 
        const string fileNameToken = "_token.txt";


        public Settings()
        {    
        }

        public Settings(string _workingFolder)
        {
            WorkingFolder = _workingFolder;
        }

        // data access

        public static Settings ReadSettings(string _workingFolder)
        { 
            string fullPathSettings = Path.Combine(_workingFolder, fileNameSettings);
            string fullPathPeeps = Path.Combine(_workingFolder, fileNamePeeps);
            string fullPathToken = Path.Combine(_workingFolder, fileNameToken);
            if (!string.IsNullOrEmpty(_workingFolder) && File.Exists(fullPathSettings))
            {
                string content = File.ReadAllText(fullPathSettings);
                var theSettings = JsonSerializer.Deserialize<Settings>(content);
                theSettings.WorkingFolder = _workingFolder;

                // get peeps
                theSettings.Persons = new List<Person>();
                if (File.Exists(fullPathPeeps))
                {
                    foreach (var line in File.ReadAllLines(fullPathPeeps))
                    {
                        try
                        {
                            var peep = line.Split(";");
                            if (peep.Length == 2)
                            {
                                theSettings.Persons.Add(new Person() { XeduleId = Int32.Parse(peep[0]), Name = peep[1] });
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Invalid peeps file or error in peeps file! Error: {ex.Message}");
                        }
                    }
                }

                // get token
                if (File.Exists(fullPathToken))
                {
                    theSettings.BearerToken = File.ReadAllText(fullPathToken);
                }
                return theSettings;
            }
            else
            {
                return new Settings(_workingFolder);
            }
        }

        public void StoreSettings()
        {
            string fullPathSettings = Path.Combine(WorkingFolder, fileNameSettings);
            string fullPathPeeps = Path.Combine(WorkingFolder, fileNamePeeps);
            string fullPathToken = Path.Combine(WorkingFolder, fileNameToken);

            // write settings
            File.WriteAllText(fullPathSettings, JsonSerializer.Serialize(this));

            // write peeps
            // Create or replace a file to write to.
            using (StreamWriter sw = File.CreateText(fullPathPeeps))
            {
                foreach (var peep in Persons)
                {
                    sw.WriteLine($"{peep.XeduleId};{peep.Name.ToLower()}");
                }
            }
        
            // write token
            using (StreamWriter sw = File.CreateText(fullPathToken))
            {
                sw.WriteLine(BearerToken);
            }
        }
    }
}
