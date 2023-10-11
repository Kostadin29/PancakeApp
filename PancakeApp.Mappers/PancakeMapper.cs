using PancakeApp.Domain.Models;
using PancakeApp.ViewModels.PancakeViewModels;

namespace PancakeApp.Mappers
{
    public static class PancakeMapper
    {
        public static PancakeListViewModel ToPancakeListViewModel(this Pancake pancake)
        {
            return new PancakeListViewModel()
            {
                Id = pancake.Id,
                Name = pancake.Name,
                Price = pancake.Price,
                ImageUrl = pancake.ImageUrl,
                IsOnPromotion = pancake.IsOnPromotion
            };
        }

        public static PancakeIngredientsViewModel ToPancakeDetailsViewModel(this Pancake pancake)
        {
            return new PancakeIngredientsViewModel()
            {
                Name = pancake.Name,
                Price = pancake.Price,
                ImageUrl = pancake.ImageUrl,
                IsOnPromotion = pancake.IsOnPromotion,
                Color = pancake.Color,
                HasProtein = pancake.HasProtein,
                HasCandies = pancake.HasCandies,
                HasFruits = pancake.HasFruits,
                HasSyrup = pancake.HasSyrup,
                HasWhippedCream = pancake.HasWhippedCream
            };
        }

        public static Pancake ToPancake(this PancakeViewModel pancakeViewModel)
        {
            return new Pancake()
            {
                Id = pancakeViewModel.Id,
                Name = pancakeViewModel.Name,
                Price = pancakeViewModel.Price,
                ImageUrl = pancakeViewModel.ImageUrl,
                IsOnPromotion= pancakeViewModel.IsOnPromotion,
                Color = pancakeViewModel.Color,
                HasProtein = pancakeViewModel.HasProtein,
                HasCandies = pancakeViewModel.HasCandies,
                HasFruits = pancakeViewModel.HasFruits,
                HasSyrup = pancakeViewModel.HasSyrup,
                HasWhippedCream = pancakeViewModel.HasWhippedCream
              
            };
        }

        public static PancakeViewModel ToPancakeViewModel(this Pancake pancake)
        {
            return new PancakeViewModel()
            {
                Id = pancake.Id,
                Name = pancake.Name,
                Price = pancake.Price,
                ImageUrl = pancake.ImageUrl,
                IsOnPromotion = pancake.IsOnPromotion,
                Color = pancake.Color,
                HasProtein = pancake.HasProtein,
                HasCandies = pancake.HasCandies,
                HasFruits = pancake.HasFruits,
                HasSyrup = pancake.HasSyrup,
                HasWhippedCream = pancake.HasWhippedCream
            };
        }

        public static PancakesForDropdownViewModel ToPancakesForDropdown(this Pancake pancake)
        {
            return new PancakesForDropdownViewModel()
            {
                Id = pancake.Id,
                Name = pancake.Name
            };
        }
    }
}
