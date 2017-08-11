namespace Fabric.Terminology.Client.Models
{
    using Newtonsoft.Json;

    public class ValueSetCode : CodeSetCode
    {
        [JsonProperty("valueSetUniqueId")]
        public string ValueSetUniqueId { get; set; }

        [JsonProperty("valueSetOId")]
        public string ValueSetOId { get; set; }

        [JsonProperty("valueSetId")]
        public string ValueSetId { get; set; }
    }
}