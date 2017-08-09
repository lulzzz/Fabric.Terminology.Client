namespace Fabric.Terminology.Client.TestsBase.Fixtures
{
    public class TerminologyFixture : ApiSettingsFixture
    {
        public TerminologyFixture()
        {
            this.Initialize();
        }

        public ITerminologyContext TerminologyContext { get; private set; }

        private void Initialize()
        {
            this.TerminologyContext = new TerminologyContext(this.TerminologyApiSettings);
        }
    }
}