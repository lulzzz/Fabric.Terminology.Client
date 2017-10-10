namespace Fabric.Terminology.Client.Models
{
    using System;
    using Newtonsoft.Json;

    public class ValueSetMeta
    {
        [JsonProperty("versionDate")]
        public DateTime VersionDate { get; set; }

        [JsonProperty("definiionDescription")]
        public string DefinitionDescription { get; set; }

        [JsonProperty("authoringSourceDescription")]
        public string AuthoringSourceDescription { get; set; }

        [JsonProperty("sourceDescription")]
        public string SourceDescription { get; set; }
    }
}