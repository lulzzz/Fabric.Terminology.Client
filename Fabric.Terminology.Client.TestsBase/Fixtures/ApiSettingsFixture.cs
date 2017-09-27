namespace Fabric.Terminology.Client.TestsBase.Fixtures
{
    using System;
    using Fabric.Terminology.Client.Configuration;

    public class ApiSettingsFixture : IDisposable
    {
        public ApiSettingsFixture()
        {
            this.TerminologyApiSettings = TestHelper.GetConfig();
        }

        public ITerminologyApiSettings TerminologyApiSettings { get; }

        public virtual void Dispose()
        {
        }
    }
}