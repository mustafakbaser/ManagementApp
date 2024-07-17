namespace ManagementApp.Models
{
    public class WorkOrderViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Assigner { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public IEnumerable<Document> Documents { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}