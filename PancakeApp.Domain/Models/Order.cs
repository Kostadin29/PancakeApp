using PancakeApp.Domain.Enums;
using System.Data.Common;

namespace PancakeApp.Domain.Models
{
    public class Order : BaseEntity
    {
        public PancakeShapeEnum PancakeShape { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsDelivered { get; set; }
        public List<PancakeOrder> PancakeOrders { get; set; } = new List<PancakeOrder>();
        public Location Location { get; set; }
        public int LocationId { get; set; }

    }
}
