﻿using System;

namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Builders;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Models;

    internal class ValueSetApiService : ApiServiceBase, IValueSetApiService
    {
        public ValueSetApiService(ITerminologyApiSettings settings)
            : base(settings, "valuesets")
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
            //return this.PostApiResult<ValueSet>()
            throw new NotImplementedException();
        }

        private string BuildHttpGetUrl(IApiGetRequest request)
        {
            return $"{this.BaseUrl}/{request.GetEndpoint()}";
        }
    }
}