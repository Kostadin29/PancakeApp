using PancakeApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PancakeApp.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; } 
        [Display(Name = "Please enter your full name ")]
        public  string FullName { get; set; } = string.Empty;
        [Display(Name = "Please enter your address ")]
        public string Address { get; set; } = string.Empty;
        [Display(Name = "Is your order delivered ?")]
        public bool IsDelivered { get; set; }
        [Display(Name = "Select your Pancake shape")]
        public PancakeShapeEnum PancakeShape { get; set; }
        [Display(Name = "Select from which shop you want to order.")]
        public int LocationId { get; set; }
        [Display(Name = "Choose pancake")]
        public List<int> PancakeId { get; set; }   

    }
}
