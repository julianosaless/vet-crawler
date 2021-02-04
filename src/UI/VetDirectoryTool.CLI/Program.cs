using System;
using System.Reflection;

using McMaster.Extensions.CommandLineUtils;

using VetDirectoryTool.CLI.Controller;
using VetDirectoryTool.Core.Service.Analyzers;
using VetDirectoryTool.Core.Service.Analyzers.Model;

namespace VetDirectoryTool.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "",
                Description = ""
            };

            app.HelpOption("-?|-h|--help");
            app.VersionOption("-v|--version", () => $"Version {Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}");

            new VetCommandController(app).Apply();

            app.OnExecute(async () =>
            {

#if DEBUG
                const string path = @"https://www.1800petmeds.com/vetdirectory";
                const string exportPath = @"C:\\Temp";
                var analyzeModel = new DirectoryModel(path, exportPath, verbose: true);
               
                var analyzeService = AnalyzerService.CreateAnalyzer(analyzeModel.Path);
                await analyzeService.AnalyzeAsync(analyzeModel);
#endif
                return 0;
            });

            try
            {
                app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
