using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UploadImageToCloudinary
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = "C:\\Users\\Christopher\\Desktop\\Angele_Dei_Pictures";

            const int imageType = 1;

            DirectoryInfo directory = new DirectoryInfo(path);

            FileInfo[] fileInfos = directory.GetFiles();

            ISet<AttachedFileRequest> base64Files = fileInfos.Select(fileInfo => new AttachedFileRequest
            {
                File = Convert.ToBase64String(File.ReadAllBytes(fileInfo.FullName)),
                Format = fileInfo.Extension.Replace(".jpg","jpg"),
                Summary = fileInfo.Name,
                Type = imageType
            }).ToHashSet();

            UploadImages(base64Files);
        }

        private static void UploadImages(ISet<AttachedFileRequest> base64Files)
        {
            Guid userId = FileServices.GetUserId().Result;
            string token = FileServices.GetToken(userId).Result;

            foreach (AttachedFileRequest attachedFileRequest in base64Files)
            {
                FileServices.UploadAttachedFile(attachedFileRequest, token).Wait();
            }
        }
    }
}
