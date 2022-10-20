using System.ComponentModel.DataAnnotations;

namespace H4.Forms.Oef1.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required(ErrorMessage = "Geef gebruikersnaam in!")]
        [Display(Name = "Gebruikersnaam:")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Moet emailadres zijn!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Geef paswoord in!")]
        [Display(Name = "Wachtwoord:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Onthoud me")]
        public bool RememberMe { get; set; }
    }
}
