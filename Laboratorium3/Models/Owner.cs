using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public class Owner
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię!")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [RegularExpression("^\\d{11}$")]
        [Required(ErrorMessage = "Proszę podać numer PESEL!")]
        [Display(Name = "PESEL")]
        public string Pesel { get; set; }

        [Phone]
        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Display(Name = "Adres email")]
        [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwa miasta/wioski!")]
        [Display(Name = "Nazwa miasta/wioski")]
        public string City { get; set; }

        [Display(Name = "Nazwa ulicy")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Proszę podać kod pocztowy!")]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę województwa!")]
        [Display(Name = "Województwo")]
        public string Region { get; set; }

        [ValidateNever]
        public List<Car> Cars { get; set; }
    }
}
