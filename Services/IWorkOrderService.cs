using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementApp.Models;

namespace ManagementApp.Services
{
    public interface IWorkOrderService
    {
        Task<IEnumerable<WorkOrder>> GetWorkOrdersAsync();
        Task<WorkOrder> GetWorkOrderByIdAsync(int id);
        Task CreateWorkOrderAsync(WorkOrder workOrder);
        Task UpdateWorkOrderAsync(WorkOrder workOrder);
        Task DeleteWorkOrderAsync(int id);
    }
}
