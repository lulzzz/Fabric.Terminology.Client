namespace Fabric.Terminology.Client.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ValueSetCreation : ValueSetMeta
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("codeSetCodes")]
        public IEnumerable<CodeSetCode> CodeSetCodes { get; set; }
    }
}