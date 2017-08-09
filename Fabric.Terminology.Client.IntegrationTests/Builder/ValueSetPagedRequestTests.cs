namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
    using System.Linq;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class ValueSetPagedRequestTests : ValueSetRequestTestBase
    {
        public ValueSetPagedRequestTests(ITestOutputHelper output, TerminologyFixture fixture)
            : base(output, fixture)
        {
        }

        [Fact]
        public void CanGetValueSetPage()
        {
            // Arrange
            var query = this.TerminologyContext.ValueSets.Paged().IncludeAllCodes();

            // Act
            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.Values.All(vs => vs.ValueSetCodes.Any()).Should().BeTrue("all value sets should have codes.");
        }
    }
}
