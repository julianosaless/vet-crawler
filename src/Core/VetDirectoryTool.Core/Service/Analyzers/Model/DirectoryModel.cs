namespace VetDirectoryTool.Core.Service.Analyzers.Model
{
    public readonly struct DirectoryModel
    {
        public string Path { get; }
        public string OutputPath { get; }
        public bool Verbose { get; }

        public DirectoryModel(string path, string outputPath, bool verbose)
        {
            Path = path;
            OutputPath = outputPath;
            Verbose = verbose;
        }
    }
}
