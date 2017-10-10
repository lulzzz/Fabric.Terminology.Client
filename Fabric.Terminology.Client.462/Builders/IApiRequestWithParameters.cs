namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;

    public interface IApiRequestWithParameters<TResult> : IApiRequest<TResult>
    {
        bool Summary { get; set; }

        IEnumerable<Guid> CodeSystemGuidFilters { get; }

        void AddCodeSytemFilter(Guid codeSystemGuid);
    }
}