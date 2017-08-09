namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetSearchRequest : ValueSetPagedRequestBase, IApiPostRequest<FindByTermQuery>
    {
        private readonly string term;
        private readonly PagerSettings pagerSettings;

        public ValueSetSearchRequest(Lazy<IValueSetApiService> service, string term, PagerSettings pagerSettings)
            : base(service)
        {
            this.term = term;
            this.EnsurePagerSettings(pagerSettings);
            this.pagerSettings = pagerSettings;
        }

        public override Task<PagedCollection<ValueSet>> Execute()
        {
            throw new NotImplementedException();
        }

        public FindByTermQuery BuildModel()
        {
            return new FindByTermQuery
            {
                Term = this.term,
                CodeSystemCodes = this.CodeSystemCodeFilters,
                PagerSettings = this.pagerSettings,
                Summary = this.Summary
            };
        }
    }
}
