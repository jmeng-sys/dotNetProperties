using System.Collections.Generic;
using System.Linq;
using CPRG214.Properties.Data;
using CPRG214.Properties.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System;

namespace CPRG214.Properties.BLL
{
    public class RentalsManager
    {
        public static List<RentalProperty> GetAll()
        {
            var context = new RentalsContext();           
            var rentals = context.RentalProperties.Include(r => r.Owner).Include(rp => rp.PropertyType).ToList();
            return rentals;
        }

        public static List<RentalProperty> GetAllByPropertyType(int id)
        {
            var context = new RentalsContext();
            var rentals = context.RentalProperties.
                Where(prop => prop.PropertyTypeId == id).
                Include(r => r.Owner).Include(rp => rp.PropertyType).ToList();
            return rentals;
        }

        public static void Add(RentalProperty rental)
        {
            var context = new RentalsContext();
            context.RentalProperties.Add(rental);
            context.SaveChanges();
        }
    }
}
