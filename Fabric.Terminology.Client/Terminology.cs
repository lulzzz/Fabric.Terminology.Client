namespace Fabric.Terminology.Client
{
    using System;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Services;

    public class Terminology : ITerminology
    {
        private Lazy<IValueSetApiService> valueSetApiService;

        public Terminology(ITerminologyApiSettings settings)
        {
            this.Initialize(settings);
        }

        public IValueSetApiService ValueSet => this.valueSetApiService.Value;

        private void Initialize(ITerminologyApiSettings settings)
        {
            this.valueSetApiService = new Lazy<IValueSetApiService>(() => new ValueSetApiService(settings));
        }
    }
}