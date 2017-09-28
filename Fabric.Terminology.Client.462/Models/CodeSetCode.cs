namespace Fabric.Terminology.Client.Models
{
    using System;
    using Newtonsoft.Json;

    public class CodeSetCode
    {
        [JsonProperty("codeGuid")]
        public Guid CodeGuid { get; internal set; }

        [JsonProperty("code")]
        public string Code { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("codeSystemGuid")]
        public Guid CodeSystemGuid { get; internal set; }
    }
}