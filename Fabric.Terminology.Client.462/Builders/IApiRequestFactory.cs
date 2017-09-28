namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;

    public interface IApiRequestFactory
    {
        IApiRequest<Maybe<ValueSet>> CreateValueSetSingleRequest(Guid valueSetGuid);

        IApiRequest<IReadOnlyCollection<ValueSet>> CreateValueSetListRequest(IEnumerable<Guid> valueSetGuids);

        IApiRequest<PagedCollection<ValueSet>> CreateValueSetPagedRequest(PagerSettings pagerSettings);

        IApiPostRequest<FindByTermQuery, PagedCollection<ValueSet>> CreateValueSetSearchRequest(
            string term,
            PagerSettings pagerSettings);

        IApiPostRequest<ValueSetCreation, Maybe<ValueSet>> CreateValueSetAddRequest(
            string name,
            ValueSetMeta valueSetMeta,
            IEnumerable<CodeSetCode> codes);
    }
}