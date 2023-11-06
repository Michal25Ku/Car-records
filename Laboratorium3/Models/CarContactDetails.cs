using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public class CarContactDetails
    {
        [Required(ErrorMessage = "Proszę podać imię!")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        public string? LastName { get; set; }

        [Phone]
        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        public string? PhoneNumber { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
        public string? Email { get; set; }
    }
}
