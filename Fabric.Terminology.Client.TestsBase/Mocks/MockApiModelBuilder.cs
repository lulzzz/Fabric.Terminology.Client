namespace Fabric.Terminology.Client.TestsBase.Mocks
{
    using System;
    using System.Collections.Generic;
    using Fabric.Terminology.Client.Models;

    public class MockApiModelBuilder
    {
        public static IEnumerable<CodeSetCode> BuildCodeSetCodeCollection(int count = 10)
        {
            for (var i = 0; i < count; i++)
            {
                yield return BuildCodeSetCode($"Code.Set.Code.{i}", $"Code.Set.Code.{i} Name");
            }
        }

        public static CodeSetCode BuildCodeSetCode(string code, string name)
        {
            var codeSystem = new CodeSystem
            {
                Code = "TEST-CODE-SYSTEM",
                Name = "TEST CODE SYSTEM",
                Version = "TEST-CODE-SYSTEM-VERSION"
            };

            return new CodeSetCode
            {
                Code = code,
                Name = name,
                SourceDescription = "TEST Source",
                VersionDescription = "TEST Version",
                CodeSystem = codeSystem,
                LastLoadDate = DateTime.UtcNow
            };
        }
    }
}
