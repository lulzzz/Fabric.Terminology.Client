namespace Fabric.Terminology.Client.Builder
{
    using System;
    using System.Collections.Generic;
    using Fabric.Terminology.Client.Configuration;
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

        private void Initialize(ITerminologyApiSettings settings)
        {
            this.valueSetApiService = new Lazy<IValueSetApiService>(() => new ValueSetApiService(settings));
        }
    }
}