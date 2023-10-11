using Microsoft.AspNetCore.Mvc;
using PancakeApp.Services.Interfaces;
using PancakeApp.ViewModels.OrderViewModels;

namespace PancakeApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IPancakeService _pancakeService;
        private ILocationService _locationService;

        public OrderController(IOrderService orderService, IPancakeService pancakeService, ILocationService locationService)
        {
            this._orderService = orderService;
            this._pancakeService = pancakeService;
            this._locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _orderService.GetOrdersForCards());
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _orderService.DeleteOrderById(id));
        }

        public async Task<IActionResult> Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Pancakes = await _pancakeService.GetPancakesForDropdown();
            ViewBag.Locations = await _locationService.GetLocationsForDropdown();

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel orderViewModel)
        {
            await _orderService.CreateOrder(orderViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            OrderViewModel orderViewModel = await _orderService.GetOrdersForEditing(id);
            ViewBag.Pancakes = await _pancakeService.GetPancakesForDropdown();
            ViewBag.Locations = await _locationService.GetLocationsForDropdown();

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderViewModel orderViewModel)
        {
            await _orderService.EditOrder(orderViewModel);
            return RedirectToAction("Index");
        }

    }
}
