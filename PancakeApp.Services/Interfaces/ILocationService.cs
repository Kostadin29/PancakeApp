using PancakeApp.ViewModels.LocationViewModels;

namespace PancakeApp.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationListViewModel>> GetAllLocations();
        Task<int> DeleteLocationById(int id);
        Task CreateLocation(LocationViewModel locationViewModel);
        Task<List<LocationsForDropDownViewModel>> GetLocationsForDropdown();
    }

}
