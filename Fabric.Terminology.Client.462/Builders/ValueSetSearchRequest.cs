namespace Fabric.Terminology.Client.Builders
{
    using System.Threading.Tasks;

    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetSearchRequest : ValueSetRequestBase<PagedCollection<ValueSet>>, IApiPostRequestWithParameters<FindByTermQuery, PagedCollection<ValueSet>>
    {
        private readonly string term;

        private readonly PagerSettings pagerSettings;

        public ValueSetSearchRequest(IValueSetApiService service, string term, PagerSettings pagerSettings)
            : base(service)
        {
            this.term = term;
            this.pagerSettings = pagerSettings;
        }

        public override Task<PagedCollection<ValueSet>> Execute()
        {
            return this.ValueSetApiService.SearchValueSetPage(this);
        }

        public FindByTermQuery BuildModel()
        {
            return new FindByTermQuery
            {
                Term = this.term,
                CodeSystemGuids = this.CodeSystemGuidFilters,
                PagerSettings = this.pagerSettings,
                Summary = this.Summary
            };
        }

        public override string GetEndpoint()
        {
            return "search";
        }
    }
}