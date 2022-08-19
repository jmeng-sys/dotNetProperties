using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.Properties.Domain
{
    [Table("Owner")]
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Owner")]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        //navigation property
        public ICollection<RentalProperty> RentalProperties { get; set; }

    }
}
