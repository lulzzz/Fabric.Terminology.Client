namespace Fabric.Terminology.Client.Models
{
    using Newtonsoft.Json;

    public class PagerSettings
    {
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; } = 1;

        [JsonProperty("itemsPerPage")]
        public int ItemsPerPage { get; set; } = 20;
    }
}