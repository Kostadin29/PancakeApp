using PancakeApp.Domain.Enums;

namespace PancakeApp.ViewModels.OrderViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsDelivered { get; set; }
        public PancakeShapeEnum PancakeShape { get; set; }

    }
}
