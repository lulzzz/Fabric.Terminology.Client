namespace Fabric.Terminology.Client.Models
{
    using System;

    public class ValueSetCodeCount
    {
        public string ValueSetGuid { get; internal set; }

        public Guid CodeSystemGuid { get; internal set; }

        public int CodeCount { get; internal set; }
    }
}