using System.Collections.Generic;
using System.Threading.Tasks;

using VetDirectoryTool.Core.Parser.Model;
using VetDirectoryTool.Core.Service.Reporting.Template;

namespace VetDirectoryTool.Core.Service.Reporting
{
    public class ReportingService
    {
        public ReportingService(ReportingType reportingType)
        {
            ReportingType = reportingType;
        }

        private readonly ReportingType ReportingType;

        public async Task ExportAsync(string path, List<ParserFileModel> result)
        {
            switch (ReportingType)
            {
                case ReportingType.PetMedsTypeCsv:
                    await new CsvReportingService(path).ExportAsync(result);
                    break;
                default:
                    break;
            }
        }
    }
}