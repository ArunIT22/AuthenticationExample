using System.ComponentModel.DataAnnotations;

namespace AuthenticationExample.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        public string? EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string? ReturnUrl { get; set; }
    }
}
