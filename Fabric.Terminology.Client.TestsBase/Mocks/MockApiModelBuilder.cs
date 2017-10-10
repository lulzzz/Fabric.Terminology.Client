namespace Fabric.Terminology.Client.TestsBase.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fabric.Terminology.Client.Models;

    public class MockApiModelBuilder
    {
        public static IEnumerable<CodeSetCode> BuildCodeSetCodeCollection(IEnumerable<Guid> codeSystems, int count = 10)
        {
            var codeSystemGuids = codeSystems as Guid[] ?? codeSystems.ToArray();
            var r = new Random();
            for (var i = 0; i < count; i++)
            {
                yield return BuildCodeSetCode($"Code.Set.Code.{i}", $"Code.Set.Code.{i} Name", Guid.NewGuid(), codeSystemGuids[r.Next(0, codeSystemGuids.Length - 1)]);
            }
        }

        public static CodeSetCode BuildCodeSetCode(string code, string name, Guid codeGuid, Guid codeSystemGuid)
        {
            return new CodeSetCode
            {
                Code = code,
                Name = name,
                CodeGuid = codeGuid,
                CodeSystemGuid = codeSystemGuid
            };
        }
    }
}
