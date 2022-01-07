using ConferenceHall.Domain.Files.Interfaces;

namespace ConferenceHall.Domain.Files.Services;

public class FileService : IFileService
{
    public async Task Upload(IFormFileCollection uploads)
    {
        string root = Directory.GetCurrentDirectory();
        string staticPath = Path.Join(root, "/Static");
        foreach (var uploadFile in uploads)
        {
            string guid = Guid.NewGuid().ToString();
            string[] parts = uploadFile.FileName.Split('.');
            string filePath = Path.Join(staticPath, $"/{guid}.{parts[^1]}");
            
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await uploadFile.CopyToAsync(fileStream);
            }
        }
    }
}