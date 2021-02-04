using System;
using System.IO;
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
            if (!File.Exists(Output))
            {
                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(new Uri(Url), Output);
                }
            }

            using (var reader = File.OpenText(Output))
            {
                var content =  await reader.ReadToEndAsync();
                return System.Web.HttpUtility.HtmlDecode(content);
            }
        }
    }
}
