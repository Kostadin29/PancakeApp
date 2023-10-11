
namespace PancakeApp.Domain.Models
{
    using PancakeApp.Domain.Enums;
    public class PancakeOrder : BaseEntity
    {
        public Pancake Pancake { get; set; }
        public int PancakeId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public PancakeShapeEnum PancakeShape { get; set; }
    }
}
