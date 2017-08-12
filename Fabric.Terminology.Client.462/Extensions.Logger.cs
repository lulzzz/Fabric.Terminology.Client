namespace Fabric.Terminology.Client
{
    using System;
    using Fabric.Terminology.Client.Logging;

    /// <summary>
    /// Extensions specific to <see cref="ILogger"/>
    /// </summary>
    public static partial class Extensions
    {
        public static void Error<T>(
            this ILogger logger,
            string message,
            Exception exception,
            params object[] propertyValues)
        {
            logger.Error(typeof(T), message, exception, propertyValues);
        }

        public static void Warning<T>(
            this ILogger logger,
            string message,
            Exception exception,
            params object[] propertyValues)
        {
            logger.Warning(typeof(T), message, exception, propertyValues);
        }

        public static void Information<T>(
            this ILogger logger,
            string message,
            params object[] propertyValues)
        {
            logger.Information(typeof(T), message, propertyValues);
        }

        public static void Debug<T>(
            this ILogger logger,
            string message,
            params object[] propertyValues)
        {
            logger.Debug(typeof(T), message, propertyValues);
        }
    }
}
