namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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

        public IApiRequest<Task<Maybe<ValueSet>>> CreateValueSetSingleRequest(Guid valueSetGuid)
        {
            return new ValueSetSingleRequest(this.valueSetApiService, valueSetGuid);
        }

        public IApiRequest<Task<IReadOnlyCollection<ValueSet>>> CreateValueSetListRequest(IEnumerable<Guid> valueSetGuids)
        {
            return new ValueSetListRequest(this.valueSetApiService, valueSetGuids);
        }

        public IApiRequest<Task<PagedCollection<ValueSet>>> CreateValueSetPagedRequest(PagerSettings pagerSettings)
        {
            return new ValueSetPagedRequest(this.valueSetApiService, pagerSettings);
        }

        public IApiPostRequest<FindByTermQuery, Task<PagedCollection<ValueSet>>> CreateValueSetSearchRequest(string term, PagerSettings pagerSettings)
        {
            return new ValueSetSearchRequest(this.valueSetApiService, term, pagerSettings);
        }

        public IApiPostRequest<ValueSetCreation, Task<Maybe<ValueSet>>> CreateValueSetAddRequest(
            string name,
            ValueSetMeta valueSetMeta,
            IEnumerable<CodeSetCode> codes)
        {
            return new ValueSetAddRequest(this.valueSetApiService, name, valueSetMeta, codes);
        }
    }
}
