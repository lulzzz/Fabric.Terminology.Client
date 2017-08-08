namespace Fabric.Terminology.Client.TestsBase.Fixtures
{
    public class TerminologyFixture : ApiSettingsFixture
    {
        public TerminologyFixture()
        {
            this.Initialize();
        }

        public ITerminology Terminology { get; private set; }

        private void Initialize()
        {
            this.Terminology = new Terminology(this.TerminologyApiSettings);
        }
    }
}