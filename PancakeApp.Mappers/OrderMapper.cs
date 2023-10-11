using PancakeApp.Domain.Models;
using PancakeApp.ViewModels.OrderViewModels;

namespace PancakeApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderListViewModel ToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel()
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                PancakeShape = order.PancakeShape
            };
        }

       public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            var orderPancakes = orderViewModel.PancakeId
                               .Select(pancakeId => new PancakeOrder { PancakeId = pancakeId }).ToList();
            return new Order()
            {
                Id = orderViewModel.Id,
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                IsDelivered = orderViewModel.IsDelivered,
                PancakeShape = orderViewModel.PancakeShape,
                LocationId = orderViewModel.LocationId,


            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order) 
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                PancakeShape= order.PancakeShape,
                LocationId = order.LocationId,
                PancakeId = order.PancakeOrders.Select(x => x.PancakeId).ToList()
            };
        }
    }
}
