using System;
using Fabric.Terminology.Client.Builders;
using Fabric.Terminology.Client.Services;

namespace Fabric.Terminology.Client.TestsBase.Fixtures
{
    using Fabric.Terminology.Client.Logging;
    using Moq;
    using Serilog.Core;

    public class TerminologyFixture : ApiSettingsFixture
    {
        public TerminologyFixture()
        {
            this.Initialize();
        }

        public ISharedTerminology TerminologyContext { get; private set; }

        private void Initialize()
        {
            var settings = this.TerminologyApiSettings;
            var logger = LogFactory.CreateLogger(new LoggingLevelSwitch());
            var transactionManager = new ApiTransactionManager(settings, logger);

            var valueSetApiService = new Lazy<IValueSetApiService>(() => new ValueSetApiService(transactionManager));
            var apiRequestFactory = new ApiRequestFactory(valueSetApiService);

            this.TerminologyContext = new SharedTerminology(apiRequestFactory);
        }
    }
}