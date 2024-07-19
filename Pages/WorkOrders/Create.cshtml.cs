using ManagementApp.Models;
using ManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ManagementApp.Pages.WorkOrders
{
    public class CreateModel : PageModel
    {
        private readonly IWorkOrderService _workOrderService;

        public CreateModel(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        [BindProperty]
        public WorkOrderViewModel WorkOrder { get; set; }

        public void OnGet()
        {
            WorkOrder = new WorkOrderViewModel
            {
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var workOrder = new WorkOrder
            {
                Title = WorkOrder.Title,
                Description = WorkOrder.Description,
                Status = WorkOrder.Status,
                Assigner = WorkOrder.Assigner,
                AssignedTo = WorkOrder.AssignedTo,
                CreatedDate = WorkOrder.CreatedDate.ToUniversalTime(),
                LastUpdatedDate = WorkOrder.LastUpdatedDate.ToUniversalTime()
            };

            var createdWorkOrder = await _workOrderService.AddWorkOrderAsync(workOrder);
            if (createdWorkOrder == null)
            {
                return BadRequest("Failed to create work order.");
            }

            return RedirectToPage("./Details", new { id = createdWorkOrder.Id });
        }
    }
}
