namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
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
            var query = this.TerminologyContext.ValueSets.Paged().IncludeCodes();

            // Act
            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            foreach (var item in page.Values)
            {
                item.ValueSetCodes.Should().NotBeEmpty();
                item.CodeCounts.Should().NotBeEmpty();
            }
        }
    }
}
