using System.Collections.Generic;
using System.Threading.Tasks;

namespace VetDirectoryTool.Core.Service.Reporting
{
    public class ReportingService
    {
        public ReportingService(ReportingType reportingType)
        {
            ReportingType = reportingType;
        }

        private readonly ReportingType ReportingType;

        public async Task ExportAsync<T>(string path, List<T> result)
        {
            switch (ReportingType)
            {
                case ReportingType.PetMedsTypeCsv:
                    break;
                default:
                    break;
            }
        }
    }
}