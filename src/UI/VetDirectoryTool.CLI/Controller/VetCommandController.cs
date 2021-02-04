using System.IO;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using VetDirectoryTool.Core.Service.Analyzers;
using VetDirectoryTool.Core.Service.Analyzers.Model;

namespace VetDirectoryTool.CLI.Controller
{
    public class VetCommandController : CommandControllerBase
    {
        public VetCommandController(CommandLineApplication app) : base(app)
        {
        }

        protected override string Name => "directory";

        public override void Apply()
        {
            App.Command(Name, (command) =>
            {
                command.Description = "";
                command.ExtendedHelpText = "";
                command.HelpOption("-?|-h|--help");

                var exportOutput = command.Option(
                    "-o|--output <OUTPUT_DIR>",
                    "",
                    CommandOptionType.SingleValue);

                var verboseOption = command.Option(
                    "--verbose",
                    "",
                    CommandOptionType.NoValue);

                command.OnExecute(async () =>
                {
                    var outputPath = exportOutput.HasValue() ? exportOutput.Value() : Directory.GetCurrentDirectory();

                    var directoryModel = new DirectoryModel("https://www.1800petmeds.com/vetdirectory", outputPath, verboseOption.HasValue());
                    await CreateAnalyzeAsync(directoryModel);
                    return 0;
                });
            });
        }

        private async Task CreateAnalyzeAsync(DirectoryModel directoryModel)
        {
            await AnalyzerService
                .CreateAnalyzer(path: "https://www.1800petmeds.com/vetdirectory")
                .AnalyzeAsync(directoryModel);
        }
    }
}
