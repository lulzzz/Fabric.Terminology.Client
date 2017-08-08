namespace Fabric.Terminology.Client.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fabric.Terminology.Client.Services;

    public abstract class ValueSetRequestBase
    {
        private readonly IList<string> codeSytemCodes = new List<string>();

        private readonly Lazy<IValueSetApiService> valueSetApiService;

        protected ValueSetRequestBase(Lazy<IValueSetApiService> service)
        {
            this.valueSetApiService = service;
        }

        internal bool SummaryCodeList { get; set; }

        internal IEnumerable<string> CodeSystemCodeFilters => this.codeSytemCodes;

        protected IValueSetApiService ValueSetApiService => this.valueSetApiService.Value;


        internal void AddCodeSytemFilter(string codeSystemCode)
        {
            this.codeSytemCodes.Add(codeSystemCode);
        }

        internal string BuildQueryString()
        {
            var qs = string.Empty;

            if (this.SummaryCodeList)
            {
                qs += $"$summary=true";
            }

            if (this.CodeSystemCodeFilters.Any())
            {
                foreach (var code in this.CodeSystemCodeFilters)
                {
                    if (qs.Length > 0)
                    {
                        qs += "&";
                    }

                    qs += $"codesystems={code}";
                }
            }

            return qs.Length == 0 ? string.Empty : $"?{qs}";
        }
    }
}