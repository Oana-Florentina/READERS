
using System.ComponentModel.DataAnnotations;


namespace Lunatic.Application.Models.Identity {
    public class LoginModel {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;
    }
}
