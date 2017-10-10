namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;

    public interface IApiRequestFactory
    {
        IApiRequestWithParameters<Maybe<ValueSet>> CreateValueSetSingleRequest(Guid valueSetGuid);

        IApiRequestWithParameters<IReadOnlyCollection<ValueSet>> CreateValueSetListRequest(IEnumerable<Guid> valueSetGuids);

        IApiRequestWithParameters<PagedCollection<ValueSet>> CreateValueSetPagedRequest(PagerSettings pagerSettings);

        IApiPostRequestWithParameters<FindByTermQuery, PagedCollection<ValueSet>> CreateValueSetSearchRequest(
            string term,
            PagerSettings pagerSettings);

        IApiPostRequest<ValueSetCreation, Maybe<ValueSet>> CreateValueSetAddRequest(
            string name,
            ValueSetMeta valueSetMeta,
            IEnumerable<CodeSetCode> codes);
    }
}