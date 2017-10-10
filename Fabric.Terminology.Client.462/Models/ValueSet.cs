namespace Fabric.Terminology.Client.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ValueSet : ValueSetMeta
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("valueSetGuid")]
        public Guid ValueSetGuid { get; set; }

        [JsonProperty("valueSetReferenceId")]
        public string ValueSetReferenceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("originGuid")]
        public Guid OriginGuid { get; set; }

        [JsonProperty("clientCode")]
        public string ClientCode { get; set; }

        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [JsonProperty("isLatestVersion")]
        public bool IsLatestVersion { get; set; }

        [JsonProperty("codeCounts")]
        public IReadOnlyCollection<ValueSetCodeCount> CodeCounts { get; set; } = new List<ValueSetCodeCount>();

        [JsonProperty("valueSetCodes")]
        public IReadOnlyCollection<ValueSetCode> ValueSetCodes { get; set; } = new List<ValueSetCode>();
    }
}