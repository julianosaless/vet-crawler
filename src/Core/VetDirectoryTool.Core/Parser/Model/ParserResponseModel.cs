using System.Collections.Generic;

namespace VetDirectoryTool.Core.Parser.Model
{
    public readonly struct ParserResponseModel
    {
        public string Source { get; }
        public List<ParserFileModel> ParserFiles { get; }

        public ParserResponseModel(string source, List<ParserFileModel> parserFiles)
        {
            Source = source;
            ParserFiles = parserFiles;
        }
    }
}
