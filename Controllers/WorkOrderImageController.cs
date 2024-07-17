using ManagementApp.Models;
using ManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderImageController : ControllerBase
    {
        private readonly IWorkOrderImageService _imageService;

        public WorkOrderImageController(IWorkOrderImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var images = await _imageService.GetAllImagesAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var image = await _imageService.GetImageByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpPost]
        public async Task<IActionResult> AddImage([FromBody] Image image)
        {
            var createdImage = await _imageService.AddImageAsync(image);
            return CreatedAtAction(nameof(GetImageById), new { id = createdImage.Id }, createdImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(int id, [FromBody] Image image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }

            var updatedImage = await _imageService.UpdateImageAsync(image);
            return Ok(updatedImage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var result = await _imageService.DeleteImageAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
