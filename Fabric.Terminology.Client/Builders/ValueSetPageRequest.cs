namespace Fabric.Terminology.Client.Builder
{
    using System;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetPageRequest : ValueSetRequestBase<Task<PagedCollection<ValueSet>>>, IApiGetRequest
    {
        private readonly PagerSettings pagerSettings;

        public ValueSetPageRequest(Lazy<IValueSetApiService> valueSetApiService, PagerSettings pagerSettings)
            : base(valueSetApiService)
        {
            this.EnsurePagerSettings(pagerSettings);
            this.pagerSettings = pagerSettings;
        }

        public override Task<PagedCollection<ValueSet>> Execute()
        {
            return this.ValueSetApiService.GetValueSetPage(this);
        }

        public string GetEndpoint()
        {
            var pageQs = $"$top={this.pagerSettings.ItemsPerPage}&$skip{this.pagerSettings.CurrentPage - 1}";
            var qs = this.BuildQueryString();

            return qs.IsNullOrWhiteSpace() ? $"?{pageQs}" : $"{qs}&{pageQs}";
        }

        private void EnsurePagerSettings(PagerSettings settings)
        {
            if (settings.CurrentPage <= 0)
            {
                settings.CurrentPage = 1;
            }

            if (settings.ItemsPerPage < 0)
            {
                settings.ItemsPerPage = 10;
            }
        }
    }
}