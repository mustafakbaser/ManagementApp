using ManagementApp.Models;

namespace ManagementApp.Services
{
    public interface IWorkOrderDocumentService
    {
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> GetDocumentByIdAsync(int id);
        Task<Document> AddDocumentAsync(Document document);
        Task<Document> UpdateDocumentAsync(Document document);
        Task<bool> DeleteDocumentAsync(int id);
    }
}
