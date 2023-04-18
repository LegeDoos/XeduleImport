using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XeduleImportHelper.Business
{
    public class Settings
    {
        /// <summary>
        /// The token
        /// </summary>
        public string BearerToken { get; set; }

        /// <summary>
        /// Destination folder for file storage
        /// </summary>
        public string DestinationFolder { get; set; }

        /// <summary>
        /// Persons to get information for
        /// </summary>
        public List<Person> Persons { get; set; }

        public string WorkingFolder { get; set; }
        
        const string filename = "_setting.json";

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
            string fname = Path.Combine(_workingFolder, filename);
            if (!string.IsNullOrEmpty(_workingFolder) && File.Exists(fname))
            {
                string content = File.ReadAllText(fname);
                var retval = JsonSerializer.Deserialize<Settings>(content);
                retval.WorkingFolder = _workingFolder;
                return retval;
            }
            else
            {
                return new Settings(_workingFolder);
            }
        }

        public void StoreSettings()
        {
            string fname = Path.Combine(WorkingFolder, filename);
            File.WriteAllText(fname, JsonSerializer.Serialize(this));
        }
    }
}
