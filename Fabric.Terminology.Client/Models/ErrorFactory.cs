namespace Fabric.Terminology.Client.Models
{
    using System;
    using System.Net;

    internal static class ErrorFactory
    {
        public static TerminologyApiError CreateError<T>(string message, HttpStatusCode statusCode)
        {
            return new TerminologyApiError(
                Enum.GetName(typeof(HttpStatusCode), statusCode),
                typeof(T).Name,
                message);
        }
    }
}
