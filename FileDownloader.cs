using Microsoft.Graph;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace OneDriveIntegrityTool
{
    public class FileDownloader
    {
        private readonly GraphServiceClient _graphClient;
        public FileDownloader(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        public async Task DownloadFileAsync(string onedriveFileName, string localPath)
        {
            //if i want to download form specific user  (me)
            // string userId = "martina@tenantthingie.onmicrosoft.com";

            // get all drives like in uploader
            var drivesResponse = await _graphClient.Drives
                .GetAsync();
            var firstDrive = drivesResponse?.Value?.FirstOrDefault();

            var primaryDrive = drivesResponse?.Value?.FirstOrDefault();
            if (primaryDrive == null)
                throw new Exception("No drives found for user");



            // download file from root of primary drive
            var stream = await _graphClient.Drives[primaryDrive.Id].Root
                .ItemWithPath(onedriveFileName)
                .Content
                .GetAsync();
            // if i want to download for specific user
            //  var stream = await _graphClient.Users[userId].Drive.Root
            // .ItemWithPath(onedriveFileName)
            // .Content
            // .GetAsync();


            if (stream == null)
                throw new Exception("Failed to download file");

            using var fileStream = File.Create(localPath);
            await stream.CopyToAsync(fileStream);
        }
    }
}