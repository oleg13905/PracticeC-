namespace CRMApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int DealsCount { get; set; }
        public string Status { get; set; }
    }
}