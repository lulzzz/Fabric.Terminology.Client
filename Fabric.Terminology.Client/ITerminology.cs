namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Services;

    public interface ITerminology
    {
        IValueSetApiService ValueSet { get; }
    }
}