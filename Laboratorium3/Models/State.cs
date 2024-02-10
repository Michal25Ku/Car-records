using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public enum State
    {
        [Display(Name = "Sprawny")]Operation = 1,
        [Display(Name = "Uszkodzony")]Demage = 2,
    }
}
