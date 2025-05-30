using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.UserInterface.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "please enter user id", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "enter email as user id")]
        public required string UserId { get; set; }

        [Required(ErrorMessage = "please enter password", AllowEmptyStrings = false)]        
        public required string Password { get; set; }
    }
}
