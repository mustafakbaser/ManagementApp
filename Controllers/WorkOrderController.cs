using ManagementApp.Models;
using ManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager,Engineer")]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkOrders()
        {
            var workOrders = await _workOrderService.GetAllWorkOrdersAsync();
            return Ok(workOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkOrderById(int id)
        {
            var workOrder = await _workOrderService.GetWorkOrderByIdAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }
            return Ok(workOrder);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> AddWorkOrder([FromBody] WorkOrderViewModel workOrderViewModel)
        {
            var workOrder = new WorkOrder
            {
                Title = workOrderViewModel.Title,
                Description = workOrderViewModel.Description,
                Status = workOrderViewModel.Status,
                Assigner = workOrderViewModel.Assigner,
                AssignedTo = workOrderViewModel.AssignedTo,
                CreatedDate = workOrderViewModel.CreatedDate,
                LastUpdatedDate = workOrderViewModel.LastUpdatedDate
            };

            var createdWorkOrder = await _workOrderService.AddWorkOrderAsync(workOrder);
            return CreatedAtAction(nameof(GetWorkOrderById), new { id = createdWorkOrder.Id }, createdWorkOrder);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,Engineer")]
        public async Task<IActionResult> UpdateWorkOrder(int id, [FromBody] WorkOrderViewModel workOrderViewModel)
        {
            if (id != workOrderViewModel.Id)
            {
                return BadRequest();
            }

            var workOrder = new WorkOrder
            {
                Id = workOrderViewModel.Id,
                Title = workOrderViewModel.Title,
                Description = workOrderViewModel.Description,
                Status = workOrderViewModel.Status,
                Assigner = workOrderViewModel.Assigner,
                AssignedTo = workOrderViewModel.AssignedTo,
                CreatedDate = workOrderViewModel.CreatedDate,
                LastUpdatedDate = workOrderViewModel.LastUpdatedDate
            };

            var updatedWorkOrder = await _workOrderService.UpdateWorkOrderAsync(workOrder);
            return Ok(updatedWorkOrder);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteWorkOrder(int id)
        {
            var result = await _workOrderService.DeleteWorkOrderAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
