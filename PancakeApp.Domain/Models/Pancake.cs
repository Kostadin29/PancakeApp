namespace PancakeApp.Domain.Models
{
    public class Pancake : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public bool IsOnPromotion { get; set; }
        public bool HasProtein { get; set; }
        public bool HasFruits { get; set; }
        public bool HasWhippedCream { get; set; }
        public bool HasSyrup { get; set; }
        public bool HasCandies { get; set; }
        public List<PancakeOrder> PancakeOrders { get; set; } = new List<PancakeOrder>();

    }
}
