
using System.ComponentModel.DataAnnotations;

namespace IdentityProvider.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}