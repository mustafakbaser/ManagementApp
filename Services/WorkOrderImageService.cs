using ManagementApp.Data;
using ManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Services
{
    public class WorkOrderImageService : IWorkOrderImageService
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderImageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetImageByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task<Image> AddImageAsync(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> UpdateImageAsync(Image image)
        {
            _context.Entry(image).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return false;
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
