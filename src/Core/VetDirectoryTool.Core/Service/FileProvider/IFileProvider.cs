using System.Threading.Tasks;

namespace VetDirectoryTool.Core.Service.FileProvider
{
    public interface IFileProvider
    {
        Task<string> GetContentAsync();
    }
}
