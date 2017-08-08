namespace Fabric.Terminology.Client.Configuration
{
    public interface ITerminologyApiSettings
    {
        string TerminologyApiUri { get; set; }

        string ApiVersion { get; set; }
    }
}