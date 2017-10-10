using Newtonsoft.Json;

namespace Fabric.Terminology.Client.Models
{
    using System;

    public class ValueSetCodeCount
    {
        [JsonProperty("valueSetGuid")]
        public string ValueSetGuid { get; internal set; }

        [JsonProperty("codeSystemGuid")]
        public Guid CodeSystemGuid { get; internal set; }

        [JsonProperty("codeCount")]
        public int CodeCount { get; internal set; }
    }
}