#pragma warning disable SA1402 // File may only contain a single class
namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.Services;

    public abstract class ValueSetRequestBase
    {
        private readonly IList<Guid> codeSytemGuids = new List<Guid>();

        private readonly Lazy<IValueSetApiService> valueSetApiService;

        protected ValueSetRequestBase(Lazy<IValueSetApiService> service)
        {
            this.valueSetApiService = service;
            this.Summary = true;
        }

        internal bool Summary { get; set; }

        internal IEnumerable<Guid> CodeSystemGuidFilters => this.codeSytemGuids;

        protected IValueSetApiService ValueSetApiService => this.valueSetApiService.Value;

        internal void AddCodeSytemFilter(Guid codeSystemGuid)
        {
            this.codeSytemGuids.Add(codeSystemGuid);
        }

        internal string BuildQueryString()
        {
            var qs = string.Empty;

            if (this.Summary)
            {
                qs += $"$summary=true";
            }

            if (this.CodeSystemGuidFilters.Any())
            {
                var guidlist = string.Join(",", this.CodeSystemGuidFilters);

                if (qs.Length > 0)
                {
                    qs += "&";
                }

                qs += $"$codesystems={guidlist}";
            }

            return qs.Length == 0 ? string.Empty : $"?{qs}";
        }
    }
}
#pragma warning disable SA1402 // File may only contain a single class
