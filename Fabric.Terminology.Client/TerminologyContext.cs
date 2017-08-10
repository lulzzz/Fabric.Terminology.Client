namespace Fabric.Terminology.Client
{
    using Fabric.Terminology.Client.Builders;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Logging;

    public class TerminologyContext : ITerminologyContext
    {
        public TerminologyContext(ITerminologyApiSettings settings, ILogger logger)
        {
            this.ValueSets = new ValueSetRequest(settings, logger);
        }

        public ValueSetRequest ValueSets { get; }
    }
}