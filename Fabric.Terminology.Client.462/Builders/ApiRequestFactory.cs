namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ApiRequestFactory : IApiRequestFactory
    {
        private readonly Lazy<IValueSetApiService> valueSetApiService;

        public ApiRequestFactory(Lazy<IValueSetApiService> valueSetApiService)
        {
            this.valueSetApiService = valueSetApiService;
        }

        public IApiRequest<Maybe<ValueSet>> CreateValueSetSingleRequest(Guid valueSetGuid)
        {
            return new ValueSetSingleRequest(this.valueSetApiService.Value, valueSetGuid);
        }

        public IApiRequest<IReadOnlyCollection<ValueSet>> CreateValueSetListRequest(IEnumerable<Guid> valueSetGuids)
        {
            return new ValueSetListRequest(this.valueSetApiService.Value, valueSetGuids);
        }

        public IApiRequest<PagedCollection<ValueSet>> CreateValueSetPagedRequest(PagerSettings pagerSettings)
        {
            return new ValueSetPagedRequest(this.valueSetApiService.Value, pagerSettings);
        }

        public IApiPostRequest<FindByTermQuery, PagedCollection<ValueSet>> CreateValueSetSearchRequest(string term, PagerSettings pagerSettings)
        {
            return new ValueSetSearchRequest(this.valueSetApiService.Value, term, pagerSettings);
        }

        public IApiPostRequest<ValueSetCreation, Maybe<ValueSet>> CreateValueSetAddRequest(
            string name,
            ValueSetMeta valueSetMeta,
            IEnumerable<CodeSetCode> codes)
        {
            return new ValueSetAddRequest(this.valueSetApiService.Value, name, valueSetMeta, codes);
        }
    }
}
