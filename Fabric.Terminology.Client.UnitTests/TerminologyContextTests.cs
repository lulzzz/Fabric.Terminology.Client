namespace Fabric.Terminology.Client.UnitTests
{
    using Fabric.Terminology.Client.Builders;
    using Fabric.Terminology.Client.TestsBase;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class TerminologyContextTests : OutputTestBase, IClassFixture<TerminologyFixture>
    {
        private readonly ISharedTerminology terminology;

        public TerminologyContextTests(ITestOutputHelper output, TerminologyFixture fixture)
            : base(output)
        {
            this.terminology = fixture.TerminologyContext;
        }

        [Fact]
        public void CanGetValueSetRequestInstance()
        {
            // Arrange
            // handled in fixture

            // Act
            var valueSetRequest = this.terminology.ValueSets;

            // Assert
            valueSetRequest.Should().NotBeNull();
            valueSetRequest.GetType().Should().Be(typeof(ValueSetRequest));
        }

        //[Fact]
        //public void CanGetCorrectBuilders()
        //{
        //    // Arrange

        //    // Act
        //    var single = this.terminology.ValueSets.WithUniqueId("somestring");
        //    var list = this.terminology.ValueSets.WithUniqueIdsIn(new[] { "one", "two" });
        //    var page = this.terminology.ValueSets.Paged();
        //    var search = this.terminology.ValueSets.Search("term");

        //    // Assert
        //    single.Should().NotBeNull();
        //    single.GetType().Should().Be(typeof(ValueSetSingleRequest));
        //    list.Should().NotBeNull();
        //    list.GetType().Should().Be(typeof(ValueSetListRequest));
        //    page.Should().NotBeNull();
        //    page.GetType().Should().Be(typeof(ValueSetPagedRequest));
        //    search.Should().NotBeNull();
        //    search.GetType().Should().Be(typeof(ValueSetSearchRequest));
        //}
    }
}