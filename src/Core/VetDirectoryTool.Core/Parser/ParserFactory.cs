using System.Collections.Generic;
using VetDirectoryTool.Core.Parser.Template;

namespace VetDirectoryTool.Core.Parser
{
    public class ParserFactory
    {
        private readonly IEnumerable<IParser> Parsers = new List<IParser>
        {
            new PetMedsParserTemplate()
        };
    }
}
