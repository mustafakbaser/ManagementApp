using ManagementApp.Data;
using ManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Services
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkOrder>> GetAllWorkOrdersAsync()
        {
            return await _context.WorkOrders.Include(w => w.Documents).Include(w => w.Images).ToListAsync();
        }

        public async Task<WorkOrder> GetWorkOrderByIdAsync(int id)
        {
            return await _context.WorkOrders.Include(w => w.Documents).Include(w => w.Images).FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<WorkOrder> AddWorkOrderAsync(WorkOrder workOrder)
        {
            _context.WorkOrders.Add(workOrder);
            await _context.SaveChangesAsync();
            return workOrder;
        }

        public async Task<WorkOrder> UpdateWorkOrderAsync(WorkOrder workOrder)
        {
            _context.Entry(workOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return workOrder;
        }

        public async Task<bool> DeleteWorkOrderAsync(int id)
        {
            var workOrder = await _context.WorkOrders.FindAsync(id);
            if (workOrder == null)
            {
                return false;
            }

            _context.WorkOrders.Remove(workOrder);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
