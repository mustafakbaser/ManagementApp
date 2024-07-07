using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagementApp.Data;
using ManagementApp.Models;

namespace ManagementApp.Services
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkOrder>> GetWorkOrdersAsync()
        {
            return await _context.WorkOrders.Include(t => t.Documents).Include(t => t.Images).ToListAsync();
        }

        public async Task<WorkOrder> GetWorkOrderByIdAsync(int id)
        {
            return await _context.WorkOrders.Include(t => t.Documents).Include(t => t.Images)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateWorkOrderAsync(WorkOrder workOrder)
        {
            _context.WorkOrders.Add(workOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkOrderAsync(WorkOrder workOrder)
        {
            _context.WorkOrders.Update(workOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorkOrderAsync(int id)
        {
            var workOrder = await _context.WorkOrders.FindAsync(id);
            if (workOrder != null)
            {
                _context.WorkOrders.Remove(workOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}
