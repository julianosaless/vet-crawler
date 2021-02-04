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
            csv.WriteField("Address 1");
            csv.WriteField("Address 2");
            csv.WriteField("City");
            csv.WriteField("Postal Code");
            csv.WriteField("Latitude");
            csv.WriteField("Longitude");
            csv.WriteField("State Code");
            csv.WriteField("Country Code");
            csv.WriteField("Distance");
            csv.WriteField("Phone");
        }

        private async Task CreateBodyAsync(CsvWriter csv, List<ParserFileModel> parseFiles)
        {

            foreach (var item in parseFiles)
            {
                await csv.NextRecordAsync();
                csv.WriteField(item.Name);
                csv.WriteField(item.Address1);
                csv.WriteField(item.Address2);
                csv.WriteField(item.City);
                csv.WriteField(item.PostalCode);
                csv.WriteField(item.Latitude);
                csv.WriteField(item.Longitude);
                csv.WriteField(item.StateCode);
                csv.WriteField(item.CountryCode);
                csv.WriteField(item.Distance);
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
