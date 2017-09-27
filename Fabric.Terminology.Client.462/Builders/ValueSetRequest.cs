namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;

    public class ValueSetRequest
    {
        private readonly IApiRequestFactory requestFactory;

        internal ValueSetRequest(IApiRequestFactory requestFactory)
        {
            this.requestFactory = requestFactory;
        }

        public IApiRequest<Task<Maybe<ValueSet>>> WithUniqueId(Guid valueSetGuid)
        {
            return this.requestFactory.CreateValueSetSingleRequest(valueSetGuid);
        }

        public IApiRequest<Task<IReadOnlyCollection<ValueSet>>> WithUniqueIdsIn(IEnumerable<Guid> valueSetGuids)
        {
            return this.requestFactory.CreateValueSetListRequest(valueSetGuids);
        }

        public IApiRequest<Task<PagedCollection<ValueSet>>> Paged()
        {
            return this.Paged(new PagerSettings());
        }

        public IApiRequest<Task<PagedCollection<ValueSet>>> Paged(int currentPage, int itemsPerPage = 20)
        {
            var pagerSettings = new PagerSettings
            {
                CurrentPage = currentPage,
                ItemsPerPage = itemsPerPage
            };

            return this.Paged(pagerSettings);
        }

        public IApiRequest<Task<PagedCollection<ValueSet>>> Paged(PagerSettings pagerSettings)
        {
            EnsurePagerSettings(pagerSettings);
            return this.requestFactory.CreateValueSetPagedRequest(pagerSettings);
        }

        public IApiPostRequest<FindByTermQuery, Task<PagedCollection<ValueSet>>> Search(string term)
        {
            return this.Search(term, 1);
        }

        public IApiPostRequest<FindByTermQuery, Task<PagedCollection<ValueSet>>> Search(
            string term,
            int currentPage,
            int itemsPerPage = 20)
        {
            var pagerSettings = new PagerSettings
            {
                CurrentPage = currentPage,
                ItemsPerPage = itemsPerPage
            };

            return this.Search(term, pagerSettings);
        }

        public IApiPostRequest<FindByTermQuery, Task<PagedCollection<ValueSet>>> Search(
            string term,
            PagerSettings pagerSettings)
        {
            EnsurePagerSettings(pagerSettings);
            return this.requestFactory.CreateValueSetSearchRequest(term, pagerSettings);
        }

        public IApiPostRequest<ValueSetCreation, Task<Maybe<ValueSet>>> Add(
            string name,
            ValueSetMeta valueSetMeta,
            IEnumerable<CodeSetCode> codes)
        {
            return this.requestFactory.CreateValueSetAddRequest(name, valueSetMeta, codes);
        }

        private static void EnsurePagerSettings(PagerSettings settings)
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