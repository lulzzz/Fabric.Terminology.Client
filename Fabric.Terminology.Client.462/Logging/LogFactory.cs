namespace Fabric.Terminology.Client.Logging
{
    using Serilog;
    using Serilog.Core;

    /// <summary>
    /// Responsible for creating the <see cref="ILogger"/>
    /// </summary>
    /// <remarks>
    /// This class should be removed with Fabric.Platform logging has been finalized.
    /// </remarks>
    internal class LogFactory
    {
        public static ILogger CreateLogger(LoggingLevelSwitch levelSwitch)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.FromLogContext()
                .WriteTo.LiterateConsole()
                .WriteTo.RollingFile("Logs\\fabric-terminology-{Date}.txt")
                .CreateLogger();

            return new SerilogAdapter(logger);
        }
    }
}