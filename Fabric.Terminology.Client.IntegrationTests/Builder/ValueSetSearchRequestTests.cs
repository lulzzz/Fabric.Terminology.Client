using System.Linq;
using Fabric.Terminology.Client.Models;
using FluentAssertions;
using Xunit;

namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using Xunit.Abstractions;

    public class ValueSetSearchRequestTests : ValueSetRequestTestBase
    {
        private readonly ITerminologyContext terminology;

        public ValueSetSearchRequestTests(ITestOutputHelper output, TerminologyFixture fixture) 
            : base(output, fixture)
        {
            this.terminology = fixture.TerminologyContext;
        }

        [Theory]
        [InlineData("cancer")]
        [InlineData("diabetes")]
        public void CanSearchForValueSets(string term)
        {
            // Arrange

            // Act
            var query = this.terminology.ValueSets.Search(term);

            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.TotalItems.Should().BeGreaterThan(0, "term should match");
            page.Values.All(vs => vs.ValueSetCodes.Any()).Should().BeTrue("value sets must have codes.");
        }

        [Theory]
        [InlineData("cancer")]
        [InlineData("diabetes")]
        public void CanSearchForValueSetAndReturnAllCodes(string term)
        {
            // Arrange

            // Act
            var query = this.terminology.ValueSets.Search(term).IncludeAllCodes();

            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.TotalItems.Should().BeGreaterThan(0, "term should match");
            page.Values.All(vs => vs.ValueSetCodes.Any()).Should().BeTrue("value sets must have codes.");
            page.Values.Any(vs => vs.AllCodesLoaded).Should().BeTrue("All codes included flag was set");
        }

        [Theory]
        [InlineData("cancer")]
        public void CanSearchForValueSetAndReturnPageAllCodesWith(string term)
        {
            // Arrange
            var currentPage = 2;

            // Act
            var query = this.terminology.ValueSets.Search(term, currentPage).IncludeAllCodes();

            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.TotalPages.Should().BeGreaterOrEqualTo(currentPage, "otherwise the test would not be valid");
            page.TotalItems.Should().BeGreaterThan(0, "term should match");
            page.Values.All(vs => vs.ValueSetCodes.Any()).Should().BeTrue("value sets must have codes.");
            page.Values.Any(vs => vs.AllCodesLoaded).Should().BeTrue("All codes included flag was set");
            page.PagerSettings.CurrentPage.Should().Be(currentPage, $"queried for page {currentPage}");
        }


        [Theory]
        [InlineData("cancer")]
        public void CanSearchForValueSetAndReturnAllCodesWithPageSettings(string term)
        {
            // Arrange
            var currentPage = 2;
            var itemsPerPage = 10;

            var pageSettings = new PagerSettings
            {
                CurrentPage = currentPage,
                ItemsPerPage = itemsPerPage
            };

            // Act
            var query = this.terminology.ValueSets.Search(term, pageSettings).IncludeAllCodes();

            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.TotalPages.Should().BeGreaterOrEqualTo(currentPage, "otherwise the test would not be valid");
            page.TotalItems.Should().BeGreaterThan(0, "term should match");
            page.Values.All(vs => vs.ValueSetCodes.Any()).Should().BeTrue("value sets must have codes.");
            page.Values.Any(vs => vs.AllCodesLoaded).Should().BeTrue("All codes included flag was set");
            page.PagerSettings.CurrentPage.Should().Be(currentPage, $"queried for page {currentPage}");
            page.PagerSettings.ItemsPerPage.Should().Be(itemsPerPage, $"queried for page size of {itemsPerPage}");
        }
    }
}
