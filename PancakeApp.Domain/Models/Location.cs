namespace PancakeApp.Domain.Models
{
    public class Location : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string OpensAt { get; set; } = string.Empty;
        public string ClosesAt { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
