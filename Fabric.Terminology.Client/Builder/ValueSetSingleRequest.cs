namespace Fabric.Terminology.Client.Builder
{
    using System;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetSingleRequest : ValueSetRequestBase<Task<Maybe<ValueSet>>>, IApiGetRequest
    {
        public ValueSetSingleRequest(Lazy<IValueSetApiService> valueSetApiService, string valueSetUniqueId)
            : base(valueSetApiService)
        {
            this.ValueSetUniqueId = valueSetUniqueId;
        }

        internal string ValueSetUniqueId { get; }

        public string GetEndpoint()
        {
            return $"{this.ValueSetUniqueId}{this.BuildQueryString()}";
        }

        public override Task<Maybe<ValueSet>> Execute()
        {
            return this.ValueSetApiService.GetValueSet(this);
        }
    }
}