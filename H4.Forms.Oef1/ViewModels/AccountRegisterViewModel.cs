
using H4.Forms.Oef1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace H4.Forms.Oef1.ViewModels
{
    public class AccountRegisterViewModel
    {

        [Required]
        [Display(Name = "Voornaam:")]
        
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Naam:")]

        public string Lastname { get; set; }
        [Required]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Paswoord:")]
        [DataType(DataType.Password)]
        [StringLength(6,MinimumLength = 2,ErrorMessage = "Paswoorden moeten tussen 2 en 6 zijn(waarom?)")]
        [Compare("PasswordRepeat",ErrorMessage = "Paswoorden moeten gelijk zijn!")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Herhaal paswoord:")]
        [DataType(DataType.Password)]
        public string PasswordRepeat { get; set; }
        
        //keeps the selected countryCode
        public string CountryCode { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        //role checkboxes
        public List<CheckboxModel> Roles { get; set; }


    }
}
