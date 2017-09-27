namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetListRequest : ValueSetRequestBase, IApiRequest<Task<IReadOnlyCollection<ValueSet>>>
    {
        private readonly HashSet<Guid> valueSetGuids = new HashSet<Guid>();

        internal ValueSetListRequest(Lazy<IValueSetApiService> valueSetApiService, IEnumerable<Guid> valueSetGuids)
            : base(valueSetApiService)
        {
            var setUniqueIds = valueSetGuids as Guid[] ?? valueSetGuids.ToArray();
            if (!setUniqueIds.Any())
            {
                throw new ArgumentException($"{nameof(valueSetGuids)} may not be an empty collection");
            }

            this.Initialize(setUniqueIds);
        }

        public Task<IReadOnlyCollection<ValueSet>> Execute()
        {
            return this.ValueSetApiService.GetValueSets(this);
        }

        public string GetEndpoint()
        {
            return $"{string.Join(",", this.valueSetGuids)}{this.BuildQueryString()}";
        }

        private void Initialize(IEnumerable<Guid> keys)
        {
            foreach (var key in keys)
            {
                this.valueSetGuids.Add(key);
            }
        }
    }
}