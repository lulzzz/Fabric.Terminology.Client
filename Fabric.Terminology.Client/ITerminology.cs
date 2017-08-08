namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Builder;
    using Fabric.Terminology.Client.Services;

    public interface ITerminology
    {
        ValueSetRequest ValueSets { get; }
    }
}