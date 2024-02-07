namespace RashakaGroupsAdmin.Services
{
    public interface IimagesSevice
    {
        Task<string> UploadAsync(string url, IFormFile file, string fileName);
        Task<List<string>> UploadAsync(string url, List<IFormFile> files, string fileName);
        string GetProfileImageUrl(string image, string id);
    }
}
