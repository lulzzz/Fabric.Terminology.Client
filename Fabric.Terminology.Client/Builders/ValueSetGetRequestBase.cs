namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.Services;

    public abstract class ValueSetGetRequestBase
    {
        private readonly IList<Guid> codeSytemGuids = new List<Guid>();

        protected ValueSetGetRequestBase(IValueSetApiService service)
        {
            this.ValueSetApiService = service;
        }

        internal bool Summary { get; set; } = true;

        internal IEnumerable<Guid> CodeSystemGuidFilters => this.codeSytemGuids;

        protected IValueSetApiService ValueSetApiService { get; }

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
