namespace Fabric.Terminology.Client.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FindByTermQuery
    {
        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("pagerSettings")]
        public PagerSettings PagerSettings { get; set; }

        [JsonProperty("codeSystemGuids")]
        public IEnumerable<Guid> CodeSystemGuids { get; set; }

        [JsonProperty("summary")]
        public bool Summary { get; set; } = true;
    }
}