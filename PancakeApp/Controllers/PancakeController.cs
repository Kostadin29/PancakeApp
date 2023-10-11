using Microsoft.AspNetCore.Mvc;
using PancakeApp.Services.Interfaces;
using PancakeApp.ViewModels.PancakeViewModels;
using System.Runtime.CompilerServices;

namespace PancakeApp.Controllers
{
    public class PancakeController : Controller
    {
        private IPancakeService _pancakeService;

        public PancakeController(IPancakeService _pancakeService) 
        {
            this._pancakeService = _pancakeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pancakeService.GetPancakeForCards());
        }

        public async Task<IActionResult> Ingredients(int id)
        {
            return View(await _pancakeService.GetPancakeIngredients(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pancakeService.DeletePancakeById(id));
        }

        public IActionResult Create()
        {
            PancakeViewModel pancakeViewModel = new PancakeViewModel();

            return View(pancakeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PancakeViewModel pancakeViewModel)
        {
            await _pancakeService.CreatePancake(pancakeViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            PancakeViewModel pancakeViewModel = await _pancakeService.GetPancakeForEditing(id);

            return View(pancakeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PancakeViewModel pancakeViewModel)
        {
            await _pancakeService.EditPancake(pancakeViewModel);

            return RedirectToAction("Index");
        }

    }
}
