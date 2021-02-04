using McMaster.Extensions.CommandLineUtils;

namespace VetDirectoryTool.CLI.Controller
{
    public abstract class CommandControllerBase
    {
        protected readonly CommandLineApplication App;
        protected abstract string Name { get; }

        protected CommandControllerBase(CommandLineApplication app)
        {
            App = app;
        }
        public abstract void Apply();
    }
}
