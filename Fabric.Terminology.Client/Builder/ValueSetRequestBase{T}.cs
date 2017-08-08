namespace Fabric.Terminology.Client.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fabric.Terminology.Client.Services;

    public abstract class ValueSetRequestBase<TResult> : ValueSetRequestBase
    {
        protected ValueSetRequestBase(Lazy<IValueSetApiService> service)
            :base(service)
        {
        }

        public abstract TResult Execute();
    }
}