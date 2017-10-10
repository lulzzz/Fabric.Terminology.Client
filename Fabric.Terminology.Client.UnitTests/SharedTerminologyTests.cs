namespace Fabric.Terminology.Client.UnitTests
{
    using System;
    using Fabric.Terminology.Client.Builders;
    using Fabric.Terminology.Client.TestsBase;
    using Fabric.Terminology.Client.TestsBase.Fixtures;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class SharedTerminologyTests : OutputTestBase, IClassFixture<TerminologyFixture>
    {
        private readonly ISharedTerminology terminology;

        public SharedTerminologyTests(ITestOutputHelper output, TerminologyFixture fixture)
            : base(output)
        {
            this.terminology = fixture.SharedTerminology;
        }

        [Fact]
        public void CanGetValueSetRequestInstance()
        {
            // Arrange
            // handled in fixture

            // Act
            var valueSetRequest = this.terminology.ValueSets;

            // Assert
            valueSetRequest.Should().BeOfType<ValueSetRequest>();
        }

        [Fact]
        public void CanGetCorrectBuilders()
        {
            // Arrange

            // Act
            var single = this.terminology.ValueSets.WithUniqueId(Guid.NewGuid());
            var list = this.terminology.ValueSets.WithUniqueIdsIn(new[] { Guid.NewGuid(), Guid.NewGuid() });
            var page = this.terminology.ValueSets.Paged();
            var search = this.terminology.ValueSets.Search("term");

            // Assert
            single.Should().BeOfType<ValueSetSingleRequest>();
            list.Should().BeOfType<ValueSetListRequest>();
            page.Should().BeOfType<ValueSetPagedRequest>();
            search.Should().BeOfType<ValueSetSearchRequest>();
        }
    }
}