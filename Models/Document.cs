namespace ManagementApp.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public string DocumentUrl { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
