namespace Fabric.Terminology.Client.Builder
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ValueSetRequestExtensions
    {
        public static TRequest IncludeAllCodes<TRequest>(this TRequest request)
            where TRequest : ValueSetRequestBase
        {
            request.SummaryCodeList = false;
            return request;
        }

        public static TRequest CodesFilteredByCodeSystem<TRequest>(this TRequest request, string codeSystemCode)
            where TRequest : ValueSetRequestBase
        {
            request.AddCodeSytemFilter(codeSystemCode);
            return request;
        }

        public static TRequest CodesFilteredByCodeSystem<TRequest>(
            this TRequest request,
            IEnumerable<string> codeSystemCodes)
            where TRequest : ValueSetRequestBase
        {
            foreach (var code in codeSystemCodes.ToArray())
            {
                if (!request.CodeSystemCodeFilters.Contains(code))
                {
                    request.AddCodeSytemFilter(code);
                }
            }

            return request;
        }
    }
}