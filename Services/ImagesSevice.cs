using RashakaGroupsAdmin.Models;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;

namespace RashakaGroupsAdmin.Services
{
    public class ImagesSevice: IimagesSevice
    {
        public static string apiImagesPath = "https://files.rashaqa.net/";

        public static string baseGroupImageURL = apiImagesPath + "groups/";
        public static string basePostsImageURL = apiImagesPath + "groups/posts/";
        public static string baseAdminImageURL = "https://static.rashaqa.net/uploads/";
        public static string basePostCommentsImageURL = apiImagesPath + "groups/posts/comments/";
        static IWebHostEnvironment environment;
        public string Url { get; set; }
        public ImagesSevice(IWebHostEnvironment _environment)
        {
            environment = _environment;
        }
        public  string GetUniqueFileName(IFormFile file, string imageName)
        {
            string fileName = Path.GetFileName(file.FileName).Trim('\"');
            return string.Concat(imageName, DateTime.Now.ToString("yyyyMMddHHmmssfff"), Path.GetExtension(fileName));
        }

        public async Task<string> UploadAsync(string url, IFormFile file, string fileName)
        {
            using HttpClient httpClient = new();
            MultipartFormDataContent content = new();

            using var stream1 = new MemoryStream();
            await file.CopyToAsync(stream1);
            var fileContent1 = new StreamContent(stream1);
            fileContent1.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            string fullFileName = GetUniqueFileName(file, fileName);
            content.Add(fileContent1, "files", fullFileName);
            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            return fullFileName;
        }
        public async Task<List<string>> UploadAsync(string url, List<IFormFile> files, string fileName)
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
            return filesNames;
        }




        public  string UploadEventImage(IFormFile file)
        {
            string fileName = string.Empty;
            try
            {
                //var file = HttpContext.Current.Request.Files[0];
                if (file.FileName.StartsWith("defaultEventImg") == false)
                {
                    fileName = UploadAsync("https://api.rashaqa.net/Images/Groups/events/", file, "eventImage").Result;
                }
            }
            catch { }
            return fileName;
        }



        public  string GetFileExtension(string data, string imageName)
        {
            //string fileName = AppendTimeStamp(imageName);
            data = data.Substring(0, 5);
            string extention = "jpg";
            switch (data.ToUpper())
            {
                case "IVBOR":
                    extention = "png";
                    break;
                case "AAABA":
                    extention = "ico";
                    break;
            }
            return imageName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + extention;
        }
        private  string AppendTimeStamp(string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fileName)
                );
        }
        public  string GetProfileImageUrl(string image,string id)
        {
            if (!string.IsNullOrEmpty(image))
            {
                return (image.Trim().Contains("http://") || image.Contains("https://")) ? image : apiImagesPath + "profile/" + image;
            }
            return "https://groupanel.rashaqa.net/content/frontend/imgs/userDefault.png";
        }

        public static string GetProfileImageUrl(string image)
        {
            if (!string.IsNullOrEmpty(image))
            {
                return (image.Trim().Contains("http://") || image.Contains("https://")) ? image : apiImagesPath + "profile/" + image;
            }
            return "https://groupanel.rashaqa.net/content/frontend/imgs/userDefault.png";
        }

        public static string GetGroupImageUrl(string image)
        {
            return !string.IsNullOrEmpty(image) ? baseGroupImageURL + image : "";
        }
        public static string GetPostImageUrl(string image)
        {
            if (!string.IsNullOrEmpty(image))
            {
                image = (image.Trim().Contains("http://") || image.Contains("https://")) ? image : basePostsImageURL + image;
            }
            return image;
        }
        public static string GetPostImageUrl(GroupPost groupPost)
        {
            if (!string.IsNullOrEmpty(groupPost.image))
            {
                return GetPostImage(groupPost.image);
            }
            if (!string.IsNullOrEmpty(groupPost.image2))
            {
                return GetPostImage(groupPost.image2);
            }
            if (!string.IsNullOrEmpty(groupPost.image3))
            {
                return GetPostImage(groupPost.image3);
            }
            return string.Empty;
        }
        public static string GetPostImage(string imageName)
        {
            return (imageName.Trim().Contains("http://") || imageName.Contains("https://")) ? imageName : basePostsImageURL + imageName;
        }

       
    }
}