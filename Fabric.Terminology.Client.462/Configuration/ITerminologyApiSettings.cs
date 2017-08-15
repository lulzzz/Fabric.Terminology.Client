namespace Fabric.Terminology.Client.Configuration
{
    using Fabric.Terminology.Client.Models;

    public interface ITerminologyApiSettings
    {
        string TerminologyApiUri { get; }

        string ApiVersion { get; }

        ValueSetMeta ValueSetMeta { get; }
    }
}