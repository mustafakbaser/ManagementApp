using ManagementApp.Models;

namespace ManagementApp.Services
{
    public interface IWorkOrderImageService
    {
        Task<IEnumerable<Image>> GetAllImagesAsync();
        Task<Image> GetImageByIdAsync(int id);
        Task<Image> AddImageAsync(Image image);
        Task<Image> UpdateImageAsync(Image image);
        Task<bool> DeleteImageAsync(int id);
    }
}
