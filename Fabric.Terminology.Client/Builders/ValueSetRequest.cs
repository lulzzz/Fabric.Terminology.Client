namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetRequest
    {
        private Lazy<IValueSetApiService> valueSetApiService;

        internal ValueSetRequest(ITerminologyApiSettings settings)
        {
            this.Initialize(settings);
        }

        public ValueSetSingleRequest WithUniqueId(string valueSetUniqueId)
        {
            return new ValueSetSingleRequest(this.valueSetApiService, valueSetUniqueId);
        }

        public ValueSetListRequest WithUniqueIdsIn(IEnumerable<string> valueSetUniqueIds)
        {
            return new ValueSetListRequest(this.valueSetApiService, valueSetUniqueIds);
        }

        public ValueSetPagedRequest Paged()
        {
            return this.Paged(new PagerSettings());
        }

        public ValueSetPagedRequest Paged(int currentPage, int itemsPerPage = 20)
        {
            var pagerSettings = new PagerSettings
            {
                CurrentPage = currentPage,
                ItemsPerPage = itemsPerPage
            };

            return this.Paged(pagerSettings);
        }

        public ValueSetPagedRequest Paged(PagerSettings pagerSettings)
        {
            return new ValueSetPagedRequest(this.valueSetApiService, pagerSettings);
        }

        public ValueSetSearchRequest Search(string term)
        {
            return this.Search(term, 1);
        }

        public ValueSetSearchRequest Search(string term, int currentPage, int itemsPerPage = 20)
        {
            var pagerSettings = new PagerSettings
            {
                CurrentPage = currentPage,
                ItemsPerPage = itemsPerPage
            };

            return this.Search(term, pagerSettings);
        }

        public ValueSetSearchRequest Search(string term, PagerSettings pagerSettings)
        {
            return new ValueSetSearchRequest(this.valueSetApiService, term, pagerSettings);
        }

        private void Initialize(ITerminologyApiSettings settings)
        {
            this.valueSetApiService = new Lazy<IValueSetApiService>(() => new ValueSetApiService(settings));
        }
    }
}