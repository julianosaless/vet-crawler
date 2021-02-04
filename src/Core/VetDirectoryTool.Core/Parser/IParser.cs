using System.Collections.Generic;
using VetDirectoryTool.Core.Parser.Model;

namespace VetDirectoryTool.Core.Parser
{
    public interface IParser
    {
        List<ParserFileModel> Analyze(ParserRequestModel parserRequest);
    }
}
