using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XeduleImportHelper.Business
{
    public class Classroom
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
    }

    public class Classrooms
    {
        [JsonPropertyName("result")]
        public List<Classroom> Result { get; set; }
    }
}
