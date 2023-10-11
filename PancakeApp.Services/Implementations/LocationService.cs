using PancakeApp.DataAccess.Repositories.Interfaces;
using PancakeApp.Domain.Models;
using PancakeApp.Mappers;
using PancakeApp.Services.Interfaces;
using PancakeApp.ViewModels.LocationViewModels;

namespace PancakeApp.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private IRepository<Location> _locationRepository;

        public LocationService(IRepository<Location> locationRepository)
        {
            this._locationRepository = locationRepository;
        }

        public Task CreateLocation(LocationViewModel locationViewModel)
        {
            return _locationRepository.Insert(locationViewModel.ToLocation());
        }

        public async Task<int> DeleteLocationById(int id)
        {
            return await _locationRepository.DeleteById(id);
        }

        public async Task<List<LocationListViewModel>> GetAllLocations()
        {
           List<Location> locationDb = await _locationRepository.GetAll();
            return locationDb.Select(x => x.ToLocationListViewModel()).ToList();
        }

        public async Task<List<LocationsForDropDownViewModel>> GetLocationsForDropdown()
        {
            List<Location> locationDb = await _locationRepository.GetAll();
            return locationDb.Select(x => x.ToLocationsForDropdown()).ToList();
        }
    }
}
