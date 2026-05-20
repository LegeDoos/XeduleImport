using System.Collections.Generic;
using System.Text.Json.Serialization;

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
