namespace Fabric.Terminology.Client.Configuration
{
    using Fabric.Terminology.Client.Models;

    public class TerminologyApiSettings : ITerminologyApiSettings
    {
        public string TerminologyApiUri { get; set; }

        public string ApiVersion { get; set; }
    }
}