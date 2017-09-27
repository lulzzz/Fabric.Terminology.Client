namespace Fabric.Terminology.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fabric.Terminology.Client.Builders;

    public static partial class Extensions
    {
        public static TRequest IncludeCodes<TRequest>(this TRequest request)
            where TRequest : ValueSetRequestBase
        {
            request.Summary = false;
            return request;
        }

        public static TRequest CodesFilteredByCodeSystem<TRequest>(this TRequest request, Guid codeSystemGuid)
            where TRequest : ValueSetRequestBase
        {
            request.AddCodeSytemFilter(codeSystemGuid);
            return request;
        }

        public static TRequest CodesFilteredByCodeSystem<TRequest>(
            this TRequest request,
            IEnumerable<Guid> codeSystemGuids)
            where TRequest : ValueSetRequestBase
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
