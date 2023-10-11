using PancakeApp.ViewModels.OrderViewModels;

namespace PancakeApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderListViewModel>> GetOrdersForCards();
        Task<int> DeleteOrderById(int id);

        Task CreateOrder(OrderViewModel orderViewModel);

        Task<OrderViewModel> GetOrdersForEditing(int id);

        Task EditOrder(OrderViewModel orderViewModel);
    }
}
