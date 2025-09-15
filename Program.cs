using System;
using System.Threading.Tasks;
using Microsoft.Graph;
using Azure.Identity;

namespace OneDriveIntegrityTool
{
    class Program
    {
             private static readonly string ClientId = "here goes the application client id";

        // directory - tenant id 
        private static readonly string TenantId = "here goes the tenant id(directory id)";
        private static readonly string ClientSecret = "here goes the client secret(value)";

        static async Task Main(string[] args)
        {
            try
            {
                var authManager = new AuthManager(ClientId, TenantId, ClientSecret);
                var graphClient = authManager.GetAuthenticatedClient();
                var fileUploader = new FileUploader(graphClient);
                var FileDownloader = new FileDownloader(graphClient);

                await fileUploader.UploadFileAsync("../data/test.txt", "test.txt");
                Console.WriteLine("Upload done!");

                await FileDownloader.DownloadFileAsync("../data/test.txt", "downloaded_test.txt");
                Console.WriteLine("Download done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
