using System.ComponentModel.DataAnnotations;

namespace PancakeApp.ViewModels.PancakeViewModels
{
    public class PancakeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Pancake Name")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; } = string.Empty;
        [Display(Name = "Is On Promotion")]
        public bool IsOnPromotion { get; set; }
        [Display(Name = "Color")]
        public string Color { get; set; } = string.Empty;
        [Display(Name = "Has Protein")]
        public bool HasProtein { get; set; }
        [Display(Name = "Has Fruits")]
        public bool HasFruits { get; set; }
        [Display(Name = "Has Whipped Cream")]
        public bool HasWhippedCream { get; set; }
        [Display(Name = "Has Syrup")]
        public bool HasSyrup { get; set; }
        [Display(Name = "Has Candies")]
        public bool HasCandies { get; set; }

    }
}
