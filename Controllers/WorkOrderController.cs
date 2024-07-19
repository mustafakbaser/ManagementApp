using ManagementApp.Models;
using ManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApp.Controllers
{
    [Route("workorders")]
    [ApiController]
    public class WorkOrderController : Controller
    {
        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        // GET: /workorders
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workOrders = await _workOrderService.GetAllWorkOrdersAsync();
            var workOrderViewModels = workOrders.Select(wo => new WorkOrderViewModel
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

            return View(workOrderViewModels);
        }

        // GET: /workorders/details/5
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var workOrder = await _workOrderService.GetWorkOrderByIdAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            var workOrderViewModel = new WorkOrderViewModel
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

            return View(workOrderViewModel);
        }

        // GET: /workorders/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /workorders/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Status,Assigner,AssignedTo,CreatedDate,LastUpdatedDate")] WorkOrderViewModel workOrderViewModel)
        {
            if (ModelState.IsValid)
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
                if (createdWorkOrder == null)
                {
                    return BadRequest("Failed to create work order.");
                }

                return RedirectToAction(nameof(Details), new { id = createdWorkOrder.Id });
            }
            return View(workOrderViewModel);
        }

        // GET: /workorders/edit/5
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var workOrder = await _workOrderService.GetWorkOrderByIdAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            var workOrderViewModel = new WorkOrderViewModel
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

            return View(workOrderViewModel);
        }

        // POST: /workorders/edit/5
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status,Assigner,AssignedTo,CreatedDate,LastUpdatedDate")] WorkOrderViewModel workOrderViewModel)
        {
            if (id != workOrderViewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
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
                if (updatedWorkOrder == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Details), new { id = updatedWorkOrder.Id });
            }

            return View(workOrderViewModel);
        }

        // GET: /workorders/delete/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var workOrder = await _workOrderService.GetWorkOrderByIdAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // POST: /workorders/delete/5
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _workOrderService.DeleteWorkOrderAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
