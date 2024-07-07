using Microsoft.AspNetCore.Mvc;
using ManagementApp.Models;
using ManagementApp.Services;

namespace ManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkOrders()
        {
            var workOrders = await _workOrderService.GetWorkOrdersAsync();
            return Ok(workOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkOrder(int id)
        {
            var workOrder = await _workOrderService.GetWorkOrderByIdAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }
            return Ok(workOrder);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkOrder([FromBody] WorkOrder workOrder)
        {
            if (workOrder == null)
            {
                return BadRequest();
            }

            await _workOrderService.CreateWorkOrderAsync(workOrder);
            return CreatedAtAction(nameof(GetWorkOrder), new { id = workOrder.Id }, workOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkOrder(int id, [FromBody] WorkOrder workOrder)
        {
            if (workOrder == null || workOrder.Id != id)
            {
                return BadRequest();
            }

            var existingWorkOrder = await _workOrderService.GetWorkOrderByIdAsync(id);
            if (existingWorkOrder == null)
            {
                return NotFound();
            }

            await _workOrderService.UpdateWorkOrderAsync(workOrder);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOrder(int id)
        {
            var existingWorkOrder = await _workOrderService.GetWorkOrderByIdAsync(id);
            if (existingWorkOrder == null)
            {
                return NotFound();
            }

            await _workOrderService.DeleteWorkOrderAsync(id);
            return NoContent();
        }
    }
}