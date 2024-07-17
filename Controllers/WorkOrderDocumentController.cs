using ManagementApp.Models;
using ManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderDocumentController : ControllerBase
    {
        private readonly IWorkOrderDocumentService _documentService;

        public WorkOrderDocumentController(IWorkOrderDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument([FromBody] Document document)
        {
            var createdDocument = await _documentService.AddDocumentAsync(document);
            return CreatedAtAction(nameof(GetDocumentById), new { id = createdDocument.Id }, createdDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] Document document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }

            var updatedDocument = await _documentService.UpdateDocumentAsync(document);
            return Ok(updatedDocument);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var result = await _documentService.DeleteDocumentAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
