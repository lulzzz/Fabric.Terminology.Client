namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetAddRequest : IApiPostRequest<ValueSetCreation, Maybe<ValueSet>>
    {
        private readonly IValueSetApiService valueSetApiService;

        private readonly string name;

        private readonly ValueSetMeta meta;

        private readonly IReadOnlyCollection<CodeSetCode> codes;

        internal ValueSetAddRequest(IValueSetApiService valueSetApiService, string name, ValueSetMeta meta, IEnumerable<CodeSetCode> codes)
        {
            this.valueSetApiService = valueSetApiService;
            this.name = name;
            this.meta = meta;
            this.codes = codes.ToArray();
        }

        public Task<Maybe<ValueSet>> Execute()
        {
            return this.valueSetApiService.AddValueSet(this);
        }

        public ValueSetCreation BuildModel()
        {
            return new ValueSetCreation
            {
                VersionDate = DateTime.UtcNow,
                AuthoringSourceDescription = this.meta.AuthoringSourceDescription,
                DefinitionDescription = this.meta.DefinitionDescription,
                SourceDescription = this.meta.SourceDescription,
                CodeSetCodes = this.codes,
                Name = this.name
            };
        }

        public string GetEndpoint()
        {
            return string.Empty;
        }
    }
}