using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.UserInterface.Models
{
    public class ProductCommandViewModel
    {
        [Required(ErrorMessage = "enter product name")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "enter price")]
        [Range(1, 1000000)]
        public decimal Price { get; set; }
    }
}
