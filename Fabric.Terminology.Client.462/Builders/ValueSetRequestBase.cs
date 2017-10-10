namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.Services;

    public abstract class ValueSetRequestBase<TResult> : IApiRequestWithParameters<TResult>
    {
        private readonly IList<Guid> codeSytemGuids = new List<Guid>();

        protected ValueSetRequestBase(IValueSetApiService service)
        {
            this.ValueSetApiService = service;
        }

        public bool Summary { get; set; } = true;

        public IEnumerable<Guid> CodeSystemGuidFilters => this.codeSytemGuids;

        protected IValueSetApiService ValueSetApiService { get; }

        public void AddCodeSytemFilter(Guid codeSystemGuid)
        {
            this.codeSytemGuids.Add(codeSystemGuid);
        }

        public string BuildQueryString()
        {
            var qs = string.Empty;

            if (!this.Summary)
            {
                qs += $"$summary=false";
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

        public abstract Task<TResult> Execute();

        public abstract string GetEndpoint();
    }
}
