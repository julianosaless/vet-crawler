using System.Collections.Generic;

namespace VetDirectoryTool.Core.Parser.Model
{
    public readonly struct ParserResponseModel
    {
        public List<ParserFileModel> ParserFileModels { get; }

        public ParserResponseModel(List<ParserFileModel> parserFileModels)
        {
            ParserFileModels = parserFileModels;
        }
    }
}
