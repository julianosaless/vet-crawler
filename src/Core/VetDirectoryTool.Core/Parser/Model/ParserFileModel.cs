namespace VetDirectoryTool.Core.Parser.Model
{
    public readonly struct ParserFileModel
    {
        public string Name { get; }
        public string Address { get; }
        public string Phone { get; }

        public ParserFileModel(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}
