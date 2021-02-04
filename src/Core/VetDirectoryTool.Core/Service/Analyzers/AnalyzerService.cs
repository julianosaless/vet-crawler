using System.IO;

using VetDirectoryTool.Core.Service.FileProvider;
using VetDirectoryTool.Core.Service.Reporting;

namespace VetDirectoryTool.Core.Service.Analyzers
{
    public static class AnalyzerService
    {
        public static PetMedsAnalyzerService CreateAnalyzer(string path)
        {
            return new PetMedsAnalyzerService(new RemoteUrlProviderService(path, $"{Path.GetTempPath()}/petmeds.html"), new ReportingService(ReportingType.PetMedsTypeCsv));
        }
    }
}
