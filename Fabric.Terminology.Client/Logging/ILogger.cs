namespace Fabric.Terminology.Client.Logging
{
    using System;

    public interface ILogger
    {
        void Error(Type callingType, string message, Exception exception, params Func<object>[] propertyValues);

        void Error(string message, Exception exception, params Func<object>[] propertyValues);

        void Warning(Type callingType, string message, Exception exception, params Func<object>[] propertyValues);

        void Warning(string message, Exception exception, params Func<object>[] propertyValues);

        void Information(string message);

        void Information(string message, params Func<object>[] propertyValues);

        void Information(Type callingType, string message, params Func<object>[] propertyValues);

        void Debug(string message);

        void Debug(string message, params Func<object>[] propertyValues);

        void Debug(Type callingType, string message, params Func<object>[] propertyValues);
    }
}