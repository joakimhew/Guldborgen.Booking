using System.ComponentModel.DataAnnotations;

namespace Guldborgen.Booking.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Epost-address")]
        [EmailAddress(ErrorMessage = "Epost-addressen som du angav är inte korrekt!")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}