using ManagementApp.Models;

namespace ManagementApp.Services
{
    public interface IWorkOrderService
    {
        Task<IEnumerable<WorkOrder>> GetAllWorkOrdersAsync();
        Task<WorkOrder> GetWorkOrderByIdAsync(int id);
        Task<WorkOrder> AddWorkOrderAsync(WorkOrder workOrder);
        Task<WorkOrder> UpdateWorkOrderAsync(WorkOrder workOrder);
        Task<bool> DeleteWorkOrderAsync(int id);
    }
}