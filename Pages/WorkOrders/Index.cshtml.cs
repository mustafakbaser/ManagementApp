using Microsoft.AspNetCore.Mvc;
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
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            const int pageSize = 10; // Number of records for every page (Pagination)

            var workOrders = await _workOrderService.GetAllWorkOrdersAsync();
            var count = workOrders.Count();

            WorkOrders = workOrders
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(wo => new WorkOrderViewModel
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

            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
