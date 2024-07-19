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
        public string Assigner { get; set; }
        public string AssignedTo { get; set; }

        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value.ToUniversalTime();
        }

        private DateTime _lastUpdatedDate;
        public DateTime LastUpdatedDate
        {
            get => _lastUpdatedDate;
            set => _lastUpdatedDate = value.ToUniversalTime();
        }

        // Navigation properties
        public List<Document> Documents { get; set; } = new List<Document>();
        public List<Image> Images { get; set; } = new List<Image>();
    }
}
