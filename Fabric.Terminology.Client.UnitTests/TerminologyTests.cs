namespace Fabric.Terminology.Client.UnitTests
{
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

        [Fact]
        public void CanGetValueSetApiServiceInstance()
        {
            // Arrange
            // handled in fixture

            // Act
            var valueSetApiService = this.terminology.ValueSets;

            // Assert
            valueSetApiService.Should().NotBeNull();
        }
    }
}