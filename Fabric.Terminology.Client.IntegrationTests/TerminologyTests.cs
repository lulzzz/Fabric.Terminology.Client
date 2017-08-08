using Fabric.Terminology.Client.Builder;

namespace Fabric.Terminology.Client.IntegrationTests
{
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.TestsBase;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class TerminologyTests : OutputTestBase, IClassFixture<TerminologyFixture>
    {
        private readonly ITerminology terminology;

        public TerminologyTests(ITestOutputHelper output, TerminologyFixture fixture)
            : base(output)
        {
            this.terminology = fixture.Terminology;
        }

        [Theory]
        [InlineData("00149FF4-480E-4625-8281-500FB6D327E3")]
        [InlineData("003DB2E6-77F1-4449-B085-044B20BD179C")]
        [InlineData("01F981E5-2C94-4850-B6DA-03BBAF46E3ED")]
        [InlineData("1297BB11-927B-438C-9715-853FED36C300")]
        [InlineData("17316FBA-0D34-400A-B30E-47895EFAD962")]
        public void CanGetValueSet(string valueSetUniqueId)
        {
            // Arrange

            // Act
            var maybe = this.Profiler.ExecuteTimed(async () => await this.terminology.ValueSets.WithUniqueId(valueSetUniqueId).Execute());
            maybe.HasValue.Should().BeTrue();
            var valueSet = maybe.Single();

            // Assert
            valueSet.Should().NotBeNull();
            valueSet.ValueSetUniqueId.Should().Be(valueSetUniqueId);
        }
    }
}