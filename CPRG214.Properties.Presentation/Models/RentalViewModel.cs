using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Properties.Presentation.Models
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Rent { get; set; }
        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }
        public string Owner { get; set; }
    }
}
