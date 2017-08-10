namespace Fabric.Terminology.Client.TestsBase.Fixtures
{
    using Fabric.Terminology.Client.Logging;
    using Moq;
    using Serilog.Core;

    public class TerminologyFixture : ApiSettingsFixture
    {
        public TerminologyFixture()
        {
            this.Initialize();
        }

        public ITerminologyContext TerminologyContext { get; private set; }

        private void Initialize()
        {
            this.TerminologyContext = new TerminologyContext(this.TerminologyApiSettings, LogFactory.CreateLogger(new LoggingLevelSwitch()));
        }
    }
}