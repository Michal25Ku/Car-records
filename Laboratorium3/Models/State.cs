using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public enum State
    {
        [Display(Name = "Uszkodzony")]Low = 1,
        [Display(Name = "Igła")]Normal = 2,
    }
}
