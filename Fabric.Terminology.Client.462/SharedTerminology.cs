namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Builders;

    public class SharedTerminology : ISharedTerminology
    {
        public SharedTerminology(IApiRequestFactory requestFactory)
        {
            this.ValueSets = new ValueSetRequest(requestFactory);
        }

        public ValueSetRequest ValueSets { get; }
    }
}