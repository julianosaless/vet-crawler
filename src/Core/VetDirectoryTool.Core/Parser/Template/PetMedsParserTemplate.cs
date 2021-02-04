using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using VetDirectoryTool.Core.Parser.Model;

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

            string ExtractAddress1()
            {
                var currentInfo = informations.Single(x => x.StartsWith("address1:"));
                return currentInfo.Replace("address1:", string.Empty);
            }

            string ExtractAddress2()
            {
                var currentInfo = informations.Single(x => x.StartsWith("address2:"));
                return currentInfo.Replace("address2:", string.Empty);
            }

            string ExtractCity()
            {
                var currentInfo = informations.Single(x => x.StartsWith("city:"));
                return currentInfo.Replace("city:", string.Empty);
            }

            string ExtractPostalCode()
            {
                var currentInfo = informations.Single(x => x.StartsWith("postalCode:"));
                return currentInfo.Replace("postalCode:", string.Empty);
            }

            string ExtractLatitude()
            {
                var currentInfo = informations.Single(x => x.StartsWith("latitude:"));
                return currentInfo.Replace("latitude:", string.Empty);
            }

            string ExtractLongitude()
            {
                var currentInfo = informations.Single(x => x.StartsWith("longitude:"));
                return currentInfo.Replace("longitude:", string.Empty);
            }

            string ExtractStateCode()
            {
                var currentInfo = informations.Single(x => x.StartsWith("stateCode:"));
                return currentInfo.Replace("stateCode:", string.Empty);
            }


            string ExtractCountryCode()
            {
                var currentInfo = informations.Single(x => x.StartsWith("countryCode:"));
                return currentInfo.Replace("countryCode:", string.Empty);
            }

            string ExtractCountryDistance()
            {
                var currentInfo = informations.Single(x => x.StartsWith("distance:"));
                return currentInfo.Replace("distance:", string.Empty);
            }

            string ExtractPhone()
            {
                var currentInfo = informations.Single(x => x.StartsWith("ID:"));
                return currentInfo.Replace("ID:", string.Empty);
            }

            return new ParserFileModel
            (
                ExtractName(), ExtractAddress1(),
                ExtractAddress2(),
                ExtractCity(), ExtractPostalCode(),
                ExtractLatitude(), ExtractLongitude(),
                ExtractStateCode(), ExtractCountryCode(),
                ExtractCountryDistance(), ExtractPhone()
            );
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
