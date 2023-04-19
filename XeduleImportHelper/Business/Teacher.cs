using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XeduleImportHelper.Business
{
    /// <summary>
    /// helper class to deserialize the teachers from Xedule
    /// </summary>
    public class Teacher
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("teams")]
        public List<int> Teams{ get; set; }
    }
}
