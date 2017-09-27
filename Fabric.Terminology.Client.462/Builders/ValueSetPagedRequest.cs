namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetPagedRequest : ValueSetRequestBase, IApiRequest<Task<PagedCollection<ValueSet>>>
    {
        private readonly PagerSettings pagerSettings;

        internal ValueSetPagedRequest(Lazy<IValueSetApiService> valueSetApiService, PagerSettings pagerSettings)
            : base(valueSetApiService)
        {
            this.pagerSettings = pagerSettings;
        }

        public virtual Task<PagedCollection<ValueSet>> Execute()
        {
            return this.ValueSetApiService.GetValueSetPage(this);
        }

        public string GetEndpoint()
        {
            var pageQs = $"$top={this.pagerSettings.ItemsPerPage}&$skip{this.pagerSettings.CurrentPage - 1}";
            var qs = this.BuildQueryString();

            return qs.IsNullOrWhiteSpace() ? $"?{pageQs}" : $"{qs}&{pageQs}";
        }

    }
}