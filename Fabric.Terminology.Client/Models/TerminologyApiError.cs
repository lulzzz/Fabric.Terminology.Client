using System;
using System.Security.Cryptography;

namespace Fabric.Terminology.Client.Models
{
    // acquired from Fabric.Authorization.Domain
    public class TerminologyApiError : Exception
    {
        public TerminologyApiError(string code, string target, string message)
            : base(message)
        {
            this.Code = code;
            this.Target = target;
        }

        public TerminologyApiError(string code, string target, string message, Exception exception)
            : base(message, exception)
        {
            this.Code = code;
            this.Target = target;
        }

        public string Code { get; set; }

        public string Target { get; set; }
    }
}
