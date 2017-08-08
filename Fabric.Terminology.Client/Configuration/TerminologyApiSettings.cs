namespace Fabric.Terminology.Client.Configuration
{
    public class TerminologyApiSettings : ITerminologyApiSettings
    {
        public string TerminologyApiUri { get; set; }

        public string ApiVersion { get; set; }
    }
}