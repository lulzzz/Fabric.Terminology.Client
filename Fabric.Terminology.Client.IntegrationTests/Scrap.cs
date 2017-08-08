using Fabric.Terminology.Client.TestsBase.Fixtures;

namespace Fabric.Terminology.Client.IntegrationTests
{
    using Fabric.Terminology.Client.TestsBase;
    using Xunit;
    using Xunit.Abstractions;

    public class Scrap : OutputTestBase, IClassFixture<ApiSettingsFixture>
    {
        private readonly ApiSettingsFixture apiSettings;

        public Scrap(ITestOutputHelper output, ApiSettingsFixture apiSettings)
            : base(output)
        {
            this.apiSettings = apiSettings;
        }

        [Fact]
        public void CanGetSettings()
        {
            this.Output.WriteLine(this.apiSettings.TerminologyApiSettings.TerminologyApiUri);
        }
    }
}