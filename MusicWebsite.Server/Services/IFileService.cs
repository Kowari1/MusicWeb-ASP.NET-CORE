namespace MusicWebsite.Server.Services
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string folder);
        Task<bool> DeleteFileAsync(string filePath);
        string GetFilePath(string fileName, string folder);
    }
}
