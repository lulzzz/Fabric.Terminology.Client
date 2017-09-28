namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetSingleRequest : ValueSetRequestBase<Maybe<ValueSet>>
    {
        internal ValueSetSingleRequest(IValueSetApiService valueSetApiService, Guid valueSetGuid)
            : base(valueSetApiService)
        {
            this.ValueSetGuid = valueSetGuid;
        }

        internal Guid ValueSetGuid { get; }

        public override string GetEndpoint()
        {
            return $"{this.ValueSetGuid}{this.BuildQueryString()}";
        }

        public override Task<Maybe<ValueSet>> Execute()
        {
            return this.ValueSetApiService.GetValueSet(this);
        }
    }
}