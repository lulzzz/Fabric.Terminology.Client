namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
    using Fabric.Terminology.Client.TestsBase;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class ValueSetRequestTestBase : OutputTestBase, IClassFixture<TerminologyFixture>
    {
        protected ValueSetRequestTestBase(ITestOutputHelper output, TerminologyFixture fixture)
            : base(output)
        {
            this.TerminologyContext = fixture.TerminologyContext;
        }

        protected ITerminologyContext TerminologyContext { get; }
    }
}
