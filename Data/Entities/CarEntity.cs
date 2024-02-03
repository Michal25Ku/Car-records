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
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Model { get; set; }

        [MaxLength(50)]
        public string? Producer { get; set; }

        [MaxLength(50)]
        public string? EngineCapacity { get; set; }

        [Range(0, int.MaxValue)]
        public int EnginePower { get; set; } = 0;

        [MaxLength(50)]
        public string? EngineType { get; set; }

        [MaxLength(10)]
        public string? LicensePlateNumber { get; set; }


        [Range(0, int.MaxValue)]
        public int State { get; set; } = 1;


        [Column("CreateDate")]
        public DateTime? Created { get; set; } = DateTime.Now;

        [Required]
        public int OwnerId { get; set; }
        public OwnerEntity? Owner { get; set; }
    }
}