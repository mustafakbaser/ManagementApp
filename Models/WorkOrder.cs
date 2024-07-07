using System;
using System.Collections.Generic;

namespace ManagementApp.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Assigner { get; set; } // User Id of the assigner
        public string AssignedTo { get; set; } // User Id of the assignee
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public List<Document> Documents { get; set; }
        public List<Image> Images { get; set; }
    }
}
