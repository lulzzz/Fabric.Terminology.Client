namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Builder;
    using Fabric.Terminology.Client.Configuration;

    public class Terminology : ITerminology
    {
        public Terminology(ITerminologyApiSettings settings)
        {
            this.ValueSets = new ValueSetRequest(settings);
        }

        public ValueSetRequest ValueSets { get; }
    }
}