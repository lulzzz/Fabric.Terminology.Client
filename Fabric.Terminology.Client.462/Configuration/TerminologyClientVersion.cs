namespace Fabric.Terminology.Client.Configuration
{
    using System;
    using System.Reflection;
    using Semver;

    public static class TerminologyClientVersion
    {
        public static Version Current { get; } = new AssemblyName(typeof(TerminologyClientVersion).GetTypeInfo().Assembly.FullName).Version;

        public static string CurrentComment => "alpha";

        public static string AssemblyVersion => Current.ToString();

        public static string Route => $"v{Current.Major}.{Current.Minor}";

        public static SemVersion SemanticVersion => new SemVersion(
            Current.Major,
            Current.Minor,
            Current.Build,
            CurrentComment.IsNullOrWhiteSpace() ? null : CurrentComment,
            Current.Revision > 0 ? Current.Revision.ToString() : null);
    }
}
