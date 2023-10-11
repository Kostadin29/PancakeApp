
namespace PancakeApp.Services.Implementations
{
    using PancakeApp.DataAccess.Repositories.Interfaces;
    using PancakeApp.Domain.Models;
    using PancakeApp.Mappers;
    using PancakeApp.Services.Interfaces;
    using PancakeApp.ViewModels.OrderViewModels;
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public async Task<int> DeleteOrderById(int id)
        {
            return await _orderRepository.DeleteById(id);
        }

        public Task CreateOrder(OrderViewModel orderViewModel)
        {
            return _orderRepository.Insert(orderViewModel.ToOrder());
        }


        public async Task EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = await _orderRepository.GetById(orderViewModel.Id);

            if (orderDb == null)
                throw new Exception("Order was not found.");


            orderDb.Id = orderViewModel.Id;
            orderDb.FullName = orderViewModel.FullName;
            orderDb.Address = orderViewModel.Address;
            orderDb.LocationId = orderViewModel.LocationId;
            orderDb.IsDelivered = orderViewModel.IsDelivered;
            orderDb.PancakeShape = orderViewModel.PancakeShape;

            await _orderRepository.Update(orderDb);
        }

        public async Task<List<OrderListViewModel>> GetOrdersForCards()
        {
            List<Order> ordersDb = await _orderRepository.GetAll();

            return ordersDb.Select(x => x.ToOrderListViewModel()).ToList();
        }

        public async Task<OrderViewModel> GetOrdersForEditing(int id)
        {
            Order order = await _orderRepository.GetById(id);

            if (order == null)
                throw new Exception("Order was not found.");

            OrderViewModel orderViewModel = order.ToOrderViewModel();

            return orderViewModel;
        }
    }
}
