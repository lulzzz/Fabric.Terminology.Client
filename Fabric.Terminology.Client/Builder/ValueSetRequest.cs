namespace Fabric.Terminology.Client.Builder
{
    using System;
    using System.Collections.Generic;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetRequest
    {
        private Lazy<IValueSetApiService> valueSetApiService;

        public ValueSetRequest(ITerminologyApiSettings settings)
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

        public ValueSetPageRequest Paged()
        {
            return this.Paged(new PagerSettings());
        }

        public ValueSetPageRequest Paged(int currentPage, int itemsPerPage = 20)
        {
            var pagerSettings = new PagerSettings
            {
                CurrentPage = currentPage,
                ItemsPerPage = itemsPerPage
            };

            return this.Paged(pagerSettings);
        }

        public ValueSetPageRequest Paged(PagerSettings pagerSettings)
        {
            return new ValueSetPageRequest(this.valueSetApiService, pagerSettings);
        }

        private void Initialize(ITerminologyApiSettings settings)
        {
            this.valueSetApiService = new Lazy<IValueSetApiService>(() => new ValueSetApiService(settings));
        }
    }
}