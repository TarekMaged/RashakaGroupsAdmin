using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace RashakaGroupsAdmin.Models
{
    public class Imagesviewmodel
    {
        static IWebHostEnvironment environment;
        public string Url { get; set; }
        public Imagesviewmodel(IWebHostEnvironment _environment)
        {
            environment = _environment;
        }

        public string UploadIFormFile(IFormFile file, string folderPath, string imageName)
        {
            string fileName = string.Empty;
            try
            {
                if (file.Length > 0)
                {
                    fileName = GetUniqueFileName(file, imageName);
                    string path = Path.GetFullPath(Path.Combine(environment.WebRootPath, folderPath, fileName));
                    using var fileStream = new FileStream(path, FileMode.Create);
                    file.CopyTo(fileStream);
                }
                return fileName;
            }
            catch (Exception)
            {
                return fileName;
            }
        }
        public static string GetUniqueFileName(IFormFile file, string imageName)
        {
            string fileName = Path.GetFileName(file.FileName).Trim('\"');
            return string.Concat(imageName, DateTime.Now.ToString("yyyyMMddHHmmssfff"), Path.GetExtension(fileName));
        }
       
        private async Task<string> UploadAsync(string url, IFormFile file, string fileName)
        {
            using HttpClient httpClient = new();
            MultipartFormDataContent content = new();

            using var stream1 = new MemoryStream();
            await file.CopyToAsync(stream1);
            var fileContent1 = new StreamContent(stream1);
            fileContent1.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            string fullFileName = GetUniqueFileName(file, fileName);
            content.Add(fileContent1, "files",fullFileName);

           
            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            return fullFileName;
        }
        private async Task UploadAsync(string url, List<IFormFile> files, string fileName)
        {
            using HttpClient httpClient = new();
            List<string> filesNames = new List<string>();   
            MultipartFormDataContent content = new();
            foreach (var item in files)
            {
                using var stream1 = new MemoryStream();
                await item.CopyToAsync(stream1);
                var fileContent1 = new StreamContent(stream1);
                fileContent1.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                string fullFileName = GetUniqueFileName(item, fileName);
                content.Add(fileContent1, "files", fullFileName);
                filesNames.Add(fullFileName);
            }
            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }
    }
}