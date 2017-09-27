namespace Fabric.Terminology.Client
{
    /// <summary>
    /// Extension methods for
    ///     <see>
    ///         <cref>System.String</cref>
    ///     </see>
    /// </summary>
    public static partial class Extensions
    {
        internal static bool IsNullOrWhiteSpace(this string value)
        {
            return (value == null) || (value.Trim().Length == 0);
        }
    }
}
