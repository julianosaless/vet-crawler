using System;
using System.Linq;
using System.Collections.Generic;

using VetDirectoryTool.Core.Parser.Model;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace VetDirectoryTool.Core.Parser.Template
{
    public class PetMedsParserTemplate : IParser
    {
        private const string OnlyDataStoreInfo = "data-store-info=.*";

        public List<ParserFileModel> Analyze(ParserRequestModel parserRequest) => Evaluate(parserRequest.Content);

        private List<ParserFileModel> Evaluate(string source)
        {
            var groupResults = Regex.Matches(source, OnlyDataStoreInfo);

            return groupResults
                .Where(x => x.Success)
                .Select(x => x.Value)
                .Select(candidate => ExtractToModel(Sanitize(candidate)))
                .Distinct()
                .ToList();
        }

        private ParserFileModel ExtractToModel(string value)
        {
            var informations = value.Split('-');
            string ExtractName()
            {
                var currentInfo = informations.Single(x => x.StartsWith("name:"));
                return currentInfo.Replace("name:", string.Empty);
            }

            string ExtractAddress()
            {
                var currentInfo = informations.Single(x => x.StartsWith("address1:"));
                return currentInfo.Replace("address1:", string.Empty);
            }

            string ExtractPhone()
            {
                var currentInfo = informations.Single(x => x.StartsWith("ID:"));
                return currentInfo.Replace("ID:", string.Empty);
            }
            return new ParserFileModel(ExtractName(), ExtractAddress(), ExtractPhone());
        }

        private string Sanitize(string value)
        {
            return value
                .Replace("data-store-info", string.Empty)
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/>", string.Empty)
                .Replace("\":\"", ":")
                .Replace("\",\"", "-")
                .Replace(",", "-")
                .Replace("\"", string.Empty)
                .Trim();
        }
    }
}
