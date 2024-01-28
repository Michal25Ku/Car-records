using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Cars")]
    public class CarEntity
    {
        public int CarId { get; set; }
        public string? Model { get; set; }
        public string? Producer { get; set; }
        public string? EngineCapacity { get; set; }
        public int EnginePower { get; set; }
        public string? EngineType { get; set; }
        public string? LicensePlateNumber { get; set; }
        public DateTime Created { get; set; }
        public int Priority { get; set; }
        public CarContactDetailsEntity ContactDetails { get; set; } = default!;
    }
}