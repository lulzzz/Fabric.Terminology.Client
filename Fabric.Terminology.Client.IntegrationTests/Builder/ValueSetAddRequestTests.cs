using System.Linq;
using Fabric.Terminology.Client.Models;

namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
    using System;
    using System.Collections.Generic;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using Fabric.Terminology.Client.TestsBase.Mocks;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class ValueSetAddRequestTests : ValueSetRequestTestBase
    {
        public ValueSetAddRequestTests(ITestOutputHelper output, TerminologyFixture fixture)
            : base(output, fixture)
        {
        }

        [Theory(Skip = "Manual run only. Delete not implemented.")]
        //[Theory]
        [InlineData("Api.ValueSet1", 10)]
        [InlineData("Api.ValueSet2", 5)]
        [InlineData("Api.ValueSet3", 2500)]
        public void CanAddAValueSet(string name, int codeCount)
        {
            // Arrange
            var codeSystemGuids = new List<Guid>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid()
                };
            var codes = MockApiModelBuilder.BuildCodeSetCodeCollection(codeSystemGuids, codeCount);

            // Act
            var meta = new ValueSetMeta
            {
                AuthoringSourceDescription = "Fabric.Terminology.Client Test",
                DefinitionDescription = "Integration test",
                SourceDescription = "Testing client API",
                VersionDate = DateTime.UtcNow
            };

            var query = this.TerminologyContext.ValueSets.Add(name, meta, codes);
            var maybe = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            maybe.HasValue.Should().BeTrue();
            var valueSet = maybe.Single();

            valueSet.IsCustom.Should().BeTrue();
            valueSet.CodeCounts.Sum(x => x.CodeCount).Should().Be(codeCount);
        }
    }
}