using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public class CarContactDetails
    {
        [Required(ErrorMessage = "Proszę podać imię!")]
        [Display(Name = "Imię")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        [Display(Name = "Nazwisko")]
        public string? LastName { get; set; }

        [Phone]
        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        [Display(Name = "Numer telefonu")]
        public string? PhoneNumber { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Display(Name = "Adres email")]
        [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
        public string? Email { get; set; }
    }
}
