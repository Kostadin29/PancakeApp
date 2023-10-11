using PancakeApp.ViewModels.PancakeViewModels;

namespace PancakeApp.Services.Interfaces
{
    public interface IPancakeService
    {
        Task<List<PancakeListViewModel>> GetPancakeForCards();
        Task<PancakeIngredientsViewModel> GetPancakeIngredients(int id);
        Task<int> DeletePancakeById(int id);
        Task CreatePancake(PancakeViewModel pancakeViewModel);
        Task<PancakeViewModel> GetPancakeForEditing(int id);
        Task EditPancake(PancakeViewModel pancakeViewModel);
        List<PancakeViewModel> GetPancakesForPromotion();

        Task<List<PancakesForDropdownViewModel>> GetPancakesForDropdown();

    }
}
