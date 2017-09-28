namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
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

        //[Theory(Skip = "Manual run only. Delete not implemented.")]
        ////[Theory]
        //[InlineData("Api.ValueSet1", 10)]
        //[InlineData("Api.ValueSet2", 5)]
        //[InlineData("Api.ValueSet3", 2500)]
        //public void CanAddAValueSet(string name, int codeCount)
        //{
        //    // Arrange
        //    var codes = MockApiModelBuilder.BuildCodeSetCodeCollection(codeCount);

        //    // Act
        //    var query = this.SharedTerminology.ValueSets.Add(name, codes);
        //    var maybe = this.Profiler.ExecuteTimed(async () => await query.Execute());

        //    // Assert
        //    maybe.HasValue.Should().BeTrue();
        //    var valueSet = maybe.Single();

        //    valueSet.IsCustom.Should().BeTrue();
        //    valueSet.ValueSetCodesCount.Should().Be(codeCount);
        //}
    }
}