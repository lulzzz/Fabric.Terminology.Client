namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetSearchRequest : ValueSetRequestBase, IApiPostRequest<FindByTermQuery, Task<PagedCollection<ValueSet>>>
    {
        private readonly string term;
        private readonly PagerSettings pagerSettings;

        public ValueSetSearchRequest(Lazy<IValueSetApiService> service, string term, PagerSettings pagerSettings)
            : base(service)
        {
            this.term = term;
            // TODO ensure pager settings
            this.pagerSettings = pagerSettings;
        }

        public Task<PagedCollection<ValueSet>> Execute()
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

        public string GetEndpoint()
        {
            return "search";
        }
    }
}
