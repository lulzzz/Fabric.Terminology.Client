namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Builders;
    using Fabric.Terminology.Client.Models;

    internal class ValueSetApiService : IValueSetApiService
    {
        private readonly IApiTransactionManager transactionManager;

        public ValueSetApiService(IApiTransactionManager transactionManager)
        {
            this.transactionManager = transactionManager;
        }

        private string BaseUrl => this.transactionManager.GetBaseUrl("valuesets");

        public Task<Maybe<ValueSet>> GetValueSet(ValueSetSingleRequest request)
        {
            return this.transactionManager.GetApiResult<ValueSet>(this.BuildHttpGetUrl(request));
        }

        public Task<IReadOnlyCollection<ValueSet>> GetValueSets(ValueSetListRequest request)
        {
            return this.transactionManager.GetApiResultList<ValueSet>(this.BuildHttpGetUrl(request));
        }

        public Task<PagedCollection<ValueSet>> GetValueSetPage(ValueSetPagedRequest request)
        {
            return this.transactionManager.GetApiResultPage<ValueSet>(this.BuildHttpGetUrl(request));
        }

        public Task<PagedCollection<ValueSet>> SearchValueSetPage(ValueSetSearchRequest request)
        {
            return this.transactionManager.PostApiResultPage<ValueSet, FindByTermQuery>(this.BuildHttpGetUrl(request), request.BuildModel());
        }

        public Task<Maybe<ValueSet>> AddValueSet(ValueSetAddRequest request)
        {
            return this.transactionManager.PostApiResult<ValueSet, ValueSetCreation>(this.BaseUrl, request.BuildModel());
        }

        private string BuildHttpGetUrl(IApiRequest request)
        {
            return $"{this.transactionManager.GetBaseUrl("valuesets")}/{request.GetEndpoint()}";
        }
    }
}