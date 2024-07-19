using ManagementApp.Models;
using ManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ManagementApp.Pages.WorkOrders
{
    public class DetailsModel : PageModel
    {
        private readonly IWorkOrderService _workOrderService;

        public DetailsModel(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        public WorkOrderViewModel WorkOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var workOrder = await _workOrderService.GetWorkOrderByIdAsync(id);

            if (workOrder == null)
            {
                return NotFound();
            }

            WorkOrder = new WorkOrderViewModel
            {
                Id = workOrder.Id,
                Title = workOrder.Title,
                Description = workOrder.Description,
                Status = workOrder.Status,
                Assigner = workOrder.Assigner,
                AssignedTo = workOrder.AssignedTo,
                CreatedDate = workOrder.CreatedDate,
                LastUpdatedDate = workOrder.LastUpdatedDate
            };

            return Page();
        }
    }
}
