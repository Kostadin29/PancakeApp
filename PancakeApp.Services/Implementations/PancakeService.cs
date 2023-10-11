using PancakeApp.DataAccess.Repositories.Interfaces;
using PancakeApp.Domain.Models;
using PancakeApp.Mappers;
using PancakeApp.Services.Interfaces;
using PancakeApp.ViewModels.PancakeViewModels;
using System;

namespace PancakeApp.Services.Implementations
{
    public class PancakeService : IPancakeService
    {
        private IPancakeRepository _pancakeRepository;

        public PancakeService(IPancakeRepository _pancakeRepository)
        {
            this._pancakeRepository = _pancakeRepository;
        }

        public Task CreatePancake(PancakeViewModel pancakeViewModel)
        {
            return _pancakeRepository.Insert(pancakeViewModel.ToPancake());
        }

        public async Task<int> DeletePancakeById(int id)
        {
            return await _pancakeRepository.DeleteById(id);
        }

        public async Task EditPancake(PancakeViewModel pancakeViewModel)
        {
            Pancake pancakeDb = await _pancakeRepository.GetById(pancakeViewModel.Id);

            if(pancakeDb == null)
                throw new Exception("Pancake not found");

            pancakeDb.Name = pancakeViewModel.Name;
            pancakeDb.Price = pancakeViewModel.Price;
            pancakeDb.ImageUrl = pancakeViewModel.ImageUrl;
            pancakeDb.IsOnPromotion = pancakeViewModel.IsOnPromotion;
            pancakeDb.Color = pancakeViewModel.Color;
            pancakeDb.HasProtein = pancakeViewModel.HasProtein;
            pancakeDb.HasFruits = pancakeViewModel.HasFruits;
            pancakeDb.HasSyrup = pancakeViewModel.HasSyrup;
            pancakeDb.HasCandies = pancakeViewModel.HasCandies;
            pancakeDb.HasWhippedCream = pancakeViewModel.HasWhippedCream;

            await _pancakeRepository.Update(pancakeDb);
        }

        public async Task<List<PancakeListViewModel>> GetPancakeForCards()
        {
            List<Pancake> pancakeDb = await _pancakeRepository.GetAll();
            return pancakeDb.Select(x => x.ToPancakeListViewModel()).ToList();
        }

        public async Task<PancakeViewModel> GetPancakeForEditing(int id)
        {
            Pancake pancake = await _pancakeRepository.GetById(id);

            if (pancake == null)
                throw new Exception("Pancake was not found!");

            PancakeViewModel pancakeViewModel = pancake.ToPancakeViewModel();

            return pancakeViewModel;
        }

        public async Task<PancakeIngredientsViewModel> GetPancakeIngredients(int id)
        {
            Pancake pancakeDb = await _pancakeRepository.GetById(id);
            return pancakeDb.ToPancakeDetailsViewModel();
        }


        public List<PancakeViewModel> GetPancakesForPromotion()
        {
            var pancakesOnPromotion = _pancakeRepository.GetPancakesOnPromotion();

            var pancakeViewModels = pancakesOnPromotion.Select(pancake => new PancakeViewModel
            {

                Id = pancake.Id,
                Name = pancake.Name,
                Price = pancake.Price,
                ImageUrl = pancake.ImageUrl,
                Color = pancake.Color,
                IsOnPromotion = pancake.IsOnPromotion,
                HasCandies = pancake.HasCandies,
                HasFruits = pancake.HasFruits,
                HasProtein = pancake.HasProtein,
                HasSyrup = pancake.HasSyrup,
                HasWhippedCream = pancake.HasWhippedCream

            }).ToList();

            return pancakeViewModels;
        }

        public async Task<List<PancakesForDropdownViewModel>> GetPancakesForDropdown()
        {
            List<Pancake> pancakeDb = await _pancakeRepository.GetAll();
            return pancakeDb.Select(x => x.ToPancakesForDropdown()).ToList();
        }


    }
}
