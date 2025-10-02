using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XeduleImportHelper.Business
{
    /// <summary>
    /// Helper class to import teachers from api call result
    /// </summary>
    public class Teachers
    {
        [JsonPropertyName("result")]
        public List<Teacher> Result { get; set; }
    }
}
