using Newtonsoft.Json;

namespace SimpleArchiver.Models
{
    public class Config
    {
        [JsonProperty("sourceFolders", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SourceFolders { get; set; }

        [JsonProperty("targetFolder", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetFolder { get; set; }
    }
}