namespace Fabric.Terminology.Client.Models
{
    using Newtonsoft.Json;

    public class CodeSystem
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}