using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public class Car
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać model samochodu!")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Proszę podać producenta samochodu!")]
        public string? Producer { get; set; }

        [Required(ErrorMessage = "Proszę podać pojemnosc silnika!")]
        public string? EngineCapacity { get; set; }

        [Required(ErrorMessage = "Proszę podać Moc silnika!")]
        public int? EnginePower { get; set; }

        [Required(ErrorMessage = "Proszę podać typ silnika!")]
        public string? EngineType { get; set; }

        [Required(ErrorMessage = "Proszę podać numer rejestracyjny!")]
        public string? LicensePlateNumber { get; set; }

        public CarContactDetails Owner { get; set; } = default!;
    }
}
