namespace VetDirectoryTool.Core.Parser.Model
{
    public readonly struct ParserRequestModel
    {
        public ParserRequestModel(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }
}
