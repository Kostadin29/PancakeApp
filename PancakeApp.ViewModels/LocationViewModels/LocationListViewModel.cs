namespace PancakeApp.ViewModels.LocationViewModels
{
    public class LocationListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string OpensAt { get; set; } = string.Empty;
        public string ClosesAt { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
