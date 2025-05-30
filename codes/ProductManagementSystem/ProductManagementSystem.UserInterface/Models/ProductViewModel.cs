using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.UserInterface.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "enter product name")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 50, ErrorMessage = "name should not be less than 5 and more than 50 chars", MinimumLength = 5)]
        public required string Name { get; set; }


        public string? Description { get; set; }

        [Required(ErrorMessage = "enter price")]
        [DataType(DataType.Currency, ErrorMessage = "the value should be numerical")]
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Description}, {Price}";
        }
    }
}
