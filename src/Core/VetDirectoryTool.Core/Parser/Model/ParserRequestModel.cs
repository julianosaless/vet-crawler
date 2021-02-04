namespace VetDirectoryTool.Core.Parser.Model
{
    public readonly struct ParserRequestModel
    {
        public string Content { get; }

        public ParserRequestModel(string content)
        {
            Content = content;
        }
    }
}
