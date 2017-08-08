namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Builder;
    using Fabric.Terminology.Client.Models;

    public interface IValueSetApiService
    {
        Task<Maybe<ValueSet>> GetValueSet(ValueSetSingleRequest request);

        //Task<Maybe<ValueSet>> GetValueSet(string valueSetUniqueId, IEnumerable<string> codeSystemCodes);

        //IReadOnlyCollection<ValueSet> GetValueSets(IEnumerable<string> valueSetUniqueId);

        //IReadOnlyCollection<ValueSet> GetValueSets(IEnumerable<string> valueSetUniqueId, IEnumerable<string> codeSystemCodes);

        //IReadOnlyCollection<ValueSetCode> GetValueSetCodes(string valueSetUniqueId);

        //IReadOnlyCollection<ValueSetCode> GetValueSetCodes(string valueSetUniqueId, IEnumerable<string> codeSystemCodes);
    }
}