namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public abstract class ValueSetPagedRequestBase : ValueSetRequestBase<Task<PagedCollection<ValueSet>>>
    {
        protected ValueSetPagedRequestBase(Lazy<IValueSetApiService> service)
            : base(service)
        {
        }

        protected void EnsurePagerSettings(PagerSettings settings)
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
