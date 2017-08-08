namespace Fabric.Terminology.Client.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ValueSet : ValueSetMeta
    {
        [JsonProperty("valueSetUniqueId")]
        public string ValueSetUniqueId { get; set; }

        [JsonProperty("valueSetId")]
        public string ValueSetId { get; set; }

        [JsonProperty("valueSetOId")]
        public string ValueSetOId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [JsonProperty("allCodesLoaded")]
        public bool AllCodesLoaded { get; set; }

        [JsonProperty("valueSetCodesCount")]
        public int ValueSetCodesCount { get; set; }

        [JsonProperty("valueSetCodes")]
        public IReadOnlyCollection<ValueSetCode> ValueSetCodes { get; set; }
    }
}