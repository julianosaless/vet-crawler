using System.Threading.Tasks;

using VetDirectoryTool.Core.Parser;
using VetDirectoryTool.Core.Parser.Model;
using VetDirectoryTool.Core.Service.Analyzers.Model;
using VetDirectoryTool.Core.Service.FileProvider;
using VetDirectoryTool.Core.Service.Reporting;

namespace VetDirectoryTool.Core.Service.Analyzers
{
    public class PetMedsAnalyzerService
    {
        private readonly IFileProvider FileProvider;
        private readonly ReportingService ReportingService;

        public PetMedsAnalyzerService(IFileProvider fileProvider, ReportingService reportingService)
        {
            FileProvider = fileProvider;
            ReportingService = reportingService;
        }

        public async Task AnalyzeAsync(DirectoryModel analyzeModel)
        {
            var content = await FileProvider.GetContentAsync();
            var parserResponse = new ParserFactory().Analyze(new ParserRequestModel(content));
            await ReportingService.ExportAsync(analyzeModel.OutputPath, parserResponse.ParserFileModels);
        }

    }
}
