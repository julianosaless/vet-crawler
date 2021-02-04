using System;
using System.Net;
using System.Threading.Tasks;

namespace VetDirectoryTool.Core.Service.FileProvider
{
    public class RemoteUrlProviderService : IFileProvider
    {
        private readonly string Url;
        private readonly string Output;

        public RemoteUrlProviderService(string url, string output)
        {
            Url = url;
            Output = output;
        }

        public async Task<string> GetContentAsync()
        {
            using WebClient client = new WebClient();
            await client.DownloadFileTaskAsync(new Uri(Url), Output);
            return "";
        }
    }
}
