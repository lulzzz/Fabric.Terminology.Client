namespace Fabric.Terminology.Client.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Fabric.Terminology.Client.Models;
    using Fabric.Terminology.Client.Services;

    public class ValueSetListRequest : ValueSetRequestBase<Task<IReadOnlyCollection<ValueSet>>>, IApiGetRequest
    {
        private readonly IList<string> valueSetUniqueIds = new List<string>();

        internal ValueSetListRequest(Lazy<IValueSetApiService> valueSetApiService, IEnumerable<string> valueSetUniqueIds)
            : base(valueSetApiService)
        {
            var setUniqueIds = valueSetUniqueIds as string[] ?? valueSetUniqueIds.ToArray();
            if (!setUniqueIds.Any())
            {
                throw new ArgumentException($"{nameof(valueSetUniqueIds)} may not be an empty collection");
            }

            this.Initialize(setUniqueIds);
        }

        public override Task<IReadOnlyCollection<ValueSet>> Execute()
        {
            return this.ValueSetApiService.GetValueSets(this);
        }

        public string GetEndpoint()
        {
            return $"{string.Join(",", this.valueSetUniqueIds)}{this.BuildQueryString()}";
        }

        private void Initialize(string[] ids)
        {
            foreach (var id in ids)
            {
                if (!this.valueSetUniqueIds.Contains(id))
                {
                    this.valueSetUniqueIds.Add(id);
                }
            }
        }
    }
}