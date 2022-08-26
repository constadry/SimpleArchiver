using Newtonsoft.Json;

namespace SimpleArchiver.Models
{
    public class Config
    {
        [JsonProperty("sourceFolder", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceFolder { get; set; }

        [JsonProperty("targetFolder", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetFolder { get; set; }
    }
}