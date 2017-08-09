namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Builders;
    using Fabric.Terminology.Client.Models;

    public interface IValueSetApiService
    {
        Task<Maybe<ValueSet>> GetValueSet(ValueSetSingleRequest request);

        Task<IReadOnlyCollection<ValueSet>> GetValueSets(ValueSetListRequest request);

        Task<PagedCollection<ValueSet>> GetValueSetPage(ValueSetPagedRequest request);

        Task<PagedCollection<ValueSet>> FindValueSetPage(ValueSetSearchRequest request);
    }
}