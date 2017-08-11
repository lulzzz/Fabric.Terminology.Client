namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Builders;

    public interface ITerminologyContext
    {
        ValueSetRequest ValueSets { get; }
    }
}