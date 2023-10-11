using Microsoft.AspNetCore.Mvc;
using PancakeApp.Services.Interfaces;
using PancakeApp.ViewModels.LocationViewModels;

namespace PancakeApp.Controllers
{
    public class LocationController : Controller
    {
        private ILocationService _locationService;
        public LocationController(ILocationService _locationService)
        {
            this._locationService = _locationService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _locationService.GetAllLocations());
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _locationService.DeleteLocationById(id));
        }


        public IActionResult Create()
        {
            LocationViewModel locationViewModel = new LocationViewModel();
            return View(locationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationViewModel locationViewModel)
        {
            await _locationService.CreateLocation(locationViewModel);
            return View(locationViewModel);
        }

    }
}
