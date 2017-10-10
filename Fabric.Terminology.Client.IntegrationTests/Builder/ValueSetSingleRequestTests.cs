namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
    using System;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class ValueSetSingleRequestTests : ValueSetRequestTestBase
    {
        public ValueSetSingleRequestTests(ITestOutputHelper output, TerminologyFixture fixture)
            : base(output, fixture)
        {
        }

        [Theory]
        [InlineData("00149FF4-480E-4625-8281-500FB6D327E3")]
        [InlineData("003DB2E6-77F1-4449-B085-044B20BD179C")]
        [InlineData("01F981E5-2C94-4850-B6DA-03BBAF46E3ED")]
        [InlineData("1297BB11-927B-438C-9715-853FED36C300")]
        [InlineData("17316FBA-0D34-400A-B30E-47895EFAD962")]
        public void CanGetValueSet(string valueSetReferenceId)
        {
            // Arrange
            var valueSetGuid = Guid.Parse(valueSetReferenceId);

            // Act
            var query = this.TerminologyContext.ValueSets.WithUniqueId(valueSetGuid).IncludeCodes();

            var maybe = this.Profiler.ExecuteTimed(async () => await query.Execute());
            maybe.HasValue.Should().BeTrue();
            var valueSet = maybe.Single();

            // Assert
            valueSet.Should().NotBeNull("value set unique id corresponds to a known value set.");
            valueSet.CodeCounts.Should().NotBeEmpty();
            valueSet.ValueSetCodes.Should().NotBeEmpty("because all codes should be included");
        }
    }
}