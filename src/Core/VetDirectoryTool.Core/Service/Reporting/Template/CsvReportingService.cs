using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using CsvHelper;

using VetDirectoryTool.Core.Parser.Model;
using CsvHelper.Configuration;
using System.Globalization;
using System;

namespace VetDirectoryTool.Core.Service.Reporting.Template
{
    public class CsvReportingService
    {
        private readonly string Path;
        private readonly string Format = "yyyy-MM-dd";

        public CsvReportingService(string path)
        {
            Path = PreparePath(path);
        }

        public async Task ExportAsync(List<ParserFileModel> csvReporting)
        {
            var fileName = Path;
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                CreateHeader(csv);
                await CreateBodyAsync(csv, csvReporting);
                await writer.FlushAsync();
                Console.WriteLine(fileName);
                stream.Position = 0;
            }
        }

        private void CreateHeader(CsvWriter csv)
        {
            csv.WriteField("Name");
            csv.WriteField("Address1");
            csv.WriteField("Phone");
        }

        private async Task CreateBodyAsync(CsvWriter csv, List<ParserFileModel> parseFiles)
        {
            var exportsData = (from parseFile in parseFiles
                               select new
                               {
                                   parseFile.Name,
                                   parseFile.Address,
                                   parseFile.Phone,
                                 
                               });

            foreach (var item in exportsData)
            {
                await csv.NextRecordAsync();
                csv.WriteField(item.Name);
                csv.WriteField(item.Address);
                csv.WriteField(item.Phone);
            }
        }

        private string PreparePath(string path)
        {
            string CreateDefaultFile(string pathFile, string file) => string.Concat(pathFile, "\\", file);
            bool IsCsvFile(string file) => System.IO.Path.GetExtension(file).ToUpper().Equals(".CSV");

            if (string.IsNullOrEmpty(path))
            {
                return CreateDefaultFile(path, DefaultFile);
            }
            return IsCsvFile(path) ? path : CreateDefaultFile(path, DefaultFile);
        }

        private string DefaultFile => $"report-Vet-Directory-{DateTime.Now.ToString(Format)}.csv";
    }
}
