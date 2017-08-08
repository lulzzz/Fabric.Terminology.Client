namespace Fabric.Terminology.Client.Models
{
    using System;
    using Newtonsoft.Json;

    public class CodeSetCode
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("codeSystem")]
        public CodeSystem CodeSystem { get; set; }

        [JsonProperty("sourceDescription")]
        public string SourceDescription { get; set; }

        [JsonProperty("versionDescription")]
        public string VersionDescription { get; set; }

        [JsonProperty("lastLoadDate")]
        public DateTime LastLoadDate { get; set; }
    }
}