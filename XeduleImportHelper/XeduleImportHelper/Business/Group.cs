using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XeduleImportHelper.Business
{
    public class Group
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }

    public class Groups
    {
        [JsonPropertyName("result")]
        public List<Group> Result { get; set; }
    }
}
