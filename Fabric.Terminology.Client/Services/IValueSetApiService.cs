namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using Fabric.Terminology.Client.Models;

    public interface IValueSetApiService
    {
        ValueSet GetValueSet(string valueSetUniqueId);

        ValueSet GetValueSet(string valueSetUniqueId, IEnumerable<string> codeSystemCodes);

        IReadOnlyCollection<ValueSet> GetValueSets(IEnumerable<string> valueSetUniqueId);

        IReadOnlyCollection<ValueSet> GetValueSets(IEnumerable<string> valueSetUniqueId, IEnumerable<string> codeSystemCodes);

        IReadOnlyCollection<ValueSetCode> GetValueSetCodes(string valueSetUniqueId);

        IReadOnlyCollection<ValueSetCode> GetValueSetCodes(string valueSetUniqueId, IEnumerable<string> codeSystemCodes);
    }
}