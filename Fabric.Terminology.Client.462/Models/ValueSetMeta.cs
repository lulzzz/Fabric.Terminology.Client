namespace Fabric.Terminology.Client.Models
{
    using Newtonsoft.Json;

    public class ValueSetMeta
    {
        [JsonProperty("authoringSourceDescription")]
        public string AuthoringSourceDescription { get; set; }

        [JsonProperty("purposeDescription")]
        public string PurposeDescription { get; set; }

        [JsonProperty("sourceDescription")]
        public string SourceDescription { get; set; }

        [JsonProperty("versionDescription")]
        public string VersionDescription { get; set; }
    }
}