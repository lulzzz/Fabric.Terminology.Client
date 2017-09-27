namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
    using System.Linq;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class ValueSetListRequestTests : ValueSetRequestTestBase
    {
        public ValueSetListRequestTests(ITestOutputHelper output, TerminologyFixture fixture)
            : base(output, fixture)
        {
        }

        [Fact]
        public void CanGetValueSetList()
        {
            // Arrange
            var ids = new[]
            {
                "00149FF4-480E-4625-8281-500FB6D327E3",
                "003DB2E6-77F1-4449-B085-044B20BD179C",
                "01F981E5-2C94-4850-B6DA-03BBAF46E3ED",
                "1297BB11-927B-438C-9715-853FED36C300",
                "17316FBA-0D34-400A-B30E-47895EFAD962"
            };

            // Act
            var query = this.TerminologyContext.ValueSets.WithUniqueIdsIn(ids);

            var valueSets = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            valueSets.Any().Should().BeTrue("passed five valid unique ids.");
            valueSets.Count.Should().Be(5, "five valid unique ids were requested.");
            valueSets.All(vs => vs.ValueSetCodes.Any()).Should().BeTrue("All value sets should have codes.");
        }
    }
}
