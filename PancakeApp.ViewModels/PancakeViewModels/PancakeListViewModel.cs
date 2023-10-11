namespace PancakeApp.ViewModels.PancakeViewModels
{
    public class PancakeListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsOnPromotion { get; set; }
    }
}
