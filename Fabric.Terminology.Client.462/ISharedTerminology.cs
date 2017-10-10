namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Builders;

    public interface ISharedTerminology
    {
        ValueSetRequest ValueSets { get; }
    }
}