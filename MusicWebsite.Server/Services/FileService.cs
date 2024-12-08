
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using MusicWebsite.Server.Configurations;

namespace MusicWebsite.Server.Services
{
    public class FileService : IFileService
    {

        private readonly IWebHostEnvironment _env;
        private readonly FileStorageOptions _options;

        public FileService(IWebHostEnvironment env, IOptions<FileStorageOptions> options)
        {
            _env = env;
            _options = options.Value;
        }


        public async Task<bool> DeleteFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Путь к файлу не предоставлен.");
            }

            var fullPath = Path.Combine(_env.ContentRootPath, _options.RootPath, filePath);

            if (!System.IO.File.Exists(fullPath))
            {
                return false;
            }

            await Task.Run(() => System.IO.File.Delete(fullPath));
            return true;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
            throw new ArgumentNullException("Файл пустой или не предоставлен.");

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";

            string filePath = GetFilePath(folder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create)) 
            { 
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }

        public string GetFilePath(string fileFolder, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Имя файла не предоставлено.");            

            return Path.Combine(_env.ContentRootPath, _options.RootPath, fileFolder, fileName);
        }
    }
}
