namespace FiorellaAPI.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
    }
}

