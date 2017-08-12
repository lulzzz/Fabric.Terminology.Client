namespace Fabric.Terminology.Client.Configuration
{
    using Fabric.Terminology.Client.Models;

    public interface ITerminologyApiSettings
    {
        string TerminologyApiUri { get; set; }

        string ApiVersion { get; set; }

        ValueSetMeta ValueSetMeta { get; set; }
    }
}