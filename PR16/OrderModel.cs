namespace CrmDemo.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string ClientName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}