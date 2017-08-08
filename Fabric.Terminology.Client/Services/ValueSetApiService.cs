namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Builder;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Models;

    internal class ValueSetApiService : ApiServiceBase, IValueSetApiService
    {
        public ValueSetApiService(ITerminologyApiSettings settings)
            : base(settings, "valuesets")
        {
        }

        public Task<Maybe<ValueSet>> GetValueSet(string valueSetUniqueId)
        {
            return this.GetApiResult<ValueSet>($"{this.BaseUrl}/{valueSetUniqueId}");
        }

        public Task<Maybe<ValueSet>> GetValueSet(ValueSetSingleRequest request)
        {
            return this.GetApiResult<ValueSet>($"{this.BaseUrl}/{request.GetEndpoint()}");
        }
    }
}