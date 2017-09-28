namespace Fabric.Terminology.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fabric.Terminology.Client.Builders;

    public static partial class Extensions
    {
        public static IApiRequestWithParameters<T> IncludeCodes<T>(this IApiRequestWithParameters<T> request)
        {
            request.Summary = false;
            return request;
        }

        public static IApiRequestWithParameters<T> CodesFilteredByCodeSystem<T>(this IApiRequestWithParameters<T> request, Guid codeSystemGuid)
        {
            request.AddCodeSytemFilter(codeSystemGuid);
            return request;
        }

        public static IApiRequestWithParameters<T> CodesFilteredByCodeSystem<T>(
            this IApiRequestWithParameters<T> request,
            IEnumerable<Guid> codeSystemGuids)
        {
            foreach (var code in codeSystemGuids.ToArray())
            {
                if (!request.CodeSystemGuidFilters.Contains(code))
                {
                    request.AddCodeSytemFilter(code);
                }
            }

            return request;
        }
    }
}
