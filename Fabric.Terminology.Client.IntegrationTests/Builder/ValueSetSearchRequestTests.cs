namespace Fabric.Terminology.Client.IntegrationTests.Builder
{
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class ValueSetSearchRequestTests : ValueSetRequestTestBase
    {
        private readonly ISharedTerminology terminology;

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
            var query = this.terminology.ValueSets.Search(term).IncludeCodes();

            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.TotalItems.Should().BeGreaterThan(0, "term should match");
            foreach (var item in page.Values)
            {
                item.ValueSetCodes.Should().NotBeEmpty();
                item.CodeCounts.Should().NotBeEmpty();
            }
        }

        [Theory]
        [InlineData("cancer")]
        [InlineData("diabetes")]
        public void CanSearchForValueSetAndReturnAllCodes(string term)
        {
            // Arrange

            // Act
            var query = this.terminology.ValueSets.Search(term).IncludeCodes();

            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.TotalItems.Should().BeGreaterThan(0, "term should match");
            foreach (var item in page.Values)
            {
                item.ValueSetCodes.Should().NotBeEmpty();
                item.CodeCounts.Should().NotBeEmpty();
            }
        }

        [Theory]
        [InlineData("cancer")]
        public void CanSearchForValueSetAndReturnPageAllCodesWith(string term)
        {
            // Arrange
            var currentPage = 2;

            // Act
            var query = this.terminology.ValueSets.Search(term, currentPage).IncludeCodes();

            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.TotalPages.Should().BeGreaterOrEqualTo(currentPage, "otherwise the test would not be valid");
            page.TotalItems.Should().BeGreaterThan(0, "term should match");
            page.PagerSettings.CurrentPage.Should().Be(currentPage, $"queried for page {currentPage}");
            foreach (var item in page.Values)
            {
                item.ValueSetCodes.Should().NotBeEmpty();
                item.CodeCounts.Should().NotBeEmpty();
            }
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
            var query = this.terminology.ValueSets.Search(term, pageSettings).IncludeCodes();

            var page = this.Profiler.ExecuteTimed(async () => await query.Execute());

            // Assert
            page.Should().NotBeNull();
            page.TotalPages.Should().BeGreaterOrEqualTo(currentPage, "otherwise the test would not be valid");
            page.TotalItems.Should().BeGreaterThan(0, "term should match");
            page.PagerSettings.CurrentPage.Should().Be(currentPage, $"queried for page {currentPage}");
            page.PagerSettings.ItemsPerPage.Should().Be(itemsPerPage, $"queried for page size of {itemsPerPage}");
            foreach (var item in page.Values)
            {
                item.ValueSetCodes.Should().NotBeEmpty();
                item.CodeCounts.Should().NotBeEmpty();
            }
        }
    }
}
