namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Builders;
    using Fabric.Terminology.Client.Configuration;

    public class TerminologyContext : ITerminologyContext
    {
        public TerminologyContext(ITerminologyApiSettings settings)
        {
            this.ValueSets = new ValueSetRequest(settings);
        }

        public ValueSetRequest ValueSets { get; }
    }
}