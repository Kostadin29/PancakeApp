using PancakeApp.Domain.Models;
using PancakeApp.ViewModels.LocationViewModels;

namespace PancakeApp.Mappers
{
    public static class LocationMapper
    {
        public static LocationListViewModel ToLocationListViewModel(this Location location)
        {
            return new LocationListViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                OpensAt = location.OpensAt,
                ClosesAt = location.ClosesAt,
                City = location.City
            };
        }

        public static Location ToLocation(this LocationViewModel locationViewModel)
        {
            return new Location()
            {
                Id = locationViewModel.Id,
                Name = locationViewModel.Name,
                Address = locationViewModel.Address,
                OpensAt = locationViewModel.OpensAt,
                ClosesAt = locationViewModel.ClosesAt,
                City = locationViewModel.City
            };
        }

        public static LocationsForDropDownViewModel ToLocationsForDropdown(this Location location)
        {
            return new LocationsForDropDownViewModel
            {
                Id = location.Id,
                Name = location.Name
            };
        }
    }
}
