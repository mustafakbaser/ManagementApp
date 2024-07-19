using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagementApp.Models;
using ManagementApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApp.Pages.WorkOrders
{
    public class IndexModel : PageModel
    {
        private readonly IWorkOrderService _workOrderService;

        public IndexModel(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        public IList<WorkOrderViewModel> WorkOrders { get; set; }

        public async Task OnGetAsync()
        {
            var workOrders = await _workOrderService.GetAllWorkOrdersAsync();
            WorkOrders = workOrders.Select(wo => new WorkOrderViewModel
            {
                Id = wo.Id,
                Title = wo.Title,
                Description = wo.Description,
                Status = wo.Status,
                Assigner = wo.Assigner,
                AssignedTo = wo.AssignedTo,
                CreatedDate = wo.CreatedDate,
                LastUpdatedDate = wo.LastUpdatedDate
            }).ToList();
        }
    }
}
