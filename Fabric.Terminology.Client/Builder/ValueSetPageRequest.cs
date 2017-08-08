using System;
using Fabric.Terminology.Client.Services;

namespace Fabric.Terminology.Client.Builder
{
    using Fabric.Terminology.Client.Models;

    public class ValueSetPageRequest : ValueSetRequestBase
    {
        private readonly PagerSettings pagerSettings;

        private ValueSetPageRequest(Lazy<IValueSetApiService> valueSetApiService, PagerSettings pagerSettings)
            : base(valueSetApiService)
        {
            this.pagerSettings = pagerSettings;
        }

        public static ValueSetPageRequest GetPage(int currentPage, int itemsPerPage = 20)
        {
            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            if (itemsPerPage <= 0)
            {
                itemsPerPage = 20;
            }

            return new ValueSetPageRequest(new PagerSettings
            {
                CurrentPage = currentPage,
                ItemsPerPage = itemsPerPage
            });
        }
    }
}