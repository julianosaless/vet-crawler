using System.Linq;
using System.Collections.Generic;

using VetDirectoryTool.Core.Parser.Model;
using VetDirectoryTool.Core.Parser.Template;

namespace VetDirectoryTool.Core.Parser
{
    public class ParserFactory
    {
        private readonly IEnumerable<IParser> Parsers = new List<IParser>
        {
            new PetMedsParserTemplate()
        };

        public  ParserResponseModel Analyze(ParserRequestModel parserRequest)
        {
            var filesFounded = Parsers.SelectMany(x => x.Analyze(parserRequest)).ToList();
            return new ParserResponseModel(filesFounded);
        }
    }
}
