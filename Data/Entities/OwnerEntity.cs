using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Entities
{
    [Table("Owners")]
    public class OwnerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression("^\\d{11}$")]
        public string Pesel { get; set; }

        [Required]
        [Phone]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }
        public Address? Address { get; set; }
        public ISet<CarEntity> Cars { get; set; }
    }
}
