namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Builders;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Logging;
    using Fabric.Terminology.Client.Models;

    internal class ValueSetApiService : ApiServiceBase, IValueSetApiService
    {
        public ValueSetApiService(ITerminologyApiSettings settings, ILogger logger)
            : base(settings, logger, "valuesets")
        {
        }

        public Task<Maybe<ValueSet>> GetValueSet(ValueSetSingleRequest request)
        {
            return this.GetApiResult<ValueSet>(this.BuildHttpGetUrl(request));
        }

        public Task<IReadOnlyCollection<ValueSet>> GetValueSets(ValueSetListRequest request)
        {
            return this.GetApiResultList<ValueSet>(this.BuildHttpGetUrl(request));
        }

        public Task<PagedCollection<ValueSet>> GetValueSetPage(ValueSetPagedRequest request)
        {
            return this.GetApiResultPage<ValueSet>(this.BuildHttpGetUrl(request));
        }

        public Task<PagedCollection<ValueSet>> FindValueSetPage(ValueSetSearchRequest request)
        {
            return this.PostApiResultPage<ValueSet, FindByTermQuery>($"{this.BaseUrl}/find", request.BuildModel());
        }

        public Task<Maybe<ValueSet>> AddValueSet(ValueSetAddRequest request)
        {
            var model = request.BuildModel(this.ApiSettings.ValueSetMeta);
            return this.PostApiResult<ValueSet, ValueSetCreation>(this.BaseUrl, model);
        }

        private string BuildHttpGetUrl(IApiGetRequest request)
        {
            return $"{this.BaseUrl}/{request.GetEndpoint()}";
        }
    }
}