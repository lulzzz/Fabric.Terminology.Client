namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Builder;

    public interface ITerminologyContext
    {
        ValueSetRequest ValueSets { get; }
    }
}