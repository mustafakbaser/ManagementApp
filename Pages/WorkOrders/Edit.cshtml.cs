using ManagementApp.Models;
using ManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ManagementApp.Pages.WorkOrders
{
    public class EditModel : PageModel
    {
        private readonly IWorkOrderService _workOrderService;

        public EditModel(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var workOrder = new WorkOrder
            {
                Id = WorkOrder.Id,
                Title = WorkOrder.Title,
                Description = WorkOrder.Description,
                Status = WorkOrder.Status,
                Assigner = WorkOrder.Assigner,
                AssignedTo = WorkOrder.AssignedTo,
                CreatedDate = WorkOrder.CreatedDate, // Bu değişmez
                LastUpdatedDate = DateTime.UtcNow.AddHours(3) // GMT+3
            };

            var updatedWorkOrder = await _workOrderService.UpdateWorkOrderAsync(workOrder);
            if (updatedWorkOrder == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Details", new { id = updatedWorkOrder.Id });
        }
    }
}
