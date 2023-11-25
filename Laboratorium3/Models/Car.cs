using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public class Car
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać model samochodu!")]
        [Display(Name = "Model samochodu")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Proszę podać producenta samochodu!")]
        [Display(Name = "Producent")]
        public string? Producer { get; set; }

        [Required(ErrorMessage = "Proszę podać pojemnosc silnika!")]
        [Display(Name = "Pojemnosc silnika")]
        public string? EngineCapacity { get; set; }

        [Required(ErrorMessage = "Proszę podać Moc silnika!")]
        [Display(Name = "Moc silnika")]
        public int EnginePower { get; set; }

        [Required(ErrorMessage = "Proszę podać typ silnika!")]
        [Display(Name = "Typ silnika")]
        public string? EngineType { get; set; }

        [Required(ErrorMessage = "Proszę podać numer rejestracyjny!")]
        [Display(Name = "Numer rejestracyjny")]
        public string? LicensePlateNumber { get; set; }

        public CarContactDetails Owner { get; set; } = default!;

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }
       
        [HiddenInput]
        public DateTime Created { get; set; }
    }
}
