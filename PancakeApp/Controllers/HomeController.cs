using Microsoft.AspNetCore.Mvc;
using PancakeApp.Models;
using PancakeApp.Services.Interfaces;
using PancakeApp.ViewModels.HomeViewModels;
using System.Diagnostics;

namespace PancakeApp.Controllers
{
    public class HomeController : Controller
    {
        private IPancakeService _pancakeService;

        public HomeController(ILogger<HomeController> logger, IPancakeService _pancakeService)
        {
            this._pancakeService = _pancakeService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.PancakesOnPromotion = _pancakeService.GetPancakesForPromotion();

            return View(homeViewModel);
        }

        public IActionResult AboutUs()
        {
            return View();
        }


    }
}