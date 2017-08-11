namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetAddRequest : IApiRequest<Task<Maybe<ValueSet>>>
    {
        private readonly Lazy<IValueSetApiService> lazy;

        internal ValueSetAddRequest(Lazy<IValueSetApiService> valueSetApiService, string name, IEnumerable<CodeSetCode> codes)
        {
            this.lazy = valueSetApiService;
            this.Name = name;
            this.Codes = codes.ToArray();
        }

        protected IValueSetApiService ValueSetApiService => this.lazy.Value;

        protected string Name { get; }

        protected IReadOnlyCollection<CodeSetCode> Codes { get; }

        public Task<Maybe<ValueSet>> Execute()
        {
            return this.ValueSetApiService.AddValueSet(this);
        }

        public ValueSetCreation BuildModel(ValueSetMeta meta)
        {
            return new ValueSetCreation
            {
                VersionDescription = meta.VersionDescription,
                AuthoringSourceDescription = meta.AuthoringSourceDescription,
                PurposeDescription = meta.PurposeDescription,
                SourceDescription = meta.SourceDescription,
                CodeSetCodes = this.Codes,
                Name = this.Name
            };
        }
    }
}