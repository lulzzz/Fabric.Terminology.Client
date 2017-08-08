namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Models;

    internal class ValueSetApiService : IValueSetApiService
    {
        private readonly ITerminologyApiSettings settings;

        public ValueSetApiService(ITerminologyApiSettings settings)
        {
            this.settings = settings;
        }

        public ValueSet GetValueSet(string valueSetUniqueId)
        {
            throw new System.NotImplementedException();
        }

        public ValueSet GetValueSet(string valueSetUniqueId, IEnumerable<string> codeSystemCodes)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<ValueSet> GetValueSets(IEnumerable<string> valueSetUniqueId)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<ValueSet> GetValueSets(IEnumerable<string> valueSetUniqueId, IEnumerable<string> codeSystemCodes)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<ValueSetCode> GetValueSetCodes(string valueSetUniqueId)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<ValueSetCode> GetValueSetCodes(string valueSetUniqueId, IEnumerable<string> codeSystemCodes)
        {
            throw new System.NotImplementedException();
        }
    }
}