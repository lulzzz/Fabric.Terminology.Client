using Moq;

namespace Fabric.Terminology.Client.TestsBase
{
    using System.IO;
    using Fabric.Terminology.Client.Configuration;
    using Newtonsoft.Json;

    public static class TestHelper
    {
        public static FileInfo GetConfigFile()
        {
            var fileName = $"terminologyApiSettings.json";
            var path = $"{Directory.GetCurrentDirectory()}\\..\\..\\..\\";
            var filePath = $"{path}{fileName}";

            if (!File.Exists(filePath))
            {
                return null;
            }

            return new FileInfo(filePath);
        }

        public static TerminologyApiSettings GetConfig()
        {
            var file = GetConfigFile();

            return file != null
                ? JsonConvert.DeserializeObject<TerminologyApiSettings>(File.ReadAllText(file.FullName))
                : new Mock<TerminologyApiSettings>().Object;
        }
    }
}