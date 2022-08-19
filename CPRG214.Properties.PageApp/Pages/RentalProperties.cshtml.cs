using System.Collections.Generic;
using CPRG214.Properties.BLL;
using CPRG214.Properties.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG214.Properties.PageApp.Pages
{
    public class RentalPropertiesModel : PageModel
    {
        public List<RentalProperty> Rentals { get; set; }
        public void OnGet()
        {
            Rentals = RentalsManager.GetAll();
        }
    }
}
