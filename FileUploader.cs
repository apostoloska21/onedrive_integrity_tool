using Microsoft.Graph;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace OneDriveIntegrityTool
{


    public class FileUploader
    {
        // using _ in graphClient field to distinguish private field from public property 
        private readonly GraphServiceClient _graphClient;
        public FileUploader(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        public async Task UploadFileAsync(string localPath, string onedriveFileName)
        {
            //get all drives
            var drivesResponse = await _graphClient.Drives.GetAsync();
            var primaryDrive = drivesResponse?.Value?.FirstOrDefault();
            if (primaryDrive == null)
                throw new Exception("No drives found for user");

            // drive get file in root of primary drive
            using var stream = File.OpenRead(localPath);
            await _graphClient.Drives[primaryDrive.Id].Root
                .ItemWithPath(onedriveFileName)
                .Content
                .PutAsync(stream);
        }
    }

}