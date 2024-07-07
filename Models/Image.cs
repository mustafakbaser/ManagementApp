namespace ManagementApp.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public string ImageUrl { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
