namespace Fabric.Terminology.Client.Models
{
    using System;
    using Newtonsoft.Json;

    public class ValueSetCode : CodeSetCode
    {
        [JsonProperty("valueSetGuid")]
        public Guid ValueSetGuid { get; set; }
    }
}