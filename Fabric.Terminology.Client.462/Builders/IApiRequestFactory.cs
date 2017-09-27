namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;

    public interface IApiRequestFactory
    {
        IApiRequest<Task<Maybe<ValueSet>>> CreateValueSetSingleRequest(Guid valueSetGuid);

        IApiRequest<Task<IReadOnlyCollection<ValueSet>>> CreateValueSetListRequest(IEnumerable<Guid> valueSetGuids);

        IApiRequest<Task<PagedCollection<ValueSet>>> CreateValueSetPagedRequest(PagerSettings pagerSettings);

        IApiPostRequest<FindByTermQuery, Task<PagedCollection<ValueSet>>> CreateValueSetSearchRequest(
            string term,
            PagerSettings pagerSettings);

        IApiPostRequest<ValueSetCreation, Task<Maybe<ValueSet>>> CreateValueSetAddRequest(
            string name,
            ValueSetMeta valueSetMeta,
            IEnumerable<CodeSetCode> codes);
    }
}